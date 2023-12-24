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
using OgawaPortal.Module.BusinessObjects.Maintenances;
using OgawaPortal.Module.BusinessObjects.Nonpersistent;
using OgawaPortal.Module.BusinessObjects.POS___Sales;
using OgawaPortal.Module.BusinessObjects.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SalesEditOrderControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public SalesEditOrderControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(POSSales);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            if (View.Id == "POSSales_DetailView_EditOrder")
            {
                //this.BackToInquiry.Active.SetItemValue("Enabled", true);
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.SalesEditOrder.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SalesEditOrder.Active.SetItemValue("Enabled", false);
                }
            }
            else
            {
                this.SalesEditOrder.Active.SetItemValue("Enabled", false);
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

        private void SalesEditOrder_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            POSSales resumeorder = os.CreateObject<POSSales>();

            resumeorder.SalesOrderDate = DateTime.Now;
            resumeorder.SalesRefNo = selectedObject.SalesRefNo;
            resumeorder.Remarks = selectedObject.Remarks;
            resumeorder.BaseNum = selectedObject.DocNum;
            resumeorder.EditAndCancel = true;

            if (selectedObject.Name != null)
            {
                resumeorder.Name = resumeorder.Session.GetObjectByKey<Customer>(selectedObject.Name.Oid);
            }
            resumeorder.Address1 = selectedObject.Address1;
            resumeorder.Address2 = selectedObject.Address2;
            resumeorder.City = selectedObject.City;
            resumeorder.District = selectedObject.District;
            resumeorder.PostCode = selectedObject.PostCode;
            resumeorder.Country = selectedObject.Country;
            resumeorder.MobilePhone = selectedObject.MobilePhone;
            resumeorder.HomePhone = selectedObject.HomePhone;
            resumeorder.Email = selectedObject.Email;
            resumeorder.IdentityNo = selectedObject.IdentityNo;
            if (selectedObject.Race != null)
            {
                resumeorder.Race = resumeorder.Session.GetObjectByKey<Races>(selectedObject.Race.Oid);
            }

            if (selectedObject.BillName != null)
            {
                resumeorder.BillName = resumeorder.Session.GetObjectByKey<Customer>(selectedObject.BillName.Oid);
            }
            resumeorder.BillAddress1 = selectedObject.BillAddress1;
            resumeorder.BillAddress2 = selectedObject.BillAddress2;
            resumeorder.BillCity = selectedObject.BillCity;
            resumeorder.BillDistrict = selectedObject.BillDistrict;
            resumeorder.BillPostCode = selectedObject.BillPostCode;
            resumeorder.BillCountry = selectedObject.BillCountry;
            resumeorder.BillMobilePhone = selectedObject.BillMobilePhone;
            resumeorder.BillHomePhone = selectedObject.BillHomePhone;
            resumeorder.BillEmail = selectedObject.BillEmail;
            resumeorder.BillIdentityNo = selectedObject.BillIdentityNo;
            if (selectedObject.BillRace != null)
            {
                resumeorder.BillRace = resumeorder.Session.GetObjectByKey<Races>(selectedObject.BillRace.Oid);
            }

            if (selectedObject.DeliveryContact != null)
            {
                resumeorder.DeliveryContact = resumeorder.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            resumeorder.DeliveryAddress1 = selectedObject.DeliveryAddress1;
            resumeorder.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            resumeorder.DeliveryCity = selectedObject.DeliveryCity;
            resumeorder.DeliveryDistrict = selectedObject.DeliveryDistrict;
            resumeorder.DeliveryPostCode = selectedObject.DeliveryPostCode;
            resumeorder.DeliveryCountry = selectedObject.DeliveryCountry;
            resumeorder.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            resumeorder.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                resumeorder.DeliveryRace = resumeorder.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            if (selectedObject.SalesRep1 != null)
            {
                resumeorder.SalesRep1 = resumeorder.Session.GetObjectByKey<vwSalesRep>(selectedObject.SalesRep1.No);
            }

            if (selectedObject.SalesRep2 != null)
            {
                resumeorder.SalesRep2 = resumeorder.Session.GetObjectByKey<vwSalesRep>(selectedObject.SalesRep2.No);
            }

            if (selectedObject.SalesRep3 != null)
            {
                resumeorder.SalesRep3 = resumeorder.Session.GetObjectByKey<vwSalesRep>(selectedObject.SalesRep3.No);
            }

            if (selectedObject.SalesRep4 != null)
            {
                resumeorder.SalesRep4 = resumeorder.Session.GetObjectByKey<vwSalesRep>(selectedObject.SalesRep4.No);
            }

            resumeorder.SubTotal = selectedObject.SubTotal;
            resumeorder.OrderDiscount = selectedObject.OrderDiscount;
            resumeorder.Tax = selectedObject.Tax;
            resumeorder.TotalDue = selectedObject.TotalDue;
            resumeorder.SettlementDiscount = selectedObject.SettlementDiscount;
            resumeorder.NetTotalDue = selectedObject.NetTotalDue;
            resumeorder.Cash = selectedObject.Cash;
            resumeorder.CreditCard = selectedObject.CreditCard;
            resumeorder.Voucher = selectedObject.Voucher;
            resumeorder.CreditNote = selectedObject.CreditNote;
            resumeorder.PreviousPayment = selectedObject.PreviousPayment;
            resumeorder.TotalPayment = selectedObject.TotalPayment;
            resumeorder.OrderBalanceDue = selectedObject.OrderBalanceDue;
            resumeorder.MinimumDue = selectedObject.MinimumDue;
            resumeorder.MinDueBalance = selectedObject.MinDueBalance;

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                POSSalesDetails orderitem = os.CreateObject<POSSalesDetails>();
                orderitem.Class = dtl.Class;
                orderitem.ItemCode = orderitem.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                orderitem.ItemName = dtl.ItemName;
                orderitem.RevisedSellingPrice = dtl.RevisedSellingPrice;
                orderitem.UnitPrice = dtl.UnitPrice;
                orderitem.Order = dtl.Order;
                orderitem.Taken = dtl.Taken;
                orderitem.BackOrder = dtl.BackOrder;
                orderitem.Amount = dtl.Amount;
                resumeorder.DetailsBO.Add(orderitem);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                POSSalesPayment orderpayment = os.CreateObject<POSSalesPayment>();
                orderpayment.PaymentMethod = dtl2.PaymentMethod;
                orderpayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    orderpayment.Consignment = orderpayment.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }
                orderpayment.CashAmount = dtl2.CashAmount;
                orderpayment.CashRefNum = dtl2.CashRefNum;
                orderpayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    orderpayment.CardType = orderpayment.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                orderpayment.CreditCardNo = dtl2.CreditCardNo;
                orderpayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    orderpayment.Instalment = orderpayment.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                orderpayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    orderpayment.CardIssuer = orderpayment.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    orderpayment.Merchant = orderpayment.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                orderpayment.ApprovalCode = dtl2.ApprovalCode;
                orderpayment.BatchNo = dtl2.BatchNo;
                orderpayment.Transaction = dtl2.Transaction;
                orderpayment.CreditCardAmount = dtl2.CreditCardAmount;
                orderpayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    orderpayment.VoucherType = orderpayment.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                orderpayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    orderpayment.TaxCode = orderpayment.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                orderpayment.VoucherAmount = dtl2.VoucherAmount;
                orderpayment.PaymentTotal = dtl2.PaymentTotal;
                resumeorder.PaymentDetailsBO.Add(orderpayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, "POSSales_DetailView", true, resumeorder);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "POS Sales document created.", InformationType.Success);
        }

        private void SalesEditOrder_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
