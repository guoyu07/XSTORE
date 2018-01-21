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

namespace tdx.memb.man.Texts
{
    public partial class vote_Bigpic_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的投票项目信息";
            if (!IsPostBack)
            {
                try
                {
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from vote_bigpic").Rows[0][0]); // where cityID=" + Session["wID"]
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, ""); //, " cityID=" + Session["wID"]

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='vote_Bigpic_Add.aspx'\" class=\"btnAdd\" value=\"添加投票项目\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/vote_Bigpic_List.cs", Session["wID"].ToString());
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
                    string sql = " name like '%" + keyword + "%'"; //and cityID=" + Session["wID"]
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, sql);

                    //生成分页按钮 
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from vote_bigpic where " + sql).Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/vote_Bigpic_list.cs", Session["wID"].ToString());
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>setTimeout(function(){location.href='vote_Bigpic_list.aspx';},300);</script>");
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
                    String[] arlist = Regex.Split(delid, ",");
                    foreach (string _id in arlist)
                    {
                        int id = Convert.ToInt32(_id);
                        string updateSql = @"update vote_bigpic set isactive=0 where id=" + id;
                        comfun.UpdateBySQL(updateSql);
                    }
                    lt_result.Text = "批量停运成功！<script language='javascript'>setTimeout(function(){location.href='vote_Bigpic_list.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要批量停运的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/vote_Bigpic_List.cs", Session["wID"].ToString());
            }
        }
        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {
            string sql = "with c as (select row_number() over(order by regTime desc) as rown, * from vote_Bigpic where 1=1 " + (_sql.Length > 0 ? " and" + _sql : "") + ") select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th>投票项目名</th>";
            str += @"        <th >代表图片</th>";
            str += @"        <th>是否启用</th>";
            str += @"        <th>注册时间</th>";
            str += @"        <th>修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["name"] + "<br /><br/>获取地址：tp.aspx?id=" + dr["id"] + "</td>";
                str += @"          <td ><img src=" + dr["picurl"].ToString().Replace("all", "min") + " width='60' height='60'/></td>";
                str += @"          <td >" + intToString(dr["isactive"].ToString()) + "</td>";
                str += @"          <td >" + dr["regTime"] + "</td>";
                str += @"          <td ><a href='vote_Bigpic_Add.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
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
                    result = "不启用";
                    break;
                case "1":
                    result = "启用";
                    break;
            }
            return result;
        }
    }
}