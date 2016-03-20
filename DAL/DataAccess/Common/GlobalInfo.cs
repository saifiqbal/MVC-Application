using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess.Common
{
    public static class GlobalInfo
    {
        private static DataTable _OrganizatioInfo=new DataTable();
        private static DataRow _LoginInfo;
        private static bool _IsLoggedIn = false;
        private static int _RoleID = 0;
        private static int _OID = 0;
        private static string _OrgName = null;
        private static int _PersonID = 0;
        private static string _OrgCode = null;
        private static string _OrgAddress = null;
        private static string _OrgEmailAddress = null;
        private static string _RegMethod = null;

        public static string OrgAddress
        {
            get
            {
                return _OrgAddress;
            }
            set
            {
                _OrgAddress = value;
            }
        }

        public static string OrgEmailAddress
        {
            get
            {
                return _OrgEmailAddress;
            }
            set
            {
                _OrgEmailAddress = value;
            }
        }

        public static string RegMethod
        {
            get
            {
                return _RegMethod;
            }
            set
            {
                _RegMethod = value;
            }
        }

        public static string OrgCode
        {
            get
            {
                return _OrgCode;
            }
            set
            {
                _OrgCode = value;
            }
        }

        public static string OrgName
        {
            get
            {
                return _OrgName;
            }
            set
            {
                _OrgName = value;
            }
        }



        public static int PersonID
        {
            get
            {
                return _PersonID;
            }
            set
            {
                _PersonID = value;
            }
        }

        public static int OID
        {
            get
            {
                return _OID;
            }
            set
            {
                _OID = value;
            }
        }
        public static int RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }
        public static bool IsLoggedIN
        {
            get
            {
                return _IsLoggedIn;
            }
            set
            {
                _IsLoggedIn = value;
            }
        }
        public static DataTable OrganizationInfo
        {
            get
            {
                return _OrganizatioInfo;
            }
            set
            {
                _OrganizatioInfo= value;
            }
        }

        public static DataRow LoginInfo
        {
            get
            {
                return _LoginInfo;
            }
            set
            {
                _LoginInfo = value;
            }
        }

    }
}
