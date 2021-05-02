using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTax.Annualisation
{
    public class Average : IAnnualisationMethod 
    {
        //Properties
        public TaxInformation Input { get; set; }
        public double AnnualTaxableNormalEarnings { get; set; }

        //Constructor
        public Average(TaxInformation input)
        {
            Input = input;
            CalcTaxableEarnings();
        }

        private void CalcTaxableEarnings()
        {
            double TotalTaxableNormalEarningsYTD;
            int DaysWorked;
            int DaysInTheYear;


            DaysInTheYear = 365;
            DaysWorked = 1;


            TotalTaxableNormalEarningsYTD = Input.GetTotalTaxableNormalEarningsYTD();
            AnnualTaxableNormalEarnings = (TotalTaxableNormalEarningsYTD / DaysWorked) * DaysInTheYear;
        }
    }
}
