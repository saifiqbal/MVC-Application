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
    
    public partial class tbl_Organizations
    {
        public tbl_Organizations()
        {
            this.tbl_Conference_Sponsors = new HashSet<tbl_Conference_Sponsors>();
            this.tbl_Course_Sponsors = new HashSet<tbl_Course_Sponsors>();
            this.tbl_Issuers = new HashSet<tbl_Issuers>();
            this.tbl_Person_Organization_Roles = new HashSet<tbl_Person_Organization_Roles>();
            this.tbl_Providers = new HashSet<tbl_Providers>();
        }
    
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Nullable<System.Guid> OrganizationGUID { get; set; }
        public int Business_MunicipalityID { get; set; }
        public string Business_StreetName { get; set; }
        public decimal Business_BuildingNumber { get; set; }
        public string Business_Unit { get; set; }
        public string Business_Zipcode { get; set; }
        public string Business_Zipcode4 { get; set; }
        public int Mailing_MunicipalityID { get; set; }
        public string Mailing_StreetName { get; set; }
        public decimal Mailing_BuildingNumber { get; set; }
        public string Mailing_Unit { get; set; }
        public string Mailing_Zipcode { get; set; }
        public string Mailing_Zipcode4 { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string EMailAddress { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<bool> MembersAreAllowed { get; set; }
        public Nullable<int> MailingAddressTypeID { get; set; }
        public Nullable<int> LicenseeStatus { get; set; }
        public Nullable<bool> AllowPayByMail { get; set; }
        public Nullable<bool> AllowPayByCreditCard { get; set; }
        public string MerchantAccountID { get; set; }
        public string MerchantID { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public Nullable<System.DateTime> License_Exp_Date { get; set; }
        public string RegistrationMethod { get; set; }
        public Nullable<System.DateTime> MembershipExpiryDate { get; set; }
        public Nullable<System.DateTime> MembershipJoinOnDate { get; set; }
        public Nullable<decimal> MembershipDues { get; set; }
        public Nullable<System.DateTime> PaidOnDate { get; set; }
        public Nullable<bool> MembersDuesAreAllowed { get; set; }
    
        public virtual ICollection<tbl_Conference_Sponsors> tbl_Conference_Sponsors { get; set; }
        public virtual ICollection<tbl_Course_Sponsors> tbl_Course_Sponsors { get; set; }
        public virtual ICollection<tbl_Issuers> tbl_Issuers { get; set; }
        public virtual ICollection<tbl_Person_Organization_Roles> tbl_Person_Organization_Roles { get; set; }
        public virtual ICollection<tbl_Providers> tbl_Providers { get; set; }
    }
}