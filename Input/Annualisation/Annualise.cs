using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTax
{
    public class Annualise
    {
        //Properties

        static int annualisationMethod;
        static decimal taxableNormalEarnings;
        static decimal daysWorked;
        static int daysInTheYear;
        static decimal NormalEarningsAnnualised;

        //Constructor
        public Annualise()
        {
        }

        public static decimal Calc(int AnnualisationMethod, decimal TaxableNormalEarnings, decimal DaysWorked, int DaysInTheYear)
        {
            annualisationMethod = AnnualisationMethod;
            taxableNormalEarnings = TaxableNormalEarnings;
            daysWorked = DaysWorked;
            daysInTheYear = DaysInTheYear;
            

            switch (AnnualisationMethod)
            {
                case 1:
                    AverageMethod();
                    break;

                case 2:

                    break;

                case 3:

                    break; 
            }

            return NormalEarningsAnnualised;
        }
        
        private static void AverageMethod()
        {
            NormalEarningsAnnualised = (taxableNormalEarnings / daysWorked) * daysInTheYear;
        }
    }
}
