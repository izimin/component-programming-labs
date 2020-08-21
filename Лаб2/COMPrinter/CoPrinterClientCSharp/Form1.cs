using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoPrinterClientCSharp
{
    public partial class MainForm : Form
    {
        Program.Printer myPrinter = new Program.Printer();
        Program.ICreatePrinter iCrPrinter;
        Program.IEngine iEgPrinter;
        Program.IStats iStPrinter;
        public MainForm()
        {
            InitializeComponent();
            iCrPrinter = (Program.ICreatePrinter)myPrinter;
            iEgPrinter = (Program.IEngine)myPrinter;
            iStPrinter = (Program.IStats)myPrinter;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            iCrPrinter.SetPetName(tbxName.Text);
            iCrPrinter.SetMaxSpeed(int.Parse(tbMaxSpeed.Text));


            // Окошко преобретет новый вид
            gb1.Visible = true;
        }

        private void btnCurSpeed_Click(object sender, EventArgs e)
        {
            int curSp = 0;
            iEgPrinter.GetCurSpeed(ref curSp);
            tbCurSpeed.Text = curSp.ToString();
        }

        private void btnCurQ_Click(object sender, EventArgs e)
        {
            int curQ = 0;
            iEgPrinter.GetCurQuality(ref curQ);
            tbCurQuality.Text = curQ.ToString();
        }

        private void btnSpeedUp_Click(object sender, EventArgs e)
        {
            int maxSp = 0;
            iEgPrinter.GetMaxSpeed(ref maxSp);
            int curSp = 0;
            iEgPrinter.GetCurSpeed(ref curSp);
            if (curSp < maxSp)
                iEgPrinter.SpeedUp();
        }

        private void btnQualityUp_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbCurQuality.Text) < 100)
                iEgPrinter.QualityUp();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            iStPrinter.DisplayStats();
        }
    }
}
