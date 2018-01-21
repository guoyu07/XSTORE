using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Texts
{
    public partial class B2c_TPageClassList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 编辑您的页面类别，即页面所在的栏目。";
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

                    string superSQL = "select * from b2c_tpclass where c_parent=" + parents +  "order by c_id"; //" and cityID=" + Session["wID"].ToString().Trim() + "

                    lb_catelist.Text = ClassList(superSQL);
                    //生成分页按钮
                    //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_tclass").Rows[0][0]);
                    //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                    lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\"location.href='B2C_TPageClass_Add.aspx?parent=" + parents + "&level=" + levels + "'\" value=\"添加页面类别\" />";
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Texts/B2c_TPageClassList.cs", Session["wID"].ToString());
                }
            }
        }


        #region 读取数据
        protected string ClassList(string _sql)
        {
            string str = "";
            try
            {
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                #region 获取大类数据

                str += @"<table>";
                str += @"       <tr>";
                str += "        <th><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
                str += @"        <th >编号</th>";
                str += @"        <th>名称</th>";
                str += @"        <th>排序</th>";
                str += @"        <th>图片</th>";
                str += @"        <th>操作</th>";
                str += @"       </tr>";
                foreach (DataRow dr in dt.Rows)
                {
                    str += @"        <tr>";
                    str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                    str += @"          <td >" + dr["c_no"] + "</td>";
                    str += @"          <td ><a href='?level=" + (Convert.ToInt32(dr["c_level"]) + 1) + "&parent=" + dr["c_id"] + "'>" + dr["c_name"] + "</a></td>";
                    str += @"          <td >" + dr["c_sort"] + "</td>";
                    str += @"          <td >" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"].ToString().Trim() + "' border='0' width='90' />") + "</td>";
                    str += @"          <td ><a href='B2C_TPageClass_Add.aspx?id=" + dr["c_id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a> </td>";
                    str += @"        </tr>";
                }
                str += @"</table>";
                #endregion

                return str;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Texts/B2c_TPageClassList.cs", Session["wID"].ToString());
                return str;
            }
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
                        DataTable dt = comfun.GetDataTableBySQL("select top 1 * from B2C_TPclass where c_id=" + id);
                        string _c_no = dt.Rows[0]["c_no"].ToString();
                        try
                        {

                            DataTable _dt = comfun.GetDataTableBySQL("select * from B2C_tpage where cno=" + _c_no); // + " and cityID=" + Session["wID"].ToString()
                            if (_dt.Rows.Count <= 0)
                            {
                                B2C_TPclass.myDel(id);
                                lt_result.Text += "<br/>编号" + _c_no + "的项已彻底删除";
                            }
                            else
                            {
                                lt_result.Text += "<br/>编号" + _c_no + "的项存在页面内容无法删除";
                            }
                        }
                        catch (Exception)
                        {
                            lt_result.Text = "<br/>编号" + _c_no + "的项彻底删除失败";
                        }
                    }

                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2c_TPageClassList.aspx';},2000);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项";
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Texts/B2c_TPageClassList.cs", Session["wID"].ToString());
            }
        }
        #endregion

    }
}