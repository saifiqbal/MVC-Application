using System;
using System.Linq;
using System.Web.Mvc;
using Ceu_Education_MVC.Models;

namespace Ceu_Education_MVC.Controllers
{
    public class MergeAndDeleteMainController : Controller
    {
        //  private PersonCollection p = new PersonCollection();
        //
        // GET: /MergeAndDeleteMain/
        [HttpPost]
        public ActionResult MergeAndDeleteMain(MergeAndDeleteModel p)
        {
            int personidleft = p.PersonList.Where(x => x.IsSelected).Select(s => s.PersonID).FirstOrDefault();
            MergeAndDeleteModel.PersonDetail detail = p.PersonList.First(x => x.PersonID == personidleft);
            p.PersonList.Remove(detail);
            int personidright = p.PersonList.Where(x => x.IsSelected).Select(s => s.PersonID).FirstOrDefault();

            // ViewBag.PersonIDleft = personidleft;
            // ViewBag.PersonIDright = personidright;
            var mm = new MergeAndDeleteMain();
            mm.personidleft = Convert.ToString(personidleft);
            mm.personidright = Convert.ToString(personidright);
            mm.SelectedOne = true;
            mm.SelectedTwo = false;
            return View(mm);
        }

        [HttpPost]
        public ActionResult DeleteSelected()
        {
            int personidselected = Convert.ToInt32(Request["rbgrp"]);
            return View();
        }
    }
}