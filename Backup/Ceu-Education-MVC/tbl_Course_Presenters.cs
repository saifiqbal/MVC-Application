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
    
    public partial class tbl_Course_Presenters
    {
        public int CoursePresenterID { get; set; }
        public int CourseID { get; set; }
        public int PresenterID { get; set; }
    
        public virtual tbl_Courses tbl_Courses { get; set; }
        public virtual tbl_Presenters tbl_Presenters { get; set; }
    }
}