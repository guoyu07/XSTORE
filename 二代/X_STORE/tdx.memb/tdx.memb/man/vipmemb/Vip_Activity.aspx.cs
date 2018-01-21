using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.Common;
using Creatrue.kernel;

namespace tdx.memb.man.vipmemb
{
    public partial class Vip_Activity : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>配置您的微信会员卡活动。";

                int _wid = Convert.ToInt32(Session["wid"]);
                int _id = 0;
                string _sql = "*";
                string _infoWhere = string.Format("wid={0}", _wid);
                DataTable dt_Info = B2C_vipcard.GetList(_sql, _infoWhere);
                if (dt_Info.Rows.Count > 0)
                    _id = Convert.ToInt32(dt_Info.Rows[0]["id"]);
                string _where = string.Format(" cardid={0}", _id);
                DataTable dt = B2C_card_action.GetList(_sql, _where);
                string result1 = "";
                if (dt.Rows.Count > 0)
                {
                    result1 += "\r\n";
                    result1 += " \r\n <table >";
                    result1 += " \r\n <tbody>";
                    result1 += "\r\n <tr>";
                    result1 += "\r\n <th ><input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\" /><label for=\"delAll\">全选</label></th> ";
                    result1 += "\r\n <th >活动名称</th> ";
                    result1 += "\r\n <th >长期有效</th> ";
                    result1 += "\r\n <th>状态</th> ";
                    result1 += " \r\n <th>编辑</th> ";
                    result1 += " \r\n </tr>";
                    //B2C_AccOperate b2c_acc = new B2C_AccOperate();
                    foreach (DataRow dr in dt.Rows)
                    {
                        result1 += " \r\n <tr>";
                        result1 += "\r\n <td ><input name='delbox' value='" + dr["id"] + "' type='checkbox'/></td> ";
                        //result1 += " \r\n <td align=\"left\" height=\"100\"> <input name=\"delbox\" value=\"" + dr["id"].ToString() + "\" type=\"checkbox\"></td> ";
                        result1 += " \r\n <td >" + dr["name"].ToString() + "</td> ";
                        if (dr["is_long"].ToString() == "1")
                        {
                            result1 += " \r\n  <td >" + "长期有效" + "</td> ";
                            result1 += " \r\n  <td >" + "已生效" + "</td> ";
                        }
                        else
                        {
                            result1 += " \r\n  <td >" + "否" + "</td> ";
                            if (Convert.ToDateTime(dr["star_time"].ToString()) > DateTime.Now || Convert.ToDateTime(dr["end_time"].ToString()) < DateTime.Now)
                            {
                                result1 += " \r\n  <td >" + "未生效" + "</td> ";
                            }
                            else
                            {
                                result1 += " \r\n  <td >" + "已生效" + "</td> ";
                            }
                        }
                        result1 += " \r\n<td ><a href=\"" + "Edit_Activity.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                        result1 += " \r\n </tr>";
                    }
                    result1 += " \r\n </tbody>";
                    result1 += " \r\n </table>";
                    ylList.Text = result1;
                }
            }
        }

        protected void delActivity_Click(object sender, EventArgs e)
        {
            if (Request["delbox"] != null)
            {
                try
                {
                    string delbox = Request["delbox"].ToString();
                    string _where = "1=1 order by id";
                    DataTable dt = B2C_card_action.GetList("top 1 *", _where);
                    string _sql = "delete from B2C_card_action where id in(" + Request["delbox"] + ")";
                    comfun.DelbySQL(_sql);
                    commonTool.Show_Have_Url(lt_result, "删除成功！", "Vip_Activity.aspx", 0);
                }
                catch (Exception ex)
                {
                    commonTool.Show_Have_Url(lt_result, "删除出现异常,删除失败！", "", 1);

                }

            }
            else
            {
                commonTool.Show_Have_Url(lt_result, "请选择要删除的记录！", "", 1);
            }
        }
    }
}