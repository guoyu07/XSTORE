using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class Group_fran : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["wid"] != null)
                {
                    int wid = Convert.ToInt32(Session["wid"]);
                    string _sql = "*";
                    string _where = "wid=" + wid;
                    DataTable dt = B2C_group_fran.GetList(_sql, _where);
                    B2C_group_fran _bgf;
                    if (dt.Rows.Count < 1)
                    {
                        _bgf = new B2C_group_fran();
                        _bgf.create_time = DateTime.Now;
                        _bgf.name = "默认";
                        _bgf.wid = wid;
                        _bgf.Update();
                    }
                    dt = B2C_group_fran.GetList(_sql, _where);
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        //样式改动
                        result1 += " \r\n <table >";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <th> <input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\" /><label for=\"delAll\">全选</label></th> ";
                        result1 += "\r\n <th >分组名称</th> ";
                        result1 += "\r\n <th >创建时间</th> ";
                        result1 += "\r\n <th >修改</th> ";
                        result1 += " \r\n </tr>";
                        foreach (DataRow dr in dt.Rows)
                        {
                            result1 += " \r\n <tr>";
                            if (!dr["name"].ToString().Equals("默认"))
                            {
                                result1 += "\r\n <td ><input name='delbox' value='" + dr["id"] + "' type='checkbox'/></td> ";
                                result1 += " \r\n  <td >" + dr["name"].ToString() + "</td> ";
                                result1 += " \r\n  <td >" + Convert.ToDateTime(dr["create_time"]).ToString("yyyy-MM-dd") + "</td> ";
                                result1 += " \r\n<td ><a href=\"" + "Group_franEdit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                            }
                            else
                            {
                                result1 += "\r\n <td ></td> ";
                                result1 += " \r\n  <td >" + dr["name"].ToString() + "</td> ";
                                result1 += " \r\n  <td >" + Convert.ToDateTime(dr["create_time"]).ToString("yyyy-MM-dd") + "</td> ";
                                result1 += "\r\n  <td ></td>";
                            }
                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </tbody>";
                        result1 += " \r\n </table>";
                        ylList.Text = result1;
                    }
                }
            }
        }
        protected void delGroup(object sender, EventArgs e)
        {
            if (Request["delbox"] != null)
            {
                try
                {
                    string delbox = Request["delbox"].ToString();
                    string _where = "1=1 order by id";
                    DataTable dt = B2C_group_fran.GetList("top(1) *", _where);
                    if (dt.Rows.Count > 0)
                    {
                        string groupID = dt.Rows[0]["id"].ToString();
                        string _sql = "";// "update B2C_Franchises set group_id=" + groupID + " where group_id in(" + delbox + ");";
                        _sql += "delete from B2C_group_fran where id in(" + Request["delbox"] + ")";
                        comfun.DelbySQL(_sql);
                        commonTool.Show_Have_Url(lt_result, "删除成功！", "Group_fran.aspx", 0);
                    }
                }
                catch (Exception ex)
                {
                    commonTool.Show_Have_Url(lt_result, "删除失败！", "", 1);
                }

            }
            else
            {
                commonTool.Show_Have_Url(lt_result, "请选择修改数据！", "", 1);
            }
        }
    }
}