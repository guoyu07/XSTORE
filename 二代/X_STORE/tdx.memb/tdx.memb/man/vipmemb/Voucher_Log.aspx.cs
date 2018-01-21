using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.vipmemb
{
    public partial class Voucher_Log : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int pagesize = 20;
                    string firstSql = @"select [C2C_voucher_log].[id],
[C2C_voucher].[v_amount],
[C2C_voucher].[v_deduction],
[B2C_mem].[M_name],
[C2C_voucher_log].[isuse],
[C2C_voucher_log].[vl_date],
[C2C_voucher_log].[vl_update] from C2C_voucher_log 
inner join [C2C_voucher] on [C2C_voucher_log].[v_id]=[C2C_voucher].[id] 
and [C2C_voucher].[wid]=" + Session["wID"].ToString() + " inner join [B2C_mem] on [C2C_voucher_log].[mid]=[B2C_mem].[id]) as tb";
                    string safeSql = @"select top 1 * from (" + firstSql;
                    DataTable dt = comfun.GetDataTableBySQL(safeSql);
                    if (dt.Rows.Count > 0)
                    {
                        int _page = (Request["page"] != null ? int.Parse(Request["page"]) : 1);
                        string _sqlLog = @"select *,(row_number() over(order by id desc)) as rown from(" + firstSql;
                        _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";
                        zdList.Text = pagelist(_sqlLog, dt);
                        int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + firstSql).Rows[0][0]);
                        lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/Voucher_Log.cs", Session["wID"].ToString());
                }
            }

        }
        private string pagelist(string _sql, DataTable _tab)
        {
            string result1 = "";
            try
            {
                DataTable dtNew = comfun.GetDataTableBySQL(_sql);
                result1 += "\r\n";
                result1 += " \r\n <table>";
                result1 += " \r\n <tbody>";
                result1 += "\r\n <tr>";
                result1 += "\r\n <th >领取的用户</th> ";
                result1 += "\r\n <th >代金卷信息</th> ";
                result1 += "\r\n <th >是否已使用</th> ";
                result1 += "\r\n <th >领取时间</th> ";
                result1 += "\r\n <th >使用时间</th> ";
                result1 += " \r\n </tr>";
                foreach (DataRow dr in dtNew.Rows)
                {
                    result1 += " \r\n <tr>";
                    result1 += " \r\n <td >" + dr["M_name"].ToString() + "</td> ";
                    result1 += " \r\n <td >购买" + dr["v_amount"] + "元，返回" + dr["v_deduction"] + "元</td> ";
                    result1 += " \r\n <td >" + result(dr["isuse"].ToString()) + "</td> ";
                    result1 += " \r\n <td >" + dr["vl_date"] + "</td> ";
                    result1 += " \r\n <td >" + dr["vl_update"] + "</td> ";
                    result1 += "\r\n </tr>";
                }
                return result1;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/Voucher_Log.cs", Session["wID"].ToString());
                return result1;
            }
        }

        protected void btn_downexcel(object sender, EventArgs e)
        { }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string firstSql = @"select [C2C_voucher_log].[id],
[C2C_voucher].[v_amount],
[C2C_voucher].[v_deduction],
[B2C_mem].[M_name],
[C2C_voucher_log].[isuse],
[C2C_voucher_log].[vl_date],
[C2C_voucher_log].[vl_update] from C2C_voucher_log 
inner join [C2C_voucher] on [C2C_voucher_log].[v_id]=[C2C_voucher].[id] 
and [C2C_voucher].[wid]=" + Session["wID"].ToString() + " inner join [B2C_mem] on [C2C_voucher_log].[mid]=[B2C_mem].[id]) as tb";
                int pagesize = 20;
                if (sousuo_txt.Value.Trim() == "" || sousuo_txt.Value == "")
                {
                    string safeSql = @"select top 1 * from (" + firstSql;
                    DataTable dt = comfun.GetDataTableBySQL(safeSql);
                    if (dt.Rows.Count > 0)
                    {
                        int _page = (Request["page"] != null ? int.Parse(Request["page"]) : 1);
                        string _sqlLog = @"select *,(row_number() over(order by id desc)) as rown from(" + firstSql;
                        _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";
                        zdList.Text = pagelist(_sqlLog, dt);
                        int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + firstSql).Rows[0][0]);
                        lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    }
                }
                else
                {
                    string _where = " where M_name like '%" + sousuo_txt.Value + "%'";
                    string safeSql = @"select top 1 * from (" + firstSql + _where;
                    DataTable dt = comfun.GetDataTableBySQL(safeSql);
                    if (dt.Rows.Count > 0)
                    {
                        int _page = (Request["page"] != null ? int.Parse(Request["page"]) : 1);
                        string _sqlLog = @"select *,(row_number() over(order by id desc)) as rown from(" + firstSql + _where;
                        _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";
                        zdList.Text = pagelist(_sqlLog, dt);
                        int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + firstSql).Rows[0][0]);
                        lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    }
                }

            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/Voucher_Log.cs", Session["wID"].ToString());
            }
        }

        private string result(string num)
        {
            string str = string.Empty;
            switch (num)
            {
                case "0":
                    str = "未使用";
                    break;
                case "1":
                    str = "已使用";
                    break;
            }
            return str;
        }
    }
}