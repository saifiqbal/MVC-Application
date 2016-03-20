using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ceu_Education_MVC.Models
{
   
    public class MergeAndDeleteModel
    {
        public List<PersonDetail> PersonList { get; set; }

        public class PersonDetail
        {
            public bool IsSelected { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public int PersonID { get; set; }
        }
    }
}