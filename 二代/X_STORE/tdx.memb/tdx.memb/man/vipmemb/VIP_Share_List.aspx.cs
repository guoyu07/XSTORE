using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.vipmemb
{
    public partial class VIP_Share_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的会员分享信息";
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_share").Rows[0][0]); // where  cityID=" + Session["wID"].ToString().Trim()
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, ""); //"  cityID=" + Session["wID"].ToString().Trim()

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='VIP_Share_Add.aspx'\" class=\"btnAdd\" value=\"添加会员分享\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/VIP_Share_List.cs", Session["wID"].ToString());
                }
            }
        }
        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            //收集参数
            if (ss_keyword.Value != "" || ss_keyword.Value.Trim() != "")
            {
                try
                {
                    string keyword = ss_keyword.Value.Trim();

                    string sql = " t_title like '%" + keyword + "%'"; //  cityID=" + Session["wID"].ToString().Trim() + " and

                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, sql);

                    //生成分页按钮 
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_share where " + sql).Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/VIP_Share_List.cs", Session["wID"].ToString());
                }
            }
        }

        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string delid = "0";
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    int iret = B2C_share.IsNoactive(delid);
                    if (iret == 1)
                    {
                        lt_result.Text = "已批量停运成功！";
                    }
                    else
                    { lt_result.Text = "已批量停运失败！"; }

                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='VIP_Share_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要批量停运的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/VIP_Share_List.cs", Session["wID"].ToString());
            }
        }

        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {//                                                                                                             and
            string sql = "with c as (select row_number() over(order by t_wdate desc) as rown, * from B2C_share where 1=1 " + _sql + ") select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th>标题</th>";
            str += @"        <th >访问次数</th>";
            str += @"        <th >起始时间<br /> 结束时间 <br />最后更新时间</th>";
            str += @"        <th>是否可分享</th>";
            str += @"        <th>分享后可获得积分</th>";
            str += @"        <th>图片</th>";
            str += @"        <th>修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["t_title"] + "<br />";
                str += @"          <td >" + dr["t_hits"] + "</td>";
                str += @"          <td >" + dr["t_bdate"] + "<br />" + dr["t_edate"] + "<br />" + dr["t_wdate"] + "</td>";
                str += @"          <td >" + intToString(dr["t_isactive"].ToString()) + "</td>";
                str += @"          <td >" + dr["t_ischead"] + "</td>";
                str += @"          <td >" + (string.IsNullOrEmpty(dr["t_gif"].ToString()) ? "" : "<image src='" + dr["t_gif"].ToString().Replace("all", "min") + "' width='60 height='60'/>") + "</td>";
                str += @"          <td ><a href='VIP_Share_Add.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                str += @"        </tr>";
            }
            str += @"</table>";

            return str;
        }
        #endregion

        private string intToString(string num)
        {
            string result = string.Empty;
            switch (num)
            {
                case "0":
                    result = "否";
                    break;
                case "1":
                    result = "是";
                    break;
            }
            return result;
        }
    }
}