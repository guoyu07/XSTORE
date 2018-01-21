using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;
using tdx.database.database;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Downs_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userAuthentication(11);
            if (!IsPostBack)
            {
                //绑定地区
                DataTable classidArry1 = comfun.GetDataTableBySQL("select c_id from B2C_Dclass where c_parent=0 and 1=1  order by c_id");
                foreach (DataRow dr in classidArry1.Rows)
                {
                    B2C_Dclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                }

                string dzd = " *,(select c_name from B2C_Dclass where B2C_Dclass.c_no=B2C_Downs.cno  and 1=1) as cname";
                string sql = "(1=1)  and 1=1 ";
                lb_prolist.Text = prolist(dzd, sql, 1);
                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Downs where 1=1  and 1=1").Rows[0][0]);
                //lt_pagearrow.Text = fsWeixin.Common.commonTool.F_pagearrow(_page, totalcount);

                lb_proadd.Text = "<a href='B2C_Downs_Add.aspx'>添加新下载</a>";
            }
        }
        private string prolist(string _dzd, string _sql, int _pageIndex)
        {

            string str = "";
            str += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0  class='borderTable'>";
            str += @"        <tr style='border-bottom: 1px solid #333333;'>";
            str += @"           <td align=center class=""red"">删除</td>";
            str += @"          <td height=""25"" align=center >类别</td>";
            str += @"          <td align=center >名称</td>";
            str += @"          <td align=center >图片</td>";
            str += @"		   <td align=center >时间</td>";
            str += @"		   <td align=center >排序</td>";
            str += @"          <td align=center  >修改</td>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }

            DataTable dt = B2C_Downs.GetList(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"           <td align=center> <input  style=""clear:both; width:20px;"" type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td align=center height=24>" + dr["cname"] + "</td>";
                str += @"          <td align=center>" + dr["p_name"] + "</td>";
                str += @"          <td align=center><img src='" + dr["p_gif"] + "' border='0' width='90' /></td>";
                str += @"          <td align=center>" + dr["p_wdate"] + "</td>";
                str += @"          <td align=center>" + dr["p_sort"] + "</td>";
                str += @"          <td align=center><a href=""B2C_Downs_Add.aspx?id=" + dr["id"] + "\">修改</a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }
        #region  功能按钮
        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void delBtn_Click(object sender, EventArgs e)
        {
            //userAuthentication(12);
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                try
                {
                    B2C_Downs.delete(delid);
                    Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_Downs_List.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('彻底删除失败！" + ex.Message.Replace("'", "") + "');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }

        #endregion

        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            string keyword = ss_keyword.Value;
            string cno = ss_cid.Value;
            string sql = "1=1 and (p_name like '%" + keyword + "%' or p_no like '%" + keyword + "%')  and 1=1";
            if (cno != null)
            {
                sql = sql + " and cno like '" + cno + "%'";
            }
            string dzd = " *,(select c_name from B2C_Dclass where B2C_Dclass.c_no=B2C_Downs.cno  and 1=1)as cname ";
            lb_prolist.Text = prolist(dzd, sql, Convert.ToInt32(Request["page"]));//, 
            //生成分页按钮
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Downs where " + sql).Rows[0][0]);
            //lt_pagearrow.Text = fsWeixin.Common.commonTool.F_pagearrow(Convert.ToInt32(Request["page"]), totalcount);
        }
    }
}