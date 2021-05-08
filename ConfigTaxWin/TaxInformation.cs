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
        public TaxInformation()
        {
            InitializeComponent();
        }

        private void TaxInformation_Load(object sender, EventArgs e)
        {
            panelDates.Visible = false;

            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;

            panelTopMenu.Width = btnAverage.Width;
            panelTopMenu.Left = btnAverage.Left;

            dtPayrollDate.Value = DateTime.ParseExact("31-Mar-21", "dd-MMM-yy", CultureInfo.InvariantCulture);
            dtHireDate.Value = DateTime.ParseExact("01-Mar-21", "dd-MMM-yy", CultureInfo.InvariantCulture);
            dtTaxYearStart.Value = DateTime.ParseExact("01-Mar-21", "dd-MMM-yy", CultureInfo.InvariantCulture);

            txtTaxStart.Text = dtTaxYearStart.Text;

            var daysworked = (dtPayrollDate.Value - dtTaxYearStart.Value).TotalDays + 1;
            txtDaysWorked.Text = daysworked.ToString();

            txtFullMonth.Text = "Yes";



        }

        private void btnCalcTax_Click(object sender, EventArgs e)
        {
            ConfigTax.TaxInformation ti = new ConfigTax.TaxInformation();

            ti.RunDetail.PayrollDate = dtPayrollDate.Text;
        }

         private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnDashboard.Height;
            panelLeft.Top = btnDashboard.Top;

            panelDates.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            panelTopMenu.Width = btnAverage.Width;
            panelTopMenu.Left = btnAverage.Left;
        }

        private void btnCumulative_Click(object sender, EventArgs e)
        {
            panelTopMenu.Width = btnCumulative.Width;
            panelTopMenu.Left = btnCumulative.Left;
        }

        private void btnNonCumulative_Click(object sender, EventArgs e)
        {
            panelTopMenu.Width = btnNonCumulative.Width;
            panelTopMenu.Left = btnNonCumulative.Left;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnEmployee.Height;
            panelLeft.Top = btnEmployee.Top;

            panelDates.Visible = false;
        }

        private void btnLegislation_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnLegislation.Height;
            panelLeft.Top = btnLegislation.Top;

            panelDates.Visible = false;
        }

        private void dtHireDate_ValueChanged(object sender, EventArgs e)
        {
            if(dtHireDate.Value > dtTaxYearStart.Value)
                {
                    txtTaxStart.Text = dtHireDate.Text;
                }
            else
                {
                txtTaxStart.Text = dtTaxYearStart.Text;
                }
            btnCalcTax.Focus();
        }

        private void txtTaxStart_TextChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(txtTaxStart.Text);
            var daysworked = (dtPayrollDate.Value - dt).TotalDays + 1;
            txtDaysWorked.Text = daysworked.ToString();
        }

        private void dtPayrollDate_ValueChanged(object sender, EventArgs e)
        {
            if (txtTaxStart.Text.Length > 0)
            {
                DateTime dt = Convert.ToDateTime(txtTaxStart.Text);
                var daysworked = (dtPayrollDate.Value - dt).TotalDays + 1;
                txtDaysWorked.Text = daysworked.ToString();
                btnCalcTax.Focus(); 
            }
        }

        private void btnTaxInput_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnTaxInput.Height;
            panelLeft.Top = btnTaxInput.Top;

            panelDates.Top = btnDashboard.Top;
            panelDates.Visible = true;
        }
    }
}
