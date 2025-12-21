namespace MyBooks
{
    partial class UploadPage
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
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            textBoxLanguage = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            labelISBN = new Label();
            textBoxISBN = new TextBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label4 = new Label();
            textBoxSubTitle = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label5 = new Label();
            dateTimePickerYearPublic = new DateTimePicker();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label6 = new Label();
            textBoxPublisher = new TextBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            label7 = new Label();
            textBoxTags = new TextBox();
            flowLayoutPanel8 = new FlowLayoutPanel();
            label8 = new Label();
            textBoxAuthor = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labelTitle = new Label();
            textBoxTitle = new TextBox();
            buttonSave = new Button();
            buttonUpload = new Button();
            openFileDialog1 = new OpenFileDialog();
            pictureBoxPreview = new PictureBox();
            flowLayoutPanel11 = new FlowLayoutPanel();
            label11 = new Label();
            textBoxSeries = new TextBox();
            flowLayoutPanel10 = new FlowLayoutPanel();
            label10 = new Label();
            richTextBoxDescription = new RichTextBox();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            flowLayoutPanel11.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(textBoxLanguage);
            flowLayoutPanel2.Location = new Point(19, 311);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1362, 37);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 0;
            label2.Text = "Ngôn ngữ";
            label2.Click += label2_Click;
            // 
            // textBoxLanguage
            // 
            textBoxLanguage.Dock = DockStyle.Fill;
            textBoxLanguage.Location = new Point(85, 4);
            textBoxLanguage.Margin = new Padding(3, 4, 3, 4);
            textBoxLanguage.Name = "textBoxLanguage";
            textBoxLanguage.Size = new Size(1233, 27);
            textBoxLanguage.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(labelISBN);
            flowLayoutPanel3.Controls.Add(textBoxISBN);
            flowLayoutPanel3.Location = new Point(19, 93);
            flowLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(1318, 37);
            flowLayoutPanel3.TabIndex = 4;
            flowLayoutPanel3.Paint += flowLayoutPanel3_Paint;
            // 
            // labelISBN
            // 
            labelISBN.AutoSize = true;
            labelISBN.Dock = DockStyle.Top;
            labelISBN.Location = new Point(3, 0);
            labelISBN.Name = "labelISBN";
            labelISBN.Size = new Size(41, 20);
            labelISBN.TabIndex = 0;
            labelISBN.Text = "ISBN";
            // 
            // textBoxISBN
            // 
            textBoxISBN.Dock = DockStyle.Fill;
            textBoxISBN.Location = new Point(50, 4);
            textBoxISBN.Margin = new Padding(3, 4, 3, 4);
            textBoxISBN.Name = "textBoxISBN";
            textBoxISBN.Size = new Size(1262, 27);
            textBoxISBN.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label4);
            flowLayoutPanel4.Controls.Add(textBoxSubTitle);
            flowLayoutPanel4.Location = new Point(19, 124);
            flowLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(1362, 37);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.Location = new Point(0, 7);
            label4.Margin = new Padding(0, 7, 0, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 0;
            label4.Text = "Tiêu đề phụ";
            label4.Click += label4_Click;
            // 
            // textBoxSubTitle
            // 
            textBoxSubTitle.Dock = DockStyle.Fill;
            textBoxSubTitle.Location = new Point(90, 4);
            textBoxSubTitle.Margin = new Padding(3, 4, 3, 4);
            textBoxSubTitle.Name = "textBoxSubTitle";
            textBoxSubTitle.Size = new Size(1228, 27);
            textBoxSubTitle.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label5);
            flowLayoutPanel5.Controls.Add(dateTimePickerYearPublic);
            flowLayoutPanel5.Location = new Point(19, 161);
            flowLayoutPanel5.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(1362, 37);
            flowLayoutPanel5.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 0;
            label5.Text = "Năm phát hành";
            label5.Click += label5_Click;
            // 
            // dateTimePickerYearPublic
            // 
            dateTimePickerYearPublic.Location = new Point(120, 3);
            dateTimePickerYearPublic.Name = "dateTimePickerYearPublic";
            dateTimePickerYearPublic.Size = new Size(1198, 27);
            dateTimePickerYearPublic.TabIndex = 1;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(label6);
            flowLayoutPanel6.Controls.Add(textBoxPublisher);
            flowLayoutPanel6.Location = new Point(19, 198);
            flowLayoutPanel6.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(1362, 37);
            flowLayoutPanel6.TabIndex = 4;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 0;
            label6.Text = "Nhà phát hành";
            label6.Click += label6_Click;
            // 
            // textBoxPublisher
            // 
            textBoxPublisher.Dock = DockStyle.Fill;
            textBoxPublisher.Location = new Point(115, 4);
            textBoxPublisher.Margin = new Padding(3, 4, 3, 4);
            textBoxPublisher.Name = "textBoxPublisher";
            textBoxPublisher.Size = new Size(1203, 27);
            textBoxPublisher.TabIndex = 1;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(label7);
            flowLayoutPanel7.Controls.Add(textBoxTags);
            flowLayoutPanel7.Location = new Point(19, 235);
            flowLayoutPanel7.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(1362, 37);
            flowLayoutPanel7.TabIndex = 4;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 0;
            label7.Text = "Chủ đề";
            label7.Click += label7_Click;
            // 
            // textBoxTags
            // 
            textBoxTags.Dock = DockStyle.Fill;
            textBoxTags.Location = new Point(64, 4);
            textBoxTags.Margin = new Padding(3, 4, 3, 4);
            textBoxTags.Name = "textBoxTags";
            textBoxTags.Size = new Size(1254, 27);
            textBoxTags.TabIndex = 1;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(label8);
            flowLayoutPanel8.Controls.Add(textBoxAuthor);
            flowLayoutPanel8.Location = new Point(19, 272);
            flowLayoutPanel8.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(1318, 37);
            flowLayoutPanel8.TabIndex = 5;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(55, 20);
            label8.TabIndex = 0;
            label8.Text = "Tác giả";
            label8.Click += label8_Click;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Dock = DockStyle.Fill;
            textBoxAuthor.Location = new Point(64, 4);
            textBoxAuthor.Margin = new Padding(3, 4, 3, 4);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(1250, 27);
            textBoxAuthor.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(labelTitle);
            flowLayoutPanel1.Controls.Add(textBoxTitle);
            flowLayoutPanel1.Location = new Point(19, 57);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1318, 32);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Location = new Point(3, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(58, 20);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Tiêu đề";
            labelTitle.Click += label1_Click_1;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Dock = DockStyle.Fill;
            textBoxTitle.Location = new Point(67, 4);
            textBoxTitle.Margin = new Padding(3, 4, 3, 4);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(1247, 27);
            textBoxTitle.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(19, 717);
            buttonSave.Margin = new Padding(3, 4, 3, 4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(238, 44);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Lưu";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += button1_Click;
            // 
            // buttonUpload
            // 
            buttonUpload.Location = new Point(19, 650);
            buttonUpload.Margin = new Padding(3, 4, 3, 4);
            buttonUpload.Name = "buttonUpload";
            buttonUpload.Size = new Size(238, 44);
            buttonUpload.TabIndex = 8;
            buttonUpload.Text = "Tải lên";
            buttonUpload.UseVisualStyleBackColor = true;
            buttonUpload.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Location = new Point(435, 622);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(151, 184);
            pictureBoxPreview.TabIndex = 9;
            pictureBoxPreview.TabStop = false;
            pictureBoxPreview.Click += pictureBox1_Click;
            // 
            // flowLayoutPanel11
            // 
            flowLayoutPanel11.Controls.Add(label11);
            flowLayoutPanel11.Controls.Add(textBoxSeries);
            flowLayoutPanel11.Location = new Point(19, 349);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            flowLayoutPanel11.Size = new Size(1362, 36);
            flowLayoutPanel11.TabIndex = 10;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(3, 0);
            label11.Name = "label11";
            label11.Size = new Size(48, 20);
            label11.TabIndex = 1;
            label11.Text = "Series";
            label11.TextAlign = ContentAlignment.TopCenter;
            label11.Click += label11_Click;
            // 
            // textBoxSeries
            // 
            textBoxSeries.Dock = DockStyle.Fill;
            textBoxSeries.Location = new Point(57, 4);
            textBoxSeries.Margin = new Padding(3, 4, 3, 4);
            textBoxSeries.Name = "textBoxSeries";
            textBoxSeries.Size = new Size(1261, 27);
            textBoxSeries.TabIndex = 2;
            // 
            // flowLayoutPanel10
            // 
            flowLayoutPanel10.Controls.Add(label10);
            flowLayoutPanel10.Controls.Add(richTextBoxDescription);
            flowLayoutPanel10.Location = new Point(19, 387);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            flowLayoutPanel10.Size = new Size(1365, 210);
            flowLayoutPanel10.TabIndex = 11;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(3, 0);
            label10.Name = "label10";
            label10.Size = new Size(48, 20);
            label10.TabIndex = 1;
            label10.Text = "Mô tả";
            label10.TextAlign = ContentAlignment.TopCenter;
            label10.Click += label10_Click;
            // 
            // richTextBoxDescription
            // 
            richTextBoxDescription.Location = new Point(57, 3);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(1261, 197);
            richTextBoxDescription.TabIndex = 2;
            richTextBoxDescription.Text = "";
            // 
            // UploadPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel11);
            Controls.Add(pictureBoxPreview);
            Controls.Add(flowLayoutPanel10);
            Controls.Add(buttonUpload);
            Controls.Add(buttonSave);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel8);
            Controls.Add(flowLayoutPanel7);
            Controls.Add(flowLayoutPanel6);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel3);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UploadPage";
            Size = new Size(1362, 850);
            Load += UploadPage_Load;
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel11.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private System.Windows.Forms.TextBox textBoxLanguage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private Label label4;
        private System.Windows.Forms.TextBox textBoxSubTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private Label label6;
        private System.Windows.Forms.TextBox textBoxPublisher;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private Label label7;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private Label label8;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUpload;
        private OpenFileDialog openFileDialog1;
        private DateTimePicker dateTimePickerYearPublic;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private Label label11;
        private System.Windows.Forms.TextBox textBoxSeries;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private Label label10;
        private RichTextBox richTextBoxDescription;
    }
}