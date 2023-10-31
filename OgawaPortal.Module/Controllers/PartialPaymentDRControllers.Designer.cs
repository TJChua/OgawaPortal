namespace OgawaPortal.Module.Controllers
{
    partial class PartialPaymentDRControllers
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
            this.SubmitPartialPayment = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelPartialPayment = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitPartialPayment
            // 
            this.SubmitPartialPayment.AcceptButtonCaption = null;
            this.SubmitPartialPayment.CancelButtonCaption = null;
            this.SubmitPartialPayment.Caption = "Submit";
            this.SubmitPartialPayment.Category = "ObjectsCreation";
            this.SubmitPartialPayment.ConfirmationMessage = null;
            this.SubmitPartialPayment.Id = "SubmitPartialPayment";
            this.SubmitPartialPayment.ToolTip = null;
            this.SubmitPartialPayment.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitPartialPayment_CustomizePopupWindowParams);
            this.SubmitPartialPayment.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitPartialPayment_Execute);
            // 
            // CancelPartialPayment
            // 
            this.CancelPartialPayment.AcceptButtonCaption = null;
            this.CancelPartialPayment.CancelButtonCaption = null;
            this.CancelPartialPayment.Caption = "Cancel";
            this.CancelPartialPayment.Category = "ObjectsCreation";
            this.CancelPartialPayment.ConfirmationMessage = null;
            this.CancelPartialPayment.Id = "CancelPartialPayment";
            this.CancelPartialPayment.ToolTip = null;
            this.CancelPartialPayment.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelPartialPayment_CustomizePopupWindowParams);
            this.CancelPartialPayment.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelPartialPayment_Execute);
            // 
            // PartialPaymentDRControllers
            // 
            this.Actions.Add(this.SubmitPartialPayment);
            this.Actions.Add(this.CancelPartialPayment);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitPartialPayment;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelPartialPayment;
    }
}
