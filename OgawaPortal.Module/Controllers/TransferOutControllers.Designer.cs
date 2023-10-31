namespace OgawaPortal.Module.Controllers
{
    partial class TransferOutControllers
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
            this.AddItemTransfer = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.SubmitTransfer = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelTransfer = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.ReceiveTransfer = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // AddItemTransfer
            // 
            this.AddItemTransfer.AcceptButtonCaption = null;
            this.AddItemTransfer.CancelButtonCaption = null;
            this.AddItemTransfer.Caption = "Add Item";
            this.AddItemTransfer.Category = "Menu";
            this.AddItemTransfer.ConfirmationMessage = null;
            this.AddItemTransfer.Id = "AddItemTransfer";
            this.AddItemTransfer.ToolTip = null;
            this.AddItemTransfer.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.AddItemTransfer_CustomizePopupWindowParams);
            this.AddItemTransfer.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.AddItemTransfer_Execute);
            // 
            // SubmitTransfer
            // 
            this.SubmitTransfer.AcceptButtonCaption = null;
            this.SubmitTransfer.CancelButtonCaption = null;
            this.SubmitTransfer.Caption = "Submit";
            this.SubmitTransfer.Category = "ObjectsCreation";
            this.SubmitTransfer.ConfirmationMessage = null;
            this.SubmitTransfer.Id = "SubmitTransfer";
            this.SubmitTransfer.ToolTip = null;
            this.SubmitTransfer.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitTransfer_CustomizePopupWindowParams);
            this.SubmitTransfer.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitTransfer_Execute);
            // 
            // CancelTransfer
            // 
            this.CancelTransfer.AcceptButtonCaption = null;
            this.CancelTransfer.CancelButtonCaption = null;
            this.CancelTransfer.Caption = "Cancel";
            this.CancelTransfer.Category = "ObjectsCreation";
            this.CancelTransfer.ConfirmationMessage = null;
            this.CancelTransfer.Id = "CancelTransfer";
            this.CancelTransfer.ToolTip = null;
            this.CancelTransfer.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelTransfer_CustomizePopupWindowParams);
            this.CancelTransfer.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelTransfer_Execute);
            // 
            // ReceiveTransfer
            // 
            this.ReceiveTransfer.AcceptButtonCaption = null;
            this.ReceiveTransfer.CancelButtonCaption = null;
            this.ReceiveTransfer.Caption = "Receive";
            this.ReceiveTransfer.Category = "ObjectsCreation";
            this.ReceiveTransfer.ConfirmationMessage = null;
            this.ReceiveTransfer.Id = "ReceiveTransfer";
            this.ReceiveTransfer.ToolTip = null;
            this.ReceiveTransfer.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ReceiveTransfer_CustomizePopupWindowParams);
            this.ReceiveTransfer.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ReceiveTransfer_Execute);
            // 
            // TransferOutControllers
            // 
            this.Actions.Add(this.AddItemTransfer);
            this.Actions.Add(this.SubmitTransfer);
            this.Actions.Add(this.CancelTransfer);
            this.Actions.Add(this.ReceiveTransfer);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction AddItemTransfer;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitTransfer;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelTransfer;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ReceiveTransfer;
    }
}
