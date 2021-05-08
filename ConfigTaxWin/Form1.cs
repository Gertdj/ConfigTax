﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            //dtTaxStartDate. = 01/03/21; 

            DateTime dtTaxStart = new DateTime();
            dtTaxStart = DateTime.Parse("01-Mar-21");

            //dtTaxStartDate.Value = DateTime.ParseExact("25/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var ti = new ConfigTax.TaxInformation();

            ti.NormalEarnings.SetEarningsYTD(10000);
            ti.NormalEarnings.SetTravelAllowanceYTD(1000);

            // ti.AnnualEarnings.SetBonusYTD(20000);
            // ti.AnnualEarnings.SetSharesYTD(50000);


            // var TotalAnnualYTD = ti.AnnualEarnings.GetTotalAnnualEarningsYTD();
            // MessageBox.Show("TotalAnnEarnYTD: " + TotalAnnualYTD.ToString());

            var TaxNormEarn =  ti.NormalEarnings.GetTaxableNormalEarningsYTD();
            MessageBox.Show(TaxNormEarn.ToString());

            var AnnNormEarn = Math.Round(ti.GetNormalEarningsAnnualised());
            MessageBox.Show(AnnNormEarn.ToString());

            ti.RunDetail.HireDate = dtHireDate.Text;

            //var taxStartDate = ti.RunDetail.TaxStartDate;
            //taxStartDate = "01-Mar-21";

            //DateTime dt = DateTime.Parse (taxStartDate);

            var tsStr = dtHireDate.Text;

            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtTaxStartDate.Value = DateTime.ParseExact("01-Mar-21", "dd-MMM-yy", CultureInfo.InvariantCulture);
        }
    }
}
