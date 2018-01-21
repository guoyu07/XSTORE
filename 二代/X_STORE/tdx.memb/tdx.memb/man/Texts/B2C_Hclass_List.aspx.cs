using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using Creatrue.kernel;
using tdx.database;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Hclass_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的图片类别，如：企业风采、企业场景等";
                    string parents = "0";
                    string levels = "0";
                    if (Request["parent"] != null)
                    {
                        parents = Request["parent"];
                    }
                    if (Request["level"] != null)
                    {
                        levels = Request["level"];
                    }
                    string superSQL = " c_parent=" + parents + " order by c_id asc";

                    lb_catelist.Text = ClassList(superSQL);
                    //生成分页按钮
                    //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Hclass").Rows[0][0]);
                    //lt_pagearrow.Text = tdx.master.Common.commonTool.F_pagearrow(_page, totalcount);

                    lb_cate.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='B2C_Hclass_Add.aspx?parent=" + parents + "&level=" + levels + "' \" value=\"添加图片类别\"/>";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2C_Hclass_List.cs", Session["wID"].ToString());
                }


            }
        }

        #region 读取数据
        protected string ClassList(string _sql)
        {
            string parents = "";
            string isactive = "";
            string parentsname = "";
            string isdel = "";
            string _dzd = "";
            if (Request["parent"] != null)
            {
                parents = Request["parent"];
                _dzd = " *,(select c_name from B2C_Hclass where c_id=" + parents + ")as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt = B2C_Hclass.GetList(_dzd, _sql);

            #region 获取大类数据
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th  ><input type=\"checkbox\"  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";//class=\"red\"  class=\"btn\" 
            str += @"        <th  >编号</th>";
            str += @"        <th  >名称</th>";
            str += @"        <th  >排序</th>";
            str += @"        <th >图片</th>";
            str += @"        <th  >修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                str += @"          <td >" + dr["c_no"] + "</td>";
                str += @"          <td ><a href='?level=" + (Convert.ToInt32(dr["c_level"]) + 1) + "&parent=" + dr["c_id"] + "'>" + dr["c_name"] + "</a><br />";
                //str += "获取地址:<span class='rb'>http://www.tdx.cn/" + B2C_worker.currentGNTheme() + "/photolist.aspx?id=" + dr["c_id"].ToString() + "&wwx=" + B2C_worker.currentWWX() + "</span></td>";
                str += @"          <td >" + dr["c_sort"] + "</td>";
                str += @"          <td >" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"] + "' border='0' height='90' />") + "</td>";
                str += @"          <td ><a href='B2C_Hclass_Add.aspx?id=" + dr["c_id"] + "'>修改</a></td>";
                str += @"        </tr>";
            }
            str += @"</table>";
            #endregion

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
                    String[] delidArry = Regex.Split(delid, ",");
                    foreach (String _id in delidArry)
                    {
                        int id = Convert.ToInt32(_id);
                        try
                        {
                            DataTable dt = comfun.GetDataTableBySQL("select c_child from B2C_Hclass where c_id=" + id + " and c_child > 0");
                            if (dt.Rows.Count <= 0)
                            {
                                B2C_Hclass.myDel(id);

                            }
                            else
                            {
                                lt_result.Text = "存在子类的目录无法删除！";
                            }
                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除失败！";
                        }
                    }
                    lt_result.Text = "已彻底删除！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_Hclass_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2C_Hclass_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

    }
}