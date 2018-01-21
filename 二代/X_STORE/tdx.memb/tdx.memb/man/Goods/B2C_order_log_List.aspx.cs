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
    public partial class B2C_order_log_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // lb_catelist.Text = ClassList();
                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_order_log").Rows[0][0]);
                //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
                lb_cateadd.Text = @"<a href='B2C_Goods_M_Add.aspx'>添加商品描述</a>";
            }
        }


        #region 读取数据
        protected string ClassList(int pagesize, int page)
        {

            string isactive = "";
            string isdel = "";
            string sql = "with c as (select row_number() over(order by ol_date desc) as rown, * from B2C_order_log) select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string str = "";
            str += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0  class='borderTable'>>";
            str += @"       <tr>";
            str += @"        <td height=""30"" align=center class=""red"">选择</td>";
            str += @"        <td align=center>订单编号</td>";
            str += @"        <td align=center>订单状态</td>";
            str += @"        <td align=center>操作员</td>";
            str += @"        <td align=center>操作时间</td>";
            str += @"        <td align=center>描述</td>";
            //  str += @"        <td align=center class=""tablehead"">修改</td>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td align=center height=""25""><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td align=center>" + dr["ono"] + "</td>";

                str += @"          <td align=center>" + dr["ol_name"] + "</td>";
                str += @"          <td align=center>" + dr["o_no"] + "</td>";
                str += @"          <td align=center>" + dr["ol_uid"] + "</td>";
                str += @"          <td align=center>" + dr["ol_date"] + "</td>";
                str += @"          <td align=center>" + dr["ol_des"] + "</td>";

                //str += @"          <td align=center><a href='B2C_Goods_Add.aspx?id=" + dr["id"] + "'>修改</a></td>";
                str += @"        </tr>";
            }
            str += @"</table>";

            return str;
        }
        #endregion

        #region 彻底删除
        protected void delBtn_ServerClick(object sender, EventArgs e)
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
                        // B2C_Goods.myDel(id);
                        // B2C_Goods_M.myDel(id);
                        Response.Write("<script language='javascript'>alert('已彻底删除！');location.href='B2C_Goods_List.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('彻底删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 是否删除
        protected void isdelBtn_ServerClick(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    string id = _id;
                    try
                    {
                        // B2C_Goods.setIsdel(id);
                        Response.Write("<script language='javascript'>alert('删除成功！');location.href='B2C_Goods_List.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('删除失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要删除的行！');history.go(-1);</script>");
            }
        }
        #endregion

        #region 是否启用
        protected void disnetBtn_ServerClick(object sender, EventArgs e)
        {
            string delid = "0";
            if (Request["delbox"] != null)
            {
                delid = Request["delbox"].ToString();
                String[] delidArry = Regex.Split(delid, ",");
                foreach (String _id in delidArry)
                {
                    string id = _id;
                    try
                    {
                        // B2C_Goods.setIsactive(id);
                        Response.Write("<script language='javascript'>alert('启用成功！');location.href='B2C_Goods_List.aspx';</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script language='javascript'>alert('启用失败！');history.go(-1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script language='javascript'>alert('请选择需要启用的行！');history.go(-1);</script>");
            }
        }
        #endregion
    }
}