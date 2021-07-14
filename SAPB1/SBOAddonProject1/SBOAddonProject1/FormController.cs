using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBOAddonProject1
{
    class FormController
    {
        public SAPbouiCOM.IForm Form { get; set; }
        public SAPbobsCOM.Company Company { get; set; }
        private SAPbobsCOM.Recordset rs { get; set; }
        public SAPbouiCOM.Grid Grid { get; set; }

        #region Lists
        public List<string> Currency;
        public List<string> AccountCurrencyCode;
        public List<string> AccountNumber;
        public List<int> Position;
        public List<string> IntermediaryBankCode;
        public List<string> IntermediaryBankName;
        #endregion

        public FormController(SAPbouiCOM.IForm form, SAPbobsCOM.Company company)
        {
            Form = form;
            Company = company;
             Grid = ((SAPbouiCOM.Grid)(Form.Items.Item("Item_1").Specific));
            Currency = new List<string>();
            AccountCurrencyCode = new List<string>();
            AccountNumber = new List<string>();
            Position = new List<int>();
            IntermediaryBankCode = new List<string>();
           IntermediaryBankName = new List<string>();
        }

          public void GetDatasInList()
        {
            rs = (SAPbobsCOM.Recordset)Company.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery("SELECT TOP 24 * FROM DSC1");
            Random r = new Random();
            int  number;
            string tempStr="";
            string CurrencyCode = "";
            while (!rs.EoF)
            {
                tempStr= rs.Fields.Item("Account").Value.ToString();
                CurrencyCode = (tempStr[tempStr.Length - 3] + tempStr[tempStr.Length - 2] + tempStr[tempStr.Length - 1]).ToString();

                AccountNumber.Add(tempStr);
                IntermediaryBankCode.Add(rs.Fields.Item("BankCode").Value.ToString());
                IntermediaryBankName.Add(rs.Fields.Item("AcctName").Value.ToString());
                AccountCurrencyCode.Add(CurrencyCode);

                number = r.Next(0, 100);
                Position.Add(number);

                switch (CurrencyCode)
                {
                    case "GEL":
                        {
                            Currency.Add("Gela");
                            break;
                        }
                    case "EUR":
                        {
                            Currency.Add("EURO");
                            break;
                        }
                    case "USD":
                        {
                            Currency.Add("American Dollar");
                            break;
                        }
                    case "GBP":
                        {
                            Currency.Add("Pound Starling");
                            break;
                        }
                    default:
                        {
                            Currency.Add("Other Currency");
                            break;
                        }
                }

                rs.MoveNext();
            }
        }
          public void AddData(int Length )
         {
            Form.Freeze(true);
            for (int i = 0; i < Length; i++)
            {
                Grid.DataTable.Rows.Add(1);
                Grid.DataTable.Columns.Item("Currency").Cells.Item(i).Value = Currency[i];
                Grid.DataTable.Columns.Item("Account Currency Code").Cells.Item(i).Value = AccountCurrencyCode[i];
                Grid.DataTable.Columns.Item("Account Number").Cells.Item(i).Value = AccountNumber[i];
                Grid.DataTable.Columns.Item("Position").Cells.Item(i).Value = Position[i];
                Grid.DataTable.Columns.Item("Intermediary  Bank Code").Cells.Item(i).Value = IntermediaryBankCode[i];
                Grid.DataTable.Columns.Item("Intermediary Bank Name").Cells.Item(i).Value = IntermediaryBankName[i];
            }
            Form.Freeze(false);
        }
    }
}
