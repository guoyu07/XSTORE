using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Goods
{
    public partial class B2C_Vip_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的会员特权产品信息";
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Goods where g_isdel=0 and g_buytype=1").Rows[0][0]); // and cityid=" + Session["wID"].ToString().Trim()
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, "(g_buytype = 1) and g_isdel=0"); //and cityid=" + Session["wID"].ToString().Trim()

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='B2C_Vip_Add.aspx'\" class=\"btnAdd\" value=\"添加会员特权产品\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_Goods_List.cs", Session["wID"].ToString());
                }
            }
        }
        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            //收集参数
            try
            {
                string keyword = ss_keyword.Value.Trim();

                string sql = "  g_name like '%" + keyword + "%'"; // cityid=" + Session["wID"].ToString().Trim() + " and

                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, sql);

                //生成分页按钮 
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Goods where g_isdel=0 and g_buytype=1 and " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_Goods_List.cs", Session["wID"].ToString());
            }
        }
        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {
            //                                                                        and cityid=" + Session["wID"].ToString().Trim() + "
            string sql = "with c as (select row_number() over(order by g_wdate desc) as rown, *,(select top(1) a.c_name from b2c_category a where a.c_no=cno order by c_id desc) as cname,(select top(1) b.c_name from b2c_brand b where b.c_no=bno order by c_id desc) as dname from B2C_Goods where 1=1 and " + _sql + ") select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";

            DataTable dt = comfun.GetDataTableBySQL(sql);
            //string _br = "select * from B2C_brand"; // where cityid=" + Session["wID"].ToString()
            //DataTable dt_br = comfun.GetDataTableBySQL(_br);
            //Dictionary<string, string> _dic = new Dictionary<string, string>();
            //foreach (DataRow dr in dt_br.Rows)
            //{
            //    _dic.Add(dr["c_no"].ToString(), dr["c_name"].ToString());
            //}
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th>名称</th>";
            str += @"        <th >单位</th>";
            str += @"        <th >图片</th>";
            str += @"        <th >优惠价</th>";

            str += @"        <th>修改时间</th>";
            str += @"        <th>修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["g_name"] + "<br />";
                //str += "获取地址:<span class='rb'>http://www.tdx.cn/" + B2C_worker.currentGNTheme() + "/showpro.aspx?id=" + dr["id"].ToString() + "&wwx=" + B2C_worker.currentWWX() + "</span></td>";
                str += @"          <td >" + dr["g_unit"] + "</td>";
                str += @"          <td >" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "" : "<image src='" + dr["g_gif"].ToString().Replace("all", "min") + "' width='60 height='60'/>") + "</td>";
                str += @"          <td >" + Creatrue.Common.commonTool.GetMoney(dr["g_price_S"].ToString()) + "</td>";
                str += @"          <td >" + dr["regtime"] + "</td>";
                str += @"          <td ><a href='B2C_Vip_Add.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                str += @"        </tr>";
            }
            str += @"</table>";

            return str;
        }
        #endregion

        #region 批量停运
        protected void delBtn_ServerClick(object sender, EventArgs e)
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
                            B2C_Goods.setIsdel(id.ToString());
                        }
                        catch (Exception ex)
                        {
                            lt_result.Text = "放入回收站失败！";
                        }
                    }
                    lt_result.Text = "已放入回收站！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Vip_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要放入回收站的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_Vip_List.cs", Session["wID"].ToString());
            }
        }
        #endregion
    }
}