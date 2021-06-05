using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTax
{
    public static class Global
    {
        public const double AveMonthDays = 30.416666666667;

        public enum AnnualisationMethod_enum
        {
            Average,
            Cumulative,
            NonCumulative
        }

        private static AnnualisationMethod_enum _annualisationMethod = 0;

        public static AnnualisationMethod_enum AnnualisationMethod
        {
            get { return _annualisationMethod; }
            set { _annualisationMethod = value; }
        }
    }
}
