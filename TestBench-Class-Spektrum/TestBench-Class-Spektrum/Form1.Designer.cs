namespace TestBench_Class_Spektrum
{
    partial class Form1
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
            this.btn_load_spectrum = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_load_spectrum
            // 
            this.btn_load_spectrum.Location = new System.Drawing.Point(2, 12);
            this.btn_load_spectrum.Name = "btn_load_spectrum";
            this.btn_load_spectrum.Size = new System.Drawing.Size(148, 23);
            this.btn_load_spectrum.TabIndex = 0;
            this.btn_load_spectrum.Text = "load spectrum";
            this.btn_load_spectrum.UseVisualStyleBackColor = true;
            this.btn_load_spectrum.Click += new System.EventHandler(this.btn_load_spectrum_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_load_spectrum);
            this.Name = "Form1";
            this.Text = " Test Bench for Class spectrum.cs  Vers 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_load_spectrum;
    }
}

