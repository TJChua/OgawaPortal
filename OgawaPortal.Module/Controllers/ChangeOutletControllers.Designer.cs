namespace OgawaPortal.Module.Controllers
{
    partial class ChangeOutletControllers
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
            this.ChangeOutlet = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ChangeOutlet
            // 
            this.ChangeOutlet.AcceptButtonCaption = null;
            this.ChangeOutlet.CancelButtonCaption = null;
            this.ChangeOutlet.Caption = "Change";
            this.ChangeOutlet.Category = "ListView";
            this.ChangeOutlet.ConfirmationMessage = null;
            this.ChangeOutlet.Id = "ChangeOutlet";
            this.ChangeOutlet.ToolTip = null;
            this.ChangeOutlet.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ChangeOutlet_CustomizePopupWindowParams);
            this.ChangeOutlet.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ChangeOutlet_Execute);
            // 
            // ChangeOutletControllers
            // 
            this.Actions.Add(this.ChangeOutlet);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ChangeOutlet;
    }
}
