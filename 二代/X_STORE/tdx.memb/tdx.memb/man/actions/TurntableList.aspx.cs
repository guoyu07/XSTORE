using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.actions
{
    public partial class TurntableList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //int wid = 0;
                    //if (Session["wID"] != null)
                    //{
                    //    int.TryParse(Session["wID"].ToString(), out wid);
                    //}

                    string dzd = " *,(select ac_name from wx_actions where wx_action.typeid=wx_actions.id) as ac_name ";
                    //string sql = string.Format("(wid={0})", wid);
                    string sql = "";
                    lb_prolist.Text = prolist(dzd, sql, 1);
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/actions/TurntableList.cs", Session["wID"].ToString());
                }

                ////生成分页按钮
                //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_worker").Rows[0][0]);
                //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
            }
        }

        private string prolist(string _dzd, string _sql, int _pageIndex)
        {
            //  string active = "";
            string str = "";
            str += @"<table >";
            str += @"    <tr>";
            str += @"       <th >活动名称</th>";
            str += @"       <th >活动入口</th>";
            str += @"       <th >一等奖</th>";
            str += @"       <th >二等奖</th>";
            str += @"       <th >三等奖</th>";
            str += @"       <th >开始时间</th>";
            str += @"       <th  >结束时间</th>";
            str += @"       <th >修改</th>";
            str += @"       <th >&nbsp;</th>";
            str += @"    </tr>";
            str += @"        ";
            int currentPage = 1;
            if (Request["page"] != null)
            {
                currentPage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = Wx_action.GetList(_dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td >" + dr["ac_title"] + "</td>";
                if (dr["ac_name"].ToString() == "砸金蛋")
                    str += @"          <td  >" + "/honor_actionegg.aspx?id=" + dr["id"].ToString() + "&wwx=" + currentWWX() + "</td>";
                else if (dr["ac_name"].ToString() == "刮刮卡")
                    str += @"          <td  >" + "/honor_action2.aspx?id=" + dr["id"].ToString() + "&wwx=" + currentWWX() + "</td>";
               

                else if (dr["ac_name"].ToString() == "大转盘")
                    str += @"          <td  >" + "/honor_action.aspx?typeid=" + dr["id"].ToString() + "&wwx=" + currentWWX() + "</td>";
                    

                str += @"          <td  >" + dr["ac_jp_one"] + "</td>";
                str += @"          <td  >" + dr["ac_jp_two"] + "</td>";
                str += @"          <td  >" + dr["ac_jp_three"] + "</td>";
                str += @"          <td  >" + dr["ac_bdate"] + "</td>";
                str += @"          <td  >" + dr["ac_edate"] + "</td>";
                str += "          <td><a href=\"Edit_Action.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                str += @"          <td><a href=""Action_GainersList.aspx?acid=" + dr["id"] + "\">获奖</a> | <a href=\"Action_LogsList.aspx?acid=" + dr["id"] + "\">日志</a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }


        string currentWWX()
        {


            string sql = "select * from wx_mp";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string _theme = dt.Rows[0]["wx_id"].ToString();
            //string _theme = "appv";
            //if (System.Web.HttpContext.Current.Session["wInfo"] != null)
            //{
            //    string[] wInfo = (string[])System.Web.HttpContext.Current.Session["wInfo"];
            //    _theme = wInfo[4].ToString();
            //}
            return _theme;
        }


    }
}