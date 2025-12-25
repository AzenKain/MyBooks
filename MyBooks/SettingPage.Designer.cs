

namespace MyBooks
{
    partial class SettingPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private Label lblTitle;
        private Button btnBackup;
        private Button btnUpload;
        private GroupBox grpCurrentProfile;
        private Label lblCurrentProfile;
        private TextBox txtNewProfile;
        private Button btnAddProfile;
        private Button btnDeleteProfile;
        private DataGridView dgvProfiles;
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnBackup = new Button();
            btnUpload = new Button();
            grpCurrentProfile = new GroupBox();
            lblCurrentProfile = new Label();
            txtNewProfile = new TextBox();
            btnAddProfile = new Button();
            btnDeleteProfile = new Button();
            dgvProfiles = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            btnSetDefault = new Button();
            openFileDialog1 = new OpenFileDialog();
            grpCurrentProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(50, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Trang cài đặt";
            // 
            // btnBackup
            // 
            btnBackup.Anchor = AnchorStyles.None;
            btnBackup.BackColor = Color.SandyBrown;
            btnBackup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.Location = new Point(50, 80);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(160, 40);
            btnBackup.TabIndex = 1;
            btnBackup.Text = "Sao lưu dữ liệu";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.None;
            btnUpload.BackColor = Color.MediumSpringGreen;
            btnUpload.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpload.Location = new Point(244, 80);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(160, 40);
            btnUpload.TabIndex = 2;
            btnUpload.Text = "Tải lên dữ liệu";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // grpCurrentProfile
            // 
            grpCurrentProfile.Anchor = AnchorStyles.None;
            grpCurrentProfile.Controls.Add(lblCurrentProfile);
            grpCurrentProfile.Location = new Point(50, 140);
            grpCurrentProfile.Name = "grpCurrentProfile";
            grpCurrentProfile.Size = new Size(500, 80);
            grpCurrentProfile.TabIndex = 3;
            grpCurrentProfile.TabStop = false;
            grpCurrentProfile.Text = "Profile hiện tại";
            // 
            // lblCurrentProfile
            // 
            lblCurrentProfile.AutoSize = true;
            lblCurrentProfile.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentProfile.Location = new Point(20, 35);
            lblCurrentProfile.Name = "lblCurrentProfile";
            lblCurrentProfile.Size = new Size(107, 25);
            lblCurrentProfile.TabIndex = 0;
            lblCurrentProfile.Text = "Chưa chọn";
            // 
            // txtNewProfile
            // 
            txtNewProfile.Anchor = AnchorStyles.None;
            txtNewProfile.Location = new Point(50, 240);
            txtNewProfile.Name = "txtNewProfile";
            txtNewProfile.PlaceholderText = "Nhập tên profile";
            txtNewProfile.Size = new Size(400, 27);
            txtNewProfile.TabIndex = 4;
            // 
            // btnAddProfile
            // 
            btnAddProfile.Anchor = AnchorStyles.None;
            btnAddProfile.BackColor = Color.MediumTurquoise;
            btnAddProfile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddProfile.Location = new Point(494, 237);
            btnAddProfile.Name = "btnAddProfile";
            btnAddProfile.Size = new Size(180, 32);
            btnAddProfile.TabIndex = 5;
            btnAddProfile.Text = "Thêm profile";
            btnAddProfile.UseVisualStyleBackColor = false;
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Anchor = AnchorStyles.None;
            btnDeleteProfile.BackColor = Color.LightCoral;
            btnDeleteProfile.Enabled = false;
            btnDeleteProfile.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteProfile.Location = new Point(897, 237);
            btnDeleteProfile.Name = "btnDeleteProfile";
            btnDeleteProfile.Size = new Size(180, 32);
            btnDeleteProfile.TabIndex = 6;
            btnDeleteProfile.Text = "Xóa profile";
            btnDeleteProfile.UseVisualStyleBackColor = false;
            // 
            // dgvProfiles
            // 
            dgvProfiles.AllowUserToAddRows = false;
            dgvProfiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProfiles.ColumnHeadersHeight = 29;
            dgvProfiles.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgvProfiles.Location = new Point(50, 290);
            dgvProfiles.Name = "dgvProfiles";
            dgvProfiles.ReadOnly = true;
            dgvProfiles.RowHeadersWidth = 51;
            dgvProfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfiles.Size = new Size(1262, 514);
            dgvProfiles.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn1.HeaderText = "STT";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "Tên profile";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // btnSetDefault
            // 
            btnSetDefault.Anchor = AnchorStyles.None;
            btnSetDefault.BackColor = Color.SandyBrown;
            btnSetDefault.Enabled = false;
            btnSetDefault.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSetDefault.Location = new Point(695, 237);
            btnSetDefault.Name = "btnSetDefault";
            btnSetDefault.Size = new Size(180, 32);
            btnSetDefault.TabIndex = 8;
            btnSetDefault.Text = "Chọn làm mặc định";
            btnSetDefault.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // SettingPage
            // 
            Controls.Add(btnSetDefault);
            Controls.Add(lblTitle);
            Controls.Add(btnBackup);
            Controls.Add(btnUpload);
            Controls.Add(grpCurrentProfile);
            Controls.Add(txtNewProfile);
            Controls.Add(btnAddProfile);
            Controls.Add(btnDeleteProfile);
            Controls.Add(dgvProfiles);
            Name = "SettingPage";
            Size = new Size(1362, 850);
            grpCurrentProfile.ResumeLayout(false);
            grpCurrentProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewButtonColumn colRename;
        private DataGridViewButtonColumn colDelete;
        private Button btnSetDefault;
        private OpenFileDialog openFileDialog1;
    }
}
