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
using OgawaPortal.Module.BusinessObjects.Logistic;
using OgawaPortal.Module.BusinessObjects.Maintenances;
using OgawaPortal.Module.BusinessObjects.Nonpersistent;
using OgawaPortal.Module.BusinessObjects.POS___Logistic;
using OgawaPortal.Module.BusinessObjects.View;
using OgawaPortal.Module.BusinessObjects.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PickListFullControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public PickListFullControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(PickListFullPayment);
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

        private void SubmitFullPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListFullPayment selectedObject = (PickListFullPayment)e.CurrentObject;

            selectedObject.Status = Status.Submit;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            PickListFullPayment full = os.FindObject<PickListFullPayment>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, full, ViewEditMode.View);
            showMsg("Successful", "Document Submitted.", InformationType.Success);
        }

        private void SubmitFullPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CancelFullPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListFullPayment selectedObject = (PickListFullPayment)e.CurrentObject;

            selectedObject.Status = Status.Cancel;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            PickListFullPayment full = os.FindObject<PickListFullPayment>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, full, ViewEditMode.View);
            showMsg("Successful", "Document Cancelled.", InformationType.Success);
        }

        private void CancelFullPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void WarehouseFull_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListFullPayment selectedObject = (PickListFullPayment)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            DeliveryOrderFull deliveryfull = os.CreateObject<DeliveryOrderFull>();

            deliveryfull.PickListCreateDate = DateTime.Now;
            deliveryfull.DeliveryDate = DateTime.Now;
            deliveryfull.DeliveryTime = new TimeSpan(deliveryfull.DeliveryDate.Hour, deliveryfull.DeliveryDate.Minute, deliveryfull.DeliveryDate.Second);
            deliveryfull.SalesOrderNo = selectedObject.SalesOrderNo;
            deliveryfull.SORefNo = selectedObject.SORefNo;
            deliveryfull.DRRefNo = selectedObject.DRRefNo;
            deliveryfull.PLRefNo = selectedObject.PLRefNo;
            if (selectedObject.Warehouse != null)
            {
                deliveryfull.Warehouse = deliveryfull.Session.GetObjectByKey<vwWarehouse>(selectedObject.Warehouse.WhsCode);
            }

            if (selectedObject.DeliveryContact != null)
            {
                deliveryfull.DeliveryContact = deliveryfull.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            deliveryfull.DeliveryAddress2 = selectedObject?.DeliveryAddress2;
            deliveryfull.DeliveryCity = selectedObject.DeliveryCity;
            deliveryfull.DeliveryDistrict = selectedObject.DeliveryDistrict;
            deliveryfull.DeliveryPostCode = selectedObject.DeliveryPostCode;
            deliveryfull.DeliveryCountry = selectedObject.DeliveryCountry;
            deliveryfull.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            deliveryfull.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            deliveryfull.DeliveryRace = selectedObject.DeliveryRace;

            IObjectSpace fos = Application.CreateObjectSpace();
            FullPaymentDeliveryReq fullpayment = fos.FindObject<FullPaymentDeliveryReq>(new BinaryOperator("BaseNum", selectedObject.SalesOrderNo));
            if (fullpayment != null)
            {
                deliveryfull.RequestNo = fullpayment.DocNum;
            }

            foreach (PickListFullPaymentDetails dtl in selectedObject.DetailsBO)
            {
                DeliveryOrderFullDetails itemlist = os.CreateObject<DeliveryOrderFullDetails>();
                itemlist.Class = dtl.Class;
                itemlist.ItemCode = itemlist.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                itemlist.ItemName = dtl.ItemName;
                itemlist.Ship = dtl.ToShip;
                deliveryfull.DetailsBO.Add(itemlist);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, deliveryfull);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Delivery Order document created.", InformationType.Success);
        }

        private void WarehouseFull_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
