<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistriBution_Information.aspx.cs" Inherits="Wx_NewWeb.Talk.DistriBution_Information" %>

<%@ Register TagPrefix="uc" TagName="shopfootsNew" Src="~/Talk/shopfootsNew.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多-个人资料</title>
<%--    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_fx.css" rel="stylesheet" type="text/css" />
    <script src="js/jqurey.js" type="text/javascript"></script>
    <link href="css/style.css" rel="stylesheet" />--%>
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_fx.css" rel="stylesheet" type="text/css" />
    <script src="js/jqurey.js" type="text/javascript"></script>
    <!--<link rel="stylesheet" href="../style/3c30a65871.layout.min.css">-->
    <link rel="stylesheet" type="text/css" href="../style/footer.css">
    <script>        __STAT.add('head_load');</script>
        <script src="../style/562a4c0e89.jquery-2.1.0.min.js"></script>

    <!--轮播图-->
    <script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>
    <!--回顶部-->
    <script type="text/javascript" src="js/zzsc.js"></script>



    <script type="text/javascript">
        $(function () {
            $(window).toTop({
                showHeight: 100,//设置滚动高度时显示
                speed: 300 //返回顶部的速度以毫秒为单位
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
                <!--头部开始-->
        <!--<header id="header" class="u-header clearfix">
            <div class="u-hd-left f-left">
                <a href="javascript:history.go(-1)" mars_sead="brand-detail-back_btn" class="J_backToPrev"><span class="u-icon i-hd-back"></span></a>
            </div>
            <span class="u-hd-tit">个人资料</span>
            <div class="u-hd-right f-right">
                <a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
            </div>
        </header>-->
        <div class="t_head">
            <div class="wrap">
                <div class="back"><i class="icons"></i></div>
                <h3 class="title">个人资料</h3>
                <div class="home_tb"><i class="icons"></i></div>
            </div>
        </div> 
        <!--头部结束-->
		<div class="top_50"></div>
<!--个人资料头部介绍开始-->
    <div class="user_top">
        <div class="wrap">
            <div class="item">
                <div class="s_pic"><img src="images/02.jpg" /></div>
                <div class="s_row u_name">张小娴<i class="icons male"></i></div>
                <div class="s_row u_motto">15995364920</div>
            </div>
        </div>
    </div>
    <div class="hei_15"></div>
<!--个人资料头部介绍结束-->
<!--个人资料列表开始-->
	<div class="user_m">
		<ul class="user_list">
			<li class="user_09 border_b">
				<a href="14.html" class="icons wrap">
					<i class="icons"></i><span>我的订单</span>
				</a>
			</li>
			<li class="user_08 border_b">
				<a href="15.html" class="icons wrap">
					<i class="icons"></i><span>我的预定</span>
				</a>
			</li>
		</ul>
    </div>
<!--个人资料列表结束-->


        <div class="tab-content">
            <ul class="user_list">
                <li class="user_01 border_b">

                    <dl>
                        <dt><span>姓名</span></dt>
                        <dd><span>
                            <asp:Literal ID="txt_M_truename" runat="server"></asp:Literal></span></dd>
                    </dl>
                    <dl>
                        <dt><span>性别</span></dt>
                        <dd><span>
                            <asp:Literal ID="txt_M_sex" runat="server"></asp:Literal></span></dd>
                    </dl>

                    <dl>
                        <dt><span>联系电话</span></dt>
                        <dd><span>
                            <asp:Literal ID="txt_M_mobile" runat="server"></asp:Literal></span></dd>
                    </dl>
                    <dl>
                        <dt><span>卡号</span></dt>
                        <dd><span>
                            <asp:Literal ID="txt_M_card" runat="server"></asp:Literal></span></dd>
                    </dl>

                    <dl>
                        <dt><span>开户行</span></dt>
                        <dd><span>
                            <asp:Literal ID="txt_M_bank" runat="server"></asp:Literal></span></dd>
                    </dl>
                    <dl>
                        <dt><span>注册时间</span></dt>
                        <dd><span>
                            <asp:Literal ID="txt_M_regtime" runat="server"></asp:Literal></span></dd>
                    </dl>
                </li>
            </ul>
        </div>

        <div class="layout-login-area" id="footer">
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
        </div>

    </form>
</body>
</html>
