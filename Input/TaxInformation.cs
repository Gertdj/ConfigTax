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
    public class TaxInformation
    {
        [ComVisible(true)]
        //Propereties
        public ConfigTax.RunDetail RunDetail { get; set; }
        public NormalEarnings NormalEarnings  { get; set; }
        public AnnualEarnings AnnualEarnings { get; set; }
        public PreTaxDeductions PreTaxDeductions { get; set; }
 


        //Constructor
        public TaxInformation()
        {
            //Create the main Tax Elements for the Tax calculation 
            CreateRunDetail();
            CreateNormalEarnings();
            CreateAnnualEarnings();
            CreatePreTaxDeductions();
        }

        //Overloaded Construcor
        //public TaxInformation(InputList Input)
        //{
        //    //This overloaded Constructor will take list with multiple records and loop through each
        //    //Create the main Tax Elements for the Tax calculation 
        //    CreateRunDetail();
        //    CreateNormalEarnings();
        //    CreateAnnualEarnings();
        //    CreatePreTaxDeductions();
        //    CreateReliefs();
        //}

        //Methods
        private void CreateRunDetail()
        {
            RunDetail runDetail = new RunDetail();
            RunDetail = runDetail;
        }
        
        private void CreateNormalEarnings()
        {
            NormalEarnings normalEarnings = new NormalEarnings();
            NormalEarnings = normalEarnings;
        }

        private void CreateAnnualEarnings()
        {
            AnnualEarnings annualEarnings = new AnnualEarnings();
            AnnualEarnings = annualEarnings;
        }

        private void CreatePreTaxDeductions()
        {
            PreTaxDeductions preTaxDeductions = new PreTaxDeductions();
            PreTaxDeductions = preTaxDeductions;
        }

        public decimal GetNormalEarningsAnnualised()
        {
            var NormalEarn = NormalEarnings.GetTaxableNormalEarnings();
            
            //Send Actual Days Worked if not full month 
            var NormEarnAnn = Annualise.Calc(1, NormalEarn, Global.AveMonthDays, 365);
            return NormEarnAnn;

        }

        /// <summary>
        /// Calculate Simple Tax by using Pre-Calculated Total figures 
        /// </summary>
        /// <param name="annualisationMethod">Specify the Annualisation Method</param>
        /// <param name="daysWorked">Enter the total number of days worked in the Tax Year or Period</param>
        /// <param name="normalEarnings">Amount of Total Normal Earnings for the Period</param>
        /// <param name="annualEarnings">Amount of Total Annual Earnings for the Period</param>
        /// <param name="preTaxDeductions">Amount of Total Pre-Tax Deductions for the Period</param>
        public void CalculateTax(string annualisationMethod, decimal daysWorked, decimal normalEarnings,decimal annualEarnings,decimal preTaxDeductions)
        {
            Console.WriteLine(annualisationMethod);
            Console.WriteLine(daysWorked);
            Console.WriteLine(normalEarnings);
            Console.WriteLine(annualEarnings);
            Console.WriteLine(preTaxDeductions);
        }
    }
}
