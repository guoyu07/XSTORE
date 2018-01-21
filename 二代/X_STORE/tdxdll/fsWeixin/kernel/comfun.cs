using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;

namespace tdx.kernel
{
    public class comfun
    {
        public static string CreateShop()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("<div class=\"lv1\">");
            sbResult.Append("  <div class=\"arrow\">");
            sbResult.Append(" </div>");
            sbResult.Append(" <a class=\"index_menu_title\" href=\"javascript:void(0)\">微商城</a>");
            sbResult.Append(" </div>");
            sbResult.Append("<div class=\"index_menu\">");
            sbResult.Append("<div>");
            sbResult.Append("<div class=\"lv2\">");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Shop_Config.aspx\" target=\"mainFram\">商城配置</a>");
            sbResult.Append(" </div>");


            sbResult.Append("  <div class=\"lv2\">");
            sbResult.Append("<div class=\"arrow\">");
            sbResult.Append(" </div>");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品管理</a>");
            sbResult.Append("</div>");
            sbResult.Append(" <div class=\"index_menu2\">");
            sbResult.Append("<div>");
            sbResult.Append(" <div class=\"lv3\">");
            sbResult.Append("<a href=\"/memb/Goods/B2C_category_List.aspx\" target=\"mainFram\">产品类别</a>");
            sbResult.Append("</div>");
            sbResult.Append("  <div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_brand_List.aspx\" target=\"mainFram\">产品品牌</a>");
            sbResult.Append("</div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Goods_List.aspx\" target=\"mainFram\">产品内容添加</a>");
            sbResult.Append("</div>");
            sbResult.Append("  </div>");
            sbResult.Append("  </div>");
            ////////////////////////////////////////////////////////////////////
            sbResult.Append("  <div class=\"lv2\">");
            sbResult.Append("<div class=\"arrow\">");
            sbResult.Append(" </div>");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">会员特权产品管理</a>");
            sbResult.Append("</div>");
            sbResult.Append(" <div class=\"index_menu2\">");
            sbResult.Append("<div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_Vip_List.aspx\" target=\"mainFram\">特权产品内容添加</a>");
            sbResult.Append("</div>");
            sbResult.Append("  </div>");
            sbResult.Append("  </div>");
            ////////////////////////////

            sbResult.Append("  <div class=\"lv2\">");
            sbResult.Append("<div class=\"arrow\">");
            sbResult.Append(" </div>");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">会员积分兑换产品管理</a>");
            sbResult.Append("</div>");
            sbResult.Append(" <div class=\"index_menu2\">");
            sbResult.Append("<div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_JiFen_List.aspx\" target=\"mainFram\">积分兑换产品内容添加</a>");
            sbResult.Append("</div>");
            sbResult.Append("  </div>");
            sbResult.Append("  </div>");

            /////////////////////////
            sbResult.Append("  <div class=\"lv2\">");
            sbResult.Append("<div class=\"arrow\">");
            sbResult.Append(" </div>");
            sbResult.Append("<a class=\"index_menu2_title\" href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品管理</a>");
            sbResult.Append("</div>");
            sbResult.Append(" <div class=\"index_menu2\">");
            sbResult.Append("<div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/Goods/B2C_taocan_List.aspx\" target=\"mainFram\">打包套餐产品添加</a>");
            sbResult.Append("</div>");
            sbResult.Append("  </div>");
            sbResult.Append("  </div>");

            /////////////////////////


            sbResult.Append("<div class=\"lv2\">");
            sbResult.Append("<div class=\"arrow\">");
            sbResult.Append("</div>");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"javascript:void(0)\">订单管理</a>");
            sbResult.Append("</div>");
            sbResult.Append(" <div class=\"index_menu2\">");
            sbResult.Append("<div>");
            sbResult.Append(" <div class=\"lv3\">");
            sbResult.Append("  <a href=\"/memb/Goods/B2C_order_List.aspx\" target=\"mainFram\">订单查询</a>");
            sbResult.Append("</div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/reg_advance.aspx\" target=\"mainFram\">订单导出</a>");
            sbResult.Append(" </div>");
            sbResult.Append("</div>");
            sbResult.Append("  </div>");
            sbResult.Append(" <div class=\"lv2\">");
            sbResult.Append("<div class=\"arrow\">");
            sbResult.Append(" </div>");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"/memb/Goods/Action_TeamList.aspx\" target=\"mainFram\">团购管理</a>");
            sbResult.Append(" </div>");
            sbResult.Append(" <div class=\"index_menu2\">");
            sbResult.Append(" <div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append(" <a href=\"/memb/Goods/Action_TeamList.aspx\" target=\"mainFram\">团购列表</a>");
            sbResult.Append("</div>");
            sbResult.Append("<div class=\"lv3\">");
            sbResult.Append("<a href=\"/memb/Goods/tm_order_List.aspx\" target=\"mainFram\">团购订单</a>");
            sbResult.Append("</div>");
            sbResult.Append(" </div>");
            sbResult.Append(" </div>");
            sbResult.Append("<div class=\"lv2\">");
            sbResult.Append(" <div class=\"arrow\">");

            sbResult.Append(" </div>");
            sbResult.Append(" <a class=\"index_menu2_title\" href=\"/memb/Goods/Action_MsList.aspx\" target=\"mainFram\">秒杀管理</a>");

            sbResult.Append("</div>");

            sbResult.Append("<div class=\"index_menu2\">");
            sbResult.Append("<div>");

            sbResult.Append("   <div class=\"lv3\">");

            sbResult.Append("<a href=\"/memb/Goods/Action_MsList.aspx\" target=\"mainFram\">秒杀设置</a>");

            sbResult.Append(" </div>");

            sbResult.Append(" <div class=\"lv3\">");

            sbResult.Append("<a href=\"/memb/Goods/ms_order_List.aspx\" target=\"mainFram\">秒杀订单</a>");

            sbResult.Append("    </div>");
            sbResult.Append("</div> ");
            sbResult.Append(" </div> ");
            sbResult.Append("  </div> ");
            sbResult.Append("</div> ");

            //        <%--     <div class="lv2"><div class="arrow"></div><a class="index_menu2_title" href="javascript:void(0)">预定管理</a></div>
            //<div class="index_menu2">
            //    <div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">预订设置</a> </div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">预订订单</a> </div>
            //    </div>
            //</div>
            //<div class="lv2"><div class="arrow"></div><a class="index_menu2_title" href="javascript:void(0)">订餐管理</a></div>
            //<div class="index_menu2">
            //    <div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">订餐管理</a> </div>
            //        <div class="lv3"><a href="/memb/reg_advance.aspx" target="mainFram">订餐订单</a> </div>
            //    </div>
            //</div>--%>
            return sbResult.ToString();
        }
        /// <summary>
        /// 根据类型生成菜单
        /// </summary>
        /// <param name="_type">什么模板类型</param>
        /// <param name="_wid">wid</param>
        /// <returns></returns>
        public static string CreateMenu(int _type, int _wid)
        {

            switch (_type)
            {
                case 1:
                    return "";
                    break;
                case 2:
                    return comfun.CreateShop();
                    break;
                default:
                    return "";
                    break;
            }


        }
        /// <summary>
        /// 处理异常信息
        /// </summary>
        /// <param name="exn">异常对象</param>
        /// <param name="className">发生异常的当前类</param>
        /// <param name="wid">发生异常的用户标识</param>
        public static void ChuliException(Exception exn, string className, string wid)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand("ex_msg", oracleConnection);
            oracleCommand.CommandTimeout = 9999;
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("@wid", SqlDbType.VarChar);
            oracleCommand.Parameters["@wid"].Value = wid;
            oracleCommand.Parameters.Add("@message", SqlDbType.NText);
            oracleCommand.Parameters["@message"].Value = exn.Message;
            oracleCommand.Parameters.Add("@track", SqlDbType.NText);
            oracleCommand.Parameters["@track"].Value = exn.StackTrace;
            oracleCommand.Parameters.Add("@className", SqlDbType.VarChar);
            oracleCommand.Parameters["@className"].Value = className;
            oracleConnection.Open();
            try
            {

                int count = oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // throw new NotSupportedException(ex.Message + wid);
            }
            finally
            {
                oracleConnection.Close();
            }
        }

        public static void ChuliControl(int wid)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand("objControl", oracleConnection);
            oracleCommand.CommandTimeout = 9999;
            oracleCommand.CommandType = CommandType.StoredProcedure;
            oracleCommand.Parameters.Add("@wid", SqlDbType.Int);
            oracleCommand.Parameters["@wid"].Value = wid;
            oracleConnection.Open();
            try
            {

                int count = oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message + wid);
            }
            finally
            {
                oracleConnection.Close();
            }
        }
        public static System.Data.DataTable GetDataTableBySQL(string SuperSQL)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(SuperSQL, oracleConnection);
            oracleCommand.CommandTimeout = 9999;
            oracleConnection.Open();
            System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter(oracleCommand);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            try
            {

                dataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message + SuperSQL);
            }
            finally
            {
                oracleConnection.Close();
            }
        }
        public static int InsertBySQL(string SQL)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
            string queryString = SQL;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);
            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }
            return rowsAffected;
        }
        public static int UpdateBySQL(string SQL)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
            string queryString = SQL;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);
            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }
            return rowsAffected;
        }
        public static int DelbySQL(string SQL)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
            string querystring = SQL;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(querystring, oracleConnection);
            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }
            return rowsAffected;
        }


        /// ''' 取值类函数
        public static string GetStrByInt(string 字段名, string 表名, string 依据字段, int 依据值)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "select Top 1 " + 字段名 + " from " + 表名 + " where  " + 依据字段 + "=" + 依据值 + "";
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            string rowsAffected = "";
            oracleConnection.Open();
            try
            {
                rowsAffected = ((oracleCommand.ExecuteScalar() == DBNull.Value) ? "" : Convert.ToString(oracleCommand.ExecuteScalar()));
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return (rowsAffected.Trim());
        }
        //获取表集合
        public static System.Data.DataSet GetDataSetBySQL(string SuperSQL)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(SuperSQL, oracleConnection);
            oracleCommand.CommandTimeout = 999;

            System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter(oracleCommand);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            try
            {
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }
        }

        public static System.Data.DataTable GetDataTableBySQL2005(string SuperSQL, int PageSize, int PageIndex, string SortField, bool SortType)
        {
            //改造SuperSQL，使其具备分页的功能
            SuperSQL = SuperSQL.ToLower();
            //Dim SuperSQL_tmp = SuperSQL.Substring(0, SuperSQL.IndexOf("from") + 4)
            //Dim SuperSQL_tmp2 = SuperSQL.Substring(SuperSQL.IndexOf("from") + 4)

            if (SortType)
            {
                SuperSQL = SuperSQL.Replace("from", ",ROW_NUMBER() OVER (ORDER BY " + SortField + ") AS RowNo from");
            }
            else
            {
                SuperSQL = SuperSQL.Replace("from", ",ROW_NUMBER() OVER (ORDER BY " + SortField + " DESC) AS RowNo from");
            }
            SuperSQL = "SELECT TOP " + PageSize + " * FROM (" + SuperSQL + ") AS A WHERE RowNo > " + (PageIndex - 1) * PageSize;
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(SuperSQL, oracleConnection);

            System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter(oracleCommand);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            try
            {
                dataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }
        }
        public static int GetMaxField(string 表名, string 字段名)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
            string queryString = "SELECT MAX(" + 字段名 + ") AS MaxField FROM  " + 表名;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = (oracleCommand.ExecuteScalar() == DBNull.Value) ? 0 : Convert.ToInt32(oracleCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsAffected;
        }

        public static int GetMinField(string 表名, string 字段名)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "SELECT Min(" + 字段名 + ") AS MaxField FROM  " + 表名;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = (oracleCommand.ExecuteScalar() == DBNull.Value) ? 0 : Convert.ToInt32(oracleCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsAffected;
        }

        public static int GetFieldCount(string 表名, string ParaSQL)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "SELECT COUNT(*) AS FieldCount FROM " + 表名 + " where " + ParaSQL;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = Convert.ToInt32(oracleCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsAffected;
        }

        public static int GetFieldSumByInt(string 表名, string 字段名, string ParaSQL)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "SELECT isnull(sum(" + 字段名 + "),0) AS CountNumber FROM " + 表名 + " where " + ParaSQL;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = Convert.ToInt32(oracleCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsAffected;
        }

        public static decimal GetFieldSumByDec(string 表名, string 字段名, string ParaSQL)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "SELECT isnull(sum(" + 字段名 + "),0) AS CountNumber FROM " + 表名 + " where " + ParaSQL;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            decimal rowsAffected = default(decimal);
            oracleConnection.Open();
            try
            {
                rowsAffected = Convert.ToDecimal(oracleCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsAffected;
        }

        /// '''  删除类函数
        public static int DelByInt(string 表名, string 依据字段, long 依据值)
        {

            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "DELETE FROM " + 表名 + " WHERE " + 依据字段 + " =" + 依据值;
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand(queryString, oracleConnection);

            int rowsAffected = 0;
            oracleConnection.Open();
            try
            {
                rowsAffected = oracleCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }

            return rowsAffected;
        }

        /// <summary>
        /// ----------
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public void ExecuteNonQuery(string sql, System.Data.SqlClient.SqlParameter[] paras)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, oracleConnection);
            cmd.Parameters.AddRange(paras);
            cmd.CommandType = CommandType.Text;
            oracleConnection.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
            finally
            {
                oracleConnection.Close();
            }
            // return dt;
        }

        /// <summary>
        /// HTML解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DeCodeHtml(string str)
        {
            //先进行URI解码
            str = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Server.UrlDecode(str));
            //过滤script
            Regex r = new Regex(@"<script.*?>.*?<\/script>");
            Regex noFrom = new Regex(@"<form.*?>");
            Match m;
            m = r.Match(str);
            if (m.Value.Length > 0)
            {
                str = str.Replace(m.Value, "");
            }
            m = noFrom.Match(str);
            if (m.Value.Length > 0)
            {
                str = str.Replace(m.Value, "");
            }
            noFrom = new Regex(@"<\/form>");
            m = noFrom.Match(str);
            if (m.Value.Length > 0)
            {
                str = str.Replace(m.Value, "");
            }
            //再进行HTML解码
            // str = HttpContext.Current.Server.HtmlDecode(str);
            return str;
        }

        /// <summary>
        /// HTML加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EnCodeHtml(string str)
        {
            //先进行HTML编码
            //str = HttpContext.Current.Server.HtmlEncode(str);
            //再进行URI编码
            str = HttpContext.Current.Server.UrlEncode(HttpContext.Current.Server.UrlEncode(str).Replace("+", "%20")).Replace("+", "%20");

            return str;
        }

        public static int InsertBySQL(List<string> SQL)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);
            System.Data.SqlClient.SqlCommand oracleCommand = new System.Data.SqlClient.SqlCommand();
            oracleCommand.Connection = oracleConnection;
            int rowsAffected = 0;
            oracleConnection.Open();
            System.Data.SqlClient.SqlTransaction tran = oracleConnection.BeginTransaction();
            try
            {
                foreach (string s in SQL)
                {
                    oracleCommand.Transaction = tran;
                    oracleCommand.CommandText = s;
                    rowsAffected += oracleCommand.ExecuteNonQuery();

                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new NotSupportedException(ex.Message);

            }
            finally
            {
                oracleConnection.Close();
            }
            return rowsAffected;
        }

    }
}