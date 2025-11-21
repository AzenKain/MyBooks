namespace MyBooks
{
    partial class HomePage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            bookCard1 = new BookCard();
            label2 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            bookCard2 = new BookCard();
            label3 = new Label();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 23);
            label1.TabIndex = 0;
            label1.Text = "Top trending";
            label1.TextAlign = ContentAlignment.BottomLeft;
            label1.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(bookCard1);
            flowLayoutPanel1.Location = new Point(0, 26);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 228);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // bookCard1
            // 
            bookCard1.BackColor = SystemColors.ActiveBorder;
            bookCard1.BookCover = null;
            bookCard1.BookName = null;
            bookCard1.ButtonClickAction = null;
            bookCard1.ButtonText = "button1";
            bookCard1.Location = new Point(3, 3);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new Size(150, 194);
            bookCard1.TabIndex = 0;
            bookCard1.Load += bookCard1_Load;
            // 
            // label2
            // 
            label2.Location = new Point(0, 257);
            label2.Name = "label2";
            label2.Size = new Size(800, 23);
            label2.TabIndex = 4;
            label2.Text = "Last read";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(bookCard2);
            flowLayoutPanel2.Location = new Point(3, 283);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(797, 229);
            flowLayoutPanel2.TabIndex = 5;
            flowLayoutPanel2.WrapContents = false;
            // 
            // bookCard2
            // 
            bookCard2.BackColor = SystemColors.ActiveBorder;
            bookCard2.BookCover = null;
            bookCard2.BookName = null;
            bookCard2.ButtonClickAction = null;
            bookCard2.ButtonText = "button1";
            bookCard2.Location = new Point(3, 3);
            bookCard2.Name = "bookCard2";
            bookCard2.Size = new Size(150, 194);
            bookCard2.TabIndex = 0;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(0, 527);
            label3.Name = "label3";
            label3.Size = new Size(806, 23);
            label3.TabIndex = 6;
            label3.Text = "© 2025 MyBooks. All rights reserved.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Name = "HomePage";
            Size = new Size(806, 550);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private BookCard bookCard1;
        private BookCard bookCard2;
        private Label label3;
    }
}