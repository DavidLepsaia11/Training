using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;

namespace SBOAddon2
{
    [FormAttribute("SBOAddon2.Form1", "Form1.b1f")]
    class Form1 : UserFormBase
    {
        public Form1()
        {
        }
        public FormController formController;

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_0").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_1").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_2").Specific));
            this.Button1.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button1_PressedAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button2.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button2_PressedAfter);
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button3.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button3_PressedAfter);
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.Button4.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button4_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {

        }

        private SAPbouiCOM.Grid Grid0;

        private void OnCustomInitialize()
        {
            formController = new FormController(UIAPIRawForm, UIConnection.Company);
        }

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Button Button4;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           formController.TableQuery_1();
        }

        private void Button1_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           formController.TableQuery_2();
        }

        private void Button2_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.TableQuery_3();
        }

        private void Button3_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.TableQuery_4();
        }

        private void Button4_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            formController.TableQuery_5();
        }
    }
}