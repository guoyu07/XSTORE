using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;

namespace tdx.memb.man.vipmemb
{
    public partial class Franchises : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>配置您的微信会员卡特权。";
                if (Session["wid"] != null)
                {
                    string _sql = "*";
                    string _where = "wid=" + Session["wid"];
                    int wid = Convert.ToInt32(Session["wid"]);
                    DataTable dt = B2C_group_fran.GetList(_sql, _where);
                    B2C_group_fran _bgf;
                    //如果dt的数据小于1.说明对应的公众号没有默认分组，添加一条默认分组
                    if (dt.Rows.Count < 1)
                    {
                        _bgf = new B2C_group_fran();
                        _bgf.create_time = DateTime.Now;
                        _bgf.name = "默认";
                        _bgf.wid = wid;
                        _bgf.Update();
                    }
                    //添加后再次查询分组信息
                    DataTable _fenzu = B2C_group_fran.GetList(_sql, _where);
                    _where = " group_id in(select id from B2C_group_fran where wid=" + wid + ")";
                    DataTable _tequan = B2C_Franchises.GetList(_sql, _where);
                    string result1 = "";
                    //如果有分组信息，查询和分组信息对应的特权
                    if (_fenzu.Rows.Count > 0 && _tequan.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table>";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "        <th ><input type=\"checkbox\" name=\"delAll\" id=\"delAll\" runat=\"server\" onclick=\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
                        result1 += "\r\n <th >特权名称</th> ";
                        result1 += "\r\n <th >特权分组</th> ";
                        //result1 += "\r\n <td align=\"center\">有效期</td> ";
                        result1 += "\r\n <th >创建时间</th> ";//默认普通等级
                        result1 += "\r\n <th >修改</th> ";
                        result1 += " \r\n </tr>";
                        foreach (DataRow dr in _tequan.Rows)
                        {
                            _where = "id in(select group_id from B2C_Franchises where id=" + dr["id"].ToString() + ")";
                            DataTable _item = B2C_group_fran.GetList(_sql, _where);
                            result1 += " \r\n <tr>";
                            result1 += "\r\n<td ><input type=checkbox name=\"delbox\" class=\"btn\"  value=\"" + dr["id"] + "\"></td>";
                            result1 += " \r\n  <td >" + dr["name"].ToString() + "</td> ";
                            if (_item.Rows.Count > 0)
                            {
                                result1 += " \r\n  <td>" + _item.Rows[0]["name"].ToString() + "</td> ";
                            }
                            //result1 += " \r\n  <td align=\"center\" height=\"24\">长期有效</td> ";
                            result1 += " \r\n  <td >" + Convert.ToDateTime(dr["create_time"]).ToString("yyyy-MM-dd") + "</td> ";
                            result1 += " \r\n<td ><a href=\"" + "FranchisesEdit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </tbody>";
                        result1 += " \r\n </table>";
                        ylList.Text = result1;
                    }
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            if (Request["delbox"] != null)
            {
                int i = 0;
                string _sql = "select * from B2C_Franchises where id in (" + Request["delbox"].ToString() + ")";
                DataTable dt = comfun.GetDataTableBySQL(_sql);
                if (Request["delbox"].ToString() != "")
                {
                    string[] delStr = Request["delbox"].ToString().Split(',');
                    foreach (string _id in delStr)
                    {
                        try
                        {
                            B2C_Franchises.MyDel(_id);
                            lt_result.Text += "特权--" + dt.Rows[i]["name"].ToString() + "删除成功！<br/>";
                        }
                        catch (Exception ex)
                        {
                            lt_result.Text += "特权--" + dt.Rows[i]["name"].ToString() + "删除失败！<br/>";
                        }
                        i++;
                    }

                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='Franchises.aspx';},1500);</script>";
                }
            }
            else
            {
                lt_result.Text = "请选择要删除的项！";
            }
        }
    }
}