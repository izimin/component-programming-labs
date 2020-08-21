namespace TestControlsApplication
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.rgbChangeColor = new LabControls.RGBChangeColor();
			this.SuspendLayout();
			// 
			// rgbChangeColor
			// 
			this.rgbChangeColor.Color = System.Drawing.Color.DarkKhaki;
			this.rgbChangeColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.rgbChangeColor.Location = new System.Drawing.Point(4, 1);
			this.rgbChangeColor.Name = "rgbChangeColor";
			this.rgbChangeColor.Size = new System.Drawing.Size(340, 143);
			this.rgbChangeColor.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 145);
			this.Controls.Add(this.rgbChangeColor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Управление цветом";
			this.ResumeLayout(false);

        }


		#endregion

		private LabControls.RGBChangeColor rgbChangeColor;
	}
}

