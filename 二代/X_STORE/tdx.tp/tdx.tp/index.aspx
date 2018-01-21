<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tdx.tp.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"
        name="viewport">
    <meta content="default" name="apple-mobile-web-app-status-bar-style">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <meta content="telephone=no" name="format-detection" />
    <title>投票</title>
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="js/vote_index.js?v=2014.4.15.3" type="text/javascript"></script>
    <link href="css/vote_index.css?v=2014.4.15.3" rel="stylesheet" type="text/css" />
</head>
<body onscroll="scroll()">
    <form id="form1" runat="server">
    <div class="vote_index_header">
        <asp:Image id="bigpic" runat="server"/>
    </div>
    <div class="vote_index_content">
        <asp:Literal ID="ListInfo" runat="server"></asp:Literal>

    </div>
    <div class="vote_index_footer">
    </div>    
     <div id="vote_imgShow"><div id="vote_imgShowBox"><img /></div></div>
    </form>
</body>
</html>
