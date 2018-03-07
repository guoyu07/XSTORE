<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shownews.aspx.cs" Inherits="Wx_NewWeb.shownews" %>

<%@ Register Src="wxhead.ascx" TagPrefix="uc" TagName="appHeader" %> 
<%@ Register Src="wxfoot.ascx" TagPrefix="uc" TagName="appFooter" %> 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>    
   <asp:Literal ID='lt_keywords' runat='server'></asp:Literal>
    <asp:Literal ID="lt_description" runat="server"></asp:Literal>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <asp:Literal ID='lt_theme' runat='server'></asp:Literal>
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/js/fsWeixin_apps.js" type="text/javascript"

        charset="utf-8"></script>
    <script type="text/javascript" src="/js/thickbox.js"></script>
    <link href="/css/thickbox.css" rel="stylesheet" type="text/css" />
</head>
<body class="nei_body">
    <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>
    <div class="d_body">
        <div class="d_content">
            <h2>
                <asp:Literal ID="lt_proTitle" runat="server" EnableViewState="false"></asp:Literal>
            </h2>
            <h5>
                <span id="proAuthor"><asp:Literal ID="lt_proAuthor" runat="server" EnableViewState="false"></asp:Literal></span>
                <span id="proDate"><asp:Literal ID="lt_proDate" runat="server" EnableViewState="false"></asp:Literal></span>
           </h5>
            <img id="img_detail" runat="server" />
            <p>
                <asp:Literal ID="lt_newsContent" runat="server" EnableViewState="false"></asp:Literal>
            </p>
        </div>
        </div>

        <div class="d_share">

            <ul>
                <li><a onclick="document.getElementById('mcover').style.display='block';">
                    <img src="/images/icon_msg.png">发送给朋友</a></li>
                <li onclick="document.getElementById('mcover').style.display='block';"><a>
                    <img src="/images/icon_timeline.png">分享到朋友圈</a></li>
                <li><asp:literal id="lt_tel" runat="server"></asp:literal></li>
                <li><a onclick="window.scrollTo(0,0)" id="backTop">
                    <img src="/images/icon_back.png">返回顶部</a></li>
            </ul>
        </div>

      
    <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
</body>
</html>
