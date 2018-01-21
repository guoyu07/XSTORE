<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kefu.aspx.cs" Inherits="Wx_NewWeb.kefu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="css/kefuchat.css" rel="stylesheet" />
    <title></title>
   
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
<meta name="apple-mobile-web-app-status-bar-style" content="default" />
<meta name="apple-mobile-web-app-capable" content="yes" /> 
    <script>
        function a()
        {
            WeixinJSBridge.call('closeWindow');
        }

    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="btn_chat">
        
    <input type="button"  id="close" onclick="a()" runat="server" value="开始与客服聊天" />
    </div>
    </form>
</body>
</html>
