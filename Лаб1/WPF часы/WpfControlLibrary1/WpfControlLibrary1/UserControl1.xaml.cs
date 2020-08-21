using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfControlLibrary1
{
	/// <summary>
	/// Логика взаимодействия для UserControl1.xaml
	/// </summary>
	public partial class UserControl1 : UserControl
    {

	    DispatcherTimer timer = new DispatcherTimer();
		public UserControl1()
        {
            InitializeComponent();
	        timer.Interval = TimeSpan.FromSeconds(0.1);
	        timer.Tick += timerTick;
	        timer.Start();
		}

	    private void timerTick(object sender, EventArgs e)
	    {
		    var sec = DateTime.Now.Second;
		    var min = DateTime.Now.Minute;
		    HandSecond.Angle = 6 * sec;
		    HandMinute.Angle = 6 * min + sec / 10.0;
		    HandHour.Angle = 30 * DateTime.Now.Hour + 5 * (min / 10.0);
	    }
	}
}
