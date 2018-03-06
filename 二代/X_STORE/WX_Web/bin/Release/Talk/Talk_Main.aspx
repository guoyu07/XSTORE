<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Talk_Main.aspx.cs" Inherits="Wx_NewWeb.Talk.Talk_Main" %>

<%@ Register TagPrefix="uc" TagName="appfooter_1_1" Src="~/Shop/shopfoots.ascx" %>
<%@ Register Src="~/Talk/shopfootsNew.ascx" TagPrefix="uc" TagName="shopfootsNew" %>


<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <meta content="yes" name="apple-mobile-web-app-capable" />
    <meta content="black" name="apple-mobile-web-app-status-bar-style" />
    <meta content="telephone=no" name="format-detection" />
    <meta name="baidu-site-verification" content="t7oDT96Amk" />
    <title>幸事多-微社区</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_bbs.css" rel="stylesheet" type="text/css" />
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
            <span class="u-hd-tit">微社区</span>
            <div class="u-hd-right f-right">
                <a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
            </div>
        </header>-->

        <div class="t_head">
            <div class="wrap">
                <div class="back"><i class="icons"></i></div>
                <h3 class="title">微社区</h3>
                <div class="home_tb"><i class="icons"></i></div>
            </div>
        </div>
        <!--头部结束-->

        <!--头部banner图片开始-->
        <div class="banner_s_top">
            <div class="price_sc">
                <div id="banner_box" class="box_swipe">
                    <ul>
                        <asp:Repeater ID="imgList" runat="server">
                            <ItemTemplate>
                                <%--                                <li><a href='<%#GetBH(Eval("url"))==""?"#":"Talk_Detail.aspx?BH="+GetBH(Eval("url"))%>'>--%>
                                <li><a href='<%#Eval("url")%>'>
                                    <img src='<%#Utils.GetGPICTURE(Eval("pic"))%>' alt="2" style="width: 100%" />
                                </a>
                                </li>

                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <ol>
                        <li class="on"></li>
                        <asp:Literal runat="server" ID="showNumber"></asp:Literal>
                    </ol>

                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    new Swipe(document.getElementById('banner_box'), {
                        speed: 500,
                        auto: 3000,
                        callback: function () {
                            var lis = $(this.element).next("ol").children();
                            lis.removeClass("on").eq(this.index).addClass("on");
                        }
                    });
                });
            </script>
        </div>
        <!--头部banner图片结束-->
        <!--中间类别图开始-->
        <div class="main_bbs_m clear">
            <ul class="pf_tab">
                <%--                <li><a href="Talk_Detail.aspx?BH=<%=LeftBH%>">--%>
                <li><a href="<%=LeftBH%>">
                    <img src="<%=LeftImg%>" /></a></li>
                <%--                <li><a href="Talk_Detail.aspx?BH=<%=RightBH%>">--%>
                <li><a href="<%=RightBH%>">
                    <img src="<%=RightImg%>" /></a></li>
            </ul>
        </div>
        <!--中间类别图结束-->
        <!--正文开始-->
        <div class="main_bbs_list">
            <ul class="bbs_list">

                <asp:Repeater ID="TalkType" runat="server">
                    <ItemTemplate>
                        <li class=" border_b">
                            <div class="wrap">
                                <div class="item ">
                                    <div class="s_pic">
                                        <a href="Talk_List.aspx?cno=<%#Eval("类别编号")%>">
                                            <img src="<%#Eval("图片")%>" /></a>
                                    </div>
                                    <a class="title_bbs" href="Talk_List.aspx?cno=<%#Eval("类别编号")%>">【<%#Eval("类别名")%>】</a>
                                    <div class="s_row bbs_c"><span>主题</span><%#Eval("主题")%><span>帖数</span><%#Eval("发帖数")%></div>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>



            </ul>

        </div>
        <div class="more"><a href="#">没有更多了</a></div>
        <!--正文结束-->

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
