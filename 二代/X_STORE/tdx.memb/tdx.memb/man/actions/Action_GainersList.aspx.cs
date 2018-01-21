using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;

namespace tdx.memb.man.actions
{
    public partial class Action_GainersList : System.Web.UI.Page
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


                string dzd = " *,(select ac_title from wx_action where id=wx_action_gain.acid) as actitle ";
                string sql = string.Format("acID={0}", acid);

                lb_prolist.Text = prolist(dzd, sql, 1);

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
            str += @"    <tr>";
            str += @"   <th>参加时间</th>";
            str += @"   <th>活动</th>";
            str += @"   <th>奖品</th>";
            str += @"   <th>参加活动的微信</th>";
            str += @"   <th>电话/Email</th>";
            str += @"   <th>姓名/公司</th>";
            str += @"   <th>地址</th>";
            str += @"   <th>SN码,随机生成</th>";
            str += @" </tr>";
            str += @"        ";
            int currentPage = 1;
            if (Request["page"] != null)
            {
                currentPage = Convert.ToInt32(Request["page"]);
            }
            DataTable dt = Wx_action_gain.GetList(_dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr> ";
                str += @"          <td>" + dr["regdate"] + "</td>";
                str += @"          <td>" + dr["acID"] + "<br />" + dr["actitle"] + "</td>";
                string xinxi = "不中奖";//默认
                int jiang = Convert.ToInt32(dr["ac_jpID"].ToString());
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
                str += @"          <td>" + xinxi + "</td>";
                str += @"          <td>" + dr["froms"] + "</td>";
                str += @"<td> " + dr["from_tel"] + "<br />" + dr["from_email"] + "</td>";
                str += @"<td>" + dr["from_name"] + "<br />" + dr["from_comp"] + "</td>";
                str += @"          <td>" + dr["from_addr"] + "</td>";
                str += @"<td>" + dr["SN"] + "</td>";
                str += @" </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
    }
}