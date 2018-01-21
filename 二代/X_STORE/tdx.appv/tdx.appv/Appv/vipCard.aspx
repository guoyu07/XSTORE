<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vipCard.aspx.cs" Inherits="tdx.appv.vipCard" %>

<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
    <asp:Literal ID='lt_keywords' runat='server'></asp:Literal>
    <asp:Literal ID='lt_description' runat='server'></asp:Literal>
    <link href="images/black/Apps_main.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <asp:Literal ID='lt_theme' runat='server'></asp:Literal>
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/fsWeixin_apps.js" type="text/javascript"></script>   
</head>
<body class="nei_body">
    <%-- <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>--%>
    <form id="form1" runat="server">
    <%--<uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>--%>
    <div class="Appcontent">
        <%--<uc1:foot2 ID="foot21" runat="server" />--%>
        <h1>
            <asp:Literal ID="lt_proTitle" runat="server" EnableViewState="false"></asp:Literal>
        </h1>
    </div>
    <div class="proImg">
        <%--<asp:Literal ID="lt_proImg" runat="server" EnableViewState="false"></asp:Literal>--%>
        <a href="" id="detailed" runat="server">
            <div class="logimg">
                <asp:Literal ID="lt_logo" runat="server"></asp:Literal>
                <div class="center">
                    &nbsp;
                    <asp:Literal ID="lt_lea" runat="server"></asp:Literal>
                </div>
                <div class="bt_left">
                    &nbsp; 会员名:<asp:Literal ID="lt_name" runat="server"></asp:Literal>
                </div>
                <div class="bt_right">
                    &nbsp; 编号:<asp:Literal ID="lt_num" runat="server"></asp:Literal>
                </div>
            </div>
        </a>
    </div>
    <div class="proTxt">
        <span class="me">
            <%--<asp:Literal ID="lt_receive" runat="server" EnableViewState="false"></asp:Literal>
        <asp:Literal ID="lt_proDes" runat="server" EnableViewState="false"></asp:Literal>--%>
        </span>
        <div class="clear1">
        </div>
    </div>
    <div class="proIng">
        <a runat="server" href="" style="display: none;" id="getCard">立即开通会员卡</a>
    </div>
    <div class="proDes">
        <h2 class='h2s'>
            <b>消费特权介绍</b></h2>
        <asp:Literal ID="lt_wa" runat="server"></asp:Literal>
    </div>
    <%--<div class="proDes">
        <h2 class='h2s'>
            <b>特权介绍</b></h2>
        <asp:Literal ID="lt_rank" runat="server" EnableViewState="false"></asp:Literal>
    </div>--%>
    <div class="proDes">
        <h2 class='h2s'>
            <b>活动介绍</b></h2>
        <asp:Literal ID="lt_active" runat="server" EnableViewState="false"></asp:Literal>
    </div>
    <div>
        <ul class='cl'>
            <asp:Literal ID="lt_foot" runat="server"></asp:Literal>
        </ul>
    </div>
    <%--  <uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>--%>
    <%-- <uc2:foot2 ID="foot22" runat="server" />--%>
    <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
    </form>
</body>
</html>

