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
    public partial class Voucher_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的代金券信息";
            if (!IsPostBack)
            {
                try
                {
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from C2C_voucher where wid=" + Session["wID"].ToString().Trim()).Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, "  wid=" + Session["wID"].ToString().Trim());

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='Voucher_Add.aspx'\" class=\"btnAdd\" value=\"添加代金卷\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/Voucher_List.cs", Session["wID"].ToString());
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
                    double keyword = Convert.ToDouble(ss_keyword.Value.Trim());

                    string sql = "  wid=" + Session["wID"].ToString().Trim() + " and v_amount like '%" + keyword + "%' or v_deduction like '%" + keyword + "%'";

                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, sql);

                    //生成分页按钮 
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from C2C_voucher where " + sql).Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/Voucher_List.cs", Session["wID"].ToString());
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
                    int iret = C2C_voucher.IsNoactive(delid);
                    if (iret == 1)
                    {
                        lt_result.Text = "已批量停运成功！";
                    }
                    else
                    { lt_result.Text = "已批量停运失败！"; }

                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Voucher_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要批量停运的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/Voucher_List.cs", Session["wID"].ToString());
            }
        }

        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {
            string sql = "with c as (select row_number() over(order by regtime desc) as rown, * from C2C_voucher where 1=1 and " + _sql + ") select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th>发行数量</th>";
            str += @"        <th >使用金额条件</th>";
            str += @"        <th >抵扣金额</th>";

            str += @"        <th>创建时间</th>";
            str += @"        <th>有效期开始</th>";
            str += @"        <th>有效期结束</th>";
            str += @"        <th>是否激活</th>";
            str += @"        <th>修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["v_num"] + "<br />";
                str += @"          <td >" + dr["v_amount"] + "</td>";
                str += @"          <td >" + dr["v_deduction"] + "</td>";
                str += @"          <td >" + dr["regtime"].ToString() + "</td>";
                str += @"          <td >" + dr["v_start_time"] + "</td>";
                str += @"          <td >" + dr["v_end_time"] + "</td>";
                str += @"          <td >" + intToString(dr["v_isactive"].ToString()) + "</td>";
                str += @"          <td ><a href='Voucher_Add.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
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