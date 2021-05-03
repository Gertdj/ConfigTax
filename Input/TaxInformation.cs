﻿using System;
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

        public double GetNormalEarningsAnnualised()
        {
            var NormalEarn = NormalEarnings.GetTaxableNormalEarningsYTD();
            
            var NormEarnAnn = Annualise.Calc(1, NormalEarn, 30.416666666667, 365);
            return NormEarnAnn;

        }
    }
}
