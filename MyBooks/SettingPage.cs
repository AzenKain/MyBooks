using MyBooks.Data;
using MyBooks.Services;
using MyBooks.State;
using MyBooks.Utils;
using System.IO.Compression;


namespace MyBooks
{
    public partial class SettingPage : UserControl
    {
        private int? _selectedRowIndex = null;
        private readonly AuthService authService = new AuthService();

        public SettingPage()
        {
            InitializeComponent();


            btnAddProfile.Click += btnAddProfile_Click;
            btnDeleteProfile.Click += btnDeleteProfile_Click;
            btnSetDefault.Click += btnSetDefault_Click;

            dgvProfiles.CellClick += dgvProfiles_CellClick;
            dgvProfiles.MouseDown += dgvProfiles_MouseDown;

            ResetSelection();

            AppStore.Changed += OnAppStateChanged;
            lblCurrentProfile.Text = AppStore.States.Setting.currentProfile.ProfileName;
            var listProfiles = authService.GetAllProfiles();
            foreach (var profile in listProfiles)
            {
                dgvProfiles.Rows.Add(profile.Id, profile.ProfileName);
            }

        }

        private void OnAppStateChanged(AppState state)
        {
            lblCurrentProfile.Text = state.Setting.currentProfile.ProfileName;
        }

        private void dgvProfiles_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (_selectedRowIndex == e.RowIndex)
            {
                ResetSelection();
                return;
            }

            _selectedRowIndex = e.RowIndex;

            var row = dgvProfiles.Rows[e.RowIndex];
            var name = row.Cells[1].Value?.ToString();

            dgvProfiles.ClearSelection();
            row.Selected = true;

            txtNewProfile.Text = name;
            btnAddProfile.Text = "Cập nhật profile";
            btnDeleteProfile.Enabled = true;
            btnDeleteProfile.Visible = true;
            btnSetDefault.Enabled = true;
            btnSetDefault.Visible = true;
        }

        private void dgvProfiles_MouseDown(object? sender, MouseEventArgs e)
        {
            var hit = dgvProfiles.HitTest(e.X, e.Y);
            if (hit.RowIndex == -1)
            {
                ResetSelection();
            }
        }

        private void btnAddProfile_Click(object? sender, EventArgs e)
        {
            var name = txtNewProfile.Text.Trim();
            if (string.IsNullOrEmpty(name))
                return;

            if (_selectedRowIndex == null)
            {
                int index = dgvProfiles.Rows.Count + 1;
                var rsp = authService.CreateProfile(name);
                if (!rsp.Success || rsp.Data == null)
                {
                    RJMessageBox.Show(rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvProfiles.Rows.Add(rsp.Data.Id, name);
            }
            else
            {
                dgvProfiles.Rows[_selectedRowIndex.Value].Cells[1].Value = name;
                var profileId = Convert.ToInt32(dgvProfiles.Rows[_selectedRowIndex.Value].Cells[0].Value);
                var rsp = authService.UpdateProfile(profileId, name);
                if (!rsp.Success || rsp.Data == null)
                {
                    RJMessageBox.Show(rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ResetSelection();
        }

        private void btnDeleteProfile_Click(object? sender, EventArgs e)
        {
            if (_selectedRowIndex == null)
                return;

            var profileId = Convert.ToInt32(dgvProfiles.Rows[_selectedRowIndex.Value].Cells[0].Value);
            var rsp = authService.DeleleProfile(profileId);
            if (!rsp.Success)
            {
                RJMessageBox.Show(rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvProfiles.Rows.RemoveAt(_selectedRowIndex.Value);
            ResetSelection();
        }

        private void btnSetDefault_Click(object? sender, EventArgs e)
        {
            if (_selectedRowIndex == null)
                return;
            var profileId = Convert.ToInt32(dgvProfiles.Rows[_selectedRowIndex.Value].Cells[0].Value);
            var rsp = authService.SwitchProfile(profileId);
            if (!rsp.Success || rsp.Data == null)
            {
                RJMessageBox.Show(rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ResetSelection();
        }

        private void ResetSelection()
        {
            dgvProfiles.ClearSelection();
            _selectedRowIndex = null;

            txtNewProfile.Clear();
            btnAddProfile.Text = "Thêm profile";
            btnDeleteProfile.Enabled = false;
            btnDeleteProfile.Visible = false;
            btnSetDefault.Enabled = false;
            btnSetDefault.Visible = false;

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var outputDir = dialog.SelectedPath;
            var time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var zipPath = Path.Combine(outputDir, $"backup_{time}.zip");

            var baseDir = AppContext.BaseDirectory;
            var dbPath = Path.Combine(baseDir, "database.db");
            var booksPath = Path.Combine(baseDir, "books");

            using var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create);

            var tempDb = Path.Combine(Path.GetTempPath(), $"database_{Guid.NewGuid()}.db");

            File.Copy(dbPath, tempDb, true);

            zip.CreateEntryFromFile(tempDb, "database.db", CompressionLevel.Optimal);

            File.Delete(tempDb);

            if (Directory.Exists(booksPath))
                FS.AddDirectoryToZip(zip, booksPath, "books");

            System.Diagnostics.Process.Start("explorer.exe", outputDir);
            RJMessageBox.Show($"Sao lưu thành công tại {zipPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog();
            dialog.Filter = "Zip files (*.zip)|*.zip";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var zipPath = dialog.FileName;

            using var zip = ZipFile.OpenRead(zipPath);

            var hasDb = zip.Entries.Any(e => e.FullName == "database.db");
            var hasBooks = zip.Entries.Any(e => e.FullName.StartsWith("books/"));

            if (!hasDb || !hasBooks)
            {
                RJMessageBox.Show(
                    "File backup không hợp lệ (thiếu database.db hoặc thư mục books)",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var baseDir = AppContext.BaseDirectory;
            var dbPath = Path.Combine(baseDir, "database.db");
            var booksPath = Path.Combine(baseDir, "books");

            Database.DisconnectAll();

            var tempDir = Path.Combine(Path.GetTempPath(), $"restore_{Guid.NewGuid()}");
            Directory.CreateDirectory(tempDir);

            try
            {
                zip.ExtractToDirectory(tempDir);

                var newDb = Path.Combine(tempDir, "database.db");
                var newBooks = Path.Combine(tempDir, "books");

                if (File.Exists(dbPath))
                    File.Delete(dbPath);

                File.Copy(newDb, dbPath, true);

                if (Directory.Exists(booksPath))
                    Directory.Delete(booksPath, true);

                FS.CopyDirectory(newBooks, booksPath);

                using var conn = Database.GetConnection();
            }
            catch (Exception ex)
            {
                RJMessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }

            var currentProfile = authService.GetCurrentProfile();
            AppStore.Update(state => state with
            {
                Setting = state.Setting with
                {
                    currentProfile = currentProfile
                }
            });

            var listProfiles = authService.GetAllProfiles();
            dgvProfiles.Rows.Clear();
            foreach (var profile in listProfiles)
            {
                dgvProfiles.Rows.Add(profile.Id, profile.ProfileName);
            }

            authService.SwitchProfile(currentProfile.Id);
            RJMessageBox.Show("Phục hồi dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
