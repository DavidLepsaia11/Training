using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBOAddon1
{
    class FormController
    {
        public SAPbouiCOM.IForm Form { get; set; }
        public SAPbobsCOM.Company Company { get; set; }
        private SAPbobsCOM.Recordset rs { get; set; }
      
        private List<string> UserNames;
        public SAPbouiCOM.EditText TextBox { get; set; }

        private int Counter { get; set; }

        public FormController(SAPbouiCOM.IForm form, SAPbobsCOM.Company company)
        {
            Counter = 0;
            Form = form;
            Company = company;
            TextBox = (SAPbouiCOM.EditText)Form.Items.Item("TextBox").Specific;
            UserNames = new List<string>();
        }

        public void GetUserNames()
        {
            rs = (SAPbobsCOM.Recordset)Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery("SELECT * FROM OCRD");



            while (!rs.EoF)
            {
                var userName = rs.Fields.Item("CardName").Value.ToString();
                UserNames.Add(userName);
                rs.MoveNext();
            }
        }


        #region MyMethods
        public void MovePrevious()
        {
            if (Counter == 0)
            {
                Counter = UserNames.Count - 1;
                TextBox.Value = UserNames[Counter];
            }
            else
            {
                Counter--;
                TextBox.Value = UserNames[Counter];
            }
        }

        public void MoveNext()
        {
            if (Counter == (UserNames.Count - 1))
            {
                Counter = 0;
                TextBox.Value = UserNames[Counter];
            }
            else
            {
                Counter++;
                TextBox.Value = UserNames[Counter];
            }

        }

        public void MoveLast()
        {
            Counter = UserNames.Count - 1;
            TextBox.Value = UserNames[Counter];
        }

        public void MoveFirst()
        {
            Counter = 0;
            TextBox.Value = UserNames[Counter];
        }
        #endregion

    }
}
