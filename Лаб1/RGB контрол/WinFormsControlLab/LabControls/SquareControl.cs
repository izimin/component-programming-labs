using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabControls
{
    public partial class SquareControl : Control
    {
        private Color color;
        public Color Color
        {
            set { color = value; Invalidate(); }
            get { return color; }
        }

        public SquareControl()
        {
            InitializeComponent();
        }

        public SquareControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (DesignMode)
                e.Graphics.DrawRectangle(new Pen(color, 1), ClientRectangle);
            else
                e.Graphics.FillRectangle(new SolidBrush(color), ClientRectangle);
        }
    }
}
