using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfigTax;

namespace ConfigTaxWin
{
    public partial class TaxInformation : Form
    {
        #region GlobalScope

        ConfigTax.TaxInformation ti = new ConfigTax.TaxInformation();

        #endregion

        #region Constructor
        public TaxInformation()
        {
            InitializeComponent();
            setNormalEarnings();
            setPreTaxDeductions();
        }
        #endregion

        #region Load
        private void TaxInformation_Load(object sender, EventArgs e)
        {
            //Active menu item
            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;
            panelTopMenu.Width = btnAverage.Width;
            panelTopMenu.Left = btnAverage.Left;

            //Set Payroll Period
            dtPayrollPeriod.Value = GetLastDay(dtPayrollPeriod.Value);

            //Set HireDate
            dtHireDate.Value = DateTime.ParseExact("01-Mar-21", "dd-MMM-yy", CultureInfo.InvariantCulture);

            //Set Termination Date
            dtTerminationDate.Value = DateTime.ParseExact("28-Feb-22", "dd-MMM-yy", CultureInfo.InvariantCulture);

            //Set TaxYear StarDate 
            dtTaxYearStart.Value = DateTime.ParseExact("01-Mar-21", "dd-MMM-yy", CultureInfo.InvariantCulture);

            //Calculate DaysWorked
            txtDaysWorked.Text = ti.RunDetail.GetDaysWorked();

            //Load initial data into Input Object
            ti.RunDetail.PayrollDate = dtPayrollPeriod.Value;
            ti.RunDetail.HireDate = dtHireDate.Value;
            ti.RunDetail.TaxStartDate = dtTaxYearStart.Value;

            txtTaxStart.Text = ti.RunDetail.GetTaxStart();

            var daysworked = (dtPayrollPeriod.Value - dtTaxYearStart.Value).TotalDays + 1;
            txtDaysWorked.Text = daysworked.ToString();

            txtFullMonth.Text = "True";



            #region AnnualisationMethod

            


            #endregion 
        }
        #endregion

        #region ClickEvents

        //Annualisation Method - Average
        private void btnAverage_Click(object sender, EventArgs e)
        {
            panelTopMenu.Width = btnAverage.Width;
            panelTopMenu.Left = btnAverage.Left;

            //Set Annualisation Method
            Global.AnnualisationMethod = Global.AnnualisationMethod_enum.Average;
            setNormalEarnings();
            setPreTaxDeductions();
        }

        //Annualisation Method - Cumulative
        private void btnCumulative_Click(object sender, EventArgs e)
        {
            panelTopMenu.Width = btnCumulative.Width;
            panelTopMenu.Left = btnCumulative.Left;

            Global.AnnualisationMethod = Global.AnnualisationMethod_enum.Cumulative;
            setNormalEarnings();
            setPreTaxDeductions();
        }

        //Annualisation Method - Non-Cumulative
        private void btnNonCumulative_Click(object sender, EventArgs e)
        {
            panelTopMenu.Width = btnNonCumulative.Width;
            panelTopMenu.Left = btnNonCumulative.Left;

            Global.AnnualisationMethod = Global.AnnualisationMethod_enum.NonCumulative;
            setNormalEarnings();
            setPreTaxDeductions();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;

            //Hide Input Panel
            panelInputParent.Visible = false;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnEmployee.Height;
            panelLeft.Top = btnEmployee.Top;

            //Hide Input Panel
            panelInputParent.Visible = false;
        }

        private void btnLegislation_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnLegislation.Height;
            panelLeft.Top = btnLegislation.Top;

            //Hide Input Panel
            panelInputParent.Visible = false;

        }

        private void btnTaxInput_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnTaxInput.Height;
            panelLeft.Top = btnTaxInput.Top;

            //Hide Input Panel
            panelInputParent.Visible = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcTax_Click(object sender, EventArgs e)
        {
            //dtTaxStartDate. = 01/03/21; 

            DateTime dtTaxStart = new DateTime();
            dtTaxStart = DateTime.Parse("01-Mar-21");

            //dtTaxStartDate.Value = DateTime.ParseExact("25/03/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var ti = new ConfigTax.TaxInformation();

            ti.NormalEarnings.SetEarningsYTD(10000);
            ti.NormalEarnings.SetTravelAllowanceYTD(1000);

            // ti.AnnualEarnings.SetBonusYTD(20000);
            // ti.AnnualEarnings.SetSharesYTD(50000);


            // var TotalAnnualYTD = ti.AnnualEarnings.GetTotalAnnualEarningsYTD();
            // MessageBox.Show("TotalAnnEarnYTD: " + TotalAnnualYTD.ToString());

            var TaxNormEarn = ti.NormalEarnings.GetTaxableNormalEarningsYTD();
            MessageBox.Show(TaxNormEarn.ToString());

            var AnnNormEarn = Math.Round(ti.GetNormalEarningsAnnualised());
            MessageBox.Show(AnnNormEarn.ToString());

            ti.RunDetail.HireDate = dtHireDate.Value;

            //var taxStartDate = ti.RunDetail.TaxStartDate;
            //taxStartDate = "01-Mar-21";

            //DateTime dt = DateTime.Parse (taxStartDate);

            var tsStr = dtHireDate.Text;
        }


        #endregion

        #region ValueChangeEvevts
        private void dtHireDate_ValueChanged(object sender, EventArgs e)
        {
            ti.RunDetail.HireDate = dtHireDate.Value;
            txtTaxStart.Text = ti.RunDetail.GetTaxStart();
            btnCalcTax.Focus();
        }

        private void txtTaxStart_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(txtTaxStart.Text);
            var daysworked = (dtPayrollPeriod.Value - dt).TotalDays + 1;
            txtDaysWorked.Text = daysworked.ToString();
        }

        private void dtPayrollPeriod_ValueChanged(object sender, EventArgs e)
        {
            dtPayrollPeriod.Value = GetLastDay(dtPayrollPeriod.Value);

            if (txtTaxStart.Text.Length > 0)
            {
                DateTime taxStart = Convert.ToDateTime(txtTaxStart.Text);
                var daysworked = (dtPayrollPeriod.Value - taxStart).TotalDays + 1;
                txtDaysWorked.Text = daysworked.ToString();
                btnCalcTax.Focus();
            }
        }

        private void dtTaxYearStart_ValueChanged(object sender, EventArgs e)
        {
            //Update Input Object
            ti.RunDetail.TaxStartDate = dtTaxYearStart.Value;

            //Set Payroll Period and Range
            dtPayrollPeriod.MinDate = dtTaxYearStart.Value;
            dtPayrollPeriod.MaxDate = dtTaxYearStart.Value.AddMonths(11);
            dtPayrollPeriod.Value = dtTaxYearStart.Value;
            dtPayrollPeriod.Value = GetLastDay(dtPayrollPeriod.Value);

            txtTaxStart.Text = ti.RunDetail.GetTaxStart();

            //Update Employee Termination Date on the form
            var taxYearStart = dtTaxYearStart.Value;
            var lastDay = DateTime.DaysInMonth(taxYearStart.Year, taxYearStart.Month);
            var empTerminationDate = taxYearStart.AddMonths(12);
            empTerminationDate = new DateTime(empTerminationDate.Year, empTerminationDate.Month, lastDay);
            dtTerminationDate.Value = empTerminationDate;
        }

        #endregion

        #region Local Methods
        private DateTime GetLastDay(DateTime dateIn)
        {
            var lastDay = DateTime.DaysInMonth(dateIn.Year, dateIn.Month);
            var fullDate = new DateTime(dateIn.Year, dateIn.Month, lastDay);

            return fullDate;
        }

        private void setNormalEarnings()
        {
            //var dimension = "";
            var annMethod = Global.AnnualisationMethod;
            
            //Get new Normal Earnings Panel Object
            Panel panelNormalEarnings = new Panel();
            panelNormalEarnings = PanelNormalEarnings;

            switch (annMethod.ToString())
            {
            case "Average":

                foreach (Control control in panelNormalEarnings.Controls)
                        {
                        switch (control.Name)
                        {
                            case "lblEarnings":
                                lblEarnings.Text = "Earnings (YTD)";
                                txtEarnings.Text = "";
                            break;

                            case "lblFringeBenefits":
                                lblFringeBenefits.Text = "FringeBenefits (YTD)";
                                txtFringeBenefits.Text = "";
                            break;

                        case "lblTravelAllowance":
                                lblTravelAllowance.Text = "Travel Allowance (YTD)";
                                txtTravelAllowance.Text = "";
                            break;
                        }
                    }
                break;

            case "Cumulative":

                foreach (Control control in panelNormalEarnings.Controls)
                {
                    switch (control.Name)
                    {
                        case "lblEarnings":
                            lblEarnings.Text = "Earnings (PTD)";
                                txtEarnings.Text = "";
                                break;

                        case "lblFringeBenefits":
                            lblFringeBenefits.Text = "FringeBenefits (PTD)";
                            txtFringeBenefits.Text = "";
                            break;

                        case "lblTravelAllowance":
                            lblTravelAllowance.Text = "Travel Allowance (PTD)";
                            txtTravelAllowance.Text = "";
                            break;
                    }
                }
                break;

            case "NonCumulative":
                    foreach (Control control in panelNormalEarnings.Controls)
                    {
                        switch (control.Name)
                        {
                            case "lblEarnings":
                                lblEarnings.Text = "Earnings (PTD)";
                                txtEarnings.Text = "";
                                break;

                            case "lblFringeBenefits":
                                lblFringeBenefits.Text = "FringeBenefits (PTD)";
                                txtFringeBenefits.Text = "";
                                break;

                            case "lblTravelAllowance":
                                lblTravelAllowance.Text = "Travel Allowance (PTD)";
                                txtTravelAllowance.Text = "";
                                break;
                        }
                    }
                    break;
            }
        }

        private void setPreTaxDeductions()
        {
            var annMethod = Global.AnnualisationMethod;

            //Get new Pre-Tax Deductions Panel Object
            Panel panelPreTaxDeductions = new Panel();
            panelPreTaxDeductions = PanelPreTaxDeductions;

            switch (annMethod.ToString())
            {
                case "Average":

                    foreach (Control control in panelPreTaxDeductions.Controls)
                    {
                        switch (control.Name)
                        {
                            case "lblPension":
                                lblPension.Text = "Pension (YTD)";
                                txtPension.Text = "";
                                break;

                            case "lblAnnuities":
                                lblAnnuities.Text = "Annuities (YTD)";
                                txtAnnuities.Text = "";
                                break;

                            case "lblReliefs":
                                lblReliefs.Text = "Relief (YTD)";
                                txtReliefs.Text = "";
                                break;
                        }
                    }
                    break;

                case "Cumulative":

                    foreach (Control control in panelPreTaxDeductions.Controls)
                    {
                        switch (control.Name)
                        {
                            case "lblPension":
                                lblPension.Text = "Pension (PTD)";
                                txtPension.Text = "";
                                break;

                            case "lblAnnuities":
                                lblAnnuities.Text = "Annuities (PTD)";
                                txtAnnuities.Text = "";
                                break;

                            case "lblReliefs":
                                lblReliefs.Text = "Relief (PTD)";
                                txtReliefs.Text = "";
                                break;
                        }
                    }
                    break;

                case "NonCumulative":
                    foreach (Control control in panelPreTaxDeductions.Controls)
                    {
                        switch (control.Name)
                        {
                            case "lblPension":
                                lblPension.Text = "Pension (PTD)";
                                txtPension.Text = "";
                                break;

                            case "lblAnnuities":
                                lblAnnuities.Text = "Annuities (PTD)";
                                txtAnnuities.Text = "";
                                break;

                            case "lblReliefs":
                                lblReliefs.Text = "Relief (PTD)";
                                txtReliefs.Text = "";
                                break;
                        }
                    }
                    break;
            }

            //var lblEarn = lblEarnings as Label;
            //lblEarn.Text = "XXX";

            //var txtBox = txtEarnings as TextBox;
            //txtBox.Text = "123";



        }
    }
    #endregion
}
