<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="tdx.appv.cart" %>
<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %> 
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %> 
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
<meta name="keywords" content="<asp:Literal ID='lt_keywords' runat='server'></asp:Literal>">
<meta name="description" content="<asp:Literal ID='lt_description' runat='server'></asp:Literal>">
<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" /> 
<link rel="stylesheet" type="text/css" href="/Appv/images/<asp:Literal ID='lt_theme' runat='server'></asp:Literal>/apps_main.css" />  
<script language="javascript" src="/Appv/js/jquery-1.10.2.min.js" charset="utf-8"></script> 
<link rel="stylesheet" href="/Appv/js/jquery.mobile-1.3.2.min.css" /> 
<script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script> 
<script language="javascript" src="/Appv/js/jquery.mobile-1.3.2.min.js"></script>
</head>

<body class="nei_body"> 
  <form id="form1" runat="server" >
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>  
    <div class="Appcontent"> 
       <h1>  购物车</h1>
       <div id="Div_prolist">
         	<asp:Literal ID="lt_goodlist" runat="server" EnableViewState="False" ></asp:Literal>
             <div class="contSend">	
         	    <p>收货人</p>
         	    <p><input type="text" id="txtSHR" name="txtSHR" value="" runat="server" enableviewstate="false"/></p>
         	    <p>地 址</p>
         	    <p><input type="text" id="txtDZ" name="txtDZ" value=""  runat="server" enableviewstate="false"/></p>
         	    <p>电 话</p>
         	    <p><input type="text" id="txtTel" name="txtTel" value=""  runat="server" enableviewstate="false"/></p> 
         	    <p>备 注</p>
         	    <p>
         	        <textarea id="txtDes" name="txtDes"  runat="server" enableviewstate="false"></textarea>
         	    </p>
         	    <p><span class="rb"><asp:Literal ID="lt_msg" runat="server" ></asp:Literal></span></p>  
             </div> 
             <div class="contSend">
         	        <asp:Button ID="btn_oderCart_true" CssClass ="btn_oderCart" Text = " 确定订单 " runat=server OnClick="Button2_Click" /> 
         	        <asp:Button ID="btn_oderCart_false" CssClass ="btn_jxgw" Text = " 继续购物 " runat=server OnClick="Button3_Click" />  
             </div>
       </div>
 </div> 
 <uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</form>
</body>
</html>
