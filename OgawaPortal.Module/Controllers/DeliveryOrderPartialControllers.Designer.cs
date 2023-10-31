namespace OgawaPortal.Module.Controllers
{
    partial class DeliveryOrderPartialControllers
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
            this.SubmitPartialDO = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelPartialDO = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitPartialDO
            // 
            this.SubmitPartialDO.AcceptButtonCaption = null;
            this.SubmitPartialDO.CancelButtonCaption = null;
            this.SubmitPartialDO.Caption = "Submit";
            this.SubmitPartialDO.Category = "ObjectsCreation";
            this.SubmitPartialDO.ConfirmationMessage = null;
            this.SubmitPartialDO.Id = "SubmitPartialDO";
            this.SubmitPartialDO.ToolTip = null;
            this.SubmitPartialDO.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitPartialDO_CustomizePopupWindowParams);
            this.SubmitPartialDO.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitPartialDO_Execute);
            // 
            // CancelPartialDO
            // 
            this.CancelPartialDO.AcceptButtonCaption = null;
            this.CancelPartialDO.CancelButtonCaption = null;
            this.CancelPartialDO.Caption = "Cancel";
            this.CancelPartialDO.Category = "ObjectsCreation";
            this.CancelPartialDO.ConfirmationMessage = null;
            this.CancelPartialDO.Id = "CancelPartialDO";
            this.CancelPartialDO.ToolTip = null;
            this.CancelPartialDO.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelPartialDO_CustomizePopupWindowParams);
            this.CancelPartialDO.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelPartialDO_Execute);
            // 
            // DeliveryOrderPartialControllers
            // 
            this.Actions.Add(this.SubmitPartialDO);
            this.Actions.Add(this.CancelPartialDO);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitPartialDO;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelPartialDO;
    }
}
