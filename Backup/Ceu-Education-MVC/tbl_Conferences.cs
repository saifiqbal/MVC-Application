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
    
    public partial class tbl_Conferences
    {
        public tbl_Conferences()
        {
            this.tbl_Conference_Courses = new HashSet<tbl_Conference_Courses>();
            this.tbl_Conference_Facilities = new HashSet<tbl_Conference_Facilities>();
            this.tbl_Conference_Sponsors = new HashSet<tbl_Conference_Sponsors>();
            this.tbl_Conference_Venue_Types = new HashSet<tbl_Conference_Venue_Types>();
            this.tbl_ConferenceEnrollment = new HashSet<tbl_ConferenceEnrollment>();
        }
    
        public int ConferenceID { get; set; }
        public string ConferenceName { get; set; }
        public Nullable<System.DateTime> ConferenceEnrollmentDeadline { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> CredentialIssuanceDate { get; set; }
        public int OrganizationID { get; set; }
        public string Promotionalurl { get; set; }
        public Nullable<System.DateTime> PostingDate { get; set; }
    
        public virtual ICollection<tbl_Conference_Courses> tbl_Conference_Courses { get; set; }
        public virtual ICollection<tbl_Conference_Facilities> tbl_Conference_Facilities { get; set; }
        public virtual ICollection<tbl_Conference_Sponsors> tbl_Conference_Sponsors { get; set; }
        public virtual ICollection<tbl_Conference_Venue_Types> tbl_Conference_Venue_Types { get; set; }
        public virtual ICollection<tbl_ConferenceEnrollment> tbl_ConferenceEnrollment { get; set; }
    }
}