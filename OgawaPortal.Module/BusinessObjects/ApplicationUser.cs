using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using OgawaPortal.Module.BusinessObjects.View;

namespace OgawaPortal.Module.BusinessObjects {
    [MapInheritance(MapInheritanceType.ParentTable)]
    [DefaultProperty(nameof(UserName))]
    public class ApplicationUser : PermissionPolicyUser, IObjectSpaceLink, ISecurityUserWithLoginInfo {
        public ApplicationUser(Session session) : base(session) { }

        [Browsable(false)]
        [Aggregated, Association("User-LoginInfo")]
        public XPCollection<ApplicationUserLoginInfo> LoginInfo {
            get { return GetCollection<ApplicationUserLoginInfo>(nameof(LoginInfo)); }
        }

        IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

        IObjectSpace IObjectSpaceLink.ObjectSpace { get; set; }

        ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey) {
            ApplicationUserLoginInfo result = ((IObjectSpaceLink)this).ObjectSpace.CreateObject<ApplicationUserLoginInfo>();
            result.LoginProviderName = loginProviderName;
            result.ProviderUserKey = providerUserKey;
            result.User = this;
            return result;
        }

        private vwOutlets _Outlet;
        [RuleRequiredField(DefaultContexts.Save)]
        [NoForeignKey]
        [DataSourceCriteria("GroupCode = '114'")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public vwOutlets Outlet
        {
            get { return _Outlet; }
            set
            {
                SetPropertyValue("Outlet", ref _Outlet, value);
            }

        }
        private string _PersonalName;
        [RuleRequiredField(DefaultContexts.Save)]
        [VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public string PersonalName
        {
            get { return _PersonalName; }
            set
            {
                SetPropertyValue("PersonalName", ref _PersonalName, value);
            }
        }
    }
}
