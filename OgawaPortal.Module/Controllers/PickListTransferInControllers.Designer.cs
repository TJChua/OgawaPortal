namespace OgawaPortal.Module.Controllers
{
    partial class PickListTransferInControllers
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
            this.SubmitPickListTransferIn = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitPickListTransferIn
            // 
            this.SubmitPickListTransferIn.AcceptButtonCaption = null;
            this.SubmitPickListTransferIn.CancelButtonCaption = null;
            this.SubmitPickListTransferIn.Caption = "Submit";
            this.SubmitPickListTransferIn.Category = "ObjectsCreation";
            this.SubmitPickListTransferIn.ConfirmationMessage = null;
            this.SubmitPickListTransferIn.Id = "SubmitPickListTransferIn";
            this.SubmitPickListTransferIn.ToolTip = null;
            this.SubmitPickListTransferIn.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitPickListTransferIn_CustomizePopupWindowParams);
            this.SubmitPickListTransferIn.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitPickListTransferIn_Execute);
            // 
            // PickListTransferInControllers
            // 
            this.Actions.Add(this.SubmitPickListTransferIn);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitPickListTransferIn;
    }
}
