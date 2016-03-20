using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ceu_Education_MVC.Controllers
{
    public class UnAuthorizedController : Controller
    {
        //
        // GET: /UnAuthorized/

        public ActionResult Index()
        {
            return View();
        }

    }
}
