using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ceu_Education_MVC.Controllers
{
    public class CompanyDashBoardController : Controller
    {
        //
        // GET: /CompanyDashBoard/

        public ActionResult CompanyDashBoard()
        {
            CeuEntities dbcontext=new CeuEntities();

            int activereg= (from s in dbcontext.tbl_Person
                select s).Count();
            ViewBag.ActiveReg = Convert.ToString(activereg);

            return View("~/Views/SuperCompany/CompanyDashBoard.cshtml");
        }

    }
}
