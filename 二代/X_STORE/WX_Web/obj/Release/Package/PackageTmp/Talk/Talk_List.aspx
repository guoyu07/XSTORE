<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Talk_List.aspx.cs" Inherits="Wx_NewWeb.Talk.Talk_List" %>

<%@ Register TagPrefix="uc" TagName="appFooter_1" Src="~/Shop/shopfoots.ascx" %>
<%@ Register TagPrefix="uc" TagName="shopfootsNew" Src="~/Talk/shopfootsNew.ascx" %>
<%@ Register src="Talk_head.ascx" tagname="Talk_head" tagprefix="uc1" %>

<!DOCTYPE html>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多-微社区列表</title>    
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
            <span class="u-hd-tit">微社区列表</span>
            <div class="u-hd-right f-right">
                <a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
            </div>
        </header>-->
        <uc1:Talk_head ID="Talk_head1" runat="server" />
<%--        <div class="t_head">
            <div class="wrap">
                <div class="back"><i class="icons"></i></div>
                <h3 class="title">微社区列表</h3>
                
                <div class="home_tb"><i class="icons"></i></div>
            </div>
        </div>--%>
        <!--头部结束-->

        <!--主题头部开始-->
        <div class="style_bbs_list top_50">
            <div class="bbs_list">
                <div class="">
                    <div class="wrap">
                        <div class="item">
                            <div class="s_pic">
                                <a href="#">
                                    <img src="<%=图片 %>" /></a>
                            </div>
                            <a class="title_bbs" href="#">【<%=名称 %>】</a>
                            <div class="s_row bbs_c"><span>主题</span><%=主题数 %><span>帖数</span><%=帖数%></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--主题头部结束-->
        <!--正文列表开始-->

        <asp:Repeater ID="TalkTieZi" runat="server" OnItemDataBound="TalkTieZi_ItemDataBound">
            <ItemTemplate>
                <div class="hei_15"></div>
                <div class="list_c">
                    <div class="review_t wrap">
                        <div class="border_b">
                            <div class="bbs_top clear">
                                <img src="<%#Eval("wx头像")%>">
                                <div class="bbs_pp">
                                    <span class="pl_name"><%#Eval("wx昵称")%></span>
                                    <span class="pl_time"><%#Eval("创建时间","{0:yyyy-MM-dd}")%></span>
                                </div>
                            </div>
                            <div class="zt_ti">
                            	<span><%#Getthem(Eval("类别号").ToString())%></span><a class="bbs_title " href="Talk_Detail.aspx?BH=<%#Eval("编号") %>"><%#Eval("名称")%></a>
                            </div>
                            <div class="dz_hf">
                                <!--<span class="dz"><i class="icons"></i>0</span>-->
                                <span class="hf"><i class="icons"></i><%#GetTalknum(Eval("id").ToString())%></span>
                            </div>
                        </div>
                    </div>
                    <ul class="review_l wrap">
                        <asp:Repeater ID="ListGoods" runat="server">
                            <ItemTemplate>
                                <li class="border_bottom">
                                    <div class="bbs_cc clear">
                                        <img src="<%#Eval("wx头像")%>" />
                                        <div class="bbs_pp">
                                            <span class="pl_name"><%#Eval("wx昵称")%></span>
                                            <span class="pl_con"><%#Eval("评论内容")%></span>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="more"><a href="Talk_Detail.aspx?BH=<%#Eval("编号") %>">查看全部<%#GetTalknum(Eval("id").ToString())%>条回复</a></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>




        <!--正文列表结束-->
        <div class="more bot_80"><a href="#">没有更多了</a></div>
        <!--正文结束-->
        <!--底部发帖按钮开始-->
        <div class="bott_fix">
            <div class="btn_ft"><a href="Talk_FaTie.aspx?cno=<%=类别号%>"><i class="icons"></i><span>发帖</span></a></div>
        </div>
        <!--底部发帖按钮结束-->

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
            <uc:shopfootsNew ID="appFooter1"  runat="server" EnableViewState="False" />
        </div>--%>

        <script src="js/weui.js"></script>
    </form>
</body>
</html>

