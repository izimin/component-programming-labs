using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace LabControls
{
	public partial class NumberBox_DecHex : TextBox
	{
		public enum Mode { Hex, Dec };
		public Mode textMode = Mode.Dec;
		//public event EventHandler<EventArgs> ColorChanged;

		public char[] lettersForHex = new char[] {'A', 'B', 'C', 'D', 'E', 'F'};

		public NumberBox_DecHex()
		{
			InitializeComponent();
		}

		//protected void OnColorChanged()
		//{
		//	if (ColorChanged != null)
		//		ColorChanged(this, new EventArgs());
		//}

		public NumberBox_DecHex(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public Mode TextMode
		{
			get { return textMode; }
			set
			{
				textMode = value;
				OnTextModeChanged();
			}
		}

		public int Value
		{
			get
			{
				if (textMode == Mode.Hex)
					return Convert.ToInt32(Text, 16);
				else return int.Parse(Text);
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
				if (TextMode != Mode.Hex || !lettersForHex.Any(x => (x == char.ToLower(e.KeyChar) || x == char.ToUpper(e.KeyChar))))
					e.Handled = true;
			base.OnKeyPress(e);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			if (!string.IsNullOrEmpty(Text))
			{
				if (textMode == Mode.Hex)
				{
					if (int.TryParse(Text, System.Globalization.NumberStyles.HexNumber, null, out var v))
					{
						if (Convert.ToInt32(Text, 16) > 255)
							Text = "FF";
					}
					else
						Text = (string)Tag;
				}
				else
				{
					if (int.TryParse(Text, out int v))
					{
						if (int.Parse(Text) > 255)
							Text = "255";
					}
					else
						Text = (string)Tag;
				}
				Tag = Text;
				//OnColorChanged();
			}
			base.OnTextChanged(e);
		}

		protected void OnTextModeChanged()
		{
			if (!String.IsNullOrEmpty(Text))
				if (TextMode == Mode.Dec)
					Text = Convert.ToInt32(Text, 16).ToString();
				else
					Text = int.Parse(Text).ToString("X");
		}

		// Как только нажали на numberbox запоминаем текущее значение (если будем вставлять ерунду - вернем предыдущее значение)
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			Tag = Text;
		}

		// Элемент перестает быть активным
		protected override void OnValidating(CancelEventArgs e)
		{
			base.OnValidating(e);
			if (string.IsNullOrEmpty(Text))
				Text = (string)Tag;
		}
	}
}
