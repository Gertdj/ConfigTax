﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigTax;
using ConfigTax.Annualisation;

namespace ConfigTax.Annualisation
{
    public class NonCumulative : IAnnualisationMethod
    {
        //Properties
        public TaxInformation Input { get; set; }
        public double AnnualTaxableNormalEarnings { get; set; }

        //Constructor
        public NonCumulative(TaxInformation input)
        {
            Input = input;
            CalcTaxableEarnings();
        }

        //Methods

        private void CalcTaxableEarnings()
        {
            double NormalEarnings;

            NormalEarnings = Input.NormalEarnings.Earnings.AmountPTD;
            AnnualTaxableNormalEarnings = NormalEarnings * 12;
        }
    }
}
