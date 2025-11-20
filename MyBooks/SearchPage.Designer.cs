namespace MyBooks
{
    partial class SearchPage
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 450);
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true; // để scroll nếu nhiều card
            flowLayoutPanel1.TabIndex = 0;
            // 
            // SearchPage
            // 
            Controls.Add(flowLayoutPanel1);
            Name = "SearchPage";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }
    }
}
