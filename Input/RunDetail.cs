using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConfigTax
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]

    public class RunDetail
    {
        [ComVisible(true)]

        public const double AveWorkingDays = 30.416666666667;
        
        //Properties
        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public DateTime TaxStartDate { get; set; } //Official Tax StartDate
        public DateTime PayrollDate { get; set; }
        public DateTime TaxStart { get; set; } //Latest of HireDate and TaxStartDate
        public double DaysWorked { get; set; }
        public DateTime TaxPeriod { get; set; }
        public int TaxPeriodsRemaining { get; set; }
        public bool FullMonth { get; set; }

        //Constructor
        public RunDetail()
        {
        }

        public string GetTaxStart()
        {
            // DateTime dt = Convert.ToDateTime(txtTaxStart.Text);

            if(HireDate > TaxStartDate)
                {
                    TaxStart = HireDate;
                }
            else
                {
                    TaxStart = TaxStartDate;
                }

            return TaxStart.ToString("dd-MMM-yy");
        }

        public string GetDaysWorked()
        {
            DaysWorked = (PayrollDate - TaxStart).TotalDays + 1;
            return DaysWorked.ToString();
        }
    }
}
