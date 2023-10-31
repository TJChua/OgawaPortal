namespace OgawaPortal.Module.Controllers
{
    partial class PrintGRNControllers
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
            this.SubmitSalesGRN = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelSalesGRN = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitSalesGRN
            // 
            this.SubmitSalesGRN.AcceptButtonCaption = null;
            this.SubmitSalesGRN.CancelButtonCaption = null;
            this.SubmitSalesGRN.Caption = "Submit";
            this.SubmitSalesGRN.Category = "ObjectsCreation";
            this.SubmitSalesGRN.ConfirmationMessage = null;
            this.SubmitSalesGRN.Id = "SubmitSalesGRN";
            this.SubmitSalesGRN.ToolTip = null;
            this.SubmitSalesGRN.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitSalesGRN_CustomizePopupWindowParams);
            this.SubmitSalesGRN.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitSalesGRN_Execute);
            // 
            // CancelSalesGRN
            // 
            this.CancelSalesGRN.AcceptButtonCaption = null;
            this.CancelSalesGRN.CancelButtonCaption = null;
            this.CancelSalesGRN.Caption = "Cancel";
            this.CancelSalesGRN.Category = "ObjectsCreation";
            this.CancelSalesGRN.ConfirmationMessage = null;
            this.CancelSalesGRN.Id = "CancelSalesGRN";
            this.CancelSalesGRN.ToolTip = null;
            this.CancelSalesGRN.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelSalesGRN_CustomizePopupWindowParams);
            this.CancelSalesGRN.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelSalesGRN_Execute);
            // 
            // PrintGRNControllers
            // 
            this.Actions.Add(this.SubmitSalesGRN);
            this.Actions.Add(this.CancelSalesGRN);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitSalesGRN;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelSalesGRN;
    }
}
