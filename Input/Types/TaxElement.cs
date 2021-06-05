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
    public class TaxElement //Base class (parent)
    {
        [ComVisible(true)]
        public double Amount { get; set; }
        public double AmountPrev { get; private set; }

        public TaxElement()
        {
        }
        
        //private double  calcPrevYTD()
        //{
        //    double prevYTD;

        //    prevYTD = AmountYTD - AmountPTD;
        //    return prevYTD;
        //}
     
        public void SetAmount(double amount)
        {
            Amount = amount;
        }


    }
}
