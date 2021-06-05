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
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.Earnings.SetAmount(1000);
            amt = ti.NormalEarnings.Earnings.Amount;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_SetTravelAllowancePTD()
        {
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.TravelAllowance.SetAmount(1000);
            amt = ti.NormalEarnings.TravelAllowance.Amount;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_CalcTravelAllowanceTaxable()
        {
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.TravelAllowance.SetAmount(1000);
            amt = ti.NormalEarnings.TravelAllowance.Amount_Taxable;
            Assert.AreEqual(amt, 800);
        }

        [TestMethod]
        public void Test_Annualise_Average()
        {
            TaxInformation ti = new TaxInformation();
            var AnnualTaxable = ti.GetNormalEarningsAnnual(10000, 30.4166666666667, 365);
            Assert.AreEqual(Math.Round(AnnualTaxable), 120000);
        }
    }
}
