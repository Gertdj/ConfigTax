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
        public virtual double AmountPTD { get; set; }
        public double AmountYTD { get; set; }
        public double AmountPrevYTD { get; private set; }

        public TaxElement()
        {

        }
        
        private double  calcPrevYTD()
        {
            double prevYTD;

            prevYTD = AmountYTD - AmountPTD;
            return prevYTD;
        }
     
        public virtual void SetAmountPTD(double Amount)
        {
            AmountPTD = Amount;
        }

        public void SetAmountYTD(double Amount)
        {
            AmountYTD = Amount;
        }


    }
}
