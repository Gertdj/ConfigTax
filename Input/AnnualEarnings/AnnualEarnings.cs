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
    public class AnnualEarnings
    {
        //Properties
        [ComVisible(true)]
        public Bonus Bonus { get; set; }
        public Shares Shares { get; set; }
        public LeaveCommutation LeaveCommutation { get; set; }
        public double TotalAnnualEarnings { get; private set; }

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
        public void SetBonus(double amount)
        {
            Bonus.Amount = amount;
        }

        //Shares
        public void SetShares(double amount)
        {
            Shares.SetAmount(amount);
        }

        //LeaveCommutation
        public void SetLeaveCommutation(double amount)
        {
            LeaveCommutation.SetAmount(amount);
        }

        /// <summary>
        /// Sets TotalAnnualEarnings as the sum of all Annual Earnings Sub-Elements
        /// </summary>
        public void SetTotalAnnualEarningsSumOfElements()
        {
            TotalAnnualEarnings = Bonus.Amount + Shares.Amount + LeaveCommutation.Amount ;
        }

        /// <summary>
        /// Gets TotalAnnualEarnings
        /// </summary>
        /// <returns>TotalAnnualEarnings</returns>
        public double GetTotalAnnualEarnings()
        {
            return TotalAnnualEarnings;
        }

        public void SetTotalAnnualEarnings(double amount) => TotalAnnualEarnings = amount;
    }
}
