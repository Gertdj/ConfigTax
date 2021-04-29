using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigTax;
using ConfigTax.Input;
using ConfigTax.Annualisation;

namespace ConfigTaxWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double TotalNormalPTD;
            double TotalNormalTaxablePTD;
            
            TaxInformation ti = new TaxInformation();

            ti.NormalEarnings.SetEarningsPTD (10000);
            ti.NormalEarnings.SetTravelAllowancePTD(1000);



            TotalNormalPTD = ti.NormalEarnings.GetTotalNormalEarningsPTD();
            TotalNormalTaxablePTD = ti.NormalEarnings.GetTotalTaxableNormalEarningsPTD();




            MessageBox.Show(TotalNormalPTD.ToString());
            MessageBox.Show(TotalNormalTaxablePTD.ToString());   
            
            

        }

       






    }
}
