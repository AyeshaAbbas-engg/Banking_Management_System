using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RoundedButton : UserControl
    {
        public RoundedButton()
        {
            InitializeComponent();
            this.Size = new Size(150, 50);  // Default size
            this.BackColor = Color.MediumSlateBlue; // Default background color
            this.ForeColor = Color.White;           // Default text color
            this.Text = "Rounded Button";           // Default text
        }
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; Invalidate(); }  // Invalidate forces a repaint
        }
        private void RoundedButton_Load(object sender, EventArgs e)
        {
            // You can add optional load-time logic here.
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int borderRadius = 20; // Roundness radius

            GraphicsPath path = GetRoundedPath(rect, borderRadius);
            this.Region = new Region(path);

            // Fill background
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Draw Text
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rect, this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
