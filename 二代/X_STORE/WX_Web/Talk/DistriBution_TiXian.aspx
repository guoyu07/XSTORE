﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistriBution_TiXian.aspx.cs" Inherits="Wx_NewWeb.Talk.DistriBution_TiXian" %>

<%@ Register TagPrefix="uc" TagName="appFooter_1" Src="~/Shop/shopfoots.ascx" %>
<%@ Register TagPrefix="uc" TagName="shopfootsNew" Src="~/Talk/shopfootsNew.ascx" %>


<%@ Register src="DistriBution_head.ascx" tagname="DistriBution_head" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多-提现申请</title>
    <%--    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_bbs.css" rel="stylesheet" type="text/css" />
    <script src="js/jqurey.js" type="text/javascript"></script>--%>

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

    <script>
        function checkNum() {
            var money = $("#txt_M_psw").val();
            if (money == "")
            {
                return false;
            }
            if (isNaN(money)) {
                alert('请填写正确金额');
                return false;
            }
            else {

            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <!--头部开始-->
        <!--<header id="header" class="u-header clearfix">
            <div class="u-hd-left f-left">
                <a href="javascript:history.go(-1)" mars_sead="brand-detail-back_btn" class="J_backToPrev"><span class="u-icon i-hd-back"></span></a>
            </div>
            <span class="u-hd-tit">提现申请</span>
            <div class="u-hd-right f-right">
                <a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
            </div>
        </header>-->

        <uc1:DistriBution_head ID="DistriBution_head1" runat="server" />

         <!--头部结束-->
		<div class="top_50 hei_15_nt">
            
        </div>
        <!--正文列表开始-->
        <div class="sport wrap">

            <div class="weui_cells">
                <div class="weui_cell border_b">
                    <div class="weui_cell_bd weui_cell_primary">
                        <input class="weui_input" id="txt_M_psw" runat="server" name="name" type="text" placeholder="提现额度（必填）" />
                    </div>
                </div>
            </div>

            <div class="weui_btn_area">
                <%--                <a class="weui_btn weui_btn_primary" id="button" href="javascript:">发送</a>--%>
                <asp:LinkButton runat="server" ID="LinkButton1" Text="提交保存" OnClick="button_OnClick" OnClientClick="checkNum()" class="weui_btn weui_btn_primary" />
            </div>
        </div>
        <!--正文列表结束-->
        <!--正文结束-->
        <!--文本域的字数控制-->
        <script src="js/js_textarea.js"></script>


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

        <script src="js/weui.js"></script>
    </form>
</body>
</html>

