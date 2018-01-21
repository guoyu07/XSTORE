using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;

namespace tdx.memb.man.weixinmoni
{
    public partial class weixinUserEdit : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null && Session["wid"] != null)
                { //编辑
                    wx_userInfo _wu = new wx_userInfo(Request["id"].ToString(), Convert.ToInt32(Session["wid"]));
                    weixin_nichen.Value = _wu.nick_name;
                    weixin_id.Value = _wu.weixinID;
                    gropName.Value = _wu.group_name;
                    remark_Name.Value = _wu.remark_name;
                }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null && Session["wid"] != null)
            {
                try
                {
                    //编辑
                    wx_userInfo _wu = new wx_userInfo(Request["id"].ToString(), Convert.ToInt32(Session["wid"]));
                    _wu.weixinID = weixin_id.Value;
                    _wu.Update();
                    Response.Write("<script language='javascript'>alert('修改成功！');location.href='weixinUserList.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='javascript'>alert('修改失败！');location.href='weixinUserList.aspx';</script>");
                }
            }
        }
    }
}