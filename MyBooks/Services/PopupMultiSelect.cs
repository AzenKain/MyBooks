using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Services
{
    public class PopupMultiSelect
    {
        private readonly ContextMenuStrip menu;
        private readonly CheckedListBox listBox;

        public List<string> SelectedItems { get; private set; } = new();

        public PopupMultiSelect(List<string> allItems, List<string> selectedItems)
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
            ok.Click += (s, e) =>
            {
                SelectedItems = listBox.CheckedItems.Cast<string>().ToList();
                menu.Close();
                Selected?.Invoke(this, SelectedItems);
            };
            menu.Items.Add(ok);
        }

        public event EventHandler<List<string>> Selected;

        public void Show(Control c)
        {
            var pos = c.PointToScreen(new Point(0, c.Height));
            menu.Show(pos);
        }
    }
}
