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
            var ti = new TaxInformation();

            ti.NormalEarnings.SetEarningsYTD(10000);
            ti.NormalEarnings.SetTravelAllowanceYTD(1000);

            // ti.AnnualEarnings.SetBonusYTD(20000);
            // ti.AnnualEarnings.SetSharesYTD(50000);


            // var TotalAnnualYTD = ti.AnnualEarnings.GetTotalAnnualEarningsYTD();
            // MessageBox.Show("TotalAnnEarnYTD: " + TotalAnnualYTD.ToString());

            var TaxNormEarn =  ti.NormalEarnings.GetTaxableNormalEarningsYTD();
            MessageBox.Show(TaxNormEarn.ToString());

            var AnnNormEarn = Annualise.Calc(1, TaxNormEarn,30.416666666667,365);
            MessageBox.Show(AnnNormEarn.ToString());

            AnnNormEarn = Math.Round(ti.GetNormalEarningsAnnualised(TaxNormEarn));
            MessageBox.Show(AnnNormEarn.ToString());

        }
    }
}
