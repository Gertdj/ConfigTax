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
            double TotalNormalPTD;
            double TotalNormalTaxablePTD;

            double TotalAnnualYTD;

            TaxInformation ti = new TaxInformation();

            ti.NormalEarnings.SetEarningsPTD(10000);
            ti.NormalEarnings.SetTravelAllowancePTD(1000);

            ti.AnnualEarnings.SetBonusYTD(20000);
            ti.AnnualEarnings.SetSharesYTD(50000);


            TotalNormalPTD = ti.NormalEarnings.GetTotalNormalEarningsPTD();
            TotalNormalTaxablePTD = ti.NormalEarnings.GetTotalTaxableNormalEarningsPTD();

            MessageBox.Show(TotalNormalPTD.ToString());
            MessageBox.Show(TotalNormalTaxablePTD.ToString());

            TotalAnnualYTD = ti.AnnualEarnings.GetTotalAnnualEarningsYTD();

            MessageBox.Show("TotalAnnualEarnings_YTD: " + TotalAnnualYTD.ToString());
        }
    }
}
