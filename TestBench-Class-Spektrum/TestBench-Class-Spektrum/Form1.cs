using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBench_Class_Spektrum
{
    public partial class Form1 : Form
    {
        Spectrum test = new Spectrum();
        public Form1()
        {
            InitializeComponent();
            
           
            //get systems decimal seperator in case it needs to be exchaned in loaded txt file
            string seperator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            txtBx_status.Text = seperator;// kann gelöscht werden!!!!
        }

        private void btn_load_spectrum_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try {

                    test.readTextFile(fd.FileName);
                    chart_test_spectrum.Series["loaded_spectrum"].Points.DataBindXY(test.Wavelength, test.Counts);
                    //numericOffsetHigh.Maximum = Convert.ToDecimal(quelle.Wavelength.Max());
                    //numericOffsetLow.Minimum = Convert.ToDecimal(quelle.Wavelength.Min());
                    //numericOffsetHigh.Minimum = Convert.ToDecimal(quelle.Wavelength.Min());
                }
                catch
                {
                    MessageBox.Show("failed to open file");
                }
            }
         }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
