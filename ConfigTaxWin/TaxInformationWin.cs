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
    public partial class TaxInformationWin : Form
    {
        #region GlobalScope

        public ConfigTax.TaxInformation ti = new ConfigTax.TaxInformation();
        public string activeButton = "";


        #endregion

        #region Constructor
        public TaxInformationWin()
        {
            InitializeComponent();
            setNormalEarnings();
            setPreTaxDeductions();
        }
        #endregion

        #region Load
        private void TaxInformation_Load(object sender, EventArgs e)
        {
            //panelDates.BackColor = Color.FromArgb(100,0,0,0);
            //panelNormalEarnings.BackColor = Color.FromArgb(100, 0, 0, 0);
            //panelTax.BackColor = Color.FromArgb(100, 0, 0, 0);
            //panelAnnualEarnings.BackColor = Color.FromArgb(100, 0, 0, 0);
            //PanelPreTaxDeductions.BackColor = Color.FromArgb(100, 0, 0, 0);
            //panelNormalEarningsDetail.BackColor = Color.FromArgb(100, 0, 0, 0);
            //panelAnnualEarningsDetail.BackColor = Color.FromArgb(100, 0, 0, 0);
            //panelPreTaxDetail.BackColor = Color.FromArgb(100, 0, 0, 0);


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

            ////Calculate DaysWorked
            //var DaysWorked = (dtPayrollPeriod.Value - dtTaxYearStart.Value).TotalDays + 1;
            //txtDaysWorked.Text = DaysWorked.ToString();

            //Calculate Periods Worked



            //Calculated Full Period Worked
            txtFullMonth.Text = IsFullPeriod();
 
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
            Panel panelParent = new Panel();
            panelParent = panelInputParent;
            panelParent.Visible = true;
           

            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;

            activeButton = "Dashboard";
            SelectForm();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnEmployee.Height;
            panelLeft.Top = btnEmployee.Top;
            activeButton = "EmployeeInput";
            SelectForm();
        }

        private void btnLegislation_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnLegislation.Height;
            panelLeft.Top = btnLegislation.Top;
            activeButton = "Legislation";
            SelectForm();
        }

        private void btnTaxInput_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnTaxInput.Height;
            panelLeft.Top = btnTaxInput.Top;
            activeButton = "TaxInput";
            SelectForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcTax_Click(object sender, EventArgs e)
        {
            LoadData();

            double annualTaxableEarnings = ti.GetNormalEarningsAnnualised(1000);
            MessageBox.Show("Annual Taxable Earnings: " + annualTaxableEarnings.ToString());
        }

        private void txtTotalNormalEarnings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = txtTotalAnnualEarnings;
            }
        }

        private void txtTotalAnnualEarnings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = txtTotalPreTaxDeductions;
            }
        }

        private void txtBonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = txtPreviousTax;
            }
        }

        private void txtPreviousTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.ActiveControl = btnCalcTax;
                //   btnCalcTax.PerformClick();
            }
        }

        #endregion

        #region ValueChangeEvevts

        private void dtHireDate_ValueChanged(object sender, EventArgs e)
        {
            txtTaxStartActual.Text = ti.RunDetail.GetTaxStart(dtHireDate.Value, dtTaxYearStart.Value);
            txtFullMonth.Text = IsFullPeriod();

            //var daysWorked = ti.RunDetail.GetDaysWorked(dtPayrollPeriod.Value, DateTime.ParseExact(txtTaxStartActual.Text, "dd-MMM-yy", CultureInfo.InvariantCulture));
            //txtDaysWorked.Text = daysWorked.ToString();

            btnCalcTax.Focus();
        }

        private void dtTerminationDate_ValueChanged(object sender, EventArgs e)
        {
            var daysWorked = ti.RunDetail.GetDaysWorked(dtTerminationDate.Value, DateTime.ParseExact(txtTaxStartActual.Text, "dd-MMM-yy", CultureInfo.InvariantCulture));
            txtDaysWorked.Text = daysWorked.ToString();

            txtFullMonth.Text = IsFullPeriod();

            btnCalcTax.Focus();
        }

        private void txtTaxStart_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(txtTaxStartActual.Text);
            var daysworked = (dtPayrollPeriod.Value - dt).TotalDays + 1;
            txtDaysWorked.Text = daysworked.ToString();
        }

        private void dtPayrollPeriod_ValueChanged(object sender, EventArgs e)
        {
            txtFullMonth.Text = IsFullPeriod();

            dtPayrollPeriod.Value = GetLastDay(dtPayrollPeriod.Value);

            if (txtTaxStartActual.Text.Length > 0)
            {
                DateTime taxStartActual = Convert.ToDateTime(txtTaxStartActual.Text);
                var daysWorked = ti.RunDetail.GetDaysWorked(dtPayrollPeriod.Value, taxStartActual);
//                txtDaysWorked.Text = daysWorked.ToString();
                btnCalcTax.Focus();
            }
        }

        private void dtTaxYearStart_ValueChanged(object sender, EventArgs e)
        {
            //Set Payroll Period and Range
            dtPayrollPeriod.MinDate = dtTaxYearStart.Value;
            dtPayrollPeriod.MaxDate = dtTaxYearStart.Value.AddMonths(11);
            dtPayrollPeriod.Value = dtTaxYearStart.Value;
            dtPayrollPeriod.Value = GetLastDay(dtPayrollPeriod.Value);
            dtHireDate.Value = dtTaxYearStart.Value;

            txtTaxStartActual.Text = dtTaxYearStart.Value.ToString("dd-MMM-yy");

            //Update Employee Termination Date on the form
            var taxYearStart = dtTaxYearStart.Value;
            var lastDay = DateTime.DaysInMonth(taxYearStart.Year, taxYearStart.Month);
            var empTerminationDate = taxYearStart.AddMonths(12);
            empTerminationDate = new DateTime(empTerminationDate.Year, empTerminationDate.Month, lastDay);
            dtTerminationDate.Value = empTerminationDate;
        }

        private void radioButtonSimple_CheckedChanged(object sender, EventArgs e)
        {
            SetInputTypeForms();
        }

        private void radioButtonDetail_CheckedChanged(object sender, EventArgs e)
        {
            SetInputTypeForms();
        }

        #endregion

        #region Local Methods

        private void LoadData()
        {
            //Run Detail
            ti.RunDetail.TaxYearStart = dtTaxYearStart.Value;
            ti.RunDetail.HireDate = dtHireDate.Value;
            ti.RunDetail.TerminationDate = dtTerminationDate.Value;
            ti.RunDetail.PayrollDate = dtPayrollPeriod.Value;
            ti.RunDetail.FullMonth = true;

            if (this.radioButtonSimple.Checked == true)
            {
                ti.RunDetail.CalculationType = "Simple";
            } 
            else
            {
                ti.RunDetail.CalculationType = "Detailed";
            }

            DateTime dt = DateTime.ParseExact(txtTaxStartActual.Text, "dd-MMM-yy", CultureInfo.InvariantCulture);
            ti.RunDetail.TaxStartActual = dt;

            ti.RunDetail.DaysWorked = double.Parse(txtDaysWorked.Text);


            //txtFullMonth.Text = "True";
            //bool mybool = bool.Parse(txtFullMonth.Text);
            //ti.RunDetail.FullMonth = mybool;


            //Normal Earnings
            ti.NormalEarnings.SetTotalTaxableNormalEarnings(Helper.Nz_TextToDouble(txtTotalNormalEarnings.Text));

            //Annual Earnings
            ti.AnnualEarnings.SetTotalAnnualEarnings(Helper.Nz_TextToDouble(txtTotalAnnualEarnings.Text));

            //Pre-Tax Deductions
            ti.PreTaxDeductions.SetTotalPreTaxDeductions(Helper.Nz_TextToDouble(txtTotalPreTaxDeductions.Text));
            
            //Previous Tax Deductions
            ti.Tax.PreviousTax = Helper.Nz_TextToDouble(txtPreviousTax.Text);
        }

        private void SelectForm()
        {
            switch(activeButton)
            {
                case "Dashboard":
                    HideAll();
                    break;

                case "EmployeeInput":
                    HideAll();
                    break;

                case "Legislation":
                    HideAll();
                    break;

                case "TaxInput":
                    radioButtonSimple.Enabled = true;
                    panelInputType.Visible = true;
                    labelInputType.Visible = true;
                    panelDates.Visible = true;
                    panelNormalEarnings.Visible = true;
                    panelAnnualEarnings.Visible = true;
                    PanelPreTaxDeductions.Visible = true;
                    
                    panelTax.Top = 204;
                    panelTax.Visible = true;

                    break;
            }
  
        }

        private void SetInputTypeForms()
        {
            if (radioButtonSimple.Checked == true)
            {
                panelInputType.Visible = true;
                labelInputType.Visible = true;

                panelNormalEarningsDetail.Visible = false;
                panelAnnualEarningsDetail.Visible = false;
                panelPreTaxDetail.Visible = false;

                panelTax.Top = 204;
                panelInputParent.Visible = true;

            }
            else
            {
                panelNormalEarningsDetail.Visible = true;
                panelAnnualEarningsDetail.Visible = true;
                panelPreTaxDetail.Visible = true;
                labelInputType.Visible = true;

                panelTax.Top = 459;
            }
        }

        private void HideAll()
        {

            panelDates.Visible = false;
            panelInputType.Visible = false;
            labelInputType.Visible = false;
            panelNormalEarnings.Visible = false;
            panelAnnualEarnings.Visible = false;
            PanelPreTaxDeductions.Visible = false;
            panelTax.Visible = false;

            //            this.panelInputParent.Dispose();

        }

        private DateTime GetLastDay(DateTime dateIn)
        {
            var lastDay = DateTime.DaysInMonth(dateIn.Year, dateIn.Month);
            var fullDate = new DateTime(dateIn.Year, dateIn.Month, lastDay);

            return fullDate;
        }

        /// <summary>
        /// Sets all labels for Input Fields (Normal Earnings) according to the Method of Annualisation
        /// and clears the relevand Text fields for new input
        /// </summary>
        private void setNormalEarnings()
        {
            //var dimension = "";
            var annMethod = Global.AnnualisationMethod;
            
            //Get new Normal Earnings Panel Object
            Panel panelNormalEarnings = new Panel();
            panelNormalEarnings = this.panelNormalEarnings;

            switch (annMethod.ToString())
            {
            case "Average":

                foreach (Control control in panelNormalEarnings.Controls)
                        {
                        switch (control.Name)
                        {
                            case "lblTotalTaxableNormalEarnings":
                                lblTotalNormalEarnings.Text = "Total Normal Earnings (YTD)";
                                txtTotalNormalEarnings.Text = "";
                            break;

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

        /// <summary>
        /// Sets all labels for Input Fields (Pre-Tax Deductions) according to the Method of Annualisation
        /// and clears the relevand Text fields for new input
        /// </summary>

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
                            case "lblTotalPreTaxDeductions":
                                lblTotalPreTaxDeductions.Text = "Total Pre-Tax Deductions (YTD)";
                                txtTotalPreTaxDeductions.Text = "";
                                break;

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

        private void TaxInformation_Paint(object sender, PaintEventArgs e)
        {
            this.ActiveControl = txtTotalNormalEarnings;
            txtTotalNormalEarnings.Text = "";
        }

        private string IsFullPeriod()
        {
            string isFullPeriod;

            if (dtHireDate.Value <= dtTaxYearStart.Value & dtTerminationDate.Value >= dtPayrollPeriod.Value)
            {
                isFullPeriod = "True";
                int periodsWorked = GetPeriodsWorked();
                txtPeriodsWorked.Text = periodsWorked.ToString();
                lblDaysWorked.Text = "Days Worked (Average)";
                txtDaysWorked.Text = (periodsWorked * Global.AveMonthDays).ToString();
                return isFullPeriod;

            }
            else
            {
                isFullPeriod = "False";
                txtPeriodsWorked.Text = "";

                lblDaysWorked.Text = "Days Worked (Actual)";
                return isFullPeriod;
            }
        }

        private int GetPeriodsWorked()
        {
            var months = (((dtPayrollPeriod.Value.Year - dtTaxYearStart.Value.Year) * 12) + dtPayrollPeriod.Value.Month - dtTaxYearStart.Value.Month) + 1;
            return months;
        }

        #endregion

        #region Control Leave

        private void txtTotalTaxableNormalEarnings_Leave(object sender, EventArgs e)
        {
            txtTotalNormalEarnings.Text = string.Format("{0:#,##0.00}", Helper.Nz_TextToDouble(txtTotalNormalEarnings.Text));
        }

        private void txtTotalAnnualEarnings_Leave(object sender, EventArgs e)
        {
            txtTotalAnnualEarnings.Text = string.Format("{0:#,##0.00}", Helper.Nz_TextToDouble(txtTotalAnnualEarnings.Text));
        }

        private void txtTotalPreTaxDeductions_Leave(object sender, EventArgs e)
        {
            txtTotalPreTaxDeductions.Text = string.Format("{0:#,##0.00}", Helper.Nz_TextToDouble(txtTotalPreTaxDeductions.Text));
        }

        private void txtPreviousTax_Leave(object sender, EventArgs e)
        {
            txtPreviousTax.Text = string.Format("{0:#,##0.00}", double.Parse(txtPreviousTax.Text));
        }

        #endregion

    }
}
