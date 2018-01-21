﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="tdx.appv.feedback" %>
<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %> 
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %> 
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
<asp:Literal ID='lt_keywords' runat='server'></asp:Literal>
<asp:Literal ID='lt_description' runat='server'></asp:Literal>
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" /> 
<asp:Literal ID='lt_theme' runat='server'></asp:Literal>
<script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script> 
<script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>
</head>

<body class="nei_body"> 
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>
    <div class="Appcontent">   
            <h1>信息反馈</h1> 
                  <form id="form1" name="form1" runat="server" > 
                    <div align="left">内容：</div> 
                    <div align="left">
                          <textarea cols="30" rows="10" name="txtContent" id="txtContent" runat="server" ></textarea> 
                    </div>
                    <div align="left">联系方式：</div>  
                    <div align="left">  
                          <textarea cols="30"  name="txtTel" id="txtTel" runat="server" ></textarea> 
                    </div>
                    <div align="center">
                        <p class="notice rb"><asp:Literal ID="lt_result" runat="server" ></asp:Literal></p>
                    </div>
                    <div align="center"> <asp:Button ID="btn1" runat="server" onclick="btn1_Click" CssClass="btn1" /> </div> 
                    
                  </form>
               
   </div>   
 
<uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</body>
</html>