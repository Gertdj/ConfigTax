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
        public new double AmountPTD { get; set; }
        public double AmountPTD_Taxable { get; private set; }

        public TravelAllowance()
        {
           
        }

        public override void SetAmountPTD(double Amount)
        {
            AmountPTD = Amount;
            CalcAmountPTD_Taxable();
        }

        private void CalcAmountPTD_Taxable()
        {
            
            if(AmountPTD != 0)
            {
                AmountPTD_Taxable = AmountPTD * 0.8;
            }
            else
            {
                AmountPTD_Taxable = 0;
            }
        }
    }
}
