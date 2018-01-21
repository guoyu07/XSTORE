using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;
using System.Text.RegularExpressions;
using Creatrue.Common;

namespace tdx.memb.man.Sets
{
    public partial class wx_mp_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小提示：</span> 这里有您已绑定的所有微信公众号信息。您可以在此绑定新的公众号，也可以修改或删除老的公众号。";
                    lt_friendly.Text += "<br/>可以设置您的微信公众号各种功能，如：关注回复、关键词回复、公众号菜单等等。";
                    lt_friendly.Text += "<br/><span class='tipsTitle'>特别提醒：</span>您可以将多个公众号绑定在同一个微网站上";
                    string sql = "(1=1)";
                    lb_prolist.Text = prolist();
                    lb_cateadd.Text = "<input type=\"button\"  value=\"绑定新公众号\" class=\"btnAdd\" onclick=\"location.href='wx_mp_Add.aspx';\"/>";
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/Sets/wx_mp_list.cs", Session["wid"].ToString());
                }
            }
        }
        private string prolist()
        {
            string str = "";
            try
            {

                str += @"<table>";
                str += @"        <tr>";
                str += "           <th align=center><input type=checkbox  name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";//style=\" clear:both; width:20px;\"
                str += @"          <th height=""25"" align=center >类型</th>";
                str += @"          <th align=center >微信号</th>";
                str += @"          <th align=center >昵称</th>";
                str += @"          <th align=center >原始号</th>";
                str += @"          <th align=center >二维码</th>";
                str += @"          <th align=center >描述</th>";
                str += @"          <th align=center  >功能</th>";
                str += @"        </tr>";
                str += @"        ";


                DataTable dt = wx_mp.GetWxList(Convert.ToInt32(Session["wID"]));
                foreach (DataRow dr in dt.Rows)
                {
                    str += @"        <tr> ";
                    str += @"           <td > <input type=checkbox name=""delbox"" value=""" + dr["id"] + "\"> </td> ";
                    if (Convert.ToInt32(dr["wx_cid"]) == 3)
                        str += @"          <td>" + "认证服务号" + "</td>";
                    else if (Convert.ToInt32(dr["wx_cid"]) == 1)
                        str += @"          <td>" + "服务号" + "</td>";
                    else if (Convert.ToInt32(dr["wx_cid"]) == 2)
                        str += @"          <td>" + "认证订阅号" + "</td>";
                    else
                        str += @"          <td>" + "订阅号" + "</td>";
                    str += @"          <td>" + dr["wx_name"] + "</td>";
                    str += @"          <td>" + dr["wx_nichen"] + "</td>";
                    str += @"          <td>" + dr["wx_ID"] + "</td>";
                    str += @"          <td>" + (string.IsNullOrEmpty(dr["wx_2wm"].ToString()) ? "" : "<img src='" + dr["wx_2wm"].ToString() + "' border='0' width='90' />") + "</td>";
                    str += @"          <td>" + dr["wx_des"] + "</td>";
                    str += "          <td><a href=\"wx_mp_Add.aspx?id=" + dr["id"] + "\"><img width=\"20\" height=\"20\" src=\"/man/images4/Icon_xiugai.png\"></a>";
                    if (Convert.ToInt32(dr["wx_cid"]) > 0)
                    {
                        str += "          <br /><a href=\"/man/Sets/B2C_menu2_list.aspx?wid=" + dr["id"] + "\">菜单设置</a>";
                    }
                    str += "          <br /><a href=\"/man/Ads/Welcome_Ads_Edit.aspx?wid=" + dr["id"] + "\">关注回复</a>";
                    str += "          <br /><a href=\"/man/Texts/wx_keys_List.aspx?wid=" + dr["id"] + "\">关键词回复</a>";
                    str += "          <br /><a href=\"/man/Ads/B2C_MoRen_Edit.aspx?wid=" + dr["id"] + "\">默认回复</a>";
                    str += "</td>";
                    str += @"        </tr>";
                }
                str += @"</div>";
                str += @"      </table>";
                return str;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Sets/wx_mp_list.cs", Session["wid"].ToString());
                return str;
            }
        }
        #region  功能按钮

        /// <summary>
        /// 彻底删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delBtn_Click(object sender, EventArgs e)
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
                            wx_mp.Delete(id);
                            commonTool.Show_Have_Url(lt_result, "彻底删除成功！", "wx_mp_List.aspx", 0);
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},300);</script>";
                        }
                        catch (Exception ex)
                        {

                            lt_result.Text = "彻底删除失败！";
                        }
                    }
                }
                else
                {
                    //Response.Write("<script language='javascript'>alert('请选择需要彻底删除的行！');history.go(-1);</script>");
                    lt_result.Text = "请选择需要删除的记录！";
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Sets/wx_mp_list.cs", Session["wid"].ToString());
            }
        }

        #endregion

    }
}