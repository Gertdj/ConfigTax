using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConfigTax.Input
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
