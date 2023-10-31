namespace OgawaPortal.Module.Controllers
{
    partial class SalesEditOrderControllers
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
            this.SalesEditOrder = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SalesEditOrder
            // 
            this.SalesEditOrder.AcceptButtonCaption = null;
            this.SalesEditOrder.CancelButtonCaption = null;
            this.SalesEditOrder.Caption = "Edit and Cancel";
            this.SalesEditOrder.Category = "ObjectsCreation";
            this.SalesEditOrder.ConfirmationMessage = null;
            this.SalesEditOrder.Id = "SalesEditOrder";
            this.SalesEditOrder.ToolTip = null;
            this.SalesEditOrder.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SalesEditOrder_CustomizePopupWindowParams);
            this.SalesEditOrder.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SalesEditOrder_Execute);
            // 
            // SalesEditOrderControllers
            // 
            this.Actions.Add(this.SalesEditOrder);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SalesEditOrder;
    }
}
