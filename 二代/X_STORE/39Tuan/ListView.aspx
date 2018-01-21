<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="Tuan.ListView" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>拼好货-列表页</title>
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
    <script>
        //////////2015年7月15日 10:53:55
        $(function () {
            $(".leftbj").hide();

            $("#leibie").click(function () {
                
                if ($("#pdyx").val() == "0") {
                    $('.leftbj').animate({ width: 'show', opacity: 'show' }, 500, function () { $('.leftbj').show(); });
                    $("#pdyx").val("1");
                }
                else
                {
                    $('.leftbj').animate({ width: 'hide', opacity: 'hide' }, 500, function () { $('.leftbj').hide(); });
                    $("#pdyx").val("0");
                }
            
             } );

           




        });

        function pdyx(id)
        {
            $("#" + id).css("color","#bf2b2b");
        }

</script>
    
</head>
<body>
<div class="leftbj">
    <input id="pdyx" type="hidden" value="0"/>
	<div class="left_nav">
	<ul>
<%--		<li style="border-top:none;" class="on"><span></span><a href="#">甜品类1</a></li>
		<li><span></span><a href="#">甜品类2</a></li>
		<li><span></span><a href="#">甜品类3</a></li>
		<li><span></span><a href="#">甜品类4</a></li>
		<li><span></span><a href="#">甜品类5</a></li>
		<li><span></span><a href="#">甜品类6</a></li>
		<li><span></span><a href="#">甜品类7</a></li>
		<li><span></span><a href="#">甜品类8</a></li>--%>
        <%=leibieall %>
	</ul>
</div>
</div>
<%=infomation %>
<div class="m_15"><div class="copyright">红豆万花城</div></div>
<!--导航开始-->
<div class="bott_m">
	<div class="menu_b">
		<ul>
			<li><a href="Homepage.aspx"><div class="home"><b></b></div><div>首页</div></a></li>
			<li class="on"><a href="ListView.aspx"><div class="list"><b></b></div><div>类别</div></a></li>
				<li><a href="ShopCar.aspx"><div class="trolley"><b></b></div><div>购物车</div></a></li>
			<li><a href="MyInfo.aspx"><div class="user"><b></b></div><div>会员</div></a></li>
		</ul>
	</div>
</div>
<!--导航结束-->
</body>
</html>
