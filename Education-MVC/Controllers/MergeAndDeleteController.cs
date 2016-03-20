using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Ceu_Education_MVC.Models;
using DAL.DataAccess.CallingDAL;

namespace Ceu_Education_MVC.Controllers
{
    public class MergeAndDeleteController : Controller
    {
        //
        // GET: /MergeAndDelete/
        [HttpGet]
        public ActionResult MergeAndDelete()
        {
            var CDA = new CommonDA();
            var DSPerson = new DataSet();
            DSPerson = CDA.GetAllDuplicateUsers();

            var model = new MergeAndDeleteModel();
            var personlist = new List<MergeAndDeleteModel.PersonDetail>();

            for (int i = 0; i < 10; i++)
            {
                var mergemodel = new MergeAndDeleteModel.PersonDetail();
                mergemodel.FirstName = DSPerson.Tables[0].Rows[i]["fname"].ToString();
                mergemodel.MiddleName = DSPerson.Tables[0].Rows[i]["mname"].ToString();
                mergemodel.LastName = DSPerson.Tables[0].Rows[i]["lname"].ToString();
                mergemodel.UserName = DSPerson.Tables[0].Rows[i]["UserName"].ToString();
                mergemodel.PersonID = Convert.ToInt32(DSPerson.Tables[0].Rows[i]["personid"]);
                mergemodel.IsSelected = false;

                personlist.Add(mergemodel);
            }
            model.PersonList = personlist;


            return View(model);
        }

        //[HttpPost]
        //public ActionResult MergeAndDelete(MergeAndDeleteModel p)
        //{

        //    return Json(new { status = p });
        //}
    }
}