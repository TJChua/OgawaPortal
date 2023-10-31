namespace OgawaPortal.Module.Controllers
{
    partial class DeliveryOrderFullControllers
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
            this.SubmitFullDO = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.CancelFullDO = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // SubmitFullDO
            // 
            this.SubmitFullDO.AcceptButtonCaption = null;
            this.SubmitFullDO.CancelButtonCaption = null;
            this.SubmitFullDO.Caption = "Submit";
            this.SubmitFullDO.Category = "ObjectsCreation";
            this.SubmitFullDO.ConfirmationMessage = null;
            this.SubmitFullDO.Id = "SubmitFullDO";
            this.SubmitFullDO.ToolTip = null;
            this.SubmitFullDO.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.SubmitFullDO_CustomizePopupWindowParams);
            this.SubmitFullDO.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.SubmitFullDO_Execute);
            // 
            // CancelFullDO
            // 
            this.CancelFullDO.AcceptButtonCaption = null;
            this.CancelFullDO.CancelButtonCaption = null;
            this.CancelFullDO.Caption = "Cancel";
            this.CancelFullDO.Category = "ObjectsCreation";
            this.CancelFullDO.ConfirmationMessage = null;
            this.CancelFullDO.Id = "CancelFullDO";
            this.CancelFullDO.ToolTip = null;
            this.CancelFullDO.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.CancelFullDO_CustomizePopupWindowParams);
            this.CancelFullDO.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.CancelFullDO_Execute);
            // 
            // DeliveryOrderFullControllers
            // 
            this.Actions.Add(this.SubmitFullDO);
            this.Actions.Add(this.CancelFullDO);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction SubmitFullDO;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction CancelFullDO;
    }
}
