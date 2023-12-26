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
using OgawaPortal.Module.BusinessObjects.Nonpersistent;
using OgawaPortal.Module.BusinessObjects.POS___Sales;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SalesDetailControllers : ViewController
    {
        GeneralControllers genCon;
        public SalesDetailControllers()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            this.DeleteDetailItem.Active.SetItemValue("Enabled", false);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            genCon = Frame.GetController<GeneralControllers>();

            if (View.Id == "POSSales_DetailsBO_ListView")
            {
                this.DeleteDetailItem.Active.SetItemValue("Enabled", true);
            }
            else
            {
                this.DeleteDetailItem.Active.SetItemValue("Enabled", false);
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        public void showMsg(string caption, string msg, InformationType msgtype)
        {
            MessageOptions options = new MessageOptions();
            options.Duration = 3000;
            options.Message = string.Format("{0}", msg);
            options.Type = msgtype;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = caption;
            options.Win.Type = WinMessageType.Flyout;
            Application.ShowViewStrategy.ShowMessage(options);
        }

        public void openNewView(IObjectSpace os, object target, ViewEditMode viewmode)
        {
            ShowViewParameters svp = new ShowViewParameters();
            DetailView dv = Application.CreateDetailView(os, target);
            dv.ViewEditMode = viewmode;
            dv.IsRoot = true;
            svp.CreatedView = dv;

            Application.ShowViewStrategy.ShowView(svp, new ShowViewSource(null, null));
        }

        private void DeleteDetailItem_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            if (e.SelectedObjects.Count > 1)
            {
                foreach (POSSalesDetails dtl in e.SelectedObjects)
                {
                    if (dtl.POSSales != null)
                    {
                        if (dtl.POSSales.Status != Status.Draft)
                        {
                            showMsg("Error", "Not allow delete item, SO already submit/cancel.", InformationType.Error);
                            return;
                        }
                    }

                    if (dtl.POSSales != null)
                    {
                        if (dtl.ItemCode.ItemCode == dtl.ItemFather)
                        {
                            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                            string selectbom = "EXEC sp_DeleteBOM '" + dtl.ItemCode.ItemCode + "', " + dtl.POSSales.Oid + ", '" + dtl.FatherKey + "'";
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(selectbom, conn);
                            SqlDataReader reader = cmd.ExecuteReader();
                            conn.Close();
                        }
                        else
                        {
                            showMsg("Warning", "Child item not allow to delete.", InformationType.Warning);
                        }
                    }
                    else
                    {
                        showMsg("Error", "Please save the document before proceed delete action.", InformationType.Error);
                        return;
                    }
                }

                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();
            }
            else
            {
                showMsg("Warning", "No Item selected.", InformationType.Warning);
            }
        }

        private void DeleteDetailItem_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace();
            DetailView dv = Application.CreateDetailView(os, os.CreateObject<Confirmation>(), true);
            dv.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            ((Confirmation)dv.CurrentObject).Message = "Do you want to proceed?";

            e.View = dv;
        }
    }
}
