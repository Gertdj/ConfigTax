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
    public class TravelAllowance:TaxElement
    {
        public new double AmountYTD { get; set; }
        public double AmountYTD_Taxable { get; private set; }

        public TravelAllowance()
        {
           
        }

        public void SetAmountYTD(double Amount)
        {
            AmountYTD = Amount;
            CalcAmountYTD_Taxable();
        }

        private void CalcAmountYTD_Taxable()
        {
            
            if(AmountYTD != 0)
            {
                AmountYTD_Taxable = AmountYTD * 0.8;
            }
            else
            {
                AmountYTD_Taxable = 0;
            }
        }
    }
}
