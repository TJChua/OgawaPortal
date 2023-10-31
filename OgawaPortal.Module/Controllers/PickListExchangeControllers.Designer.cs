namespace OgawaPortal.Module.Controllers
{
    partial class PickListExchangeControllers
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
            this.SubmitExchangePickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelExchangePickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitExchangePickList
            // 
            this.SubmitExchangePickList.AcceptButtonCaption = null;
            this.SubmitExchangePickList.CancelButtonCaption = null;
            this.SubmitExchangePickList.Caption = "Submit";
            this.SubmitExchangePickList.Category = "ObjectsCreation";
            this.SubmitExchangePickList.ConfirmationMessage = null;
            this.SubmitExchangePickList.Id = "SubmitExchangePickList";
            this.SubmitExchangePickList.ToolTip = null;
            this.SubmitExchangePickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitExchangePickList_CustomizePopupWindowParams);
            this.SubmitExchangePickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitExchangePickList_Execute);
            // 
            // CancelExchangePickList
            // 
            this.CancelExchangePickList.AcceptButtonCaption = null;
            this.CancelExchangePickList.CancelButtonCaption = null;
            this.CancelExchangePickList.Caption = "Cancel";
            this.CancelExchangePickList.Category = "ObjectsCreation";
            this.CancelExchangePickList.ConfirmationMessage = null;
            this.CancelExchangePickList.Id = "CancelExchangePickList";
            this.CancelExchangePickList.ToolTip = null;
            this.CancelExchangePickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelExchangePickList_CustomizePopupWindowParams);
            this.CancelExchangePickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelExchangePickList_Execute);
            // 
            // PickListExchangeControllers
            // 
            this.Actions.Add(this.SubmitExchangePickList);
            this.Actions.Add(this.CancelExchangePickList);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitExchangePickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelExchangePickList;
    }
}
