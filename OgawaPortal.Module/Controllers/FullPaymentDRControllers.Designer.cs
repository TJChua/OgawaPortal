namespace OgawaPortal.Module.Controllers
{
    partial class FullPaymentDRControllers
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
            this.SubmitFullPayment = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelFullPayment = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitFullPayment
            // 
            this.SubmitFullPayment.AcceptButtonCaption = null;
            this.SubmitFullPayment.CancelButtonCaption = null;
            this.SubmitFullPayment.Caption = "Submit";
            this.SubmitFullPayment.Category = "ObjectsCreation";
            this.SubmitFullPayment.ConfirmationMessage = null;
            this.SubmitFullPayment.Id = "SubmitFullPayment";
            this.SubmitFullPayment.ToolTip = null;
            this.SubmitFullPayment.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitFullPayment_CustomizePopupWindowParams);
            this.SubmitFullPayment.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitFullPayment_Execute);
            // 
            // CancelFullPayment
            // 
            this.CancelFullPayment.AcceptButtonCaption = null;
            this.CancelFullPayment.CancelButtonCaption = null;
            this.CancelFullPayment.Caption = "Cancel";
            this.CancelFullPayment.Category = "ObjectsCreation";
            this.CancelFullPayment.ConfirmationMessage = null;
            this.CancelFullPayment.Id = "CancelFullPayment";
            this.CancelFullPayment.ToolTip = null;
            this.CancelFullPayment.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelFullPayment_CustomizePopupWindowParams);
            this.CancelFullPayment.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelFullPayment_Execute);
            // 
            // FullPaymentDRControllers
            // 
            this.Actions.Add(this.SubmitFullPayment);
            this.Actions.Add(this.CancelFullPayment);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitFullPayment;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelFullPayment;
    }
}
