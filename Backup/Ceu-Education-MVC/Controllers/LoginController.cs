using Ceu_Education_MVC.Models;
using DAL.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ceu_Education_MVC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Dologin()
        {
            MainPage OrganizationData = new MainPage();
            OrganizationData.OID = GlobalInfo.OID;
            OrganizationData.OrgAddress = GlobalInfo.OrgAddress;
            OrganizationData.OrganizationName = GlobalInfo.OrgName;
            OrganizationData.OrgCode = GlobalInfo.OrgCode;
            OrganizationData.OrgEmailAddress = GlobalInfo.OrgEmailAddress;
            OrganizationData.RegMethod = GlobalInfo.RegMethod;
            ViewBag.OrgInfo = OrganizationData;

            return View();
        }

        [HttpPost]
        public ActionResult Dologin(Login log)
        {
            if (ModelState.IsValid)
            {
                DAL.DataAccess.CallingDAL.CommonDA CDA = new DAL.DataAccess.CallingDAL.CommonDA();
                DataTable DTLoginInfo = CDA.ValidateUserLogin(log.Username, log.Password, GlobalInfo.OID);

                if (DTLoginInfo.Rows.Count > 0)
                {

                    GlobalInfo.LoginInfo = DTLoginInfo.Rows[0];
                    GlobalInfo.IsLoggedIN = true;
                    GlobalInfo.PersonID = Convert.ToInt32(DTLoginInfo.Rows[0]["PersonID"]);
                    GlobalInfo.RoleID = Convert.ToInt32(DTLoginInfo.Rows[0]["RoleID"]);

                    /*add login information to session*/
                    Session.Add("DTLogin", DTLoginInfo);

                    /*Set form authentication*/
                    FormsAuthentication.SetAuthCookie(log.Username,false);


                    if (GlobalInfo.LoginInfo["RoleID"].ToString() == "9")
                    {
                        return  RedirectToAction("Index", "SuperUserDB");  
                    }
                    else if (GlobalInfo.LoginInfo["RoleID"].ToString() == "8")
                    {
                        /*Redirect to Admin DashBoard*/
                    }
                    else if (GlobalInfo.LoginInfo["RoleID"].ToString() == "7")
                    {
                        /*Redirect to Register user Dashboard*/
                    }

                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            
            return RedirectToAction("Index","MainPage");
        }

    }
}
