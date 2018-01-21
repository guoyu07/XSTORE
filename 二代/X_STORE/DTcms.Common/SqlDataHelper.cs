using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DTcms.Common
{
    public  class SqlDataHelper
    {
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        #region 1.为cmd命令对象做执行前参数设定
        /// <summary>
        /// 为cmd命令对象做执行前参数设定
        /// </summary>
        /// <param name="cmd">cmd命令对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">sql命令文本,</param>
        /// <param name="cmdParms">在命令文本中要使用的 sql参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();//如果连接通道未打开 则打开通道
            cmd.Connection = conn;//为命令对象设置连接通道
            cmd.CommandText = cmdText;//为命令对象设置sql文本
            if (trans != null) cmd.Transaction = trans;//如果存在事务，则为命令对象设置事务
            cmd.CommandType = cmdType;//设置命令类型(sql文本/存储过程)
            if (cmdParms != null) cmd.Parameters.AddRange(cmdParms);//如果参数集合不为空，为命令对象添加参数
        }
        #endregion

        #region 2.执行sql命令 增删改
        /// <summary>
        /// 执行sql命令 增删改(无参数)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText)
        {
            return ExecuteCommand(cmdText, null);
        }

        /// <summary>
        /// 执行sql命令 增删改(带参数)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText, SqlParameter[] parameters)
        {
            #region 原方法代码
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                int val = 0;
                try
                {
                    val = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return val;
            } 
            #endregion
            //return ExecuteCommand(cmdText, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行sql命令 增删改(带参数)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="commandParameters">参数集合</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText, CommandType cmdType, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int res = 0;
                try
                {
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return res;
            }
            //return ExecuteCommand(cmdText, null, cmdType, commandParameters);
        }

        /// <summary>
        /// 执行sql命令 增删改
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static int ExecuteCommand(string cmdText, SqlTransaction trans, CommandType cmdType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, parameters);
            int res =0;
            try
            {
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            { 
            }
            cmd.Parameters.Clear();
            return res;
        }
        #endregion

        #region 3.执行sql命令 查询
        /// <summary>
        /// 执行sql命令 查询
        /// </summary>
        /// <param name="sqlStr">sql命令语句</param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(string sqlStr)
        {
            #region 原方法代码
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter(sqlStr, connection);
            //    DataTable dt = new DataTable();
            //    try
            //    {
            //        da.Fill(dt);
            //    }
            //    catch (Exception)
            //    { 
            //    }
            //    return dt;
            //} 
            #endregion
            return GetDataTable(sqlStr, null);
        }

        /// <summary>
        /// 执行sql命令 查询
        /// </summary>
        /// <param name="sqlStr">sql命令语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(string sqlStr,SqlParameter[] parameters)
        {
            return GetDataTable(sqlStr, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行sql命令 查询
        /// </summary>
        /// <param name="sqlStr">sql命令语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="parameters">参数集合</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sqlStr,CommandType type, SqlParameter[] parameters) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlStr, connection);
                cmd.CommandType = type;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return dt;
            }
        }

        /// <summary>
        /// 执行sql命令 (查询)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <returns></returns>
        public static object GetScalar(string cmdText) 
        {
            return GetScalar(cmdText, null);
        }


        /// <summary>
        /// 执行sql命令 (查询)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>第一行第一列的值（object类型）</returns>
        public static object GetScalar(string cmdText,SqlParameter[] parameters)
        {
            return GetScalar(cmdText, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行sql命令 (查询)
        /// </summary>
        /// <param name="cmdText">sql命令语句</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>第一行第一列的值（object类型）</returns>
        public static object  GetScalar(string cmdText, CommandType cmdType, System.Data.SqlClient.SqlParameter[] parameters)
        {
            object res = 0;
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, parameters);
                try
                {
                    res = cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                }
                cmd.Parameters.Clear();
                return res;
            }
        }
        #endregion

    }
}

