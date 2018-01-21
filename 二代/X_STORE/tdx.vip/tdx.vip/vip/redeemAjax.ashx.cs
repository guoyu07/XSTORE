using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Creatrue.kernel;
namespace tdx.vip
{
    /// <summary>
    /// redeemAjax1 的摘要说明
    /// </summary>
    public class redeemAjax1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string wid = context.Request.Form["wid"];
            string wwv = context.Request.Form["wwv"];
            string type = context.Request.Form["type"];
            string str = "";
            if (type == "0")
            {
                string _sql = "SELECT * FROM B2C_Goods WHERE   (g_isdel = 0) AND (g_buytype = 2) AND (cityid = " + wid + ")";//查询积分产品（未入回收站）
                try
                {
                    DataTable td = comfun.GetDataTableBySQL(_sql);
                    if (td != null && td.Rows.Count > 0)
                    {
                        str  += GetInfo(td,type);
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "tdxvip/vip/redeem.aspx", wid);
                }
            }
            else if (type == "1")
            {
                string _sqlwwv = "select id from B2C_mem where M_card='"+wwv+"'";
                DataTable dtwwv = comfun.GetDataTableBySQL(_sqlwwv);
                string _wwv = "";
                if (dtwwv != null && dtwwv.Rows.Count > 0)
                {
                    _wwv = dtwwv.Rows[0][0].ToString();
                }
                string _sql = "select gid from B2C_orders where wid="+wid+" and mid="+_wwv+"";//查询一换购商品
                try
                {
                    DataTable td = comfun.GetDataTableBySQL(_sql);
                    string nowtd = "";
                    if (td != null && td.Rows.Count > 0)
                    {
                        foreach (DataRow dr in td.Rows)
                        {
                            nowtd += dr["gid"].ToString();
                        }
                        int index = td.Rows[0][0].ToString().LastIndexOf(',');
                        nowtd = nowtd.Substring(0,index);
                    }
                    _sql = "select * from B2C_Goods where cityid="+wid+" and g_buytype=2 and id in("+nowtd+")";
                    td.Dispose();
                    td = comfun.GetDataTableBySQL(_sql);
                    if (td != null && td.Rows.Count > 0)
                    {
                        str += GetInfo(td,type);
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "tdxvip/vip/redeem.aspx", wid);
                }
            }
            context.Response.Write(str);
        }

        /// <summary>
        /// 输出信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetInfo(DataTable dt,string type)
        {
            string info = "";
            if (type == "0")
            {
                info = "<ul>";
                foreach (DataRow dr in dt.Rows)
                {
                    info += "<li class='gocart' idnum='"+dr["id"]+"'><a><span><img src='" + dr["g_gif"] + "' /></span><i>" + Convert.ToDouble(dr["g_cent"]).ToString("f0") + "积分</i><em>" + dr["g_name"] + "</em></a></li>";
                }
                info += "</ul>";
            }
            else if (type == "1")
            {
                info = "<ul>";
                foreach (DataRow dr in dt.Rows)
                {
                    info += "<li><a><span><img src='" + dr["g_gif"] + "' /></span><i>" + Convert.ToDouble(dr["g_cent"]).ToString("f0") + "积分</i><em>" + dr["g_name"] + "</em></a></li>";
                }
                info += "</ul>";
            }
            return info;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}