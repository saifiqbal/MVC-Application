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
    
    public partial class tbl_Enrollment_Master
    {
        public tbl_Enrollment_Master()
        {
            this.tbl_Attendance = new HashSet<tbl_Attendance>();
            this.tbl_ConferenceEnrollment = new HashSet<tbl_ConferenceEnrollment>();
            this.tbl_Course_Enrollment = new HashSet<tbl_Course_Enrollment>();
        }
    
        public int EnrollmentMasterID { get; set; }
        public string DummyColumn { get; set; }
    
        public virtual ICollection<tbl_Attendance> tbl_Attendance { get; set; }
        public virtual ICollection<tbl_ConferenceEnrollment> tbl_ConferenceEnrollment { get; set; }
        public virtual ICollection<tbl_Course_Enrollment> tbl_Course_Enrollment { get; set; }
    }
}