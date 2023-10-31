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

namespace OgawaPortal.Module.BusinessObjects.Warehouse
{
    [DefaultClassOptions]
    [NavigationItem("Warehouse")]
    [XafDisplayName("Delivery Order - Full")]
    [DefaultProperty("DocNum")]
    [Appearance("HideDelete", AppearanceItemType = "Action", TargetItems = "Delete", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]

    [Appearance("HideSubmit", AppearanceItemType = "Action", TargetItems = "SubmitFullDO", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideCancel", AppearanceItemType = "Action", TargetItems = "CancelFullDO", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSubmit2", AppearanceItemType = "Action", TargetItems = "SubmitFullDO", Criteria = "not (Status in (0))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideCancel2", AppearanceItemType = "Action", TargetItems = "CancelFullDO", Criteria = "not (Status in (0))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    
    public class DeliveryOrderFull : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DeliveryOrderFull(Session session)
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
            PickListCreateDate = DateTime.Now;
            DeliveryDate = DateTime.Now;
            DeliveryTime = new TimeSpan(DeliveryDate.Hour, DeliveryDate.Minute, DeliveryDate.Second);
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

        private DateTime _PickListCreateDate;
        [XafDisplayName("Pick List Create Date")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("PickListCreateDate", Enabled = false, Criteria = "not (Status in (0))")]
        public DateTime PickListCreateDate
        {
            get { return _PickListCreateDate; }
            set
            {
                SetPropertyValue("PickListCreateDate", ref _PickListCreateDate, value);
            }
        }

        private DateTime _DeliveryDate;
        [XafDisplayName("Delivery Date")]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("DeliveryDate", Enabled = false, Criteria = "not (Status in (0))")]
        public DateTime DeliveryDate
        {
            get { return _DeliveryDate; }
            set
            {
                SetPropertyValue("DeliveryDate", ref _DeliveryDate, value);
            }

        }
        private TimeSpan _DeliveryTime;
        [XafDisplayName("Delivery Time")]
        [Index(8), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
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
        [Index(10), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("SalesOrderNo", Enabled = false)]
        public string SalesOrderNo
        {
            get { return _SalesOrderNo; }
            set
            {
                SetPropertyValue("SalesOrderNo", ref _SalesOrderNo, value);
            }
        }

        private string _RequestNo;
        [XafDisplayName("Request No")]
        [Index(12), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("RequestNo", Enabled = false)]
        public string RequestNo
        {
            get { return _RequestNo; }
            set
            {
                SetPropertyValue("RequestNo", ref _RequestNo, value);
            }
        }

        private string _SORefNo;
        [XafDisplayName("SO Ref No")]
        [Index(15), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
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
        [Index(18), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
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
        [Index(20), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("PLRefNo", Enabled = false)]
        public string PLRefNo
        {
            get { return _PLRefNo; }
            set
            {
                SetPropertyValue("PLRefNo", ref _PLRefNo, value);
            }
        }

        private string _DORefNo;
        [XafDisplayName("DO Ref No")]
        [Index(22), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("DORefNo", Enabled = false)]
        public string DORefNo
        {
            get { return _DORefNo; }
            set
            {
                SetPropertyValue("DORefNo", ref _DORefNo, value);
            }
        }

        private Transporter _Transporter;
        [XafDisplayName("Transporter")]
        [DataSourceCriteria("IsActive = 'True'")]
        [Index(25), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(28), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(30), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public Status Status
        {
            get { return _Status; }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }

        private string _LogisticRemarks;
        [XafDisplayName("Logistic Remarks")]
        [Index(32), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(35), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryOrderRemarks", Enabled = false, Criteria = "not (Status in (0))")]
        public string DeliveryOrderRemarks
        {
            get { return _DeliveryOrderRemarks; }
            set
            {
                SetPropertyValue("DeliveryOrderRemarks", ref _DeliveryOrderRemarks, value);
            }
        }

        // Delivery
        private Customer _DeliveryContact;
        [ImmediatePostData]
        [XafDisplayName("Contact")]
        [Index(38), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(40), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(42), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(45), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(48), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(50), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(52), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(55), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(58), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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
        [Index(60), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
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

        [Association("DeliveryOrderFull-DetailsBO")]
        [XafDisplayName("Items")]
        [Appearance("DetailsBO", Enabled = false, Criteria = "not (Status in (0))")]
        public XPCollection<DeliveryOrderFullDetails> DetailsBO
        {
            get { return GetCollection<DeliveryOrderFullDetails>("DetailsBO"); }
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