using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common;
using Creatrue.kernel;

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_Accout_wuliu_total : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _sql = "1=1";
                //生成分页
                int _page = 1;
                if (Request["page"] != null)
                {
                    _page = Convert.ToInt32(Request["page"]);
                }

                lb_prolist.Text = prolist(consts.pagesize_Txt, _page, _sql, "", "");

                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_mem where  " + _sql).Rows[0][0]);
                lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);

            }
        }
        private string prolist(int _pagesize, int _page, string _sql, string btime, string etime)
        {
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f1f1f1"">";
            str += @"		   <td align=center class=""tablehead"">会员 </td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">现金收入</td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">提现</td>";
            //str += @"          <td align=center class=""tablehead"">冻结金额</td>";
            str += @"          <td align=center class=""tablehead"">现金余额</td>";
            str += @"        </tr>";
            str += @"        ";

            string sql = "select row_number() over(order by id desc) as rown,*";//,(select c_name from B2C_kemu where B2C_kemu.c_no=B2C_Accout.cno)as kname 
            sql += " ,isnull((select top 1 ac_amt from b2c_account where ptid=3 and b2c_account.mid=B2C_mem.id order by id desc),0) as amt";
            //sql += " ,isnull((select top 1 ac_amt from b2c_account where ptid=3 and b2c_account.mid=B2C_mem.id and orderNo not  in (select orderNo from b2c_account as ba) order by id desc),0) as amt2";
            //sql += ",isnull((select sum(ac_money) from b2c_account where ptid=2 and b2c_account.mid=B2C_mem.id";
            //if (btime.Trim() != "")
            //    sql = sql + " and ac_update >= '" + Convert.ToDateTime(btime.Trim()) + "'";
            //if (etime.Trim() != "")
            //    sql = sql + " and ac_update <= '" + Convert.ToDateTime(etime.Trim()) + "'";
            //sql += " and  cno in (select c_no from b2c_kemu where c_math>0)),0) as money1";

            //sql += ",isnull((select sum(ac_money) from b2c_account where ptid=2 and b2c_account.mid=B2C_mem.id";
            //if (btime.Trim() != "")
            //    sql = sql + " and ac_update >= '" + Convert.ToDateTime(btime.Trim()) + "'";
            //if (etime.Trim() != "")
            //    sql = sql + " and ac_update <= '" + Convert.ToDateTime(etime.Trim()) + "'";
            //sql += " and  cno in (select c_no from b2c_kemu where c_math<0)),0) as money2";

            sql += " from B2C_mem where  ";
            sql += _sql;
            //sql += " order by id desc";
            sql = "with c as (" + sql + ")";
            sql += "\n select top " + _pagesize.ToString() + " * from c where M_isactive=1 and rown > " + ((_page - 1) * _pagesize).ToString() + " order by rown";
            //throw new Exception(sql);
            DataTable dt = comfun.GetDataTableBySQL(sql); //B2C_Account.GetList(currentpage, _dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"          <td align=center><a href='B2C_Accout_wuliu2_List.aspx?mid=" + dr["id"].ToString().Trim() + "'>" + dr["M_truename"] + "</a></td>";
                //str += @"          <td align=center height=24>" + dr["money1"] + "</td>";
                //str += @"          <td align=center height=24>" + dr["money2"] + "</td>";
                //str += @"          <td align=center>" + dr["amt2"] + "</td>";
                str += @"          <td align=center>" + dr["amt"] + "</td>";str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }

        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            string keyword = ss_keyword.Text;

            string sql = " (M_truename like '%" + keyword + "%' )";

            int _page = 1;
            if (Request["page"] != null)
            {
                _page = Convert.ToInt32(Request["page"]);
            }
            lb_prolist.Text = prolist(consts.pagesize_Txt, _page, sql, txtbtime.Text.Trim(), txtetime.Text.Trim());//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_mem where 1=1 and " + sql).Rows[0][0]);
            lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);
        }
    }
}