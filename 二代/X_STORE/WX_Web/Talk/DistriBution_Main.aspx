<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistriBution_Main.aspx.cs"
    Inherits="Wx_NewWeb.Talk.DistriBution_Main" %>

<%@ Register TagPrefix="uc" TagName="appFooter_1" Src="~/Shop/shopfoots.ascx" %>
<%@ Register TagPrefix="uc" TagName="shopfootsNew" Src="~/Talk/shopfootsNew.ascx" %>
<%@ Register Src="DistriBution_head.ascx" TagName="DistriBution_head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多-分销中心</title>
    <%--  <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_fx.css" rel="stylesheet" type="text/css" />
    <link href="../style/3c30a65871.layout.min.css" rel="stylesheet" />
    <script src="js/jqurey.js" type="text/javascript"></script>--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <!--<link href="css/weui.css" rel="stylesheet" type="text/css" />-->
    <link href="css/weui.css" rel="stylesheet" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />

    <link href="css/style_fx.css" rel="stylesheet" type="text/css" />

    <script src="js/jqurey.js" type="text/javascript"></script>

    <!--<link rel="stylesheet" href="../style/3c30a65871.layout.min.css">-->
    <link rel="stylesheet" type="text/css" href="../style/footer.css">

    <script>        __STAT.add('head_load');</script>

    <script src="../style/562a4c0e89.jquery-2.1.0.min.js"></script>

    <link href="css/weui.css" rel="stylesheet" />

    <script src="js/weui.js"></script>

    <!--轮播图-->

    <script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>

    <!--回顶部-->

    <script type="text/javascript" src="js/zzsc.js"></script>

    <script type="text/javascript">
        $(function () {
            $(window).toTop({
                showHeight: 100, //设置滚动高度时显示
                speed: 300 //返回顶部的速度以毫秒为单位
            });
        });
    </script>
        <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>

    <script type="text/javascript">//2015年7月13日 20:55:03 微信分享JSSDK
        $(function () {
            var appid = 'wx4b52212c5d5983ad';
            wx.config({
                debug: false,// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: 'wx4b52212c5d5983ad', // 必填，公众号的唯一标识 wx752aa82143c09a8a
                timestamp: 1421142450,
                nonceStr: '9hKgyCLgGZOgQmEI',// 必填，生成签名的随机串
                signature: '<%=jsdkSignature%>',// 必填，签名，见附录1
                jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage']
            });
            wx.ready(function () {
                //1 判断当前版本是否支持指定 JS 接口，支持批量判断
                wx.checkJsApi({
                    jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage'],

                });
                wx.onMenuShareTimeline({
                    title: '幸事多<%=nickName%>的小店', //
                    link: "<%=shareurl%>&sponsor=<%=openid%>",
                    imgUrl: "http://hdwsb.china-mail.com.cn/images/fx_logo.png",
                });
                wx.onMenuShareAppMessage({
                    title: '幸事多<%=nickName%>的小店', //
                    desc: "幸事多<%=nickName%>的小店", //
                    link: "<%=shareurl%>&sponsor=<%=openid%>",
                    imgUrl: "http://hdwsb.china-mail.com.cn/images/fx_logo.png",
                    type: 'link',

                });
            });
        });
    </script>
</head>
<body>
    <form runat="server">
        <!--头部开始-->
        <!--<header id="header" class="u-header clearfix">
            <div class="u-hd-left f-left">
                <a href="javascript:history.go(-1)" mars_sead="brand-detail-back_btn" class="J_backToPrev"><span class="u-icon i-hd-back"></span></a>
            </div>
            <span class="u-hd-tit">分销中心</span>
            <div class="u-hd-right f-right">
                <a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
            </div>
        </header>-->
        <uc1:DistriBution_head ID="DistriBution_head1" runat="server" />
        <!--头部结束-->
        <asp:HiddenField ID="myopenid" runat="server" />
        <asp:HiddenField ID="myisactive" runat="server" />
        <!--主题头部开始-->
        <asp:Repeater ID="DB_top" runat="server">
            <ItemTemplate>
                <div class="style_bbs_list top_50">
                    <div class="bbs_list">
                        <div class="bb_cc">
                            <div class="wrap">
                                <div class="item">
                                    <div class="s_pic">
                                        <a href="#">
                                            <img src="<%#Eval("wx头像") %>" /></a>
                                    </div>
                                    <a class="title_bbs" href="#">
                                        <%#Eval("wx昵称") %></a><span><%#Eval("M_isactive").ToString()=="1"?"正式分销商":""%></span>
                                    <%--                            <div class="s_row bbs_c"><span>关注时间</span>2015-04-06</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="hei_15">
                </div>
                <!--主题头部结束-->
                <!--中间开始-->
                <div class="main_fx clear">
                    <ul class="pf_tab">
                        <li class="fx_jb">
                            <div class="bg_c bg_c1">
                                <a href="DistriBution_Money.aspx?mid=<%=id%>" class="icons wrap"><i class="icons"></i>
                                    佣金<span class="price"><em>¥</em><%=Getmoney(openid)%></span></a>
                            </div>
                        </li>
                        <li class="fx_peo">
                            <div class="bg_c bg_c2">
                                <a href="DistriBution_Team.aspx?mid=<%=id%>" class="icons wrap"><i class="icons"></i>
                                    团队<span><%#Eval("team") %></span></a>
                            </div>
                        </li>
                    </ul>
                    <%--                    <div class="hei_15 hei_2">您是由【<%#Eval("Recommand") %>】推荐</div>--%>
            </ItemTemplate>
        </asp:Repeater>
        <div class="hei_15">
        </div>
        <ul class="user_list">
            <li class="user_01 border_b"><a href="DistriBution_Money.aspx?mid=<%=id%>" class="icons wrap">
                <i class="icons"></i><span>我的佣金</span> </a></li>
            <li class="user_02 border_b"><a href="DistriBution_Order.aspx?mid=<%=id%>" class="icons wrap">
                <i class="icons"></i><span>我的订单</span> </a></li>
            <li class="user_03 border_b"><a href="DistriBution_TiXianList.aspx?mid=<%=id%>" class="icons wrap">
                <i class="icons"></i><span>结算记录</span> </a></li>
            <li class="user_07 border_b"><a href="DistriBution_TiXian.aspx?mid=<%=id%>" class="icons wrap"
                class="icons wrap"><i class="icons"></i><span>提现申请</span> </a></li>
            <!--<li class="user_08 border_b">
                <a href="DistriBution_Information.aspx?mid=<%=id%>" class="icons wrap">
                    <i class="icons"></i><span>个人资料</span>
                </a>
            </li>-->
        </ul>
        <!--中间结束-->
        <!--正文开始-->
        <div class="navbar navbar-default navbar-fixed-bottom">
            <div class="container nav-current-box detail-box">
                <div class="navbar-brand2">
                    <a href="javascript:void(0);" class="btn btn-large1 btn-purple"
                        onclick="btnclick()"></a>
                </div>
            </div>
        </div>
        <!--申请成为分销商-->
        <div class="t_hf">
            <div class="sport wrap">
                <div class="weui_cells">
                    <div class="weui_cell">
                        <div class="weui_cell_bd weui_cell_primary">
                            <input class="weui_textarea" id="txt姓名" placeholder="真实姓名" type="text" />
                        </div>
                    </div>
                    <div class="weui_cell">
                        <div class="weui_cell_bd weui_cell_primary">
                            <input class="weui_textarea" id="txt手机" placeholder="手机号码" type="text" />
                        </div>
                    </div>
                </div>
                <div class="weui_btn_area">
                    <a class="weui_btn weui_btn_primary" id="button" href="javascript:" onclick="AddhuiFu()">提交</a>
                </div>
            </div>
        </div>
        <div class="sport" id="asd">
            <div class="weui_mask">
            </div>
        </div>
        <!--申请成为分销商-->

        <script type="text/javascript">

            $(function () {
                $(".t_hf").hide();
                $("#asd").hide();
                $("#asd").click(function () {
                    $(".t_hf").toggle();
                    $("#asd").toggle();
                })
                var active = $("#myisactive").val();
                if (active == -2) {
                    $("#addcar").html("申请成为分销商");
                }
                if (active == 0) {
                    $("#addcar").html("申请审核中");
                    $("#addcar").attr("onclick", "");
                }
                if (active == 1) {
                    $("#addcar").html("");
                    //$("#addcar").attr("display", "none")
                    $("#addcar").hide()
                    $("#addcar").attr("onclick", "");
                }
                if (active == -1) {
                    $("#addcar").html("审核申请未通过");

                }
            })
            function btnclick() {
                $(".t_hf").toggle();
                $("#asd").toggle();
            }

            function AddhuiFu() {
                var active = $("#myisactive").val();
                var openid = $("#myopenid").val();
                var name = $("#txt姓名").val();
                var tel = $("#txt手机").val();
                if (name == "" || tel == "") {
                    alert('请输入姓名和手机号')
                    return false;
                }
                if (jQuery.mCheck(tel, "mobile") == false) {
                    alert('请输入正确的手机号');
                    return false;
                }
                if (active == "-2") {
                    $.ajax({
                        type: "POST", //用POST方式传输
                        dataType: "text", //数据格式:JSON
                        url: 'DistriBution.ashx', //目标地址
                        data: { openidsss: openid, activesss: active, name: name, tel: tel },
                        error: function (msg) { },
                        success: function (msg) {
                            if (msg == "1") {
                                $.weui.toast('审核成功');
                                setTimeout(function () {
                                    location.reload();
                                }, 1000);
                                $("#addcar").html("申请审核中");
                                $("#addcar").attr("onclick", "");
                                $("#myisactive").val(0)
                                $(".t_hf").toggle();
                                $("#asd").toggle();
                            }
                            else {
                                $.weui.toast('提交失败');
                                setTimeout(function () {
                                    location.reload();
                                }, 1000);
                                $(".t_hf").toggle();
                                $("#asd").toggle();
                            }
                        }
                    });
                }
            }

            /*
            * 正则验证
            * @param s 验证字符串
            * @param type 验证类型 money,china,mobile等 
            * @return
            */
            jQuery.mCheck = function (s, type) {
                var objbool = false;
                var objexp = "";
                switch (type) {
                    case 'money': //金额格式,格式定义为带小数的正数，小数点后最多三位
                        objexp = "^[0-9]+[\.][0-9]{0,3}$";
                        break;
                    case 'numletter_': //英文字母和数字和下划线组成   
                        objexp = "^[0-9a-zA-Z\_]+$";
                        break;
                    case 'numletter': //英文字母和数字组成
                        objexp = "^[0-9a-zA-Z]+$";
                        break;
                    case 'numletterchina': //汉字、字母、数字组成 
                        objexp = "^[0-9a-zA-Z\u4e00-\u9fa5]+$";
                        break;
                    case 'email': //邮件地址格式 
                        objexp = "^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$";
                        break;
                    case 'tel': //固话格式 
                        objexp = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
                        break;
                    case 'mobile': //手机号码 
                        objexp = "^(13[0-9]|15[0-9]|18[0-9])([0-9]{8})$";
                        break;
                    case 'decimal': //浮点数 
                        objexp = "^[0-9]+([.][0-9]+)?$";
                        break;
                    case 'url': //网址 
                        objexp = "(http://|https://){0,1}[\w\/\.\?\&\=]+";
                        break;
                    case 'date': //日期 YYYY-MM-DD格式
                        objexp = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
                        break;
                    case 'int': //整数 
                        objexp = "^[0-9]*[1-9][0-9]*$";
                        break;
                    case 'int+': //正整数包含0
                        objexp = "^\\d+$";
                        break;
                    case 'int-': //负整数包含0
                        objexp = "^((-\\d+)|(0+))$";
                        break;
                    case 'china': //中文 
                        objexp = /^[\u0391-\uFFE5]+$/;
                        break;
                }
                var re = new RegExp(objexp);
                if (re.test(s)) {
                    return true;
                }
                else {
                    return false;
                }
            };
        </script>
        <div id="mcover" onclick="document.getElementById('mcover').style.display='';" style="display: none">
            <img src="/images/icon_guide.png">
        </div>
        <!--以下是浮于显示屏左下角的分享-->
        <div class="u-share" data-shopcart="true">
            <a mars_sead="floating-cart_btn" onclick="document.getElementById('mcover').style.display='block';"><span class="u-icon i-flow-carticon"></span><span class="u-flow-cartnum hide"></span><span class="u-flow-carttime hide"></span>
            </a>
        </div>
        <!--正文结束-->
        <%--        <div class="layout-login-area" id="footer">
            <!--<div class="layout-login">
						<span class="layout-lg-bar">528062317@qq.com </span>
						<span class="layout-new-fr"><a href="">反馈</a></span>
			     </div>-->
            <div class="layout-copyright">
                © 幸事多 版权所有
            </div>
        </div>
        <!--以下是底部样式-->
        <div style="display: block;" class="footer_bar openwebview">
            <uc:shopfootsNew ID="appFooter1" runat="server" EnableViewState="False" />
        </div>--%>

        <script src="js/weui.js"></script>

    </form>
</body>
</html>
