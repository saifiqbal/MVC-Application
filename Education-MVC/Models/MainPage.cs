using DAL.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace Ceu_Education_MVC.Models
{
    public class MainPage
    {
        public MainPage()
        {
        }

        public string OrganizationName{get;set;}
        public int OID{get;set;}
        public string OrgCode{get;set;}
        public string OrgAddress{get;set;}
        public string OrgEmailAddress{get;set;}
        public string RegMethod{get;set;}
    }
    public class ValidateOrganization
    {
        public bool LoadOrganizationInfo(string OID)
        {
            /*Entity Framework testing*/
            var persons = new CeuEntities();

            var data = persons.tbl_Person.FirstOrDefault(x => x.PersonID == 1);
            var data1 = from p in persons.tbl_Person
                where p.PersonID == 1
                select p;


            /*xxx*/




            string OrgCode = OID;
            DAL.DataAccess.CallingDAL.CommonDA CDAL = new DAL.DataAccess.CallingDAL.CommonDA();
            string OrganizationName = CDAL.GetOrganizationName(OID);


            int orgId = 0;
            if (!string.IsNullOrEmpty(OrganizationName))
            {

                string[] str = OrganizationName.Split('|');
                string OName = str[0];
                int status = Convert.ToInt32(str[1]);
                orgId = Convert.ToInt32(str[3]);
                string orgAddress = str[4];
                string EmailAddress = str[5];
                string RegistrationMethod = str[6];
                // string Zipcode = str[7];

                if (str[2] == "1")
                {
                    //new ViewModelLocator().Main.AllowMemberShip = true;
                }
                else
                {
                    //  new ViewModelLocator().Main.AllowMemberShip = false;
                }

                if (status == 2)
                {
                    //new ViewModelLocator().Main.AllowMemberLogin = true;
                }
                else
                {
                    //new ViewModelLocator().Main.AllowMemberLogin = false;
                }

                //if (status == 2)
                //{
                //new ViewModelLocator().LoginForm.OrganizationName = ea.Result;
                // busyIndicator.Content = new MainPage();
                // LoadImage(orgId);
                GlobalInfo.OrgName = OName;//ea.Result;
                GlobalInfo.OID = orgId;
                GlobalInfo.OrgCode = OrgCode;
                GlobalInfo.OrgAddress = orgAddress;
                GlobalInfo.OrgEmailAddress = EmailAddress;
                GlobalInfo.RegMethod = RegistrationMethod;
                return true;
            }
            else
            {

                return false;
            }
      


        }
    }
}