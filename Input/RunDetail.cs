using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConfigTax.Input
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]

    public class RunDetail
    {
        [ComVisible(true)]

        //Properties
        public DateTime HireDate { get; set; }
        public DateTime TaxStartDate { get; set; }
        public DateTime PayrollDate { get; set; }
        public int DaysWorked { get; set; }
        public int TaxPeriod { get; set; }
        public int TaxPeriodsRemaining { get; set; }

        //Constructor
        public RunDetail()
        {

        }
    }
}
