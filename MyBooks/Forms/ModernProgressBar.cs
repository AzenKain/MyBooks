using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Forms
{
    public class ModernProgressBar : Control
    {
        private int value;
        public int Value
        {
            get => value;
            set
            {
                this.value = Math.Max(0, Math.Min(value, Maximum));
                Invalidate();
            }
        }

        public int Maximum { get; set; } = 100;
        public Color BarColor { get; set; } = Color.FromArgb(0, 120, 215);
        public Color TrackColor { get; set; } = Color.FromArgb(235, 235, 235);

        public ModernProgressBar()
        {
            DoubleBuffered = true;
            Height = 12;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            DrawRounded(e.Graphics, TrackColor, rect, 6);

            var w = (int)(rect.Width * (Value / (float)Maximum));
            if (w > 0)
                DrawRounded(e.Graphics, BarColor, new Rectangle(0, 0, w, rect.Height), 6);
        }

        void DrawRounded(Graphics g, Color c, Rectangle r, int radius)
        {
            using var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            using var brush = new SolidBrush(c);
            g.FillPath(brush, path);
        }
    }
}
