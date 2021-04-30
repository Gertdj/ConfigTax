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
            double TotalNormalYTD;
            double TotalNormalTaxableYTD;

            double TotalAnnualYTD;

            TaxInformation ti = new TaxInformation();

            ti.NormalEarnings.SetEarningsYTD(10000);
            ti.NormalEarnings.SetTravelAllowanceYTD(1000);

            ti.AnnualEarnings.SetBonusYTD(20000);
            ti.AnnualEarnings.SetSharesYTD(50000);


            TotalNormalYTD = ti.NormalEarnings.GetTotalNormalEarningsYTD();
            TotalNormalTaxableYTD = ti.NormalEarnings.GetTotalTaxableNormalEarningsPTD();

            MessageBox.Show(TotalNormalYTD.ToString());
            MessageBox.Show(TotalNormalTaxableYTD.ToString());

            TotalAnnualYTD = ti.AnnualEarnings.GetTotalAnnualEarningsYTD();

            MessageBox.Show("TotalAnnualEarnings_YTD: " + TotalAnnualYTD.ToString());

            

        }
    }
}
