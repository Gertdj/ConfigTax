using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTax.Annualisation
{
    interface IAnnualisationMethod
    {
        double AnnualTaxableNormalEarnings { get; set; }
    }
}
