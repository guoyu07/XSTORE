<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historyNews.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.historyNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-历史消息</title>
    <link rel="icon" href="img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/historyNews.css" />
</head>
<body>
    <form id="form1" runat="server">
        <ul>
            <asp:Repeater ID="rp_historynews" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="clearfix newStrip">
                            <div class="iconfont icon-xiaoxi l"></div>
                            <div class="l des">补货通知</div>
                            <div class="iconfont icon-gengduo1 r iconChange"></div>
                            <div class="iconfont icon-gengduo2 r iconChange"></div>
                            <p class="r info">房间号：<span><%#Eval("库位名")%></span></p>
                        </div>
                        <dl class="content">
                            <dt class="conTime">时间：<span><%#Eval("售出时间")%></span></dt>
                            <dd class="conInfo">内容：<span><%#Eval("品名")%>已经售罄了，请及时补货</span></dd>
                        </dl>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/historyNews.js"></script>
    </form>
</body>
</html>
