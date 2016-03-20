using System;
using System.Activities.Debugger;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Objects.SqlClient;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.SessionState;
using Antlr.Runtime;
using AutoMapper;
using Ceu_Education_MVC.Models;
using DAL.DataAccess.Common;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using Microsoft.SqlServer.Server;
using ModelState = System.Web.Http.ModelBinding.ModelState;
using System.Data;

namespace Ceu_Education_MVC.Controllers
{
    public class PersonProfileController : Controller
    {

        //
        // GET: /PersonProfile/
        [Authorize]
        public ActionResult PersonProfile(int personid)
        {




            var personinfo = new tbl_Person();
            List<tbl_Person_Organization_Roles> personOrganizationRoles = new List<tbl_Person_Organization_Roles>();
            List<tbl_Person_Degrees> Person_Degrees = new List<tbl_Person_Degrees>();
            List<tbl_Person_Licenses> PersonLicenses = new List<tbl_Person_Licenses>();
            List<tbl_Persons_Professions> Persons_Professions = new List<tbl_Persons_Professions>();

            CeuEntities dbcontext = new CeuEntities();
            var data = from p in dbcontext.tbl_Person
                       where p.PersonID == personid
                       select p;
            

            /*mapping for models*/
            Mapper.CreateMap<tbl_Person, Models.PersonProfile>();
            /*xxxxxxx*/
            if (data.ToArray().Count() > 0)
            {
                personinfo = (tbl_Person)data.ToArray()[0];
            }
            if (personinfo.tbl_Person_Organization_Roles.ToArray().Count() > 0)
            {
                personOrganizationRoles =
                    (List<tbl_Person_Organization_Roles>)personinfo.tbl_Person_Organization_Roles.ToList();
            }
            if (personinfo.tbl_Person_Degrees.ToArray().Count() > 0)
            {
                Person_Degrees = (List<tbl_Person_Degrees>)personinfo.tbl_Person_Degrees.ToList();

            }
            if (personinfo.tbl_Person_Licenses.ToArray().Count() > 0)
            {
                PersonLicenses = (List<tbl_Person_Licenses>)personinfo.tbl_Person_Licenses.ToList();
            }
            if (personinfo.tbl_Persons_Professions.ToArray().Count() > 0)
            {
                Persons_Professions = (List<tbl_Persons_Professions>)personinfo.tbl_Persons_Professions.ToList();
            }

            Models.PersonProfile pp = new PersonProfile();
            pp = Mapper.Map<tbl_Person, Models.PersonProfile>(personinfo);


            #region PersonDegrees

            List<PersonDegrees> PersonDegreeList = (from pd in dbcontext.tbl_Person_Degrees
                                                    join d in dbcontext.tbl_Degrees on pd.DegreeID equals d.DegreeID
                                                    where pd.PersonID == personid
                                                    select new PersonDegrees
                                                           {
                                                               DegreeDesc = d.DegreeDesc,
                                                               DegreeID = d.DegreeID,
                                                               PersonID = GlobalInfo.PersonID,
                                                               PersonDegreeID = pd.PersonDegreeID,
                                                               selected = false

                                                           }).ToList<PersonDegrees>();


            #endregion

            #region States&Cities
            List<states> StatesList = (
                from s in dbcontext.tbl_States
                select new states
                {

                    Name = s.Name,
                    ID = s.ID

                }).ToList<states>();


            int UserStateID = Convert.ToInt32(pp.Residence_StateID);
            List<cities> CitiesLists =
                (from c in dbcontext.tbl_Cities
                 where c.StateID == UserStateID
                 select new cities
                {
                    Name = c.Name,
                    ID = c.ID
                }).ToList<cities>();
            #endregion

            #region DOBCalendar
            /*loading Calenders dropdownlist*/
            List<SelectListItem> year = new List<SelectListItem>();
            for (int jLoop = 1900; jLoop <= DateTime.Now.Year; jLoop++)
            {
                SelectListItem sl = new SelectListItem();
                sl.Text = Convert.ToString(jLoop);
                sl.Value = Convert.ToString(jLoop);
                year.Add(sl);
            }
            /*xx*/
            /**/


            /*fill months ddl*/
            int months = CultureInfo.CurrentUICulture.DateTimeFormat.Calendar.GetMonthsInYear(pp.DateOfBirth.Value.Year);
            List<SelectListItem> monthscoll = new List<SelectListItem>();
            for (int m = 0; m <= months; m++)
            {
                SelectListItem sl = new SelectListItem();
                sl.Text = Convert.ToString(m);
                sl.Value = Convert.ToString(m);
                monthscoll.Add(sl);
            }


            /*fill Months ddl*/
            int Days = CultureInfo.CurrentUICulture.DateTimeFormat.Calendar.GetDaysInMonth(pp.DateOfBirth.Value.Year, pp.DateOfBirth.Value.Month);
            List<SelectListItem> dayscoll = new List<SelectListItem>();
            for (int d = 0; d <= Days; d++)
            {
                SelectListItem sl = new SelectListItem();
                sl.Text = Convert.ToString(d);
                sl.Value = Convert.ToString(d);
                dayscoll.Add(sl);
            }

            #endregion

            #region GenderInfo
            /*Suffix ddl*/

            IEnumerable<SelectListItem> Suffixcoll = from s in dbcontext.tbl_Suffixes
                                                     select new SelectListItem
                                                            {
                                                                Text = s.SuffixDesc,
                                                                Value = SqlFunctions.StringConvert((decimal?)s.SuffixID)
                                                            };

            /*Sex Coll*/
            IEnumerable<SelectListItem> Sexcoll = from s in dbcontext.tbl_Sex
                                                  select new SelectListItem
                                                         {
                                                             Text = s.SexDesc,
                                                             Value = SqlFunctions.StringConvert((decimal?)s.SexID)
                                                         };

            #endregion

            #region Professions

            IEnumerable<SelectListItem> ProfList = from p in dbcontext.tbl_professions
                                                   select new SelectListItem
                                                          {
                                                              Text = p.Profession_description,
                                                              Value = SqlFunctions.StringConvert((decimal?)p.Profession_ID)
                                                          };
            var professionsList = new SelectList(ProfList, "Value", "Text");




            #endregion

            #region OrganizationRoles

            IEnumerable<SelectListItem> Orgroles = from r in dbcontext.tbl_Roles
                                                   select new SelectListItem
                                                   {
                                                       Text = r.RoleDesc,
                                                       Value = SqlFunctions.StringConvert((decimal?)r.RoleID)
                                                   };
            var OrgrolesList = new SelectList(Orgroles, "Value", "Text");




            #endregion

            #region PersonOrganization

            var PersonOrg = from r in dbcontext.tbl_Person_Organization_Roles
                            join o in dbcontext.tbl_Organizations on r.OrganizationID equals o.OrganizationID
                            where r.PersonID == personid && r.RoleTypeID == 2
                            select new SelectListItem
                                   {
                                       Text = o.OrganizationName,
                                       Value = SqlFunctions.StringConvert((decimal?)r.OrganizationID)



                                   };


            var PersonOrgnization = new SelectList(PersonOrg, "Value", "Text");



            #endregion

            #region SecretQuestion

            IEnumerable<SelectListItem> SecretQuestionList = from q in dbcontext.tbl_Secret_Questions
                                                             select new SelectListItem
                                                             {
                                                                 Text = q.SecretQuestionDesc,
                                                                 Value = SqlFunctions.StringConvert((decimal?)q.SecretQuestionID)
                                                             };
            var SecretQList = new SelectList(SecretQuestionList, "Value", "Text");





            #endregion

            #region Organization-Specific-Security

            List<OrganizationSpecificSecurityInfo> dataOrgSpec = (from s in dbcontext.tbl_Person_Organization_Roles
                                                                  join o in dbcontext.tbl_Organizations on s.OrganizationID equals o.OrganizationID
                                                                  join l in dbcontext.tbl_PersonOrganizationMemberships on s.PersonID equals l.PersonID
                                                                  where s.PersonID == personid && s.RoleTypeID == 2 && l.OrganizationID == s.OrganizationID
                                                                  select
                                                                      new OrganizationSpecificSecurityInfo
                                                                      {
                                                                          JoinDate = l.JoinOnDate,
                                                                          PaidOnDate = l.PaidOnDate,
                                                                          IsMemberAreAllowed = (bool)(o.MembersAreAllowed),
                                                                          IsMemberDuesAreAllowed = (bool)(o.MembersDuesAreAllowed),
                                                                          ExpiryDate = l.DateMembershipExpires,
                                                                          Dues = l.Dues,
                                                                          MemberShipID = l.MembershipID,
                                                                          IsAdministrator = (bool)(s.RoleID == 8 ? true : false),
                                                                          IsRegisterUser = (bool)(s.RoleID == 7 ? true : false),
                                                                          isSuperUser = (bool)(s.RoleID == 9 ? true : false),

                                                                          OrganizationID = s.OrganizationID,
                                                                          Password = s.Pwd
                                                                      }).ToList<OrganizationSpecificSecurityInfo>();

            /*Store OSSI into tempdata for later use*/
            //TempData.Add("OSSIList",dataOrgSpec);

            Session.Add("OSSIList", dataOrgSpec);


            /**/

            OrganizationSpecificSecurityInfo Orgspec =
                dataOrgSpec.Where(x => x.OrganizationID == 1).First();





            pp.selectedOrganizationspecificSecurity = new OrganizationSpecificSecurityInfo();

            pp.selectedOrganizationspecificSecurity = Orgspec;
            //pp.selectedOrganizationspecificSecurity.Dues = Convert.ToDecimal(10.2);
            //pp.selectedOrganizationspecificSecurity.ExpiryDate = DateTime.Now;
            //pp.selectedOrganizationspecificSecurity.isSuperUser = true;
            //pp.selectedOrganizationspecificSecurity.IsAdministrator = false;
            //pp.selectedOrganizationspecificSecurity.IsMember = true;
            //pp.selectedOrganizationspecificSecurity.JoinDate = DateTime.Now;
            //pp.selectedOrganizationspecificSecurity.PaidOnDate = DateTime.Now;





            #endregion
            // DataTable Dt = sinfo.CopyToDataTable();

            #region ViewBags
            ViewBag.SuffixColl = Suffixcoll;
            ViewBag.SexColl = Sexcoll;
            ViewBag.DOBYear = year;
            ViewBag.DOBMonth = monthscoll;
            ViewBag.DOBDay = dayscoll;
            ViewBag.Professions = professionsList;
            ViewBag.Orgroles = OrgrolesList;
            ViewBag.SecretQuesList = SecretQList;
            ViewBag.PersonOrganization = PersonOrgnization;
            // ViewBag.PersonDegreesColl = PersonDegrees;
            pp.Stateslist = new SelectList(StatesList, "ID", "Name", pp.Residence_StateID);
            pp.CitiesList = new SelectList(CitiesLists, "ID", "Name");
            pp.PersonDegreesColl = PersonDegreeList;

            #endregion

            //tbl_Person persons = dbcontext.tbl_Person.FirstOrDefault<tbl_Person>();


            //personinfo.FName = "SaifIqbal";
            //dbcontext.Entry(personinfo).State = System.Data.EntityState.Modified;
            //dbcontext.SaveChanges();

            return View(pp);
        }
        
        [HttpPost]
        public ActionResult PersonProfile(Models.PersonProfile modeldata, List<string> PersonDegreesChkList,Models.OrganizationSpecificSecurityInfo spec)
        {
          //  return View(modeldata);
           // CreateViewBags(GlobalInfo.PersonID,modeldata);
            CeuEntities ceu=new CeuEntities();
             tbl_Person tbn=new tbl_Person();
            ceu.tbl_Person.AddOrUpdate(t => t.PersonID,new tbl_Person{PersonID =1,FName = "saif"});
            ceu.tbl_Person.SqlQuery("update tbl_person set FName='BB' where PersonID=1", null);
         
            ceu.SaveChanges();
            return View("PersonProfile", modeldata);
        }

        [HttpGet]
        public JsonResult GetCities(int? stateid)
        {
            CeuEntities dbcontext=new CeuEntities();

            var citieslist = (from s in dbcontext.tbl_Cities
                where s.StateID == stateid
                select new {s.ID, s.Name}).ToList();

            return Json(citieslist, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetDays(int year, int month)
        {
            CeuEntities dbcontext = new CeuEntities();
            int Days = CultureInfo.CurrentUICulture.DateTimeFormat.Calendar.GetDaysInMonth(year, month);
            List<SelectListItem> dayscoll = new List<SelectListItem>();
            for (int d = 0; d <= Days; d++)
            {
                SelectListItem sl = new SelectListItem();
                sl.Text = Convert.ToString(d);
                sl.Value = Convert.ToString(d);
                dayscoll.Add(sl);
            }

            return Json(dayscoll, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetProfessionDegrees(Models.PersonProfile modeldata)
        {
            //CeuEntities dbcontext = new CeuEntities();

            //var profdeglist = (from s in dbcontext.tbl_Profession_Degrees
            //                  join d in dbcontext.tbl_Degrees on s.Degree_ID equals d.DegreeID
            //                  where s.Profession_ID == Profid
            //                  select new PersonDegrees {DegreeDesc = d.DegreeDesc,PersonDegreeID = s.Profession_Degree_ID,PersonID =GlobalInfo.PersonID,DegreeID = d.DegreeID,selected = false}).ToList();

            //return Json(profdeglist, JsonRequestBehavior.AllowGet);


            return View(modeldata);

        }

        [HttpGet]
        public string checkusername(string username)
        {
            CeuEntities dbcontext = new CeuEntities();

            int count = (from s in dbcontext.tbl_Person
                         where s.UserName == username && s.PersonID!=GlobalInfo.PersonID
                         select s).Count();

            string data = "";
            if (count == 0)
            {
                return "Available";

            }
            else
            {
                return "NotAvailable";


            }



            return data;

        }
        
        public ActionResult UpdateOrganizationSpecSec(Models.PersonProfile modelData,string Organization)
        {
          
            List<OrganizationSpecificSecurityInfo> OrgSSIList = (List<OrganizationSpecificSecurityInfo>)Session["OSSIList"];

            for (int i = 0; i < OrgSSIList.Count(); i++)
            {
                if (OrgSSIList[i].OrganizationID == Convert.ToInt32(Organization))
                {
                    Mapper.CreateMap<OrganizationSpecificSecurityInfo, Models.OrganizationSpecificSecurityInfo>();
                    Models.OrganizationSpecificSecurityInfo org=new OrganizationSpecificSecurityInfo();
                    OrgSSIList[i] =
                        Mapper.Map<OrganizationSpecificSecurityInfo, Models.OrganizationSpecificSecurityInfo>(
                            modelData.selectedOrganizationspecificSecurity);





                }
            }
            return View(modelData);
        }

        public void CreateViewBags(int personid,PersonProfile pp)
        {

            CeuEntities dbcontext = new CeuEntities();
            
            
            //#region DOBCalendar
            ///*loading Calenders dropdownlist*/
            //List<SelectListItem> year = new List<SelectListItem>();
            //for (int jLoop = 1900; jLoop <= DateTime.Now.Year; jLoop++)
            //{
            //    SelectListItem sl = new SelectListItem();
            //    sl.Text = Convert.ToString(jLoop);
            //    sl.Value = Convert.ToString(jLoop);
            //    year.Add(sl);
            //}
            ///*xx*/
            ///**/


            ///*fill months ddl*/
            //int months = CultureInfo.CurrentUICulture.DateTimeFormat.Calendar.GetMonthsInYear(pp.DateOfBirth.Value.Year);
            //List<SelectListItem> monthscoll = new List<SelectListItem>();
            //for (int m = 0; m <= months; m++)
            //{
            //    SelectListItem sl = new SelectListItem();
            //    sl.Text = Convert.ToString(m);
            //    sl.Value = Convert.ToString(m);
            //    monthscoll.Add(sl);
            //}


            ///*fill Months ddl*/
            //int Days = CultureInfo.CurrentUICulture.DateTimeFormat.Calendar.GetDaysInMonth(pp.DateOfBirth.Value.Year, pp.DateOfBirth.Value.Month);
            //List<SelectListItem> dayscoll = new List<SelectListItem>();
            //for (int d = 0; d <= Days; d++)
            //{
            //    SelectListItem sl = new SelectListItem();
            //    sl.Text = Convert.ToString(d);
            //    sl.Value = Convert.ToString(d);
            //    dayscoll.Add(sl);
            //}

            //#endregion

            #region GenderInfo
            /*Suffix ddl*/

            IEnumerable<SelectListItem> Suffixcoll = from s in dbcontext.tbl_Suffixes
                                                     select new SelectListItem
                                                     {
                                                         Text = s.SuffixDesc,
                                                         Value = SqlFunctions.StringConvert((decimal?)s.SuffixID)
                                                     };

            /*Sex Coll*/
            IEnumerable<SelectListItem> Sexcoll = from s in dbcontext.tbl_Sex
                                                  select new SelectListItem
                                                  {
                                                      Text = s.SexDesc,
                                                      Value = SqlFunctions.StringConvert((decimal?)s.SexID)
                                                  };

            #endregion

            #region Professions

            IEnumerable<SelectListItem> ProfList = from p in dbcontext.tbl_professions
                                                   select new SelectListItem
                                                   {
                                                       Text = p.Profession_description,
                                                       Value = SqlFunctions.StringConvert((decimal?)p.Profession_ID)
                                                   };
            var professionsList = new SelectList(ProfList, "Value", "Text");




            #endregion

            #region OrganizationRoles

            IEnumerable<SelectListItem> Orgroles = from r in dbcontext.tbl_Roles
                                                   select new SelectListItem
                                                   {
                                                       Text = r.RoleDesc,
                                                       Value = SqlFunctions.StringConvert((decimal?)r.RoleID)
                                                   };
            var OrgrolesList = new SelectList(Orgroles, "Value", "Text");




            #endregion

            #region PersonOrganization

            var PersonOrg = from r in dbcontext.tbl_Person_Organization_Roles
                            join o in dbcontext.tbl_Organizations on r.OrganizationID equals o.OrganizationID
                            where r.PersonID == personid && r.RoleTypeID == 2
                            select new SelectListItem
                            {
                                Text = o.OrganizationName,
                                Value = SqlFunctions.StringConvert((decimal?)r.OrganizationID)



                            };


            var PersonOrgnization = new SelectList(PersonOrg, "Value", "Text");



            #endregion

            #region SecretQuestion

            IEnumerable<SelectListItem> SecretQuestionList = from q in dbcontext.tbl_Secret_Questions
                                                             select new SelectListItem
                                                             {
                                                                 Text = q.SecretQuestionDesc,
                                                                 Value = SqlFunctions.StringConvert((decimal?)q.SecretQuestionID)
                                                             };
            var SecretQList = new SelectList(SecretQuestionList, "Value", "Text");





            #endregion

            #region ViewBags
            ViewBag.SuffixColl = Suffixcoll;
            ViewBag.SexColl = Sexcoll;
            //ViewBag.DOBYear = year;
            //ViewBag.DOBMonth = monthscoll;
            //ViewBag.DOBDay = dayscoll;
            ViewBag.Professions = professionsList;
            ViewBag.Orgroles = OrgrolesList;
            ViewBag.SecretQuesList = SecretQList;
            ViewBag.PersonOrganization = PersonOrgnization;


            #endregion

        }
 
    }
}
