<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="honor_list.aspx.cs" Inherits="tdx.appv.honor_list" %>
<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %> 
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %> 
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
<asp:Literal ID="lt_keywords" runat="server"></asp:Literal>
<asp:Literal ID="lt_description" runat="server"></asp:Literal>
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" /> 
<asp:Literal ID="lt_theme" runat="server"></asp:Literal> 
<script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script> 
<script language="javascript" src="/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>
</head>

<body> 
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>
    <div class="Appcontent">
        <h1> 欢迎来到<asp:Literal ID="lt_nichen" runat="server"></asp:Literal>微网站 </h1>
        <p>您可以点击下列图标进行操作</p>  
    </div>
    <div class="Appcontent">  
     <div id="Div_prolist">
        <asp:Literal ID="lt_prolist" runat="server" EnableViewState ="false" ></asp:Literal>
     </div>
     <asp:Literal ID="lt_prolist_more" runat="server" EnableViewState="false" ></asp:Literal>
  
<uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</body>
</html>
