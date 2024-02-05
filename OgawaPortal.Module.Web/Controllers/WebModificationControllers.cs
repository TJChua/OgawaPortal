﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using OgawaPortal.Module.BusinessObjects;
using OgawaPortal.Module.BusinessObjects.POS___Sales;
using OgawaPortal.Module.BusinessObjects.View;
using OgawaPortal.Module.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WebModificationControllers : WebModificationsController
    {
        GeneralControllers genCon;
        public WebModificationControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Enabled", false);
            Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Enabled", false);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            genCon = Frame.GetController<GeneralControllers>();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        protected override void Save(SimpleActionExecuteEventArgs args)
        {
            if (View.ObjectTypeInfo.Type == typeof(POSSales))
            {
                POSSales CurrObject = (POSSales)args.CurrentObject;

                if (CurrObject.BaseNum != null)
                {
                    IObjectSpace os = Application.CreateObjectSpace();
                    POSSales so = os.FindObject<POSSales>(new BinaryOperator("DocNum", CurrObject.BaseNum));

                    if (so != null)
                    {
                        //if (CurrObject.EditAndCancel == true)
                        //{
                        //    so.Status = Status.Cancel;
                        //}

                        if (CurrObject.ResumeOrder == true)
                        {
                            so.ResumeOrder = false;
                        }

                        if (so.SalesRep1 != null)
                        {
                            CurrObject.SalesRep1 = CurrObject.Session.GetObjectByKey<vwSalesRep>(so.SalesRep1.No);
                        }
                    }

                    os.CommitChanges();
                }

                base.Save(args);
                ((DetailView)View).ViewEditMode = ViewEditMode.View;
                View.BreakLinksToControls();
                View.CreateControls();
            }
            else
            {
                base.Save(args);
                ((DetailView)View).ViewEditMode = ViewEditMode.View;
                View.BreakLinksToControls();
                View.CreateControls();
            }
        }
    }
}
