using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.BusinessObjects.Nonpersistent
{
    [DomainComponent]
    [NonPersistent]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideDelete", AppearanceItemType.Action, "True", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [XafDisplayName("Item")]
    public class ItemCodes
    {
        [Browsable(false), DevExpress.ExpressApp.Data.Key]
        public int Id;

        [XafDisplayName("Class")]
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("Class", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("Class1", Enabled = false)]
        public string Class { get; set; }

        [XafDisplayName("Item Code")]
        [Index(1), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("ItemCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("ItemCode1", Enabled = false)]
        public string ItemCode { get; set; }

        [XafDisplayName("Item Name")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("ItemName", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("ItemName1", Enabled = false)]
        public string ItemName { get; set; }

        [XafDisplayName("New/Demo")]
        [Index(3), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("NewOrDemo", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("NewOrDemo1", Enabled = false)]
        public string NewOrDemo { get; set; }

        [XafDisplayName("Price")]
        [Index(4), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("Price", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("Price1", Enabled = false)]
        [ModelDefault("DisplayFormat", "n2")]
        public decimal Price { get; set; }

        [Browsable(false)]
        public bool IsErr { get; set; }
    }

    [DomainComponent]
    [NonPersistent]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideDelete", AppearanceItemType.Action, "True", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    public class ItemList
    {
        [XafDisplayName("Order Qty")]
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public int Order { get; set; }

        private BindingList<ItemCodes> Items;
        public ItemList()
        {
            Items = new BindingList<ItemCodes>();
        }
        public BindingList<ItemCodes> items { get { return Items; } }
    }

    [DomainComponent]
    [NonPersistent]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideDelete", AppearanceItemType.Action, "True", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [XafDisplayName("Item")]
    public class ItemCodesTransfer
    {
        [Browsable(false), DevExpress.ExpressApp.Data.Key]
        public int Id;

        [XafDisplayName("Class")]
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("Class", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("Class1", Enabled = false)]
        public string Class { get; set; }

        [XafDisplayName("Item Code")]
        [Index(1), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("ItemCode", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("ItemCode1", Enabled = false)]
        public string ItemCode { get; set; }

        [XafDisplayName("Item Name")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("ItemName", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("ItemName1", Enabled = false)]
        public string ItemName { get; set; }

        [XafDisplayName("New/Demo")]
        [Index(3), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("NewOrDemo", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("NewOrDemo1", Enabled = false)]
        public string NewOrDemo { get; set; }

        [XafDisplayName("OnHand")]
        [Index(4), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("OnHand", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "IsErr")]
        [Appearance("OnHand1", Enabled = false)]
        [ModelDefault("DisplayFormat", "n2")]
        public decimal OnHand { get; set; }

        [Browsable(false)]
        public bool IsErr { get; set; }
    }

    [DomainComponent]
    [NonPersistent]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideDelete", AppearanceItemType.Action, "True", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    public class ItemListTransfer
    {
        [XafDisplayName("Order Qty")]
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public int Order { get; set; }

        private BindingList<ItemCodesTransfer> Items;
        public ItemListTransfer()
        {
            Items = new BindingList<ItemCodesTransfer>();
        }
        public BindingList<ItemCodesTransfer> items { get { return Items; } }
    }
}