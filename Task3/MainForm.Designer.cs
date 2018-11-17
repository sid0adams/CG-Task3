namespace Task3
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
            this.output = new System.Windows.Forms.PictureBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.AddPointBtn = new System.Windows.Forms.RadioButton();
            this.MoveBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.output)).BeginInit();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.Color.White;
            this.output.Location = new System.Drawing.Point(13, 50);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(1342, 617);
            this.output.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.output.TabIndex = 0;
            this.output.TabStop = false;
            this.output.MouseDown += new System.Windows.Forms.MouseEventHandler(this.output_MouseDown);
            this.output.MouseMove += new System.Windows.Forms.MouseEventHandler(this.output_MouseMove);
            this.output.MouseUp += new System.Windows.Forms.MouseEventHandler(this.output_MouseUp);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(13, 13);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 1;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // AddPointBtn
            // 
            this.AddPointBtn.AutoSize = true;
            this.AddPointBtn.Checked = true;
            this.AddPointBtn.Location = new System.Drawing.Point(94, 16);
            this.AddPointBtn.Name = "AddPointBtn";
            this.AddPointBtn.Size = new System.Drawing.Size(68, 17);
            this.AddPointBtn.TabIndex = 2;
            this.AddPointBtn.TabStop = true;
            this.AddPointBtn.Text = "AddPoint";
            this.AddPointBtn.UseVisualStyleBackColor = true;
            // 
            // MoveBtn
            // 
            this.MoveBtn.AutoSize = true;
            this.MoveBtn.Location = new System.Drawing.Point(168, 16);
            this.MoveBtn.Name = "MoveBtn";
            this.MoveBtn.Size = new System.Drawing.Size(52, 17);
            this.MoveBtn.TabIndex = 3;
            this.MoveBtn.TabStop = true;
            this.MoveBtn.Text = "Move";
            this.MoveBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 679);
            this.Controls.Add(this.MoveBtn);
            this.Controls.Add(this.AddPointBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.output);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox output;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.RadioButton AddPointBtn;
        private System.Windows.Forms.RadioButton MoveBtn;
    }
}

