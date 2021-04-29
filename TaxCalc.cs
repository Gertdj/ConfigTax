using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigTax;

namespace ConfigTax
{
    public class TaxCalc
    {
        //References
        public TaxInformationInput Input { get; set; }
        public Annualisation.NonCumulative nonCumulative  { get; set; }
        public double TaxableEarnings { get; set; }



        //Constructor
        public TaxCalc()
        {

        }

        //methods
        private void CreateInput()
        {
            TaxInformationInput input = new TaxInformationInput();
            Input = input; 
        }

        private void CreateAnnualisation()
        {
            Annualisation.NonCumulative annualisation = new Annualisation.NonCumulative(Input);
        }

        private void GetTax()
        {
            TaxableEarnings = nonCumulative.TaxableEarnings * 30 / 100; 
        }
        


    }
}
