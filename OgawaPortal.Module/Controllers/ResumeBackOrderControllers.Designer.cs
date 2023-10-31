namespace OgawaPortal.Module.Controllers
{
    partial class ResumeBackOrderControllers
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
            this.ResumeOrder = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // ResumeOrder
            // 
            this.ResumeOrder.AcceptButtonCaption = null;
            this.ResumeOrder.CancelButtonCaption = null;
            this.ResumeOrder.Caption = "Resume";
            this.ResumeOrder.Category = "ObjectsCreation";
            this.ResumeOrder.ConfirmationMessage = null;
            this.ResumeOrder.Id = "ResumeOrder";
            this.ResumeOrder.ToolTip = null;
            this.ResumeOrder.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.ResumeOrder_CustomizePopupWindowParams);
            this.ResumeOrder.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.ResumeOrder_Execute);
            // 
            // ResumeBackOrderControllers
            // 
            this.Actions.Add(this.ResumeOrder);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction ResumeOrder;
    }
}
