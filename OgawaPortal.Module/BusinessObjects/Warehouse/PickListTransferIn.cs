﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
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
    [XafDisplayName("Transfer In")]
    [DefaultProperty("DocNum")]
    [Appearance("HideDelete", AppearanceItemType = "Action", TargetItems = "Delete", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]

    [Appearance("HideSubmit", AppearanceItemType = "Action", TargetItems = "SubmitPickListTransferIn", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSubmit2", AppearanceItemType = "Action", TargetItems = "SubmitPickListTransferIn", Criteria = "not (Status in (6))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    public class PickListTransferIn : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PickListTransferIn(Session session)
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
            TransferDate = DateTime.Now;
            Status = Status.Draft;
            TransferFrom = Session.GetObjectByKey<vwWarehouse>(user.Outlet.CardCode);
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
        [ImmediatePostData]
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [XafDisplayName("Transfer No")]
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

        private DateTime _TransferDate;
        [XafDisplayName("Transfer Date")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("TransferDate", Enabled = false, Criteria = "not (Status in (6))")]
        public DateTime TransferDate
        {
            get { return _TransferDate; }
            set
            {
                SetPropertyValue("TransferDate", ref _TransferDate, value);
            }
        }

        private vwWarehouse _TransferFrom;
        [NoForeignKey]
        [XafDisplayName("Transfer From")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("TransferFrom", Enabled = false, Criteria = "not (Status in (6))")]
        [DataSourceCriteria("Inactive = 'N'")]
        public vwWarehouse TransferFrom
        {
            get { return _TransferFrom; }
            set
            {
                SetPropertyValue("TransferFrom", ref _TransferFrom, value);
            }
        }

        private vwWarehouse _TransferTo;
        [NoForeignKey]
        [XafDisplayName("Transfer To")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(8), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("TransferTo", Enabled = false, Criteria = "not (Status in (6))")]
        [DataSourceCriteria("Inactive = 'N'")]
        public vwWarehouse TransferTo
        {
            get { return _TransferTo; }
            set
            {
                SetPropertyValue("TransferTo", ref _TransferTo, value);
            }
        }

        private DateTime _ReceiveDate;
        [XafDisplayName("Receive Date")]
        [Index(9), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("ReceiveDate", Enabled = false, Criteria = "not (Status in (6))")]
        public DateTime ReceiveDate
        {
            get { return _ReceiveDate; }
            set
            {
                SetPropertyValue("ReceiveDate", ref _ReceiveDate, value);
            }
        }

        private string _TranferRefNo;
        [XafDisplayName("Transfer Ref No")]
        [Index(10), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("TranferRefNo", Enabled = false, Criteria = "not (Status in (6))")]
        public string TranferRefNo
        {
            get { return _TranferRefNo; }
            set
            {
                SetPropertyValue("TranferRefNo", ref _TranferRefNo, value);
            }
        }

        private Status _Status;
        [XafDisplayName("Transfer Status")]
        [Appearance("Status", Enabled = false)]
        [Index(12), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public Status Status
        {
            get { return _Status; }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }

        private string _Remarks;
        [Index(15), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("Remarks", Enabled = false, Criteria = "not (Status in (6))")]
        public string Remarks
        {
            get { return _Remarks; }
            set
            {
                SetPropertyValue("Remarks", ref _Remarks, value);
            }
        }

        private string _BaseNum;
        [Index(18), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Appearance("BaseNum", Enabled = false)]
        public string BaseNum
        {
            get { return _BaseNum; }
            set
            {
                SetPropertyValue("BaseNum", ref _BaseNum, value);
            }
        }

        [Browsable(false)]
        public bool IsNew
        {
            get
            { return Session.IsNewObject(this); }
        }

        [Association("PickListTransferIn-DetailsBO")]
        [XafDisplayName("Items")]
        [Appearance("DetailsBO", Enabled = false, Criteria = "not (Status in (6))")]
        public XPCollection<PickListTransferInDetails> DetailsBO
        {
            get { return GetCollection<PickListTransferInDetails>("DetailsBO"); }
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