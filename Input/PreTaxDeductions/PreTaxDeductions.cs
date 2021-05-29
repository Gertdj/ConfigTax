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
        //Properties
        [ComVisible(true)]
        public Pension  Pension { get; set; }
        public Annuity Annuity { get; set; }
        public Relief Relief { get; set; }
        public decimal TotalPreTaxDeductions { get; set; }


        //Constructor
        public PreTaxDeductions()
        {
            CreatePension();
            CreateAnnuity();
            CreateRelief();
        }

        //Methods
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

        private void CreateRelief()
        {
            Relief relief = new Relief();
            Relief = relief;
        }

        //Set Sub-Element values
        //Earnings

        public void SetPension(decimal amount)
        {
            Pension.Amount = amount;
        }

        public void SetAnnuity(decimal amount)
        {
            Annuity.Amount = amount;
        }

        public void SetRelief(decimal amount)
        {
            Relief.Amount = amount;
        }

        public decimal GetTotalPreTaxDeductions()
        {
            decimal PreTaxDeductions;
            PreTaxDeductions = Relief.Amount + Annuity.Amount + Relief.Amount;
            TotalPreTaxDeductions = PreTaxDeductions;
            return TotalPreTaxDeductions;
        }
    }
}
