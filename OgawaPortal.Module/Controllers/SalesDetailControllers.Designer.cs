namespace OgawaPortal.Module.Controllers
{
    partial class SalesDetailControllers
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
            this.DeleteDetailItem = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // DeleteDetailItem
            // 
            this.DeleteDetailItem.AcceptButtonCaption = null;
            this.DeleteDetailItem.CancelButtonCaption = null;
            this.DeleteDetailItem.Caption = "Delete Item";
            this.DeleteDetailItem.Category = "ObjectsCreation";
            this.DeleteDetailItem.ConfirmationMessage = null;
            this.DeleteDetailItem.Id = "DeleteDetailItem";
            this.DeleteDetailItem.ToolTip = null;
            this.DeleteDetailItem.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.DeleteDetailItem_CustomizePopupWindowParams);
            this.DeleteDetailItem.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.DeleteDetailItem_Execute);
            // 
            // SalesDetailControllers
            // 
            this.Actions.Add(this.DeleteDetailItem);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction DeleteDetailItem;
    }
}
