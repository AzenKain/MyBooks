using MyBooks.Services;

namespace MyBooks
{
    public partial class HomePage : UserControl
    {
        
        private readonly BookService bookService = new BookService();
        public HomePage()
        {
            InitializeComponent();
            LoadAllData();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void bookCard1_Load(object sender, EventArgs e) { }

        

        private void LoadAllData()
        {
            flowLayoutPanelTopTreding.Controls.Clear();
            flowLayoutPanelRecommend.Controls.Clear();
            flowLayoutPanelLastReading.Controls.Clear();
            var rsp = bookService.GetAllBook();
            if (!rsp.Success || rsp.Data == null)
            {
                MessageBox.Show($@"Lỗi: {rsp.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var books = rsp.Data;

            foreach (var card in books.Select(bookService.CreateCard))
            {
                flowLayoutPanelTopTreding.Controls.Add(card);
            }

            foreach (var card in books.Select(bookService.CreateCard))
            {
                flowLayoutPanelRecommend.Controls.Add(card);
            }
            foreach (var card in books.Select(bookService.CreateCard))
            {
                flowLayoutPanelLastReading.Controls.Add(card);
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bookCard2_Load(object sender, EventArgs e)
        {

        }
    }
}
