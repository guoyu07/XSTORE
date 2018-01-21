using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Text.RegularExpressions;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class B2C_Pclass_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string parents = "0";
                string levels = "0";
                lb_date.Text = DateTime.Now.ToShortDateString();
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
                //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Pclass").Rows[0][0]);
                //lt_pagearrow.Text = tdx.master.Common.commonTool.F_pagearrow(_page, totalcount);

                lb_cateadd.Text = @"<a href='B2C_Pclass_Add.aspx?parent=" + parents + "&level=" + levels + "'>添加类别</a>";
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
                _dzd = " *,(select c_name from B2C_Pclass where c_id=" + parents + ")as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt = B2C_Pclass.GetList(_dzd, _sql);

            #region 获取大类数据
            string str = "";
            str += @"<table >";
            str += @"       <tr bgcolor=#427faf>";
            str += @"        <th height=""25"" align=center >选择</th>";
            str += @"        <th align=center >编号</th>";
            str += @"        <th align=center >名称</th>";
            str += @"        <th align=center >目录</th>";
            str += @"        <th align=center >排序</th>";
            str += @"        <th align=center >父类</th>";
            str += @"        <th align=center >子类数量</th>";
            str += @"        <th align=center >是否启用</th>";
            str += @"        <th align=center >是否删除</th>";
            str += @"        <th align=center >修改</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr bgcolor=#def0ff >";
                str += @"          <td align=center><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                str += @"          <td align=center height=24>" + dr["c_no"] + "</td>";
                str += @"          <td align=center><a href='B2C_Pclass_List.aspx?level=" + dr["c_level"] + 1 + "&parent=" + dr["c_id"] + "'>" + dr["c_name"] + "</a></td>";
                str += @"          <td align=center height=24>" + dr["c_url"] + "</td>";
                str += @"          <td align=center height=24>" + dr["c_sort"] + "</td>";
                if (Request["parent"] != null)
                {
                    if (!Convert.IsDBNull(dr["cname"].ToString()))
                    {
                        parentsname = dr["cname"].ToString();
                    }
                    else
                    {
                        parentsname = "没有父类了";
                    }
                }
                else
                {
                    parentsname = "没有父类了";
                }
                str += @"          <td align=center height=24>" + parentsname + "</td>";
                str += @"          <td align=center height=24>" + dr["c_child"] + "</td>";
                isactive = Convert.ToInt32(dr["c_isactive"]) == 1 ? "是" : "否";
                isdel = Convert.ToInt32(dr["c_isdel"]) == 0 ? "否" : "是";
                str += @"          <td align=center height=24>" + isactive + "</td>";
                str += @"          <td align=center height=24>" + isdel + "</td>";
                str += @"          <td align=center><a href='B2C_Pclass_Add.aspx?id=" + dr["c_id"] + "'>修改</a></td>";
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
                        DataTable dt = comfun.GetDataTableBySQL("select c_child from B2C_Pclass where c_id=" + id + " and c_child > 0");
                        if (dt.Rows.Count <= 0)
                        {
                            B2C_Pclass.myDel(id);
                            Response.Write("<script language='javascript'>alert('已彻底删除！');location.href='B2C_Pclass_List.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('存在子类的目录无法删除！');location.href='B2C_Pclass_List.aspx';</script>");
                        }
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
                        B2C_Pclass.setC_isdel(id);
                        Response.Write("<script language='javascript'>alert('删除成功！');location.href='B2C_Pclass_List.aspx';</script>");
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
                        B2C_Pclass.setC_isactive(id);
                        Response.Write("<script language='javascript'>alert('启用成功！');location.href='B2C_Pclass_List.aspx';</script>");
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