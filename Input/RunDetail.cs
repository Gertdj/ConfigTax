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
        public string HireDate { get; set; }
        public string TaxStartDate { get; set; }
        public string PayrollDate { get; set; }
        public int DaysWorked { get; set; }
        public DateTime TaxPeriod { get; set; }
        public int TaxPeriodsRemaining { get; set; }

        //Constructor
        public RunDetail()
        {

        }
    }
}
