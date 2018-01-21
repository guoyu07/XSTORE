using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using tdx.Weixin;

namespace tdx.appv
{
    public partial class vipCard : weixinAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["wID"] != null)
                {
                    int wID = Convert.ToInt32(Session["wID"]);
                    string wwv = "";
                    string id = "";
                    if (Request["WWV"] != null)
                        wwv = Request["wwv"].ToString();

                    else if (Session["WWV"] != null)
                        wwv = Session["WWV"].ToString();

                    if (Request.Cookies["tdxVIP"] != null)
                        id = Request.Cookies["tdxVIP"]["vipID"] != null ? Request.Cookies["tdxVIP"]["vipID"].ToString().Trim() : "";


                    string _tdxWeixin = Session["tdxWeixin"].ToString().Trim();
                    string[] _tdxWeixinArry = _tdxWeixin.Split('|');
                    lt_title.Text = _tdxWeixinArry[1];
                    lt_keywords.Text = "<meta name=\"keywords\" content=\"" + _tdxWeixinArry[1] + "\">";
                    lt_description.Text = "<meta name=\"description\" content=\"" + _tdxWeixinArry[1] + "\">";
                    lt_theme.Text = "<link rel=\"stylesheet\" type=\"text/css\" href=\"/appv/images/" + _tdxWeixinArry[2] + "/apps_main.css\" />";
                    B2C_vipcard _bv = new B2C_vipcard(wID.ToString());
                    string uID = Convert.ToString(Session["uid"]);
                    if (!string.IsNullOrEmpty(wwv) || !string.IsNullOrEmpty(id))
                    {
                        string _sql = "top(1) *";
                        string _where = string.IsNullOrEmpty(wwv) ? " id =" + id + " and cityID=" + wID : " M_card ='" + wwv + "' and cityID=" + wID;
                        DataTable dt = B2C_mem.GetList(_sql, _where);
                        if (dt.Rows.Count > 0)
                        { //找到对应的信息了
                            int _uid = Convert.ToInt32(dt.Rows[0]["id"]);
                            B2C_user_rank _bur = new B2C_user_rank(_uid.ToString());
                            B2C_rankinfo _br = new B2C_rankinfo(_bur.rankid);
                            //链接显示界面
                            detailed.HRef = "EditVip.aspx?wwx=" + Request["wwx"] + (string.IsNullOrEmpty(wwv) ? "" : "&wwv=" + wwv);
                            //<p class='price'></span></p>
                            string result1 = "";//卡片信息
                            string result2 = "";//特权信息
                            string result3 = "";//活动信息
                            result1 += "\r\n<div>";
                            result1 += "\r\n <p class='des' id='card_number'><span>卡号：" + _bur.card_number + "</span></p>";//卡号
                            result1 += "\r\n <p class='des' id='card_number'><span>等级：" + _br.name + "</span></p>";//等级名称
                            result1 += "\r\n";
                            result1 += "\r\n </div>";
                            //会员卡logo
                            //等级名称
                            lt_lea.Text = "<span class='level'>" + _br.name + "</span>";
                            //卡号
                            lt_num.Text = _bur.card_number;
                            //会员名
                            lt_name.Text = dt.Rows[0]["M_name"].ToString();

                            //_sql = "*";
                            //_where = "rankid=" + _bur.rankid;
                            //DataTable _rank = B2C_rankvsfran.GetList(_sql, _where);
                            //result2 += "\r\n<div class='rank'>";
                            //foreach (DataRow dr in _rank.Rows)
                            //{
                            //    B2C_Franchises _items = new B2C_Franchises(Convert.ToInt32(dr["franid"]));
                            //    result2 += "\r\n";
                            //    result2 += "\r\n <span>特权名称：" + _items.name + "</span>&nbsp;&nbsp;";//特权名称
                            //    result2 += "\r\n <span>特权介绍：" + _items.des + "</span><br/>";//特权介绍
                            //}
                            //result2 += "\r\n </div>";

                            _sql = "*";
                            _where = "cardid=" + _bv.id + " and (end_time>='" + DateTime.Now + "' or is_long=1)";
                            DataTable _action = B2C_card_action.GetList(_sql, _where);
                            result3 += "\r\n <div class='action'>";
                            foreach (DataRow dr in _action.Rows)
                            {
                                result3 += "\r\n";
                                result3 += "\r\n <span>活动名称：" + dr["name"].ToString() + "</span>&nbsp;&nbsp;";//活动名称
                                result3 += "\r\n <span>活动介绍：" + dr["des"].ToString() + "</span><br/>";//活动介绍
                            }
                            result3 += "\r\n </div>";
                            //lt_rank.Text = result2;
                            lt_active.Text = result3;
                            lt_foot.Text = "\r\n<ul><li><a href='EditVip.aspx?wwx=" + Request["wwx"] + "&uid=" + Session["uid"] + "'>编辑资料</a></li><li><a href='CheckLog.aspx?wwx=" + Request["wwx"] + "'>查看详细</a></li></ul>";
                        }
                        else
                        {
                            //未找到对应信息
                            detailed.HRef = "EditVip.aspx?wwx=" + Request["wwx"];// +"&uid=" + Session["uid"];
                            getCard.Style.Remove("display");
                            //getCard.Attributes.Add("display", "display");
                            getCard.HRef = "EditVip.aspx?wwx=" + Request["wwx"];// +"&uid=" + Session["uid"];
                            lt_num.Text = "会员卡未激活";
                        }
                        lt_wa.Text = B2C_wallet.GetWallet(wID); //特权信息
                    }
                    else
                    {
                        //未找到对应信息
                        detailed.HRef = "EditVip.aspx?wwx=" + Request["wwx"];// +"&uid=" + Session["uid"];
                        getCard.Style.Remove("display");
                        //getCard.Attributes.Add("display", "display");
                        getCard.HRef = "EditVip.aspx?wwx=" + Request["wwx"];// +"&uid=" + Session["uid"];
                        lt_num.Text = "会员卡未激活";
                    }
                    //会员卡logo信息
                    lt_logo.Text = "<div class='logo' style='background-image:url(" + _bv.title_image + ")'></div>";
                }
            }
        }
    }
}