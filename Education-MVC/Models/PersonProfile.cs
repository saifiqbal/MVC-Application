using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace Ceu_Education_MVC.Models
{
    public class PersonProfile
    {
            public int PersonID { get; set; }
            public string FName { get; set; }
            public string MName { get; set; }
            public string LName { get; set; }
            public Nullable<int> SuffixID { get; set; }
            public Nullable<int> SexID { get; set; }
            public Nullable<System.DateTime> DateOfBirth { get; set; }
            public Nullable<long> NasnIdentifier { get; set; }
            public string UserName { get; set; }
            public Nullable<int> SecretQuestionID { get; set; }
            public string SecretQuestionAnswer { get; set; }
            public string PhonePersonal { get; set; }
            public string MobilePerson { get; set; }
            public string SSN { get; set; }
            public string EMailPersonal { get; set; }
            public Nullable<int> Residence_StateID { get; set; }
            public Nullable<int> Residence_MunicipalityID { get; set; }
            public string Residence_StreetName { get; set; }
            public Nullable<int> Residence_BuildingNumber { get; set; }
            public string Residence_Unit { get; set; }
            public string Residence_Zipcode { get; set; }
            public string Residence_Zipcode4 { get; set; }
            public Nullable<int> MailingStateID { get; set; }
            public Nullable<int> Mailing_MunicipalityID { get; set; }
            public string Mailing_StreetName { get; set; }
            public Nullable<int> Mailing_BuildingNumber { get; set; }
            public string Mailing_Unit { get; set; }
            public string Mailing_Zipcode { get; set; }
            public string Mailing_Zipcode4 { get; set; }
            public Nullable<int> DistrictSiteID { get; set; }
            public string PhoneWork { get; set; }
            public string EMailWork { get; set; }
            public string EINNbr { get; set; }
            public Nullable<int> LicenseStateID { get; set; }
            public Nullable<int> LicenseLevelID { get; set; }
            public string LicenseNbr { get; set; }
            public Nullable<System.DateTime> LicenseExpirationDate { get; set; }
            public Nullable<bool> Deceased { get; set; }
            public Nullable<int> MailingAddressTypeID { get; set; }
            public Nullable<int> DistrictID { get; set; }
            public Nullable<int> SchoolID { get; set; }
            public Nullable<bool> Retired { get; set; }
            public SelectList Stateslist { get; set; }
            public SelectList CitiesList { get; set; }
            public List<PersonDegrees> PersonDegreesColl { get; set; }
            public List<OrganizationSpecificSecurityInfo> OrganizationSpecificInfo { get; set; }
        public OrganizationSpecificSecurityInfo selectedOrganizationspecificSecurity { get; set; }
    }

    public class PersonDegrees
    {
        public int PersonDegreeID { get; set; }
        public int PersonID { get; set; }
        public int DegreeID { get; set; }
        public string DegreeDesc { get; set; }
        public bool selected { get; set; }
    }

    public class states
    {
        public int ID { get;set; }
        public string Name { get; set; }
    }
     public class cities
    {
        public int ID { get;set; }
        public string Name { get; set; }
    }

    public class OrganizationSpecificSecurityInfo
    {

        private int _organizationID;
        public int OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value;}
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value;}
        }

        private bool _isAdministrator;
        public bool IsAdministrator
        {
            get { return _isAdministrator; }
            set { _isAdministrator = value; }
        }

        private bool _isSuperUser;
        public bool isSuperUser
        {
            get { return _isSuperUser; }
            set { _isSuperUser = value; }
        }

        private bool _isRegisterUser;
        public bool IsRegisterUser
        {
            get { return _isRegisterUser; }
            set { _isRegisterUser = value;}
        }
        private bool _IsMember;
        public bool IsMember
        {
            get { return _IsMember; }
            set { _IsMember = value;}
        }
        private string _MembershipID;
        public string MemberShipID
        {
            get { return _MembershipID; }
            set { _MembershipID = value; }

        }
        private DateTime? _ExpiryDate;
        public DateTime? ExpiryDate
        {
            get { return _ExpiryDate; }
            set { _ExpiryDate = value;}

        }
        private DateTime? _JoinDate;
        public DateTime? JoinDate
        {
            get { return _JoinDate; }
            set { _JoinDate = value; }


        }

        private decimal? _Dues;
        public decimal? Dues
        {
            get { return _Dues; }
            set { _Dues = value;}

        }

        private DateTime? _PaidOnDate;
        public DateTime? PaidOnDate
        {
            get { return _PaidOnDate; }
            set { _PaidOnDate = value;}


        }

        private bool _IsMemberAreAllowed;
        public bool IsMemberAreAllowed
        {
            get { return _IsMemberAreAllowed; }
            set { _IsMemberAreAllowed = value; }
        }


        private bool _IsMemberDuesAreAllowed;
        public bool IsMemberDuesAreAllowed
        {
            get { return _IsMemberDuesAreAllowed; }
            set { _IsMemberDuesAreAllowed = value; }
        }
    }


}