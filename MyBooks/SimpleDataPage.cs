using MyBooks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyBooks.Services;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyBooks
{
    public partial class SimpleDataPage : UserControl
    {
        private List<DataField> _listData = new();
        private DataFieldType? _dataType;
        private readonly DataFieldService dataFieldService = new DataFieldService();
        private readonly Action<UserControl> _loadPage;
        public SimpleDataPage(DataFieldType dataType, Action<UserControl> loadPage)
        {
            InitializeComponent();
            _dataType = dataType;
            _loadPage = loadPage;
            AddFilterButtons();
            switch (dataType)
            {
                case DataFieldType.Authors:
                    lblTitle.Text = "Tác giả";
                    break;

                case DataFieldType.Publishers:
                    lblTitle.Text = "Nhà xuất bản";
                    break;

                case DataFieldType.Series:
                    lblTitle.Text = "Bộ sưu tập";
                    break;

                case DataFieldType.Languages:
                    lblTitle.Text = "Ngôn ngữ";
                    break;

                case DataFieldType.Tags:
                    lblTitle.Text = "Chủ đề";
                    break;

                default:
                    lblTitle.Text = "Khác";
                    break;
            }
            var rsp = dataFieldService.GetListField(dataType);
            if (rsp.Success && rsp.Data != null)
            {
                _listData = rsp.Data;
            }

            lvLeft.ItemSelectionChanged += Author_ItemSelectionChanged;
            lvRight.ItemSelectionChanged += Author_ItemSelectionChanged;
            LoadAuthors(_listData);

        }

        private void Author_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected || !_dataType.HasValue)
                return;

            var text = e?.Item?.Text.Split(')', 2)[1].Trim() ?? "";

            var selectItem = _listData
                .FirstOrDefault(x => x.Name == text);

            if (selectItem == null)
                return;


            _loadPage(new SearchPage(
                _dataType.Value,
                selectItem
            ));
        }

        private void AddFilterButtons()
        {
            pnlFilter.Controls.Add(CreateFilterButton("All"));

            for (char c = 'A'; c <= 'Z'; c++)
            {
                pnlFilter.Controls.Add(CreateFilterButton(c.ToString()));
            }
        }

        private Button CreateFilterButton(string text)
        {
            var btn = new Button
            {
                Text = text,
                Width = 40,
                Height = 32,
                BackColor = Color.FromArgb(30, 120, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(3)
            };

            btn.Click += FilterButton_Click;

            return btn;
        }

        private void FilterButton_Click(object? sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var key = btn.Text;

            if (key == "All")
            {
                LoadAuthors(_listData);
                return;
            }

            var filtered = _listData
                .Where(a => a.Name.StartsWith(key, StringComparison.OrdinalIgnoreCase))
                .ToList();

            LoadAuthors(filtered);
        }



        public void LoadAuthors(List<DataField> listData)
        {
            lvLeft.Items.Clear();
            lvRight.Items.Clear();

            int half = (int)Math.Ceiling(listData.Count / 2.0);

            for (int i = 0; i < listData.Count; i++)
            {
                var item = new ListViewItem(
                    $"({i})  {listData[i].Name}"
                )
                {
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold)
                };
                if (i < half)
                    lvLeft.Items.Add(item);
                else
                    lvRight.Items.Add(item);
            }
        }

    }
}
