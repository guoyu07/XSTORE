<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Tuan.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=title %>-拼好货</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="js/jquery-1.7.2.min.js" charset="utf-8"></script> 
	<script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>
	<script type="text/javascript" src="js/menu_min.js"></script>
<%--    <script type="text/javascript">
        // 对浏览器的UserAgent进行正则匹配，不含有微信独有标识的则为其他浏览器
        var useragent = navigator.userAgent;
        if (useragent.match(/MicroMessenger/i) != 'MicroMessenger') {
            // 这里警告框会阻塞当前页面继续加载
            alert('已禁止本次访问：您必须使用微信内置浏览器访问本页面！');
            // 以下代码是用javascript强行关闭当前页面
            var opened = window.open('about:blank', '_self');
            opened.opener = null;
            opened.close();
        }
</script>--%>
         <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script type="text/javascript">        //2015年7月13日 20:55:03 微信分享JSSDK
        $(function () {
        
        wx.config({
            debug: false,// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: "<%=appid%>", // 必填，公众号的唯一标识 wx752aa82143c09a8a
            timestamp: '<%=timestamp%>', // 必填，生成签名的时间戳
            nonceStr: '<%=nonceStr%>', // 必填，生成签名的随机串
            signature: '<%=signature%>',// 必填，签名，见附录1
            jsApiList: ['checkJsApi','onMenuShareTimeline', 'onMenuShareAppMessage']
        });     // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
   
    

            wx.ready(function () {
                //1 判断当前版本是否支持指定 JS 接口，支持批量判断
               
                wx.checkJsApi({
                    jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage'],

                });

            <%--   var link = "http://hongou.creatrue.net/tuan/index.aspx?attach=::" + '<%=spbh%>';
                var imgUrl = "http://hongou.creatrue.net/tuan/" + '<%=pic%>';--%>

            wx.onMenuShareTimeline({
                title: '<%=title%>', //
                link: "http://hongou.creatrue.net/tuan/index.aspx?attach=::"+"<%=spbh%>:"+"<%=wxid%>",
                imgUrl: "http://hongou.creatrue.net/tuan/"+"<%=picurl%>"
            });


            wx.onMenuShareAppMessage({
                title: '<%=title%>', //<%=title%>
                desc: "<%=title%>", //
                link: "http://hongou.creatrue.net/tuan/index.aspx?attach=::" + "<%=spbh%>:" + "<%=wxid%>",
                imgUrl: "http://hongou.creatrue.net/tuan/"+"<%=picurl%>",
                type: 'link',

                    });
        });
        });
    </script>

  
<script type="text/javascript">
    $(document).ready(function () {
  
        $(".menu ul li").menu();
    });
</script> 
    <script>
        function go()
        {
            var  openid='<%=openid%>';
            var price = '<%=sanprice%>' * 100;
            var ddbh = '<%=ddbh%>';
            var otheropenid = '<%=otheropenid%>';
            var otherddbh = '<%=otherddbh%>';
            var unionid = '<%=unionid%>';
            var spbh = '<%=spbh%>';
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'insertdd.ashx', //目标地址
                data: { spbh: spbh,openid:openid,price:price,ddbh:ddbh,otheropenid:otheropenid,otherddbh:otherddbh },
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    window.location = ("PageBuy.aspx?openid=" + openid + "&price=" + price + "&ddbh=" + ddbh + "&otheropenid=" + otheropenid + "&otherddbh=" + otherddbh + "&unionid=" + unionid + "&showwxpaytitle=1");
                }
            });
         
        }



    </script>
  
</head>
<body>
     <div class="container">
           
<!--广告轮播图片-->
<div class="banner">
	<div style="-webkit-transform:translate3d(0,0,0);">
		<div id="banner_box" class="box_swipe">
			<ul>
				<%=pic %>
			</ul>
			<ol>
				<%=picli %>
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
    <!--2015年6月26日AJAX刷新购买人数-->
    <script>
        function refreshcount() {

            var spbh = '<%=spbh%>';
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'RefreshPeoPle.ashx', //目标地址
                data: { spbh: spbh },
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    if (msg.length > 0) {
                        $("#labelcount").text(msg);
                    }
                    else {
                        $("#labelcount").text(0);
                    }
                }
            });
        }
        $(function () {
           
            refreshcount();
            var ding = $("#ding").val();
            var lx = '<%=lx%>';
            if (lx == "2") {
                $("#divcar").hide();
                $("#divding").removeClass("buy_btt");
                $("#divding").removeClass("buy_bt02");
                $("#divding").addClass("buy_bt2");
            }
            else {
                $("#divcar").show();
            }
            if (ding == "本团已结束") {
                $("#divding").removeClass("buy_bt");
                $("#divding").addClass("buy_bte");

            }
            setInterval("refreshcount()", 1000);
        });
     
    </script>
    <script>
        function caradd()
        {
            var spbh = '<%=spbh%>';
            var openid = '<%=openid%>';
            var danjia = '<%=sanprice%>';
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'caradd.ashx', //目标地址
                data: { spbh: spbh,openid:openid,danjia:danjia},
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    alert('加入购物车成功！');
                }
            });
        }


    </script>
<div class="banner_title">
	<div class="wrap padd_10">
    	<div class="title"><%=title %></div>
    	<div class="price clear">
            <div class="peo fl">已有<Label id="labelcount"></Label>人购买</div>
           <strong>¥ <%=sanprice %></strong><em>¥ <%=bzprice %></em></div>
    </div>
</div>

<div class="menu">
			<ul>
                <%--   <li class="hei_15"></li>
				<li class="list_hj"><a href="javascript:;">商品特色</a>
					<ul class="cont clear" style="display:block;">
                    	<li>
                    	<%=spts %>
                        </li>
					</ul>					
				</li>--%>
			   <%--<li class="hei_15"></li>
                 <li class="list_yy"><a href="javascript:;">活动规则</a>
                <ul class="cont clear pirse" >
                    	<li><p>1、请遵守本团规则 </p><p>2、邀请2位好友组成3人团就可获得3人团购价<strong><%=sanprice %></strong>元</p><p>3、邀请8位好友组成9人团就可获得9人团购价<strong><%=jiuprice %></strong>元</p><p>4、最终解释权归本站所有</p></li>
					</ul>	
               </li>--%>
                <li class="hei_15"></li>
				<li class="list_aq"><a href="javascript:;">商品详情</a>
					<ul class="cont clear" style="display:block;">
                    	<li><%=spxq %></li>
					</ul>				
				</li>
             
              <%--   <li class="hei_15"></li>
    			<li class="list_yy"><a href="javascript:;">注意事项</a>
					<ul class="cont clear">
                    <li>
                    	<%=zysx %>
                    </li>    
					</ul>				
				</li>
                <li class="hei_15"></li>
                <li class="list_yy"><a href="javascript:;">资质证明</a>
					<ul class="cont clear">
                    	<li><%=zzzm %></li>
					</ul>				
				</li>
                <li class="hei_15"></li>
                <li class="list_yy"><a href="javascript:;">品牌介绍</a>
                <ul class="cont clear">
                    	<li><%=ppjs %></li>
					</ul>	
               </li> --%>
             
			</ul>
</div>
         <!--<div class="car"><div class="gocar"><a href="ShopCar.aspx"><img src="images/shopcar.png" /></a></div></div>-->
    </div>
<div class="m_15"> <div class ="copyright">CopyRights 红豆万华城</div></div>

<div class="bott">
	<div class="wrap padd_10 clear">
    	<div class="buy_btt fr buy_bt02" id ="divcar"><input type="button" id="addcar" runat="server" onclick="caradd()" value="放入购物车" /></div>
        <div class="buy_btt fl buy_bt01" id ="divding"><input type="button" id="ding" runat="server" onclick="go()" value="立即订购" /></div>
    </div>
</div>
</body>
</html>
