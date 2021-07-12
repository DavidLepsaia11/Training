using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;

namespace SBOAddon1
{
    [FormAttribute("SBOAddon1.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button6 = ((SAPbouiCOM.Button)(this.GetItem("Pre_btn").Specific));
            this.Button6.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button6_PressedAfter);
            this.Button7 = ((SAPbouiCOM.Button)(this.GetItem("Next_btn").Specific));
            this.Button7.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button7_PressedAfter);
            this.Button8 = ((SAPbouiCOM.Button)(this.GetItem("MvPr_Btn").Specific));
            this.Button8.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button8_PressedAfter);
            this.Button9 = ((SAPbouiCOM.Button)(this.GetItem("MvNxt_Btn").Specific));
            this.Button9.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button9_PressedAfter);
            this.OnCustomInitialize();

        }
        private FormController formController;
        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }
        
        private void OnCustomInitialize()
        {
            formController = new FormController(UIAPIRawForm, UIConnection.Company);
            formController.GetUserNames();
        }

        private SAPbouiCOM.Button Button6;

        private void Button6_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.MovePrevious();
        }

        private SAPbouiCOM.Button Button7;
        private SAPbouiCOM.Button Button8;

        private void Button7_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.MoveNext();
        }

        private void Button8_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.MoveLast();
        }

        private SAPbouiCOM.Button Button9;

        private void Button9_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.MoveFirst();
        }
    }
}