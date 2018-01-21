<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Talk_Detail.aspx.cs" Inherits="Wx_NewWeb.Talk.Talk_Detail" %>
<%@ Register TagPrefix="uc" TagName="appFooter_1" Src="~/Shop/shopfoots.ascx" %>
<%@ Register TagPrefix="uc" TagName="shopfootsNew" Src="~/Talk/shopfootsNew.ascx" %>
<%@ Register src="Talk_head.ascx" tagname="Talk_head" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多-微社区详情</title>
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
    <link href="css/style_bbs.css" rel="stylesheet" type="text/css" />
    <script src="js/jqurey.js" type="text/javascript"></script>
    <!--<link rel="stylesheet" href="../style/3c30a65871.layout.min.css">-->
    <link rel="stylesheet" type="text/css" href="../style/footer.css">

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
        $(document).ready(function () {
            $(".t_hf").hide();
            $("#asd").hide();
            $("#HF").click(function () {
                $(".t_hf").toggle();
                $("#asd").toggle();
            });
            $("#asd").click(function () {
                $(".t_hf").toggle();
                $("#asd").toggle();
            })
        })
        function AddhuiFu() {
            var openid = '<%=openid%>';
                 var id = '<%=发帖表id%>';
            var textarea_jj = $("#textarea_jj").val();
            if (textarea_jj == "")
            {
                alert('请输入内容');
                return;
            }
                 $.ajax({
                     type: "POST",
                     async: false,
                     dataType: "text",
                     url: 'AddHuiFu.ashx',
                     data: { textarea_jj: textarea_jj, openid: openid, id: id },
                     beforeSend: function () {
                         $("#button").unbind("click");
                     },
                     success: function (msg) {
                         if (msg == "1") {
                             $.weui.toast('回复成功');
                             $(".t_hf").hide();
                             location.reload(true);
                         }
                     }
                 })
             }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltrHuifu" runat="server"></asp:Literal>
        <!--头部开始-->
        <!--<header id="header" class="u-header clearfix">
            <div class="u-hd-left f-left">
                <a href="javascript:history.go(-1)" mars_sead="brand-detail-back_btn" class="J_backToPrev"><span class="u-icon i-hd-back"></span></a>
            </div>
            <span class="u-hd-tit">微社区详情</span>
            <div class="u-hd-right f-right">
                <a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
            </div>
        </header>-->
        <uc1:Talk_head ID="Talk_head1" runat="server" />
        <%--<div class="t_head">
            <div class="wrap">
                <div class="back"><i class="icons"></i></div>
                <h3 class="title">微社区列表</h3>
                
                <div class="home_tb"><i class="icons"></i></div>
            </div>
        </div>--%>
        <!--头部结束-->

        <!--正文列表开始-->
        <div class="list_c top_50">
            <div class="review_t wrap">
                <div class=" ">
                    <asp:Repeater ID="TalkTieZi" runat="server">
                        <ItemTemplate>
                            <div class="bbs_top clear">
                                <img src="<%#Eval("wx头像") %>" />
                                <div class="bbs_pp">
                                    <span class="pl_name"><%#Eval("wx昵称") %></span>
                                    <span class="pl_time"><%#Eval("创建时间","{0:yyyy-MM-dd}") %></span>
                                </div>
                            </div>
                            <div class="bbs_title " ><%#Eval("名称") %> </div>
                            <div class="content_t clear">
                                <%#Eval("内容") %>
                            </div>
                            <%--                    <div class="dz_hf">
                        <span class="share"><i class="icons"></i>分享</span>
                        <span class="dz"><i class="icons"></i>6</span>
                        <span class="hf"><i class="icons"></i>8</span>
                    </div>--%>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="hei_15"></div>
            <ul class="review_c wrap">
                <asp:Repeater ID="RepeaterPingLun" runat="server">
                    <ItemTemplate>
                        <li class="border_b">
                            <div class="bbs_top clear">
                                <img src="<%#Eval("wx头像") %>" />
                                <div class="bbs_pp">
                                    <span class="pl_name"><%#Eval("wx昵称") %></span>
                                </div>
                            </div>
                            <div class="bbs_title "><%#Eval("评论内容") %> </div>
                            <div class="dz_hf hf_time clear">
                                <span class="pl_time"><%#GetTime(Eval("评论时间").ToString()) %></span>
<%--                                <span class="hf"><i class="icons"></i></span>--%>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>

        <!--正文列表结束-->
        <div class="more bot_80"><a href="#">没有更多了</a></div>
        <!--正文结束-->
        <!--底部发帖按钮开始-->
        <div class="bott_fix">
            <div class="btn_hf"><a href="#"><i class="icons"></i><span id="HF">回复</span></a></div>
        </div>
        <!--底部发帖按钮结束-->
        
        

        <!--回复-->
        <div class="t_hf">
            <div class="sport wrap">
                <div class="weui_cells">
                    <div class="weui_cell">
                        <div class="weui_cell_bd weui_cell_primary">
                            <textarea class="weui_textarea" id="textarea_jj" placeholder="说两句吧" rows="3" runat="server"></textarea>
                        </div>
                    </div>
                </div>
                <div class="weui_btn_area">
                    <a class="weui_btn weui_btn_primary" id="button" href="javascript:" onclick="AddhuiFu()">发送</a>
                </div>                                               
            </div>
        </div>
         <div class="sport" id="asd">
            <div class="weui_mask"></div>
        </div>
        <!--回复-->

  


<%--                <div class="layout-login-area" id="footer">
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

