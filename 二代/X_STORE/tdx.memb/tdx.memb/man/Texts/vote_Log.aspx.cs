using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Texts
{
    public partial class vote_Log : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int pagesize = 20;
                    int _bigpic_id = Convert.ToInt32(Request["id"]);
                    string firstSql = @"select [vote_log].[id],[vote_bigpic].[name],
       [vote_Album].[Album_name],
       [vote_log].[vote_wwv],
       [vote_log].[vote_time],
       [vote_log].[vote_ip]
from [vote_log] inner join [vote_bigpic] on [vote_log].[bigpic_id]=[vote_bigpic].[id]
 inner join [vote_Album] on [vote_log].[Album_id]=[vote_Album].[id] and [vote_log].[bigpic_id]=" + _bigpic_id + ") as tb";
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
                    comfun.ChuliException(ex, "man/Texts/vote_Log.cs", Session["wID"].ToString());
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
                result1 += "\r\n <th >投票项目名称</th> ";
                result1 += "\r\n <th >投票项名称</th> ";
                result1 += "\r\n <th >投票用户名</th> ";
                result1 += "\r\n <th >投票时间</th> ";
                result1 += "\r\n <th >ip地址</th> ";
                result1 += " \r\n </tr>";
                foreach (DataRow dr in dtNew.Rows)
                {
                    result1 += " \r\n <tr>";
                    result1 += " \r\n <td >" + dr["name"].ToString() + "</td> ";
                    result1 += " \r\n <td >" + dr["Album_name"] + "</td> ";
                    result1 += " \r\n <td >" + dr["vote_wwv"].ToString() + "</td> ";
                    result1 += " \r\n <td >" + dr["vote_time"] + "</td> ";
                    result1 += " \r\n <td >" + dr["vote_ip"] + "</td> ";
                    result1 += "\r\n </tr>";
                }
                return result1;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/vote_Log.cs", Session["wID"].ToString());
                return result1;
            }
        }

        protected void btn_downexcel(object sender, EventArgs e)
        {   
            int bigpic_id = Convert.ToInt32(Request["id"]);
            Excel excel = new Excel();
            string votesql = "select name as 投票名称,album_name as 投票选项,vote_wwv as 微信ID,vote_time as 投票时间,vote_ip as 投票者IP from vote_bigpic a,vote_log b,vote_album c where b.bigpic_id=c.bigpic_id and a.id=c.bigpic_id and b.album_id=c.id and a.id=" + bigpic_id + "";
            OutputExcel(votesql, "投票日志");
        }

        void OutputExcel(string sql, string name)
        {
            try
            {
                DataTable dt = comfun.GetDataTableBySQL(sql);
                Excel excel = new Excel();
                excel.CreateExcel(dt, name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int pagesize = 20;
                int _bigpic_id = Convert.ToInt32(Request["id"]);
                string firstSql = @"select [vote_log].[id],[vote_bigpic].[name],
       [vote_Album].[Album_name],
       [vote_log].[vote_wwv],
       [vote_log].[vote_time],
       [vote_log].[vote_ip]
from [vote_log] inner join [vote_bigpic] on [vote_log].[bigpic_id]=[vote_bigpic].[id]
inner join [vote_Album] on [vote_log].[Album_id]=[vote_Album].[id] and [vote_log].[bigpic_id]=" + _bigpic_id + ") as tb";
                if (sousuo_txt.Value.Trim() != "" || sousuo_txt.Value != "")
                {
                    string safeSql = @"select top 1 * from (" + firstSql;
                    DataTable dt = comfun.GetDataTableBySQL(safeSql);
                    if (dt.Rows.Count > 0)
                    {
                        string _where = " where M_name like '%" + sousuo_txt.Value + "%'";
                        string selectSql = @"select top 1 * from (" + firstSql + _where;
                        DataTable dtList = comfun.GetDataTableBySQL(selectSql);
                        if (dtList.Rows.Count > 0)
                        {
                            int _page = (Request["page"] != null ? int.Parse(Request["page"]) : 1);
                            string _sqlLog = @"select *,(row_number() over(order by id desc)) as rown from(" + firstSql + _where;
                            _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";
                            zdList.Text = pagelist(_sqlLog, dtList);
                            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + firstSql).Rows[0][0]);
                            lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                        }
                    }
                }
                else
                {
                    Response.Write("<script language='javascript'>setTimeout(function(){location.href='vote_Log.aspx';},300);</script>");
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/vote_Log.cs", Session["wID"].ToString());
            }
        }
    }
}