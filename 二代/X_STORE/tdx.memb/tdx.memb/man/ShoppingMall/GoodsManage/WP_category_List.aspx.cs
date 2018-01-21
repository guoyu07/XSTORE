using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database;
using System.Text.RegularExpressions;
using tdx.memb.admin;

namespace tdx.memb.man.ShoppingMall.GoodsManage
{
    public partial class WP_category_List : System.Web.UI.Page
    {
        public string parents = "0";
        public string levels = "0";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                { 
                    if (Request["parent"] != null)
                    {
                        parents = Request["parent"];
                    }
                    if (Request["level"] != null)
                    {
                        levels = Request["level"];
                    }
                    string superSQL = " c_parent=" + parents + " order by c_sort,c_id desc";

                    Rp_UserInfo.DataSource = ClassList(superSQL);
                    Rp_UserInfo.DataBind();

                    //lb_catelist.Text = ClassList(superSQL);
                    //生成分页按钮
                    //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from WP_category").Rows[0][0]);
                    //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                    //lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='WP_category_Add.aspx?parent=" + parents + "&level=" + levels + "'\" value=\"添加产品类别\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/WP_category_List.cs", Session["wID"].ToString());
                }
            }
        }

        #region 读取数据
        protected DataTable ClassList(string _sql)
        {
            string parents = "";
            string _dzd = "";
            if (Request["parent"] != null)
            {
                parents = Request["parent"];
                _dzd = " *,(select c_name from WP_category where c_id=" + parents + ") as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt = WP_category.GetList(_dzd, _sql);

            //#region 获取大类数据
            //string str = "";
            //str += @"<table >";
            //str += @"       <tr>";
            ////str += "        <th><input type=\"checkbox\" class=\"btn\"  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            //str += @"        <th>选择</th>";
            //str += @"        <th >编号</th>";
            //str += @"        <th >名称</th>";
            //str += @"        <th >排序</th>";
            //str += @"        <th >图片</th>";
            //str += @"        <th >操作</th>";
            //str += @"       </tr>";
            //foreach (DataRow dr in dt.Rows)
            //{
            //    str += @"        <tr>";
            //    str += @"          <td > <span class=""checkall"" style=""vertical-align: middle;""><input type=checkbox   name=""delbox"" CssClass=""checkall""  value=""" + dr["c_id"] + "\"></span></td>";

            //    //str += @"              <td style='text-align: center;'>";
            //    //str +=@"                <asp:CheckBox ID='chkId' CssClass='checkall' runat='server' Style='vertical-align: middle;' />";
            //    //str += @"                <asp:HiddenField ID='hidId'  runat='server'  value=""" + dr["c_id"] + "\"> ";
            //    // str += @"                </td>";



            //    str += @"          <td>" + dr["c_no"] + "</td>";
            //    str += @"          <td><a href='?level=" + (Convert.ToInt32(dr["c_level"]) + 1) + "&parent=" + dr["c_id"] + "'>" + dr["c_name"] + "</a></td>";
            //    str += @"          <td>" + dr["c_sort"] + "</td>";
            //    str += @"          <td>" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"].ToString().Trim() + "' border='0' width='90' />") + "</td>";
            //    str += @"          <td><a href='WP_category_Add.aspx?id=" + dr["c_id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a> </td>";
            //    str += @"        </tr>";
            //}
            //str += @"</table>";
            //#endregion

            return dt;
        }
        #endregion

        #region 彻底删除
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
            for (int i = 0; i < Rp_UserInfo.Items.Count; i++)
                {
                int id = Convert.ToInt32(((HiddenField)Rp_UserInfo.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)Rp_UserInfo.Items[i].FindControl("chkId");
                if (cb.Checked)
                    {
                        try
                        {
                            DataTable dt = comfun.GetDataTableBySQL("select c_child from WP_category where c_id=" + id + " and c_child > 0");
                            if (dt.Rows.Count <= 0)
                            {
                                WP_category.myDel(id);

                            }
                            else
                            {
                                lt_result.Text = "存在子类的目录无法删除！";
                            }
                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除失败！";
                            return;
                        }
                    }
                    lt_result.Text = "已彻底删除！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='WP_category_List.aspx';},300);</script>";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/WP_category_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

    }
}