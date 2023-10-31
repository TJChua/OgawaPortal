using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
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

namespace OgawaPortal.Module.BusinessObjects
{
    public enum Language
    {
        Default = 0,
        Chinese = 1
    }

    public enum District
    {
        [XafDisplayName("N/A")] blank = 0,
        Johor = 1,
        Kedah = 2,
        Kelantan = 3,
        [XafDisplayName("Kuala Lumpur")] KL = 4,
        Melaka = 5,
        [XafDisplayName("Negeri Sembilan")] NS = 6,
        Others = 7,
        Overseas = 8,
        Pahang = 9,
        Perak = 10,
        Perlis = 11,
        [XafDisplayName("Pulau Pinang")] PP = 12,
        Sabah = 13,
        Sarawak = 14,
        Selangor = 15,
        Terengganu = 16,
        [XafDisplayName("Wilayah Persekutuan Labuan")] WPL = 17,
        [XafDisplayName("Wilayah Persekutuan Putrajaya")] WPP = 18
    }

    public enum CountryList
    {
        [XafDisplayName("N/A")] blank = 0,
        China = 1,
        [XafDisplayName("Hong Kong")] HK = 2,
        Malaysia = 3,
        Others = 4,
        Philippines = 5,
        Singapore = 6,
        Vietnam
    }

    public enum Status
    {
        Draft = 0,
        Submit = 1,
        Cancel = 2,
        Posted = 3,
        Closed = 4,
        Transfered = 5,
        Released = 6,
        [XafDisplayName("Full Payment")] Full = 7,
        [XafDisplayName("Partial Payment")] Partial = 8,
        [XafDisplayName("Open")] TransferOpen = 9

    }

    public enum PaymentMethod
    {
        Cash = 0,
        [XafDisplayName("Credit Card")] CC = 1,
        Voucher = 2
    }
}