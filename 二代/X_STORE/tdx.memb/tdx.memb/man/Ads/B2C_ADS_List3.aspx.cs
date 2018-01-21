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

namespace tdx.memb.man.Ads
{
    public partial class B2C_ADS_List3 : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int _wid = (Session["wid"] != null ? Convert.ToInt32(Session["wid"]) : 0);

                string sql = " (1=1) and cno like '010%'"; // and (cityID=" + _wid + " or cityID in (select id from wx_mp where cityID=" + _wid + "))
                string dzd = " *,(select c_name from B2C_AdClass where B2C_AdClass.c_no=B2C_ADS_Web.cno)as cname ";

                DataTable bigTable = B2C_ads.getlist(dzd, sql);
                string str = "";
                str += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0   class='borderTable'>";
                str += @"       <tr>";
                str += "        <td height=\"30\" align=\"center\"><input type=\"checkbox\" class=\"btn\"  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</td>";
                str += @"        <td align=center>位 置</td>";
                str += @"        <td align=center>名称</td>";
                str += @"        <td align=center>广告图片</td>";
                str += @"        <td align=center>链接地址</td>";
                str += @"        <td align=center>修改</td>";
                str += @"       </tr>";
                foreach (DataRow dr in bigTable.Rows)
                {
                    str += @"          <tr>";
                    str += @"          <td align=center><input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"  style=\"width:20px;\" " + (Convert.ToInt32(dr["a_isSys"]) > 0 ? "disabled" : "") + "></td>";
                    str += @"          <td align=center>" + dr["cname"] + "</td>";
                    str += @"          <td align=center height=30>" + dr["a_name"] + "</td>";
                    str += @"          <td align=center>";
                    if (Convert.IsDBNull(dr["a_adGif"]) == false && dr["a_adGif"].ToString() != "")
                    {
                        str += "<a href='" + dr["a_adGif"] + "' target=_blank> 预览</a>";
                    }
                    str += @"</td>";
                    str += @"          <td align=center>" + dr["a_url"] + "</td>";
                    str += @"           <td align=center>" + (Convert.ToInt32(dr["a_isSys"]) < 2 ? "<a href='B2C_ADS_Add3.aspx?id=" + dr["id"] + "&wid=" + Session["wid"].ToString().Trim() + "'>修改</a>" : "") + "</td>";
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
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_ADS where cno like '009%'").Rows[0][0]); // and cityid=" + Session["wID"].ToString().Trim()
                lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);



                lb_cateadd.Text = @"<a href='B2C_ADS_Add3.aspx?cno=009&wid=" + _wid.ToString().Trim() + "'>添加广告信息</a>";



            }
        }

        /// <summary>
        /// 删除选中的记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
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
                        B2C_ads.myDeleteMethod2(cid);
                        Response.Write("<script language='javascript'>alert('彻底删除成功！');location.href='B2C_ADS_List3.aspx?wid=" + Request["wid"].ToString().Trim() + "';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！');history.go(-1);</script>");
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