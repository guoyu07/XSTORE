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

namespace tdx.memb.man.caimi
{
    public partial class wx_acm_test_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理和编辑猜谜的信息。";

                    string _sql = "select * from wx_acm_level";
                    DataSet ds = comfun.GetDataSetBySQL(_sql);
                    this.ss_cid.DataSource = ds.Tables[0]; //这里我绑到DataTable上了.
                    this.ss_cid.DataTextField = "c_name"; //前台看到的值,也就是CheckBoxList中显示出来的值
                    this.ss_cid.DataValueField = "id"; //这个值直接在页面上是看不到的,但在源代码中可以看到
                    this.ss_cid.DataBind();

                    string dzd = " *,(select c_name from wx_acm_level where id=lid) as cname ";
                    string sql = "(1=1)";
                    lb_prolist.Text = prolist(dzd, sql);
                    //生成分页按钮
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_acm_test where " + sql).Rows[0][0]);
                    int _ipage = Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1;
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_ipage, totalcount, 20, Request.Form, Request.QueryString);



                    lb_proadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='wx_acm_test_Add.aspx' \" value=\"添加新谜语\"/>";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/wx_acm_test_List.cs", Session["wID"].ToString());
                }
            }
        }
        private string prolist(string _dzd, string _sql)
        {
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "          <th ><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"          <th  >等级</th>";
            str += @"          <th >谜面</th>";
            str += @"          <th  >答案</th>";
            str += @"          <th  >简介</th>";
            str += @"          <th   >修改</th>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            //str += currentpage.ToString();
            DataTable dt = wx_acm_test.GetList(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr> ";
                str += @"           <td  > <input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td >" + dr["cname"] + "</td>";
                str += @"          <td >" + dr["t_title"] + "</td>";
                str += @"          <td >" + dr["t_answer"] + "</td>";
                str += @"          <td >" + dr["t_cont"] + "</td>";
                str += "  <td ><a href=\"wx_acm_test_Add.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
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
                        try
                        {
                            wx_acm_test.myDel(id);

                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除失败！";
                            return;
                        }
                    }
                    lt_result.Text = "彻底删除成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_test_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_test_List.cs", Session["wID"].ToString());
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
                    sql = sql + " and lid=" + cno + "";
                }
                string dzd = " *,(select c_name from wx_acm_level where id=lid) as cname ";
                lb_prolist.Text = prolist(dzd, sql);//, Convert.ToInt32(Request["page"])             
                //生成分页按钮
                int _ipage = Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1;
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_acm_test where " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_ipage, totalcount, 20, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_test_List.cs", Session["wID"].ToString());
            }


        }
    }
}