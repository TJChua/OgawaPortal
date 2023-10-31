namespace OgawaPortal.Module.Controllers
{
    partial class SalesExchangeOutControllers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SubmitSalesExchangeOut = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelSalesExchangeOut = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitSalesExchangeOut
            // 
            this.SubmitSalesExchangeOut.AcceptButtonCaption = null;
            this.SubmitSalesExchangeOut.CancelButtonCaption = null;
            this.SubmitSalesExchangeOut.Caption = "Submit";
            this.SubmitSalesExchangeOut.Category = "ObjectsCreation";
            this.SubmitSalesExchangeOut.ConfirmationMessage = null;
            this.SubmitSalesExchangeOut.Id = "SubmitSalesExchangeOut";
            this.SubmitSalesExchangeOut.ToolTip = null;
            this.SubmitSalesExchangeOut.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitSalesExchangeOut_CustomizePopupWindowParams);
            this.SubmitSalesExchangeOut.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitSalesExchangeOut_Execute);
            // 
            // CancelSalesExchangeOut
            // 
            this.CancelSalesExchangeOut.AcceptButtonCaption = null;
            this.CancelSalesExchangeOut.CancelButtonCaption = null;
            this.CancelSalesExchangeOut.Caption = "Cancel";
            this.CancelSalesExchangeOut.Category = "ObjectsCreation";
            this.CancelSalesExchangeOut.ConfirmationMessage = null;
            this.CancelSalesExchangeOut.Id = "CancelSalesExchangeOut";
            this.CancelSalesExchangeOut.ToolTip = null;
            this.CancelSalesExchangeOut.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelSalesExchangeOut_CustomizePopupWindowParams);
            this.CancelSalesExchangeOut.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelSalesExchangeOut_Execute);
            // 
            // SalesExchangeOutControllers
            // 
            this.Actions.Add(this.SubmitSalesExchangeOut);
            this.Actions.Add(this.CancelSalesExchangeOut);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitSalesExchangeOut;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelSalesExchangeOut;
    }
}
