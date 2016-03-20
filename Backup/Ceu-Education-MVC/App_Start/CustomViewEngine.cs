using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ceu_Education_MVC.App_Start
{
    public class CustomViewEngine:RazorViewEngine
    {

        public CustomViewEngine()
        {
            ViewLocationFormats = new string[] { "~/Views/{1}/{0}.cshtml", "~/Views/SuperUser/{0}.cshtml", "~/Views/SuperUser/DashBoard/SUDashBoard.cshtml", "~/Views/SuperCompany/{1}.cshtml", "~/Views/SuperCompany/CompanyDashBoard.cshtml" };
           
        }


    }
}