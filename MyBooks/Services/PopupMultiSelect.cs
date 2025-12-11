
using MyBooks.Models;

namespace MyBooks.Services
{
    public class PopupMultiSelect
    {
        private readonly ContextMenuStrip menu;
        private readonly CheckedListBox listBox;

        private List<DataField> SelectedItems { get; set; } = new();

        public PopupMultiSelect(List<DataField> allItems, List<DataField> selectedItems)
        {
            listBox = new CheckedListBox()
            {
                CheckOnClick = true,
                BorderStyle = BorderStyle.None,
                IntegralHeight = true,
                Height = 150,
                Width = 200
            };

            foreach (var item in allItems)
            {
                int idx = listBox.Items.Add(item);
                if (selectedItems.Contains(item))
                    listBox.SetItemChecked(idx, true);
            }

            var host = new ToolStripControlHost(listBox);

            menu = new ContextMenuStrip()
            {
                DropShadowEnabled = true,
                AutoClose = false
            };

            menu.Items.Add(host);

            var ok = new ToolStripMenuItem("Xác nhận");
            ok.Click += (_, _) =>
            {
                SelectedItems = listBox.CheckedItems.Cast<DataField>().ToList();
                menu.Close();
                Selected?.Invoke(this, SelectedItems);
            };
            menu.Items.Add(ok);
        }

        public event EventHandler<List<DataField>>? Selected;

        public void Show(Control c)
        {
            var pos = c.PointToScreen(new Point(0, c.Height));
            menu.Show(pos);
        }
    }
}
