<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liuyan.aspx.cs" Inherits="Wx_NewWeb.Message.Liuyan" %>


<%@ Register Src="WeixinHeads.ascx" TagPrefix="uc" TagName="appHeader" %>
<%@ Register Src="wxfoots.ascx" TagPrefix="uc" TagName="appFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
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

    <link href="../../css/tanchudiv.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
</head>
<body class="liu_body">
    <form id="form1" runat="server">
        <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>
        <div id="fenxiang" class="hidefenxiang">
            <img src="images/icon_guide.png" />
        </div>
        <div id="bj" class="hidebjclass"></div>
        <div class="d_body">
            <div class="d_content">
                <div class="box box_shadow">
                    <div class="box_padd">
                        <%-- <input type="text" placeholder="点这里发布你信息！" class="release" />--%>
                        <div class="release">点这里给我们留言！</div>
                    </div>
                </div>
                <div class="box box_shadow about_us">
                    <div class="box_padd">
                        迎着朝阳，一路向东，奔腾到海。各种新奇、新潮微应用介绍。各种微案例。各路微创介绍。
                    </div>
                </div>
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
        
            <div class="theme-popover"> 
                <div class="theme-poptit  clear">
                    <a href="javascript:;" title="关闭" class="close">取消</a>
                    <span>发表信息</span><asp:Button ID="btn_fb" runat="server" OnClick="btn_fabu_Click" Text="发表信息" />
                </div>
                <div class="theme-popbod dform">

                    <textarea id="txt_fabiao" runat="server" cols="20" rows="5" name="txt_fabiao"></textarea>

                </div>
            </div>
       
        <%-- 弹出发表div Ending --%>


      
        <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
    </form>

</body>
</html>

