using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabControls
{
	public partial class RGBChangeColor : UserControl
	{
		public RGBChangeColor()
		{
			InitializeComponent();
			rbtDec.Checked = true; 
		}
		public event EventHandler<EventArgs> ColorChanged;

		protected void OnColorChanged()
		{
			if (ColorChanged != null)
				ColorChanged(this, new EventArgs());
		}

		public Color Color
		{
			get { return sqControl.Color; }
			set { sqControl.Color = value; ChangeNbx(); OnColorChanged();}
		}

		public void ChangeNbx()
		{
			nbxRed.Text = sqControl.Color.R.ToString();
			nbxGreen.Text = sqControl.Color.G.ToString();
			nbxBlue.Text = sqControl.Color.B.ToString();
		}

		public void ChangeNbxMode(NumberBox_DecHex.Mode m)
		{
			nbxRed.TextMode = nbxGreen.TextMode = nbxBlue.TextMode = m;
		}

		// Сробатывает при смене радио баттонов 
		public void ChangeMode(object sender, EventArgs e)
		{
			if (rbtDec.Checked)
				ChangeNbxMode(NumberBox_DecHex.Mode.Dec);
			else
				ChangeNbxMode(NumberBox_DecHex.Mode.Hex);
		}

		// Сробатывает при изменении в любом nbx
		private void ChangeColor(object sender, EventArgs e)
		{

			//Смотрим, что вызвало это событие (смена с.с. тоже может вызвать)
			if (!nbxRed.Focused && !nbxGreen.Focused && !nbxBlue.Focused) return;

			if (!String.IsNullOrEmpty(nbxRed.Text) && !String.IsNullOrEmpty(nbxGreen.Text) &&
			    !String.IsNullOrEmpty(nbxBlue.Text))
			{
				sqControl.Color = Color.FromArgb(nbxRed.Value, nbxGreen.Value, nbxBlue.Value);
				OnColorChanged();
			}
		}
	}
}