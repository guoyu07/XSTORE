using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common.Msgbox;
using Creatrue.kernel;
using DTcms.DAL;
using tdx.database;
using WP_category = tdx.database.TK_发帖类别表;

namespace tdx.memb.man.Talking
{
    public partial class TalkTypeList : System.Web.UI.Page
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
                    string superSQL = " c_parent=" + parents + " order by c_sort asc,id desc";

                    lb_catelist.Text = ClassList(superSQL);
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Talking/TalkTypeList.cs", Session["wID"].ToString());
                }
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
                _dzd = " *";
                //,(select c_name from TK_发帖类别表 where id=" + parents + ") as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt =  tdx.database.TK_发帖类别表.GetList(_dzd, _sql);

            #region 获取大类数据
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            //str += "        <th><input type=\"checkbox\" class=\"btn\"  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th>选择</th>";
            str += @"        <th >编号</th>";
            str += @"        <th >名称</th>";
            str += @"        <th >排序</th>";
            str += @"        <th >图片</th>";
            str += @"        <th >操作</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox""   value=""" + dr["id"] + "\"></td>";

                //str += @"              <td style='text-align: center;'>";
                //str +=@"                <asp:CheckBox ID='chkId' CssClass='checkall' runat='server' Style='vertical-align: middle;' />";
                //str += @"                <asp:HiddenField ID='hidId'  runat='server'  value=""" + dr["id"] + "\"> ";
                // str += @"                </td>";



                str += @"          <td>" + dr["类别编号"] + "</td>";
                str += @"          <td><a href='?level=" + (Convert.ToInt32(dr["c_level"]) + 1) + "&parent=" + dr["id"] + "'>" + dr["类别名"] + "</a></td>";
                str += @"          <td>" + dr["c_sort"] + "</td>";
                str += @"          <td>" + (string.IsNullOrEmpty(dr["图片"].ToString()) ? "" : "<img src='" + dr["图片"].ToString().Trim() + "' border='0' width='90' />") + "</td>";
                str += @"          <td><a href='TalkTypeEdit.aspx?id=" + dr["id"] + "'><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a> </td>";
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
                            DataTable dt = comfun.GetDataTableBySQL("select c_child from [TK_发帖类别表] where id=" + id + " and c_child > 0");
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
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='TalkTypeList.aspx';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Talking/TalkTypeList.cs", Session["wID"].ToString());
            }
        }
        #endregion
    }
}