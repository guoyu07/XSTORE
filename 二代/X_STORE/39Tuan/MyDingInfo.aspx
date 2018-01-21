<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyDingInfo.aspx.cs" Inherits="Tuan.MyDingInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单详情</title>
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
<div class="order_more order_more_dw">
	<div class="wrap padd_10">
    	<a href="javascript:;">
    		<div class="top_a clear"><span class="name">收货人：<%=name %></span><span class="tel"><%=tel %></span></div>
    		<div class="bot_a"><span>收货地址：</span><%=address %></div>
        </a>
    </div>
</div>
<div class="hei_15"></div>
<div class="order_more">
	<div class="wrap padd_10">
      <asp:Literal ID="DingInfo" runat="server" Text=""></asp:Literal>
        
  <%--      <div class="express or_list border_b clear">
        	<span class="name">运费</span>
        	<span class="yp">¥5</span>
        </div>--%>
        <div class="message or_list border_b">
        	<span>备注：<%=bz %></span>
        </div>
        <div class="express or_list clear">
        	<span class="name">合计</span>
        	<span class="yp price">¥<%=totalprice %></span>
        </div>
    </div>
</div>
<div class="hei_15"></div>
<div class="order_more">
	<div class="wrap padd_10">
    	<div class="title">订单号：<%=ddbh %></div>
        <div class="time"><%=xdsj %></div>
        <div class="complete">完成付款</div>
    </div>
</div>    
<div class="hei_15 "></div>
</div>
<div class="copyright">红豆万花城</div>
</body>
</html>
