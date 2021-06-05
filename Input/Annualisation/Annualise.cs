using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTax
{
    public static class Annualise
    {
        //Properties

        public static string AnnualisationMethod { get; set; }
        public static double TaxableNormalEarnings { get; set; }
        public static double DaysWorked { get; set; }
        public static int DaysInTheYear { get; set; }
        public static double MyProperty { get; set; }
        public static double NormalEarningsAnnualised { get; set; }

        //Constructor
        static Annualise()
        {
        }

        public static double GetNormalEarningsAnnualised(string AnnualisationMethod,double TaxableNormalEarnings,double DaysWorked, int DaysInTheYear)
        {
            switch (AnnualisationMethod)
            {
                case "Average":
                    AverageMethod(TaxableNormalEarnings, DaysWorked, DaysInTheYear);
                    break;

                case "Cumulative":

                    break;

                case "NonCumulative":

                    break; 
            }

            return NormalEarningsAnnualised;
        }
        
        private static void AverageMethod(double TaxableNormalEarnings, double DaysWorked, double DaysInTheYear)
        {
            NormalEarningsAnnualised = (TaxableNormalEarnings / DaysWorked) * DaysInTheYear;
        }
    }
}
