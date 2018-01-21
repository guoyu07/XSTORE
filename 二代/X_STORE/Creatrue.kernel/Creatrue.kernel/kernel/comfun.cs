using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Creatrue.kernel
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
        public System.Data.DataTable GetDataTable(string SuperSQL)
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
        public int Insert(string SQL)
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

        public int Update(string SQL)
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

        public int Del(string SQL)
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

        public static string GetStrbySQL(string 字段名, string 表名, string 语句Sql)
        {
            System.Data.SqlClient.SqlConnection oracleConnection = new System.Data.SqlClient.SqlConnection(consts.constr);

            string queryString = "select Top 1 " + 字段名 + " from " + 表名 + " where 1=1 and " + 语句Sql;
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

        #region


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="ps">参数列表</param>
        /// <returns>返回存储过程成功与否</returns>
        public int ExecuteNonQuerySP(string cmdText, params SqlParameter[] ps)
        {
            return this.ExecuteNonQuery(cmdText, CommandType.StoredProcedure, ps);
        }

        /// <summary>
        /// 执行SQL语句或存储过程，返回结果
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="type">执行类型</param>
        /// <param name="ps">参数列表</param>
        /// <returns>返回受影响行数或存储过程成功与否</returns>
        public int ExecuteNonQuery(string cmdText, CommandType type, params SqlParameter[] ps)
        {
            if (type == CommandType.Text)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(consts.constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            conn.Open();
                            return cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (type == CommandType.StoredProcedure)
            {
                try
                {
                    ps[ps.Length - 1].Direction = ParameterDirection.Output;
                    using (SqlConnection conn = new SqlConnection(consts.constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return (int)ps[ps.Length - 1].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 执行查询语句，返回第一行第一列数据
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="ps">参数列表</param>
        /// <returns>第一行第一列数据</returns>
        public object ExecuteScalar(string cmdText, params SqlParameter[] ps)
        {
            return ExecuteScalar(cmdText, CommandType.Text, ps);
        }

        /// <summary>
        /// 执行存储过程，返回存储过程返回值
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="ps">参数列表</param>
        /// <returns>存储过程返回值</returns>
        public object ExecuteScalarSP(string cmdText, params SqlParameter[] ps)
        {
            return ExecuteScalar(cmdText, CommandType.StoredProcedure, ps);
        }

        /// <summary>
        /// 执行查询语句或存储过程，返回第一行第一列数据或存储过程返回值
        /// </summary>
        /// <param name="cmdText">Sql语句或存储过程名称</param>
        /// <param name="ps">参数列表</param>
        /// <returns>第一行第一列数据或存储过程返回值</returns>
        public object ExecuteScalar(string cmdText, CommandType type, params SqlParameter[] ps)
        {
            if (type == CommandType.Text)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(consts.constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            conn.Open();
                            return cmd.ExecuteScalar();
                        }
                    }
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
            else if (type == CommandType.StoredProcedure)
            {
                try
                {
                    for (int i = 0; i < ps.Length; i++)
                    {
                        if (ps[i].Value == null)
                        {
                            ps[i].Direction = ParameterDirection.Output;
                        }
                    }
                    using (SqlConnection conn = new SqlConnection(consts.constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                        {
                            cmd.CommandType = type;
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            conn.Open();
                            cmd.ExecuteScalar();
                        }
                    }
                    List<Object> returnValue = new List<object>();
                    for (int i = 0; i < ps.Length; i++)
                    {
                        if (ps[i].Direction == ParameterDirection.Output)
                        {
                            returnValue.Add(ps[i].Value);
                        }
                    }
                    return returnValue;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 执行查询语句，并返回一个DataReader阅读器
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="ps">参数列表</param>
        /// <returns>DataReader阅读器</returns>
        public SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] ps)
        {
            return ExecuteReader(cmdText, CommandType.Text, ps);
        }

        /// <summary>
        /// 执行存储过程，并返回一个DataReader阅读器
        /// </summary>
        /// <param name="cmdText">存储过程名称</param>
        /// <param name="ps">参数列表</param>
        /// <returns>DataReader阅读器</returns>
        public SqlDataReader ExecuteReaderSP(string cmdText, params SqlParameter[] ps)
        {
            return ExecuteReader(cmdText, CommandType.StoredProcedure, ps);
        }

        /// <summary>
        /// 执行查询语句或存储过程，并返回一个DataReader阅读器
        /// </summary>
        /// <param name="cmdText">Sql语句或存储过程名称</param>
        /// <param name="ps">参数列表</param>
        /// <returns>DataReader阅读器</returns>
        public SqlDataReader ExecuteReader(string cmdText, CommandType type, params SqlParameter[] ps)
        {
            SqlConnection conn = new SqlConnection(consts.constr);
            try
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw (ex);
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="ps">参数列表</param>
        /// <returns>返回的DataSet</returns>
        public DataSet GetDataSet(string cmdText, params SqlParameter[] ps)
        {
            return this.GetDataSet(cmdText, CommandType.Text, ps);
        }

        /// <summary>
        /// 执行存储过程返回DataSet
        /// </summary>
        /// <param name="cmdText">存储过程名</param>
        /// <param name="ps">参数列表</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSetSP(string cmdText, params SqlParameter[] ps)
        {
            return this.GetDataSet(cmdText, CommandType.StoredProcedure, ps);
        }

        /// <summary>
        /// 执行存储过程，或SQL语句，返回DataSet
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名称</param>
        /// <param name="type">执行类型</param>
        /// <param name="ps">参数列表</param>
        /// <returns>返回DataSet</returns>
        public DataSet GetDataSet(string cmdText, CommandType type, params SqlParameter[] ps)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmdText, consts.constr))
                {
                    if (ps != null)
                    {
                        sda.SelectCommand.Parameters.AddRange(ps);
                    }
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sda.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                ds.Dispose();
                throw (ex);
            }
        }
        #endregion

    }
}