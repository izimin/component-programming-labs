namespace LabControls
{
	partial class RGBChangeColor
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblRed = new System.Windows.Forms.Label();
			this.lblGreen = new System.Windows.Forms.Label();
			this.lblBlue = new System.Windows.Forms.Label();
			this.rbtDec = new System.Windows.Forms.RadioButton();
			this.rbtHex = new System.Windows.Forms.RadioButton();
			this.sqControl = new LabControls.SquareControl(this.components);
			this.nbxBlue = new LabControls.NumberBox_DecHex(this.components);
			this.nbxGreen = new LabControls.NumberBox_DecHex(this.components);
			this.nbxRed = new LabControls.NumberBox_DecHex(this.components);
			this.SuspendLayout();
			// 
			// lblRed
			// 
			this.lblRed.AutoSize = true;
			this.lblRed.Location = new System.Drawing.Point(15, 16);
			this.lblRed.Name = "lblRed";
			this.lblRed.Size = new System.Drawing.Size(34, 17);
			this.lblRed.TabIndex = 2;
			this.lblRed.Text = "Red";
			// 
			// lblGreen
			// 
			this.lblGreen.AutoSize = true;
			this.lblGreen.Location = new System.Drawing.Point(15, 44);
			this.lblGreen.Name = "lblGreen";
			this.lblGreen.Size = new System.Drawing.Size(48, 17);
			this.lblGreen.TabIndex = 2;
			this.lblGreen.Text = "Green";
			// 
			// lblBlue
			// 
			this.lblBlue.AutoSize = true;
			this.lblBlue.Location = new System.Drawing.Point(15, 73);
			this.lblBlue.Name = "lblBlue";
			this.lblBlue.Size = new System.Drawing.Size(36, 17);
			this.lblBlue.TabIndex = 2;
			this.lblBlue.Text = "Blue";
			// 
			// rbtDec
			// 
			this.rbtDec.AutoSize = true;
			this.rbtDec.Checked = true;
			this.rbtDec.Location = new System.Drawing.Point(39, 103);
			this.rbtDec.Name = "rbtDec";
			this.rbtDec.Size = new System.Drawing.Size(54, 21);
			this.rbtDec.TabIndex = 4;
			this.rbtDec.TabStop = true;
			this.rbtDec.Text = "Dec";
			this.rbtDec.UseVisualStyleBackColor = true;
			// 
			// rbtHex
			// 
			this.rbtHex.AutoSize = true;
			this.rbtHex.Location = new System.Drawing.Point(104, 103);
			this.rbtHex.Name = "rbtHex";
			this.rbtHex.Size = new System.Drawing.Size(53, 21);
			this.rbtHex.TabIndex = 5;
			this.rbtHex.Text = "Hex";
			this.rbtHex.UseVisualStyleBackColor = true;
			this.rbtHex.CheckedChanged += new System.EventHandler(this.ChangeMode);
			// 
			// sqControl
			// 
			this.sqControl.Color = System.Drawing.Color.OrangeRed;
			this.sqControl.Location = new System.Drawing.Point(182, 14);
			this.sqControl.Name = "sqControl";
			this.sqControl.Size = new System.Drawing.Size(120, 109);
			this.sqControl.TabIndex = 6;
			this.sqControl.Text = "squareControl2";
			// 
			// nbxBlue
			// 
			this.nbxBlue.Location = new System.Drawing.Point(67, 70);
			this.nbxBlue.Name = "nbxBlue";
			this.nbxBlue.Size = new System.Drawing.Size(100, 22);
			this.nbxBlue.TabIndex = 3;
			this.nbxBlue.TextMode = LabControls.NumberBox_DecHex.Mode.Dec;
			this.nbxBlue.TextChanged += new System.EventHandler(this.ChangeColor);
			// 
			// nbxGreen
			// 
			this.nbxGreen.Location = new System.Drawing.Point(67, 42);
			this.nbxGreen.Name = "nbxGreen";
			this.nbxGreen.Size = new System.Drawing.Size(100, 22);
			this.nbxGreen.TabIndex = 2;
			this.nbxGreen.TextMode = LabControls.NumberBox_DecHex.Mode.Dec;
			this.nbxGreen.TextChanged += new System.EventHandler(this.ChangeColor);
			// 
			// nbxRed
			// 
			this.nbxRed.Location = new System.Drawing.Point(67, 14);
			this.nbxRed.Name = "nbxRed";
			this.nbxRed.Size = new System.Drawing.Size(100, 22);
			this.nbxRed.TabIndex = 1;
			this.nbxRed.TextMode = LabControls.NumberBox_DecHex.Mode.Dec;
			this.nbxRed.TextChanged += new System.EventHandler(this.ChangeColor);
			// 
			// RGBChangeColor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sqControl);
			this.Controls.Add(this.rbtHex);
			this.Controls.Add(this.rbtDec);
			this.Controls.Add(this.lblBlue);
			this.Controls.Add(this.lblGreen);
			this.Controls.Add(this.lblRed);
			this.Controls.Add(this.nbxBlue);
			this.Controls.Add(this.nbxGreen);
			this.Controls.Add(this.nbxRed);
			this.Name = "RGBChangeColor";
			this.Size = new System.Drawing.Size(323, 140);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private NumberBox_DecHex nbxRed;
		private NumberBox_DecHex nbxGreen;
		private NumberBox_DecHex nbxBlue;
		private System.Windows.Forms.Label lblRed;
		private System.Windows.Forms.Label lblGreen;
		private System.Windows.Forms.Label lblBlue;
		private System.Windows.Forms.RadioButton rbtDec;
		private System.Windows.Forms.RadioButton rbtHex;
		private SquareControl sqControl;
	}
}
