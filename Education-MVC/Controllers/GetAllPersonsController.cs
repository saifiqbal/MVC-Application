using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ceu_Education_MVC.Models;
using DAL.DataAccess.Common;

namespace Ceu_Education_MVC.Controllers
{
    public class GetAllPersonsController : ApiController
    {
        public string Get()
        {

            DAL.DataAccess.CallingDAL.CommonDA CDA = new DAL.DataAccess.CallingDAL.CommonDA();
            DataTable DTPersons = new DataTable();
            string data = "";
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
                p.EmailAddress = DTPersons.Rows[i]["EmailPersonal"].ToString();
                p.IsMember = Convert.ToBoolean(DTPersons.Rows[i]["IsMember"]);


                data += p.FirstName+","+p.LastName+","+p.PersonID+","+p.Telephone;



            }
            return data;
        }

    }
}
