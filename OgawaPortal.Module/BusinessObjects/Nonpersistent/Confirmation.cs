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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.BusinessObjects.Nonpersistent
{
    [DomainComponent]
    [NonPersistent]
    public class Confirmation : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Confirmation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [XafDisplayName("Message")]
        [Appearance("Message", Enabled = false)]
        public string Message { get; set; }

    }

    [DomainComponent]
    [NonPersistent]
    public class CancelConfirmation : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CancelConfirmation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [XafDisplayName("Cancel Type")]
        [DataSourceCriteria("IsActive = 'True'")]
        public CancelType CancelType { get; set; }

        [XafDisplayName("Reason")]
        public string Reason { get; set; }

        [XafDisplayName("Message")]
        [Appearance("Message", Enabled = false)]
        public string Message { get; set; }

    }

    [DomainComponent]
    [NonPersistent]
    public class CloseConfirmation : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CloseConfirmation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [XafDisplayName("Close Type")]
        [DataSourceCriteria("IsActive = 'True'")]
        public CloseType CloseType { get; set; }

        [XafDisplayName("Reason")]
        public string Reason { get; set; }

        [XafDisplayName("Message")]
        [Appearance("Message", Enabled = false)]
        public string Message { get; set; }

    }
}