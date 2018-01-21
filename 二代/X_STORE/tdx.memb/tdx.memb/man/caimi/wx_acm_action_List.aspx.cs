using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Text.RegularExpressions;
using System.Data;

namespace tdx.memb.man.caimi
{
    public partial class wx_acm_action_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理和编辑猜谜活动的信息。";

                    string dzd = " * ";
                    string sql = "(1=1)"; // and wid=" + Session["wID"].ToString().Trim()
                    lb_prolist.Text = prolist(dzd, sql);
                    //生成分页按钮
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_acm_action where " + sql).Rows[0][0]); //wid=" + Session["wID"].ToString().Trim() + " and "
                    int _ipage = Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1;
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_ipage, totalcount, 20, Request.Form, Request.QueryString);



                    lb_proadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='wx_acm_action_Add.aspx' \" value=\"添加新猜谜活动\"/>";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/wx_acm_action_List.cs", Session["wID"].ToString());
                }
            }
        }
        private string prolist(string _dzd, string _sql)
        {
            string str = "";
            str += @"<table >";
            str += @"        <tr>";
            str += "          <th ><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"          <th  >活动名称</th>";
            str += @"          <th >开始时间</th>";
            str += @"          <th  >结束时间</th>";
            str += @"          <th  >频率</th>";
            str += @"          <th   >修改</th>";
            str += @"          <th   >管理</th>";
            str += @"        </tr>";
            str += @"        ";

            int currentpage = 1;
            if (Request["page"] != null)
            {
                currentpage = Convert.ToInt32(Request["page"]);
            }
            //str += currentpage.ToString();
            DataTable dt = wx_acm_action.GetList(currentpage, _dzd, _sql);

            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr> ";
                str += @"           <td  > <input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                str += @"          <td >" + dr["ac_name"] + "</td>";
                str += @"          <td >" + dr["bdate"] + "</td>";
                str += @"          <td >" + dr["edate"] + "</td>";
                str += @"          <td >" + dr["freq"] + "</td>";
                str += "  <td ><a href=\"wx_acm_action_Add.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                str += "  <td ><a href=\"wx_acm_action_gains_list.aspx?acid=" + dr["id"] + "\">设置奖品</a> | <a href=\"wx_acm_action_logs_list.aspx?id=" + dr["id"] + "\">日志</a> | <a href=\"wx_acm_action_gain_list.aspx?id=" + dr["id"] + "\">获奖</a></td>";
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
                            wx_acm_action.myDel(id);

                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除失败！";
                            return;
                        }
                    }
                    lt_result.Text = "彻底删除成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_acm_action_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_action_List.cs", Session["wID"].ToString());
            }
        }

        #endregion

        protected void ss_btn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string keyword = ss_keyword.Value;

                string sql = "1=1 and ac_name like '%" + keyword + "%'";

                string dzd = " * ";
                lb_prolist.Text = prolist(dzd, sql);//, Convert.ToInt32(Request["page"])             
                //生成分页按钮
                int _ipage = Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1;
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_acm_action where wid=" + Session["wID"].ToString().Trim() + " and " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_ipage, totalcount, 20, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/wx_acm_action_List.cs", Session["wID"].ToString());
            }


        }
    }
}