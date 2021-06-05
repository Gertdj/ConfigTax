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

        //Properties
        public DateTime HireDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public DateTime TaxYearStart { get; set; } //Official Tax StartDate
        public DateTime PayrollDate { get; set; }
        public DateTime TaxStartActual { get; set; } //Latest of HireDate and TaxStartDate
        public double DaysWorked { get; set; }
        public int TaxPeriodsRemaining { get; set; }
        public bool FullMonth { get; set; }
        public string CalculationType { get; set; }

        //Constructor
        public RunDetail()
        {
        }

        public string GetTaxStart(DateTime hireDate, DateTime taxYearStart)
        {
            // DateTime dt = Convert.ToDateTime(txtTaxStart.Text);
            DateTime taxStartActual;

            if (hireDate > taxYearStart)
            {
                taxStartActual = hireDate;
            }
            else
            {
                taxStartActual = taxYearStart;
            }

            return taxStartActual.ToString("dd-MMM-yy");
        }

        public double GetDaysWorked(DateTime date2, DateTime date1)
        {
            DaysWorked = (double)(date2 - date1).TotalDays + 1;
            return DaysWorked;
        }
    }
}
