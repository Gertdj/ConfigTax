using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTax
{
    public class Helper
    {
        public static double Nz_TextToDouble(string input)
        {
            double output = 0;

            if (string.IsNullOrEmpty(input))
            {
                output = 0;
            }
            else
            {
                output = double.Parse(input);
            }

            return output;
        }



    }
}
