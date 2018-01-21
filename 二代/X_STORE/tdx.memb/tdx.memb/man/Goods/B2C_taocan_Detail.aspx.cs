using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using System.Data;
using tdx.database;

namespace tdx.memb.man.Goods
{
    public partial class B2C_taocan_Detail : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 在这里，管理您的套餐产品信息";

                    string _pid = Request["pid"] != null ? Request["pid"].ToString().Trim() : "0";
                    if (_pid == "0")
                    {
                        lt_result.Text = "您还未指定套餐产品！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_taocan_List.aspx';},300);</script>";
                        return;
                    }
                    //                            cityid=" + Session["wID"].ToString().Trim() + " AND 
                    //lb_catelist.Text = ClassList(" (select g_childs from b2c_goods where id=" + _pid + ") like ('%,'+ cast(id as varchar(8)) +',%')");
                    lb_catelist.Text = ClassList(_pid);

                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/Goods/B2C_taocan_List.cs", Session["wID"].ToString());
                }
            }
        }

        #region 读取数据
        protected string ClassList(string _pid)
        { //                                                                                                                    and cityid=" + Session["wID"].ToString().Trim() + "
            //string ssql = "select * from b2c_goods where id='"+_pid+"'";
            //DataTable dts = comfun.GetDataTableBySQL(ssql);
          //  string g_childs = dts.Rows[0]["g_childs"].ToString();
          //string sql="";
          //  if (_pid.Equals(g_childs))
          //  {
            string sql = "select * from b2c_goods where g_childs='" + _pid + "' ";
            //or id='" + dts.Rows[0]["id"].ToString() + "'";

            //}
            //else
            //{
            // sql = "select * from b2c_goods where g_childs='" + g_childs + "' or id='"+ g_childs +"'";
            //}
            DataTable dt=comfun.GetDataTableBySQL(sql);
          
            //string _br = "select * from B2C_brand"; // where cityid=" + Session["wID"].ToString().Trim()
            //DataTable dt_br = comfun.GetDataTableBySQL(_br);
            //Dictionary<string, string> _dic = new Dictionary<string, string>();
            //foreach (DataRow dr in dt_br.Rows)
            //{
            //    _dic.Add(dr["c_no"].ToString(), dr["c_name"].ToString());
            //}
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
            str += @"        <th>名称</th>";
            str += @"        <th >单位</th>";
            str += @"        <th >图片</th>";
            str += @"        <th >价格</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["g_name"] + "</td>";
                str += @"          <td >" + dr["g_unit"] + "</td>";
                str += @"          <td >" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "" : "<image src='" + dr["g_gif"].ToString().Replace("all", "min") + "' width='60 height='60'/>") + "</td>";
                str += @"          <td >" + Convert.ToDouble(Creatrue.Common.commonTool.GetMoney(dr["g_price_s"].ToString())).ToString("f2") + "</td>";
                str += @"        </tr>";
            }
            str += @"</table>";
            return str;
        }

        protected string ClassList2(string _sql)
        {
            //                                                                                                                and cityid=" + Session["wID"].ToString().Trim() + "
            string sql = "with c as (select row_number() over(order by g_wdate desc) as rown, *,(select top(1) c_name from b2c_category where c_no=cno order by c_id desc) as cname from B2C_Goods where 1=1 and " + _sql + " and g_buytype<>'3') select * from c order by rown";
            DataTable dt = comfun.GetDataTableBySQL(sql);
            string _br = "select * from B2C_brand"; // where cityid=" + Session["wID"].ToString().Trim()
            //DataTable dt_br = comfun.GetDataTableBySQL(_br);
            //Dictionary<string, string> _dic = new Dictionary<string, string>();
            //foreach (DataRow dr in dt_br.Rows)
            //{
            //    _dic.Add(dr["c_no"].ToString(), dr["c_name"].ToString());
            //}
            string str = "";
            str += @"<table >";
            str += @"       <tr>";
            str += "        <th ><input type=\"checkbox\" name=\"delAll2\" id=\"delAll2\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox2,this);\" />全选</th>";
            str += @"        <th>名称</th>";
            str += @"        <th >单位</th>";
            str += @"        <th >图片</th>";
            str += @"        <th >价格</th>";
            str += @"       </tr>";
            foreach (DataRow dr in dt.Rows)
            {
                str += @"        <tr>";
                str += @"          <td ><input type=checkbox name=""delbox2"" class=""btn""  value=""" + dr["id"] + "\"></td>";
                str += @"          <td >" + dr["g_name"] + "</td>";
                str += @"          <td >" + dr["g_unit"] + "</td>";
                str += @"          <td >" + (string.IsNullOrEmpty(dr["g_gif"].ToString()) ? "" : "<image src='" + dr["g_gif"].ToString().Replace("all", "min") + "' width='60 height='60'/>") + "</td>";
                str += @"          <td >" + Convert.ToDouble(Creatrue.Common.commonTool.GetMoney(dr["g_price_s"].ToString())).ToString("f2") + "</td>";
                str += @"        </tr>";
            }
            str += @"</table>";
            return str;
        }
        #endregion


        //搜索
        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            string _pid = Request["pid"] != null ? Request["pid"].ToString().Trim() : "0";
            if (_pid == "0")
            {
                lt_result.Text = "您还未指定套餐产品！";
                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_taocan_List.aspx';},300);</script>";
                return;
            }
            //收集参数
            try
            {
                string keyword = ss_keyword.Value.Trim();
                string sql = "  g_name like '%" + keyword + "%' and bno<>''"; // cityid=" + Session["wID"].ToString().Trim() + " and
                lb_catelist2.Text = ClassList2(sql);
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_taocan_List.cs", Session["wID"].ToString());
            }
        }

        #region 彻底删除
        protected void delBtn_Click(object sender, EventArgs e)
        {
            string _pid = Request["pid"] != null ? Request["pid"].ToString().Trim() : "0";
            if (_pid == "0")
            {
                lt_result.Text = "您还未指定套餐产品！";
                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_taocan_List.aspx';},300);</script>";
                return;
            }
            try
            {
                string delid = "0";
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    try
                    {
                        string sql = "";//update B2C_Goods set g_parent=0 where id in (" + delid + ")";
                        string[] delidArry = delid.Split(',');
                        foreach (string _delid in delidArry)
                        {
                            sql += ";\r\n update b2c_goods set g_childs =NULL where id in(" + delid+")";
                        }
                        int i = comfun.UpdateBySQL(sql);
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = "取消打包失败！";
                    }
                    lt_result.Text = "取消打包成功！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_taocan_detail.aspx?pid=" + _pid + "';},300);</script>";
                }
                else
                {
                    lt_result.Text = "请选择需要取消打包的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_taocan_List.cs", Session["wID"].ToString());
            }
        }
        #endregion

        #region "添加进套餐"
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string _pid = Request["pid"] != null ? Request["pid"].ToString().Trim() : "0";
            if (_pid == "0")
            {
                lt_result.Text = "您还未指定套餐产品！";
                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_taocan_List.aspx';},300);</script>";
                return;
            }
            try
            {
                string delid = "0";
                if (Request["delbox2"] != null)
                {
                    delid = Request["delbox2"].ToString();
                    string sql = "update B2C_Goods set g_childs= '" + _pid + "' where id in (" + delid+")";

                    try
                    {
                        int i = comfun.UpdateBySQL(sql);

                        lt_result.Text = "加入套餐成功！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_taocan_detail.aspx?pid=" + _pid + "';},300);</script>";
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = "加入套餐失败！" + sql + ex.Message;
                    }

                }
                else
                {
                    lt_result.Text = "请选择需要加入套餐的行！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Goods/B2C_taocan_List.cs", Session["wID"].ToString());
            }
        }
        #endregion
    }
}