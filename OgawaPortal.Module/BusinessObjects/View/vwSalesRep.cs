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

namespace OgawaPortal.Module.BusinessObjects.View
{
    [DefaultClassOptions]
    [NavigationItem("SAP")]
    [XafDisplayName("Sales Person")]
    [DefaultProperty("BoFullName")]
    [Appearance("HideNew", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideEdit", AppearanceItemType.Action, "True", TargetItems = "SwitchToEditMode; Edit", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideDelete", AppearanceItemType.Action, "True", TargetItems = "Delete", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideLink", AppearanceItemType.Action, "True", TargetItems = "Link", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideUnlink", AppearanceItemType.Action, "True", TargetItems = "Unlink", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("hideSave", AppearanceItemType = "Action", TargetItems = "Save", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    //[Appearance("HideResetViewSetting", AppearanceItemType.Action, "True", TargetItems = "ResetViewSettings", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    //[Appearance("HideExport", AppearanceItemType.Action, "True", TargetItems = "Export", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideRefresh", AppearanceItemType.Action, "True", TargetItems = "Refresh", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    public class vwSalesRep : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public vwSalesRep(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Key]
        [Browsable(true)]
        [VisibleInLookupListView(true), VisibleInListView(true), VisibleInDetailView(true)]
        [Appearance("No", Enabled = false)]
        public string No { get; set; }

        [VisibleInLookupListView(true), VisibleInListView(true), VisibleInDetailView(true)]
        [Appearance("Name", Enabled = false)]
        public string Name { get; set; }

        [VisibleInLookupListView(true), VisibleInListView(true), VisibleInDetailView(true)]
        [Appearance("Code", Enabled = false)]
        public string Code { get; set; }

        [VisibleInLookupListView(true), VisibleInListView(true), VisibleInDetailView(true)]
        [Appearance("U_ContactNo", Enabled = false)]
        public string U_ContactNo { get; set; }

        [VisibleInLookupListView(true), VisibleInListView(true), VisibleInDetailView(true)]
        [Appearance("U_SEDivision", Enabled = false)]
        public string U_SEDivision { get; set; }

        [VisibleInLookupListView(true), VisibleInListView(true), VisibleInDetailView(true)]
        [Appearance("Active", Enabled = false)]
        public string Active { get; set; }

        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(true)]
        public string BoFullName
        {
            get { return Code + "-" + Name; }
        }
    }
}