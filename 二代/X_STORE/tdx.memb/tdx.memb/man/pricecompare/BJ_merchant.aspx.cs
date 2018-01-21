using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.Common;
using Creatrue.kernel;
using tdx.database;
using System.Data;

namespace tdx.memb.man.pricecompare
{
    public partial class BJ_merchant : workAuth
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
                    DataTable dt = BJ_obj.GetList(_sql, _where);
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table >";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <th ><input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\" /><label for=\"delAll\">全选</label></th> ";
                        result1 += "\r\n <th >商城名称</th> ";
                        result1 += "\r\n <th></th> ";
                        result1 += " \r\n </tr>";
                        foreach (DataRow dr in dt.Rows)
                        {
                            result1 += " \r\n <tr>";
                            result1 += "\r\n <td ><input name='delbox' value='" + dr["id"] + "' type='checkbox'/></td> ";
                            result1 += " \r\n  <td >" + dr["name"].ToString() + "</td> ";
                            result1 += " \r\n<td ><a href=\"" + "BJ_merchantEdit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
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
                    string _sql = "delete from BJ_value where obj_id in(" + delbox + ");";
                    _sql += "delete from BJ_obj where id in(" + delbox + ")";
                    comfun.DelbySQL(_sql);
                    commonTool.Show_Have_Url(lt_result, "删除成功！", "BJ_merchant.aspx", 0);
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