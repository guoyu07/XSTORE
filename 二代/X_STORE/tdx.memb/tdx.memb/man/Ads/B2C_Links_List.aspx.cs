using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database.database;
using System.Text.RegularExpressions;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Ads
{
    public partial class B2C_Links_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);


                string sql = " (1=1) "; // and cityID=" + _wid
                string dzd = " * ";
                if (Request["id"] != null)
                {
                    int cno = Convert.ToInt32(Request["id"].ToString());
                    sql = sql + " and cno='" + cno + "' ";
                }
                DataTable bigTable = B2C_Links.getlist(dzd, sql);
                string str = "";
                str += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0   class='borderTable'>";
                str += @"       <tr>";
                str += @"        <td height=""30"" align=center>选择</td>";
                str += @"        <td align=center>名称</td>";
                str += @"        <td align=center>友链图片</td>";
                str += @"        <td align=center>链接地址</td>";
                str += @"        <td align=center>修改</td>";
                str += @"       </tr>";
                foreach (DataRow dr in bigTable.Rows)
                {
                    str += @"          <tr>";
                    str += @"          <td align=center><input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"  style=\"width:20px;\" ></td>";
                    str += @"          <td align=center height=30>" + dr["a_name"] + "</td>";
                    str += @"          <td align=center>";
                    if (Convert.IsDBNull(dr["a_adGif"]) == false && dr["a_adGif"].ToString() != "")
                    {
                        str += "<a href='" + dr["a_adGif"] + "' target=_blank> 预览</a>";
                    }
                    str += @"</td>";
                    str += @"          <td align=center>" + dr["a_url"] + "</td>";
                    str += @"           <td align=center><a href='B2C_Links_Add.aspx?id=" + dr["id"] + "&wid=" + _wid.ToString().Trim() + "'>修改</a></td>";
                    str += @"         </tr>";
                }
                str += @"</table>";
                lb_catelist.Text = str;
                //生成分页
                int _page = 0;
                if (Request["page"] != null)
                {
                    _page = 1;
                }
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Links").Rows[0][0]);// where cityid=" + Session["wID"].ToString().Trim()
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);


                if (Request["id"] != null)
                {
                    int cno = Convert.ToInt32(Request["id"].ToString());
                    lb_cateadd.Text = @"<a href='B2C_Links_Add.aspx?cno=" + cno + "&wid=" + _wid.ToString().Trim() + "'>添加友链信息</a>";
                }
                else
                {
                    lb_cateadd.Text = @"<a href='B2C_Links_Add.aspx?wid=" + _wid.ToString().Trim() + "'>添加友链信息</a>";
                }


            }
        }

        /// <summary>
        /// 删除选中的记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String s in delidArry)
                {
                    int cid = Convert.ToInt32(s);
                    try
                    {
                        B2C_Links.myDeleteMethod(cid);
                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_Links_List.aspx?wid=" + _wid.ToString().Trim() + "';</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！" + ex.Message.Replace("'", "") + "');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要删除的行！');history.go(-1);</script>");
            }
        }


    }
}