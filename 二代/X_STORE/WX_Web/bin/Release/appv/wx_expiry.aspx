<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_expiry.aspx.cs" Inherits="Wx_NewWeb.appv.wx_expiry" %>

<%@ Register Src="wxfoot.ascx" TagPrefix="uc" TagName="appFooter" %>
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
    <asp:Literal ID="lt_theme" runat="server"></asp:Literal>
    <asp:Literal ID="lt_theme1" runat="server"></asp:Literal>
    <script language="javascript" src="../js/jquery-1.10.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="../js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>
</head>
<body class="nei_body">
    <div class="l_body">
        <div class="d_content">
            <div class="prize_content">
                <p>
                    <asp:Literal ID="lt_newsContent" runat="server"></asp:Literal>
                </p>
            </div>
        </div>
    </div>
    <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
</body>
</html>
