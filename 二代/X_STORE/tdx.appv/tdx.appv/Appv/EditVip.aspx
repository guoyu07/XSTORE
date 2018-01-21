<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVip.aspx.cs" Inherits="tdx.appv.EditVip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>

    <link href="images/black/Apps_main.css" rel="stylesheet" type="text/css" />
    <link href="images/black/Apps_main.css" rel="stylesheet" type="text/css" />
    <link href="images/cssIndex/black/Apps_main.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <style type="text/css">
    
    </style>
   <%-- h2{
			width: 96%;
			line-height: 35px;
			margin: 0 auto; 
			font-size: 16px; 
			font-weight:normal;
			border-bottom:1px solid #999;
			color:Gray;
			margin-left:20px;
		}--%>
     <%-- html,body,div,p,table,td,ul,li,h2,h3,h4,h5,h6,h7{margin:0;padding:0;font-size:14px;font-weight: normal;line-height: 12px;}--%>
</head>
<body>
    <form id="form1" runat="server">
    <h2>
    <strong>会员编辑</strong></h2>
    <div>
    <div class="duiqi">
     会员名&nbsp;<input name="M_name" id="M_name" class="px_txt"  runat="server" type="text" />
     &nbsp;<span class="rb">*</span>
    </div>
    <div class="duiqi">
     手机号&nbsp;<input name="M_mobile" id="M_mobile" class="px_txt" runat="server" type="text" />
     &nbsp;<span class="rb">*</span>
    </div>
    <div class="duiqi">
    邮&nbsp;&nbsp; 箱 &nbsp;<input name="M_mail" id="M_mail" class="px_txt" runat="server" type="text" />
    </div>
    <div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input name="btn_save" class="btnGreen" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                                    value=" 保 存 " type="button">
    </div>
    </div>
    </form>
    <p>
&nbsp;</p>
</body>
</html>
