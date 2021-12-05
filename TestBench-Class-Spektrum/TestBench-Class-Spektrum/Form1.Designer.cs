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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_load_spectrum = new System.Windows.Forms.Button();
            this.chart_test_spectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_exit = new System.Windows.Forms.Button();
            this.txtBx_status = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart_test_spectrum)).BeginInit();
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
            // chart_test_spectrum
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_test_spectrum.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_test_spectrum.Legends.Add(legend1);
            this.chart_test_spectrum.Location = new System.Drawing.Point(277, 12);
            this.chart_test_spectrum.Name = "chart_test_spectrum";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "loaded_spectrum";
            this.chart_test_spectrum.Series.Add(series1);
            this.chart_test_spectrum.Size = new System.Drawing.Size(617, 382);
            this.chart_test_spectrum.TabIndex = 1;
            this.chart_test_spectrum.Text = "chart1";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(13, 520);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // txtBx_status
            // 
            this.txtBx_status.Location = new System.Drawing.Point(203, 520);
            this.txtBx_status.Name = "txtBx_status";
            this.txtBx_status.Size = new System.Drawing.Size(100, 20);
            this.txtBx_status.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 635);
            this.Controls.Add(this.txtBx_status);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.chart_test_spectrum);
            this.Controls.Add(this.btn_load_spectrum);
            this.Name = "Form1";
            this.Text = " Test Bench for Class spectrum.cs  Vers 1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_test_spectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load_spectrum;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_test_spectrum;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TextBox txtBx_status;
    }
}

