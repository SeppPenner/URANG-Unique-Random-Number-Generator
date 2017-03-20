namespace URANG_Unique_Random_Number_Generator
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button_Generate = new System.Windows.Forms.Button();
            this.textBox_Generate = new System.Windows.Forms.TextBox();
            this.label_Generate = new System.Windows.Forms.Label();
            this.numericUpDown_Length = new System.Windows.Forms.NumericUpDown();
            this.label_Length = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Length)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(141, 61);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(75, 23);
            this.button_Generate.TabIndex = 0;
            this.button_Generate.Text = "Generate new random string";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // textBox_Generate
            // 
            this.textBox_Generate.Location = new System.Drawing.Point(15, 25);
            this.textBox_Generate.Name = "textBox_Generate";
            this.textBox_Generate.ReadOnly = true;
            this.textBox_Generate.Size = new System.Drawing.Size(333, 20);
            this.textBox_Generate.TabIndex = 1;
            // 
            // label_Generate
            // 
            this.label_Generate.AutoSize = true;
            this.label_Generate.Location = new System.Drawing.Point(12, 9);
            this.label_Generate.Name = "label_Generate";
            this.label_Generate.Size = new System.Drawing.Size(132, 13);
            this.label_Generate.TabIndex = 2;
            this.label_Generate.Text = "New unique random serial:";
            // 
            // numericUpDown_Length
            // 
            this.numericUpDown_Length.Location = new System.Drawing.Point(15, 64);
            this.numericUpDown_Length.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown_Length.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Length.Name = "numericUpDown_Length";
            this.numericUpDown_Length.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Length.TabIndex = 3;
            this.numericUpDown_Length.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Length
            // 
            this.label_Length.AutoSize = true;
            this.label_Length.Location = new System.Drawing.Point(15, 48);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(82, 13);
            this.label_Length.TabIndex = 4;
            this.label_Length.Text = "Length of serial:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 95);
            this.Controls.Add(this.label_Length);
            this.Controls.Add(this.numericUpDown_Length);
            this.Controls.Add(this.label_Generate);
            this.Controls.Add(this.textBox_Generate);
            this.Controls.Add(this.button_Generate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "URANG-Unique Random Number Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Length)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.TextBox textBox_Generate;
        private System.Windows.Forms.Label label_Generate;
        private System.Windows.Forms.NumericUpDown numericUpDown_Length;
        private System.Windows.Forms.Label label_Length;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Generate;
    }
}

