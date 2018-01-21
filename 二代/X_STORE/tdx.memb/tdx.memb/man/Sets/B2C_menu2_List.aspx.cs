using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Creatrue.kernel;
using tdx.database;
using System.Text.RegularExpressions;
using System.Data;
using tdx.Weixin;
using Newtonsoft.Json;

namespace tdx.memb.man.Sets
{
    public partial class B2C_menu2_List : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "<span class='tipsTitle'>小贴士：</span> 认证订阅号、服务号、认证服务号可以设置公众号自定义菜单，如右图。";
                    lt_friendly.Text += "<br/>您可以在此设置好一级菜单、二级菜单后，再点击“一键写入公众号菜单”按钮，为您的公众号设置上优雅的自定义菜单。";
                    lt_friendly.Text += "<br/><span class='tipsTitle'>注意：</span>一级菜单最多三个；每个一级菜单下最多设置五个二级菜单。";

                    int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);

                    if (_wid == 0)
                    {
                        Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！');location.href='../sets/wx_mp_list.aspx';</script>");
                        return;
                    }
                    else
                    {
                        try
                        {
                            wx_mp wxmp = new wx_mp(_wid);
                            lt_mp.Text = wxmp.wx_nichen;
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script language='javascript'>alert('请先选择具体要操作的公众号！" + ex.Message.Replace("'", "") + "');location.href='/sets/wx_mp_list.aspx';</script>");
                            return;
                        }
                    }

                    string parents = "0";
                    string levels = "1";
                    if (Request["parent"] != null)
                    {
                        parents = Request["parent"];
                    }
                    if (Request["level"] != null)
                    {
                        levels = Request["level"];
                    }
                    string superSQL = " c_level=" + levels + " and cityid=" + _wid;

                    lb_catelist.Text = ClassList(superSQL);
                    //生成分页按钮
                    //int _page = (Request["page"] != null ? Convert.ToInt32(Request["page"]) : 1);
                    //int totalcount = Convert.ToInt32(comfun.GetDataTableBySQL("select count(*) from B2C_menu2").Rows[0][0]);
                    //lt_pagearrow.Text = Creatrue.Common.commonTool.F_pagearrow(_page, totalcount);

                    lb_cateadd.Text = "<input value='添加一级菜单' class=\"btnAdd\" type='button' onclick=\"location.href='B2C_menu2_Add.aspx?parent=" + parents + "&level=" + levels + "&wid=" + _wid.ToString().Trim() + "';\"/>";
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                }

            }
        }

        #region 读取数据
        protected string ClassList(string _sql)
        {
            string _dzd = "";
            try
            {
                _dzd = " *,(select c_name from B2C_menu2 as bm where bm.c_id=B2C_menu2.c_parent and bm.cityID=B2C_menu2.cityID) as cname   ";

                DataTable dt = B2C_menu2.GetList(_dzd, _sql);

                #region 获取大类数据
                string str = "";
                str += @"<table >";
                str += @"       <tr>";
                str += "        <th ><input type=\"checkbox\"   name=\"delAll\" id=\"delAll\" runat=\"server\" onclick =\"this.value=checkAll(form1.delbox,this);\" />全选</th>";
                str += @"        <th >一级菜单</th>";
                str += @"        <th >二级菜单</th>";
                str += @"        <th >排序</th>";
                str += @"        <th >操作</th>";
                str += @"       </tr>";
                foreach (DataRow dr in dt.Rows)
                {

                    str += @"        <tr>";


                    str += @"          <td><input type=checkbox name=""delbox""  value=""" + dr["c_id"] + "\"></td>";

                    if (Convert.ToInt32(dr["c_parent"]) == 0)
                    {
                        str += @"          <td >" + dr["c_name"] + "</td>";
                        str += @"          <td >  </td>";
                    }
                    else
                    {
                        str += @"          <td>" + dr["cname"] + "</td>";
                        str += @"          <td >" + dr["c_name"] + "</td>";
                    }
                    str += @"          <td>" + dr["c_sort"] + "</td>";
                    str += @"          <td ><a href='B2C_menu2_Add.aspx?id=" + dr["c_id"] + "&wid=" + dr["cityID"].ToString() + "'>修改</a>";
                    if (Convert.ToInt32(dr["c_parent"]) == 0)
                    {
                        str += "| <a href='b2c_menu2_add.aspx?level=2&parent=" + dr["c_id"].ToString().Trim() + "&wid=" + dr["cityID"].ToString() + "'>添加二级菜单</a>";
                    }
                    str += "</td>";
                    str += @"        </tr>";

                    DataTable dt2 = B2C_menu2.GetList(_dzd, "c_parent=" + dr["c_id"].ToString() + " and cityid=" + dr["cityID"].ToString());
                    foreach (DataRow dr2 in dt2.Rows)
                    {

                        str += @"        <tr>";


                        str += @"          <td><input type=checkbox name=""delbox""  value=""" + dr2["c_id"] + "\"></td>";
                        str += @"          <td> </td>";
                        str += @"          <td>" + dr2["c_name"] + "</td>";
                        str += @"          <td>" + dr2["c_sort"] + "</td>";
                        str += "          <td><a href='B2C_menu2_Add.aspx?id=" + dr2["c_id"] + "&wid=" + dr["cityID"].ToString() + "'>修改</a>";
                        str += "</td>";
                        str += @"        </tr>";
                    }
                }
                str += @"</table>";
                #endregion

                return str;
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                return _dzd;
            }
        }
        #endregion

        #region 彻底删除
        protected void delBtn_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string delid = "0";
                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);
                if (Request["delbox"] != null)
                {
                    delid = Request["delbox"].ToString();
                    String[] delidArry = Regex.Split(delid, ",");
                    foreach (String _id in delidArry)
                    {
                        int id = Convert.ToInt32(_id);
                        try
                        {
                            DataTable dt = comfun.GetDataTableBySQL("select c_child from B2C_menu2 where c_id=" + id + " and c_child > 0");
                            if (dt.Rows.Count <= 0)
                            {
                                B2C_menu2.myDel(id);
                                lt_result.Text = "已彻底删除！";
                                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu2_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";
                            }
                            else
                            {
                                lt_result.Text = "存在子类的目录无法删除！";
                                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='B2C_menu2_List.aspx?wid=" + _wid.ToString() + "';},300);</script>";

                            }
                        }
                        catch (Exception)
                        {
                            lt_result.Text = "彻底删除失败！";
                        }
                    }
                }
                else
                {
                    lt_result.Text = "请选择需要彻底删除的项！";
                }
            }
            catch (Exception ex)
            { 
                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
            }
        }
        #endregion


        /// <summary>
        /// 一键写入订单操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_writeMenu_Click(object sender, EventArgs e)
        {
            try
            {
                int _wid = (Request["wid"] != null ? Convert.ToInt32(Request["wid"]) : 0);

                if (_wid == 0)
                {
                    lt_result.Text = "请先选择具体要操作的公众号！";
                    lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../sets/wx_mp_list.aspx';},300);</script>";
                    return;
                }
                else
                {

                    try
                    {
                        wx_mp wxmp = new wx_mp(_wid);
                        if (wxmp.wx_cid == 0)
                        {
                            lt_result.Text = "认证订阅号，无法写入自定义菜单";
                            return;
                        }
                        //lt_mp.Text = "公众号: " + wxmp.wx_nichen;
                        string _appID = wxmp.wx_DID;
                        string _appPSW = wxmp.wx_Dpsw;
                        string _wwx = wxmp.wx_ID;

                        if (string.IsNullOrEmpty(_appID) || string.IsNullOrEmpty(_appPSW))
                        {
                            lt_result.Text = "请先设置公众号AppID和AppSecret！";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../sets/wx_mp_list.aspx?id=" + _wid.ToString() + "';},300);</script>";
                            return;
                        }
                        else
                        {
                            string _accessToken = GetAccessToken(_appID, _appPSW);
                            string result = DelMenu(_accessToken);
                            //如果是保时捷
                            if (_wid == 62)
                            {
                                guotaotao2 gt = new guotaotao2();
                                string str = SetMenu(gt.createMenuDate(), _accessToken);
                                lt_writeMenu_err.Text = str;
                                return;
                            }
                            else
                            {
                                result += SetMenu(GetwxMenuString(_wid.ToString(), _wwx), _accessToken);
                                lt_writeMenu_err.Text = result;
                                return;
                            }
                            //Response.Write(GetwxMenuString(_wid.ToString(),_wwx));
                            //return; 

                        }

                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = "请先选择具体要操作的公众号！";
                        lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../sets/wx_mp_list.aspx';},300);</script>";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
            }
        }
        private string GetAccessToken(string devlopID, string devlogPsw)
        {
            string AccessToken = "";
            try
            {
                string url_token = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + devlopID + "&secret=" + devlogPsw;
                string result = func.webRequestGet(url_token);
                accessToken deserializedProduct = (accessToken)JsonConvert.DeserializeObject(result, typeof(accessToken));
                AccessToken = deserializedProduct.access_token;
                return AccessToken;
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                return AccessToken;
            }
        }
        private string DelMenu(string AccessToken)
        {
            string url_Menu_Delete = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=" + AccessToken;
            string result = "";
            try
            {

                result = func.webRequestGet(url_Menu_Delete);

                return result;
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                return result;
            }
        }
        private string SetMenu(string postData, string AccessToken)
        {
            string url_Menu_Create = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + AccessToken;
            string result = "";
            try
            {
                result = func.webRequestPost(url_Menu_Create, postData);

                return result;
            }
            catch (Exception ex)
            {
                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                return result;
            }
        }
        private string GetwxMenuString(string _wid)
        {
            string postData = "";
            try
            {
                string _dzd = " top 5 *,(select c_name from B2C_menu2 as bm where bm.c_id=B2C_menu2.c_parent and bm.cityID=B2C_menu2.cityID) as cname   ";
                string _sql = " c_level=1 and c_parent=0 and cityid=" + _wid;

                DataTable dt = B2C_menu2.GetList(_dzd, _sql);
                postData += "{" + "\r\n";
                int i = 0;
                postData += "\"button\":[ " + "\r\n";
                foreach (DataRow dr in dt.Rows)
                {
                    postData += "{	" + "\r\n";


                    if (Convert.ToInt32(dr["c_child"]) > 0) //有下级菜单
                    {
                        postData += "\"name\":\"" + dr["c_name"].ToString().Trim() + "\"," + "\r\n";

                        DataTable dt2 = B2C_menu2.GetList(_dzd, "c_parent=" + dr["c_id"].ToString() + " and cityid=" + dr["cityID"].ToString());
                        int j = 0;
                        postData += "\"sub_button\":[" + "\r\n";
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            postData += "{	" + "\r\n";
                            postData += "   \"type\":\"click\"," + "\r\n";
                            postData += "   \"name\":\"" + dr2["c_name"].ToString().Trim() + "\", " + "\r\n";
                            postData += "   \"key\":\"gtt_menu_" + dr2["c_no"].ToString().Trim() + "\" \r\n";
                            postData += "}";
                            if (++j < dt2.Rows.Count)
                                postData += ",";
                            else
                                postData += "]";
                            postData += "\r\n";
                        }
                        dt2.Dispose();
                        dt2 = null;
                    }
                    else
                    {
                        postData += "   \"type\":\"click\"," + "\r\n";
                        postData += "   \"name\":\"" + dr["c_name"].ToString().Trim() + "\", " + "\r\n";
                        postData += "   \"key\":\"gtt_menu_" + dr["c_no"].ToString().Trim() + "\" \r\n";
                    }
                    postData += "}" + "\r\n";
                    if (++i < dt.Rows.Count)
                        postData += ",";
                    else
                        postData += "]";
                    postData += "\r\n";
                }
                postData += "}" + "\r\n";

                return postData;
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                return postData;
            }
        }

        private string GetwxMenuString(string _wid, string _wwx)
        {
            string postData = "";
            try
            {
                //string rootPath = "apps";
                //try
                //{
                //    B2C_worker bw = new B2C_worker(Convert.ToInt32(Session["wID"]));
                //    rootPath = bw.wx_GNTheme;
                //}
                //catch (Exception ex)
                //{ ;}

                string _dzd = " *,(select c_name from B2C_menu2 as bm where bm.c_id=B2C_menu2.c_parent and bm.cityID=B2C_menu2.cityID) as cname   ";
                string _sql = " c_level=1 and c_parent=0 and cityid=" + _wid;

                DataTable dt = B2C_menu2.GetList(_dzd, _sql);
                postData += "{" + "\r\n";
                int i = 0;
                postData += "\"button\":[ " + "\r\n";
                foreach (DataRow dr in dt.Rows)
                {



                    if (Convert.ToInt32(dr["c_child"]) > 0) //有下级菜单
                    {
                        postData += "{	" + "\r\n";
                        postData += "\"name\":\"" + dr["c_name"].ToString().Trim() + "\"," + "\r\n";

                        DataTable dt2 = B2C_menu2.GetList(_dzd, "c_parent=" + dr["c_id"].ToString() + " and cityid=" + dr["cityID"].ToString());
                        int j = 0;
                        postData += "\"sub_button\":[" + "\r\n";
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            string _url = dr2["c_url"].ToString().Trim();
                            if (!(_url.StartsWith("http://") || _url.StartsWith("https://") || _url.StartsWith("tel:")))
                            {
                                //if (_url.IndexOf("?") != -1)
                                //    _url += "&";
                                //else
                                //    _url += "?";

                                //_url += "WWX=" + _wwx + "&WWV=" + "";
                                //_url = "http://www.tdx.cn/" + rootPath + "/" + _url;

                                postData += "{	" + "\r\n";
                                postData += "   \"type\":\"click\"," + "\r\n";
                                postData += "   \"name\":\"" + dr2["c_name"].ToString().Trim() + "\", " + "\r\n";
                                postData += "   \"key\":\"gtt_menu_" + dr2["c_no"].ToString().Trim() + "\" \r\n";
                                postData += "}";
                            }
                            else
                            {
                                postData += "{	" + "\r\n";
                                postData += "   \"type\":\"view\"," + "\r\n";
                                postData += "   \"name\":\"" + dr2["c_name"].ToString().Trim() + "\", " + "\r\n";
                                postData += "   \"url\":\"" + _url + "\" \r\n";
                                postData += "}";
                            }

                            if (++j < dt2.Rows.Count)
                                postData += ",";
                            else
                                postData += "]";
                            postData += "\r\n";
                        }
                        dt2.Dispose();
                        dt2 = null;

                        postData += "}" + "\r\n";
                    }
                    else
                    {
                        string _url = dr["c_url"].ToString().Trim();
                        if (!(_url.StartsWith("http://") || _url.StartsWith("https://")))
                        {
                            postData += "{	" + "\r\n";
                            postData += "   \"type\":\"click\"," + "\r\n";
                            postData += "   \"name\":\"" + dr["c_name"].ToString().Trim() + "\", " + "\r\n";
                            postData += "   \"key\":\"gtt_menu_" + dr["c_no"].ToString().Trim() + "\" \r\n";
                            postData += "}";
                        }
                        else
                        {
                            postData += "{	" + "\r\n";
                            postData += "   \"type\":\"view\"," + "\r\n";
                            postData += "   \"name\":\"" + dr["c_name"].ToString().Trim() + "\", " + "\r\n";
                            postData += "   \"url\":\"" + _url + "\" \r\n";
                            postData += "}";
                        }

                    }

                    if (++i < dt.Rows.Count)
                        postData += ",";
                    else
                        postData += "]";
                    postData += "\r\n";
                }
                postData += "}" + "\r\n";

                return postData;
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/B2C_menu2_List.cs", Session["wID"].ToString());
                return postData;
            }
        }


    }
}