using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;

namespace tdx.memb.man.Texts
{
    public partial class vote_Album_list : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的投票项信息";
            if (!IsPostBack)
            {
                try
                {
                    string safeSql = @"select table1.*,isnull(table2.total,0) as total from
(select [vote_Album].[id],[vote_bigpic].[name],[vote_bigpic].[isactive],[vote_Album].[Album_name],[vote_Album].[Album_pic],[vote_Album].[Album_desc],[vote_Album].[Album_regTime],
       [vote_Album].[bigpic_id] from [vote_Album] inner join [vote_bigpic] on [vote_Album].[bigpic_id]=[vote_bigpic].[id]
) as table1 left join(select Album_id,count(*) as total from vote_log group by Album_id) as table2 on table1.id=table2.Album_id"; //and [vote_bigpic].[cityID]=" + Session["wID"] + "
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + safeSql + ") as tb").Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, " 1=1 ");

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='vote_Album_Add.aspx'\" class=\"btnAdd\" value=\"添加投票项信息\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/vote_Album_list.cs", Session["wID"].ToString());
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
                    string safeSql = @"select table1.*,isnull(table2.total,0) as total from (select [vote_Album].[id],[vote_bigpic].[name],
       [vote_bigpic].[isactive],[vote_Album].[Album_name],[vote_Album].[Album_pic],[vote_Album].[Album_desc],[vote_Album].[Album_regTime],[vote_Album].[bigpic_id]
from [vote_Album] inner join [vote_bigpic] on [vote_Album].[bigpic_id]=[vote_bigpic].[id]) as table1 " +
"left join(select Album_id,count(*) as total from vote_log group by Album_id) as table2 on table1.id=table2.Album_id";//and [vote_bigpic].[cityID]=" + Session["wID"] + "
                    string keyword = ss_keyword.Value.Trim();
                    string sql = " name like '%" + keyword + "%' or Album_name like '%" + keyword + "%'";
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, sql);

                    //生成分页按钮 
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from (" + safeSql + ") as tb where " + sql).Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);

                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/vote_Album_list.cs", Session["wID"].ToString());
                }
            }
        }

        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {
            string safeSql = @"select table1.*,isnull(table2.total,0) as total from (select [vote_Album].[id],[vote_bigpic].[name],[vote_bigpic].[isactive],
       [vote_Album].[Album_name],[vote_Album].[Album_pic],[vote_Album].[Album_desc],[vote_Album].[Album_regTime],[vote_Album].[bigpic_id]
from [vote_Album] inner join [vote_bigpic] on [vote_Album].[bigpic_id]=[vote_bigpic].[id]) as table1 "+
"left join(select Album_id,count(*) as total from vote_log group by Album_id) as table2 on table1.id=table2.Album_id";//and [vote_bigpic].[cityID]=" + Session["wID"] + "
            string sql = "with c as (select row_number() over(order by bigpic_id desc) as rown, * from (" + safeSql + " ) as tb where 1=1 and " + _sql + ") select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += @"        <th>投票项目</th>";
            str += @"        <th >投票项名</th>";
            str += @"        <th>已投票数</th>";
            str += @"        <th >投票项封面图片</th>";
            str += @"        <th>是否启用</th>";
            str += @"        <th>注册时间</th>";
            str += @"        <th>修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td >" + dr["name"] + "<br />";
                str += @"          <td >" + dr["Album_name"] + "</td>";
                str += @"          <td >" + dr["total"] + "</td>";
                str += @"          <td ><img src=" + dr["Album_pic"].ToString().Replace("all", "min") + " width='60' height='60'/></td>";
                str += @"          <td >" + intToString(dr["isactive"].ToString()) + "</td>";
                str += @"          <td >" + dr["Album_regTime"] + "</td>";
                str += @"          <td ><a href='vote_Album_Add.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
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
                    result = "未启用";
                    break;
                case "1":
                    result = "启用";
                    break;
            }
            return result;
        }
    }
}