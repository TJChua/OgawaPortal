using DevExpress.Data.Filtering;
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
    [XafDisplayName("Delivery Order Full Details")]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("LinkDoc", AppearanceItemType = "Action", TargetItems = "Link", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("UnlinkDoc", AppearanceItemType = "Action", TargetItems = "Unlink", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    public class DeliveryOrderFullDetails : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DeliveryOrderFullDetails(Session session)
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

        private string _Class;
        [XafDisplayName("Class")]
        [Appearance("Class", Enabled = false)]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public string Class
        {
            get { return _Class; }
            set
            {
                SetPropertyValue("Class", ref _Class, value);
            }
        }

        private vwItemMasters _ItemCode;
        [NoForeignKey]
        [XafDisplayName("Item Code")]
        [Appearance("ItemCode", Enabled = false)]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public vwItemMasters ItemCode
        {
            get { return _ItemCode; }
            set
            {
                SetPropertyValue("ItemCode", ref _ItemCode, value);
                if (!IsLoading && value != null)
                {
                    ItemName = ItemCode.ItemName;
                    Class = ItemCode.Class;
                }
                else if (!IsLoading && value == null)
                {
                    ItemName = null;
                    Class = null;
                }
            }
        }

        private string _ItemName;
        [XafDisplayName("Item Name")]
        [Appearance("ItemName", Enabled = false)]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                SetPropertyValue("ItemName", ref _ItemName, value);
            }
        }

        private decimal _Ship;
        [ImmediatePostData]
        [Index(15), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [XafDisplayName("Ship")]
        public decimal Ship
        {
            get { return _Ship; }
            set
            {
                SetPropertyValue("Ship", ref _Ship, value);
            }
        }

        [Browsable(false)]
        public bool IsNew
        {
            get
            { return Session.IsNewObject(this); }
        }

        private DeliveryOrderFull _DeliveryOrderFull;
        [Association("DeliveryOrderFull-DetailsBO")]
        [Index(99), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Appearance("DeliveryOrderFull", Enabled = false)]
        public DeliveryOrderFull DeliveryOrderFull
        {
            get { return _DeliveryOrderFull; }
            set { SetPropertyValue("DeliveryOrderFull", ref _DeliveryOrderFull, value); }
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