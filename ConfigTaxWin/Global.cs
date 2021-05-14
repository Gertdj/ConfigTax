using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTaxWin
{
    static class Global
    {
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
