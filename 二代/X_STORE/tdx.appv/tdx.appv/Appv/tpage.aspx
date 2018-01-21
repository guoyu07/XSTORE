<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tpage.aspx.cs" Inherits="tdx.appv.tpage" %>
<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %> 
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %> 
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name="viewport" content="width=device-width, initial-scale=1" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
<asp:Literal ID='lt_keywords' runat='server'></asp:Literal>
<asp:Literal ID='lt_description' runat='server'></asp:Literal>
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" /> 
<asp:Literal ID="lt_theme" runat="server"></asp:Literal>
<asp:Literal ID="lt_theme1" runat="server"></asp:Literal>
<script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script> 
<script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>

<link href="images/wsite/black/wsite.css" rel="stylesheet" type="text/css" />
</head>

<body class="nei_body"> 
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>
    <div class="d_body">
    <div class="d_content">
        <h2><asp:Literal ID="lt_proTitle" runat="server" EnableViewState="false"></asp:Literal> </h2> 
        <img id="img_detail" runat="server" />
        <p>
            <asp:Literal ID="lt_newsContent" runat="server" EnableViewState="false"></asp:Literal>
        </p>
    </div>
    </div>    
<uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</body>
</html>
