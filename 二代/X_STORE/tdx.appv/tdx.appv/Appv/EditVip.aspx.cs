using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using System.Data;
using tdx.database;
using Creatrue.Common;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class EditVip : weixinAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Request["WWV"] != null)
                {
                    string _sql = "top 1 *";
                    string _where = string.Format(" M_card='{0}' and cityID={1} order by id desc", Request["WWV"].ToString(), Session["wID"].ToString());
                    DataTable dt = B2C_mem.GetList(_sql, _where);
                    if (dt.Rows.Count > 0)
                    {
                        M_name.Value = dt.Rows[0]["M_name"].ToString();
                        M_mobile.Value = dt.Rows[0]["M_mobile"].ToString();
                        M_mail.Value = dt.Rows[0]["M_email"].ToString();
                        //M_CarNo.Value = dt.Rows[0]["M_CarNo"].ToString();

                        string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                        string[] _tdxWeixinArry = _tdxWeixin.Split('|');
                        lt_title.Text = _tdxWeixinArry[1];
                    }
                }
                else if (Session["WWV"] != null)
                {
                    string _sql = "top 1 *";
                    string _where = string.Format(" M_card='{0}' and cityID={1} order by id desc", Session["WWV"].ToString(), Session["wID"].ToString());
                    DataTable dt = B2C_mem.GetList(_sql, _where);
                    if (dt.Rows.Count > 0)
                    {
                        M_name.Value = dt.Rows[0]["M_name"].ToString();
                        M_mobile.Value = dt.Rows[0]["M_mobile"].ToString();
                        M_mail.Value = dt.Rows[0]["M_email"].ToString();
                        //M_CarNo.Value = dt.Rows[0]["M_CarNo"].ToString();
                    }
                }
                else if (Request.Cookies["tdxVIP"] != null && Request.Cookies["tdxVIP"]["vipID"] != null)
                {
                    int _id = Convert.ToInt32(Request.Cookies["tdxVIP"]["vipID"].ToString());
                    string _sql = "*";
                    string _where = string.Format(" id={0}", _id);
                    DataTable dt = B2C_mem.GetList(_sql, _where);
                    if (dt.Rows.Count > 0)
                    {
                        M_name.Value = dt.Rows[0]["M_name"].ToString();
                        M_mobile.Value = dt.Rows[0]["M_mobile"].ToString();
                        M_mail.Value = dt.Rows[0]["M_email"].ToString();
                        //M_CarNo.Value = dt.Rows[0]["M_CarNo"].ToString();
                    }
                }
            }
		}


        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (Request["WWV"] != null || Session["WWV"] != null)
                {
                    string _sql = "top 1 *";
                    string _where = "";
                    string m_Card = "";
                    if (Request["WWV"] != null)
                    {
                        m_Card = Request["WWV"].ToString();
                        _where = string.Format(" M_card='{0}' and cityID={1} ", Request["WWV"].ToString(), Session["wID"].ToString());
                    }
                    else
                    {
                        m_Card = Session["WWV"].ToString();
                        _where = string.Format(" M_card='{0}' and cityID={1} ", Session["WWV"].ToString(), Session["wID"].ToString());
                    }
                    if (M_name.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('用户名不能为空！');</script>");
                        return;
                    }
                    else if (M_mobile.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('手机号不能为空！');</script>");
                        return;
                    }
                    else if (!commonTool.IsMobilePhone(M_mobile.Value))
                    {
                        Response.Write("<script language='javascript'>alert('手机号不合法！');</script>");
                        return;
                    }
                    else
                    {
                        DataTable dt = B2C_mem.GetList(_sql, _where);
                        B2C_mem b2c_mem;
                        int _id = 0;
                        if (dt.Rows.Count > 0)//编辑
                        {
                            _id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                            b2c_mem = new B2C_mem(_id);
                        }
                        else
                            b2c_mem = new B2C_mem();
                        b2c_mem.M_name = M_name.Value;
                        b2c_mem.M_mobile = M_mobile.Value;
                        b2c_mem.M_email = M_mail.Value;
                        b2c_mem.M_card = m_Card;
                        //b2c_mem.cityID = Convert.ToInt32(Session["wID"].ToString());
                        b2c_mem.Update();
                        HttpCookie cookie = new HttpCookie("tdxVIP");//初使化并设置Cookie的名称 
                        cookie.Expires = DateTime.Now.AddDays(1);//设置过期时间
                        if (b2c_mem.id == 0)
                        {
                            string _sql1 = "top 1 * ";
                            string _where1 = string.Format("cityID={0} order by id desc ", Session["wID"]);
                            DataTable dt1 = B2C_mem.GetList(_sql1, _where1);
                            int _id1 = Convert.ToInt32(dt1.Rows[0]["id"].ToString());
                            B2C_rankinfo.OpenCard(_id1);//, Convert.ToInt32(Session["wID"].ToString())
                            cookie.Values.Add("vipID", _id1.ToString());
                            cookie.Values.Add("vipName", HttpUtility.UrlEncode(M_name.Value));
                            Response.AppendCookie(cookie);
                            Response.Write(string.Format("<script language='javascript'>alert('添加会员成功！');location.href='vipCard.aspx?WWX={0}&WWV={1}';</script>", Request["WWX"].ToString(), m_Card));
                        }
                        else
                        {
                            cookie.Values.Add("vipID", _id.ToString());
                            cookie.Values.Add("vipName", HttpUtility.UrlEncode(M_name.Value));
                            Response.AppendCookie(cookie);
                            Response.Write(string.Format("<script language='javascript'>alert('编辑成功！');location.href='vipCard.aspx?WWX={0}&WWV={1}';</script>", Request["WWX"].ToString(), m_Card));
                        }
                    }
                }
                else if (Request.Cookies["tdxVIP"] != null)//缓存中存在
                {
                    int _id = Convert.ToInt32(Request.Cookies["tdxVIP"]["vipID"].ToString());
                    if (M_name.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('用户名不能为空！');</script>");
                        return;
                    }
                    else if (M_mobile.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('手机号不能为空！');</script>");
                        return;
                    }
                    else if (!commonTool.IsMobilePhone(M_mobile.Value))
                    {
                        Response.Write("<script language='javascript'>alert('手机号不合法！');</script>");
                        return;
                    }
                    else
                    {
                        string _vip_sql = "top 1 *";
                        string _vip_where = " id=" + _id.ToString();
                        DataTable _vip_tab = B2C_mem.GetList(_vip_sql, _vip_where);
                        B2C_mem b2c_mem;
                        if (_vip_tab.Rows.Count > 0)
                            b2c_mem = new B2C_mem(_id);
                        else
                            b2c_mem = new B2C_mem();
                        b2c_mem.M_name = M_name.Value;
                        b2c_mem.M_mobile = M_mobile.Value;
                        b2c_mem.M_email = M_mail.Value;
                        //b2c_mem.cityID = Convert.ToInt32(Session["wID"].ToString());
                        b2c_mem.Update();
                        HttpCookie cookie = new HttpCookie("tdxVIP");//初使化并设置Cookie的名称 
                        cookie.Expires = DateTime.Now.AddDays(1);//设置过期时间
                        if (b2c_mem.id == 0)
                        { //添加模式，cookie存入添加id
                            string _sql = "top 1 * ";
                            string _where = string.Format("cityID={0} order by id desc ", Session["wID"].ToString());
                            DataTable dt = B2C_mem.GetList(_sql, _where);
                            int _id2 = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                            cookie.Values.Add("vipID", _id2.ToString());
                            cookie.Values.Add("vipName", HttpUtility.UrlEncode(M_name.Value));
                            B2C_rankinfo.OpenCard(_id2);//, Convert.ToInt32(Session["wID"].ToString())
                            Response.Write(string.Format("<script language='javascript'>alert('添加会员成功！');location.href='vipCard.aspx?WWX={0}';</script>", Request["WWX"].ToString()));
                        }
                        else
                        {
                            //编辑模式
                            cookie.Values.Add("vipID", _id.ToString());
                            cookie.Values.Add("vipName", HttpUtility.UrlEncode(M_name.Value));
                            Response.Write(string.Format("<script language='javascript'>alert('编辑成功！');location.href='vipCard.aspx?WWX={0}';</script>", Request["WWX"].ToString()));
                        }
                        Response.AppendCookie(cookie);
                    }
                }
                else  //添加会员
                {
                    if (M_name.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('用户名不能为空！');</script>");
                        return;
                    }
                    else if (M_mobile.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('手机号不能为空！');</script>");
                        return;
                    }
                    else if (!commonTool.IsMobilePhone(M_mobile.Value))
                    {
                        Response.Write("<script language='javascript'>alert('手机号不合法！');</script>");
                        return;
                    }
                    else
                    {
                        B2C_mem b2c_mem = new B2C_mem();
                        b2c_mem.M_name = M_name.Value;
                        b2c_mem.M_mobile = M_mobile.Value;
                        b2c_mem.M_email = M_mail.Value;
                        //b2c_mem.cityID = Convert.ToInt32(Session["wID"].ToString());

                        b2c_mem.Update();
                        string _sql = "top 1 * ";
                        string _where = string.Format("cityID={0} order by id desc ", Session["wID"]);
                        DataTable dt = B2C_mem.GetList(_sql, _where);
                        int _id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                        B2C_rankinfo.OpenCard(_id);//, Convert.ToInt32(Session["wID"].ToString())
                        HttpCookie cookie = new HttpCookie("tdxVIP");//初使化并设置Cookie的名称 
                        cookie.Expires = DateTime.Now.AddDays(1);//设置过期时间
                        cookie.Values.Add("vipID", _id.ToString());
                        cookie.Values.Add("vipName", HttpUtility.UrlEncode(M_name.Value));
                        Response.AppendCookie(cookie);
                        Response.Write(string.Format("<script language='javascript'>alert('添加会员成功！');location.href='vipCard.aspx?WWX={0}';</script>", Request["WWX"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
	}
}