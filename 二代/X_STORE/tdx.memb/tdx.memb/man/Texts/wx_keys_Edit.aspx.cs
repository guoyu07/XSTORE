using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using tdx.database;
using System.Text;
using Creatrue.kernel;

namespace tdx.memb.man.Texts
{
    public partial class wx_keys_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _guid = (Request["guid"] != null ? Convert.ToString(Request["guid"]) : "");

                if (string.IsNullOrEmpty(_guid))
                {
                    Response.Write("<script language='javascript'>alert('非法进入');location.href='../main.aspx';</script>");
                    return;
                }
                else
                {
                    try
                    {
                        string _sql = "guid='" + _guid + "' order by k_sort asc";
                        DataTable dt = wx_keys.GetList("*", _sql);
                        if (dt.Rows.Count == 0)
                        {
                            Response.Write("<script language='javascript'>alert('非法进入');location.href='../main.aspx';</script>");
                            return;
                        }
                        else
                        {
                            getHtml(dt);
                            //处理显示
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script language='javascript'>alert('错误:" + ex.Message + "');location.href='../main.aspx';</script>");
                        return;
                    }
                }
            }
        }

        private void getHtml(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)/*说明是封面*/
                {
                    txt_gtitle.Value = dt.Rows[i]["k_words"].ToString();
                    hfwid.Value = dt.Rows[i]["cityID"].ToString();
                    hfGuid.Value = dt.Rows[i]["guid"].ToString();
                    str.Append("<div class=\"titlePageInfo\" id=\"titlePageInfo\">");
                    str.Append("<div class=\"imgTitle\">");
                    str.Append("<span>" + dt.Rows[i]["k_answer"].ToString() + "</span></div>");
                    str.Append("<div class=\"imgBg\"><img  src=\"" + dt.Rows[i]["k_image"].ToString() + "\" style=\"display:inline;\"/>");
                    str.Append("<span style=\"display:none;\">封面图片</span></div>");
                    str.Append("<div class=\"imgEidt\">");
                    str.Append("<a href=\"javascript:void(0)\" class=\"infoEdit\">编辑</a></div>");
                    str.Append("<div  name=\"hidden\" _title=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_answer"].ToString())
                        + "\" _pic=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_image"].ToString())
                        + "\" _author=\"\" _body_url=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_url2"].ToString())
                        + "\" _itemid=\"" + comfun.EnCodeHtml(dt.Rows[i]["id"].ToString())
                        + "\" _summary=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_des"].ToString())
                        + "\" class=\"hidden_body\">" + comfun.EnCodeHtml(dt.Rows[i]["k_content"].ToString())
                        + "</div></div>");

                }
                else
                {
                    str.Append("<div class=\"otherInfo\" id=\"otherItem" + i + "\">");
                    str.Append("<div class=\"imgBg\"><img  src=\"" + dt.Rows[i]["k_image"].ToString() + "\" style=\"display:inline;\"/>");
                    str.Append("<span style=\"display:none\">缩略图</span></div>");
                    str.Append("<div class=\"imgTitle\">");
                    str.Append("<span>" + dt.Rows[i]["k_answer"].ToString() + "</span></div>");
                    str.Append("<div class=\"imgEidt\">");
                    str.Append("<a href=\"javascript:void(0)\" class=\"infoEdit\">编辑</a><a href=\"javascript:void(0)\" class=\"infoDelete\">删除</a></div>");
                    str.Append("<div name=\"hidden\" _title=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_answer"].ToString()) +
                        "\" _pic=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_image"].ToString())
                        + "\" _author=\"\"  _body_url=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_url2"].ToString())
                        + "\" _itemid=\"" + comfun.EnCodeHtml(dt.Rows[i]["id"].ToString())
                        + "\"  _summary=\"" + comfun.EnCodeHtml(dt.Rows[i]["k_des"].ToString())
                        + "\" class=\"hidden_body\">" + comfun.EnCodeHtml(dt.Rows[i]["k_content"].ToString())
                        + "</div></div>");
                }
            }
            Literal1.Text = str.ToString();
        }
    }
}