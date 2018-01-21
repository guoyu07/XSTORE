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
    public partial class B2C_Goods_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的产品信息";   //and cityID=" + Session["wID"].ToString().Trim() + "     
                    DataSet ds = comfun.GetDataSetBySQL("select * from b2c_category where c_parent=0 order by c_id;select * from B2C_brand where c_parent=0 order by c_no;");  //where  cityID=" + Session["wID"].ToString() + "
                    DataTable dt = ds.Tables[0];
                    DataTable dt_brand = ds.Tables[1];
                    if (dt.Rows.Count == 0)
                    {
                        string _sqlt = "";
                        _sqlt += "\r\n;insert into b2c_category(c_no,c_name,c_gif) values('001','缺省商品类别','/upload/201311/12/201311121958340.all.png')";//,cityID   ,{0}
                        //_sqlt = string.Format(_sqlt, Session["wID"].ToString().Trim());
                        try
                        {
                            comfun.UpdateBySQL(_sqlt);

                        }
                        catch (Exception ex)
                        {

                            comfun.ChuliException(ex, "man/Goods/B2C_Goods_List.cs", Session["wID"].ToString());
                            Response.Write("<script language='javascript'>location.href='B2C_Goods_List.aspx';</script>");
                        }
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        //ss_cid.Items.Add(new ListItem(dr("c_name"), dr("c_id")));
                        B2C_category.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_cid);
                    }
                    foreach (DataRow dr in dt_brand.Rows)
                    {
                        B2C_brand.getOneClassTree(Convert.ToInt32(dr["c_id"]), ss_bid);
                    }
                    dt.Dispose();
                    dt = null;

                    string _cno = Request["cno"] != null ? Request["cno"].ToString() : "";
                    string _bno = Request["bno"] != null ? Request["bno"].ToString() : "";
                    //生成分页按钮
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Goods where g_buytype=0 and g_isdel=0 and cno like '" + _cno + "%'").Rows[0][0]);// and cityid=" + Session["wID"].ToString().Trim() + "
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, " g_isdel=0 and cno like '" + _cno + "%' and bno like'" + _bno + "%'"); //"  cityid=" + Session["wID"].ToString().Trim() +

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='B2C_Goods_Add.aspx'\" class=\"btnAdd\" value=\"添加产品内容\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_Goods_List.cs", Session["wID"].ToString());
                }
            }
        }

        #region 读取数据
        protected string ClassList(int pagesize, int page, string _sql)
        {
            //and cityid=" + Session["wID"].ToString().Trim() + "
            string sql = "with c as (select row_number() over(order by g_wdate desc) as rown, *,(select top(1) a.c_name from b2c_category a where a.c_no=cno order by c_id desc) as cname,(select top(1) b.c_name from b2c_brand b where b.c_no=bno order by c_id desc) as dname from B2C_Goods where 1=1 and " + _sql + ") select top " + pagesize.ToString() + " * from c where rown > " + ((page - 1) * pagesize).ToString() + "order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            //string _br = "select * from B2C_brand";//where cityid=" + Session["wID"].ToString()
            //DataTable dt_br = comfun.GetDataTableBySQL(_br);
            Dictionary<string, string> _dic = new Dictionary<string, string>();
            //foreach (DataRow dr in dt_br.Rows)
            //{
            //    _dic.Add(dr["c_no"].ToString(), dr["c_name"].ToString());
            //}
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";

            str += @"        <th >大类别</th>";
    
            str += @"        <th>名称</th>";
            str += @"        <th >类别</th>";
            str += @"        <th >单位</th>";

            str += @"        <th >图片</th>";
            str += @"        <th >销售价</th>";
            str += @"        <th >市场价</th>";
            str += @"        <th>修改时间</th>";
            str += @"        <th>修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                string cnoname = dr["cno"].ToString().Substring(0, 3);
                DataTable dtcnoname = comfun.GetDataTableBySQL("select * from b2c_category where c_no ='" + cnoname + "'");
                if (dtcnoname.Rows.Count > 0)
                {
                    str += @"          <td >" + dtcnoname.Rows[0]["c_name"] + "</td>";
                }
                else
                {
                    str += @"          <td >无</td>";

                }
                str += @"          <td >" + dr["g_name"] + "<br />";
                //str += "获取地址:<span class='rb'>http://www.tdx.cn/" + B2C_worker.currentGNTheme() + "/showpro.aspx?id=" + dr["id"].ToString() + "&wwx=" + B2C_worker.currentWWX() + "</span></td>";
                str += @"          <td >" + dr["cname"] + "</td>";
                if (dr["bno"].ToString() != "")
                {
                    str += @"          <td >" + dr["dname"] + "</td>";
                }
                else
                    str += @"          <td ></td>";
                
             
               

                str += @"          <td >" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "" : "<image src='" + dr["g_gif"].ToString().Replace("all", "min") + "' width='60 height='60'/>") + "</td>";
                str += @"          <td >" + Creatrue.Common.commonTool.GetMoney(dr["g_price_S"].ToString()) + "</td>";
                str += @"          <td >" + Creatrue.Common.commonTool.GetMoney(dr["g_price_M"].ToString()) + "</td>";
                str += @"          <td >" + dr["regtime"] + "</td>";
                str += @"          <td ><a href='B2C_Goods_Add.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a>|<a href='../pricecompare/BJ_P2P.aspx?id=" + dr["id"] + "'>比价</a></td>";
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
                    //string sql = "delete from b2c_goods where id in (" + delid + ")";

                    String[] delidArry = Regex.Split(delid, ",");
                    foreach (String _id in delidArry)
                    {
                        int id = Convert.ToInt32(_id);
                        try
                        {
                            B2C_Goods.myDel(id);
                            B2C_Goods_M.myDel(id);

                        }
                        catch (Exception ex)
                        {
                            lt_result.Text = "彻底删除失败！";
                        }
                    }
                    lt_result.Text = "已彻底删除！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Goods_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_Goods_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

        //搜索
        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            //收集参数
            try
            {
                string keyword = ss_keyword.Value.Trim();
                string _cid = ss_cid.Value;

                string sql = " g_name like '%" + keyword + "%'"; //"  cityid=" + Session["wID"].ToString().Trim() +  and
                if (!string.IsNullOrEmpty(_cid))
                {
                    sql = sql + " and cno like '" + _cid + "%'";
                }
                if (!string.IsNullOrEmpty(ss_bid.Value))
                {
                    sql += " and bno like '" + ss_bid.Value + "%'";
                }

                int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                lb_catelist.Text = ClassList(consts.pagesize_Txt, _page, sql);

                //生成分页按钮 
                int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Goods where  " + sql).Rows[0][0]);
                lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_Goods_List.cs", Session["wID"].ToString());
            }
        }


    }
}