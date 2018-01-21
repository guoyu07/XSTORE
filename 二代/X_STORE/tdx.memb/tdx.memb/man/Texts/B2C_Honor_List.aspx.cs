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
    public partial class B2C_Honor_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //userAuthentication(11);
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理和编辑您的图片，如： 企业风采、企业场景等展示图片";
                    //绑定地区
                    DataTable classidArry1 = comfun.GetDataTableBySQL("select c_id from B2C_Hclass where c_parent=0  order by c_id"); //and cityID=" + Session["wID"].ToString().Trim() + "
                    foreach (DataRow dr in classidArry1.Rows)
                    {
                        B2C_Hclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                    }

                    string dzd = " *,(select c_name from B2C_Hclass where B2C_Hclass.c_no=b2c_Honor.cno) as cname"; // and cityID=" + Session["wID"].ToString().Trim() + "
                    string sql = "(1=1)  "; // and cityID=" + Session["wID"].ToString().Trim() + "
                    lb_prolist.Text = prolist(dzd, sql, 1);
                    //生成分页按钮
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Honor where 1=1 ").Rows[0][0]); // and cityID=" + Session["wID"].ToString().Trim() + "
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);

                    lb_proadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='B2C_Honor_Add.aspx' \" value=\"添加新图片\"/>";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2C_Honor_List.cs", Session["wID"].ToString());
                }

            }
        }
        private string prolist(string _dzd, string _sql, int _pageIndex)
        {

            string str = "";
            str += @"<table >";
            str += @"        <tr >";//style='border-bottom: 1px solid #333333;'
            str += "           <th ><input type=checkbox  name=\"delAll\" id=\"delAll\"  runat=server onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</td>";//style=\" clear:both; width:20px;\"
            str += @"          <th  >相册</th>";
            str += @"          <th  >预览</th>";
            str += @"          <th  >名称</th>";
            str += @"		   <th  >时间</th>";
            str += @"		   <th  >排序</th>";
            str += @"          <th  >修改</th>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }

            DataTable dt = B2C_Honor.GetList(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"           <td > <input   type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td >" + dr["cname"] + "</td>";
                str += @"          <td ><img src='" + dr["p_url"] + "' border='0' width='90' /></td>";
                str += @"          <td >" + dr["p_name"] + "</td>";
                str += @"          <td >" + dr["p_wdate"] + "</td>";
                str += @"          <td >" + dr["p_sort"] + "</td>";
                str += "          <td ><a href=\"B2C_Honor_Add.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
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
            try
            {
                string delid = "0";
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    try
                    {
                        B2C_Honor.delete(delid);

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = "彻底删除失败！";
                    }

                    lt_result.Text = "彻底删除成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Honor_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_Honor_List.cs", Session["wID"].ToString());
            }
        }

        #endregion

        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string keyword = ss_keyword.Value;
                string cno = ss_cid.Value;
                string sql = "1=1 and (p_name like '%" + keyword + "%' or p_no like '%" + keyword + "%') "; // and cityID=" + Session["wID"].ToString().Trim() + "
                if (cno != null)
                {
                    sql = sql + " and cno like '%" + cno + "%'";
                }
                string dzd = " *,(select c_name from B2C_Hclass where B2C_Hclass.c_no=B2C_Honor.cno )as cname "; // and cityID=" + Session["wID"].ToString().Trim() + "
                lb_prolist.Text = prolist(dzd, sql, Convert.ToInt32(Request["page"]));//, 
                //生成分页按钮
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Honor where " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(Convert.ToInt32(Request["page"]), totalcount, 20, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_Honor_List.cs", Session["wID"].ToString());
            }
        }
    }
}