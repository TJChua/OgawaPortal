using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using OgawaPortal.Module.BusinessObjects;
using OgawaPortal.Module.BusinessObjects.Exchange;
using OgawaPortal.Module.BusinessObjects.Logistic;
using OgawaPortal.Module.BusinessObjects.Maintenances;
using OgawaPortal.Module.BusinessObjects.POS___Logistic;
using OgawaPortal.Module.BusinessObjects.POS___Sales;
using OgawaPortal.Module.BusinessObjects.POS___Transfer;
using OgawaPortal.Module.BusinessObjects.Warehouse;
using OgawaPortal.Module.BusinessObjects.View;

namespace OgawaPortal.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FirstOrDefault<DomainObject1>(u => u.Name == name);
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
            ApplicationUser sampleUser = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "User");
            if(sampleUser == null) {
                sampleUser = ObjectSpace.CreateObject<ApplicationUser>();
                sampleUser.UserName = "User";
                // Set a password if the standard authentication type is used
                sampleUser.SetPassword("");

                // The UserLoginInfo object requires a user object Id (Oid).
                // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
                ObjectSpace.CommitChanges(); //This line persists created object(s).
                ((ISecurityUserWithLoginInfo)sampleUser).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(sampleUser));
            }
            PermissionPolicyRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            ApplicationUser userAdmin = ObjectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "Admin");
            if(userAdmin == null) {
                userAdmin = ObjectSpace.CreateObject<ApplicationUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");

                // The UserLoginInfo object requires a user object Id (Oid).
                // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
                ObjectSpace.CommitChanges(); //This line persists created object(s).
                ((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication, ObjectSpace.GetKeyValueAsString(userAdmin));
            }
			// If a role with the Administrators name doesn't exist in the database, create this role
            PermissionPolicyRole adminRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Administrators");
            if(adminRole == null) {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
			userAdmin.Roles.Add(adminRole);
            PermissionPolicyRole AccessRole = CreateAccessRole();
            ObjectSpace.CommitChanges(); //This line persists created object(s).
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        private PermissionPolicyRole CreateDefaultRole() {
            PermissionPolicyRole defaultRole = ObjectSpace.FirstOrDefault<PermissionPolicyRole>(role => role.Name == "Default");
            if(defaultRole == null) {
                defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                defaultRole.Name = "Default";

				defaultRole.AddObjectPermissionFromLambda<ApplicationUser>(SecurityOperations.Read, cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
				defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
				defaultRole.AddMemberPermissionFromLambda<ApplicationUser>(SecurityOperations.Write, "StoredPassword", cm => cm.Oid == (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
				defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
            }
            return defaultRole;
        }

        private PermissionPolicyRole CreateAccessRole()
        {
            PermissionPolicyRole AccessRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "AccessRole"));
            if (AccessRole == null)
            {
                AccessRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                AccessRole.Name = "AccessRole";

                AccessRole.AddObjectPermission<PermissionPolicyUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Allow);
                AccessRole.AddMemberPermission<ApplicationUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                AccessRole.AddMemberPermission<ApplicationUser>(SecurityOperations.Write, "StoredPassword", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);

                //SystemUsers
                AccessRole.AddTypePermissionsRecursively<ApplicationUser>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);

                //Exchange Out
                AccessRole.AddTypePermissionsRecursively<ExchangeOut>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOut>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOut>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOutDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOutDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOutDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOutPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOutPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeOutPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //Print GRN
                AccessRole.AddTypePermissionsRecursively<PrintGRN>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRN>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRN>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRNDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRNDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRNDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRNPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRNPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PrintGRNPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //Logistic
                AccessRole.AddTypePermissionsRecursively<PickListExhange>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExhange>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExhange>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExchangeDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExchangeDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExchangeDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExchangePayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExchangePayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListExchangePayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                AccessRole.AddTypePermissionsRecursively<PickListFullPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPaymentDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPaymentDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPaymentDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPaymentAttach>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPaymentAttach>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListFullPaymentAttach>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                AccessRole.AddTypePermissionsRecursively<PickListPartialPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPaymentDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPaymentDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPaymentDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPaymentAttach>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPaymentAttach>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListPartialPaymentAttach>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //Maintenances
                AccessRole.AddTypePermissionsRecursively<CancelType>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CancelType>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CancelType>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardIssuer>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardIssuer>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardIssuer>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardMachineBank>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardMachineBank>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardMachineBank>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardType>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardType>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CardType>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CloseType>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CloseType>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<CloseType>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Consignment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Consignment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Consignment>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Customer>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Customer>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Customer>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryDateControl>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryDateControl>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryDateControl>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Discount>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Discount>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Discount>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DiscountControl>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DiscountControl>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DiscountControl>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DiscountType>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DiscountType>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DiscountType>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeType>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeType>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeType>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<GSTDates>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<GSTDates>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<GSTDates>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Instalment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Instalment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Instalment>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Races>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Races>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Races>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Translate>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Translate>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Translate>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Transporter>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Transporter>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Transporter>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Voucher>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Voucher>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<Voucher>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //POS - Logistic
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReq>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReq>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReq>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReqDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReqDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReqDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReqPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReqPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<ExchangeDeliveryReqPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReq>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReq>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReq>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqAttach>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqAttach>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FullPaymentDeliveryReqAttach>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReq>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReq>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReq>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqAttach>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqAttach>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PartialPaymentDeliveryReqAttach>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //POS - Sales
                AccessRole.AddTypePermissionsRecursively<POSSales>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSales>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSales>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSalesDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSalesDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSalesDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSalesPayment>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSalesPayment>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<POSSalesPayment>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //POS - Transfer
                AccessRole.AddTypePermissionsRecursively<TransferIn>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferIn>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferIn>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferInDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferInDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferInDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferOut>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferOut>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferOut>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferOutDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferOutDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferOutDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //Warehouse
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderFull>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderFull>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderFull>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderFullDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderFullDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderFullDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderPartial>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderPartial>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderPartial>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderPartialDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderPartialDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<DeliveryOrderPartialDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                AccessRole.AddTypePermissionsRecursively<PickListTransferIn>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferIn>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferIn>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferInDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferInDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferInDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferOut>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferOut>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferOut>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferOutDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferOutDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<PickListTransferOutDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferPickList>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferPickList>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferPickList>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferPickListDetails>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferPickListDetails>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<TransferPickListDetails>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //View
                AccessRole.AddTypePermissionsRecursively<vwItemMasters>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<vwOutlets>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<vwPrice>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<vwSalesRep>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<vwTax>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<vwWarehouse>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);

                //File data
                AccessRole.AddTypePermissionsRecursively<FileData>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FileData>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FileData>(SecurityOperations.Delete, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FileAttachmentBase>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FileAttachmentBase>(SecurityOperations.Create, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<FileAttachmentBase>(SecurityOperations.Delete, SecurityPermissionState.Allow);

                //Audit Trail
                AccessRole.AddTypePermissionsRecursively<AuditDataItemPersistent>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                AccessRole.AddTypePermissionsRecursively<AuditedObjectWeakReference>(SecurityOperations.Create, SecurityPermissionState.Allow);
            }

            return AccessRole;
        }
    }
}
