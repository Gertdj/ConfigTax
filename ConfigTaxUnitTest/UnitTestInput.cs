using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConfigTax;

namespace ConfigTaxTest
{
    [TestClass]
    public class UnitInput
    {
        [TestMethod]
        public void Test_LoadMainInputObject()
        {
            TaxInformation ti = new TaxInformation();
        }

        [TestMethod]
        public void Test_SetEarnings()
        {
            decimal amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.Earnings.SetAmount(1000);
            amt = ti.NormalEarnings.Earnings.Amount;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_SetTravelAllowancePTD()
        {
            decimal amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.TravelAllowance.SetAmount(1000);
            amt = ti.NormalEarnings.TravelAllowance.Amount;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_CalcTravelAllowanceTaxable()
        {
            decimal amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.TravelAllowance.SetAmount(1000);
            amt = ti.NormalEarnings.TravelAllowance.Amount_Taxable;
            Assert.AreEqual(amt, 800);
        }

        [TestMethod]
        public void Test_Annualise_Average()
        {
            var AnnualTaxable = Annualise.Calc  (1, 10000, 30.4166666666667M, 365);
            Assert.AreEqual(Math.Round(AnnualTaxable), 120000);
        }
    }
}
