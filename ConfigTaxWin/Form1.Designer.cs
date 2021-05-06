
namespace ConfigTaxWin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dtHireDate = new System.Windows.Forms.DateTimePicker();
            this.dtPayrollDate = new System.Windows.Forms.DateTimePicker();
            this.dtTaxStartDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtHireDate
            // 
            this.dtHireDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHireDate.CustomFormat = "dd-MMM-yy";
            this.dtHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHireDate.Location = new System.Drawing.Point(367, 107);
            this.dtHireDate.Name = "dtHireDate";
            this.dtHireDate.Size = new System.Drawing.Size(120, 20);
            this.dtHireDate.TabIndex = 1;
            // 
            // dtPayrollDate
            // 
            this.dtPayrollDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPayrollDate.CustomFormat = "dd-MMM-yy";
            this.dtPayrollDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPayrollDate.Location = new System.Drawing.Point(367, 146);
            this.dtPayrollDate.Name = "dtPayrollDate";
            this.dtPayrollDate.Size = new System.Drawing.Size(120, 20);
            this.dtPayrollDate.TabIndex = 2;
            // 
            // dtTaxStartDate
            // 
            this.dtTaxStartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTaxStartDate.CustomFormat = "dd-MMM-yy";
            this.dtTaxStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTaxStartDate.Location = new System.Drawing.Point(367, 65);
            this.dtTaxStartDate.Name = "dtTaxStartDate";
            this.dtTaxStartDate.Size = new System.Drawing.Size(120, 20);
            this.dtTaxStartDate.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtTaxStartDate);
            this.Controls.Add(this.dtPayrollDate);
            this.Controls.Add(this.dtHireDate);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtHireDate;
        private System.Windows.Forms.DateTimePicker dtPayrollDate;
        private System.Windows.Forms.DateTimePicker dtTaxStartDate;
    }
}