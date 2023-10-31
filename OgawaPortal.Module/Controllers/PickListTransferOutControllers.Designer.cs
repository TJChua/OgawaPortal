namespace OgawaPortal.Module.Controllers
{
    partial class PickListTransferOutControllers
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
            this.SubmitPickListTransferOut = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelPickListTransferOut = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.TransferInPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitPickListTransferOut
            // 
            this.SubmitPickListTransferOut.AcceptButtonCaption = null;
            this.SubmitPickListTransferOut.CancelButtonCaption = null;
            this.SubmitPickListTransferOut.Caption = "Submit";
            this.SubmitPickListTransferOut.Category = "ObjectsCreation";
            this.SubmitPickListTransferOut.ConfirmationMessage = null;
            this.SubmitPickListTransferOut.Id = "SubmitPickListTransferOut";
            this.SubmitPickListTransferOut.ToolTip = null;
            this.SubmitPickListTransferOut.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitPickListTransferOut_CustomizePopupWindowParams);
            this.SubmitPickListTransferOut.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitPickListTransferOut_Execute);
            // 
            // CancelPickListTransferOut
            // 
            this.CancelPickListTransferOut.AcceptButtonCaption = null;
            this.CancelPickListTransferOut.CancelButtonCaption = null;
            this.CancelPickListTransferOut.Caption = "Cancel";
            this.CancelPickListTransferOut.Category = "ObjectsCreation";
            this.CancelPickListTransferOut.ConfirmationMessage = null;
            this.CancelPickListTransferOut.Id = "CancelPickListTransferOut";
            this.CancelPickListTransferOut.ToolTip = null;
            this.CancelPickListTransferOut.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelPickListTransferOut_CustomizePopupWindowParams);
            this.CancelPickListTransferOut.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelPickListTransferOut_Execute);
            // 
            // TransferInPickList
            // 
            this.TransferInPickList.AcceptButtonCaption = null;
            this.TransferInPickList.CancelButtonCaption = null;
            this.TransferInPickList.Caption = "Transfer";
            this.TransferInPickList.Category = "ObjectsCreation";
            this.TransferInPickList.ConfirmationMessage = null;
            this.TransferInPickList.Id = "TransferInPickList";
            this.TransferInPickList.ToolTip = null;
            this.TransferInPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.TransferInPickList_CustomizePopupWindowParams);
            this.TransferInPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.TransferInPickList_Execute);
            // 
            // PickListTransferOutControllers
            // 
            this.Actions.Add(this.SubmitPickListTransferOut);
            this.Actions.Add(this.CancelPickListTransferOut);
            this.Actions.Add(this.TransferInPickList);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitPickListTransferOut;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelPickListTransferOut;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction TransferInPickList;
    }
}
