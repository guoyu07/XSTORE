using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Creatrue.kernel;
using tdx.database.database;
using tdx.database;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Ads
{
    public partial class B2C_Adclass_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_Adclass").Rows[0][0]);
                //lt_pagearrow.Text = fsWeixin.master.Common.commonTool.F_pagearrow(_page, totalcount);

                lb_cateadd.Text = @"<a href='B2C_Adclass_Add.aspx?parent=" + parents + "&level=" + levels + "'>添加类别</a>";
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
                _dzd = " *,(select c_name from B2C_Adclass_Web where c_id=" + parents + ")as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt = B2C_Adclass.GetList(_dzd, _sql);

            #region 获取大类数据
            string str = "";
            str += @"<table width=100% border=0 align=center cellpadding=0 cellspacing=0 class='borderTable'>";
            str += @"       <tr>";
            str += @"        <td height=""25"" align=center class=""red"">选择</td>";
            str += @"        <td align=center >编号</td>";
            str += @"        <td align=center >名称</td>";
            str += @"        <td align=center >排序</td>";
            str += @"        <td align=center >图片</td>";
            str += @"        <td align=center >宽*高</td>";
            str += @"        <td align=center >价格</td>";
            str += @"        <td align=center >修改</td>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td align=center><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                str += @"          <td align=center height=24>" + dr["c_no"] + "</td>";
                str += @"          <td align=center>" + dr["c_name"] + "</td>";
                str += @"          <td align=center height=24>" + dr["c_sort"] + "</td>";
                str += @"          <td align=center height=24>" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"] + "' border='0' height='90' />") + "</td>";
                str += @"          <td align=center height=24>" + dr["c_width"] + "*" + dr["c_height"] + "</td>";
                str += @"          <td align=center height=24>" + dr["c_amt"] + "</td>";
                str += @"          <td align=center><a href='B2C_Adclass_Add.aspx?id=" + dr["c_id"] + "'>修改</a></td>";
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
                        DataTable dt = comfun.GetDataTableBySQL("select c_child from B2C_Adclass_Web where c_id=" + id + " and c_child > 0");
                        if (dt.Rows.Count <= 0)
                        {
                            B2C_Adclass.myDel(id);
                            Response.Write("<script language='javascript'>alert('已彻底删除！');location.href='B2C_Adclass_List.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('存在子类的目录无法删除！');location.href='B2C_Adclass_List.aspx';</script>");
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

    }
}