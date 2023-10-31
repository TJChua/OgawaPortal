using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.DB;
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
    public partial class TransferPickListControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public TransferPickListControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(TransferPickList);
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

        private void AddItemTransferPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            TransferPickList selectedObject = (TransferPickList)e.CurrentObject;
            DetailView detailView = (DetailView)e.PopupWindowView;
            ItemListTransfer p = (ItemListTransfer)e.PopupWindow.View.CurrentObject;
            ListPropertyEditor listPropertyEditor = detailView.FindItem("items") as ListPropertyEditor;

            foreach (ItemCodesTransfer dtl in listPropertyEditor.ListView.SelectedObjects)
            {
                TransferPickListDetails newdetails = ObjectSpace.CreateObject<TransferPickListDetails>();
                newdetails.Class = dtl.Class;
                newdetails.ItemCode = dtl.ItemCode;
                newdetails.ItemName = dtl.ItemName;
                newdetails.New = dtl.NewOrDemo;
                newdetails.Quantity = p.Order;
                selectedObject.DetailsBO.Add(newdetails);
            }

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
        }

        private void AddItemTransferPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            TransferPickList transfer = (TransferPickList)View.CurrentObject;
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ItemCodesTransfer));

            XPObjectSpace persistentObjectSpace = (XPObjectSpace)Application.CreateObjectSpace();
            SelectedData sprocData = persistentObjectSpace.Session.ExecuteSproc("sp_GetItem", new OperandValue(transfer.TransferFrom.WhsCode),
                new OperandValue("TransferOut"));

            var nonPersistentOS = Application.CreateObjectSpace(typeof(ItemListTransfer));
            ItemListTransfer itemlist = nonPersistentOS.CreateObject<ItemListTransfer>();
            int i = 1;

            if (sprocData.ResultSet.Count() > 0)
            {
                if (sprocData.ResultSet[0].Rows.Count() > 0)
                {
                    foreach (SelectStatementResultRow row in sprocData.ResultSet[0].Rows)
                    {
                        var itemos = Application.CreateObjectSpace(typeof(ItemCodesTransfer));
                        var item = itemos.CreateObject<ItemCodesTransfer>();
                        item.Id = i;
                        item.Class = row.Values[0].ToString();
                        item.ItemCode = row.Values[1].ToString();
                        item.ItemName = row.Values[2].ToString();
                        item.NewOrDemo = row.Values[3].ToString();
                        item.OnHand = (decimal)row.Values[7];
                        itemlist.items.Add(item);

                        i++;
                    }
                }
            }

            nonPersistentOS.CommitChanges();

            DetailView detailView = Application.CreateDetailView(nonPersistentOS, itemlist);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((ItemListTransfer)detailView.CurrentObject).Order = 1;
            e.View = detailView;
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = false;
        }

        private void SubmitTransferPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            TransferPickList selectedObject = (TransferPickList)e.CurrentObject;

            selectedObject.Status = Status.TransferOpen;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            TransferPickList transfer = os.FindObject<TransferPickList>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, transfer, ViewEditMode.View);
            showMsg("Successful", "Document Submitted.", InformationType.Success);
        }

        private void SubmitTransferPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CancelTransferPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            TransferPickList selectedObject = (TransferPickList)e.CurrentObject;

            selectedObject.Status = Status.Cancel;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            TransferPickList transfer = os.FindObject<TransferPickList>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, transfer, ViewEditMode.View);
            showMsg("Successful", "Document Cancelled.", InformationType.Success);
        }

        private void CancelTransferPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void TransferOutPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            TransferPickList selectedObject = (TransferPickList)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PickListTransferOut transferout = os.CreateObject<PickListTransferOut>();

            transferout.TransferDate = selectedObject.TransferDate;
            transferout.TransferFrom = transferout.Session.GetObjectByKey<vwWarehouse>(selectedObject.TransferFrom.WhsCode);
            transferout.TransferTo = transferout.Session.GetObjectByKey<vwWarehouse>(selectedObject.TransferTo.WhsCode);
            transferout.TranferRefNo = selectedObject.TranferRefNo;
            transferout.Status = Status.TransferOpen;
            transferout.BaseNum = selectedObject.DocNum;

            foreach (TransferPickListDetails dtl in selectedObject.DetailsBO)
            {
                PickListTransferOutDetails transferoutitem = os.CreateObject<PickListTransferOutDetails>();
                transferoutitem.Class = dtl.Class;
                transferoutitem.ItemCode = dtl.ItemCode;
                transferoutitem.ItemName = dtl.ItemName;
                transferoutitem.New = dtl.New;
                transferoutitem.Quantity = dtl.Quantity;
                transferout.DetailsBO.Add(transferoutitem);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, transferout);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Transfer Out document created.", InformationType.Success);
        }

        private void TransferOutPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
