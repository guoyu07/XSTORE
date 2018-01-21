<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Tuan.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>拼好货</title>
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
<!--广告轮播图片-->
<div class="banner">
	<div style="-webkit-transform:translate3d(0,0,0);">
		<div id="banner_box" class="box_swipe">
			<ul>
			<%=img %>

			</ul>
			<ol>
				<%=imgli %>
			</ol> 
		</div>
	</div>
</div>
<script type="text/javascript">
    $(function () {
        new Swipe(document.getElementById('banner_box'), {
            speed: 500,
            auto: 3000,
            callback: function () {
                var lis = $(this.element).next("ol").children();
                lis.removeClass("on").eq(this.index).addClass("on");
            }
        });
    });
</script>
<%=infomation %>

<div class="m_15"><div class="copyright">红豆万花城</div></div>
<!--导航开始-->
<div class="bott">
	<div class="menu_b">
		<ul>
			<li class="on"><a href="HomePage.aspx"><div class="home"><b></b></div><div>首页</div></a></li>
			<li><a href="ListView.aspx"><div class="list"><b></b></div><div>类别</div></a></li>
			<li><a href="ShopCar.aspx"><div class="trolley"><b></b></div><div>购物车</div></a></li>
			<li><a href="MyInfo.aspx"><div class="user"><b></b></div><div>会员</div></a></li>
		</ul>
	</div>
</div>
<!--导航结束-->
</body>
</html>
