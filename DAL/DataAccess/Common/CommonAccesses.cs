#region using
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

#endregion
namespace DAL.DataAccess.Common
{
    #region Start
    public class CommonAccesses
    {
        #region Connection String from Web.Config

        public Boolean bDBConnected = false;
        string ecUConnectionString = "";
        string ConnectionString = "";
        DataTable DTSP = new DataTable();
        DataSet DS = new DataSet();

        public string GetConnectionString()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["CeuDB"].ToString();
            return ConnectionString;
        }
        #endregion
        public CommonAccesses()
        {
            try
            {

                string sql = "SELECT databasepropertyex( 'master', 'STATUS')";

                DataTable DT = this.Execute(sql);

                if (DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];

                    string str = DR[0].ToString();

                    if (str.ToUpper() == "ONLINE") bDBConnected = true;

                }
                //thisConnection.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public CommonAccesses(String sDataSource, String Catalog, String Username, String Password)
        {
            try
            {
                string sql = "SELECT databasepropertyex( 'master', 'STATUS')";

                DataTable DT = this.Execute(sql);

                if (DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];

                    string str = DR[0].ToString();

                    if (str.ToUpper() == "ONLINE") bDBConnected = true;

                }
                //thisConnection.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public DataTable Execute(string SQL)
        {
            DTSP = new DataTable();
            SqlConnection myConnection = new SqlConnection(GetConnectionString());
            try
            {
                using (SqlCommand myCommand = new SqlCommand(SQL, myConnection))
                {
                    myCommand.CommandTimeout = 0;
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        DTSP.Load(myReader);
                        myConnection.Close();
                        foreach (DataColumn col in DTSP.Columns)
                        {
                            col.ReadOnly = false;
                            if (col.DataType.FullName == "System.String")
                                col.MaxLength = 500;
                        }
                        return DTSP;
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return DTSP;
        }
        /// <summary>
        /// Edited By Saif
        /// </summary>
        /// <param name="SQLSP"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public DataTable ExecuteSP(string SQLSP, List<object> parametersvalue, List<string> parametersName)
        {
            DTSP = new DataTable();
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            try
            {
                using (SqlCommand myCommand = new SqlCommand(SQLSP, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandTimeout = 0;

                    if (parametersvalue.Count > 0)
                    {
                        for (int i = 0; i < parametersvalue.Count; i++)
                        {
                            string paramName = parametersName[i];
                            myCommand.Parameters.Add(new SqlParameter(paramName, parametersvalue[i]));
                            myCommand.Parameters[i].Value = parametersvalue[i];
                        }
                    }

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        DTSP.Load(myReader);
                        foreach (DataColumn col in DTSP.Columns)
                        {
                            col.ReadOnly = false;
                            if (col.DataType.FullName == "System.String")
                                col.MaxLength = 500;
                        }
                        myConnection.Close();
                        return DTSP;
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return DTSP;
        }
        public void ExecuteSPInsert(string SQLSP, List<object> parametersvalue, List<string> parametersName)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(SQLSP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametersvalue.Count > 0)
                {
                    for (int i = 0; i < parametersvalue.Count; i++)
                    {
                        string paramName = parametersName[i];
                        cmd.Parameters.Add(new SqlParameter(paramName, parametersvalue[i]));
                        cmd.Parameters[i].Value = parametersvalue[i];

                    }

                }

                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                cn.Close();
            }


        }
        public DataTable ExecuteSP(string SQLSP)
        {
            DTSP = new DataTable();
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            try
            {
                using (SqlCommand myCommand = new SqlCommand(SQLSP, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.CommandTimeout = 0;
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        DTSP.Load(myReader);
                        foreach (DataColumn col in DTSP.Columns)
                        {
                            col.ReadOnly = false;
                            if (col.DataType.FullName == "System.String")
                                col.MaxLength = 500;
                        }
                        myConnection.Close();
                        return DTSP;
                    }
                }
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                myConnection.Close();
            }

            return DTSP;
        }
        public DataSet ExecuteSPDataSet(string SQLSP)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(SQLSP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                DS = new DataSet();
                adapter.Fill(DS);
                cn.Close();
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return DS;
        }

        public DataSet ExecuteSPDataSet(string SQLSP, List<object> parametersvalue, List<string> parametersName)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(SQLSP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametersvalue.Count > 0)
                {
                    for (int i = 0; i < parametersvalue.Count; i++)
                    {
                        string paramName = parametersName[i];
                        cmd.Parameters.Add(new SqlParameter(paramName, parametersvalue[i]));
                        cmd.Parameters[i].Value = parametersvalue[i];

                    }

                }


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                DS = new DataSet();
                adapter.Fill(DS);
                // cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return DS;
        }


        public Boolean UpdateRow(DataRow DR, string sID)
        {

            DataTable DT = new DataTable();
            Boolean bUpdate = false;
            string sql = "SELECT * FROM " + DR.Table.TableName;
            sql += " WHERE " + sID;

            DT = Execute(sql);

            if (DT.Rows.Count > 0)
            {
                sql = "UPDATE " + DR.Table.TableName + " SET ";
                for (int i = 0; i < DR.Table.Columns.Count; i++)
                {
                    if (i > 0) sql += ", ";

                    if (DR[i].GetType().ToString() == "System.String")
                    {
                        sql += DR.Table.Columns[i].ToString() + " = '" + DR[i].ToString() + "'";
                    }
                    else
                    {
                        sql += DR.Table.Columns[i].ToString() + " = " + DR[i].ToString();
                    }
                }
                sql += " WHERE " + sID;
            }
            else
            {
                sql = "INSERT INTO " + DR.Table.TableName + " (";
                for (int i = 0; i < DR.Table.Columns.Count; i++)
                {
                    if (i > 0) sql += ", ";
                    sql += DR.Table.Columns[i].ToString();
                }

                sql += ") VALUES (";

                for (int j = 0; j < DR.Table.Columns.Count; j++)
                {
                    if (j > 0) sql += ", ";

                    if (DR[j].GetType().ToString() == "System.String")
                    {
                        sql += "'" + DR[j].ToString() + "'";
                    }
                    else
                    {
                        if (DR[j].ToString() == "")
                        {
                            sql += "0";
                        }
                        else
                        {
                            sql += DR[j].ToString();
                        }
                    }
                }
                sql += ") ";
            }

            DT = Execute(sql);

            return bUpdate;

        }

        public int ExceuteScalar(string Qry)
        {
            int Value = 0;
            SqlConnection cn = new SqlConnection(GetConnectionString());

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(Qry, cn);
                Value = (int)cmd.ExecuteScalar();


            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return Value;


        }

        public void insert(string InsertQuerry)
        {
            SqlConnection cn = new SqlConnection(GetConnectionString());
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlCommand cmd = new SqlCommand(InsertQuerry);
            cmd.ExecuteNonQuery();


            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = cmd;
        }
        public int ExecuteScalarSPInsert(string SQLSP, List<object> parametersvalue, List<string> parametersName)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            int a = 0;
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(SQLSP, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametersvalue.Count > 0)
                {
                    for (int i = 0; i < parametersvalue.Count; i++)
                    {
                        string paramName = parametersName[i];
                        cmd.Parameters.Add(new SqlParameter(paramName, parametersvalue[i]));
                        cmd.Parameters[i].Value = parametersvalue[i];

                    }

                }

                a = (int)cmd.ExecuteScalar();
                cn.Close();
            }
            catch (SqlException sqlexception)
            {
                string EXstr = sqlexception.Message;
            }
            catch (Exception ex)
            {
                string EXstr = ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return a;

        }


        //Added by Saqib Lodhi

        public void BulkCopyToSQL(string tableName, DataTable dataTableToCopy)
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    s.DestinationTableName = tableName;

                    foreach (var column in dataTableToCopy.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());

                    s.WriteToServer(dataTableToCopy);
                }
            }
        }
    }

    #endregion

}