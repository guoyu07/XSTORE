using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tdx.database;
using Creatrue.Common;
using System.Data;
using Creatrue.kernel;
using DTcms.Common;

namespace tdx.memb.man.Sets
{
    public partial class wx_mp_add : workAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lt_friendly.Text = "";
                    lt_friendly.Text += "<span class='tipsTitle'>小提示：</span>绑定公众号的意思就是将您的微信公众号和我们的微网站平台对接起来。";
                    lt_friendly.Text += "<br/>在开始本步骤前，您需要拥有一个微信公众号。没有的，可以到这里注册: https://mp.weixin.qq.com/cgi-bin/readtemplate?t=register/step1_tmpl&lang=zh_CN";
                    lt_friendly.Text += "<br/>如果已有微信公众号，请登录微信公众平台，我们需要获取您的公众号信息。请点击这里登录: http://mp.weixin.qq.com";
                    lt_friendly.Text += "<br/><span class='tipsTitle'>特别提醒：</span> 鼠标点击输入框，还可以看到示例图喔";
                    int _id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                    if (Request["nav"] != null && Request["nav"].ToString() == "true")
                    {
                        // DataTable _dt=comfun.GetDataTableBySQL("select top 1 * from wx_mp order by id desc");
                        //int wx_wid = Convert.ToInt32(Session["wid"]);
                        daohang_Image.Text = commonTool.DaohangImage("daohang_1.jpg");
                        string _sql = "select top 1 * from wx_mp order by id"; //where wid=" + Session["wID"].ToString() + "
                        DataTable _daoHang = comfun.GetDataTableBySQL(_sql);
                        if (_daoHang != null && _daoHang.Rows.Count > 0)
                        {
                            _id = Convert.ToInt32(_daoHang.Rows[0]["id"].ToString());
                        }
                    }
                    int _wid = Convert.ToInt32(Session["wID"].ToString());

                    if (_id != 0)
                    {
                        try
                        {
                            ////ID号获取到了 
                            wx_mp wxmp = new wx_mp(_id);
                            //if (wxmp.wid != _wid)
                            //{
                                //lt_result.Text = "这不是您的微信公众号,请不要操作！";
                                //lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},300);</script>";
                                //return;
                            //}
                            //else
                            //{
                                txtName.Value = wxmp.wx_name;
                                txtNichen.Value = wxmp.wx_nichen;
                                txtGUID.Value = wxmp.wx_ID;
                                txtDID.Value = wxmp.wx_DID;
                                txtDpsw.Value = wxmp.wx_Dpsw;
                                if (wxmp.wx_FirstIsGif == 0)
                                {
                                    RD_isGif1.Checked = true;
                                    RD_isGif2.Checked = false;
                                }
                                else
                                    RD_isGif2.Checked = true;
                                txtms.Value = wxmp.wx_des;
                                if (wxmp.wx_cid == 1)
                                    RD_Cid2.Checked = true;
                                else if (wxmp.wx_cid == 0)
                                    RD_Cid1.Checked = true;
                                else if (wxmp.wx_cid == 2)
                                    RD_Cid3.Checked = true;
                                else
                                    RD_Cid4.Checked = true;

                                try
                                {
                                    //B2C_worker bw = new B2C_worker(_wid);
                                    //if (bw.wx_GNTheme == "appv")
                                    //{
                                    //    lt_kfzURL.Text = "http://www.tdx.cn/wxv.aspx";
                                    //}
                                    //else if (bw.wx_GNTheme == "appx")
                                    //{
                                    //    lt_kfzURL.Text = "http://www.tdx.cn/wxx.aspx";
                                    //}
                                    //else
                                    //{
                                    //    lt_kfzURL.Text = "http://www.tdx.cn/appv/wxv.aspx";
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    lt_kfzURL.Text = "http://www.china-mail.com.cn/appv/wxv.aspx";
                                }

                            //}
                        }
                        catch (System.Exception ex)
                        {
                            // lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},300);</script>";
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){top.location.reload();},300);</script>";
                        }
                    }
                }
                catch (Exception ex)
                {

                    comfun.ChuliException(ex, "man/Sets/wx_mp_Add.cs", Session["wID"].ToString());
                }

            }
        }
        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int _wid = Session["wID"] != null ? Convert.ToInt32(Session["wID"].ToString()) : 0;
                int _id = Request["id"] != null ? Convert.ToInt32(Request["id"]) : 0;
                //来自导航模式,则取出第一个公众号对应的id
                if (Request["nav"] != null && Request["nav"].ToString() == "true")
                {
                    string _sql = "select top 1 * from wx_mp order by id"; //where wid=" + Session["wID"].ToString() + " 
                    DataTable _daoHang = comfun.GetDataTableBySQL(_sql);
                    if (_daoHang != null && _daoHang.Rows.Count > 0)
                    {
                        _id = Convert.ToInt32(_daoHang.Rows[0]["id"].ToString());
                    }
                }

                string _wx_name = comFunction.NoHTML(txtName.Value);
                string _wx_nichen = comFunction.NoHTML(txtNichen.Value);
                string _wx_ID = comFunction.NoHTML(txtGUID.Value);
                string _wx_DID = comFunction.NoHTML(txtDID.Value);
                string _wx_Dpsw = comFunction.NoHTML(txtDpsw.Value);
                string _wx_2wm = txtGif.Value;
                int _wx_FirstIsGif = 1;
                if (RD_isGif1.Checked == true)
                    _wx_FirstIsGif = 0;
                string _wx_des = txtms.Value.Trim();
                int _wx_cid = 0;//默认选中订阅号
                if (RD_Cid3.Checked == true)//认证订阅号
                    _wx_cid = 2;
                if (RD_Cid2.Checked == true)//服务号
                    _wx_cid = 1;
                if (RD_Cid4.Checked == true)//认证服务号
                    _wx_cid = 3;

                wx_mp goods;
                if (_id != 0)
                    goods = new wx_mp(_id);
                else
                    goods = new wx_mp();

                goods.wx_name = _wx_name;
                goods.wx_nichen = _wx_nichen;
                goods.wx_ID = _wx_ID;
                goods.wx_DID = _wx_DID;
                goods.wx_Dpsw = _wx_Dpsw;
                goods.wx_FirstIsGif = Convert.ToInt32(_wx_FirstIsGif);

                goods.wx_cid = _wx_cid;
                goods.wx_des = _wx_des;


                if (_wx_2wm != "")
                {
                    comUpload up = new comUpload();
                    up.clearFileType();
                    up.addFileType("jpg");
                    up.addFileType("jpeg");
                    up.addFileType("gif");
                    up.addFileType("png");
                    up.addFileType("bmp");

                    try
                    {
                        if (up.UploadPic(txtGif) != 0)
                        {
                            _wx_2wm = up.getTargetFilename();
                        }
                    }
                    finally { up = null; }
                }
                if (!commonTool.RemindMessageEmpty(lt_result, goods.wx_name, "请输入微信号", ""))
                    return;
                if (!commonTool.RemindMessageEmpty(lt_result, goods.wx_nichen, "请输入您的微信昵称", ""))
                    return;
                if (!commonTool.RemindMessageEmpty(lt_result, goods.wx_ID, "请输入您的微信原始号", ""))
                    return;
                if (goods.wx_ID.Substring(0, 3) != "gh_" || goods.wx_ID.Length != 15)
                {
                    lt_result.Text = "原始号不合法，请输入以gh_开头的15位字母数字组合！";
                    return;
                }
                if (!commonTool.RemindMessageLengh(lt_result, goods.wx_des.Length, 500, "描述字数不能超过500", ""))
                    return;

                if (!commonTool.RemindMessageLengh(lt_result, goods.wx_name.Length, 50, "微信号字数不能超过50", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, goods.wx_nichen.Length, 50, "微信昵称字数不能超过50", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, goods.wx_DID.Length, 50, "AppID字数不能超过50", ""))
                    return;
                if (!commonTool.RemindMessageLengh(lt_result, goods.wx_Dpsw.Length, 50, "AppSecret字数不能超过50", ""))
                    return;


                if (_id != 0) //修改模式
                {
                    try
                    {
                        //判断原始号不能重复                    

                        //if (goods.wid != _wid)
                        //{
                        //    lt_result.Text = "这不是您的微信公众号,请不要操作！";
                        //    //lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},300);</script>";
                        //    return;
                        //}
                        //else
                        //{
                            if (_wx_2wm != "")
                            {
                                goods.wx_2wm = _wx_2wm;
                            }
                            goods.Update();
                            lt_result.Text = "修改成功！";
                            if (Request["nav"] != null && Request["nav"].ToString() == "true")
                            {
                                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Ads/Welcome_Ads_Edit.aspx?nav=true';},100);</script>";
                                return;
                            }
                            else
                            {
                                lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},100);</script>";
                                return;
                            }
                        //}
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                        return;
                    }
                }
                else//添加模式
                {
                    //判断原始号不能重复

                    try
                    {
                        DataTable dt = comfun.GetDataTableBySQL("select id from wx_mp where wx_id='" + _wx_ID + "'");
                        if (dt.Rows.Count > 0)
                        {
                            lt_result.Text = "该原始号已经存在！";
                            dt.Dispose();
                            return;
                        }
                        goods.wid = _wid;
                        goods.wx_2wm = _wx_2wm;
                        goods.Update();
                        lt_result.Text = "添加成功！";



                        //DataTable dt2 = comfun.GetDataTableBySQL("select id from wx_mp where wx_id='" + _wx_ID + "'");
                        //DataRow dr = dt2.Rows[0];
                        ////</div><a class=\"index_menu_title\"  href=\"/memb/sets/wx_mp_add.aspx?id=" + dr["id"].ToString() + "\"  target=\"mainFram\">" + dr["wx_nichen"].ToString() + "</a></div> ";
                        //DTcms.Model.navigation model = new DTcms.Model.navigation();
                        //DTcms.BLL.navigation bll = new DTcms.BLL.navigation();

                        //model.nav_type = DTEnums.NavigationEnum.System.ToString();
                        //model.name = _wx_ID;
                        //model.title = _wx_nichen;
                        //model.sort_id = 98 + int.Parse(dr["id"].ToString());
                        //model.is_lock = 0;
                        //model.parent_id = 3;
                        //bll.Add(model);

                        //DataTable dt3 = comfun.GetDataTableBySQL("select id from dt_navigation where name='" + _wx_ID + "'");
                        //DataRow dr2 = dt3.Rows[0];

                        //model.name = _wx_ID + "_edit" + "_" + dr["id"].ToString();
                        //model.title = "公众号配置";
                        //model.link_url = "sets/wx_mp_add.aspx?id=" + dr["id"].ToString();
                        //model.sort_id = 99;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/ads/Welcome_Ads_Edit.aspx?wid=" + dr["id"].ToString() + "\"  target=\"mainFram\">关注时回复</a></div> ";//广告管理
                        //model.name = _wx_ID + "_res" + "_" + dr["id"].ToString();
                        //model.title = "关注时回复";
                        //model.link_url = "ads/Welcome_Ads_Edit.aspx?wid=" + dr["id"].ToString();
                        //model.sort_id = 100;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/Texts/wx_keys_list.aspx?wid=" + dr["id"].ToString() + "\"  target=\"mainFram\">关键词回复</a></div> ";
                        //model.name = _wx_ID + "_key" + "_" + dr["id"].ToString();
                        //model.title = "关键词回复";
                        //model.link_url = "Texts/wx_keys_list.aspx?wid=" + dr["id"].ToString();
                        //model.sort_id = 101;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/ads/B2C_MoRen_Edit.aspx?wid=" + dr["id"].ToString() + "\"  target=\"mainFram\">默认回复</a></div> ";//广告管理
                        //model.name = _wx_ID + "_def" + "_" + dr["id"].ToString();
                        //model.title = "默认回复";
                        //model.link_url = "ads/B2C_MoRen_Edit.aspx?wid=" + dr["id"].ToString();
                        //model.sort_id = 102;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/Sets/B2C_menu2_list.aspx?wid=" + dr["id"].ToString() + "\"  target=\"mainFram\">公众号菜单设置</a></div> ";//自定义菜单
                        //model.name = _wx_ID + "_pub" + "_" + dr["id"].ToString();
                        //model.title = "公众号菜单设置";
                        //model.link_url = "Sets/B2C_menu2_list.aspx?wid=" + dr["id"].ToString();
                        //model.sort_id = 103;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/Texts/B2C_keyslog_list.aspx?mid=" + dr["id"].ToString() + "\"  target=\"mainFram\">粉丝咨询记录</a></div> ";//回复日志列表
                        //model.name = _wx_ID + "_fans" + "_" + dr["id"].ToString();
                        //model.title = "粉丝咨询记录";
                        //model.link_url = "Texts/B2C_keyslog_list.aspx?mid=" + dr["id"].ToString();
                        //model.sort_id = 104;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/weixinmoni/WeiXinMoNi.aspx\"  target=\"mainFram\">图文推送</a></div> ";//
                        //model.name = _wx_ID + "_pic" + "_" + dr["id"].ToString();
                        //model.title = "图文推送";
                        //model.link_url = "weixinmoni/WeiXinMoNi.aspx";
                        //model.sort_id = 105;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);
                        ////"<div class=\"lv3 \"><a href=\"/memb/weixinmoni/weixinUserList.aspx\"  target=\"mainFram\">粉丝统计</a></div> ";//
                        //model.name = _wx_ID + "_fcou" + "_" + dr["id"].ToString();
                        //model.title = "粉丝统计";
                        //model.link_url = "weixinmoni/weixinUserList.aspx";
                        //model.sort_id = 106;
                        //model.is_lock = 0;
                        //model.parent_id = int.Parse(dr2["id"].ToString());
                        //bll.Add(model);

                        

                        if (Request["nav"] != null && Request["nav"].ToString() == "true")
                        {
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='../Ads/Welcome_Ads_Edit.aspx?nav=true';},100);</script>";
                            return;
                        }
                        else
                            lt_result.Text += "<script language='javascript'>setTimeout(function(){location.href='wx_mp_list.aspx';},100);</script>";
                        return;
                    }
                    catch (Exception ex)
                    {
                        lt_result.Text = ex.Message;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                comfun.ChuliException(ex, "man/Sets/wx_mp_add.cs", Session["wID"].ToString());
            }
        }
    }
}