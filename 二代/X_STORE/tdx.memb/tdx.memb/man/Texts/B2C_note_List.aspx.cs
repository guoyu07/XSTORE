using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class B2C_note_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _sql = "(1=1)";
                lb_catelist.Text = pagelist(_sql);
                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2c_note where " + _sql).Rows[0][0]); //cityID=" + Session["wID"].ToString().Trim() + " and 
                lt_pagearrow.Text = Creatrue.Common.commonTool.L_pagearrow(_page, totalcount);

                lb_cateadd.Text = "";
            }
        }
        private string pagelist(string _sql)
        {
            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            string _dzd = " * ";
            DataTable catetable = B2C_note.GetList(currentpage, _dzd, _sql);
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "           <th align=center height=\"25\">删除</th>";
            str += "          <th align=center>内容</th>";
            str += "          <th align=center>联系方式</th>";
            str += "          <th align=center>时间</th>";
            str += "        </tr>";
            str += "        ";
            foreach (DataRow dr in catetable.Rows)
            {
                str += @"        <tr> ";
                str += "        <td align=center> <input type=checkbox style=\"clear:both; width:20px;\" name=\"delbox\" value=\"" + dr["id"] + "\"> </td> ";
                str += "        <td align=center height=25>" + dr["n_msg"] + "</td>";
                str += "        <td align=center>" + dr["n_link"] + "</a></td>";
                str += "        <td align=center>" + dr["regdate"] + "</td>";
                str += "    </tr>";
            }

            str += "";
            str += "</table>";

            return str;
        }

        protected void delBtn_Click(System.Object sender, System.EventArgs e)
        {
            if (Request["delbox"] != null)
            {
                string delid = Request["delbox"].ToString();

                try
                {
                    B2C_note.delete(delid);
                    Response.Write("<script language='javascript'>alert('删除成功！');location.href='B2C_note_List.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('删除失败！');history.go(-1);</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择要删除的项！');history.go(-1);</script>");
            }
        }

    }
}