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
using OgawaPortal.Module.BusinessObjects.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OgawaPortal.Module.BusinessObjects.POS___Sales
{
    [DefaultClassOptions]
    [NavigationItem("POS - Sales")]
    [XafDisplayName("POS Sales")]
    [DefaultProperty("DocNum")]
    [Appearance("HideDelete", AppearanceItemType = "Action", TargetItems = "Delete", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSalesSubmit", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesGoodsReturn", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "ListView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideAddItemSales1", AppearanceItemType.Action, "True", TargetItems = "AddItem", Criteria = "not (Status in (0))", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]
    [Appearance("HideSalesSubmit1", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Criteria = "not (Status in (0))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel1", AppearanceItemType = "Action", TargetItems = "CancelOrder", Criteria = "not (Status in (0))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose1", AppearanceItemType = "Action", TargetItems = "CloseOrder", Criteria = "not (Status in (1))", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEdit1", AppearanceItemType.Action, "True", TargetItems = "SwitchToEditMode; Edit", Criteria = "not (Status in (0))", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "Any")]

    [Appearance("HideSalesGoodsReturnDT", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOutDT", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrderDT", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrderDT", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDRDT", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDRDT", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDRDT", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFullDT", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartialDT", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchangeDT", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Goods Return
    [Appearance("HideNewGRNL2", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_GRN")]
    [Appearance("HideAddItemSalesL2", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_GRN")]

    [Appearance("HideNewGRN2", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_GRN")]
    [Appearance("HideAddItemSales2", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_GRN")]
    [Appearance("HideSalesSubmit2", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel2", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose2", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave2", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideResumeOrder2", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder2", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut2", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR2", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR2", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDRD2", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull2", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial2", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange2", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_GRN", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Resume Back Order
    [Appearance("HideNewRsmBL3", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_RsmBackOrder")]
    [Appearance("HideAddItemSalesL3", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_RsmBackOrder")]

    [Appearance("HideNewRsmB3", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_RsmBackOrder")]
    [Appearance("HideAddItemSales3", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_RsmBackOrder")]
    [Appearance("HideSalesSubmit3", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel3", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose3", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave3", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideEditRsmBL3", AppearanceItemType.Action, "True", TargetItems = "SwitchToEditMode; Edit", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_RsmBackOrder")]

    [Appearance("HideSalesGoodsReturn3", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut3", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder3", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR3", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR3", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR3", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull3", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial3", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange3", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_RsmBackOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Edit Order
    [Appearance("HideNewEditItemL4", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_EditOrder")]
    [Appearance("HideAddItemSalesL4", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_EditOrder")]

    [Appearance("HideNewEditItem4", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_EditOrder")]
    [Appearance("HideAddItemSales4", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_EditOrder")]
    [Appearance("HideSalesSubmit4", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel4", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose4", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    //[Appearance("HideSalesSave4", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideEdit4", AppearanceItemType.Action, "True", TargetItems = "SwitchToEditMode; Edit", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_EditOrder")]

    [Appearance("HideSalesGoodsReturn4", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut4", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder4", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR4", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR4", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR4", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull4", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial4", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange4", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_EditOrder", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // POS - Logistic
    [Appearance("HideNewLogisticL5", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_Logistic")]
    [Appearance("HideAddItemSalesL5", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_Logistic")]

    [Appearance("HideNewLogistic5", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_Logistic")]
    [Appearance("HideAddItemSales5", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_Logistic")]
    [Appearance("HideSalesSubmit5", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel5", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose5", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave5", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSalesGoodsReturn5", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut5", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder5", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder5", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull5", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial5", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange5", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_Logistic", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Logistic Full
    [Appearance("HideNewLL6", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_PickListFull")]
    [Appearance("HideAddItemLL6", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_PickListFull")]

    [Appearance("HideNewL6", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_PickListFull")]
    [Appearance("HideAddItemSales6", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_PickListFull")]
    [Appearance("HideSalesSubmit6", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel6", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose6", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave6", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSalesGoodsReturn6", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut6", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder6", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR6", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR6", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR6", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder6", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial6", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange6", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_PickListFull", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Logistic Partial
    [Appearance("HideNewLLP7", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_PickListPartial")]
    [Appearance("HideAddItemLLP7", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_PickListPartial")]

    [Appearance("HideNewLP7", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_PickListPartial")]
    [Appearance("HideAddItemSales7", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_PickListPartial")]
    [Appearance("HideSalesSubmit7", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel7", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose7", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave7", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSalesGoodsReturn7", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut7", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder7", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR7", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR7", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR7", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder7", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull7", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange7", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_PickListPartial", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Logistic Exchange
    [Appearance("HideNewLLP8", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_PickListEx")]
    [Appearance("HideAddItemLLP8", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_PickListEx")]

    [Appearance("HideNewLP8", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_PickListEx")]
    [Appearance("HideAddItemSales8", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_PickListEx")]
    [Appearance("HideSalesSubmit8", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel8", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose8", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave8", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSalesGoodsReturn8", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesExchangeOut8", AppearanceItemType = "Action", TargetItems = "SalesExchangeOut", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder8", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR8", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR8", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR8", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder8", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial8", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull8", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_PickListEx", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    // Sales Exchange Out
    [Appearance("HideNewLLP9", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_ExchangeOut")]
    [Appearance("HideAddItemLLP9", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_ListView_ExchangeOut")]

    [Appearance("HideNewLP9", AppearanceItemType.Action, "True", TargetItems = "New", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_ExchangeOut")]
    [Appearance("HideAddItemSales9", AppearanceItemType.Action, "True", TargetItems = "AddItem", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Context = "POSSales_DetailView_ExchangeOut")]
    [Appearance("HideSalesSubmit9", AppearanceItemType = "Action", TargetItems = "SubmitOrder", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesCancel9", AppearanceItemType = "Action", TargetItems = "CancelOrder", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesClose9", AppearanceItemType = "Action", TargetItems = "CloseOrder", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesSave9", AppearanceItemType = "Action", TargetItems = "Save", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    [Appearance("HideSalesGoodsReturn9", AppearanceItemType = "Action", TargetItems = "SalesGoodsReturn", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideResumeOrder9", AppearanceItemType = "Action", TargetItems = "ResumeOrder", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideFullPaymentDR9", AppearanceItemType = "Action", TargetItems = "FullPaymentDR", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HidePartialPaymentDR9", AppearanceItemType = "Action", TargetItems = "PartialPaymentDR", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideExchangeDR9", AppearanceItemType = "Action", TargetItems = "ExchangeDR", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideSalesEditOrder9", AppearanceItemType = "Action", TargetItems = "SalesEditOrder", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticPartial9", AppearanceItemType = "Action", TargetItems = "LogisticPartialPayment", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticFull9", AppearanceItemType = "Action", TargetItems = "LogisticFullPayment", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]
    [Appearance("HideLogisticExchange9", AppearanceItemType = "Action", TargetItems = "LogisticExchange", Context = "POSSales_DetailView_ExchangeOut", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide)]

    public class POSSales : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public POSSales(Session session)
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
            SalesOrderDate = DateTime.Now;
            Status = Status.Draft;
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

        private string _DocNum;
        [Index(0), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [XafDisplayName("Document No")]
        [Appearance("DocNum", Enabled = false)]
        public string DocNum
        {
            get
            {
                int Number = 1000000 + Oid;
                _DocNum = Number.ToString();
                return _DocNum;
            }
        }

        private DateTime _SalesOrderDate;
        [XafDisplayName("Sales Order Date")]
        [Index(2), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("SalesOrderDate", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("SalesOrderDate1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public DateTime SalesOrderDate
        {
            get { return _SalesOrderDate; }
            set
            {
                SetPropertyValue("SalesOrderDate", ref _SalesOrderDate, value);
            }
        }

        private string _SalesRefNo;
        [XafDisplayName("Sales Ref No")]
        [Index(5), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("SalesRefNo", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("SalesRefNo1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string SalesRefNo
        {
            get { return _SalesRefNo; }
            set
            {
                SetPropertyValue("SalesRefNo", ref _SalesRefNo, value);
            }
        }

        private Status _Status;
        [XafDisplayName("Status")]
        [Appearance("Status", Enabled = false)]
        [Index(6), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        public Status Status
        {
            get { return _Status; }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }

        private CancelType _CancelType;
        [XafDisplayName("Cancel Type")]
        [Index(7), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("CancelType", Enabled = false)]
        public CancelType CancelType
        {
            get { return _CancelType; }
            set
            {
                SetPropertyValue("CancelType", ref _CancelType, value);
            }
        }

        private CloseType _CloseType;
        [XafDisplayName("Close Type")]
        [Index(8), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("CloseType", Enabled = false)]
        public CloseType CloseType
        {
            get { return _CloseType; }
            set
            {
                SetPropertyValue("CloseType", ref _CloseType, value);
            }
        }

        private string _Reason;
        [Index(9), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("Reason", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Reason1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string Reason
        {
            get { return _Reason; }
            set
            {
                SetPropertyValue("Reason", ref _Reason, value);
            }
        }

        private string _Remarks;
        [Index(10), VisibleInListView(true), VisibleInDetailView(true), VisibleInLookupListView(true)]
        [Appearance("Remarks", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Remarks1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string Remarks
        {
            get { return _Remarks; }
            set
            {
                SetPropertyValue("Remarks", ref _Remarks, value);
            }
        }

        private string _BaseNum;
        [Index(11), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [Appearance("BaseNum", Enabled = false)]
        public string BaseNum
        {
            get { return _BaseNum; }
            set
            {
                SetPropertyValue("BaseNum", ref _BaseNum, value);
            }
        }

        // Customer
        private Customer _Name;
        [ImmediatePostData]
        [XafDisplayName("Cusotmer Name")]
        [RuleRequiredField(DefaultContexts.Save)]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(12), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Name", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Name1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public Customer Name
        {
            get { return _Name; }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
                if (!IsLoading && value != null)
                {
                    Address1 = Name.Address1;
                    Address2 = Name.Address2;
                    City = Name.City;
                    District = Name.District;
                    PostCode = Name.PostCode;
                    Country = Name.Country;
                    MobilePhone = Name.MobilePhone;
                    HomePhone = Name.HomePhone;
                    Email = Name.Email;
                    Race = Name.Race;

                    //Bill
                    BillName = value;
                    BillAddress1 = Name.Address1;
                    BillAddress2 = Name.Address2;
                    BillCity = Name.City;
                    BillDistrict = Name.District;
                    BillPostCode = Name.PostCode;
                    BillCountry = Name.Country;
                    BillMobilePhone = Name.MobilePhone;
                    BillHomePhone = Name.HomePhone;
                    BillEmail = Name.Email;
                    BillRace = Name.Race;

                    //Delivery
                    DeliveryContact = value;
                    DeliveryAddress1 = Name.Address1;
                    DeliveryAddress2 = Name.Address2;
                    DeliveryCity = Name.City;
                    DeliveryDistrict = Name.District;
                    DeliveryPostCode = Name.PostCode;
                    DeliveryCountry = Name.Country;
                    DeliveryMobilePhone = Name.MobilePhone;
                    DeliveryHomePhone = Name.HomePhone;
                    DeliveryRace = Name.Race;
                }
                else if (!IsLoading && value == null)
                {
                    Address1 = null;
                    Address2 = null;
                    City = null;
                    District = 0;
                    PostCode = null;
                    Country = 0;
                    MobilePhone = null;
                    HomePhone = null;
                    Email = null;
                    Race = null;

                    //Bill
                    BillName = null;
                    BillAddress1 = null;
                    BillAddress2 = null;
                    BillCity = null;
                    BillDistrict = 0;
                    BillPostCode = null;
                    BillCountry = 0;
                    BillMobilePhone = null;
                    BillHomePhone = null;
                    BillEmail = null;
                    BillRace = null;

                    //Delivery
                    DeliveryContact = null;
                    DeliveryAddress1 = null;
                    DeliveryAddress2 = null;
                    DeliveryCity = null;
                    DeliveryDistrict = 0;
                    DeliveryPostCode = null;
                    DeliveryCountry = 0;
                    DeliveryMobilePhone = null;
                    DeliveryHomePhone = null;
                    DeliveryRace = null;
                }
            }
        }

        private string _Address1;
        [XafDisplayName("Address1")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(13), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Address1", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Address11", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string Address1
        {
            get { return _Address1; }
            set
            {
                SetPropertyValue("Address1", ref _Address1, value);
            }
        }

        private string _Address2;
        [XafDisplayName("Address2")]
        [Index(15), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Address2", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Address21", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string Address2
        {
            get { return _Address2; }
            set
            {
                SetPropertyValue("Address2", ref _Address2, value);
            }
        }

        private string _City;
        [XafDisplayName("City")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(18), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("City", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("City1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string City
        {
            get { return _City; }
            set
            {
                SetPropertyValue("City", ref _City, value);
            }
        }

        private District _District;
        [XafDisplayName("District/State")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(20), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("District", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("District1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public District District
        {
            get { return _District; }
            set
            {
                SetPropertyValue("District", ref _District, value);
            }
        }

        private string _PostCode;
        [XafDisplayName("PostCode")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(15), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("PostCode", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("PostCode1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string PostCode
        {
            get { return _PostCode; }
            set
            {
                SetPropertyValue("PostCode", ref _PostCode, value);
            }
        }

        private CountryList _Country;
        [XafDisplayName("Country")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(22), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Country", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Country1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public CountryList Country
        {
            get { return _Country; }
            set
            {
                SetPropertyValue("Country", ref _Country, value);
            }
        }

        private string _MobilePhone;
        [XafDisplayName("Mobile Phone")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(25), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("MobilePhone", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("MobilePhone1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string MobilePhone
        {
            get { return _MobilePhone; }
            set
            {
                SetPropertyValue("MobilePhone", ref _MobilePhone, value);
            }
        }

        private string _HomePhone;
        [XafDisplayName("Home Phone")]
        [Index(28), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("HomePhone", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("HomePhone1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string HomePhone
        {
            get { return _HomePhone; }
            set
            {
                SetPropertyValue("HomePhone", ref _HomePhone, value);
            }
        }

        private string _Email;
        [XafDisplayName("Email")]
        [Index(30), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Email", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Email1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string Email
        {
            get { return _Email; }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }

        private string _IdentityNo;
        [XafDisplayName("Identity No/D.O.B")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ImmediatePostData]
        [Index(32), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("IdentityNo", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("IdentityNo1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string IdentityNo
        {
            get { return _IdentityNo; }
            set
            {
                SetPropertyValue("IdentityNo", ref _IdentityNo, value);
            }
        }

        private Races _Race;
        [XafDisplayName("Race")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(35), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("Race", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("Race1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public Races Race
        {
            get { return _Race; }
            set
            {
                SetPropertyValue("Race", ref _Race, value);
            }
        }

        // Billing
        private Customer _BillName;
        [ImmediatePostData]
        [XafDisplayName("Customer Name")]
        [RuleRequiredField(DefaultContexts.Save)]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(38), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillName", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillName1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public Customer BillName
        {
            get { return _BillName; }
            set
            {
                SetPropertyValue("BillName", ref _BillName, value);
            }
        }

        private string _BillAddress1;
        [XafDisplayName("Address1")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(40), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillAddress1", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillAddress11", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillAddress1
        {
            get { return _BillAddress1; }
            set
            {
                SetPropertyValue("BillAddress1", ref _BillAddress1, value);
            }
        }

        private string _BillAddress2;
        [XafDisplayName("Address2")]
        [Index(42), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillAddress2", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillAddress21", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillAddress2
        {
            get { return _BillAddress2; }
            set
            {
                SetPropertyValue("BillAddress2", ref _BillAddress2, value);
            }
        }

        private string _BillCity;
        [XafDisplayName("City")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(45), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillCity", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillCity1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillCity
        {
            get { return _BillCity; }
            set
            {
                SetPropertyValue("BillCity", ref _BillCity, value);
            }
        }

        private District _BillDistrict;
        [XafDisplayName("District/State bill")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(47), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillDistrict", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillDistrict1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public District BillDistrict
        {
            get { return _BillDistrict; }
            set
            {
                SetPropertyValue("BillDistrict", ref _BillDistrict, value);
            }
        }

        private string _BillPostCode;
        [XafDisplayName("PostCode")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(50), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillPostCode", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillPostCode1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillPostCode
        {
            get { return _BillPostCode; }
            set
            {
                SetPropertyValue("BillPostCode", ref _BillPostCode, value);
            }
        }

        private CountryList _BillCountry;
        [XafDisplayName("Country bill")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(52), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillCountry", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillCountry1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public CountryList BillCountry
        {
            get { return _BillCountry; }
            set
            {
                SetPropertyValue("BillCountry", ref _BillCountry, value);
            }
        }

        private string _BillMobilePhone;
        [XafDisplayName("Mobile Phone")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(55), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillMobilePhone", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillMobilePhone1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillMobilePhone
        {
            get { return _BillMobilePhone; }
            set
            {
                SetPropertyValue("BillMobilePhone", ref _BillMobilePhone, value);
            }
        }

        private string _BillHomePhone;
        [XafDisplayName("Home Phone")]
        [Index(57), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillHomePhone", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillHomePhone1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillHomePhone
        {
            get { return _BillHomePhone; }
            set
            {
                SetPropertyValue("BillHomePhone", ref _BillHomePhone, value);
            }
        }

        private string _BillEmail;
        [XafDisplayName("Email")]
        [Index(60), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillEmail", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillEmail1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillEmail
        {
            get { return _BillEmail; }
            set
            {
                SetPropertyValue("BillEmail", ref _BillEmail, value);
            }
        }

        private string _BillIdentityNo;
        [XafDisplayName("Identity No/D.O.B")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ImmediatePostData]
        [Index(62), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillIdentityNo", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillIdentityNo1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string BillIdentityNo
        {
            get { return _BillIdentityNo; }
            set
            {
                SetPropertyValue("BillIdentityNo", ref _BillIdentityNo, value);
            }
        }

        private Races _BillRace;
        [XafDisplayName("Race Bill")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(65), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("BillRace", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("BillRace1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public Races BillRace
        {
            get { return _BillRace; }
            set
            {
                SetPropertyValue("BillRace", ref _BillRace, value);
            }
        }

        // Delivery
        private Customer _DeliveryContact;
        [ImmediatePostData]
        [XafDisplayName("Contact")]
        [RuleRequiredField(DefaultContexts.Save)]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(67), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryContact", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryContact1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public Customer DeliveryContact
        {
            get { return _DeliveryContact; }
            set
            {
                SetPropertyValue("DeliveryContact", ref _DeliveryContact, value);
            }
        }

        private string _DeliveryAddress1;
        [XafDisplayName("Address1")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(70), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryAddress1", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryAddress11", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string DeliveryAddress1
        {
            get { return _DeliveryAddress1; }
            set
            {
                SetPropertyValue("DeliveryAddress1", ref _DeliveryAddress1, value);
            }
        }

        private string _DeliveryAddress2;
        [XafDisplayName("Address2")]
        [Index(72), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryAddress2", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryAddress21", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string DeliveryAddress2
        {
            get { return _DeliveryAddress2; }
            set
            {
                SetPropertyValue("DeliveryAddress2", ref _DeliveryAddress2, value);
            }
        }

        private string _DeliveryCity;
        [XafDisplayName("City")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(75), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryCity", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryCity1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string DeliveryCity
        {
            get { return _DeliveryCity; }
            set
            {
                SetPropertyValue("DeliveryCity", ref _DeliveryCity, value);
            }
        }

        private District _DeliveryDistrict;
        [XafDisplayName("District/State")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(77), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryDistrict", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryDistrict1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public District DeliveryDistrict
        {
            get { return _DeliveryDistrict; }
            set
            {
                SetPropertyValue("DeliveryDistrict", ref _DeliveryDistrict, value);
            }
        }

        private string _DeliveryPostCode;
        [XafDisplayName("PostCode")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(80), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryPostCode", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryPostCode1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string DeliveryPostCode
        {
            get { return _DeliveryPostCode; }
            set
            {
                SetPropertyValue("DeliveryPostCode", ref _DeliveryPostCode, value);
            }
        }

        private CountryList _DeliveryCountry;
        [XafDisplayName("Country")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(82), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryCountry", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryCountry1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public CountryList DeliveryCountry
        {
            get { return _DeliveryCountry; }
            set
            {
                SetPropertyValue("DeliveryCountry", ref _DeliveryCountry, value);
            }
        }

        private string _DeliveryMobilePhone;
        [XafDisplayName("Mobile Phone")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(85), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryMobilePhone", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryMobilePhone1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string DeliveryMobilePhone
        {
            get { return _DeliveryMobilePhone; }
            set
            {
                SetPropertyValue("DeliveryMobilePhone", ref _DeliveryMobilePhone, value);
            }
        }

        private string _DeliveryHomePhone;
        [XafDisplayName("Home Phone")]
        [Index(87), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryHomePhone", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryHomePhone1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public string DeliveryHomePhone
        {
            get { return _DeliveryHomePhone; }
            set
            {
                SetPropertyValue("DeliveryHomePhone", ref _DeliveryHomePhone, value);
            }
        }

        private Races _DeliveryRace;
        [XafDisplayName("Race")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Index(90), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("DeliveryRace", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DeliveryRace1", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public Races DeliveryRace
        {
            get { return _DeliveryRace; }
            set
            {
                SetPropertyValue("DeliveryRace", ref _DeliveryRace, value);
            }
        }

        // Sales Rep
        private vwSalesRep _SalesRep1;
        [NoForeignKey]
        [ImmediatePostData]
        [DataSourceCriteria("Active = 'Y'")]
        [XafDisplayName("Sales Rep 1")]
        [RuleRequiredField(DefaultContexts.Save)]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(93), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("SalesRep1", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("SalesRep11", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public vwSalesRep SalesRep1
        {
            get { return _SalesRep1; }
            set
            {
                SetPropertyValue("SalesRep1", ref _SalesRep1, value);
            }
        }

        private vwSalesRep _SalesRep2;
        [NoForeignKey]
        [DataSourceCriteria("Active = 'Y'")]
        [XafDisplayName("Sales Rep 2")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(94), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("SalesRep2", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("SalesRep21", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public vwSalesRep SalesRep2
        {
            get { return _SalesRep2; }
            set
            {
                SetPropertyValue("SalesRep2", ref _SalesRep2, value);
            }
        }

        private vwSalesRep _SalesRep3;
        [NoForeignKey]
        [DataSourceCriteria("Active = 'Y'")]
        [XafDisplayName("Sales Rep 3")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(95), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("SalesRep3", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("SalesRep31", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public vwSalesRep SalesRep3
        {
            get { return _SalesRep3; }
            set
            {
                SetPropertyValue("SalesRep3", ref _SalesRep3, value);
            }
        }

        private vwSalesRep _SalesRep4;
        [NoForeignKey]
        [DataSourceCriteria("Active = 'Y'")]
        [XafDisplayName("Sales Rep 4")]
        [LookupEditorMode(LookupEditorMode.AllItems)]
        [Index(96), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [Appearance("SalesRep4", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("SalesRep41", Enabled = false, Criteria = "not (Status in (0, 3))")]
        public vwSalesRep SalesRep4
        {
            get { return _SalesRep4; }
            set
            {
                SetPropertyValue("SalesRep4", ref _SalesRep4, value);
            }
        }

        //Payment
        private decimal _SubTotal;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("SubTotal", Enabled = false)]
        [Index(102), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Sub Total")]
        public decimal SubTotal
        {
            get { return _SubTotal; }
            set
            {
                SetPropertyValue("SubTotal", ref _SubTotal, value);
            }
        }

        private decimal _OrderDiscount;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("OrderDiscount", Enabled = false)]
        [Index(105), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Order Discount")]
        public decimal OrderDiscount
        {
            get { return _OrderDiscount; }
            set
            {
                SetPropertyValue("OrderDiscount", ref _OrderDiscount, value);
            }
        }

        private decimal _Tax;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("Tax", Enabled = false)]
        [Index(108), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Tax")]
        public decimal Tax
        {
            get { return _Tax; }
            set
            {
                SetPropertyValue("Tax", ref _Tax, value);
            }
        }

        private decimal _TotalDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("TotalDue", Enabled = false)]
        [Index(110), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Total Due")]
        public decimal TotalDue
        {
            get { return _TotalDue; }
            set
            {
                SetPropertyValue("TotalDue", ref _TotalDue, value);
            }
        }

        private decimal _SettlementDiscount;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("SettlementDiscount", Enabled = false)]
        [Index(112), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Settlement Discount")]
        public decimal SettlementDiscount
        {
            get { return _SettlementDiscount; }
            set
            {
                SetPropertyValue("SettlementDiscount", ref _SettlementDiscount, value);
            }
        }

        private decimal _NetTotalDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("NetTotalDue", Enabled = false)]
        [Index(115), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Net Total Due")]
        public decimal NetTotalDue
        {
            get { return _NetTotalDue; }
            set
            {
                SetPropertyValue("NetTotalDue", ref _NetTotalDue, value);
            }
        }

        private decimal _Cash;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("Cash", Enabled = false)]
        [Index(118), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Cash")]
        public decimal Cash
        {
            get
            {
                if (Session.IsObjectsSaving != true)
                {
                    decimal rtn = 0;
                    if (PaymentDetailsBO != null)
                        rtn += PaymentDetailsBO.Sum(p => p.CashAmount);

                    return rtn;
                }
                else
                {
                    return _Cash;
                }
            }
            set
            {
                SetPropertyValue("Cash", ref _Cash, value);
            }
        }

        private decimal _CreditCard;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("CreditCard", Enabled = false)]
        [Index(120), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Credit Card")]
        public decimal CreditCard
        {
            get
            {
                if (Session.IsObjectsSaving != true)
                {
                    decimal rtn = 0;
                    if (PaymentDetailsBO != null)
                        rtn += PaymentDetailsBO.Sum(p => p.CreditCardAmount);

                    return rtn;
                }
                else
                {
                    return _CreditCard;
                }
            }
            set
            {
                SetPropertyValue("CreditCard", ref _CreditCard, value);
            }
        }

        private decimal _Voucher;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("Voucher", Enabled = false)]
        [Index(122), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Voucher")]
        public decimal Voucher
        {
            get
            {
                if (Session.IsObjectsSaving != true)
                {
                    decimal rtn = 0;
                    if (PaymentDetailsBO != null)
                        rtn += PaymentDetailsBO.Sum(p => p.VoucherAmount);

                    return rtn;
                }
                else
                {
                    return _Voucher;
                }
            }
            set
            {
                SetPropertyValue("Voucher", ref _Voucher, value);
            }
        }

        private decimal _CreditNote;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("CreditNote", Enabled = false)]
        [Index(125), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Credit Note")]
        public decimal CreditNote
        {
            get { return _CreditNote; }
            set
            {
                SetPropertyValue("CreditNote", ref _CreditNote, value);
            }
        }

        private decimal _PreviousPayment;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("PreviousPayment", Enabled = false)]
        [Index(128), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Previous Payment")]
        public decimal PreviousPayment
        {
            get { return _PreviousPayment; }
            set
            {
                SetPropertyValue("PreviousPayment", ref _PreviousPayment, value);
            }
        }

        private decimal _TotalPayment;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("TotalPayment", Enabled = false)]
        [Index(130), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Total Payment")]
        public decimal TotalPayment
        {
            get { return _TotalPayment; }
            set
            {
                SetPropertyValue("TotalPayment", ref _TotalPayment, value);
            }
        }

        private decimal _OrderBalanceDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("OrderBalanceDue", Enabled = false)]
        [Index(132), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Order Balance Due")]
        public decimal OrderBalanceDue
        {
            get { return _OrderBalanceDue; }
            set
            {
                SetPropertyValue("OrderBalanceDue", ref _OrderBalanceDue, value);
            }
        }

        private decimal _MinimumDue;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("MinimumDue", Enabled = false)]
        [Index(135), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Minimum Due")]
        public decimal MinimumDue
        {
            get { return _MinimumDue; }
            set
            {
                SetPropertyValue("MinimumDue", ref _MinimumDue, value);
            }
        }

        private decimal _MinDueBalance;
        [ImmediatePostData]
        [DbType("numeric(19,6)")]
        [ModelDefault("DisplayFormat", "n2")]
        [ModelDefault("EditMask", "n2")]
        [Appearance("MinDueBalance", Enabled = false)]
        [Index(138), VisibleInListView(false), VisibleInDetailView(true), VisibleInLookupListView(false)]
        [XafDisplayName("Min. Due Balance")]
        public decimal MinDueBalance
        {
            get { return _MinDueBalance; }
            set
            {
                SetPropertyValue("MinDueBalance", ref _MinDueBalance, value);
            }
        }

        private bool _EditAndCancel;
        [Appearance("EditAndCancel", Enabled = false)]
        [Index(700), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [XafDisplayName("EditAndCancel")]
        public bool EditAndCancel
        {
            get { return _EditAndCancel; }
            set
            {
                SetPropertyValue("EditAndCancel", ref _EditAndCancel, value);
            }
        }

        private bool _ResumeOrder;
        [Appearance("ResumeOrder", Enabled = false)]
        [Index(701), VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [XafDisplayName("ResumeOrder")]
        public bool ResumeOrder
        {
            get { return _ResumeOrder; }
            set
            {
                SetPropertyValue("ResumeOrder", ref _ResumeOrder, value);
            }
        }

        [Browsable(false)]
        public bool IsNew
        {
            get
            { return Session.IsNewObject(this); }
        }

        [Browsable(false)]
        public bool IsValid
        {
            get
            {
                if (this.Name == null || this.Address1 == null || this.City == null || this.District == District.blank ||
                    this.PostCode == null || Country == CountryList.blank || this.MobilePhone == null || this.IdentityNo == null || this.Race == null ||
                    this.BillName == null || this.BillAddress1 == null || this .BillCity == null || this.BillDistrict == District.blank || 
                    this.BillPostCode == null || this.BillCountry == CountryList.blank || this.BillMobilePhone == null || this.BillIdentityNo == null || 
                    this.BillRace == null || this. DeliveryContact == null || this.DeliveryAddress1 == null || this.DeliveryCountry == CountryList.blank || 
                    this.DeliveryMobilePhone == null || this.DeliveryRace == null || this.SalesRep1 == null)
                {
                    return true;
                }

                return false;
            }
        }

        [Association("POSSales-DetailsBO")]
        [XafDisplayName("Items")]
        [Appearance("DetailsBO", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("DetailsBO1", Enabled = false, Criteria = "not (Status in (0, 3)) and not ResumeOrder")]
        public XPCollection<POSSalesDetails> DetailsBO
        {
            get { return GetCollection<POSSalesDetails>("DetailsBO"); }
        }

        [Association("POSSales-PaymentDetailsBO")]
        [XafDisplayName("Payment")]
        [Appearance("PaymentDetailsBO", Enabled = false, Context = "POSSales_DetailView_GRN")]
        [Appearance("PaymentDetailsBO1", Enabled = false, Criteria = "not (Status in (0, 3)) and not ResumeOrder")]
        public XPCollection<POSSalesPayment> PaymentDetailsBO
        {
            get { return GetCollection<POSSalesPayment>("PaymentDetailsBO"); }
        }

        private XPCollection<AuditDataItemPersistent> auditTrail;
        public XPCollection<AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (auditTrail == null)
                {
                    auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return auditTrail;
            }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (!(Session is NestedUnitOfWork)
                && (Session.DataLayer != null)
                    && (Session.ObjectLayer is SimpleObjectLayer)
                        )
            {
                ApplicationUser user = (ApplicationUser)SecuritySystem.CurrentUser;
                if (user != null)
                {
                    UpdateUser = Session.GetObjectByKey<ApplicationUser>(user.Oid);
                }
                UpdateDate = DateTime.Now;
            }
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            this.Reload();
        }
    }
}