﻿using System;
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
 //       public new double Amount { get; set; }
        public decimal Amount_Taxable { get; private set; }

        public TravelAllowance()
        {
           
        }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
            CalcAmount_Taxable();
        }

        private void CalcAmount_Taxable()
        {
            
            if(Amount != 0)
            {
                Amount_Taxable = Amount * (decimal)0.8;
            }
            else
            {
                Amount_Taxable = 0;
            }
        }
    }
}
