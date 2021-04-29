using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ConfigTax.Input;

namespace ConfigTax
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class PreTaxDeductions
    {
        [ComVisible(true)]
        public Pension  Pension { get; set; }
        public Annuity Annuity { get; set; }

        public PreTaxDeductions()
        {
            CreatePension();
            CreateAnnuity();
        }

        private void CreatePension()
        {
            Pension pension = new Pension();
            Pension = pension;
        }

        private void CreateAnnuity()
        {
            Annuity annuity = new Annuity();
            Annuity = annuity;
        }
    }
}
