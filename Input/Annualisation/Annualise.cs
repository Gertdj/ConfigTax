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
        static double taxableNormalEarnings;
        static double daysWorked;
        static int daysInTheYear;
        static double NormalEarningsAnnualised;

        //Constructor
        public Annualise()
        {
        }

        public static double Calc(int AnnualisationMethod, double TaxableNormalEarnings, double DaysWorked, int DaysInTheYear)
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
