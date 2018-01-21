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

namespace tdx.memb.man.Sets
{
    public partial class B2C_menu_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>首页栏目即展示在您的微网站首页的栏目名称及图标，如右图";



                    //string _cityID = Session["wid"].ToString();
                    DataTable dt = B2C_menu.GetList("*", "1=1");
                    if (dt.Rows.Count == 0)
                    {
                        string _sql = "";
                        _sql += "\r\n;insert into b2c_menu(c_no,c_name,c_sort) values('001','首页',1)"; //,cityid ,{0}
                        _sql += "\r\n;insert into b2c_menu(c_no,c_name,c_sort) values('002','头部',1)"; //,cityid ,{0}
                        _sql += "\r\n;insert into b2c_menu(c_no,c_name,c_sort) values('003','底部',1)"; //,cityid ,{0}
                        //_sql = string.Format(_sql, _cityID);
                        try
                        {
                            comfun.UpdateBySQL(_sql);

                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script language='javascript'>location.href='B2C_menu_List.aspx';</script>");
                            comfun.ChuliException(ex, "man/sets/B2C_menu_List.cs", Session["wID"].ToString());
                        }
                    }
                    string parents = "1";
                    string levels = "2";
                    if (Request["parent"] != null)
                    {
                        parents = Request["parent"];
                    }
                    if (Request["level"] != null)
                    {
                        levels = Request["level"];
                    }
                    string superSQL = " c_level=" + levels + " order by c_sort,c_id desc";

                    lb_catelist.Text = ClassList(superSQL);
                    //生成分页按钮
                    //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_menu").Rows[0][0]);
                    //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                    lb_cate.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\" location.href='B2C_menu_Add.aspx?parent=" + parents + "&level=" + levels + "' \"value=\"添加栏目\"/>";
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/sets/B2C_menu_List.cs", Session["wID"].ToString());
                }
            }
        }

        #region 读取数据
        protected string ClassList(string _sql)
        {
            string parents = "";
            string str = "";
            try
            {
                string _dzd = "";
                //if (Request["parent"] != null)
                //{
                //    parents = Request["parent"];
                //    _dzd = " *,(select c_name from B2C_menu as bm where bm.c_id=b2c_menu.c_parent and bm.cityID=B2C_menu.cityID) as cname ";
                //}
                //else
                //{
                _dzd = " *,(select c_name from B2C_menu as bm where bm.c_id=b2c_menu.c_parent) as cname   ";// and bm.cityID=B2C_menu.cityID
                //}
                DataTable dt = B2C_menu.GetList(_dzd, _sql);

                #region 获取大类数据

                str += @"<table>";
                str += @"       <tr>";
                str += "        <th ><input type=\"checkbox\"  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
                str += @"        <th >分类</th>";
                str += @"        <th >栏目名称</th>";
                str += @"        <th >排序</th>";
                str += @"        <th >图标</th>";
                str += @"        <th >操作</th>";
                str += @"       </tr>";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["cname"].ToString() != "首页")
                        continue;
                    str += @"        <tr>";
                    str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                    str += @"          <td >" + dr["cname"] + "</td>";
                    str += @"          <td >" + dr["c_name"] + "</td>";
                    str += @"          <td >" + dr["c_sort"] + "</td>";
                    str += @"          <td >" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"].ToString().Trim() + "' border='0' width='90' />") + "</td>";
                    str += "          <td align=center><a href='B2C_menu_Add.aspx?id=" + dr["c_id"] + "'><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a> </td>";
                    str += @"        </tr>";
                }
                str += @"</table>";
                #endregion

                return str;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/sets/B2C_menu_List.cs", Session["wID"].ToString());
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
                        B2C_menu b2c = new B2C_menu(id);
                        try
                        {
                            DataTable dt = comfun.GetDataTableBySQL("select c_child from B2C_menu where c_id=" + id + " and c_child > 0");
                            if (dt.Rows.Count <= 0)
                            {
                                B2C_menu.myDel(id);
                            }
                            else
                            {
                                lt_result.Text = "存在子类的目录无法删除！";
                                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu_List.aspx';},300);</script>";
                                return;
                            }
                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除\"" + b2c.c_name + "\"项失败！";
                            return;
                        }
                    }
                    lt_result.Text = "已彻底删除！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu_List.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/sets/B2C_menu_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

    }
}