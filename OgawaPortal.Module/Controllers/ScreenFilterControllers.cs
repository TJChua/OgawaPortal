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
using OgawaPortal.Module.BusinessObjects.Logistic;
using OgawaPortal.Module.BusinessObjects.POS___Sales;
using OgawaPortal.Module.BusinessObjects.POS___Transfer;
using OgawaPortal.Module.BusinessObjects.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ScreenFilterControllers : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ScreenFilterControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ApplicationUser user = (ApplicationUser)SecuritySystem.CurrentUser;

            if (View.ObjectTypeInfo.Type == typeof(TransferOut))
            {
                if (View.Id == "TransferOut_ListView_TINS")
                {
                    ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Released);
                }
            }

            if (View.ObjectTypeInfo.Type == typeof(POSSales))
            {
                if (View.Id == "POSSales_ListView")
                {
                    if (user.Outlet != null)
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status != ? and CreateUser.Outlet.CardCode = ?",
                            Status.Posted, user.Outlet.CardCode);
                    }
                    else
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status != ?",Status.Posted);
                    }
                }

                if (View.Id == "POSSales_ListView_GRN")
                {
                    if (user.Outlet != null)
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ? and CreateUser.Outlet.CardCode = ?",
                        //    Status.Posted, user.Outlet.CardCode);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ? and CreateUser.Outlet.CardCode = ?",
                            Status.Submit, user.Outlet.CardCode);
                    }
                    else
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Posted);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Submit);
                    }
                }

                if (View.Id == "POSSales_ListView_ExchangeOut")
                {
                    if (user.Outlet != null)
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ? and CreateUser.Outlet.CardCode = ?",
                        //    Status.Posted, user.Outlet.CardCode);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ? and CreateUser.Outlet.CardCode = ?",
                            Status.Submit, user.Outlet.CardCode);
                    }
                    else
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Posted);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Submit);
                    }
                }

                if (View.Id == "POSSales_ListView_RsmBackOrder")
                {
                    if (user.Outlet != null)
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?) and CreateUser.Outlet.CardCode = ?",
                        //    Status.Posted, user.Outlet.CardCode);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?) and CreateUser.Outlet.CardCode = ?",
                            Status.Submit, user.Outlet.CardCode);
                    }
                    else
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                        //    Status.Posted);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                            Status.Submit);
                    }
                }

                if (View.Id == "POSSales_ListView_EditOrder")
                {
                    if (user.Outlet != null)
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ? and CreateUser.Outlet.CardCode = ?",
                        //    Status.Posted, user.Outlet.CardCode);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ? and CreateUser.Outlet.CardCode = ?",
                            Status.Submit, user.Outlet.CardCode);
                    }
                    else
                    {
                        //((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Posted);
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status = ?", Status.Submit);
                    }
                }

                if (View.Id == "POSSales_ListView_Logistic")
                {
                    if (user.Outlet != null)
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status != ? and CreateUser.Outlet.CardCode = ?",
                            Status.Posted, user.Outlet.CardCode);
                    }
                    else
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status != ?", Status.Posted);
                    }
                }

                if (View.Id == "POSSales_ListView_PickListFull")
                {
                    if (user.Outlet != null)
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?) and CreateUser.Outlet.CardCode = ?",
                            Status.Full, user.Outlet.CardCode);
                    }
                    else
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                            Status.Full);
                    }
                }

                if (View.Id == "POSSales_ListView_PickListPartial")
                {
                    if (user.Outlet != null)
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?) and CreateUser.Outlet.CardCode = ?",
                            Status.Partial, user.Outlet.CardCode);
                    }
                    else
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                            Status.Partial);
                    }
                }

                if (View.Id == "POSSales_ListView_PickListEx")
                {
                    if (user.Outlet != null)
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?, ?) and CreateUser.Outlet.CardCode = ?",
                            Status.Full, Status.Partial, user.Outlet.CardCode);
                    }
                    else
                    {
                        ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?, ?) and CreateUser.Outlet.CardCode = ?",
                            Status.Full, Status.Partial);
                    }
                }
            }

            if (View.ObjectTypeInfo.Type == typeof(PickListFullPayment))
            {
                if (View.Id == "PickListFullPayment_ListView_DOFull")
                {
                    ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                        Status.Submit);
                }
            }

            if (View.ObjectTypeInfo.Type == typeof(PickListPartialPayment))
            {
                if (View.Id == "PickListPartialPayment_ListView_DOPartial")
                {
                    ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                        Status.Submit);
                }
            }

            if (View.ObjectTypeInfo.Type == typeof(TransferPickList))
            {
                if (View.Id == "TransferPickList_ListView_TransferOut")
                {
                    ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                        Status.TransferOpen);
                }
            }

            if (View.ObjectTypeInfo.Type == typeof(PickListTransferOut))
            {
                if (View.Id == "PickListTransferOut_ListView_TransferIn")
                {
                    ((ListView)View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Status in (?)",
                        Status.Released);
                }
            }
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
