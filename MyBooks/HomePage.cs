using MyBooks.Services;
using MyBooks.State;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyBooks
{
    public partial class HomePage : UserControl
    {
        
        private readonly BookService bookService = new BookService();
        public HomePage()
        {
            InitializeComponent();

            AppStore.Changed += OnAppStateChanged;
            var rsp = bookService.GetAllBook();
            if (!rsp.Success || rsp.Data == null)
            {
                RJMessageBox.Show(this, rsp.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AppStore.Update(state => state with
            {
                Home = state.Home with
                {
                    Items = rsp.Data
                }
            });
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void bookCard1_Load(object sender, EventArgs e) { }


        private void OnAppStateChanged(AppState state)
        {
            flowLayoutPanelTopTrending.Controls.Clear();
            flowLayoutPanelRecommend.Controls.Clear();
            flowLayoutPanelLastReading.Controls.Clear();

            foreach (var card in state.Home.Items.Select(bookService.CreateCard))
            {
                flowLayoutPanelTopTrending.Controls.Add(card);

            }
            foreach (var card in state.Home.Items.Select(bookService.CreateCard))
            {
                flowLayoutPanelRecommend.Controls.Add(card);
            }
            foreach (var card in state.Home.Items.Select(bookService.CreateCard))
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
