namespace OgawaPortal.Module.Controllers
{
    partial class ExchangeDRControllers
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
            this.SubmitExchangeDR = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelExchangeDR = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitExchangeDR
            // 
            this.SubmitExchangeDR.AcceptButtonCaption = null;
            this.SubmitExchangeDR.CancelButtonCaption = null;
            this.SubmitExchangeDR.Caption = "Submit";
            this.SubmitExchangeDR.Category = "ObjectsCreation";
            this.SubmitExchangeDR.ConfirmationMessage = null;
            this.SubmitExchangeDR.Id = "SubmitExchangeDR";
            this.SubmitExchangeDR.ToolTip = null;
            this.SubmitExchangeDR.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitExchangeDR_CustomizePopupWindowParams);
            this.SubmitExchangeDR.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitExchangeDR_Execute);
            // 
            // CancelExchangeDR
            // 
            this.CancelExchangeDR.AcceptButtonCaption = null;
            this.CancelExchangeDR.CancelButtonCaption = null;
            this.CancelExchangeDR.Caption = "Cancel";
            this.CancelExchangeDR.ConfirmationMessage = null;
            this.CancelExchangeDR.Id = "CancelExchangeDR";
            this.CancelExchangeDR.ToolTip = null;
            this.CancelExchangeDR.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelExchangeDR_CustomizePopupWindowParams);
            this.CancelExchangeDR.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelExchangeDR_Execute);
            // 
            // ExchangeDRControllers
            // 
            this.Actions.Add(this.SubmitExchangeDR);
            this.Actions.Add(this.CancelExchangeDR);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitExchangeDR;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelExchangeDR;
    }
}
