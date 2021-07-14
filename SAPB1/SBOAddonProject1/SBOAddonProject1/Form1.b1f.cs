using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;
using SAPbouiCOM;

namespace SBOAddonProject1
{
    [FormAttribute("SBOAddonProject1.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }
        private FormController formController;
        private SAPbouiCOM.Grid grid;
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button = ((SAPbouiCOM.Button)(this.GetItem("Item_0").Specific));
            this.Button.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button_PressedAfter);
            this.grid = ((SAPbouiCOM.Grid)(this.GetItem("Item_1").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
           
        }

        private SAPbouiCOM.Button Button;

        private void OnCustomInitialize()
        {
            formController = new FormController(UIAPIRawForm, UIConnection.Company);

            GridSetup();
        }
        private void GridSetup()
        {
            grid.DataTable.Columns.Add("Currency", BoFieldsType.ft_AlphaNumeric);
            grid.DataTable.Columns.Add("Account Currency Code", BoFieldsType.ft_AlphaNumeric);
            grid.DataTable.Columns.Add("Account Number", BoFieldsType.ft_AlphaNumeric);
            grid.DataTable.Columns.Add("Position", BoFieldsType.ft_Integer);
            grid.DataTable.Columns.Add("Intermediary  Bank Code", BoFieldsType.ft_AlphaNumeric);
            grid.DataTable.Columns.Add("Intermediary Bank Name", BoFieldsType.ft_AlphaNumeric);        
            grid.AutoResizeColumns();
        }

        private void Button_PressedAfter(object sboObject, SBOItemEventArg pVal)
        {
            formController.GetDatasInList();
            formController.AddData(formController.AccountNumber.Count);
        }
    }
}