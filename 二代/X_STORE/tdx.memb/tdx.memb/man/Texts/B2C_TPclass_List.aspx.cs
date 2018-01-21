using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using tdx.database;
using Creatrue.kernel;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Texts
{
    public partial class B2C_TPclass_List : workAuth
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
                string superSQL = " c_parent=" + parents + " order by c_sort,c_id desc";

                lb_catelist.Text = ClassList(superSQL);
                //生成分页按钮
                //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_TPclass").Rows[0][0]);
                //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                //lb_cateadd.Text = @"<a href='B2C_TPclass_Add.aspx?parent=" + parents + "&level=" + levels + "'>添加类别</a>";
                lb_cateadd.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\" location.href='B2C_TPclass_Add.aspx?parent=" + parents + "&level=" + levels + "' \"value=\"添加图文类别\"/>";
            }
        }

        #region 读取数据
        protected string ClassList(string _sql)
        {
            string parents = "";
            string _dzd = "";
            if (Request["parent"] != null)
            {
                parents = Request["parent"];
                _dzd = " *,(select c_name from B2C_TPclass where c_id=" + parents + ") as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt = B2C_TPclass.GetList(_dzd, _sql);

            #region 获取大类数据
            string str = "";
            str += @"<table>";
            str += @"       <tr>";
            str += @"        <th height=""25"" align=left ><input type='checkbox' class='btn' name='delAll' id='delAll' runat='server' onclick='this.value=checkAll(form1.delbox,this);' />全选</th>";
            str += @"        <th align=center >名称</th>";
            str += @"        <th align=center >排序</th>";
            str += @"        <th align=center >图片</th>";
            str += @"        <th align=center >操作</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td align=left height='100'><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                str += @"          <td align=center><a href='?level=" + (Convert.ToInt32(dr["c_level"]) + 1) + "&parent=" + dr["c_id"] + "'>" + dr["c_name"] + "</a></td>";
                str += @"          <td align=center>" + dr["c_sort"] + "</td>";
                str += @"          <td align=center>" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"].ToString().Trim() + "' border='0' width='90' />") + "</td>";
                str += @"          <td align=center><a href='B2C_TPclass_Add.aspx?id=" + dr["c_id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></a> </td>";
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
                        DataTable dt = comfun.GetDataTableBySQL("select c_child from B2C_TPclass where c_id=" + id + " and c_child > 0");
                        if (dt.Rows.Count <= 0)
                        {
                            B2C_TPclass.myDel(id);
                            Response.Write("<script language='javascript'>alert('已彻底删除！');location.href='B2C_TPclass_List.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('存在子类的目录无法删除！');location.href='B2C_TPclass_List.aspx';</script>");
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