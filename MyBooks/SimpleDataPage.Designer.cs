namespace MyBooks
{
    partial class SimpleDataPage
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
        private Label lblTitle;
        private FlowLayoutPanel pnlFilter;
        private Panel pnlContent;
        private ListView lvLeft;
        private ListView lvRight;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlFilter = new FlowLayoutPanel();
            pnlContent = new Panel();
            lvLeft = new ListView();
            lvRight = new ListView();

            SuspendLayout();

            // ===== Title =====
            lblTitle.Text = "Khác";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);

            // ===== Filter A-Z =====
            pnlFilter.Location = new Point(20, 70);
            pnlFilter.Size = new Size(1300, 45);
            pnlFilter.WrapContents = false;
            pnlFilter.AutoScroll = true;


            // ===== Content Panel =====
            pnlContent.Location = new Point(20, 130);
            pnlContent.Size = new Size(1300, 690);

            // ===== ListView Left =====
            lvLeft.View = View.Details;
            lvLeft.FullRowSelect = true;
            lvLeft.HeaderStyle = ColumnHeaderStyle.None;
            lvLeft.Columns.Add("", 600);
            lvLeft.Location = new Point(0, 0);
            lvLeft.Size = new Size(630, 690);

            // ===== ListView Right =====
            lvRight.View = View.Details;
            lvRight.FullRowSelect = true;
            lvRight.HeaderStyle = ColumnHeaderStyle.None;
            lvRight.Columns.Add("", 600);
            lvRight.Location = new Point(650, 0);
            lvRight.Size = new Size(630, 690);

            pnlContent.Controls.Add(lvLeft);
            pnlContent.Controls.Add(lvRight);

            // ===== Page =====
            Controls.Add(lblTitle);
            Controls.Add(pnlFilter);
            Controls.Add(pnlContent);

            Name = "SimpleDataPage";
            Size = new Size(1362, 850);

            ResumeLayout(false);
        }


        #endregion
    }
}
