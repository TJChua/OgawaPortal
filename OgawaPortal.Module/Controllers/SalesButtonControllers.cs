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
using DevExpress.Xpo.DB.Helpers;
using OgawaPortal.Module.BusinessObjects;
using OgawaPortal.Module.BusinessObjects.Exchange;
using OgawaPortal.Module.BusinessObjects.Logistic;
using OgawaPortal.Module.BusinessObjects.Maintenances;
using OgawaPortal.Module.BusinessObjects.Nonpersistent;
using OgawaPortal.Module.BusinessObjects.POS___Logistic;
using OgawaPortal.Module.BusinessObjects.POS___Sales;
using OgawaPortal.Module.BusinessObjects.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SalesButtonControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public SalesButtonControllers()
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
            // Access and customize the target View control.
            if (View.Id == "POSSales_DetailView")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.SubmitOrder.Active.SetItemValue("Enabled", true);
                    this.CancelOrder.Active.SetItemValue("Enabled", true);
                    this.CloseOrder.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SubmitOrder.Active.SetItemValue("Enabled", false);
                    this.CancelOrder.Active.SetItemValue("Enabled", false);
                    this.CloseOrder.Active.SetItemValue("Enabled", false);
                }

                if (((DetailView)View).ViewEditMode == ViewEditMode.Edit)
                {
                    this.AddItem.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.AddItem.Active.SetItemValue("Enabled", false);
                }
            }
            else if (View.Id == "POSSales_DetailView_GRN")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.SalesGoodsReturn.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SalesGoodsReturn.Active.SetItemValue("Enabled", false);
                }
            }
            else if (View.Id == "POSSales_DetailView_ExchangeOut")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.SalesExchangeOut.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SalesExchangeOut.Active.SetItemValue("Enabled", false);
                }
            }
            else if (View.Id == "POSSales_DetailView_Logistic")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.FullPaymentDR.Active.SetItemValue("Enabled", true);
                    this.PartialPaymentDR.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SalesExchangeOut.Active.SetItemValue("Enabled", false);
                    this.PartialPaymentDR.Active.SetItemValue("Enabled", true);
                }
            }
            else if (View.Id == "POSSales_DetailView_Logistic")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.FullPaymentDR.Active.SetItemValue("Enabled", true);
                    this.PartialPaymentDR.Active.SetItemValue("Enabled", true);
                    this.ExchangeDR.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.SalesExchangeOut.Active.SetItemValue("Enabled", false);
                    this.PartialPaymentDR.Active.SetItemValue("Enabled", false);
                    this.ExchangeDR.Active.SetItemValue("Enabled", false);
                }
            }
            else if (View.Id == "POSSales_DetailView_PickListFull")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.LogisticFullPayment.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.LogisticFullPayment.Active.SetItemValue("Enabled", false);
                }
            }
            else if (View.Id == "POSSales_DetailView_PickListPartial")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.LogisticPartialPayment.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.LogisticPartialPayment.Active.SetItemValue("Enabled", false);
                }
            }
            else if (View.Id == "POSSales_DetailView_PickListEx")
            {
                if (((DetailView)View).ViewEditMode == ViewEditMode.View)
                {
                    this.LogisticExchange.Active.SetItemValue("Enabled", true);
                }
                else
                {
                    this.LogisticExchange.Active.SetItemValue("Enabled", false);
                }
            }
            else
            {
                this.SubmitOrder.Active.SetItemValue("Enabled", false);
                this.CancelOrder.Active.SetItemValue("Enabled", false);
                this.CloseOrder.Active.SetItemValue("Enabled", false);
                this.AddItem.Active.SetItemValue("Enabled", false);
                this.SalesGoodsReturn.Active.SetItemValue("Enabled", false);
                this.SalesExchangeOut.Active.SetItemValue("Enabled", false);
                this.FullPaymentDR.Active.SetItemValue("Enabled", false);
                this.PartialPaymentDR.Active.SetItemValue("Enabled", false);
                this.ExchangeDR.Active.SetItemValue("Enabled", false);
                this.LogisticFullPayment.Active.SetItemValue("Enabled", false);
                this.LogisticPartialPayment.Active.SetItemValue("Enabled", false);
                this.LogisticExchange.Active.SetItemValue("Enabled", false);
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        public string getConnectionString()
        {
            string connectionString = "";

            ConnectionStringParser helper = new ConnectionStringParser(Application.ConnectionString);
            helper.RemovePartByName("xpodatastorepool");
            connectionString = string.Format(helper.GetConnectionString());

            return connectionString;
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

        private void AddItem_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;
            DetailView detailView = (DetailView)e.PopupWindowView;
            ItemList p = (ItemList)e.PopupWindow.View.CurrentObject;

            if (p.Order < 0)
            {
                showMsg("Error", "No allow negative quantity.", InformationType.Error);
                return;
            }

            ListPropertyEditor listPropertyEditor = detailView.FindItem("items") as ListPropertyEditor;

            foreach (ItemCodes dtl in listPropertyEditor.ListView.SelectedObjects)
            {
                POSSalesDetails newdetails = ObjectSpace.CreateObject<POSSalesDetails>();
                newdetails.Class = dtl.Class;
                newdetails.ItemCode = newdetails.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode);
                newdetails.ItemFather = dtl.ItemCode;
                newdetails.UnitPrice = dtl.Price;
                newdetails.Order = p.Order;
                newdetails.BackOrder = p.Order;
                newdetails.FatherKey = Guid.NewGuid().ToString();
                string fatherkey = newdetails.FatherKey;
                selectedObject.DetailsBO.Add(newdetails);

                SqlConnection conn = new SqlConnection(getConnectionString());

                string selectbom = "EXEC sp_GetBOM '" + dtl.ItemCode + "'";
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(selectbom, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSSalesDetails newbomdetails = ObjectSpace.CreateObject<POSSalesDetails>();
                    newbomdetails.ItemCode = newdetails.Session.GetObjectByKey<vwItemMasters>(reader.GetString(0));
                    newbomdetails.ItemFather = reader.GetString(1);
                    if (dtl.Class.ToUpper() == "PROMO")
                    {
                        newbomdetails.Class = reader.GetString(6) + "-P";
                    }
                    else
                    {
                        newbomdetails.Class = dtl.Class;
                    }
                    newbomdetails.UnitPrice = dtl.Price;
                    newbomdetails.Order = p.Order * reader.GetDecimal(2);
                    newbomdetails.BackOrder = p.Order * reader.GetDecimal(2);
                    newbomdetails.FatherKey = fatherkey;
                    selectedObject.DetailsBO.Add(newbomdetails);
                }
                conn.Close();
            }

            try
            {
                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();
                View.Refresh();
            }
            catch (Exception ex)
            {
                View.Refresh();
            }
        }

        private void AddItem_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            POSSales sales = (POSSales)View.CurrentObject;
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ItemCodes));

            XPObjectSpace persistentObjectSpace = (XPObjectSpace)Application.CreateObjectSpace();
            SelectedData sprocData = persistentObjectSpace.Session.ExecuteSproc("sp_GetItem", new OperandValue(sales.CreateUser.Outlet.CardCode),
                new OperandValue("Sales"));

            var nonPersistentOS = Application.CreateObjectSpace(typeof(ItemList));
            ItemList itemlist = nonPersistentOS.CreateObject<ItemList>();
            int i = 1;

            if (sprocData.ResultSet.Count() > 0)
            {
                if (sprocData.ResultSet[0].Rows.Count() > 0)
                {
                    foreach (SelectStatementResultRow row in sprocData.ResultSet[0].Rows)
                    {
                        var itemos = Application.CreateObjectSpace(typeof(ItemCodes));
                        var item = itemos.CreateObject<ItemCodes>();
                        item.Id = i;
                        item.Class = row.Values[0].ToString();
                        item.ItemCode = row.Values[1].ToString();
                        item.ItemName = row.Values[2].ToString();
                        item.NewOrDemo = row.Values[3].ToString();
                        item.Price = (decimal)row.Values[4];
                        itemlist.items.Add(item);

                        i++;
                    }
                }
            }

            nonPersistentOS.CommitChanges();

            DetailView detailView = Application.CreateDetailView(nonPersistentOS, itemlist);
            detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((ItemList)detailView.CurrentObject).Order = 1;
            e.View = detailView;
            e.DialogController.SaveOnAccept = false;
            e.DialogController.CancelAction.Active["NothingToCancel"] = false;
        }

        private void SubmitOrder_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            if (selectedObject.SalesRep1 == null || selectedObject.SalesRep2 == null)
            {
                showMsg("Error", "Please fill in Sales Rep 1 and Sales Rep 2.", InformationType.Error);
            }
            else
            {
                selectedObject.Status = Status.Submit;

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();

                IObjectSpace os = Application.CreateObjectSpace();
                POSSales transfer = os.FindObject<POSSales>(new BinaryOperator("Oid", selectedObject.Oid));
                openNewView(os, transfer, ViewEditMode.View);
                showMsg("Successful", "Document Submitted.", InformationType.Success);
            }
        }

        private void SubmitOrder_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CancelOrder_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;
            CancelConfirmation p = (CancelConfirmation)e.PopupWindow.View.CurrentObject;

            if (p.CancelType == null || p.Reason == null)
            {
                showMsg("Fail", "Please fill in cancel type and reason.", InformationType.Error);
            }
            else
            {
                selectedObject.Status = Status.Cancel;
                selectedObject.CancelType = selectedObject.Session.GetObjectByKey<CancelType>(p.CancelType.Oid);
                selectedObject.Reason = p.Reason;

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();

                IObjectSpace os = Application.CreateObjectSpace();
                POSSales sales = os.FindObject<POSSales>(new BinaryOperator("Oid", selectedObject.Oid));
                openNewView(os, sales, ViewEditMode.View);
                showMsg("Successful", "Document Cancelled.", InformationType.Success);
            }
        }

        private void CancelOrder_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<CancelConfirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((CancelConfirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void CloseOrder_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;
            CloseConfirmation p = (CloseConfirmation)e.PopupWindow.View.CurrentObject;

            if (p.CloseType == null || p.Reason == null)
            {
                showMsg("Fail", "Please fill in close type and reason.", InformationType.Error);
            }
            else
            {
                selectedObject.Status = Status.Closed;
                selectedObject.CloseType = selectedObject.Session.GetObjectByKey<CloseType>(p.CloseType.Oid);
                selectedObject.Reason = p.Reason;

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();

                IObjectSpace os = Application.CreateObjectSpace();
                POSSales sales = os.FindObject<POSSales>(new BinaryOperator("Oid", selectedObject.Oid));
                openNewView(os, sales, ViewEditMode.View);
                showMsg("Successful", "Document Cancelled.", InformationType.Success);
            }
        }

        private void CloseOrder_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<CloseConfirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((CloseConfirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void SalesGoodsReturn_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PrintGRN goodreturn = os.CreateObject<PrintGRN>();

            if (selectedObject.BillName != null)
            {
                goodreturn.BillName = goodreturn.Session.GetObjectByKey<Customer>(selectedObject.BillName.Oid);
            }
            goodreturn.BillAddress1 = selectedObject.BillAddress1;
            goodreturn.BillAddress2 = selectedObject.BillAddress2;
            goodreturn.BillCity = selectedObject.BillCity;
            goodreturn.BillDistrict = selectedObject.BillDistrict;
            goodreturn.BillPostCode = selectedObject.BillPostCode;
            goodreturn.BillCountry = selectedObject.BillCountry;
            goodreturn.BillMobilePhone = selectedObject.BillMobilePhone;
            goodreturn.BillHomePhone = selectedObject.BillHomePhone;
            goodreturn.BillEmail = selectedObject.BillEmail;
            goodreturn.BillIdentityNo = selectedObject.BillIdentityNo;
            if (selectedObject.BillRace != null)
            {
                goodreturn.BillRace = goodreturn.Session.GetObjectByKey<Races>(selectedObject.BillRace.Oid);
            }

            if (selectedObject.DeliveryContact != null)
            {
                goodreturn.DeliveryContact = goodreturn.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            goodreturn.DeliveryAddress1 = selectedObject.DeliveryAddress1;
            goodreturn.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            goodreturn.DeliveryCity = selectedObject.DeliveryCity;
            goodreturn.DeliveryDistrict = selectedObject.DeliveryDistrict;
            goodreturn.DeliveryPostCode = selectedObject.DeliveryPostCode;
            goodreturn.DeliveryCountry = selectedObject.DeliveryCountry;
            goodreturn.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            goodreturn.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                goodreturn.DeliveryRace = goodreturn.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            goodreturn.SubTotal = selectedObject.SubTotal;
            goodreturn.OrderDiscount = selectedObject.OrderDiscount;
            goodreturn.Tax = selectedObject.Tax;
            goodreturn.TotalDue = selectedObject.TotalDue;
            goodreturn.SettlementDiscount = selectedObject.SettlementDiscount;
            goodreturn.NetTotalDue = selectedObject.NetTotalDue;
            goodreturn.Cash = selectedObject.Cash;
            goodreturn.CreditCard = selectedObject.CreditCard;
            goodreturn.Voucher = selectedObject.Voucher;
            goodreturn.CreditNote = selectedObject.CreditNote;
            goodreturn.PreviousPayment = selectedObject.PreviousPayment;
            goodreturn.OrderBalanceDue = selectedObject.OrderBalanceDue;
            goodreturn.MinimumDue = selectedObject.MinimumDue;
            goodreturn.MinDueBalance = selectedObject.MinDueBalance;

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                PrintGRNDetails grnitem = os.CreateObject<PrintGRNDetails>();
                grnitem.Class = dtl.Class;
                grnitem.ItemCode = grnitem.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                grnitem.ItemName = dtl.ItemName;
                grnitem.UnitPrice = dtl.UnitPrice;
                grnitem.Order = dtl.UnitPrice;
                grnitem.Taken = dtl.Taken;
                grnitem.BackOrder = dtl.BackOrder;
                goodreturn.DetailsBO.Add(grnitem);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                PrintGRNPayment grnpayment = os.CreateObject<PrintGRNPayment>();
                grnpayment.PaymentMethod = dtl2.PaymentMethod;
                grnpayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    grnpayment.Consignment = grnpayment.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }
                grnpayment.CashAmount = dtl2.CashAmount;
                grnpayment.CashRefNum = dtl2.CashRefNum;
                grnpayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    grnpayment.CardType = grnpayment.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                grnpayment.CreditCardNo = dtl2.CreditCardNo;
                grnpayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    grnpayment.Instalment = grnpayment.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                grnpayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    grnpayment.CardIssuer = grnpayment.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    grnpayment.Merchant = grnpayment.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                grnpayment.ApprovalCode = dtl2.ApprovalCode;
                grnpayment.BatchNo = dtl2.BatchNo;
                grnpayment.Transaction = dtl2.Transaction;
                grnpayment.CreditCardAmount = dtl2.CreditCardAmount;
                grnpayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    grnpayment.VoucherType = grnpayment.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                grnpayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    grnpayment.TaxCode = grnpayment.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                grnpayment.VoucherAmount = dtl2.VoucherAmount;
                grnpayment.PaymentTotal = dtl2.PaymentTotal;
                goodreturn.PaymentDetailsBO.Add(grnpayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, goodreturn);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Goods Return Note document created.", InformationType.Success);
        }

        private void SalesGoodsReturn_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void SalesExchangeOut_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            ExchangeOut exchangeout = os.CreateObject<ExchangeOut>();

            exchangeout.SalesOrderNo = selectedObject.DocNum;
            exchangeout.SalesOrderDate = selectedObject.SalesOrderDate;
            exchangeout.SORefNo = selectedObject.SalesRefNo;

            if (selectedObject.BillName != null)
            {
                exchangeout.BillName = exchangeout.Session.GetObjectByKey<Customer>(selectedObject.BillName.Oid);
            }
            exchangeout.BillAddress1 = selectedObject.BillAddress1;
            exchangeout.BillAddress2 = selectedObject.BillAddress2;
            exchangeout.BillCity = selectedObject.BillCity;
            exchangeout.BillDistrict = selectedObject.BillDistrict;
            exchangeout.BillPostCode = selectedObject.BillPostCode;
            exchangeout.BillCountry = selectedObject.BillCountry;
            exchangeout.BillMobilePhone = selectedObject.BillMobilePhone;
            exchangeout.BillHomePhone = selectedObject.BillHomePhone;
            exchangeout.BillEmail = selectedObject.BillEmail;
            exchangeout.BillIdentityNo = selectedObject.BillIdentityNo;
            if (selectedObject.BillRace != null)
            {
                exchangeout.BillRace = exchangeout.Session.GetObjectByKey<Races>(selectedObject.BillRace.Oid);
            }

            if (selectedObject.DeliveryContact != null)
            {
                exchangeout.DeliveryContact = exchangeout.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            exchangeout.DeliveryAddress1 = selectedObject.DeliveryAddress1;
            exchangeout.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            exchangeout.DeliveryCity = selectedObject.DeliveryCity;
            exchangeout.DeliveryDistrict = selectedObject.DeliveryDistrict;
            exchangeout.DeliveryPostCode = selectedObject.DeliveryPostCode;
            exchangeout.DeliveryCountry = selectedObject.DeliveryCountry;
            exchangeout.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            exchangeout.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                exchangeout.DeliveryRace = exchangeout.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            exchangeout.SubTotal = selectedObject.SubTotal;
            exchangeout.OrderDiscount = selectedObject.OrderDiscount;
            exchangeout.Tax = selectedObject.Tax;
            exchangeout.TotalDue = selectedObject.TotalDue;
            exchangeout.SettlementDiscount = selectedObject.SettlementDiscount;
            exchangeout.NetTotalDue = selectedObject.NetTotalDue;
            exchangeout.Cash = selectedObject.Cash;
            exchangeout.CreditCard = selectedObject.CreditCard;
            exchangeout.Voucher = selectedObject.Voucher;
            exchangeout.CreditNote = selectedObject.CreditNote;
            exchangeout.PreviousPayment = selectedObject.PreviousPayment;
            exchangeout.OrderBalanceDue = selectedObject.OrderBalanceDue;
            exchangeout.MinimumDue = selectedObject.MinimumDue;
            exchangeout.MinDueBalance = selectedObject.MinDueBalance;

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                ExchangeOutDetails itemlist = os.CreateObject<ExchangeOutDetails>();
                itemlist.Class = dtl.Class;
                itemlist.ItemCode = itemlist.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                itemlist.ItemName = dtl.ItemName;
                itemlist.OrderRequest = dtl.Order;
                itemlist.BalanceRequest = dtl.Order;
                itemlist.OutletCollect = dtl.Order;
                itemlist.ToShip = dtl.Order;
                exchangeout.DetailsBO.Add(itemlist);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                ExchangeOutPayment exchangepayment = os.CreateObject<ExchangeOutPayment>();
                exchangepayment.PaymentMethod = dtl2.PaymentMethod;
                exchangepayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    exchangepayment.Consignment = exchangepayment.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }
                exchangepayment.CashAmount = dtl2.CashAmount;
                exchangepayment.CashRefNum = dtl2.CashRefNum;
                exchangepayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    exchangepayment.CardType = exchangepayment.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                exchangepayment.CreditCardNo = dtl2.CreditCardNo;
                exchangepayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    exchangepayment.Instalment = exchangepayment.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                exchangepayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    exchangepayment.CardIssuer = exchangepayment.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    exchangepayment.Merchant = exchangepayment.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                exchangepayment.ApprovalCode = dtl2.ApprovalCode;
                exchangepayment.BatchNo = dtl2.BatchNo;
                exchangepayment.Transaction = dtl2.Transaction;
                exchangepayment.CreditCardAmount = dtl2.CreditCardAmount;
                exchangepayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    exchangepayment.VoucherType = exchangepayment.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                exchangepayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    exchangepayment.TaxCode = exchangepayment.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                exchangepayment.VoucherAmount = dtl2.VoucherAmount;
                exchangepayment.PaymentTotal = dtl2.PaymentTotal;
                exchangeout.PaymentDetailsBO.Add(exchangepayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, exchangeout);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Exchange Out document created.", InformationType.Success);
        }

        private void SalesExchangeOut_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void FullPaymentDR_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            FullPaymentDeliveryReq fullpayment = os.CreateObject<FullPaymentDeliveryReq>();

            fullpayment.DeliveryRequestDate = DateTime.Now;
            fullpayment.BaseNum = selectedObject.DocNum;
            fullpayment.BaseRefNo = selectedObject.SalesRefNo;

            if (selectedObject.BillName != null)
            {
                fullpayment.BillName = fullpayment.Session.GetObjectByKey<Customer>(selectedObject.BillName.Oid);
            }
            fullpayment.BillAddress1 = selectedObject.BillAddress1;
            fullpayment.BillAddress2 = selectedObject.BillAddress2;
            fullpayment.BillCity = selectedObject.BillCity;
            fullpayment.BillDistrict = selectedObject.BillDistrict;
            fullpayment.BillPostCode = selectedObject.BillPostCode;
            fullpayment.BillCountry = selectedObject.BillCountry;
            fullpayment.BillMobilePhone = selectedObject.BillMobilePhone;
            fullpayment.BillHomePhone = selectedObject.BillHomePhone;
            fullpayment.BillEmail = selectedObject.BillEmail;
            fullpayment.BillIdentityNo = selectedObject.BillIdentityNo;
            if (selectedObject.BillRace != null)
            {
                fullpayment.BillRace = fullpayment.Session.GetObjectByKey<Races>(selectedObject.BillRace.Oid);
            }

            if (selectedObject.DeliveryContact != null)
            {
                fullpayment.DeliveryContact = fullpayment.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            fullpayment.DeliveryAddress1 = selectedObject.DeliveryAddress1;
            fullpayment.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            fullpayment.DeliveryCity = selectedObject.DeliveryCity;
            fullpayment.DeliveryDistrict = selectedObject.DeliveryDistrict;
            fullpayment.DeliveryPostCode = selectedObject.DeliveryPostCode;
            fullpayment.DeliveryCountry = selectedObject.DeliveryCountry;
            fullpayment.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            fullpayment.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                fullpayment.DeliveryRace = fullpayment.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            fullpayment.SubTotal = selectedObject.SubTotal;
            fullpayment.OrderDiscount = selectedObject.OrderDiscount;
            fullpayment.Tax = selectedObject.Tax;
            fullpayment.TotalDue = selectedObject.TotalDue;
            fullpayment.SettlementDiscount = selectedObject.SettlementDiscount;
            fullpayment.NetTotalDue = selectedObject.NetTotalDue;
            fullpayment.Cash = selectedObject.Cash;
            fullpayment.CreditCard = selectedObject.CreditCard;
            fullpayment.Voucher = selectedObject.Voucher;
            fullpayment.CreditNote = selectedObject.CreditNote;
            fullpayment.PreviousPayment = selectedObject.PreviousPayment;
            fullpayment.OrderBalanceDue = selectedObject.OrderBalanceDue;
            fullpayment.MinimumDue = selectedObject.MinimumDue;
            fullpayment.MinDueBalance = selectedObject.MinDueBalance;

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                FullPaymentDeliveryReqDetails salesitem = os.CreateObject<FullPaymentDeliveryReqDetails>();
                salesitem.Class = dtl.Class;
                salesitem.ItemCode = salesitem.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                salesitem.ItemName = dtl.ItemName;
                salesitem.UnitPrice = dtl.UnitPrice;
                salesitem.Order = dtl.UnitPrice;
                salesitem.Taken = dtl.Taken;
                salesitem.BackOrder = dtl.BackOrder;
                fullpayment.DetailsBO.Add(salesitem);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                FullPaymentDeliveryReqPayment salespayment = os.CreateObject<FullPaymentDeliveryReqPayment>();
                salespayment.PaymentMethod = dtl2.PaymentMethod;
                salespayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    salespayment.Consignment = salespayment.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }
                salespayment.CashAmount = dtl2.CashAmount;
                salespayment.CashRefNum = dtl2.CashRefNum;
                salespayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    salespayment.CardType = salespayment.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                salespayment.CreditCardNo = dtl2.CreditCardNo;
                salespayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    salespayment.Instalment = salespayment.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                salespayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    salespayment.CardIssuer = salespayment.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    salespayment.Merchant = salespayment.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                salespayment.ApprovalCode = dtl2.ApprovalCode;
                salespayment.BatchNo = dtl2.BatchNo;
                salespayment.Transaction = dtl2.Transaction;
                salespayment.CreditCardAmount = dtl2.CreditCardAmount;
                salespayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    salespayment.VoucherType = salespayment.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                salespayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    salespayment.TaxCode = salespayment.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                salespayment.VoucherAmount = dtl2.VoucherAmount;
                salespayment.PaymentTotal = dtl2.PaymentTotal;
                fullpayment.PaymentDetailsBO.Add(salespayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, fullpayment);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Full Payment Delivery Request document created.", InformationType.Success);
        }

        private void FullPaymentDR_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void PartialPaymentDR_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PartialPaymentDeliveryReq partialpayment = os.CreateObject<PartialPaymentDeliveryReq>();

            partialpayment.DeliveryRequestDate = DateTime.Now;
            partialpayment.BaseNum = selectedObject.DocNum;
            partialpayment.BaseRefNo = selectedObject.SalesRefNo;

            if (selectedObject.BillName != null)
            {
                partialpayment.BillName = partialpayment.Session.GetObjectByKey<Customer>(selectedObject.BillName.Oid);
            }
            partialpayment.BillAddress1 = selectedObject.BillAddress1;
            partialpayment.BillAddress2 = selectedObject.BillAddress2;
            partialpayment.BillCity = selectedObject.BillCity;
            partialpayment.BillDistrict = selectedObject.BillDistrict;
            partialpayment.BillPostCode = selectedObject.BillPostCode;
            partialpayment.BillCountry = selectedObject.BillCountry;
            partialpayment.BillMobilePhone = selectedObject.BillMobilePhone;
            partialpayment.BillHomePhone = selectedObject.BillHomePhone;
            partialpayment.BillEmail = selectedObject.BillEmail;
            partialpayment.BillIdentityNo = selectedObject.BillIdentityNo;
            if (selectedObject.BillRace != null)
            {
                partialpayment.BillRace = partialpayment.Session.GetObjectByKey<Races>(selectedObject.BillRace.Oid);
            }

            if (selectedObject.DeliveryContact != null)
            {
                partialpayment.DeliveryContact = partialpayment.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            partialpayment.DeliveryAddress1 = selectedObject.DeliveryAddress1;
            partialpayment.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            partialpayment.DeliveryCity = selectedObject.DeliveryCity;
            partialpayment.DeliveryDistrict = selectedObject.DeliveryDistrict;
            partialpayment.DeliveryPostCode = selectedObject.DeliveryPostCode;
            partialpayment.DeliveryCountry = selectedObject.DeliveryCountry;
            partialpayment.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            partialpayment.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                partialpayment.DeliveryRace = partialpayment.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            partialpayment.SubTotal = selectedObject.SubTotal;
            partialpayment.OrderDiscount = selectedObject.OrderDiscount;
            partialpayment.Tax = selectedObject.Tax;
            partialpayment.TotalDue = selectedObject.TotalDue;
            partialpayment.SettlementDiscount = selectedObject.SettlementDiscount;
            partialpayment.NetTotalDue = selectedObject.NetTotalDue;
            partialpayment.Cash = selectedObject.Cash;
            partialpayment.CreditCard = selectedObject.CreditCard;
            partialpayment.Voucher = selectedObject.Voucher;
            partialpayment.CreditNote = selectedObject.CreditNote;
            partialpayment.PreviousPayment = selectedObject.PreviousPayment;
            partialpayment.OrderBalanceDue = selectedObject.OrderBalanceDue;
            partialpayment.MinimumDue = selectedObject.MinimumDue;
            partialpayment.MinDueBalance = selectedObject.MinDueBalance;

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                PartialPaymentDeliveryReqDetails salesitem = os.CreateObject<PartialPaymentDeliveryReqDetails>();
                salesitem.Class = dtl.Class;
                salesitem.ItemCode = salesitem.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                salesitem.ItemName = dtl.ItemName;
                salesitem.UnitPrice = dtl.UnitPrice;
                salesitem.Order = dtl.UnitPrice;
                salesitem.Taken = dtl.Taken;
                salesitem.BackOrder = dtl.BackOrder;
                partialpayment.DetailsBO.Add(salesitem);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                PartialPaymentDeliveryReqPayment salespayment = os.CreateObject<PartialPaymentDeliveryReqPayment>();
                salespayment.PaymentMethod = dtl2.PaymentMethod;
                salespayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    salespayment.Consignment = partialpayment.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }    
                salespayment.CashAmount = dtl2.CashAmount;
                salespayment.CashRefNum = dtl2.CashRefNum;
                salespayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    salespayment.CardType = partialpayment.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                salespayment.CreditCardNo = dtl2.CreditCardNo;
                salespayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    salespayment.Instalment = partialpayment.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                salespayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    salespayment.CardIssuer = partialpayment.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    salespayment.Merchant = partialpayment.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                salespayment.ApprovalCode = dtl2.ApprovalCode;
                salespayment.BatchNo = dtl2.BatchNo;
                salespayment.Transaction = dtl2.Transaction;
                salespayment.CreditCardAmount = dtl2.CreditCardAmount;
                salespayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    salespayment.VoucherType = partialpayment.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                salespayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    salespayment.TaxCode = partialpayment.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                salespayment.VoucherAmount = dtl2.VoucherAmount;
                salespayment.PaymentTotal = dtl2.PaymentTotal;
                partialpayment.PaymentDetailsBO.Add(salespayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, partialpayment);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Partial Payment Delivery Request document created.", InformationType.Success);
        }

        private void PartialPaymentDR_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void ExchangeDR_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            ExchangeDeliveryReq exchangedr = os.CreateObject<ExchangeDeliveryReq>();

            exchangedr.DeliveryRequestDate = DateTime.Now;
            exchangedr.BaseNum = selectedObject.DocNum;
            exchangedr.BaseRefNo = selectedObject.SalesRefNo;
            exchangedr.BaseDate = selectedObject.SalesOrderDate;
            exchangedr.Warehouse = exchangedr.Session.GetObjectByKey<vwWarehouse>(selectedObject.CreateUser.Outlet.CardCode);

            if (selectedObject.BillName != null)
            {
                exchangedr.BillName = exchangedr.Session.GetObjectByKey<Customer>(selectedObject.BillName.Oid);
            }
            exchangedr.BillAddress1 = selectedObject.BillAddress1;
            exchangedr.BillAddress2 = selectedObject.BillAddress2;
            exchangedr.BillCity = selectedObject.BillCity;
            exchangedr.BillDistrict = selectedObject.BillDistrict;
            exchangedr.BillPostCode = selectedObject.BillPostCode;
            exchangedr.BillCountry = selectedObject.BillCountry;
            exchangedr.BillMobilePhone = selectedObject.BillMobilePhone;
            exchangedr.BillHomePhone = selectedObject.BillHomePhone;
            exchangedr.BillEmail = selectedObject.BillEmail;
            exchangedr.BillIdentityNo = selectedObject.BillIdentityNo;
            if (selectedObject.BillRace != null)
            {
                exchangedr.BillRace = exchangedr.Session.GetObjectByKey<Races>(selectedObject.BillRace.Oid);
            }

            if (selectedObject.DeliveryContact != null)
            {
                exchangedr.DeliveryContact = exchangedr.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            exchangedr.DeliveryAddress1 = selectedObject.DeliveryAddress1;
            exchangedr.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            exchangedr.DeliveryCity = selectedObject.DeliveryCity;
            exchangedr.DeliveryDistrict = selectedObject.DeliveryDistrict;
            exchangedr.DeliveryPostCode = selectedObject.DeliveryPostCode;
            exchangedr.DeliveryCountry = selectedObject.DeliveryCountry;
            exchangedr.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            exchangedr.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                exchangedr.DeliveryRace = exchangedr.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            exchangedr.SubTotal = selectedObject.SubTotal;
            exchangedr.OrderDiscount = selectedObject.OrderDiscount;
            exchangedr.Tax = selectedObject.Tax;
            exchangedr.TotalDue = selectedObject.TotalDue;
            exchangedr.SettlementDiscount = selectedObject.SettlementDiscount;
            exchangedr.NetTotalDue = selectedObject.NetTotalDue;
            exchangedr.Cash = selectedObject.Cash;
            exchangedr.CreditCard = selectedObject.CreditCard;
            exchangedr.Voucher = selectedObject.Voucher;
            exchangedr.CreditNote = selectedObject.CreditNote;
            exchangedr.PreviousPayment = selectedObject.PreviousPayment;
            exchangedr.OrderBalanceDue = selectedObject.OrderBalanceDue;
            exchangedr.MinimumDue = selectedObject.MinimumDue;
            exchangedr.MinDueBalance = selectedObject.MinDueBalance;

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                ExchangeDeliveryReqDetails salesitem = os.CreateObject<ExchangeDeliveryReqDetails>();
                salesitem.Class = dtl.Class;
                salesitem.ItemCode = salesitem.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                salesitem.ItemName = dtl.ItemName;
                salesitem.UnitPrice = dtl.UnitPrice;
                salesitem.Order = dtl.UnitPrice;
                salesitem.Taken = dtl.Taken;
                salesitem.BackOrder = dtl.BackOrder;
                exchangedr.DetailsBO.Add(salesitem);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                ExchangeDeliveryReqPayment salespayment = os.CreateObject<ExchangeDeliveryReqPayment>();
                salespayment.PaymentMethod = dtl2.PaymentMethod;
                salespayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    salespayment.Consignment = exchangedr.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }
                salespayment.CashAmount = dtl2.CashAmount;
                salespayment.CashRefNum = dtl2.CashRefNum;
                salespayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    salespayment.CardType = exchangedr.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                salespayment.CreditCardNo = dtl2.CreditCardNo;
                salespayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    salespayment.Instalment = exchangedr.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                salespayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    salespayment.CardIssuer = exchangedr.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    salespayment.Merchant = exchangedr.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                salespayment.ApprovalCode = dtl2.ApprovalCode;
                salespayment.BatchNo = dtl2.BatchNo;
                salespayment.Transaction = dtl2.Transaction;
                salespayment.CreditCardAmount = dtl2.CreditCardAmount;
                salespayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    salespayment.VoucherType = exchangedr.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                salespayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    salespayment.TaxCode = exchangedr.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                salespayment.VoucherAmount = dtl2.VoucherAmount;
                salespayment.PaymentTotal = dtl2.PaymentTotal;
                exchangedr.PaymentDetailsBO.Add(salespayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, exchangedr);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Exchange Delivery Request document created.", InformationType.Success);
        }

        private void ExchangeDR_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void LogisticFullPayment_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PickListFullPayment pickfullpayment = os.CreateObject<PickListFullPayment>();

            pickfullpayment.ExpectedDate = DateTime.Now;
            pickfullpayment.DeliveryTime = new TimeSpan(pickfullpayment.ExpectedDate.Hour, pickfullpayment.ExpectedDate.Minute, pickfullpayment.ExpectedDate.Second);
            pickfullpayment.SalesOrderDate = selectedObject.SalesOrderDate;
            pickfullpayment.SalesOrderNo = selectedObject.DocNum;

            if (selectedObject.DeliveryContact != null)
            {
                pickfullpayment.DeliveryContact = pickfullpayment.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            pickfullpayment.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            pickfullpayment.DeliveryCity = selectedObject.DeliveryCity;
            pickfullpayment.DeliveryDistrict = selectedObject.DeliveryDistrict;
            pickfullpayment.DeliveryPostCode = selectedObject.DeliveryPostCode;
            pickfullpayment.DeliveryCountry = selectedObject.DeliveryCountry;
            pickfullpayment.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            pickfullpayment.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                pickfullpayment.DeliveryRace = pickfullpayment.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            IObjectSpace fos = Application.CreateObjectSpace();
            FullPaymentDeliveryReq fullpayment = fos.FindObject<FullPaymentDeliveryReq>(new BinaryOperator("DocNum", selectedObject.DocNum));
            if (fullpayment != null)
            {
                pickfullpayment.DRRefNo = fullpayment.DRRefNo;
            }

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                PickListFullPaymentDetails itemlist = os.CreateObject<PickListFullPaymentDetails>();
                itemlist.Class = dtl.Class;
                itemlist.ItemCode = itemlist.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                itemlist.ItemName = dtl.ItemName;
                itemlist.OrderRequest = dtl.Order;
                itemlist.BalanceRequest = dtl.Order;
                itemlist.OutletCollect = dtl.Order;
                itemlist.ToShip = dtl.Order;
                pickfullpayment.DetailsBO.Add(itemlist);
            }

            if (fullpayment != null)
            {
                foreach (FullPaymentDeliveryReqAttach dtl2 in fullpayment.AttachmentDetailsBO)
                {
                    PickListFullPaymentAttach attachment = os.CreateObject<PickListFullPaymentAttach>();
                    attachment.File = dtl2.File;
                    attachment.Remarks = dtl2.Remarks;
                    pickfullpayment.AttachmentDetailsBO.Add(attachment);
                }
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, pickfullpayment);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Full Payment Pick List document created.", InformationType.Success);
        }

        private void LogisticFullPayment_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void LogisticPartialPayment_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PickListPartialPayment pickpartialpayment = os.CreateObject<PickListPartialPayment>();

            pickpartialpayment.ExpectedDate = DateTime.Now;
            pickpartialpayment.DeliveryTime = new TimeSpan(pickpartialpayment.ExpectedDate.Hour, pickpartialpayment.ExpectedDate.Minute, pickpartialpayment.ExpectedDate.Second);
            pickpartialpayment.SalesOrderDate = selectedObject.SalesOrderDate;
            pickpartialpayment.SalesOrderNo = selectedObject.DocNum;

            if (selectedObject.DeliveryContact != null)
            {
                pickpartialpayment.DeliveryContact = pickpartialpayment.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            pickpartialpayment.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            pickpartialpayment.DeliveryCity = selectedObject.DeliveryCity;
            pickpartialpayment.DeliveryDistrict = selectedObject.DeliveryDistrict;
            pickpartialpayment.DeliveryPostCode = selectedObject.DeliveryPostCode;
            pickpartialpayment.DeliveryCountry = selectedObject.DeliveryCountry;
            pickpartialpayment.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            pickpartialpayment.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                pickpartialpayment.DeliveryRace = pickpartialpayment.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            pickpartialpayment.OrderBalanceDue = selectedObject.OrderBalanceDue;
            pickpartialpayment.NetTotalDue = selectedObject.NetTotalDue;
            pickpartialpayment.TotalPayment = selectedObject.TotalPayment;

            IObjectSpace fos = Application.CreateObjectSpace();
            PartialPaymentDeliveryReq partialpayment = fos.FindObject<PartialPaymentDeliveryReq>(new BinaryOperator("DocNum", selectedObject.DocNum));
            if (partialpayment != null)
            {
                partialpayment.DRRefNo = pickpartialpayment.DRRefNo;
                pickpartialpayment.PreviousCODCollected = partialpayment.TotalPayment;
                pickpartialpayment.PreviousCODToCollected = selectedObject.TotalPayment - partialpayment.TotalPayment;
            }

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                PickListPartialPaymentDetails itemlist = os.CreateObject<PickListPartialPaymentDetails>();
                itemlist.Class = dtl.Class;
                itemlist.ItemCode = itemlist.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                itemlist.ItemName = dtl.ItemName;
                itemlist.OrderRequest = dtl.Order;
                itemlist.BalanceRequest = dtl.Order;
                itemlist.OutletCollect = dtl.Order;
                itemlist.ToShip = dtl.Order;
                pickpartialpayment.DetailsBO.Add(itemlist);
            }

            if (partialpayment != null)
            {
                foreach (PartialPaymentDeliveryReqAttach dtl2 in partialpayment.AttachmentDetailsBO)
                {
                    PickListPartialPaymentAttach attachment = os.CreateObject<PickListPartialPaymentAttach>();
                    attachment.File = dtl2.File;
                    attachment.Remarks = dtl2.Remarks;
                    pickpartialpayment.AttachmentDetailsBO.Add(attachment);
                }
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, pickpartialpayment);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Partial Payment Pick List document created.", InformationType.Success);
        }

        private void LogisticPartialPayment_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }

        private void LogisticExchange_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            POSSales selectedObject = (POSSales)e.CurrentObject;

            IObjectSpace os = Application.CreateObjectSpace();
            PickListExhange pickexchange = os.CreateObject<PickListExhange>();

            pickexchange.ExpectedDate = DateTime.Now;
            pickexchange.DeliveryTime = new TimeSpan(pickexchange.ExpectedDate.Hour, pickexchange.ExpectedDate.Minute, pickexchange.ExpectedDate.Second);
            pickexchange.SalesOrderDate = selectedObject.SalesOrderDate;
            pickexchange.SalesOrderNo = selectedObject.DocNum;
            pickexchange.Warehouse = pickexchange.Session.GetObjectByKey<vwWarehouse>(selectedObject.CreateUser.Outlet.CardCode);

            if (selectedObject.DeliveryContact != null)
            {
                pickexchange.DeliveryContact = pickexchange.Session.GetObjectByKey<Customer>(selectedObject.DeliveryContact.Oid);
            }
            pickexchange.DeliveryAddress2 = selectedObject.DeliveryAddress2;
            pickexchange.DeliveryCity = selectedObject.DeliveryCity;
            pickexchange.DeliveryDistrict = selectedObject.DeliveryDistrict;
            pickexchange.DeliveryPostCode = selectedObject.DeliveryPostCode;
            pickexchange.DeliveryCountry = selectedObject.DeliveryCountry;
            pickexchange.DeliveryMobilePhone = selectedObject.DeliveryMobilePhone;
            pickexchange.DeliveryHomePhone = selectedObject.DeliveryHomePhone;
            if (selectedObject.DeliveryRace != null)
            {
                pickexchange.DeliveryRace = pickexchange.Session.GetObjectByKey<Races>(selectedObject.DeliveryRace.Oid);
            }

            pickexchange.OrderBalanceDue = selectedObject.OrderBalanceDue;
            pickexchange.NetTotalDue = selectedObject.NetTotalDue;
            pickexchange.TotalPayment = selectedObject.TotalPayment;

            if (selectedObject.Status == Status.Full)
            {
                IObjectSpace fos = Application.CreateObjectSpace();
                FullPaymentDeliveryReq fullpayment = fos.FindObject<FullPaymentDeliveryReq>(new BinaryOperator("DocNum", selectedObject.DocNum));
                if (fullpayment != null)
                {
                    pickexchange.DRRefNo = fullpayment.DRRefNo;
                }
            }
            else if (selectedObject.Status == Status.Partial)
            {
                IObjectSpace fos = Application.CreateObjectSpace();
                PartialPaymentDeliveryReq partialpayment = fos.FindObject<PartialPaymentDeliveryReq>(new BinaryOperator("DocNum", selectedObject.DocNum));
                if (partialpayment != null)
                {
                    pickexchange.DRRefNo = partialpayment.DRRefNo;
                }
            }

            foreach (POSSalesDetails dtl in selectedObject.DetailsBO)
            {
                PickListExchangeDetails itemlist = os.CreateObject<PickListExchangeDetails>();
                itemlist.Class = dtl.Class;
                itemlist.ItemCode = itemlist.Session.GetObjectByKey<vwItemMasters>(dtl.ItemCode.ItemCode);
                itemlist.ItemName = dtl.ItemName;
                itemlist.OrderRequest = dtl.Order;
                itemlist.BalanceRequest = dtl.Order;
                itemlist.OutletCollect = dtl.Order;
                itemlist.ToShip = dtl.Order;
                pickexchange.DetailsBO.Add(itemlist);
            }

            foreach (POSSalesPayment dtl2 in selectedObject.PaymentDetailsBO)
            {
                PickListExchangePayment salespayment = os.CreateObject<PickListExchangePayment>();
                salespayment.PaymentMethod = dtl2.PaymentMethod;
                salespayment.CashAcctCode = dtl2.CashAcctCode;
                if (dtl2.Consignment != null)
                {
                    salespayment.Consignment = salespayment.Session.GetObjectByKey<Consignment>(dtl2.Consignment.Oid);
                }
                salespayment.CashAmount = dtl2.CashAmount;
                salespayment.CashRefNum = dtl2.CashRefNum;
                salespayment.CreditCardAcctCode = dtl2.CreditCardAcctCode;
                if (dtl2.CardType != null)
                {
                    salespayment.CardType = salespayment.Session.GetObjectByKey<CardType>(dtl2.CardType.Oid);
                }
                salespayment.CreditCardNo = dtl2.CreditCardNo;
                salespayment.CardHolderName = dtl2.CardHolderName;
                if (dtl2.Instalment != null)
                {
                    salespayment.Instalment = salespayment.Session.GetObjectByKey<Instalment>(dtl2.Instalment.Oid);
                }
                salespayment.TerminalID = dtl2.TerminalID;
                if (dtl2.CardIssuer != null)
                {
                    salespayment.CardIssuer = salespayment.Session.GetObjectByKey<CardIssuer>(dtl2.CardIssuer.Oid);
                }
                if (dtl2.Merchant != null)
                {
                    salespayment.Merchant = salespayment.Session.GetObjectByKey<CardMachineBank>(dtl2.Merchant.Oid);
                }
                salespayment.ApprovalCode = dtl2.ApprovalCode;
                salespayment.BatchNo = dtl2.BatchNo;
                salespayment.Transaction = dtl2.Transaction;
                salespayment.CreditCardAmount = dtl2.CreditCardAmount;
                salespayment.VoucherAcctCode = dtl2.VoucherAcctCode;
                if (dtl2.VoucherType != null)
                {
                    salespayment.VoucherType = salespayment.Session.GetObjectByKey<Voucher>(dtl2.VoucherType.Oid);
                }
                salespayment.VoucherNo = dtl2.VoucherNo;
                if (dtl2.TaxCode != null)
                {
                    salespayment.TaxCode = salespayment.Session.GetObjectByKey<vwTax>(dtl2.TaxCode.Code);
                }
                salespayment.VoucherAmount = dtl2.VoucherAmount;
                salespayment.PaymentTotal = dtl2.PaymentTotal;
                pickexchange.PaymentDetailsBO.Add(salespayment);
            }

            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, pickexchange);
            dv.ViewEditMode = ViewEditMode.Edit;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
            showMsg("Success", "Exchange Pick List document created.", InformationType.Success);
        }

        private void LogisticExchange_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
