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
using OgawaPortal.Module.BusinessObjects.Maintenances;
using OgawaPortal.Module.BusinessObjects.Nonpersistent;
using OgawaPortal.Module.BusinessObjects.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class NavigationControllers : WindowController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public NavigationControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ShowNavigationItemController showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
            showNavigationItemController.CustomShowNavigationItem += showNavigationItemController_CustomShowNavigationItem;
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        void showNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
        {
            if (e.ActionArguments.SelectedChoiceActionItem.Id == "Discount_ListView")
            {
                IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Discount));
                Discount Discount = objectSpace.FindObject<Discount>(new BinaryOperator("Oid", 1));
                DetailView detailView = Application.CreateDetailView(objectSpace, Discount);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                e.ActionArguments.ShowViewParameters.CreatedView = detailView;

                e.Handled = true;
            }

            if (e.ActionArguments.SelectedChoiceActionItem.Id == "DeliveryDateControl_ListView")
            {
                IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(DeliveryDateControl));
                DeliveryDateControl DeliveryDateControl = objectSpace.FindObject<DeliveryDateControl>(new BinaryOperator("Oid", 1));
                DetailView detailView = Application.CreateDetailView(objectSpace, DeliveryDateControl);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                e.ActionArguments.ShowViewParameters.CreatedView = detailView;

                e.Handled = true;
            }

            if (e.ActionArguments.SelectedChoiceActionItem.Id == "GSTDates_ListView")
            {
                IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(GSTDates));
                GSTDates GSTDates = objectSpace.FindObject<GSTDates>(new BinaryOperator("Oid", 1));
                DetailView detailView = Application.CreateDetailView(objectSpace, GSTDates);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                e.ActionArguments.ShowViewParameters.CreatedView = detailView;

                e.Handled = true;
            }

            if (e.ActionArguments.SelectedChoiceActionItem.Id == "Change Outlet")
            {
                IObjectSpace objectSpace = Application.CreateObjectSpace();
                ChangeOutlet changeoutlet = objectSpace.CreateObject<ChangeOutlet>();

                ApplicationUser user = (ApplicationUser)SecuritySystem.CurrentUser;
                IObjectSpace os = Application.CreateObjectSpace();
                ApplicationUser upduser = os.FindObject<ApplicationUser>(new BinaryOperator("Oid", user.Oid));

                DetailView detailView = Application.CreateDetailView(objectSpace, changeoutlet);
                detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;

                if (upduser.Outlet != null)
                {
                    ((ChangeOutlet)detailView.CurrentObject).Outlet = ((ChangeOutlet)detailView.CurrentObject).Session.GetObjectByKey<vwOutlets>
                        (upduser.Outlet.CardCode);
                }

                e.ActionArguments.ShowViewParameters.CreatedView = detailView;

                e.Handled = true;
            }
        }
    }
}
