using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using tdx.database;

namespace tdx.memb.man.actions
{
    public partial class Action_LogsList : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int acid = 0;
                if (Request["acid"] != null)
                {
                    int.TryParse(Request["acid"].ToString(), out acid);
                }
                else
                {
                    Response.Write("<script language='javascript'>history.go(-1);</script>");
                }

                //DataTable dt = Wx_action.GetList("id", "wid=" + acid.ToString());

                // string _sql = ""

                string dzd = " *,(select ac_title from wx_action where id=wx_action_logs.acid) as actitle ";
                lb_prolist.Text = prolist(dzd, " acID=" + acid, 1);

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
            str += @"<table>";
            str += @"  <tr>";
            str += @"   <th>参加时间</th>";
            str += @"   <th>活动ID</th>";
            str += @"   <th>参加活动的微信</th>";
            str += @"   <th>参加活动结果</th>";
            str += @"  </tr>";
            str += @"        ";
            int currentPage = 1;
            if (Request["page"] != null)
            {
                currentPage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = Wx_action_logs.GetList(_dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr> ";
                str += @"          <td>" + dr["regdate"] + "</td>";
                str += @"          <td>" + dr["acID"] + "<br />" + dr["actitle"] + "</td>";
                str += @"          <td>" + dr["froms"] + "</td>";
                string xinxi = "不中奖";//不中奖  默认
                int jiang = Convert.ToInt32(dr["from_Res"].ToString());
                switch (jiang)
                {
                    case 1: xinxi = "一等奖";
                        break;
                    case 2: xinxi = "二等奖";
                        break;
                    case 3: xinxi = "三等奖";
                        break;
                    default: xinxi = "没中奖";
                        break;
                }
                str += @"          <td >" + xinxi + "</td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
    }
}