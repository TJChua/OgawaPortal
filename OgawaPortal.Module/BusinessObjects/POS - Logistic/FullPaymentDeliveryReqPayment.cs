using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using OgawaPortal.Module.BusinessObjects.Maintenances;
using OgawaPortal.Module.BusinessObjects.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.BusinessObjects.POS___Logistic
{
    [DefaultClassOptions]
    [XafDisplayName("Full Payment Delivery Request Payment")]
    [Appearance("LinkDoc", AppearanceItemType = "Action", TargetItems = "Link", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("UnlinkDoc", AppearanceItemType = "Action", TargetItems = "Unlink", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    public class FullPaymentDeliveryReqPayment : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public FullPaymentDeliveryReqPayment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            ApplicationUser user = (ApplicationUser)SecuritySystem.CurrentUser;
            CreateUser = Session.GetObjectByKey<ApplicationUser>(user.Oid);
            CreateDate = DateTime.Now;
        }

        private ApplicationUser _CreateUser;
        [XafDisplayName("Create User")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        [Index(300), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public ApplicationUser CreateUser
        {
            get { return _CreateUser; }
            set
            {
                SetPropertyValue("CreateUser", ref _CreateUser, value);
            }
        }

        private DateTime? _CreateDate;
        [Index(301), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                SetPropertyValue("CreateDate", ref _CreateDate, value);
            }
        }

        private ApplicationUser _UpdateUser;
        [XafDisplayName("Update User"), ToolTip("Enter Text")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        [Index(302), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public ApplicationUser UpdateUser
        {
            get { return _UpdateUser; }
            set
            {
                SetPropertyValue("UpdateUser", ref _UpdateUser, value);
            }
        }

        private DateTime? _UpdateDate;
        [Index(303), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        public DateTime? UpdateDate
        {
            get { return _UpdateDate; }
            set
            {
                SetPropertyValue("UpdateDate", ref _UpdateDate, value);
            }
        }


        private PaymentMethod _PaymentMethod;
        [ImmediatePostData]
        [XafDisplayName("Payment Method")]
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public PaymentMethod PaymentMethod
        {
            get { return _PaymentMethod; }
            set
            {
                SetPropertyValue("PaymentMethod", ref _PaymentMethod, value);
                if (!IsLoading && value != 0)
                {
                    CashAmount = 0;
                    CashAcctCode = null;
                    Consignment = null;
                    CashRefNum = null;

                    CreditCardAmount = 0;
                    CreditCardAcctCode = null;
                    CreditCardNo = null;
                    CardHolderName = null;
                    CardIssuer = null;
                    CardType = null;
                    TerminalID = null;
                    ApprovalCode = null;
                    BatchNo = null;

                    VoucherAmount = 0;
                    VoucherAcctCode = null;
                    VoucherNo = null;
                    VoucherType = null;
                    TaxCode = null;
                }
            }
        }

        private string _CashAcctCode;
        [ImmediatePostData]
        [XafDisplayName("Cash Account")]
        [Appearance("CashAcctCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 0")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public string CashAcctCode
        {
            get { return _CashAcctCode; }
            set
            {
                SetPropertyValue("CashAcctCode", ref _CashAcctCode, value);
            }
        }

        private Consignment _Consignment;
        [XafDisplayName("Consignment")]
        [Appearance("Consignment", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 0")]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public Consignment Consignment
        {
            get { return _Consignment; }
            set
            {
                SetPropertyValue("Consignment", ref _Consignment, value);
            }
        }

        private decimal _CashAmount;
        [ImmediatePostData]
        [XafDisplayName("Amount")]
        [Appearance("CashAmount", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 0")]
        [Index(8), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [DbType("numeric(19,6)")]
        public decimal CashAmount
        {
            get { return _CashAmount; }
            set
            {
                SetPropertyValue("CashAmount", ref _CashAmount, value);
                if (!IsLoading)
                {
                    PaymentTotal = value + CreditCardAmount + VoucherAmount;
                }
            }
        }

        private string _CashRefNum;
        [XafDisplayName("Cash Reference No.")]
        [Appearance("CashRefNum", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 0")]
        [Index(10), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string CashRefNum
        {
            get { return _CashRefNum; }
            set
            {
                SetPropertyValue("CreditCardRefNum", ref _CashRefNum, value);
            }
        }

        private string _CreditCardAcctCode;
        [ImmediatePostData]
        [XafDisplayName("GL Account")]
        [Appearance("CreditCardAcctCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(12), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public string CreditCardAcctCode
        {
            get { return _CreditCardAcctCode; }
            set
            {
                SetPropertyValue("CreditCardAcctCode", ref _CreditCardAcctCode, value);
            }
        }

        private CardType _CardType;
        [XafDisplayName("Card Type")]
        [Appearance("CardType", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(15), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public CardType CardType
        {
            get { return _CardType; }
            set
            {
                SetPropertyValue("CardType", ref _CardType, value);
            }
        }

        private string _CreditCardNo;
        [XafDisplayName("Credit Card No(Last 6 number)")]
        [Appearance("CreditCardNo", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(18), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string CreditCardNo
        {
            get { return _CreditCardNo; }
            set
            {
                SetPropertyValue("CreditCardNo", ref _CreditCardNo, value);
            }
        }

        private string _CardHolderName;
        [XafDisplayName("Card Holder Name")]
        [Appearance("CardHolderName", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(20), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string CardHolderName
        {
            get { return _CardHolderName; }
            set
            {
                SetPropertyValue("CardHolderName", ref _CardHolderName, value);
            }
        }

        private Instalment _Instalment;
        [XafDisplayName("Instalment")]
        [Appearance("Instalment", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(22), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public Instalment Instalment
        {
            get { return _Instalment; }
            set
            {
                SetPropertyValue("Instalment", ref _Instalment, value);
            }
        }

        private string _TerminalID;
        [XafDisplayName("Terminal ID")]
        [Appearance("TerminalID", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(25), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string TerminalID
        {
            get { return _TerminalID; }
            set
            {
                SetPropertyValue("TerminalID", ref _TerminalID, value);
            }
        }

        private CardIssuer _CardIssuer;
        [XafDisplayName("Card Issuer")]
        [Appearance("CardIssuer", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(28), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public CardIssuer CardIssuer
        {
            get { return _CardIssuer; }
            set
            {
                SetPropertyValue("CardIssuer", ref _CardIssuer, value);
            }
        }

        private CardMachineBank _Merchant;
        [XafDisplayName("Merchant")]
        [Appearance("Merchant", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(30), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public CardMachineBank Merchant
        {
            get { return _Merchant; }
            set
            {
                SetPropertyValue("Merchant", ref _Merchant, value);
            }
        }

        private string _ApprovalCode;
        [XafDisplayName("Approval Code")]
        [Appearance("ApprovalCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(32), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string ApprovalCode
        {
            get { return _ApprovalCode; }
            set
            {
                SetPropertyValue("ApprovalCode", ref _ApprovalCode, value);
            }
        }

        private string _BatchNo;
        [XafDisplayName("Batch No")]
        [Appearance("BatchNo", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(35), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string BatchNo
        {
            get { return _BatchNo; }
            set
            {
                SetPropertyValue("BatchNo", ref _BatchNo, value);
            }
        }

        private bool _Transaction;
        [XafDisplayName("Transaction(Online)")]
        [Appearance("Transaction", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(38), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public bool Transaction
        {
            get { return _Transaction; }
            set
            {
                SetPropertyValue("Transaction", ref _Transaction, value);
            }
        }

        private decimal _CreditCardAmount;
        [ImmediatePostData]
        [XafDisplayName("Amount")]
        [Appearance("CreditCardAmount", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 1")]
        [Index(40), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [DbType("numeric(19,6)")]
        public decimal CreditCardAmount
        {
            get { return _CreditCardAmount; }
            set
            {
                SetPropertyValue("CreditCardAmount", ref _CreditCardAmount, value);
                if (!IsLoading)
                {
                    PaymentTotal = value + CashAmount + VoucherAmount;
                }
            }
        }

        private string _VoucherAcctCode;
        [XafDisplayName("GL Account")]
        [Appearance("VoucherAcctCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 2")]
        [Index(42), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public string VoucherAcctCode
        {
            get { return _VoucherAcctCode; }
            set
            {
                SetPropertyValue("VoucherAcctCode", ref _VoucherAcctCode, value);
            }
        }

        private Voucher _VoucherType;
        [XafDisplayName("Voucher Type")]
        [Appearance("VoucherType", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 2")]
        [Index(45), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public Voucher VoucherType
        {
            get { return _VoucherType; }
            set
            {
                SetPropertyValue("VoucherType", ref _VoucherType, value);
            }
        }

        private string _VoucherNo;
        [XafDisplayName("Voucher No.")]
        [Appearance("VoucherNo", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 2")]
        [Index(48), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public string VoucherNo
        {
            get { return _VoucherNo; }
            set
            {
                SetPropertyValue("VoucherNo", ref _VoucherNo, value);
            }
        }

        private vwTax _TaxCode;
        [NoForeignKey]
        [XafDisplayName("Tax Code")]
        [Appearance("TaxCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 2")]
        [Index(50), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        public vwTax TaxCode
        {
            get { return _TaxCode; }
            set
            {
                SetPropertyValue("TaxCode", ref _TaxCode, value);
            }
        }

        private decimal _VoucherAmount;
        [ImmediatePostData]
        [XafDisplayName("Amount")]
        [Appearance("VoucherAmount", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "PaymentMethod != 2")]
        [Index(52), VisibleInDetailView(true), VisibleInListView(true), VisibleInLookupListView(true)]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [DbType("numeric(19,6)")]
        public decimal VoucherAmount
        {
            get { return _VoucherAmount; }
            set
            {
                if (SetPropertyValue("VoucherAmount", ref _VoucherAmount, value))
                {
                    if (!IsLoading)
                    {
                        PaymentTotal = value + CashAmount + CreditCardAmount;
                    }
                }
            }
        }

        private decimal _PaymentTotal;
        [XafDisplayName("Payment Total")]
        [Index(55), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        [Appearance("PaymentTotal", Enabled = false)]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [DbType("numeric(19,6)")]
        public decimal PaymentTotal
        {
            get { return _PaymentTotal; }
            set
            {
                SetPropertyValue("PaymentTotal", ref _PaymentTotal, value);
            }
        }

        [Browsable(false)]
        public bool IsNew
        {
            get
            { return Session.IsNewObject(this); }
        }

        private FullPaymentDeliveryReq _FullPaymentDeliveryReq;
        [Association("FullPaymentDeliveryReq-PaymentDetailsBO")]
        [Index(99), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Appearance("FullPaymentDeliveryReq", Enabled = false)]
        public FullPaymentDeliveryReq FullPaymentDeliveryReq
        {
            get { return _FullPaymentDeliveryReq; }
            set { SetPropertyValue("FullPaymentDeliveryReq", ref _FullPaymentDeliveryReq, value); }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && (Session.ObjectLayer is SimpleObjectLayer)
                        )
            {
                UpdateUser = Session.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
                UpdateDate = DateTime.Now;

                if (Session.IsNewObject(this))
                {

                }
            }
        }
    }
}