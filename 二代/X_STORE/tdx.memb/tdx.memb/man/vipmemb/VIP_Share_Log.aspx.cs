using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.vipmemb
{
    public partial class VIP_Share_Log : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int pagesize = 20;
                    string firstSql = @"select [B2C_share_log].[id],[B2C_mem].[M_name],
[B2C_share_log].[ip],
[B2C_share].[t_title],
[B2C_share_log].[s_cent],
[B2C_share_log].[regdate] 
from [B2C_share_log] inner join [B2C_mem] on [B2C_share_log].[wwv]=[B2C_mem].[M_card] 
inner join [B2C_share] on [B2C_share_log].[s_id]=[B2C_share].[id]
and [B2C_share].[cityID]=" + Session["wID"].ToString() + ") as tb";

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
                    comfun.ChuliException(ex, "man/vipmemb/VIP_Share_Log.cs", Session["wID"].ToString());
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
                result1 += "\r\n <th >分享的用户</th> ";
                result1 += "\r\n <th >ip</th> ";
                result1 += "\r\n <th >标题</th> ";
                result1 += "\r\n <th >积分</th> ";
                result1 += "\r\n <th >时间</th> ";
                result1 += " \r\n </tr>";
                foreach (DataRow dr in dtNew.Rows)
                {
                    result1 += " \r\n <tr>";
                    result1 += " \r\n <td >" + dr["M_name"].ToString() + "</td> ";
                    result1 += " \r\n <td >" + dr["ip"] + "</td> ";
                    result1 += " \r\n <td >" + dr["t_title"] + "</td> ";
                    result1 += " \r\n <td >" + dr["s_cent"] + "</td> ";
                    result1 += " \r\n <td >" + dr["regdate"] + "</td> ";
                    result1 += "\r\n </tr>";
                }
                return result1;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/VIP_Share_Log.cs", Session["wID"].ToString());
                return result1;
            }
        }

        protected void btn_downexcel(object sender, EventArgs e)
        { }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string firstSql = @"select [B2C_share_log].[id],[B2C_mem].[M_name],
[B2C_share_log].[ip],
[B2C_share].[t_title],
[B2C_share_log].[s_cent],
[B2C_share_log].[regdate] 
from [B2C_share_log] inner join [B2C_mem] on [B2C_share_log].[wwv]=[B2C_mem].[M_card] 
inner join [B2C_share] on [B2C_share_log].[s_id]=[B2C_share].[id]
and [B2C_share].[cityID]=" + Session["wID"].ToString() + ") as tb";
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
                    string _where = "";
                    if (Request["select_sousuo"].ToString().Equals("全部"))
                    {
                        _where += " and M_name like '%" + sousuo_txt.Value + "%' or t_title like '%" + sousuo_txt.Value + "%'";
                    }
                    else if (Request["select_sousuo"].ToString().Equals("微信"))
                    {
                        _where += " and M_name like '%" + sousuo_txt.Value + "%'";
                    }
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
                comfun.ChuliException(ex, "man/vipmemb/VIP_Share_Log.cs", Session["wID"].ToString());
            }
        }
    }
}