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
//        public Annualise Annualise { get; set; }
        public Tax Tax { get; set; }


        //Constructor
        public TaxInformation()
        {
            //Create the main Tax Element Objects for the Tax calculation 
            CreateRunDetail();
            CreateNormalEarnings();
            CreateAnnualEarnings();
            CreatePreTaxDeductions();
            CreateTax();
//            CreateAnnualise();
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

        #region Create Objects
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

        //private void CreateAnnualise()
        //{
        //    Annualise annualise = new Annualise();
        //    Annualise = annualise;
        //}

        private void CreateTax()
        {
            Tax tax = new Tax();
            Tax = tax;
        }

        #endregion

        /// <summary>
        /// Get Normal Annualised Earnings using the DETAILED Input Method
        /// All input must be pre-loaded into the Tax Objects
        /// </summary>
        /// <returns></returns>
        public double GetNormalEarningsAnnualised()
        {
            string annualisationMethod = Global.AnnualisationMethod.ToString();
            double taxableNormalEarnings = NormalEarnings.GetTaxableNormalEarnings();
            double daysWorked = RunDetail.DaysWorked;
            double normalAnnualEarnings = Annualise.GetNormalEarningsAnnualised(annualisationMethod, taxableNormalEarnings, daysWorked, 365);
            return normalAnnualEarnings;
        }

        /// <summary>
        /// Get Normal Annualised Earnings using the SIMPLE Input Method
        /// Total Earnings and Pre-Tax Deductions are loaded loaded manually as parameters 
        /// </summary>
        /// <param name="TotalNormalEarnings"></param>
        /// TOTAL Normal Earnings entered as Input
        /// <param name="TotalPreTaxDeductions"></param>
        /// TOTAL Pre-Tax Deductions entered as Input
        /// <returns></returns>
        public double GetNormalEarningsAnnualised(double TotalNormalEarnings, double TotalPreTaxDeductions = 0)
        {
            string annualisationMethod = Global.AnnualisationMethod.ToString();
            double taxableNormalEarnings = TotalNormalEarnings - TotalPreTaxDeductions;
            double daysWorked = RunDetail.DaysWorked;
            double normalAnnualEarnings = Annualise.GetNormalEarningsAnnualised(annualisationMethod, taxableNormalEarnings, daysWorked, 365);
            return normalAnnualEarnings;
        }

        /// <summary>
        /// Calculate Simple Tax by using Pre-Calculated Total figures 
        /// </summary>
        /// <param name="daysWorked">Enter the total number of days worked in the Tax Year or Period</param>
        /// <param name="normalEarnings">Amount of Total Normal Earnings for the Period</param>
        /// <param name="annualEarnings">Amount of Total Annual Earnings for the Period</param>
        /// <param name="preTaxDeductions">Amount of Total Pre-Tax Deductions for the Period</param>
        public void CalculateTax(double daysWorked, double normalEarnings,double annualEarnings,double preTaxDeductions)
        {
            Console.WriteLine(daysWorked);
            Console.WriteLine(normalEarnings);
            Console.WriteLine(annualEarnings);
            Console.WriteLine(preTaxDeductions);
        }
    }
}
