//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ceu_Education_MVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaymentReport
    {
        public int ID { get; set; }
        public Nullable<int> EventID { get; set; }
        public Nullable<System.DateTime> EventDate { get; set; }
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        public Nullable<int> FeeTypeID { get; set; }
        public Nullable<int> PaymentStatus { get; set; }
        public Nullable<int> PaymentMethodID { get; set; }
        public string PromoCode { get; set; }
        public string CredentialPharases { get; set; }
        public string CreditCardTransCode { get; set; }
        public string CreditCardRefundCode { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public Nullable<decimal> FeeDesc { get; set; }
        public Nullable<int> EnrollmentMasterID { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
    }
}
