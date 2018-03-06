<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.news" %>

<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-配货系统</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/distributer.css" />
    <script src='../js/plugins/zepto.min.js'></script>
    <script src='../js/plugins/vipspa.js'></script>
    <script src="../js/plugins/vipspa-dev.js"></script>
    <script src="../js/modules/news.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <link rel="stylesheet" href="../../style/footer.css" />
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="news">
                <a class="histroyNews clearfix" href="../pages/historyNews.aspx">
                    <div class="iconfont icon-lishijilu l"></div>
                    <div class="l des">历史消息</div>
                    <div class="iconfont icon-gengduo1 r"></div>
                </a>
                <div class="interval"></div>
                <ul>
                   <asp:Repeater ID="news_rp" runat="server">
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
            </div>
        </div>

        <div style="display: block;" class="footer_bar openwebview">
            <uc:psyFooter ID="psyFooter" runat="server" EnableViewState="False"></uc:psyFooter>
        </div>


        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(3).addClass("on");

            })
        </script>

    </form>
</body>
</html>
