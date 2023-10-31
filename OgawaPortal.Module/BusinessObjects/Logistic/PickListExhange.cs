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

namespace OgawaPortal.Module.BusinessObjects.Logistic
{
    [DefaultClassOptions]
    [NavigationItem("Logistic")]
    [XafDisplayName("Pick List - Exchange")]
    [DefaultProperty("DocNum")]
    [Appearance("HideDelete", AppearanceItemType = "Action", TargetItems = "Delete", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]

    [Appearance("HideSubmit", AppearanceItemType = "Action", TargetItems = "SubmitExchangePickList", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideCancel", AppearanceItemType = "Action", TargetItems = "CancelExchangePickList", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSubmit2", AppearanceItemType = "Action", TargetItems = "SubmitExchangePickList", Criteria = "not (Status in (0))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideCancel2", AppearanceItemType = "Action", TargetItems = "CancelExchangePickList", Criteria = "not (Status in (0))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    public class PickListExhange : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PickListExhange(Session session)
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
            ExpectedDate = DateTime.Now;
            DeliveryTime = new TimeSpan(ExpectedDate.Hour, ExpectedDate.Minute, ExpectedDate.Second);
            Status = Status.Draft;
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

        private string _DocNum;
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [XafDisplayName("Document No")]
        [Appearance("DocNum", Enabled = false)]
        public string DocNum
        {
            get
            {
                int Number = 1000000 + Oid;
                _DocNum = Number.ToString();
                return _DocNum;
            }
        }

        private DateTime _ExpectedDate;
        [XafDisplayName("Expected Date")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("ExpectedDate", Enabled = false, Criteria = "not (Status in (0))")]
        public DateTime ExpectedDate
        {
            get { return _ExpectedDate; }
            set
            {
                SetPropertyValue("ExpectedDate", ref _ExpectedDate, value);
            }
        }

        private TimeSpan _DeliveryTime;
        [XafDisplayName("Delivery Time")]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("DeliveryTime", Enabled = false, Criteria = "not (Status in (0))")]
        public TimeSpan DeliveryTime
        {
            get { return _DeliveryTime; }
            set
            {
                SetPropertyValue("DeliveryTime", ref _DeliveryTime, value);
            }
        }

        private string _SalesOrderNo;
        [XafDisplayName("Sales Order No")]
        [Index(8), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("SalesOrderNo", Enabled = false)]
        public string SalesOrderNo
        {
            get { return _SalesOrderNo; }
            set
            {
                SetPropertyValue("SalesOrderNo", ref _SalesOrderNo, value);
            }
        }

        private DateTime _SalesOrderDate;
        [XafDisplayName("Sales Order Date")]
        [Index(10), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("SalesOrderDate", Enabled = false)]
        public DateTime SalesOrderDate
        {
            get { return _SalesOrderDate; }
            set
            {
                SetPropertyValue("SalesOrderDate", ref _SalesOrderDate, value);
            }
        }

        private string _SORefNo;
        [XafDisplayName("SO Ref No")]
        [Index(12), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("SORefNo", Enabled = false)]
        public string SORefNo
        {
            get { return _SORefNo; }
            set
            {
                SetPropertyValue("SORefNo", ref _SORefNo, value);
            }
        }

        private string _DRRefNo;
        [XafDisplayName("DR Ref No")]
        [Index(15), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("DRRefNo", Enabled = false)]
        public string DRRefNo
        {
            get { return _DRRefNo; }
            set
            {
                SetPropertyValue("DRRefNo", ref _DRRefNo, value);
            }
        }

        private string _PLRefNo;
        [XafDisplayName("PL Ref No")]
        [Index(18), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("PLRefNo", Enabled = false)]
        public string PLRefNo
        {
            get { return _PLRefNo; }
            set
            {
                SetPropertyValue("PLRefNo", ref _PLRefNo, value);
            }
        }

        private Transporter _Transporter;
        [XafDisplayName("Transporter")]
        [DataSourceCriteria("IsActive = 'True'")]
        [Index(20), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Transporter", Enabled = false, Criteria = "not (Status in (0))")]
        [RuleRequiredField(DefaultContexts.Save)]
        public Transporter Transporter
        {
            get { return _Transporter; }
            set
            {
                SetPropertyValue("Transporter", ref _Transporter, value);
            }
        }

        private vwWarehouse _Warehouse;
        [NoForeignKey]
        [Index(22), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Warehouse", Enabled = false, Criteria = "not (Status in (0))")]
        [RuleRequiredField(DefaultContexts.Save)]
        public vwWarehouse Warehouse
        {
            get { return _Warehouse; }
            set
            {
                SetPropertyValue("Warehouse", ref _Warehouse, value);
            }
        }

        private Status _Status;
        [XafDisplayName("Status")]
        [Appearance("Status", Enabled = false)]
        [Index(25), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public Status Status
        {
            get { return _Status; }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }

        private string _SellerRemarks;
        [XafDisplayName("Seller Remarks")]
        [Index(28), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("SellerRemarks", Enabled = false, Criteria = "not (Status in (0))")]
        public string SellerRemarks
        {
            get { return _SellerRemarks; }
            set
            {
                SetPropertyValue("SellerRemarks", ref _SellerRemarks, value);
            }
        }

        private string _LogisticRemarks;
        [XafDisplayName("Logistic Remarks")]
        [Index(30), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("LogisticRemarks", Enabled = false, Criteria = "not (Status in (0))")]
        public string LogisticRemarks
        {
            get { return _LogisticRemarks; }
            set
            {
                SetPropertyValue("LogisticRemarks", ref _LogisticRemarks, value);
            }
        }

        private string _DeliveryOrderRemarks;
        [XafDisplayName("Delivery Order Remarks")]
        [Index(32), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryOrderRemarks", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryOrderRemarks
        {
            get { return _DeliveryOrderRemarks; }
            set
            {
                SetPropertyValue("DeliveryOrderRemarks", ref _DeliveryOrderRemarks, value);
            }
        }

        //Payment
        private decimal _SubTotal;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("SubTotal", Enabled = false)]
        [Index(35), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Sub Total")]
        public decimal SubTotal
        {
            get { return _SubTotal; }
            set
            {
                SetPropertyValue("SubTotal", ref _SubTotal, value);
            }
        }

        private decimal _OrderDiscount;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("OrderDiscount", Enabled = false)]
        [Index(38), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Order Discount")]
        public decimal OrderDiscount
        {
            get { return _OrderDiscount; }
            set
            {
                SetPropertyValue("OrderDiscount", ref _OrderDiscount, value);
            }
        }

        private decimal _Tax;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("Tax", Enabled = false)]
        [Index(40), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Tax")]
        public decimal Tax
        {
            get { return _Tax; }
            set
            {
                SetPropertyValue("Tax", ref _Tax, value);
            }
        }

        private decimal _TotalDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("TotalDue", Enabled = false)]
        [Index(42), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Total Due")]
        public decimal TotalDue
        {
            get { return _TotalDue; }
            set
            {
                SetPropertyValue("TotalDue", ref _TotalDue, value);
            }
        }

        private decimal _SettlementDiscount;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("SettlementDiscount", Enabled = false)]
        [Index(45), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Settlement Discount")]
        public decimal SettlementDiscount
        {
            get { return _SettlementDiscount; }
            set
            {
                SetPropertyValue("SettlementDiscount", ref _SettlementDiscount, value);
            }
        }

        private decimal _NetTotalDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("NetTotalDue", Enabled = false)]
        [Index(48), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Net Total Due")]
        public decimal NetTotalDue
        {
            get { return _NetTotalDue; }
            set
            {
                SetPropertyValue("NetTotalDue", ref _NetTotalDue, value);
            }
        }

        private decimal _Cash;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("Cash", Enabled = false)]
        [Index(50), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Cash")]
        public decimal Cash
        {
            get { return _Cash; }
            set
            {
                SetPropertyValue("Cash", ref _Cash, value);
            }
        }

        private decimal _CreditCard;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("CreditCard", Enabled = false)]
        [Index(52), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Credit Card")]
        public decimal CreditCard
        {
            get { return _CreditCard; }
            set
            {
                SetPropertyValue("CreditCard", ref _CreditCard, value);
            }
        }

        private decimal _Voucher;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("Voucher", Enabled = false)]
        [Index(55), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Voucher")]
        public decimal Voucher
        {
            get { return _Voucher; }
            set
            {
                SetPropertyValue("Voucher", ref _Voucher, value);
            }
        }

        private decimal _CreditNote;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("CreditNote", Enabled = false)]
        [Index(58), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Credit Note")]
        public decimal CreditNote
        {
            get { return _CreditNote; }
            set
            {
                SetPropertyValue("CreditNote", ref _CreditNote, value);
            }
        }

        private decimal _PreviousPayment;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("PreviousPayment", Enabled = false)]
        [Index(60), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Previous Payment")]
        public decimal PreviousPayment
        {
            get { return _PreviousPayment; }
            set
            {
                SetPropertyValue("PreviousPayment", ref _PreviousPayment, value);
            }
        }

        private decimal _TotalPayment;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("TotalPayment", Enabled = false)]
        [Index(62), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Total Payment")]
        public decimal TotalPayment
        {
            get { return _TotalPayment; }
            set
            {
                SetPropertyValue("TotalPayment", ref _TotalPayment, value);
            }
        }

        private decimal _OrderBalanceDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("OrderBalanceDue", Enabled = false)]
        [Index(65), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Order Balance Due")]
        public decimal OrderBalanceDue
        {
            get { return _OrderBalanceDue; }
            set
            {
                SetPropertyValue("OrderBalanceDue", ref _OrderBalanceDue, value);
            }
        }

        private decimal _MinimumDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("MinimumDue", Enabled = false)]
        [Index(68), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Minimum Due")]
        public decimal MinimumDue
        {
            get { return _MinimumDue; }
            set
            {
                SetPropertyValue("MinimumDue", ref _MinimumDue, value);
            }
        }

        private decimal _MinDueBalance;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("MinDueBalance", Enabled = false)]
        [Index(70), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Min. Due Balance")]
        public decimal MinDueBalance
        {
            get { return _MinDueBalance; }
            set
            {
                SetPropertyValue("MinDueBalance", ref _MinDueBalance, value);
            }
        }

        // Billing
        private Customer _BillName;
        [ImmediatePostData]
        [XafDisplayName("Customer Name")]
        [Index(72), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillName", Enabled = false, Criteria = "not (Status in (0))")]
        public Customer BillName
        {
            get { return _BillName; }
            set
            {
                SetPropertyValue("BillName", ref _BillName, value);
            }
        }

        private string _BillAddress1;
        [XafDisplayName("Address1")]
        [Index(75), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillAddress1", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillAddress1
        {
            get { return _BillAddress1; }
            set
            {
                SetPropertyValue("BillAddress1", ref _BillAddress1, value);
            }
        }

        private string _BillAddress2;
        [XafDisplayName("Address2")]
        [Index(78), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillAddress2", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillAddress2
        {
            get { return _BillAddress2; }
            set
            {
                SetPropertyValue("BillAddress2", ref _BillAddress2, value);
            }
        }

        private string _BillCity;
        [XafDisplayName("City")]
        [Index(80), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillCity", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillCity
        {
            get { return _BillCity; }
            set
            {
                SetPropertyValue("BillCity", ref _BillCity, value);
            }
        }

        private District _BillDistrict;
        [XafDisplayName("District/State")]
        [Index(82), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillDistrict", Enabled = false, Criteria = "not (Status in (0))")]
        public District BillDistrict
        {
            get { return _BillDistrict; }
            set
            {
                SetPropertyValue("BillDistrict", ref _BillDistrict, value);
            }
        }

        private string _BillPostCode;
        [XafDisplayName("PostCode")]
        [Index(85), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillPostCode", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillPostCode
        {
            get { return _BillPostCode; }
            set
            {
                SetPropertyValue("BillPostCode", ref _BillPostCode, value);
            }
        }

        private CountryList _BillCountry;
        [XafDisplayName("Country")]
        [Index(88), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillCountry", Enabled = false, Criteria = "not (Status in (0))")]
        public CountryList BillCountry
        {
            get { return _BillCountry; }
            set
            {
                SetPropertyValue("BillCountry", ref _BillCountry, value);
            }
        }

        private string _BillMobilePhone;
        [XafDisplayName("Mobile Phone")]
        [Index(90), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillMobilePhone", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillMobilePhone
        {
            get { return _BillMobilePhone; }
            set
            {
                SetPropertyValue("BillMobilePhone", ref _BillMobilePhone, value);
            }
        }

        private string _BillHomePhone;
        [XafDisplayName("Home Phone")]
        [Index(92), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillHomePhone", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillHomePhone
        {
            get { return _BillHomePhone; }
            set
            {
                SetPropertyValue("BillHomePhone", ref _BillHomePhone, value);
            }
        }

        private string _BillEmail;
        [XafDisplayName("Email")]
        [Index(95), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillEmail", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillEmail
        {
            get { return _BillEmail; }
            set
            {
                SetPropertyValue("BillEmail", ref _BillEmail, value);
            }
        }

        private string _BillIdentityNo;
        [XafDisplayName("Identity No/D.O.B")]
        [Index(98), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillIdentityNo", Enabled = false, Criteria = "not (Status in (0))")]
        public string BillIdentityNo
        {
            get { return _BillIdentityNo; }
            set
            {
                SetPropertyValue("BillIdentityNo", ref _BillIdentityNo, value);
            }
        }

        private Races _BillRace;
        [XafDisplayName("Race")]
        [Index(100), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillRace", Enabled = false, Criteria = "not (Status in (0))")]
        public Races BillRace
        {
            get { return _BillRace; }
            set
            {
                SetPropertyValue("BillRace", ref _BillRace, value);
            }
        }

        // Delivery
        private Customer _DeliveryContact;
        [ImmediatePostData]
        [XafDisplayName("Contact")]
        [Index(102), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryContact", Enabled = false, Criteria = "not (Status in (0))")]
        public Customer DeliveryContact
        {
            get { return _DeliveryContact; }
            set
            {
                SetPropertyValue("DeliveryContact", ref _DeliveryContact, value);
            }
        }

        private string _DeliveryAddress1;
        [XafDisplayName("Address1")]
        [Index(105), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryAddress1", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryAddress1
        {
            get { return _DeliveryAddress1; }
            set
            {
                SetPropertyValue("DeliveryAddress1", ref _DeliveryAddress1, value);
            }
        }

        private string _DeliveryAddress2;
        [XafDisplayName("Address2")]
        [Index(108), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryAddress2", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryAddress2
        {
            get { return _DeliveryAddress2; }
            set
            {
                SetPropertyValue("DeliveryAddress2", ref _DeliveryAddress2, value);
            }
        }

        private string _DeliveryCity;
        [XafDisplayName("City")]
        [Index(110), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryCity", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryCity
        {
            get { return _DeliveryCity; }
            set
            {
                SetPropertyValue("DeliveryCity", ref _DeliveryCity, value);
            }
        }

        private District _DeliveryDistrict;
        [XafDisplayName("District/State")]
        [Index(112), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryDistrict", Enabled = false, Criteria = "not (Status in (0))")]
        public District DeliveryDistrict
        {
            get { return _DeliveryDistrict; }
            set
            {
                SetPropertyValue("DeliveryDistrict", ref _DeliveryDistrict, value);
            }
        }

        private string _DeliveryPostCode;
        [XafDisplayName("PostCode")]
        [Index(115), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryPostCode", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryPostCode
        {
            get { return _DeliveryPostCode; }
            set
            {
                SetPropertyValue("DeliveryPostCode", ref _DeliveryPostCode, value);
            }
        }

        private CountryList _DeliveryCountry;
        [XafDisplayName("Country")]
        [Index(118), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryCountry", Enabled = false, Criteria = "not (Status in (0))")]
        public CountryList DeliveryCountry
        {
            get { return _DeliveryCountry; }
            set
            {
                SetPropertyValue("DeliveryCountry", ref _DeliveryCountry, value);
            }
        }

        private string _DeliveryMobilePhone;
        [XafDisplayName("Mobile Phone")]
        [Index(120), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryMobilePhone", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryMobilePhone
        {
            get { return _DeliveryMobilePhone; }
            set
            {
                SetPropertyValue("DeliveryMobilePhone", ref _DeliveryMobilePhone, value);
            }
        }

        private string _DeliveryHomePhone;
        [XafDisplayName("Home Phone")]
        [Index(122), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryHomePhone", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryHomePhone
        {
            get { return _DeliveryHomePhone; }
            set
            {
                SetPropertyValue("DeliveryHomePhone", ref _DeliveryHomePhone, value);
            }
        }

        private Races _DeliveryRace;
        [XafDisplayName("Race")]
        [Index(125), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryRace", Enabled = false, Criteria = "not (Status in (0))")]
        public Races DeliveryRace
        {
            get { return _DeliveryRace; }
            set
            {
                SetPropertyValue("DeliveryRace", ref _DeliveryRace, value);
            }
        }

        [Browsable(false)]
        public bool IsNew
        {
            get
            { return Session.IsNewObject(this); }
        }

        [Association("PickListExhange-DetailsBO")]
        [XafDisplayName("Items")]
        [Appearance("DetailsBO", Enabled = false, Criteria = "not (Status in (0))")]
        public XPCollection<PickListExchangeDetails> DetailsBO
        {
            get { return GetCollection<PickListExchangeDetails>("DetailsBO"); }
        }

        [Association("PickListExhange-PaymentDetailsBO")]
        [XafDisplayName("Payment")]
        [Appearance("PaymentDetailsBO", Enabled = false, Criteria = "not (Status in (0))")]
        public XPCollection<PickListExchangePayment> PaymentDetailsBO
        {
            get { return GetCollection<PickListExchangePayment>("PaymentDetailsBO"); }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && (Session.ObjectLayer is SimpleObjectLayer)
                        )
            {
                ApplicationUser user = (ApplicationUser)SecuritySystem.CurrentUser;
                if (user != null)
                {
                    UpdateUser = Session.GetObjectByKey<ApplicationUser>(user.Oid);
                }
                UpdateDate = DateTime.Now;
            }
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            this.Reload();
        }
    }
}