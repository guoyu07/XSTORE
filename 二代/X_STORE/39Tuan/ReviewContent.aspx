<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewContent.aspx.cs" Inherits="Wx_NewWeb.Message.ReviewContent" %>

<%@ Register Src="WeixinHeads.ascx" TagPrefix="uc" TagName="appHeader" %>
<%@ Register Src="wxfoots.ascx" TagPrefix="uc" TagName="appFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
    <asp:Literal ID="lt_keywords" runat="server"></asp:Literal>
    <asp:Literal ID="lt_description" runat="server"></asp:Literal>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <asp:Literal ID='lt_theme' runat='server'></asp:Literal>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/review.css" rel="stylesheet" type="text/css" />

     <script src="../../js/fsWeixin_apps.js" type="text/javascript"></script>
    <link href="../../css/tanchudiv.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function zan(nid, uid) {
            var iszan;
            var i = $("#" + nid).text();

            if (i == "已赞") {
                iszan = "True";
            }
            if (i == "赞") {
                iszan = "False";
            }

            $.ajax({
                type: "POST",
                url: "zan.ashx",
                data: { iszan: iszan, nid: nid, uid: uid },
                success: function (result) {

                    if (result == "True") {

                        $("#" + nid).html("已赞");

                        $("#s" + nid).removeClass("zan").addClass("old_zan");

                        if (parseInt($("#zan" + nid).html()) > 0) {
                            $("#zan" + nid).html(parseInt($("#zan" + nid).html()) + 1);
                        } else {
                            $("#ul" + nid).before("<div id=div" + nid + " class=\"num_zan clear\"><s class='old_zan'></s><span id=zan" + nid + ">1</span><span>人觉得很赞</span></div>");
                        }
                    }
                    if (result == "False") {
                        $("#" + nid).html("赞");

                        $("#s" + nid).removeClass("old_zan").addClass("zan");

                        if (parseInt($("#zan" + nid).html()) > 0) {

                            if (parseInt($("#zan" + nid).html()) == 1) {

                                $("#div" + nid).remove();

                            } else {

                                $("#zan" + nid).html(parseInt($("#zan" + nid).html()) - 1);
                            }
                        } else {

                            $("#ul" + nid).before("");

                        }
                    }

                },
                error: function (e) {
                    alert(e);
                }
            });
        }

        function pinglun(nid, uid) {

            $("#btn_nids").val(nid);
            $("#btn_uids").val(uid);
        }
        function fenxiang() {
            $("#fenxiang").removeClass("hidefenxiang").addClass("showfenxiang");
        }
        $(function () {
            $("#fenxiang").click(function () {
                $(this).removeClass("showfenxiang").addClass("hidefenxiang");
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>
         <div id="fenxiang" class="hidefenxiang">
            <img src="images/icon_guide.png" /></div>
         <div id="bj" class="hidebjclass"></div>
    <div class="d_body">
            <div class="d_content">
                <%--<div class="box box_shadow">
                    <div class="box_padd">
                        <input type="text" placeholder="点这里发布你信息！" class="release" /> 
                    </div>
                </div>--%>
                <%--<div class="box box_shadow about_us">
                    <div class="box_padd">
                        迎着朝阳，一路向东，奔腾到海。各种新奇、新潮微应用介绍。各种微案例。各路微创介绍。
                    </div>
                </div>--%>
                <asp:Literal ID="lit_show" runat="server"></asp:Literal> 
            </div>
        </div>
        <%-- 弹出发表div begin--%>

        <script type="text/javascript">
            jQuery(document).ready(function ($) {
                $('.release').click(function () {
                    $("#bj").removeClass("hidebjclass").addClass("showbjclass");
                    $('.theme-popover').slideDown(200);
                })
                $('.theme-poptit .close').click(function () {
                    $("#bj").removeClass("showbjclass").addClass("hidebjclass");
                    $('.theme-popover').slideUp(200);
                })
            })
        </script>
         <div  class="bjclass">
        <div class="theme-popover">
            <div class="theme-poptit  clear">
                <a href="javascript:;" title="关闭" class="close">取消</a>
                <span>发表信息</span> <asp:Button ID="btn_fb" runat="server" OnClick="btn_fabu_Click" Text="发表信息" />
            </div>
            <div class="theme-popbod dform">

                <textarea   id="txt_fabiao" runat="server" cols="20" rows="5" name="txt_fabiao"></textarea>
               
               

            </div>
        </div>
 </div>
        <%-- 弹出发表div Ending --%>


       <%-- 弹出评论div begin--%>

        <script type="text/javascript">
            jQuery(document).ready(function ($) {
                $('.pinglun').click(function () {
                    $("#bj").removeClass("hidebjclass").addClass("showbjclass");
                    $('.theme-popover1').slideDown(200);
                })
                $('.theme-poptit1 .close1').click(function () {
                    $("#bj").removeClass("showbjclass").addClass("hidebjclass");
                    $('.theme-popover1').slideUp(200);
                })
            })
        </script>
         <div class="bjclass">
        <div class="theme-popover1">
            <div class="theme-poptit1  clear">
                <a href="javascript:;" title="关闭" class="close1">取消</a>
               <span>发表评论</span><asp:Button ID="btn_pinglun" runat="server" OnClick="btn_pinglun_Click" Text="发表评论" />
            </div>
            <div class="theme-popbod1 dform1">

                <textarea   id="txt_pinglun" runat="server" cols="20" rows="5" name="txt_pinglun"></textarea>
                <input type="hidden" runat="server" id="btn_nids"/><input type="hidden" runat="server" id="btn_uids" />
                

            </div>
        </div>
 </div>
        <%-- 弹出发表div Ending --%>
        <div class="d_share">

            <ul>
                 <li><a onclick="document.getElementById('mcover').style.display='block';">
                    <img src="/images/icon_msg.png">发送给朋友</a></li>
                <li onclick="document.getElementById('mcover').style.display='block';"><a>
                    <img src="/images/icon_timeline.png">分享到朋友圈</a></li>
                <li><asp:literal id="lt_tel" runat="server"></asp:literal></li>
                <li><a onclick="window.scrollTo(0,0)" id="backTop">
                    <img src="/images/icon_back.png">返回顶部</a></li>
               
                 <li><asp:literal id="lt_plus_qq1" runat="server"></asp:literal></li>
                   
                 <li><asp:literal id="lt_plus_weixin1" runat="server"></asp:literal></li>
            </ul>
        </div>

         <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
    </form>
    
</body>
</html>
