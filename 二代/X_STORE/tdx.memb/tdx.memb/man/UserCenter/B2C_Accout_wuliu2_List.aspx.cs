using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common;
using Creatrue.kernel;
using tdx.database;

namespace tdx.memb.man.UserCenter
{
    public partial class B2C_Accout_wuliu2_List : System.Web.UI.Page
    {
        public static int mid = 0;// 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binding();
                mid = Request["mid"] != null ? Convert.ToInt32(Request["mid"].ToString().Trim()) : 0;
                string _sql = "";
                if (mid != 1)
                    _sql = " and mid=" + mid.ToString();
                if (Request["ptid"] != null)
                    _sql += " and ptid=" + Request["ptid"].ToString().Trim();
                //生成分页
                int _page = 1;
                if (Request["page"] != null)
                {
                    _page = Convert.ToInt32(Request["page"]);
                }

                lb_prolist.Text = prolist(consts.pagesize_Txt, _page, _sql);

                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Account where 1=1" + _sql).Rows[0][0]);
                lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);

                //lb_proadd.Text = "<a href='B2C_Account2_add.aspx?mid=" + mid + "'>账户变动</a>";
                ss_mid.Value = mid.ToString();
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void binding()
        {
            string sql2 = "select id ,pt_name from b2c_paytype ";
            DataTable dt2 = comfun.GetDataTableBySQL(sql2);
            ss_cid.DataSource = dt2.DefaultView;
            ss_cid.DataTextField = "pt_name";
            ss_cid.DataValueField = "id";
            ss_cid.DataBind();
            ss_cid.Items.Insert(0, new ListItem("全部", "0"));

            sql2 = "select c_no,c_name from b2c_kemu";
            dt2 = comfun.GetDataTableBySQL(sql2);
            ss_bid.DataSource = dt2.DefaultView;
            ss_bid.DataTextField = "c_name";
            ss_bid.DataValueField = "c_no";
            ss_bid.DataBind();
            ss_bid.Items.Insert(0, new ListItem("全部", "0"));

        }
        private string prolist(int _pagesize, int _page, string _sql)
        {
            string str = "";
            str += @"<table class=""ltable""  align=center cellpadding=0 cellspacing=1 >";
            str += @"        <tr bgcolor=""#f1f1f1"">";
            str += @"           <td align=center > &nbsp; </td>";
            str += @"		   <td align=center class=""tablehead"">日期</td>";
            //str += @"          <td height=""25"" align=center class=""tablehead"">账户</td>";
            str += @"          <td align=center class=""tablehead"">途径</td>";
            str += @"          <td align=center class=""tablehead"">发生额</td>";
            str += @"          <td align=center class=""tablehead"">余额</td>";
            str += @"          <td align=center class=""tablehead"">会员</td>";
            str += @"        </tr>";
            str += @"        ";

            string sql = "select row_number() over(order by id desc) as rown,*,(select pt_name from B2C_paytype where B2C_paytype.id=B2C_Account.ptid)as ptname ";//,(select c_name from B2C_kemu where B2C_kemu.c_no=B2C_Accout.cno)as kname 
            sql += " ,(select M_truename from B2C_mem where B2C_mem.id=B2C_Account.mid) as Mname";
            sql += " ,(select c_name from b2c_kemu where b2c_kemu.c_no=B2C_Account.cno) as cname";
            sql += " from B2C_Account where 1=1 ";
            sql += _sql;
            //sql += " order by id desc";
            sql = "with c as (" + sql + ")";
            sql += "\n select top " + _pagesize.ToString() + " * from c where rown > " + ((_page - 1) * _pagesize).ToString() + " order by rown";

            DataTable dt = comfun.GetDataTableBySQL(sql); //B2C_Account.GetList(currentpage, _dzd, _sql);
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#ffffff> ";
                str += @"           <td align=center> <input Class=""checkall""  style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center>" + dr["ac_update"] + "</td>";
                //str += @"          <td align=center height=24>" + dr["ptname"] + "</td>";
                str += @"          <td align=center>" + dr["cname"] + "</td>";
                str += @"          <td align=center>" + dr["ac_money"] + "</td>";
                str += @"          <td align=center>" + dr["ac_AMT"] + "</td>";
                str += @"          <td align=center>" + dr["Mname"] + "</td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }


        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            string keyword = ss_keyword.Text;
            string _pid = ss_cid.Value;
            string _bid = ss_bid.Value;

            string sql = " and orderNo like '%" + keyword + "%'";
            if (_pid != "0")
                sql += " and ptid=" + Convert.ToInt32(_pid);
            if (_bid != "")
            {
                sql += " and cno='" + _bid + "'";
            }
            mid = Request["mid"] != null ? Convert.ToInt32(Request["mid"].ToString().Trim()) : 0;
            if (mid != 1)
                sql += " and mid=" + mid.ToString();
            if (txtbtime.Text != "")
            {
                sql = sql + " and ac_update >= '" + Convert.ToDateTime(txtbtime.Text) + "'";
            }
            if (txtetime.Text != "")
            {
                sql = sql + " and ac_update <= '" + Convert.ToDateTime(txtetime.Text) + "'";
            }
            int _page = 1;
            if (Request["page"] != null)
            {
                _page = Convert.ToInt32(Request["page"]);
            }
            lb_prolist.Text = prolist(consts.pagesize_Txt, _page, sql);//
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Account where 1=1 " + sql).Rows[0][0]);
            lt_pagearrow.Text = commonTool.F_pagearrow(_page, totalcount);
        }

        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void delBtn_Click_Click(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    int id = Convert.ToInt32(_id);
                    try
                    {
                        B2C_Account.myDel(id);
                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_Accout_wuliu2_List.aspx?mid=" + Convert.ToInt32(Request["id"]) + "';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }
    }
}