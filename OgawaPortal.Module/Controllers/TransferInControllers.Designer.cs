namespace OgawaPortal.Module.Controllers
{
    partial class TransferInControllers
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
            this.SubmitTransferIn = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitTransferIn
            // 
            this.SubmitTransferIn.AcceptButtonCaption = null;
            this.SubmitTransferIn.CancelButtonCaption = null;
            this.SubmitTransferIn.Caption = "Submit";
            this.SubmitTransferIn.Category = "ObjectsCreation";
            this.SubmitTransferIn.ConfirmationMessage = null;
            this.SubmitTransferIn.Id = "SubmitTransferIn";
            this.SubmitTransferIn.ToolTip = null;
            this.SubmitTransferIn.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitTransferIn_CustomizePopupWindowParams);
            this.SubmitTransferIn.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitTransferIn_Execute);
            // 
            // TransferInControllers
            // 
            this.Actions.Add(this.SubmitTransferIn);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitTransferIn;
    }
}
