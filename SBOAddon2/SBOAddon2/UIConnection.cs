using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace SBOAddon2
{
    public static class UIConnection
    {
        public static Company Company { get { return lazyCompany.Value; } }

        public static readonly Lazy<Company> lazyCompany =
          new Lazy<Company>(() => (Company)SAPbouiCOM.Framework
                                   .Application
                                   .SBO_Application
                                   .Company.GetDICompany());
    }
}
