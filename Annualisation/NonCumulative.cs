using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigTax;
using ConfigTax.Input;

namespace ConfigTax.Annualisation
{
    public class NonCumulative : IAnnualisationMethod
    {
        //Properties
        public TaxInformation Input { get; set; }
        public double TaxableEarnings { get; set; }

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
            TaxableEarnings = NormalEarnings * 12;
        }
    }
}
