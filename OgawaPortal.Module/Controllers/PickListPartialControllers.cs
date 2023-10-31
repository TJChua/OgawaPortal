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
    public partial class PickListPartialControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public PickListPartialControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(PickListPartialPayment);
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

        private void SubmitPartialPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListPartialPayment selectedObject = (PickListPartialPayment)e.CurrentObject;

            selectedObject.Status = Status.Submit;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            PickListPartialPayment partial = os.FindObject<PickListPartialPayment>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, partial, ViewEditMode.View);
            showMsg("Successful", "Document Submitted.", InformationType.Success);
        }

        private void SubmitPartialPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CancelPartialPickList_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListPartialPayment selectedObject = (PickListPartialPayment)e.CurrentObject;

            selectedObject.Status = Status.Cancel;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();

            IObjectSpace os = Application.CreateObjectSpace();
            PickListPartialPayment partial = os.FindObject<PickListPartialPayment>(new BinaryOperator("Oid", selectedObject.Oid));
            openNewView(os, partial, ViewEditMode.View);
            showMsg("Successful", "Document Cancelled.", InformationType.Success);
        }

        private void CancelPartialPickList_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void WarehousePartial_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            PickListPartialPayment selectedObject = (PickListPartialPayment)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            DeliveryOrderPartial deliverypartial = os.CreateObject<DeliveryOrderPartial>();

            deliverypartial.PickListCreateDate = DateTime.Now;
            deliverypartial.DeliveryDate = DateTime.Now;
            deliverypartial.DeliveryTime = new TimeSpan(deliverypartial.DeliveryDate.Hour, deliverypartial.DeliveryDate.Minute, deliverypartial.DeliveryDate.Second);
            deliverypartial.SalesOrderNo = selectedObject.SalesOrderNo;
            deliverypartial.SORefNo = selectedObject.SORefNo;
            deliverypartial.DRRefNo = selectedObject.DRRefNo;
            deliverypartial.PLRefNo = selectedObject.PLRefNo;
            if (selectedObject.Warehouse != null)
            {
                deliverypartial.Warehouse = deliverypartial.Session.GetObjectByKey<vwWarehouse>(selectedObject.Warehouse.WhsCode);
            }

            if (selectedObject.DeliveryContact != null)
            {
                deliverypartial.DeliveryContact = deliverypartial.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            deliverypartial.DeliveryAddress2 = selectedObject?.DeliveryAddress2;
            deliverypartial.DeliveryCity = selectedObject.DeliveryCity;
            deliverypartial.DeliveryDistrict = selectedObject.DeliveryDistrict;
            deliverypartial.DeliveryPostCode = selectedObject.DeliveryPostCode;
            deliverypartial.DeliveryCountry = selectedObject.DeliveryCountry;
            deliverypartial.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            deliverypartial.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            deliverypartial.DeliveryRace = selectedObject.DeliveryRace;

            IObjectSpace fos = Application.CreateObjectSpace();
            PartialPaymentDeliveryReq partialpayment = fos.FindObject<PartialPaymentDeliveryReq>(new BinaryOperator("BaseNum", selectedObject.SalesOrderNo));
            if (partialpayment != null)
            {
                deliverypartial.RequestNo = partialpayment.DocNum;
            }

            foreach (PickListPartialPaymentDetails dtl in selectedObject.DetailsBO)
            {
                DeliveryOrderPartialDetails itemlist = os.CreateObject<DeliveryOrderPartialDetails>();
                itemlist.Class = dtl.Class;
                itemlist.ItemCode = itemlist.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                itemlist.ItemName = dtl.ItemName;
                itemlist.Ship = dtl.ToShip;
                deliverypartial.DetailsBO.Add(itemlist);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, deliverypartial);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Delivery Order document created.", InformationType.Success);
        }

        private void WarehousePartial_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
