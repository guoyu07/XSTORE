using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.kernel;
using System.Data;
using System.Text;
using tdx.Weixin;

namespace tdx.memb.man.vipmemb
{
    public partial class VIPUser : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["wid"] != null)
                    {
                        getData();
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/VIPUser.cs", Session["wID"].ToString());
                }
            }
        }
        protected string getData(int isExcel = 0)
        {
            DataTable dt = new DataTable();
            StringBuilder sbexce = new StringBuilder();
            string _sql = "";
            string _where = "";
            int wid = Convert.ToInt32(Session["wid"]);
            if (sousuo_txt.Value == "" || sousuo_txt.Value.Trim() == "")
            {
                _sql = "*";
                _where = ""; //"cityID=" + wid
                dt = B2C_mem.GetList(_sql, _where);
            }
            else
            {
                _sql = "*";
                _where = ""; //"cityID=" + wid + " and "
                if (Request["select_sousuo"].ToString().Equals("会员名"))
                    _where += "where M_name like '%" + sousuo_txt.Value + "%'";//输入姓名查询
                if (Request["select_sousuo"].ToString().Equals("手机号"))
                    _where += "where M_mobile like '%" + sousuo_txt.Value + "%'  ";//输入手机号查询
                if (Request["select_sousuo"].ToString().Equals("原始号"))
                    _where += "where M_card like '%" + sousuo_txt.Value + "%' ";//输入原始号查询
                _where += " and 1=1";
                dt = B2C_mem.GetList(_sql, _where);
            }
            _where = "wid=" + wid;
            //找到公众号对应的充值日志信息
            DataTable _ca = B2C_AccOperate.GetList(_sql, _where);
            string result1 = "";
            B2C_user_rank _bur;
            B2C_AccOperate _ba;
            B2C_rankinfo _br;
            B2C_PeopleInfo _bp;
            if (dt.Rows.Count > 0)
            {
                result1 += "\r\n";
                result1 += " \r\n <table >";
                result1 += " \r\n <tbody>";
                result1 += "\r\n <tr>";
                sbexce.Append("会员列表\n");
                sbexce.Append("姓名,");
                result1 += "\r\n <th >姓名</th> ";
                sbexce.Append("原始ID,");
                result1 += "\r\n <th  >原始ID</th> ";
                if (Session["wID"] != null && Session["wID"].ToString() == "56")
                {
                    result1 += "\r\n <th  >BPID</th> ";
                    sbexce.Append("BPID,");
                    sbexce.Append("车架号,");
                    result1 += "\r\n <th >车架号</th> ";
                }
                sbexce.Append("手机号,");
                sbexce.Append("会员卡号,");
                sbexce.Append("昵称,");
                sbexce.Append("余额,");
                sbexce.Append("剩余积分,");
                sbexce.Append("领卡时间,");
                sbexce.Append("会员等级\n");
                result1 += "\r\n <th >手机号</th> ";
                result1 += "\r\n <th >会员卡号</th> ";
                result1 += "\r\n <th >昵称</th> ";
                result1 += " \r\n <th >余额</th> ";
                result1 += " \r\n <th >剩余积分</th> ";
                result1 += " \r\n <th >领卡时间</th> ";
                result1 += " \r\n <th >会员等级</th> ";
                result1 += " \r\n </tr>";
                foreach (DataRow dr in dt.Rows)
                {
                    _bur = new B2C_user_rank(dr["id"].ToString());
                    _ba = new B2C_AccOperate();
                    _br = new B2C_rankinfo(_bur.rankid);
                    _bp = new B2C_PeopleInfo(Convert.ToInt32(dr["id"].ToString()), 2);
                    result1 += " \r\n <tr>";
                    sbexce.Append(Convert.ToString(dr["M_name"]) + ",");
                    sbexce.Append(Convert.ToString(dr["M_card"]) + ",");
                    result1 += " \r\n  <td >" + Convert.ToString(dr["M_name"]) + "</td> ";
                    result1 += " \r\n  <td >" + Convert.ToString(dr["M_card"]) + "</td> ";
                    if (Session["wID"] != null && Session["wID"].ToString() == "56")
                    {
                        sbexce.Append(dr["M_DPID"].ToString() + ",");
                        sbexce.Append(dr["M_CarNo"].ToString() + ",");
                        result1 += " \r\n  <td >" + dr["M_DPID"].ToString() + "</td> ";
                        result1 += " \r\n  <td >" + dr["M_CarNo"].ToString() + "</td> ";
                    }
                    sbexce.Append(Convert.ToString(dr["M_mobile"]) + ",");
                    sbexce.Append(_bur.card_number + ",");
                    sbexce.Append(_bp.nicheng + ",");
                    result1 += " \r\n  <td >" + Convert.ToString(dr["M_mobile"]) + "</td> ";
                    result1 += " \r\n  <td >" + _bur.card_number + "</td> ";
                    result1 += "\r\n  <td >";
                    result1 += "<a href=\"../vipmemb/PeopleEdit.aspx?id=" + _bp.id.ToString() + "\" title=\"" + "昵称:" + _bp.nicheng + "\r\n微信号:" + _bp.wwv + "\r\nfakeID:" + _bp.fakeID + "\r\n微信名:" + _bp.weiName + "\r\n性别:" + _bp.xingbie + "\r\n身份:" + _bp.shengfen + "\r\n城市:" + _bp.chengshi + "\r\n关注时间:" + _bp.guanzhutime + "\r\n国家:" + _bp.yuyan + "\" >";
                    result1 += "<img runat=\"Server\" width=\"60\" id=\"m_ph\" src=\"" + _bp.touxiang + "\" /><br/>" + _bp.nicheng + "</a></td>";
                    sbexce.Append(B2C_AccOperate.Money(wid, Convert.ToInt32(dr["id"])) + ",");
                    sbexce.Append(B2C_AccOperate.JIFen(wid, Convert.ToInt32(dr["id"])) + ",");
                    result1 += _ba.GetMoney(wid, Convert.ToInt32(dr["id"]));
                    result1 += _ba.GetJiFen(wid, Convert.ToInt32(dr["id"]));
                    sbexce.Append(Convert.ToDateTime(dr["M_regtime"]).ToString("yyyy-MM-dd") + ",");
                    sbexce.Append(_br.name + "\n");
                    result1 += " \r\n  <td >" + Convert.ToDateTime(dr["M_regtime"]).ToString("yyyy-MM-dd") + "</td> ";
                    result1 += " \r\n  <td >" + _br.name + "</td> ";
                    result1 += " \r\n </tr>";
                }
                result1 += " \r\n </tbody>";
                result1 += " \r\n </table>";
                if (isExcel == 1)
                {
                    return sbexce.ToString();
                }
                else
                {
                    ylList.Text = result1;
                    return "";
                }

            }
            else
            {
                if (isExcel == 1)
                {
                    return "";
                }
                else
                {
                    ylList.Text = "<p>没有搜索到相应会员</p>";
                    return "";
                }

            }

        }
        protected void btn_save_ServerClick(object sender, EventArgs e)
        {

            try
            {
                getData();
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/VIPUser.cs", Session["wID"].ToString());
            }

        }
        /// <summary>
        /// 下载的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_downexcel(object sender, EventArgs e)
        {
            try
            {
                string files = "";
                files = getData(1);

                if (!string.IsNullOrEmpty(files))
                {
                    //不为空则是链接
                    string lj = "hylb_" + DateTime.Now.ToString().Replace(" ", "").Replace(":", "_").Replace("-", "_").Replace("/", "_") + ".csv";
                    string glj = Request.MapPath("/upload/") + lj;
                    string url = "../../down.aspx?filename=" + lj;
                    try
                    {

                        if (System.IO.File.Exists(glj))
                        {
                            System.IO.File.Delete(glj);

                        }
                        Byte[] bys = System.Text.Encoding.GetEncoding("GB2312").GetBytes(files);
                        System.IO.Stream stm = System.IO.File.Create(glj);
                        stm.Write(bys, 0, bys.Length);
                        stm.Close();
                        stm = null;
                        xiazai.Text = "<input type=\"button\" class=\"btnAdd\" onclick=\" location.href='" + url + "'\"  value=\"下载excel\" />";
                    }
                    catch (System.Exception ex)
                    {
                        xiazai.Text = "<a href='####'  class=\"btnAdd\">导出错误</a>";
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/VIPUser.cs", Session["wID"].ToString());
            }
        }
        protected void btn_refresh_ServerClick(object sender, EventArgs e)
        {

            try
            {
                int _wid = 0;
                if (Session["wID"] != null)
                    _wid = Convert.ToInt32(Session["wID"].ToString());
                else
                    return;
                string _sql = "*";
                string _where = ""; //" cityID=" + _wid.ToString()
                DataTable _tab = B2C_mem.GetList(_sql, _where);
                if (_tab.Rows.Count > 0)
                {
                    string _develop_sql = "select top 1 * from wx_mp where wid=" + Session["wID"].ToString();
                    DataTable _wx_mp = comfun.GetDataTableBySQL(_develop_sql);
                    if (_wx_mp.Rows.Count > 0)//找到开发者ID，密码
                    {
                        string develop_id = _wx_mp.Rows[0]["wx_DID"].ToString();
                        string develop_psw = _wx_mp.Rows[0]["wx_Dpsw"].ToString();

                        int count = 0;
                        for (int i = 0; i < _tab.Rows.Count; i++)
                        {
                            string _info_sql = "select top 1 * from B2C_PeopleInfo where memb_id=" + _tab.Rows[i]["id"].ToString();
                            DataTable _tab_info = comfun.GetDataTableBySQL(_info_sql);
                            weixinUser _user = new weixinUser();
                            if (_tab.Rows[i]["M_card"] != null && _tab.Rows[i]["M_card"].ToString() != "")
                            {
                                _user = WeixinMember.GetWeiXinRequest(_tab.Rows[i]["M_card"].ToString(), develop_id, develop_psw);
                                if (count == 5)
                                {
                                    break;
                                }
                                if (_user.Nickname == "")
                                {
                                    count++;
                                    continue;
                                }
                                if (_user.Openid != "")
                                {
                                    _info_sql = "select top 1 * from B2C_PeopleInfo where wwv='" + _user.Openid + "'";
                                    _tab_info = comfun.GetDataTableBySQL(_info_sql);
                                }
                                if (_tab_info.Rows.Count > 0)//存在对应的信息，更新
                                {
                                    B2C_PeopleInfo b2c_info = new B2C_PeopleInfo(Convert.ToInt32(_tab_info.Rows[0]["id"].ToString()), 1);
                                    b2c_info.wwv = _user.Openid;
                                    b2c_info.nicheng = _user.Nickname;
                                    b2c_info.chengshi = _user.City;
                                    b2c_info.yuyan = _user.Country;
                                    if (_user.Sex == 1)
                                        b2c_info.xingbie = "男";
                                    else
                                        b2c_info.xingbie = "女";
                                    b2c_info.touxiang = _user.Headimgurl;
                                    b2c_info.guanzhutime = _user.Subscribe_time;
                                    b2c_info.memb_id = Convert.ToInt32(_tab.Rows[i]["id"].ToString());
                                    b2c_info.Update();
                                }
                                else//插入
                                {
                                    B2C_PeopleInfo b2c_info = new B2C_PeopleInfo();
                                    b2c_info.wwv = _user.Openid;
                                    b2c_info.nicheng = _user.Nickname;
                                    b2c_info.chengshi = _user.City;
                                    b2c_info.yuyan = _user.Country;
                                    if (_user.Sex == 1)
                                        b2c_info.xingbie = "男";
                                    else
                                        b2c_info.xingbie = "女";
                                    b2c_info.touxiang = _user.Headimgurl;
                                    b2c_info.guanzhutime = _user.Subscribe_time;
                                    b2c_info.memb_id = Convert.ToInt32(_tab.Rows[i]["id"].ToString());
                                    b2c_info.Update();
                                }
                            }
                        }
                    }
                }

                Response.Write("<script language='javascript'>location.href='VIPUser.aspx';</script>");
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/vipmemb/VIPUser.cs", Session["wID"].ToString());
            }

        }


    }
}