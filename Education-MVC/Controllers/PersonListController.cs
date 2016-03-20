using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.DataAccess.Common;
using System.Data;
using Ceu_Education_MVC.Models;

namespace Ceu_Education_MVC.Controllers
{
    
    public class PersonListController : Controller
    {
        //
        // GET: /PersonList/
        [Authorize]
        [HttpGet]
        public ActionResult PersonList()
        {
            DAL.DataAccess.CallingDAL.CommonDA CDA = new DAL.DataAccess.CallingDAL.CommonDA();
            DataTable DTPersons = new DataTable();
            var plist = new List<PersonListModel>();
            if (GlobalInfo.RoleID == 9)
            {
               
                DTPersons = CDA.GetPersonsList(0, GlobalInfo.OID);
                for (int i = 0; i < DTPersons.Rows.Count; i++)
                {
                    var p = new PersonListModel();
                    p.FirstName = DTPersons.Rows[i]["FirstName"].ToString();
                    p.MiddleName = DTPersons.Rows[i]["MiddleName"].ToString();
                    p.LastName = DTPersons.Rows[i]["LastName"].ToString();
                    p.DateofBirth = DTPersons.Rows[i]["DOB"].ToString();
                    p.PersonID = Convert.ToInt32(DTPersons.Rows[i]["PersonID"]);
                    p.Telephone = DTPersons.Rows[i]["PhonePersonal"].ToString();
                    p.Mobile = DTPersons.Rows[i]["MobilePersonal"].ToString();
                    p.EmailAddress=DTPersons.Rows[i]["EmailPersonal"].ToString();
                    p.IsMember = Convert.ToBoolean(DTPersons.Rows[i]["IsMember"]);
                    plist.Add(p);
                }
            }

            ViewBag.PersonList = plist;
            return View();
        }
        [HttpPost]
        public ActionResult PersonList(string personid, int ischecked)
        {
            /*do something with the data*/
            DAL.DataAccess.CallingDAL.CommonDA CDA = new DAL.DataAccess.CallingDAL.CommonDA();
            CDA.ModifyMemebrShipStatus(Convert.ToInt32(personid), GlobalInfo.OID, Convert.ToBoolean(ischecked));

            string message = "done";
            return Json(new PersonListModel {Message=message}); 
        }
    }
}
