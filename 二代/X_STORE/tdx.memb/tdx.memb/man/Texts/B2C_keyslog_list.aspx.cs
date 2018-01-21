using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using System.Data;
using Creatrue.kernel;
using tdx.memb.man.config;

namespace tdx.memb.man.Texts
{
    public partial class B2C_keyslog_list : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                lt_friendly.Text = "<span class='tipsTitle'>小提示：</span>在这里，您可以看到您的公众号粉丝，给你发送的关键词咨询记录。<br/>如果您是认证服务号，您还可以直接在此回复您的粉丝（粉丝最后咨询的48小时内）。";
                if (Request["mid"] != null)
                {

                    int pagesize = 20;
                    string _sql = "select top 1 * from wx_mp where id=" + Request["mid"].ToString();
                    DataTable _tab = comfun.GetDataTableBySQL(_sql);
                    if (_tab.Rows.Count > 0)
                    {
                        int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);

                        string _sqlLog = "select * ,(row_number() over(order by id desc)) as rown from wx_logs where toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and Ltype='text' and Lmsg like '收到信息：%'";
                        _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";

                        _sqlLog += "select * from B2C_PeopleInfo;";
                        ylList.Text = pagelist(_sqlLog, _tab);
                        string _sql1 = " toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and Ltype='text' and Lmsg like '收到信息：%'";
                        int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_logs where 1=1 and " + _sql1).Rows[0][0]);
                        // lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
                        lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                    }
                }
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "memb/Texts/B2C_keyslog_list.cs", Session["wID"].ToString());
            }

        }


        private string pagelist(string _sql, DataTable _tab)
        {
            string result1 = "";
            try
            {

                string devID = _tab.Rows[0]["wx_DID"].ToString();
                string devPsw = _tab.Rows[0]["wx_Dpsw"].ToString();
                bool isRepy = false;  //是否可回复
                if (!string.IsNullOrEmpty(devID) && !string.IsNullOrEmpty(devPsw))
                {
                    isRepy = true;
                }

                DataSet ds = comfun.GetDataSetBySQL(_sql);
                DataTable _tabList = ds.Tables[0];
                //DataTable _tabDic = ds.Tables[1];
                DataTable _tabInfo = ds.Tables[1];
                result1 += "\r\n";
                result1 += " \r\n <table>";
                result1 += " \r\n <tbody>";
                result1 += "\r\n <tr>";
                result1 += "\r\n <th >时间</th> ";
                result1 += "\r\n <th >消息</th> ";
                result1 += "\r\n <th >昵称</th> ";
                result1 += "\r\n <th >状态</th> ";
                result1 += "\r\n <th >回复</th> ";
                result1 += " \r\n </tr>";
                Dictionary<string, B2C_PeopleInfo> dicWWV = new Dictionary<string, B2C_PeopleInfo>();
                foreach (DataRow dr in _tabList.Rows)//遍历日志表
                {
                    int count = 0;
                    string _wwv = dr["FromUser"].ToString();

                    for (int i = 0; i < _tabInfo.Rows.Count; i++)//遍历微信信息表
                    {
                        if (dr["FromUser"].ToString().Equals(_tabInfo.Rows[i]["wwv"]))//如果和微信信息表有相同的，存入字典跳出
                        {
                            B2C_PeopleInfo b2cInfo = new B2C_PeopleInfo(Convert.ToInt32(_tabInfo.Rows[i]["id"].ToString()), 1);//实例化
                            int flag = 0;
                            foreach (string keys in dicWWV.Keys)
                            {
                                if (keys.Equals(dr["FromUser"].ToString()))///字典中已存在，跳出
                                {
                                    flag++;
                                    break;
                                }
                            }
                            if (flag == 0)//
                            {
                                dicWWV.Add(b2cInfo.wwv, b2cInfo);
                            }
                            count++;
                            break;
                        }
                        else
                            continue;
                    }
                    if (count == 0)
                    {
                        weixin _weixin = new weixin();
                        tdx.memb.man.config.weixinUser _user = new tdx.memb.man.config.weixinUser();
                        _user = _weixin.GetInfo(_wwv, devID, devPsw);
                        B2C_PeopleInfo b2cInfo = new B2C_PeopleInfo();

                        b2cInfo.chengshi = _user.City;
                        b2cInfo.guanzhutime = _user.Subscribe_time;
                        b2cInfo.nicheng = _user.Nickname;
                        b2cInfo.touxiang = _user.Headimgurl;

                        b2cInfo.wwv = _user.Nickname != "" ? _user.Openid : dr["FromUser"].ToString();
                        b2cInfo.yuyan = _user.Country;
                        if (_user.Sex == 1)
                            b2cInfo.xingbie = "男";
                        else
                            b2cInfo.xingbie = "女";
                        b2cInfo.Update();
                        int _flag = 0;
                        foreach (string keys in dicWWV.Keys)
                        {
                            if (keys.Equals(b2cInfo.wwv))
                            {
                                _flag++;
                                break;
                            }
                        }
                        if (_flag == 0)
                        {
                            dicWWV.Add(b2cInfo.wwv, b2cInfo);
                        }


                    }
                }
                foreach (DataRow dr in _tabList.Rows)
                {

                    foreach (string keys in dicWWV.Keys)
                    {
                        if (dr["FromUser"].ToString().Equals(keys))
                        {
                            string _content = dr["Lmsg"].ToString().Trim().Replace("收到信息：", "");
                            string _type = dr["Ltype"].ToString().Trim();

                            if (_type == "text" && !string.IsNullOrEmpty(_content))
                            {
                                result1 += " \r\n <tr>";
                                result1 += " \r\n <td >" + dr["regtime"].ToString() + "</td> ";
                                result1 += " \r\n <td >" + _content + "</td> ";
                                result1 += "\r\n  <td>";
                                result1 += "<a href=\"####" + "\" title=\"" + "昵称:" + dicWWV[keys].nicheng + "\r\n微信号:" + dicWWV[keys].wwv + "\r\nfakeID:" + dicWWV[keys].fakeID + "\r\n微信名:" + dicWWV[keys].weiName + "\r\n性别:" + dicWWV[keys].xingbie + "\r\n身份:" + dicWWV[keys].shengfen + "\r\n城市:" + dicWWV[keys].chengshi + "\r\n关注时间:" + dicWWV[keys].guanzhutime + "\r\n国家:" + dicWWV[keys].yuyan + "\" >";
                                result1 += "<img runat=\"Server\" width=\"60\" id=\"m_ph\" src=\"" + dicWWV[keys].touxiang + "\" /><br/>" + dicWWV[keys].nicheng + "</a></td>";
                                result1 += " \r\n <td>" + (Convert.ToInt32(dr["isReply"].ToString().Trim()) == 1 ? "已回复" : "未回复") + "</td> ";
                                //////判断是否可回复
                                DateTime current = Convert.ToDateTime(dr["regtime"].ToString());
                                TimeSpan ts = DateTime.Now - current;
                                if (dicWWV[keys].nicheng != "")
                                {
                                    if (isRepy && (ts.Days < 2) || (ts.Days == 2 && ts.Hours == 0 && ts.Minutes == 0 && ts.Seconds == 0))
                                    {
                                        //说明可以回复
                                        //result1 += " \r\n <td ><a class=\"btnReply\"  href=\"B2C_MessageEdit.aspx?wwv=" + dr["FromUser"].ToString() + "&mid=" + Request["mid"].ToString() + "\">点击回复</a></td>";
                                        result1 += " \r\n <td ><a class=\"btnReply\" _title=\"回复\"  href=\"javascript:void(0)\" _target=\"B2C_MessageEdit.aspx?wwv=" + dr["FromUser"].ToString() + "&mid=" + Request["mid"].ToString() + "\">点击回复</a></td>";
                                    }
                                }
                                else
                                {
                                    result1 += " \r\n <td></td> ";
                                }


                                result1 += " \r\n </tr>";
                            }
                            break;
                        }
                    }
                }
                result1 += " \r\n </tbody>";
                result1 += " \r\n </table>";

                return result1;
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/Texts/B2C_keyslog_list.cs", Session["wID"].ToString());
                return result1;
            }
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sousuo_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _sql = " 1=1 and ";
                if (kaishi.Value == "" && jieshu.Value == "")
                {
                    _sql += "";
                }
                else if (kaishi.Value == "")
                {
                    _sql += " regtime<='" + jieshu.Value + " 23:59:59' and ";
                }
                else if (jieshu.Value == "")
                {
                    _sql += " regtime>='" + kaishi.Value + " 00:00:00' and ";
                }
                else
                {
                    if (Convert.ToDateTime(kaishi.Value) >= Convert.ToDateTime(jieshu.Value))
                    {
                        Response.Write("<script language='javascript'>alert('开始时间不能大于结束时间!');</script>");
                        return;
                    }
                    else
                        _sql += " regtime>='" + kaishi.Value + " 00:00:00'" + " and regtime<='" + jieshu.Value + " 23:59:59' and ";
                }
                string _sql_nicheng = "(select wwv from B2C_PeopleInfo where nicheng like '%" + weixin.Value.Replace("'", "") + "%')";
                _sql += " FromUser in " + _sql_nicheng;
                txtSql.Value = _sql;
                int pagesize = 20;
                string sql1 = "select top 1 * from wx_mp where id=" + Request["mid"].ToString();
                DataTable _tab = comfun.GetDataTableBySQL(sql1);
                if (_tab.Rows.Count > 0)
                {
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    string _sqlLog = "select * ,(row_number() over(order by id desc)) as rown from wx_logs where toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and Ltype='text' and Lmsg like '收到信息：%' and " + _sql;
                    _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";

                    _sqlLog += "select * from B2C_PeopleInfo;";
                    ylList.Text = pagelist(_sqlLog, _tab);
                    string _sql2 = " toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and Ltype='text' and Lmsg like '收到信息：%' and ";
                    _sql2 += _sql;
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_logs where 1=1 and " + _sql2).Rows[0][0]);
                    //   lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/Texts/B2C_keyslog_list.cs", Session["wID"].ToString());
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ss_btn_ServerClick(System.Object sender, System.EventArgs e)
        {
            try
            {
                int pagesize = 20;
                string _sql = "select top 1 * from wx_mp where id=" + Request["mid"].ToString();
                DataTable _tab = comfun.GetDataTableBySQL(_sql);
                if (_tab.Rows.Count > 0)
                {
                    int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    string _sqlLog = "select * ,(row_number() over(order by id desc)) as rown from wx_logs where toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and Ltype='text' and Lmsg like '收到信息：%'  and " + txtSql.Value;
                    _sqlLog = "with a as (" + _sqlLog + ") select top " + pagesize + " * from a where rown>" + (_page - 1) * pagesize + " order by rown;";

                    _sqlLog += "select * from B2C_PeopleInfo;";
                    ylList.Text = pagelist(_sqlLog, _tab);
                    string _sql1 = " toUser='" + _tab.Rows[0]["wx_ID"].ToString() + "' and Ltype='text' and Lmsg like '收到信息：%'";
                    if (txtSql.Value != "1=1")
                        _sql1 += " and " + comFunction.NoHTML(txtSql.Value.Replace("'", ""));
                    int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from wx_logs where 1=1 and " + _sql1).Rows[0][0]);
                    //  lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);
                    lt_pagearrow.Text = Creatrue.Common.commonTool.GetArrowHtmlNew(_page, totalcount, 20, Request.Form, Request.QueryString);
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "memb/Texts/B2C_keyslog_list.cs", Session["wID"].ToString());
            }
        }
    }
}