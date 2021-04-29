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
        public void Test_SetEarningsPTD()
        {
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.Earnings.SetAmountPTD(1000);
            amt = ti.NormalEarnings.Earnings.AmountPTD;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_SetEarningsYTD()
        {
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.Earnings.SetAmountYTD(1000);
            amt = ti.NormalEarnings.Earnings.AmountYTD;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_SetTravelAllowancePTD()
        {
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.TravelAllowance.SetAmountPTD(1000);
            amt = ti.NormalEarnings.TravelAllowance.AmountPTD;
            Assert.AreEqual(amt, 1000);
        }

        [TestMethod]
        public void Test_CalcTravelAllowanceTaxable()
        {
            double amt;
            TaxInformation ti = new TaxInformation();
            ti.NormalEarnings.TravelAllowance.SetAmountPTD(1000);
            amt = ti.NormalEarnings.TravelAllowance.AmountPTD_Taxable;
            Assert.AreEqual(amt, 800);
        }
    }
}
