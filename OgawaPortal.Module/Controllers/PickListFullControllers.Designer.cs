namespace OgawaPortal.Module.Controllers
{
    partial class PickListFullControllers
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
            this.SubmitFullPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelFullPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.WarehouseFull = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitFullPickList
            // 
            this.SubmitFullPickList.AcceptButtonCaption = null;
            this.SubmitFullPickList.CancelButtonCaption = null;
            this.SubmitFullPickList.Caption = "Submit";
            this.SubmitFullPickList.Category = "ObjectsCreation";
            this.SubmitFullPickList.ConfirmationMessage = null;
            this.SubmitFullPickList.Id = "SubmitFullPickList";
            this.SubmitFullPickList.ToolTip = null;
            this.SubmitFullPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitFullPickList_CustomizePopupWindowParams);
            this.SubmitFullPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitFullPickList_Execute);
            // 
            // CancelFullPickList
            // 
            this.CancelFullPickList.AcceptButtonCaption = null;
            this.CancelFullPickList.CancelButtonCaption = null;
            this.CancelFullPickList.Caption = "Cancel";
            this.CancelFullPickList.Category = "ObjectsCreation";
            this.CancelFullPickList.ConfirmationMessage = null;
            this.CancelFullPickList.Id = "CancelFullPickList";
            this.CancelFullPickList.ToolTip = null;
            this.CancelFullPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelFullPickList_CustomizePopupWindowParams);
            this.CancelFullPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelFullPickList_Execute);
            // 
            // WarehouseFull
            // 
            this.WarehouseFull.AcceptButtonCaption = null;
            this.WarehouseFull.CancelButtonCaption = null;
            this.WarehouseFull.Caption = "Delivery";
            this.WarehouseFull.Category = "ObjectsCreation";
            this.WarehouseFull.ConfirmationMessage = null;
            this.WarehouseFull.Id = "WarehouseFull";
            this.WarehouseFull.ToolTip = null;
            this.WarehouseFull.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.WarehouseFull_CustomizePopupWindowParams);
            this.WarehouseFull.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.WarehouseFull_Execute);
            // 
            // PickListFullControllers
            // 
            this.Actions.Add(this.SubmitFullPickList);
            this.Actions.Add(this.CancelFullPickList);
            this.Actions.Add(this.WarehouseFull);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitFullPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelFullPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction WarehouseFull;
    }
}
