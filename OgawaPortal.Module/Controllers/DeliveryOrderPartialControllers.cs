using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using OgawaPortal.Module.BusinessObjects;
using OgawaPortal.Module.BusinessObjects.Nonpersistent;
using OgawaPortal.Module.BusinessObjects.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DeliveryOrderPartialControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public DeliveryOrderPartialControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(DeliveryOrderPartial);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            if (View.Id == "DeliveryOrderPartial_DetailView")
            {
                //this.BackToInquiry.Active.SetItemValue("Enabled", true);
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.SubmitPartialDO.Active.SetItemValue("Enabled", true);
                    this.CancelPartialDO.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SubmitPartialDO.Active.SetItemValue("Enabled", false);
                    this.CancelPartialDO.Active.SetItemValue("Enabled", false);
                }
            }
            else
            {
                this.SubmitPartialDO.Active.SetItemValue("Enabled", false);
                this.CancelPartialDO.Active.SetItemValue("Enabled", false);
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        public void showMsg(string caption, string msg, InformationType msgtype)
        {
            MessageOptions options = new MessageOptions();
            options.Duration = 3000;
            options.Message = string.Format("{0}", msg);
            options.Type = msgtype;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = caption;
            options.Win.Type = WinMessageType.Flyout;
            Application.ShowViewStrategy.ShowMessage(options);
        }

        public void openNewView(IObjectSpace os, object target, ViewEditMode viewmode)
        {
            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, target);
            dv.ViewEditMode = viewmode;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
        }

        private void SubmitPartialDO_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            DeliveryOrderPartial selectedObject = (DeliveryOrderPartial)e.CurrentObject;

            if (selectedObject.Transporter != null)
            {
                selectedObject.Status = Status.Submit;

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();

                IObjectSpace os = Application.CreateObjectSpace();
                DeliveryOrderPartial partial = os.FindObject<DeliveryOrderPartial>(new BinaryOperator("Oid", selectedObject.Oid));
                openNewView(os, partial, ViewEditMode.View);
                showMsg("Successful", "Document Submitted.", InformationType.Success);
            }
            else
            {
                showMsg("Error", "Please fill in transporter.", InformationType.Error);
            }
        }

        private void SubmitPartialDO_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CancelPartialDO_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            DeliveryOrderPartial selectedObject = (DeliveryOrderPartial)e.CurrentObject;

            if (selectedObject.Transporter != null)
            {
                selectedObject.Status = Status.Cancel;

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();

                IObjectSpace os = Application.CreateObjectSpace();
                DeliveryOrderPartial partial = os.FindObject<DeliveryOrderPartial>(new BinaryOperator("Oid", selectedObject.Oid));
                openNewView(os, partial, ViewEditMode.View);
                showMsg("Successful", "Document Cancelled.", InformationType.Success);
            }
            else
            {
                showMsg("Error", "Please fill in transporter.", InformationType.Error);
            }
        }

        private void CancelPartialDO_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
