using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using Creatrue.kernel;
using tdx.database.database;

namespace tdx.memb.man.Texts
{
    public partial class B2C_inq_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _sql = "(1=1)";
                lb_catelist.Text = pagelist(_sql);
                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2c_inq where 1=1 and " + _sql).Rows[0][0]);
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
            DataTable catetable = B2C_inq.GetList(currentpage, _dzd, _sql);
            string str = "";
            str += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0  class='borderTable'>";
            str += @"        <tr>";
            str += "           <td align=center height=\"25\">删除</td>";
            str += "          <td align=center>标题</td>";
            str += "          <td align=center>内容</td>";
            str += "          <td align=center>发件人</td>";
            str += "          <td align=center>发件人详情</td>";
            str += "          <td align=center>发件时间</td>";
            str += "        </tr>";
            str += "        ";
            foreach (DataRow dr in catetable.Rows)
            {
                str += @"        <tr> ";
                str += "        <td align=center> <input type=checkbox style=\"clear:both; width:20px;\" name=\"delbox\" value=\"" + dr["id"] + "\"> </td> ";
                str += "        <td align=center height=\"25\" width=\"200\">" + dr["i_title"] + "</td>";
                str += "        <td align=center  width=\"260\">" + dr["i_content"] + "</a></td>";
                str += "        <td align=center>" + dr["i_name"] + "</td>";
                str += "        <td align=center height=25>" + dr["i_email"] + "<br />" + dr["i_tel"] + "<br />" + dr["i_url"] + "</td>";
                str += "        <td align=center>" + dr["regtime"] + "</td>";
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
                    B2C_inq.delete(delid);
                    Response.Write("<script language='javascript'>alert('删除成功！');location.href='B2C_inq_List.aspx';</script>");
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            string str = "select  regtime,Ips,i_url,i_lang,i_title,i_content,i_email,i_name,i_tel from b2c_inq ";
            DataTable dt = comfun.GetDataTableBySQL(str);
            RenderDataTableToExcel_CSV(dt, DateTime.Now.ToShortDateString());


        }
        private static string ChangeName(string input)
        {
            string s = Regex.Replace(input, @"\s+", "_", RegexOptions.IgnoreCase);
            return s;
        }

        public static void RenderDataTableToExcel_CSV(DataTable dt, string FileName)
        {
            HttpResponse Response = HttpContext.Current.Response;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(ChangeName(FileName)) + ".csv"));
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.ContentType = "application/vnd.ms-excel";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName + ",");
            }
            sb.Append("\r\n");

            foreach (DataRow item in dt.Rows)
            {
                for (int i = 0; i < item.ItemArray.Length; i++)
                {
                    sb.Append(item.ItemArray[i].ToString().Replace(",", " ").Replace("\r\n", "     ") + ",");
                }
                sb.Append("\r\n");
            }
            Response.Write(sb.ToString());
            Response.End();
        }

    }
}