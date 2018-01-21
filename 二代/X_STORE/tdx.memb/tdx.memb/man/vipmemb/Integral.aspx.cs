using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class Integral : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["wid"] != null)
                {
                    int wid = Convert.ToInt32(Session["wid"]);
                    string _sql = "*";
                    string _where = "wid=" + wid + " and isdel<>1 and category=1";
                    DataTable dt = B2C_wallet.GetList(_sql, _where);
                    string result1 = "";
                    if (dt.Rows.Count > 0)
                    {
                        result1 += "\r\n";
                        result1 += " \r\n <table >";
                        result1 += " \r\n <tbody>";
                        result1 += "\r\n <tr>";
                        result1 += "\r\n <th ><input name=\"delAll\" id=\"delAll\" onclick=\"this.value=checkAll(form1.delbox,this);\" type=\"checkbox\" /><label for=\"delAll\">全选</label></th> ";
                        result1 += "\r\n <th >充值还是消费</th> ";
                        result1 += "\r\n <th >产生的费用</th> ";
                        result1 += "\r\n <th >赠送的费用</th> ";
                        result1 += " \r\n <th >是否累加</th> ";
                        result1 += " \r\n <th >分类</th> ";
                        result1 += " \r\n <th >应用等级</th> ";//默认普通等级
                        result1 += " \r\n <th >创建时间</th> ";
                        result1 += " \r\n <th >修改</th> ";
                        result1 += " \r\n </tr>";
                        B2C_rankinfo _br;
                        foreach (DataRow dr in dt.Rows)
                        {
                            result1 += " \r\n <tr>";
                            result1 += "\r\n <td><input name='delbox' value='" + dr["id"] + "' type='checkbox'/></td> ";
                            if (Convert.ToInt32(dr["payorcost"]) == 1)
                            { //默认1充值-1消费
                                result1 += " \r\n  <td>充值</td> ";
                            }
                            else if (Convert.ToInt32(dr["payorcost"]) == -1)
                            {
                                result1 += " \r\n  <td >消费</td> ";
                            }
                            else
                            {
                                result1 += " \r\n  <td ></td> ";
                            }
                            result1 += " \r\n  <td >" + Convert.ToDouble(dr["amount"]).ToString("F2") + "</td> ";
                            if (Convert.ToInt32(dr["is_fandian"]) == 0)
                            {
                                result1 += " \r\n  <td >" + Convert.ToDouble(dr["give_amount"]).ToString("F2") + "</td> ";
                            }
                            else
                            {
                                result1 += " \r\n  <td >" + Convert.ToInt32(dr["give_amount"]).ToString() + "%</td> ";
                            }
                            if (Convert.ToInt32(dr["is_add"]) == 0)
                            {
                                result1 += " \r\n  <td >不累加</td> ";
                            }
                            else
                            {
                                result1 += " \r\n  <td >累加</td> ";
                            }
                            if (Convert.ToInt32(dr["category"]) == 2)
                            {
                                result1 += " \r\n  <td >钱包</td> ";
                            }
                            else if (Convert.ToInt32(dr["category"]) == 1)
                            {
                                result1 += " \r\n  <td >积分</td> ";
                            }
                            if (Convert.ToInt32(dr["rankid"]) == 1)
                            {
                                result1 += " \r\n  <td >未找到对应等级</td> ";
                            }
                            else
                            {
                                _br = new B2C_rankinfo(Convert.ToInt32(dr["rankid"]));
                                result1 += " \r\n  <td >" + _br.name + "</td> ";
                            }
                            result1 += " \r\n  <td >" + Convert.ToDateTime(dr["create_time"]).ToString("yyyy-MM-dd") + "</td> ";
                            result1 += " \r\n<td ><a href=\"" + "IntegralEdit.aspx?id=" + dr["id"].ToString() + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a></td>";
                            //result1 += " \r\n <input name='btn_save' runat='server' onserverclick='btn_Delete' id='btn_" + dr["id"].ToString() + "' value=' 删 除 ' class='btnGreen' type='button' />";
                            result1 += " \r\n </tr>";
                        }
                        result1 += " \r\n </tbody>";
                        result1 += " \r\n </table>";
                        ylList.Text = result1;
                    }
                }
            }
        }
        protected void delIntegral(object sender, EventArgs e)
        {
            if (Request["delbox"] != null)
            {
                try
                {
                    string delbox = Request["delbox"].ToString();//找到所有选中项的value
                    B2C_wallet.delete(delbox);
                    commonTool.Show_Have_Url(lt_result, "删除成功！", "Integral.aspx", 0);

                }
                catch (Exception ex)
                {
                    commonTool.Show_Have_Url(lt_result, "删除失败！", "", 1);

                }
            }
            else
            {
                commonTool.Show_Have_Url(lt_result, "请选择要删除的数据！", "", 1);
            }
        }
    }
}