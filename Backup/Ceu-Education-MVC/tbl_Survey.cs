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
    
    public partial class tbl_Survey
    {
        public tbl_Survey()
        {
            this.tbl_Course_Survey = new HashSet<tbl_Course_Survey>();
            this.tbl_Survey_Questions = new HashSet<tbl_Survey_Questions>();
        }
    
        public int SurveyID { get; set; }
        public string SurveyDesc { get; set; }
        public Nullable<int> OrganizationID { get; set; }
    
        public virtual ICollection<tbl_Course_Survey> tbl_Course_Survey { get; set; }
        public virtual ICollection<tbl_Survey_Questions> tbl_Survey_Questions { get; set; }
    }
}
