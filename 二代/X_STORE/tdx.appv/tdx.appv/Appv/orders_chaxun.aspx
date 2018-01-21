<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orders_chaxun.aspx.cs" Inherits="tdx.appv.orders_chaxun" %>
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
<script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script> 
<script language="javascript" src="/js/fsWeixin_apps.js" type="text/javascript" charset="utf-8"></script>
</head>

<body> 
    <uc:appHeader id="appHeader1" runat="server"   EnableViewState="False"></uc:appHeader>
    <div class="Appcontent">
        <h1> 欢迎来到<asp:Literal ID="lt_nichen" runat="server"></asp:Literal>微网站 </h1>
        <p>您可以点击下列图标进行操作</p>  
    </div>
    <div class="Appcontent">     <h1>查询订单</h1>
          <div class="subleft"><img src="/images/weixin/aboutus.png" width="284" height="295" border="0"></div>
         <div class="subright">   
          <form id="form1" name="form1" runat="server" > 
          <table border="0" width="100%" cellpadding="0" cellspacing="0" >
                <tr>
                    <td  align="left"> 请输入订单号 </td>
                </tr>
                <tr>
                    <td ><textarea name="keywords" id="keywords" runat="server" cols="30"></textarea> </td>
                </tr>
                <tr>
                    <td > &nbsp; </td>
                </tr>
                <tr> 
                    <td><asp:Button ID="btn1" runat="server" onclick="btn1_Click" />  </td>
                </tr>
                <tr>
                    <td  ><p class="rb"><asp:Literal ID="lt_result" runat="server" ></asp:Literal></p></td>
                </tr>
          </table> 
          </form>
         </div> 
       </div>
     <div style="clear: both;height: 60px;"> </div>
    <div class="submenu">
        <ul>
            <li><a href="aboutus.aspx"><img src="/images/weixin/tb_aboutus.png" border="0" width="200" height="200" /></a><br />关于我们</li>
            <li><a href="contactus.aspx"><img src="/images/weixin/tb_contactus.png" border="0" width="200" height="200" /></a><br />联系我们</li>
            <li><a href="orders_chaxun.aspx"><img src="/images/weixin/tb_search.png" border="0" width="200" height="200" /></a><br />订单查询</li>
            <li><a href="feedback.aspx"><img src="/images/weixin/tb_feedback.png" border="0" width="200" height="200" /></a><br />留言反馈</li>
        </ul>
    </div> 
<uc:appFooter id="appFooter1" runat="server"   EnableViewState="False"></uc:appFooter>
</body>
</html>
