<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyShare.aspx.cs" Inherits="Tuan.MyShare" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
      <title>我的分享</title>
      <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="js/jquery-1.7.2.min.js" charset="utf-8"></script> 
	<script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>
	<script type="text/javascript" src="js/menu_min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".menu ul li").menu();
    });
</script> 

</head>
<body>
<div class="container"> 
    <asp:Literal ID="Literal1" runat="server"></asp:Literal> 
</div>
<div class="copyright">红豆万花城</div>
</body>
</html>
