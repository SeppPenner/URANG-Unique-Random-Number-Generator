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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxGenerate = new System.Windows.Forms.TextBox();
            this.label_Generate = new System.Windows.Forms.Label();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.label_Length = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Generate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(141, 61);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate new random string";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
            // 
            // textBox_Generate
            // 
            this.textBoxGenerate.Location = new System.Drawing.Point(15, 25);
            this.textBoxGenerate.Name = "textBoxGenerate";
            this.textBoxGenerate.ReadOnly = true;
            this.textBoxGenerate.Size = new System.Drawing.Size(333, 20);
            this.textBoxGenerate.TabIndex = 1;
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
            this.numericUpDownLength.Location = new System.Drawing.Point(15, 64);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLength.TabIndex = 3;
            this.numericUpDownLength.Value = new decimal(new int[] {
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
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.label_Generate);
            this.Controls.Add(this.textBoxGenerate);
            this.Controls.Add(this.buttonGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "URANG-Unique Random Number Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxGenerate;
        private System.Windows.Forms.Label label_Generate;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Label label_Length;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Generate;
    }
}

