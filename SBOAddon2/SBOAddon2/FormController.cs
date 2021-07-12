using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBOAddon2
{
    class FormController
    {
        public SAPbouiCOM.IForm Form { get; set; }
        public SAPbobsCOM.Company Company { get; set; }

        public SAPbouiCOM.Grid Grid { get; set; }


        public FormController(SAPbouiCOM.IForm form, SAPbobsCOM.Company company)
        {         
            Form = form;
            Company = company;
            Grid = (SAPbouiCOM.Grid)Form.Items.Item("Item_0").Specific;
        }


        public void TableQuery_1()
        {
            Grid.DataTable.ExecuteQuery("SELECT TOP 10 * FROM OCRD");
        }
    public void TableQuery_2()
        {
            Grid.DataTable.ExecuteQuery("SELECT TOP 10 * FROM OWHS");
        }
        public void TableQuery_3()
        {
            Grid.DataTable.ExecuteQuery("SELECT TOP 10 * FROM OITM");
        }
        public void TableQuery_4()
        {
            Grid.DataTable.ExecuteQuery("SELECT TOP 10 * FROM OPLN ");
        }
        public void TableQuery_5()
        {
            Grid.DataTable.ExecuteQuery("SELECT TOP 10 * FROM OFLT");
        }
    }
}
