using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ceu_Education_MVC.Models
{
    [Serializable]
    public class PersonListModel
    {
        private bool _isMember;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateofBirth { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public int PersonID { get; set; }

        public bool IsMember
        {
            get { return _isMember; }
            set { _isMember = value; }
        }

        public string Message { get; set; }
    }

}