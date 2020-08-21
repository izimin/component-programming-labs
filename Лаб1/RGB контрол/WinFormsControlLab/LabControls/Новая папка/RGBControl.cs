using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LabControls
{
    public partial class RGBControl : UserControl
    {
        public RGBControl()
        {
            InitializeComponent();
            nbxRed.TextMode = NumberBox_DecHex.Mode.Hex;
            rbtHex.Checked = true;
            sqControl.Color = Color.Black;
        }

        public void ChangeNbxMode(NumberBox_DecHex.Mode m)
        {
            nbxRed.TextMode = nbxGreen.TextMode = nbxBlue.TextMode = m;
        }

        // Сробатывает при смене радио буттонов 
        public void ChangeMode(object sender, EventArgs e)
        {
            var nbxes = new List<NumberBox_DecHex>() { nbxRed, nbxGreen, nbxBlue };
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

			if (nbxRed.Text == "" || nbxGreen.Text == "" || nbxBlue.Text == "")
                sqControl.Visible = false;
            else if (rbtHex.Checked)
            {
                sqControl.Visible = true;
                sqControl.Color = Color.FromArgb(Convert.ToInt32(nbxRed.Text, 16), Convert.ToInt32(nbxGreen.Text, 16), Convert.ToInt32(nbxBlue.Text, 16));
            }
            else
            {
                sqControl.Visible = true;
                sqControl.Color = Color.FromArgb(int.Parse(nbxRed.Text), int.Parse(nbxGreen.Text), int.Parse(nbxBlue.Text));
            }
        }
    }
}