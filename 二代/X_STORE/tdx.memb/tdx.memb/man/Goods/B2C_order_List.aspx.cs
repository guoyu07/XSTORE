using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using System.Text.RegularExpressions;
using System.Data;

namespace tdx.memb.man.Goods
{
    public partial class B2C_order_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 处理您的商城订单，也可导出订单";
                    //生成分页按钮
                    int _wid = Convert.ToInt32(Session["wID"].ToString());
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_orders where wid=" + _wid.ToString()).Rows[0][0]);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, " and 1=1");
                    //lb_cateadd.Text = @"<a href='B2C_Goods_M_Add.aspx'>添加商品描述</a>";

                    //咨询
                    DataTable dt = comfun.GetDataTableBySQL("select * from B2C_order_active order by id");
                    txt_cid.DataSource = dt;
                    txt_cid.DataTextField = "a_name";
                    txt_cid.DataValueField = "id";
                    txt_cid.DataBind();
                    txt_cid.Items.Insert(0, new ListItem("全部", "0"));
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_order_List.cs", Session["wID"].ToString());
                }
            }
        }


        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {
            string sql = "with c as (";
            sql += "\n select row_number() over(order by o_date desc) as rown,id as id,o_no,o_date";
            sql += " ,o_isdel,gid,o_amt,o_stid,o_st_amt,o_allamt,o_cent";
            sql += " ,(select M_name from b2c_mem where b2c_orders.mid=b2c_mem.id) as Mname";
            sql += " ,(select st_name from b2c_sendtype where b2c_orders.o_stid=b2c_sendtype.id) as stname";
            sql += ",(select a_name from b2c_order_active where id=b2c_orders.aid) as aname";
            sql += " from B2C_orders";
            sql += " where 1=1 and wid=" + Session["wid"].ToString();
            sql += " " + _sql;

            sql += " )";
            sql += " select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + " order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string str = "";
            str += @"<table>";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th >时间</th>";
            str += @"        <th >订单编号</th>";
            str += @"        <th >金额</th>";
            str += @"        <th >积分</th>";
            str += @"        <th >配送</th>";
            str += @"        <th >运费</th>";
            str += @"        <th >总金额</th>";
            str += @"        <th >状态</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["o_date"] + "</td>";
                str += @"          <td><a href='b2c_orders_Detail.aspx?ono=" + dr["o_no"].ToString() + "'>" + dr["o_no"] + "</a></td>";

                str += @"          <td >";
                str += "                " + string.Format("{0:F}", Convert.ToDouble(dr["o_amt"]));
                str += "           </td>";
                str += @"          <td >";
                str += "                " + string.Format("{0:F}", Convert.ToDouble(dr["o_cent"]));
                str += "           </td>";
                str += @"          <td >" + dr["stname"].ToString() + "</td>";
                str += @"          <td >";
                str += "                " + string.Format("{0:F}", Convert.ToDouble(dr["o_st_amt"]));
                str += "           </td>";
                str += @"          <td >";
                str += "                " + string.Format("{0:F}", Convert.ToDouble(dr["o_allamt"]));
                str += "           </td>";
                str += @"          <td >" + dr["aname"].ToString() + "</td>";
                str += @"        </tr>";
            }
            str += @"</table>";

            return str;
        }
        #endregion

        #region 彻底删除
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string delid = "0";
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    string _sql = "delete from b2c_orders where id in (" + delid + ")";
                    _sql += ";\r\n delete from b2c_order_d where ono in (select o_no from b2c_orders where id in(" + delid + "))";
                    _sql += ";\r\n delete from b2c_order_addr where ono in (select o_no from b2c_orders where id in(" + delid + "))";
                    _sql += ";\r\n delete from b2c_order_log where ono in (select o_no from b2c_orders where id in(" + delid + "))";
                    _sql += ";\r\n delete from b2c_order_pay where ono in (select o_no from b2c_orders where id in(" + delid + "))";

                    try
                    {
                        comfun.UpdateBySQL(_sql);
                        lt_result.Text = "已彻底删除！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_order_List.aspx';},300);</script>";
                    }
                    catch (Exception)
                    {
                        lt_result.Text = "彻底删除失败！";
                    }

                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_order_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

        #region 是否删除
        protected void isdelBtn_ServerClick(object sender, EventArgs e)
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
                        string id = _id;
                        try
                        {
                            // B2C_Goods.setIsdel(id);
                            B2C_orders.myDel(id);
                            lt_result.Text = "删除成功！";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_order_List.aspx';},300);</script>";
                        }
                        catch (Exception)
                        {
                            lt_result.Text = "删除失败！";
                        }
                    }

                }
                else
                {
                    lt_result.Text = "请选择需要删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_order_List.cs", Session["wID"].ToString());
            }
        }
        #endregion


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ss_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string Sql = " ";
                string key = comFunction.NoHTML(ss_keyword.Value);
                string _cid = txt_cid.Value;
                int temp;
                int.TryParse(_cid, out temp);

                Sql += " and o_no like '%" + key + "%'";

                if (txt_StartCPXG.Value != "")
                {
                    Sql = Sql + " and o_date >= '" + Convert.ToDateTime(txt_StartCPXG.Value) + "'";
                }
                if (txt_StartCPXG_DATE.Value != "")
                {
                    Sql = Sql + " and o_date <= '" + Convert.ToDateTime(txt_StartCPXG_DATE.Value) + "'";
                }
                string isd = "";
                if (Request["ss_isDel"] != null)
                {
                    isd = Request["ss_isDel"].ToString();
                    Sql += "  and o_isdel=1 ";
                }
                if (temp > 0)
                {
                    Sql += " and aid=" + _cid;
                }



                //生成分页按钮
                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(b2c_orders.id) from b2c_orders where 1=1 " + Sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);

                lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, Sql);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_order_List.cs", Session["wID"].ToString());
            }
        }
    }
}