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
    
    public partial class tbl_QuestionScale
    {
        public tbl_QuestionScale()
        {
            this.tbl_Survey_Results = new HashSet<tbl_Survey_Results>();
        }
    
        public int QuestionScaleID { get; set; }
        public string QuestionScaleDesc { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public Nullable<int> OrderNumber { get; set; }
    
        public virtual ICollection<tbl_Survey_Results> tbl_Survey_Results { get; set; }
    }
}