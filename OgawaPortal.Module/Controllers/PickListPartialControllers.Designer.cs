namespace OgawaPortal.Module.Controllers
{
    partial class PickListPartialControllers
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
            this.SubmitPartialPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelPartialPickList = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.WarehousePartial = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitPartialPickList
            // 
            this.SubmitPartialPickList.AcceptButtonCaption = null;
            this.SubmitPartialPickList.CancelButtonCaption = null;
            this.SubmitPartialPickList.Caption = "Submit";
            this.SubmitPartialPickList.Category = "ObjectsCreation";
            this.SubmitPartialPickList.ConfirmationMessage = null;
            this.SubmitPartialPickList.Id = "SubmitPartialPickList";
            this.SubmitPartialPickList.ToolTip = null;
            this.SubmitPartialPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitPartialPickList_CustomizePopupWindowParams);
            this.SubmitPartialPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitPartialPickList_Execute);
            // 
            // CancelPartialPickList
            // 
            this.CancelPartialPickList.AcceptButtonCaption = null;
            this.CancelPartialPickList.CancelButtonCaption = null;
            this.CancelPartialPickList.Caption = "Cancel";
            this.CancelPartialPickList.Category = "ObjectsCreation";
            this.CancelPartialPickList.ConfirmationMessage = null;
            this.CancelPartialPickList.Id = "CancelPartialPickList";
            this.CancelPartialPickList.ToolTip = null;
            this.CancelPartialPickList.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelPartialPickList_CustomizePopupWindowParams);
            this.CancelPartialPickList.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelPartialPickList_Execute);
            // 
            // WarehousePartial
            // 
            this.WarehousePartial.AcceptButtonCaption = null;
            this.WarehousePartial.CancelButtonCaption = null;
            this.WarehousePartial.Caption = "Delivery";
            this.WarehousePartial.Category = "ObjectsCreation";
            this.WarehousePartial.ConfirmationMessage = null;
            this.WarehousePartial.Id = "WarehousePartial";
            this.WarehousePartial.ToolTip = null;
            this.WarehousePartial.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.WarehousePartial_CustomizePopupWindowParams);
            this.WarehousePartial.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.WarehousePartial_Execute);
            // 
            // PickListPartialControllers
            // 
            this.Actions.Add(this.SubmitPartialPickList);
            this.Actions.Add(this.CancelPartialPickList);
            this.Actions.Add(this.WarehousePartial);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitPartialPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelPartialPickList;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction WarehousePartial;
    }
}
