namespace CoPrinterClientCSharp
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbMaxSpeed = new System.Windows.Forms.TextBox();
            this.lbMaxlSpeed = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.tbCurSpeed = new System.Windows.Forms.TextBox();
            this.btnCurSpeed = new System.Windows.Forms.Button();
            this.tbCurQuality = new System.Windows.Forms.TextBox();
            this.btnCurQ = new System.Windows.Forms.Button();
            this.btnSpeedUp = new System.Windows.Forms.Button();
            this.btnQualityUp = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxName.Location = new System.Drawing.Point(12, 49);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(305, 30);
            this.tbxName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(8, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(269, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Введите название принтера";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(119, 161);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 51);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(1, 228);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(330, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "Удалить принтер";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbMaxSpeed
            // 
            this.tbMaxSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMaxSpeed.Location = new System.Drawing.Point(12, 123);
            this.tbMaxSpeed.Name = "tbMaxSpeed";
            this.tbMaxSpeed.Size = new System.Drawing.Size(305, 30);
            this.tbMaxSpeed.TabIndex = 1;
            // 
            // lbMaxlSpeed
            // 
            this.lbMaxlSpeed.AutoSize = true;
            this.lbMaxlSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbMaxlSpeed.Location = new System.Drawing.Point(11, 92);
            this.lbMaxlSpeed.Name = "lbMaxlSpeed";
            this.lbMaxlSpeed.Size = new System.Drawing.Size(295, 24);
            this.lbMaxlSpeed.TabIndex = 1;
            this.lbMaxlSpeed.Text = "Введите макс. скорость (л/мин)";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.btnDisplay);
            this.gb1.Controls.Add(this.btnQualityUp);
            this.gb1.Controls.Add(this.btnSpeedUp);
            this.gb1.Controls.Add(this.btnCurQ);
            this.gb1.Controls.Add(this.tbCurQuality);
            this.gb1.Controls.Add(this.btnCurSpeed);
            this.gb1.Controls.Add(this.tbCurSpeed);
            this.gb1.Location = new System.Drawing.Point(-15, -19);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(352, 299);
            this.gb1.TabIndex = 4;
            this.gb1.TabStop = false;
            this.gb1.Text = "groupBox1";
            this.gb1.Visible = false;
            // 
            // tbCurSpeed
            // 
            this.tbCurSpeed.Location = new System.Drawing.Point(229, 36);
            this.tbCurSpeed.Name = "tbCurSpeed";
            this.tbCurSpeed.ReadOnly = true;
            this.tbCurSpeed.Size = new System.Drawing.Size(100, 22);
            this.tbCurSpeed.TabIndex = 1;
            // 
            // btnCurSpeed
            // 
            this.btnCurSpeed.Location = new System.Drawing.Point(29, 36);
            this.btnCurSpeed.Name = "btnCurSpeed";
            this.btnCurSpeed.Size = new System.Drawing.Size(194, 23);
            this.btnCurSpeed.TabIndex = 2;
            this.btnCurSpeed.Text = "Получить тек. скорость";
            this.btnCurSpeed.UseVisualStyleBackColor = true;
            this.btnCurSpeed.Click += new System.EventHandler(this.btnCurSpeed_Click);
            // 
            // tbCurQuality
            // 
            this.tbCurQuality.Location = new System.Drawing.Point(228, 65);
            this.tbCurQuality.Name = "tbCurQuality";
            this.tbCurQuality.ReadOnly = true;
            this.tbCurQuality.Size = new System.Drawing.Size(100, 22);
            this.tbCurQuality.TabIndex = 1;
            // 
            // btnCurQ
            // 
            this.btnCurQ.Location = new System.Drawing.Point(30, 65);
            this.btnCurQ.Name = "btnCurQ";
            this.btnCurQ.Size = new System.Drawing.Size(192, 23);
            this.btnCurQ.TabIndex = 2;
            this.btnCurQ.Text = "Получить тек. качество";
            this.btnCurQ.UseVisualStyleBackColor = true;
            this.btnCurQ.Click += new System.EventHandler(this.btnCurQ_Click);
            // 
            // btnSpeedUp
            // 
            this.btnSpeedUp.Location = new System.Drawing.Point(75, 99);
            this.btnSpeedUp.Name = "btnSpeedUp";
            this.btnSpeedUp.Size = new System.Drawing.Size(102, 53);
            this.btnSpeedUp.TabIndex = 3;
            this.btnSpeedUp.Text = "Увелисить скорость";
            this.btnSpeedUp.UseVisualStyleBackColor = true;
            this.btnSpeedUp.Click += new System.EventHandler(this.btnSpeedUp_Click);
            // 
            // btnQualityUp
            // 
            this.btnQualityUp.Location = new System.Drawing.Point(204, 100);
            this.btnQualityUp.Name = "btnQualityUp";
            this.btnQualityUp.Size = new System.Drawing.Size(96, 53);
            this.btnQualityUp.TabIndex = 4;
            this.btnQualityUp.Text = "Повысить качество";
            this.btnQualityUp.UseVisualStyleBackColor = true;
            this.btnQualityUp.Click += new System.EventHandler(this.btnQualityUp_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(110, 171);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(144, 72);
            this.btnDisplay.TabIndex = 3;
            this.btnDisplay.Text = "Посмотреть данные об объекте";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 253);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbMaxlSpeed);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbMaxSpeed);
            this.Controls.Add(this.tbxName);
            this.Name = "MainForm";
            this.Text = "Priner";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox tbMaxSpeed;
        private System.Windows.Forms.Label lbMaxlSpeed;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnQualityUp;
        private System.Windows.Forms.Button btnSpeedUp;
        private System.Windows.Forms.Button btnCurQ;
        private System.Windows.Forms.TextBox tbCurQuality;
        private System.Windows.Forms.Button btnCurSpeed;
        private System.Windows.Forms.TextBox tbCurSpeed;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

