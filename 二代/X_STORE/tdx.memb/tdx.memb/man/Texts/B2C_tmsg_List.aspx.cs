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

namespace tdx.memb.man.Texts
{
    public partial class B2C_tmsg_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DataTable _tmsg = comfun.GetDataTableBySQL("select *  from b2c_tclass ");// where cityID=" + Session["wID"].ToString().Trim()
                    if (_tmsg.Rows.Count == 0)
                    {
                        string _sqlt = "";
                        _sqlt += "\r\n;insert into b2c_tclass(c_no,c_name,c_gif) values('001','公司动态','/upload/201311/12/201311121958340.all.png')";//,cityID  ,{0}
                        _sqlt += "\r\n;insert into b2c_tclass(c_no,c_name,c_gif) values('002','促销信息','/upload/201311/12/201311121958340.all.png')";//,cityID  ,{0}
                        //_sqlt = string.Format(_sqlt, Session["wID"].ToString().Trim());
                        try
                        {
                            //comfun.UpdateBySQL(_sqlt);
                        }
                        catch (Exception ex)
                        {

                            comfun.ChuliException(ex, "man/texts/B2C_tmsg_List.cs", Session["wID"].ToString());
                            Response.Write("<script language='javascript'>location.href='B2C_tmsg_List.aspx';</script>");
                        }
                    }
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理和编辑图文类的信息，如： 新闻动态、行业资讯、技术资料等。";

                    DataTable classidArry1 = comfun.GetDataTableBySQL("select c_id from B2C_tclass where c_parent=0 order by c_id"); //and cityID=" + Session["wID"].ToString().Trim() + "
                    foreach (DataRow dr in classidArry1.Rows)
                    {
                        B2C_tclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                    }
                    string dzd = " *,(select c_name from B2C_tclass where B2C_tclass.c_no=B2C_tmsg.cno) as cname ";// and cityID=" + Session["wID"].ToString().Trim() + " 
                    string cno = Request["ss_cid"] == null ? "" : Request["ss_cid"];
                    string keyword = Request["ss_keyword"] == null ? "" : Request["ss_keyword"];
                    string sql = "";
                    if (cno == ""&&keyword=="")
                    {
                        sql = "(1=1)";
                    }
                    else
                    {
                       
                        sql = "1=1 and t_title like '%" + keyword + "%'";
                        if (cno != null)
                        {
                            sql = sql + "and cno like '" + cno + "%'";
                        }
                    }
                    
                    lb_prolist.Text = prolist(dzd, sql);
                    //生成分页按钮
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2c_tmsg where " + sql).Rows[0][0]); //cityID=" + Session["wID"].ToString().Trim() + " and 
                    
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);


                    lb_proadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='B2C_tmsg_Add.aspx' \" value=\"添加新图文\"/>";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2C_tmsg_List.cs", Session["wID"].ToString());
                }
            }
        }
        
        #region  功能按钮

        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string delid = "0";
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    String[] delidArry = Regex.Split(delid, ",");
                    foreach (String _id in delidArry)
                    {
                        int id = Convert.ToInt32(_id);
                        B2C_tmsg b2c = new B2C_tmsg(id);
                        try
                        {
                            B2C_tmsg.Delete(id);

                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除" + b2c.cname + "失败！";
                            return;
                        }
                    }
                    lt_result.Text = "彻底删除成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_tmsg_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_tmsg_List.cs", Session["wID"].ToString());
            }
        }

        #endregion



        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string keyword = ss_keyword.Value;
                string cno = ss_cid.Value;

                string sql = "1=1 and t_title like '%" + keyword + "%'";
                if (cno != null)
                {
                    sql = sql + "and cno like '" + cno + "%'";
                }
                string dzd = " *,(select c_name from B2C_tclass where B2C_tclass.c_no=B2C_tmsg.cno)as cname "; // and cityID=" + Session["wID"].ToString().Trim() + "
                lb_prolist.Text = prolist(dzd, sql);//, Convert.ToInt32(Request["page"])             
                //生成分页按钮
                int _ipage = Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1;
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2c_tmsg where " + sql).Rows[0][0]);//cityID=" + Session["wID"].ToString().Trim() + " and 
                
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_ipage, totalcount, 20, Request.Form, Request.QueryString);

            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_tmsg_List.cs", Session["wID"].ToString());
            }


        }




        private string prolist(string _dzd, string _sql)
        {
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "          <th ><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"          <th  >类别</th>";
            str += @"          <th >标题</th>";
            str += @"          <th  >作者</th>";
            str += @"          <th  >出处</th>";
            str += @"          <th  >时间</th>";
            str += @"          <th >排序</th>";
            str += @"		   <th  >图片</th>";
            str += @"          <th   >修改</th>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            //str += currentpage.ToString();
            DataTable dt = B2C_tmsg.msglist(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr> ";
                str += @"           <td  > <input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td >" + dr["cname"] + "</td>";
                str += @"          <td >" + dr["t_title"] + "<br />";
                //str += "获取地址:<span class='rb'>http://www.tdx.cn/" + B2C_worker.currentGNTheme() + "/shownews.aspx?id=" + dr["id"].ToString() + "&wwx=" + B2C_worker.currentWWX() + "</span></td>";
                str += @"          <td >" + dr["t_author"] + "</td>";
                str += @"          <td >" + dr["t_source"] + "</td>";
                str += @"          <td >" + dr["t_wdate"] + "</td>";
                str += @"          <td >" + dr["t_sort"] + "</td>";
                str += @"          <td >";
                if (Convert.IsDBNull(dr["t_gif"]) == false && dr["t_gif"].ToString() != "")
                {
                    str += "<a href='" + dr["t_gif"] + "' target=_blank> 预览</a>";
                }
                str += @"</td>";
                str += "  <td ><a href=\"B2C_tmsg_Add.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                str += @"        </tr>";
            }
            str += @"       ";
            str += @"      </table>";
            return str;
        }






    }
}