namespace LabControls
{
    partial class RGBControl
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
			this.labelRed = new System.Windows.Forms.Label();
			this.labelGreen = new System.Windows.Forms.Label();
			this.labelBlue = new System.Windows.Forms.Label();
			this.rbtDec = new System.Windows.Forms.RadioButton();
			this.rbtHex = new System.Windows.Forms.RadioButton();
			this.sqControl = new LabControls.SquareControl(this.components);
			this.nbxBlue = new LabControls.NumberBox_DecHex(this.components);
			this.nbxGreen = new LabControls.NumberBox_DecHex(this.components);
			this.nbxRed = new LabControls.NumberBox_DecHex(this.components);
			this.SuspendLayout();
			// 
			// labelRed
			// 
			this.labelRed.AutoSize = true;
			this.labelRed.Location = new System.Drawing.Point(4, 16);
			this.labelRed.Name = "labelRed";
			this.labelRed.Size = new System.Drawing.Size(34, 17);
			this.labelRed.TabIndex = 1;
			this.labelRed.Text = "Red";
			// 
			// labelGreen
			// 
			this.labelGreen.AutoSize = true;
			this.labelGreen.Location = new System.Drawing.Point(5, 45);
			this.labelGreen.Name = "labelGreen";
			this.labelGreen.Size = new System.Drawing.Size(48, 17);
			this.labelGreen.TabIndex = 1;
			this.labelGreen.Text = "Green";
			// 
			// labelBlue
			// 
			this.labelBlue.AutoSize = true;
			this.labelBlue.Location = new System.Drawing.Point(5, 71);
			this.labelBlue.Name = "labelBlue";
			this.labelBlue.Size = new System.Drawing.Size(36, 17);
			this.labelBlue.TabIndex = 1;
			this.labelBlue.Text = "Blue";
			// 
			// rbtDec
			// 
			this.rbtDec.AutoSize = true;
			this.rbtDec.Location = new System.Drawing.Point(25, 99);
			this.rbtDec.Name = "rbtDec";
			this.rbtDec.Size = new System.Drawing.Size(54, 21);
			this.rbtDec.TabIndex = 4;
			this.rbtDec.TabStop = true;
			this.rbtDec.Text = "Dec";
			this.rbtDec.UseVisualStyleBackColor = true;
			this.rbtDec.CheckedChanged += new System.EventHandler(this.ChangeMode);
			// 
			// rbtHex
			// 
			this.rbtHex.AutoSize = true;
			this.rbtHex.Location = new System.Drawing.Point(85, 99);
			this.rbtHex.Name = "rbtHex";
			this.rbtHex.Size = new System.Drawing.Size(53, 21);
			this.rbtHex.TabIndex = 5;
			this.rbtHex.TabStop = true;
			this.rbtHex.Text = "Hex";
			this.rbtHex.UseVisualStyleBackColor = true;
			// 
			// sqControl
			// 
			this.sqControl.Color = System.Drawing.Color.White;
			this.sqControl.Location = new System.Drawing.Point(174, 13);
			this.sqControl.Name = "sqControl";
			this.sqControl.Size = new System.Drawing.Size(86, 80);
			this.sqControl.TabIndex = 6;
			this.sqControl.Text = "squareControl1";
			// 
			// nbxBlue
			// 
			this.nbxBlue.Location = new System.Drawing.Point(58, 71);
			this.nbxBlue.Name = "nbxBlue";
			this.nbxBlue.Size = new System.Drawing.Size(100, 22);
			this.nbxBlue.TabIndex = 3;
			this.nbxBlue.Text = "0";
			this.nbxBlue.TextMode = LabControls.NumberBox_DecHex.Mode.Hex;
			this.nbxBlue.TextChanged += new System.EventHandler(this.ChangeColor);
			// 
			// nbxGreen
			// 
			this.nbxGreen.Location = new System.Drawing.Point(58, 42);
			this.nbxGreen.Name = "nbxGreen";
			this.nbxGreen.Size = new System.Drawing.Size(100, 22);
			this.nbxGreen.TabIndex = 2;
			this.nbxGreen.Text = "0";
			this.nbxGreen.TextMode = LabControls.NumberBox_DecHex.Mode.Hex;
			this.nbxGreen.TextChanged += new System.EventHandler(this.ChangeColor);
			// 
			// nbxRed
			// 
			this.nbxRed.Location = new System.Drawing.Point(58, 13);
			this.nbxRed.Name = "nbxRed";
			this.nbxRed.Size = new System.Drawing.Size(100, 22);
			this.nbxRed.TabIndex = 1;
			this.nbxRed.Text = "0";
			this.nbxRed.TextMode = LabControls.NumberBox_DecHex.Mode.Hex;
			this.nbxRed.TextChanged += new System.EventHandler(this.ChangeColor);
			// 
			// RGBControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.sqControl);
			this.Controls.Add(this.nbxBlue);
			this.Controls.Add(this.nbxGreen);
			this.Controls.Add(this.nbxRed);
			this.Controls.Add(this.rbtHex);
			this.Controls.Add(this.rbtDec);
			this.Controls.Add(this.labelBlue);
			this.Controls.Add(this.labelGreen);
			this.Controls.Add(this.labelRed);
			this.Name = "RGBControl";
			this.Size = new System.Drawing.Size(278, 123);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.RadioButton rbtDec;
        private System.Windows.Forms.RadioButton rbtHex;
        private NumberBox_DecHex nbxRed;
        private NumberBox_DecHex nbxGreen;
        private NumberBox_DecHex nbxBlue;
        private SquareControl sqControl;
    }
}
