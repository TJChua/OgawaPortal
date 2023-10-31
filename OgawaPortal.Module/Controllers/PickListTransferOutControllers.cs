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
using OgawaPortal.Module.BusinessObjects.View;
using OgawaPortal.Module.BusinessObjects.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PickListTransferOutControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public PickListTransferOutControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(PickListTransferOut);
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

        private void SubmitPickListTransferOut_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListTransferOut selectedObject = (PickListTransferOut)e.CurrentObject;

            selectedObject.Status = Status.Released;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            if (selectedObject.BaseNum != null)
            {
                IObjectSpace uos = Application.CreateObjectSpace();
                TransferPickList updstatus = uos.FindObject<TransferPickList>(new BinaryOperator("DocNum", selectedObject.BaseNum));

                if (updstatus != null)
                {
                    updstatus.Status = Status.Closed;
                    uos.CommitChanges();
                }
            }

            IObjectSpace os = Application.CreateObjectSpace();
            PickListTransferOut transfer = os.FindObject<PickListTransferOut>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, transfer, ViewEditMode.View);
            showMsg("Successful", "Document Submitted.", InformationType.Success);
        }

        private void SubmitPickListTransferOut_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CancelPickListTransferOut_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListTransferOut selectedObject = (PickListTransferOut)e.CurrentObject;

            selectedObject.Status = Status.Cancel;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            PickListTransferOut transfer = os.FindObject<PickListTransferOut>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, transfer, ViewEditMode.View);
            showMsg("Successful", "Document Cancelled.", InformationType.Success);
        }

        private void CancelPickListTransferOut_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void TransferInPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListTransferOut selectedObject = (PickListTransferOut)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PickListTransferIn transferin = os.CreateObject<PickListTransferIn>();

            transferin.TransferDate = selectedObject.TransferDate;
            transferin.TransferFrom = transferin.Session.GetObjectByKey<vwWarehouse>(selectedObject.TransferFrom.WhsCode);
            transferin.TransferTo = transferin.Session.GetObjectByKey<vwWarehouse>(selectedObject.TransferTo.WhsCode);
            transferin.TranferRefNo = selectedObject.TranferRefNo;
            transferin.ReceiveDate = DateTime.Now;
            transferin.Status = selectedObject.Status;
            transferin.BaseNum = selectedObject.DocNum;

            foreach (PickListTransferOutDetails dtl in selectedObject.DetailsBO)
            {
                PickListTransferInDetails transferoutitem = os.CreateObject<PickListTransferInDetails>();
                transferoutitem.Class = dtl.Class;
                transferoutitem.ItemCode = dtl.ItemCode;
                transferoutitem.ItemName = dtl.ItemName;
                transferoutitem.New = dtl.New;
                transferoutitem.Quantity = dtl.Quantity;
                transferin.DetailsBO.Add(transferoutitem);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, transferin);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Transfer In document created.", InformationType.Success);
        }

        private void TransferInPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
