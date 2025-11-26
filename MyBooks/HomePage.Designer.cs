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
            flowLayoutPanel3 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(134, 2);
            label1.Name = "label1";
            label1.Size = new Size(914, 32);
            label1.TabIndex = 0;
            label1.Text = "Top trending";
            label1.TextAlign = ContentAlignment.BottomLeft;
            label1.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(bookCard1);
            flowLayoutPanel1.Location = new Point(134, 37);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(914, 305);
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
            bookCard1.Location = new Point(3, 5);
            bookCard1.Margin = new Padding(3, 5, 3, 5);
            bookCard1.Name = "bookCard1";
            bookCard1.Size = new Size(171, 260);
            bookCard1.TabIndex = 0;
            bookCard1.Load += bookCard1_Load;
            // 
            // label2
            // 
            label2.Location = new Point(134, 345);
            label2.Name = "label2";
            label2.Size = new Size(914, 32);
            label2.TabIndex = 4;
            label2.Text = "Last read";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(bookCard2);
            flowLayoutPanel2.Location = new Point(134, 381);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(911, 306);
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
            bookCard2.Location = new Point(3, 5);
            bookCard2.Margin = new Padding(3, 5, 3, 5);
            bookCard2.Name = "bookCard2";
            bookCard2.Size = new Size(171, 260);
            bookCard2.TabIndex = 0;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Bottom;
            label3.Location = new Point(0, 705);
            label3.Name = "label3";
            label3.Size = new Size(1137, 31);
            label3.TabIndex = 6;
            label3.Text = "© 2025 MyBooks. All rights reserved.";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = SystemColors.Control;
            flowLayoutPanel3.Controls.Add(button1);
            flowLayoutPanel3.Controls.Add(button2);
            flowLayoutPanel3.Controls.Add(button3);
            flowLayoutPanel3.Controls.Add(button4);
            flowLayoutPanel3.Controls.Add(button5);
            flowLayoutPanel3.Controls.Add(button6);
            flowLayoutPanel3.Dock = DockStyle.Left;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(131, 705);
            flowLayoutPanel3.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 0;
            button1.Text = "Tác giả";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(3, 38);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 1;
            button2.Text = "Nhà phát hành";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(3, 73);
            button3.Name = "button3";
            button3.Size = new Size(125, 29);
            button3.TabIndex = 2;
            button3.Text = "Ngôn ngữ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(3, 108);
            button4.Name = "button4";
            button4.Size = new Size(125, 29);
            button4.TabIndex = 3;
            button4.Text = "Series";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(3, 143);
            button5.Name = "button5";
            button5.Size = new Size(125, 29);
            button5.TabIndex = 4;
            button5.Text = "Chủ đề";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(3, 178);
            button6.Name = "button6";
            button6.Size = new Size(125, 29);
            button6.TabIndex = 5;
            button6.Text = "Ghi chú";
            button6.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanel3);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HomePage";
            Size = new Size(1137, 736);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private BookCard bookCard1;
        private BookCard bookCard2;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}