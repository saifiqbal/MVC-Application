using System.Activities.Expressions;
using System.Data.Entity;
using System.Web.Security;
using Ceu_Education_MVC.Models;
using DAL.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace Ceu_Education_MVC.Controllers
{
    public class MainPageController : Controller
    {
        //
        // GET: /MainPage/
        
        public ActionResult Index(string OID)
        {
          
            if (OID ==null)
            {
                return RedirectToAction("UnAuthorized");
            }
            else
            {
                MainPage mainpage = new MainPage();
                bool istrue = new ValidateOrganization().LoadOrganizationInfo(OID);
                if (istrue)
                {
                    mainpage.OID = GlobalInfo.OID;
                    mainpage.OrgAddress = GlobalInfo.OrgAddress;
                    mainpage.OrganizationName = GlobalInfo.OrgName;
                    mainpage.OrgCode = GlobalInfo.OrgCode;
                    mainpage.OrgEmailAddress = GlobalInfo.OrgEmailAddress;
                    mainpage.RegMethod = GlobalInfo.RegMethod;
                   
                }
                else
                {
                    return RedirectToAction("UnAuthorized");
                }
                ViewBag.OrgInfo = mainpage;



            }
            return View();
        }
        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}
