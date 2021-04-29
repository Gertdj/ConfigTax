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
    public class Reliefs
    {
        [ComVisible(true)]
        public Relief Relief { get; set; }

        public Reliefs()
        {
            CreateRelief();
        }

        private void CreateRelief()
        {
            Relief relief = new Relief();
            Relief = relief;
        }
    }
}
