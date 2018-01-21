using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
namespace DTcms.DBUtility
{
    public class SqlHelper0
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
      
        public SqlHelper0() { }
        
        #region Query查询
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet Query(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        public static DataSet Query(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sql, parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion

        #region GetSingle()方法
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingle(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        private static object GetSingle(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, sql, parameters);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion

        #region ExecuteSql()方法
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        //public static int ExecuteSql0(string sql)
        //{

        //    using (SqlConnection connection = new SqlConnection(connectionString1))
        //    {
              
        //        using (SqlCommand cmd = new SqlCommand(sql, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //        }
        //    }
        //}



        //public static int ExecuteSqlmessage(string sql)
        //{  
    
        //    string sqlconn = "Server=120.195.111.209;Port=3306;Database=massi2;Uid=root;Pwd=Jpp0917Fly";

        //    using (MySqlConnection myConnection = new MySqlConnection(sqlconn))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand(sql, myConnection))
        //        {
        //            try
        //            {
        //                myConnection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (MySql.Data.MySqlClient.MySqlException e)
        //            {
        //                myConnection.Close();

        //                throw e;
        //            }
        //        }
        //    } 
           
        //}
        public static int ExecuteSql(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, sql, parameters);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion

        #region Exists()方法
        public static bool Exists(string sql, SqlParameter[] parameters)
        {
            object obj = SqlHelper0.GetSingle(sql, parameters);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region GetMaxID()方法
        public static int GetMaxID(string field_name, string table_name)
        {
            string strsql = "select max(" + field_name + ")+1 from " + table_name;
            object obj = SqlHelper0.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj.ToString());
            }
        }
        #endregion

        public static DataSet RunProcedure(string storedProcName, SqlParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        public static string GetRelateData(string sql)
        {
            string name = String.Empty;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd=new SqlCommand();
                try
                {
                    cmd.Connection=connection;
                    cmd.CommandText=sql;
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        name = sdr[0].ToString();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return name;
            }
        }
        #region 通过SQL语句查询数据
        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTableBySQL(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandTimeout = 9999;
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                try
                {

                    dataAdapter.Fill(dataSet);
                    return dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new NotSupportedException(ex.Message + sql);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion


        #region 通过SQL语句查询数据
        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSetBySql(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandTimeout = 9999;
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                try
                {

                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }
                catch (Exception ex)
                {
                    throw new NotSupportedException(ex.Message + sql);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion


        #region 通过SQL语句查询数据
        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public static DataTable XDGetDataTableBySQL(string sql)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString1))
        //    {
        //        SqlCommand cmd = new SqlCommand(sql, connection);
        //        cmd.CommandTimeout = 9999;
        //        connection.Open();
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        //        DataSet dataSet = new DataSet();
        //        try
        //        {

        //            dataAdapter.Fill(dataSet);
        //            return dataSet.Tables[0];
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new NotSupportedException(ex.Message + sql);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
        #endregion



        #region 分页
        public static string GetArrowHtmlNew(int _ipage, int totalcount, int _pagesize, NameValueCollection forms, NameValueCollection quests)
        {
            string ques = "";
            //  List<string> names = new List<string>();
            Dictionary<string, string> names = new Dictionary<string, string>();
            foreach (string keyName in forms.Keys)
            {
                if (keyName != "page")
                {
                    if (keyName.Equals("ss_cid") || keyName.Equals("ss_keyword"))
                    {
                        ques += "&" + keyName + "=" + forms[keyName];
                        names.Add(keyName, "");
                    }
                }
            }
            foreach (string keyNa in quests.Keys)
            {
                if (keyNa != "page")
                {
                    if (names.ContainsKey(keyNa))
                        continue;
                    else
                    {
                        ques += "&" + keyNa + "=" + quests[keyNa];
                        names.Add(keyNa, "");
                    }


                }
            }

            string result = "";
            result = result + "<input type='hidden' name='page' value='" + _ipage + "' />";
            result = result + "<script language='javascript'>";
            result = result + " function setAction(_tmpi)";
            result = result + " {";
            result = result + "    document.form1.page.value=_tmpi;";
            //result = result & "    document.form1.action= _url;" & vbCrLf
            //result = result & "    document.form1.submit();" & vbCrLf
            result = result + "    __doPostBack('ss_btn','');";
            result = result + " } ";
            result = result + "</script>";
            result += "\n <div style=\"clear: both;margin:10px auto;\">";
            //添加样式
            result += "\n <style>";
            result += "\n";
            result += "\n.page_fenye{display:inline;margin:0 auto;padding:0;overflow:hidden;}";
            result += "\n.prev,.arrow_num,.next{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;border:1px solid #cccccc;font-weight: bolder;color: #420100}";
            //result += "\n.prev a,.arrow_num a,.next a{color: #420100}";
            //result += "\n.prev a:hover,.arrow_num a:hover,.next a:hover{color: #fe0000}";
            result += "\n.pagecurr{width: auto;height: auto;margin: 5px;padding: 5px 8px 5px 10px; line-height: 30px;color: #FF6600;border:1px solid #FF6600;font-weight: bolder;}";
            result += "\n";
            result += "\n </style>";

            int _totalpage = totalcount / _pagesize;
            if (totalcount % _pagesize != 0)
            {
                _totalpage = _totalpage + 1;
            }
            int forwardpage = _ipage - 1;
            if (forwardpage < 1)
            {
                forwardpage = 1;
            }
            int backpage = _ipage + 1;
            if (backpage > _totalpage)
            {
                backpage = _totalpage;
            }

            //页数多于1页时才显示分页控制器
            if (_totalpage > 1)
            {
                //存在分页控制器即存在"上一页"按钮
                if (_ipage == 1)
                {
                    result += "<a class=\"prev\">上一页</a>" + "\n";
                }
                else
                {
                    result += "<a class=\"prev\" href='?page=" + forwardpage + ques + "'>上一页</a>" + "\n";// 
                }


                if (_totalpage < 12)//12//直接输出分页页码,不存在翻页后的...控制
                {
                    for (int _tmppage = 1; _tmppage <= _totalpage; _tmppage++)
                    {
                        string cclassname = "arrow_num";
                        if (_tmppage == _ipage)
                        {
                            cclassname = "pagecurr";
                        }
                        result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n"; // 
                    }
                }
                else //多于12页,需要存在...控制
                {
                    ///////////////小于5不跳分页数字
                    if (_ipage < 5)//10//前半部分,1~5,直接显示成页码框
                    {
                        for (int _tmppage = 1; _tmppage <= 5; _tmppage++)
                        {
                            string cclassname = "arrow_num";
                            if (_tmppage == _ipage)
                            {
                                cclassname = "pagecurr";
                            }
                            result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";// 
                        }
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        ///////////////////////注释添加...后的框样式

                        result += "<a class=\"arrow_num\" href='?page=" + _totalpage + ques + "'> " + _totalpage + " </a>" + "\n";// 
                    }
                    else
                    {
                        result += "<a class=\"arrow_num\"  href='?page=1'" + ques + "> 1 </a>" + "\n";//
                        result += "<span class=\"pagetext\">...</span>" + "\n";
                        if ((_totalpage - _ipage) > 5)//后半段也需要...
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= (_ipage + 4); _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";//
                            }
                            result += "<span class=\"pagetext\">...</span>" + "\n";
                            result += "<a class=\"arrow_num\" href='?page=" + _totalpage + ques + "'> " + _totalpage + " </a>" + "\n";//
                        }
                        else if ((_totalpage - _ipage) > 2)
                        {
                            for (int _tmppage = (_ipage - 2); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n";// 
                            }
                            //后半段不需要...,并且从7-ipage处开始
                        }
                        else
                        {
                            for (int _tmppage = (_totalpage - 6); _tmppage <= _totalpage; _tmppage++)
                            {
                                string cclassname = "arrow_num";
                                if (_tmppage == _ipage)
                                {
                                    cclassname = "pagecurr";
                                }
                                result += "<a class=\"" + cclassname + "\" href='?page=" + _tmppage + ques + "'> " + _tmppage + " </a>" + "\n"; //
                            }
                        }
                    }
                }

                //存在分页控制器,即存在"下一页"按钮
                if (_ipage == _totalpage)
                {
                    result += "<a class=\"next\"> 下一页 </a>" + "\n";
                }
                else
                {
                    result += "<a class=\"next\" href='?page=" + backpage + ques + "'> 下一页 </a>" + "\n";//
                }

            }
            result += "\n </div>";

            return result;
        }
        #endregion
    }
}
