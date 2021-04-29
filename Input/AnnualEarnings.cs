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
    public class AnnualEarnings
    {
        //Properties
        [ComVisible(true)]
        public Bonus Bonus { get; set; }
        public Shares Shares { get; set; }
        public LeaveCommutation LeaveCommutation { get; set; }
        public double TotalAnnualEarningsPTD { get; set; }

        //Constructor
        public AnnualEarnings()
        {
            CreateBonus();
            CreateShares();
            CreateLeaveCommutation();
        }

        //Methods
        private void CreateBonus()
        {
            Bonus bonus = new Bonus();
            Bonus = bonus;
        }

        private void CreateShares()
        {
            Shares shares = new Shares();
            Shares = shares;
        }

        private void CreateLeaveCommutation()
        {
            LeaveCommutation leaveCommutation = new LeaveCommutation();
            LeaveCommutation = leaveCommutation;
        }

        //Set Sub-Element values
        //Bonus
        public void SetBonusPTD(double Amount)
        {
            Bonus.AmountPTD = Amount;
        }

        public void SetBonusYTD(double Amount)
        {
            Bonus.AmountYTD = Amount;
        }

        //Shares
        public void SetSharesPTD(double Amount)
        {
            Shares.SetAmountPTD(Amount);
        }

        public void SetSharesYTD(double Amount)
        {
            Shares.SetAmountYTD(Amount);
        }

        //LeaveCommutation
        public void SetLeaveCommutationPTD(double Amount)
        {
            LeaveCommutation.SetAmountPTD(Amount);
        }

        public void SetLeaveCommutationYTD(double Amount)
        {
            LeaveCommutation.AmountYTD = Amount;
        }


        public double GetTotalAnnualEarningsPTD()
        {
            double TotalAnnualEarnings;
            TotalAnnualEarnings = Bonus.AmountPTD + Shares.AmountPTD + LeaveCommutation.AmountPTD ;
            TotalAnnualEarningsPTD = TotalAnnualEarnings;
            return TotalAnnualEarnings;
        }
    }
}
