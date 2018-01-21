using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;

namespace tdx.memb.man.vipmemb
{
    public partial class PeopleEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    int _id = Convert.ToInt32(Request["id"].ToString());
                    B2C_PeopleInfo b2c_people = new B2C_PeopleInfo(_id, 1);
                    wwv.Value = b2c_people.wwv;
                    nicheng.Value = b2c_people.nicheng;
                    fakeID.Value = b2c_people.fakeID;
                    weiName.Value = b2c_people.weiName;
                    xingbie.Value = b2c_people.xingbie;
                    shengfen.Value = b2c_people.shengfen;
                    chengshi.Value = b2c_people.chengshi;
                    touxiang.Disabled = true;
                    m_ph.Src = b2c_people.touxiang;
                    guanzhutime.Value = b2c_people.guanzhutime;
                    yuyan.Value = b2c_people.yuyan;
                }
            }
        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                try
                {
                    if (wwv.Value == "" && nicheng.Value == "")
                    {
                        Response.Write("<script language='javascript'>alert('必填项不能为空!');</script>");
                        return;
                    }
                    else
                    {
                        int _id = Convert.ToInt32(Request["id"].ToString());
                        B2C_PeopleInfo _info = new B2C_PeopleInfo(_id, 1);
                        _info.wwv = wwv.Value;
                        _info.nicheng = nicheng.Value;
                        _info.fakeID = fakeID.Value;
                        _info.weiName = weiName.Value;
                        _info.xingbie = xingbie.Value;
                        _info.shengfen = shengfen.Value;
                        _info.chengshi = chengshi.Value;
                        _info.guanzhutime = guanzhutime.Value;
                        _info.yuyan = yuyan.Value;
                        _info.Update();
                        Response.Write("<script language='javascript'>alert('修改成功！');location.href='VIPUser.aspx';</script>");
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                B2C_PeopleInfo _info = new B2C_PeopleInfo();
                if (wwv.Value == "" && nicheng.Value == "")
                {
                    Response.Write("<script language='javascript'>alert('必填项不能为空!');</script>");
                    return;
                }
                else
                {
                    _info.wwv = wwv.Value;
                    _info.nicheng = nicheng.Value;
                    _info.fakeID = fakeID.Value;
                    _info.weiName = weiName.Value;
                    _info.xingbie = xingbie.Value;
                    _info.shengfen = shengfen.Value;
                    _info.chengshi = chengshi.Value;
                    _info.touxiang = m_ph.Src;
                    _info.guanzhutime = guanzhutime.Value;
                    _info.yuyan = yuyan.Value;
                    _info.Update();
                    Response.Write("<script language='javascript'>alert('alert('增加个人信息成功！');history.go(-1);</script>");
                }

            }
        }
    }
}