using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using Creatrue.Common;

namespace tdx.memb.man.vipmemb
{
    public partial class Edit_Activity : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>配置您的微信会员卡活动。";
                try
                {
                    if (Request["id"] != null)
                    {
                        int _id = Convert.ToInt32(Request["id"].ToString());
                        string _sql = "*";
                        string _where = string.Format(" id={0}", _id);
                        DataTable dt = B2C_card_action.GetList(_sql, _where);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["is_long"].ToString() == "1")
                            {
                                _Long.Checked = true;
                                timeShow.Style.Add(HtmlTextWriterStyle.Display, "none");//让对应的div不显示
                            }
                            else
                            {
                                timeRange.Checked = true;
                                start_time.Value = dt.Rows[0]["star_time"].ToString();
                                end_time.Value = dt.Rows[0]["end_time"].ToString();
                            }
                            activity_name.Value = dt.Rows[0]["name"].ToString();
                            activity_state.Value = dt.Rows[0]["des"].ToString();

                        }
                    }
                    else
                    {
                        _Long.Checked = true;
                        timeShow.Style.Add(HtmlTextWriterStyle.Display, "none");//让对应的div不显示
                    }
                }
                catch (Exception ex)
                {
                    comfun.ChuliException(ex, "man/vipmemb/Edit_Activity.cs", Session["wID"].ToString());
                }

            }
            else
            {
                if (timeRange.Checked)
                {
                    timeRange.Checked = true;

                    timeShow.Style.Remove(HtmlTextWriterStyle.Display);

                }
            }
        }
        /// <summary>
        /// 保存活动设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_ServerClick(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                try
                {
                    int _id = Convert.ToInt32(Request["id"].ToString());
                    if (activity_name.Value == "")
                    {
                        commonTool.Show_Have_Url(lt_result, "请输入活动名称！", "", 1);
                    }
                    else if (timeRange.Checked == false && _Long.Checked == false)
                    {
                        commonTool.Show_Have_Url(lt_result, "时间范围必须选择一种！", "", 1);
                    }
                    else
                    {
                        B2C_card_action b2cCard = new B2C_card_action(_id);
                        if (timeRange.Checked == true)
                        {
                            if (start_time.Value == "")
                            {
                                commonTool.Show_Have_Url(lt_result, "必须选择开始时间！", "", 1);
                            }
                            else if (end_time.Value == "")
                            {
                                commonTool.Show_Have_Url(lt_result, "必须选择结束时间！", "", 1);
                            }
                            else
                            {
                                b2cCard.star_time = Convert.ToDateTime(start_time.Value);
                                b2cCard.end_time = Convert.ToDateTime(end_time.Value);
                                if (Convert.ToDateTime(start_time.Value) > Convert.ToDateTime(end_time.Value))
                                {
                                    commonTool.Show_Have_Url(lt_result, "开始时间不能大于结束时间！", "", 1);
                                }
                                else if (Convert.ToDateTime(end_time.Value) < DateTime.Now)
                                {
                                    commonTool.Show_Have_Url(lt_result, "结束时间不能小于当前时间！", "", 1);
                                }
                                else
                                {
                                    b2cCard.name = activity_name.Value;
                                    b2cCard.star_time = Convert.ToDateTime(start_time.Value);
                                    b2cCard.end_time = Convert.ToDateTime(end_time.Value);
                                    beginDate.Value = b2cCard.star_time.ToString();
                                    endDate.Value = b2cCard.end_time.ToString();
                                    b2cCard.des = activity_state.Value;
                                    b2cCard.is_long = 0;
                                    b2cCard.Update();
                                    commonTool.Show_Have_Url(lt_result, "编辑成功！", "Vip_Activity.aspx", 0);
                                }
                            }
                        }
                        else
                        {
                            b2cCard.name = activity_name.Value;
                            b2cCard.des = activity_state.Value;
                            b2cCard.is_long = 1;
                            b2cCard.Update();
                            commonTool.Show_Have_Url(lt_result, "编辑成功！", "Vip_Activity.aspx", 0);
                        }
                    }
                }
                catch (Exception ex1)
                {
                    comfun.ChuliException(ex1, "man/vipmemb/Edit_Activity.cs", Session["wID"].ToString());
                    commonTool.Show_Have_Url(lt_result, "编辑失败！", "", 1);
                }
            }
            else
            {
                try
                {
                    int _wid = Convert.ToInt32(Session["wid"].ToString());
                    int _card_id = 0;
                    string _sql = "*";
                    string _infoWhere = string.Format("wid={0}", _wid);
                    DataTable dt_Info = B2C_vipcard.GetList(_sql, _infoWhere);
                    if (dt_Info.Rows.Count > 0)
                        _card_id = Convert.ToInt32(dt_Info.Rows[0]["id"]);
                    if (activity_name.Value == "")
                    {
                        commonTool.Show_Have_Url(lt_result, "请输入活动名称！", "", 1);

                    }
                    else if (timeRange.Checked == false && _Long.Checked == false)
                    {
                        commonTool.Show_Have_Url(lt_result, "时间范围必须选择一种！", "", 1);

                    }
                    else
                    {
                        B2C_card_action b2cCard = new B2C_card_action();
                        if (timeRange.Checked == true)
                        {
                            if (start_time.Value == "")
                            {
                                commonTool.Show_Have_Url(lt_result, "必须选择开始时间！", "", 1);

                            }
                            else if (end_time.Value == "")
                            {
                                commonTool.Show_Have_Url(lt_result, "必须选择结束时间！", "", 1);

                            }
                            else
                            {
                                b2cCard.star_time = Convert.ToDateTime(start_time.Value);
                                b2cCard.end_time = Convert.ToDateTime(end_time.Value);
                                if (Convert.ToDateTime(start_time.Value) > Convert.ToDateTime(end_time.Value))
                                {
                                    commonTool.Show_Have_Url(lt_result, "开始时间不能大于结束时间！", "", 1);

                                }
                                else if (Convert.ToDateTime(end_time.Value) < DateTime.Now)
                                {
                                    commonTool.Show_Have_Url(lt_result, "结束时间不能小于当前时间！", "", 1);

                                }
                                else
                                {
                                    b2cCard.name = activity_name.Value;
                                    b2cCard.star_time = Convert.ToDateTime(start_time.Value);
                                    b2cCard.end_time = Convert.ToDateTime(end_time.Value);
                                    beginDate.Value = b2cCard.star_time.ToString();
                                    endDate.Value = b2cCard.end_time.ToString();
                                    b2cCard.des = activity_state.Value;
                                    b2cCard.cardid = _card_id;
                                    b2cCard.is_long = 0;
                                    b2cCard.Update();
                                    commonTool.Show_Have_Url(lt_result, "添加活动成功！", "Vip_Activity.aspx", 0);

                                }
                            }
                        }
                        else
                        {
                            b2cCard.name = activity_name.Value;
                            b2cCard.des = activity_state.Value;
                            b2cCard.is_long = 1;
                            b2cCard.cardid = _card_id;
                            b2cCard.Update();
                            commonTool.Show_Have_Url(lt_result, "添加活动成功！", "Vip_Activity.aspx", 0);
                        }
                    }
                }
                catch (Exception ex2)
                {
                    comfun.ChuliException(ex2, "man/vipmemb/Edit_Activity.cs", Session["wID"].ToString());
                    commonTool.Show_Have_Url(lt_result, "添加活动失败！", "Vip_Activity.aspx", 0);
                }

            }
        }


        protected void btn_long(object sender, EventArgs e)
        {
            timeShow.Visible = false;
        }

        protected void btn_time(object sender, EventArgs e)
        {
            timeShow.Visible = true;
        }
    }
}