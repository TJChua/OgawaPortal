namespace OgawaPortal.Module.Controllers
{
    partial class TransferPickListControllers
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
            this.AddItemTransferPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.SubmitTransferPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelTransferPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.TransferOutPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // AddItemTransferPickList
            // 
            this.AddItemTransferPickList.AcceptButtonCaption = null;
            this.AddItemTransferPickList.CancelButtonCaption = null;
            this.AddItemTransferPickList.Caption = "Add Item";
            this.AddItemTransferPickList.Category = "ListView";
            this.AddItemTransferPickList.ConfirmationMessage = null;
            this.AddItemTransferPickList.Id = "AddItemTransferPickList";
            this.AddItemTransferPickList.ToolTip = null;
            this.AddItemTransferPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.AddItemTransferPickList_CustomizePopupWindowParams);
            this.AddItemTransferPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.AddItemTransferPickList_Execute);
            // 
            // SubmitTransferPickList
            // 
            this.SubmitTransferPickList.AcceptButtonCaption = null;
            this.SubmitTransferPickList.CancelButtonCaption = null;
            this.SubmitTransferPickList.Caption = "Submit";
            this.SubmitTransferPickList.Category = "ObjectsCreation";
            this.SubmitTransferPickList.ConfirmationMessage = null;
            this.SubmitTransferPickList.Id = "SubmitTransferPickList";
            this.SubmitTransferPickList.ToolTip = null;
            this.SubmitTransferPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitTransferPickList_CustomizePopupWindowParams);
            this.SubmitTransferPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitTransferPickList_Execute);
            // 
            // CancelTransferPickList
            // 
            this.CancelTransferPickList.AcceptButtonCaption = null;
            this.CancelTransferPickList.CancelButtonCaption = null;
            this.CancelTransferPickList.Caption = "Cancel";
            this.CancelTransferPickList.Category = "ObjectsCreation";
            this.CancelTransferPickList.ConfirmationMessage = null;
            this.CancelTransferPickList.Id = "CancelTransferPickList";
            this.CancelTransferPickList.ToolTip = null;
            this.CancelTransferPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelTransferPickList_CustomizePopupWindowParams);
            this.CancelTransferPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelTransferPickList_Execute);
            // 
            // TransferOutPickList
            // 
            this.TransferOutPickList.AcceptButtonCaption = null;
            this.TransferOutPickList.CancelButtonCaption = null;
            this.TransferOutPickList.Caption = "Transfer";
            this.TransferOutPickList.Category = "ObjectsCreation";
            this.TransferOutPickList.ConfirmationMessage = null;
            this.TransferOutPickList.Id = "TransferOutPickList";
            this.TransferOutPickList.ToolTip = null;
            this.TransferOutPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.TransferOutPickList_CustomizePopupWindowParams);
            this.TransferOutPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.TransferOutPickList_Execute);
            // 
            // TransferPickListControllers
            // 
            this.Actions.Add(this.AddItemTransferPickList);
            this.Actions.Add(this.SubmitTransferPickList);
            this.Actions.Add(this.CancelTransferPickList);
            this.Actions.Add(this.TransferOutPickList);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction AddItemTransferPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitTransferPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelTransferPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction TransferOutPickList;
    }
}
