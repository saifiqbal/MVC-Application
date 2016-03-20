using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL.DataAccess.Common;
using CEUeducation.Model;

namespace DAL.DataAccess.CallingDAL
{
    public class CommonDA
    {

        private Common.CommonAccesses CA = new Common.CommonAccesses();
        public string GetOrganizationName(string orgId)
        {
            try
            {
                string orgname = "";
                List<string>objparamname=new List<string>();
                List<object>objvalue=new List<object>();
                objparamname.Add("@OrganizationID");
                objvalue.Add(orgId);
                DataTable DT = new DataTable();
                DT = CA.ExecuteSP("sp_Get_OrganizationNameByCode",objvalue,objparamname);

                if (DT.Rows.Count > 0)
                {

                    orgname= DT.Rows[0]["Org"].ToString();
                }
                return orgname;
                
            }
            catch
            {
                return "";
            }
        }
        public DataTable ValidateUserLogin(string username, string password, int OID)
        {
            List<string> objparamname = new List<string>();
            List<object> objvalue = new List<object>();
            objparamname.Add("@UserName");
            objvalue.Add(username);
            objparamname.Add("@Password");
            objvalue.Add(password);
            objparamname.Add("@OrganizationID");
            objvalue.Add(OID);
            DataTable DT = new DataTable();
            DT = CA.ExecuteSP("sp_ValidateUser", objvalue, objparamname);

            return DT;
        }
        public DataTable GetPersonsList(int organizaitonID,int OIDmem)
        {
            List<string> objparamname = new List<string>();
            List<object> objvalue = new List<object>();
            objparamname.Add("@OrganizationID");
            objvalue.Add(organizaitonID);
            objparamname.Add("@OIDmem");
            objvalue.Add(OIDmem);

            DataTable DT = new DataTable();
            DT = CA.ExecuteSP("Sp_PersonList_Get", objvalue, objparamname);

            return DT;
        }

        public int ModifyMemebrShipStatus(int personID, int OrganizationID, bool ismemeber)
        {
            SqlConnection myConnection = new SqlConnection(CA.GetConnectionString());
            myConnection.Open();
            int i = SqlHelper.ExecuteNonQuery(myConnection, "UpdateMemberShipStatus", personID, OrganizationID, ismemeber);
            return i;
        }
        public DataSet GetAllDuplicateUsers()
        {
            SqlConnection myConnection = new SqlConnection(CA.GetConnectionString());
            myConnection.Open();

            DataSet DS = SqlHelper.ExecuteDataset(myConnection, "GetDuplicatePersonRecords");
            return DS;
        }


    }
}
