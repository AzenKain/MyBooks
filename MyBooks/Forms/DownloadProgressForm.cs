using MyBooks.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBooks.Forms
{
    public partial class DownloadProgressForm : Form
    {
        public DownloadProgressForm()
        {
            InitializeComponent();
        }

        private readonly DownloadService service = new();

        public DownloadProgressForm(string url, string output)
        {
            InitializeComponent();
            Shown += async (_, _) => await Start(url, output);
        }

        async Task Start(string url, string output)
        {
            try
            {
                await service.DownloadAsync(url, output, UpdateUI);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.Abort;
                Close();
            }
        }

        void UpdateUI(long current, long total, double speed)
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateUI(current, total, speed));
                return;
            }

            int percent = total > 0 ? (int)(current * 100 / total) : 0;

            modernProgressBar1.Value = percent;
            lblPercent.Text = percent + "%";
            lblSize.Text = $"{current / 1024 / 1024} / {total / 1024 / 1024} MB";
            lblSpeed.Text = $"{speed:F1} KB/s";
        }
    }
}
