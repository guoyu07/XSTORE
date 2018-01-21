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
    public partial class B2C_tpage_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tpages = comfun.GetDataTableBySQL("select * from B2C_TPAGE where cno='001'"); //cityID=" + Session["wID"].ToString().Trim() + " and
                if (tpages.Rows.Count == 0)
                {
                    string _sqlt = "";
                    _sqlt += "\r\n;insert into b2c_tpclass(c_no,c_name,c_gif) values('001','关于','/upload/201311/12/201311121958340.all.png')"; //,cityID ,{0}
                    _sqlt += "\r\n;insert into b2c_tpage(cno,gtitle,gcontent,g_isurl,g_url,g_isSys) values('001','关于我们','',0,'',1)";//,cityID  ,{0}
                    _sqlt += "\r\n;insert into b2c_tpage(cno,gtitle,gcontent,g_isurl,g_url,g_isSys) values('001','联系我们','',0,'',1)";//,cityID  ,{0}
                    _sqlt += "\r\n;insert into b2c_tpage(cno,gtitle,gcontent,g_isurl,g_url,g_isSys) values('001','在线反馈','',1,'feedback.aspx',2)"; //,cityID ,{0}
                    //_sqlt = string.Format(_sqlt, Session["wID"].ToString().Trim());
                    try
                    {
                        //comfun.UpdateBySQL(_sqlt);
                    }
                    catch (Exception ex)
                    {

                        comfun.ChuliException(ex, "/man/texts/B2C_tpage_List.cs", Session["wID"].ToString());
                        Response.Write("<script language='javascript'>window.location='B2C_tpage_List.aspx';</script>");
                    }
                }
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，您可以添加或编辑您的微网站的通用单页，如：关于我们、联系我们等。";
                DataTable dt = comfun.GetDataTableBySQL("select * from b2c_tpclass where c_parent=0 order by c_id"); // and cityID=" + Session["wID"].ToString().Trim() + "
                foreach (DataRow dr in dt.Rows)
                {
                    //ss_cid.Items.Add(new ListItem(dr("c_name"), dr("c_id")));
                    B2C_TPclass.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                }
                dt.Dispose();
                dt = null;


                string _sql = "(1=1)";
                lb_catelist.Text = pagelist(_sql);
                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2c_tpage where " + _sql).Rows[0][0]); //cityID=" + Session["wID"].ToString().Trim() + " and 
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);

                lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='B2C_tpage_Add.aspx'\" value=\"添加新页面\" />";
            }
        }
        private string pagelist(string _sql)
        {
            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            string _dzd = " *,(select c_name from B2C_TPclass where B2C_TPclass.c_no=B2C_tpage.cno)as cname "; // and cityID=" + Session["wID"].ToString().Trim() + "
            DataTable catetable = B2C_tpage.GetList(currentpage, _dzd, _sql);
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "           <th ><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\"  onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += "          <th >类别名称</th>";
            str += "          <th >标题</th>";
            str += "          <th >排序</th>";
            str += "          <th >修改</th>";
            str += "        </tr>";
            str += "        ";
            foreach (DataRow dr in catetable.Rows)
            {
                str += @"        <tr> ";
                str += "        <td > <input type=checkbox style=\"clear:both; width:20px;\" name=\"delbox\" value=\"" + dr["id"] + "\" " + (Convert.ToInt32(dr["g_isSys"]) > 0 ? "disabled" : "") + "> </td> ";
                str += "        <td >" + dr["cname"] + "</td>";
                str += "        <td >" + dr["gtitle"] + "<br />";
                //str += "获取地址:<span class='rb'>http://www.tdx.cn/" + B2C_worker.currentGNTheme() + "/tpage.aspx?id=" + dr["id"].ToString() + "&wwx=" + B2C_worker.currentWWX() + "</span></td>";
                str += "        <td >" + dr["g_sort"] + "</td>";
                str += "        <td >" + (Convert.ToInt32(dr["g_isSys"]) < 2 ? "<a href=\"B2C_tpage_Add.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a>" : "") + "</td>";
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
                string[] delidArry = Regex.Split(delid, ",");
                foreach (string s in delidArry)
                {
                    int cid = Convert.ToInt32(s);
                    try
                    {
                        B2C_tpage.myDel(cid);
                        lt_result.Text = "删除成功";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_tpage_List.aspx';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = "删除失败！";
                    }
                }

            }
            else
            {
                lt_result.Text = "请选择要删除的项！";
            }
        }

        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            //收集参数
            string keyword = ss_keyword.Value.Trim();
            string _cid = ss_cid.Value;

            string sql = " gtitle like '%" + keyword + "%'";
            if (!string.IsNullOrEmpty(_cid))
            {
                sql = sql + " and cno like '" + _cid + "%'";
            }

            lb_catelist.Text = pagelist(sql);

            //生成分页按钮
            int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
            int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2c_tpage where " + sql).Rows[0][0]); // cityID=" + Session["wID"].ToString().Trim() + " and
            lt_pagearrow.Text = Creatrue.Common.commonTool.L_pagearrow(_page, totalcount);
        }


    }
}