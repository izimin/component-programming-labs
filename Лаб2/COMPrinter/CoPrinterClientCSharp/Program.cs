using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoPrinterClientCSharp
{
    static class Program
    {
        [ComVisible(true)]
        [ComImport, Guid("3C393219-FFBB-4947-A0DF-3FA7A1E0780D")]
        public class Printer { }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("283B962F-5680-4F30-AF59-2A84A7A70EBF")]
        public interface ICreatePrinter
        {
            void SetPetName(string petName);
            void SetMaxSpeed(int maxSp);
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BC957B35-A326-43DE-921F-7CEFFA231496")]
        public interface IStats
        {
            void DisplayStats();
            void GetPetName(ref string petName);
        }

        [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9F465B57-0EB0-4930-8C83-2FFCD18E5680")]
        public interface IEngine
        {
            void SpeedUp();
            void QualityUp();
            void GetMaxSpeed(ref int maxSpeed);
            void GetCurSpeed(ref int curSpeed);
            void GetCurQuality(ref int curQuality);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
