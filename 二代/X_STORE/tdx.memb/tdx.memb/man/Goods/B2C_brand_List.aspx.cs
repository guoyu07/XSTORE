using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using Creatrue.Common;
using System.Data;
using tdx.database;
using System.Text.RegularExpressions;

namespace tdx.memb.man.Goods
{
    public partial class B2C_brand_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 设置您的产品品牌信息。";
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
                //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_brand").Rows[0][0]);
                //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                lb_cate.Text = "<input type=\"button\" class=\"btnAdd\"  onclick=\"location.href='B2C_brand_Add.aspx?parent=" + parents + "&level=" + levels + "'\" value=\"添加品牌\" />";

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
                _dzd = " *,(select c_name from B2C_brand where c_id=" + parents + ") as cname ";
            }
            else
            {
                _dzd = " *  ";
            }
            DataTable dt = B2C_brand.GetList(_dzd, _sql);

            #region 获取大类数据
            string str = "";
            str += @"<table>";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th  >名称</th>";
            str += @"        <th  >排序</th>";
            str += @"        <th  >图片</th>";
            str += @"        <th  >操作</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["c_id"] + "\"></td>";
                str += @"          <td ><a href='?level=" + (Convert.ToInt32(dr["c_level"]) + 1) + "&parent=" + dr["c_id"] + "'>" + dr["c_name"] + "</a></td>";
                str += @"          <td >" + dr["c_sort"] + "</td>";
                str += @"          <td >" + (string.IsNullOrEmpty(dr["c_gif"].ToString()) ? "" : "<img src='" + dr["c_gif"].ToString().Trim() + "' border='0' width='90' />") + "</td>";
                str += @"          <td ><a href='B2C_brand_Add.aspx?id=" + dr["c_id"] + "'><img width=\"20\" height=\"20\"  src=\"/man/images4/Icon_xiugai.png\"></a> </td>";
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
                string _sql = "select * from B2C_Goods;"; // where cityid=" + Session["wID"].ToString() + "
                _sql += "select * from B2C_brand where c_id in (" + delid + ");"; //where cityid=" + Session["wID"].ToString() + " and
                Dictionary<string, string> _dic = new Dictionary<string, string>();
                DataSet ds = comfun.GetDataSetBySQL(_sql);
                DataTable _dt1 = ds.Tables[0];
                foreach (DataRow dr in _dt1.Rows)
                {
                    if (!_dic.Keys.Contains<string>(dr["bno"].ToString()))
                        _dic.Add(dr["bno"].ToString(), dr["g_name"].ToString());
                }

                DataTable _dt2 = ds.Tables[1];
                foreach (DataRow dr in _dt2.Rows)
                {
                    if (_dic.Keys.Contains<string>(dr["c_no"].ToString()))
                    {
                        lt_result.Text = "选中项-" + dr["c_name"].ToString() + "下包含产品内容，无法删除！";
                        return;
                    }
                }
                string _del = "delete from B2C_brand where c_id in (" + delid + ")";
                try
                {
                    comfun.DelbySQL(_del);
                    commonTool.Show_Have_Url(lt_result, "已彻底删除！", "B2C_brand_List.aspx", 0);
                }
                catch (Exception ex)
                {
                    commonTool.Show_Have_Url(lt_result, "彻底删除失败！", "", 1);
                }
            }
            else
            {
                commonTool.Show_Have_Url(lt_result, "请选择需要彻底删除的行！", "", 1);
            }
        }
        #endregion

    }
}