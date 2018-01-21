<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingInfo.aspx.cs" Inherits="Tuan.DingInfo" %>

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
<script type="text/javascript">
    $(document).ready(function () {
        $(".menu ul li").menu();
       
    });
    window.onload = function () {
       
      
        window.document.getElementById("per").style.width = '<%=nowper%>';
        refreshcount();
        setInterval("refreshcount()", 1000);
        
    }
    
        
    
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
      

    </script>
   <%-- 2015.6.26 弹出div显示文字  显示几秒钟后隐藏 --%>
    <script type="text/javascript">
        $(function () {
            setTimeout(topdiv,1500);
        });
        function topdiv()
        { 
            $("#topdiv").hide();
        }
    </script>
    <%--  2015年6月29日20:15:28 新增再来一单按钮--%>
    <script>
        function go() {
            var openid = '<%=openid%>';
                    var price = '<%=bzprice%>' * 100;
                    var spbh = '<%=spbh%>';
                    var otheropenid = '<%=otheropenid%>';
            var otherddbh = '<%=otherddbh%>';
            var unionid = '<%=unionid%>';
            window.location = ("PageBuy.aspx?openid=" + openid + "&price=" + price + "&spbh=" + spbh + "&otheropenid=" + otheropenid + "&otherddbh=" + otherddbh + "&unionid=" + unionid + "&showwxpaytitle=1");
                }


    </script>
</head>
<body>
<!--广告轮播图片 <span>感谢您购买，赶快分享到朋友圈，邀请好友购买！</span>-->
     <div id="topdiv" ><img src="/images/icon_guide.png"></div>
    <a href="javascript:;" onclick="document.getElementById('mcover').style.display = 'none';"> <div id="mcover"><img src="/images/icon_guide.png"></div></a>
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
<div class="banner_title">
	<div class="wrap padd_10">
    	<div class="title"><%=title %></div>
        <div class="price clear">
            <div class="peo fl">已有<Label id="labelcount"></Label>人购买</div>
           <strong>¥ <%=bzprice %></strong><em>¥ <%=scprice %></em></div>
    </div>
</div>
<div class="hei_15"></div>
<!--广告轮播图片结束-->
<div class="num padd_10">
	<div class="wrap dj-xm">
    	<div class="price clear">
            	<span class="pr_01">¥<%=bzprice %></span>
                <span class="pr_02">¥<%=sanprice %></span>
                <span class="pr_03">¥<%=jiuprice %></span>
		</div>
    	<div class="progress">
        	<div class="progress-red"><!--<i class="p-left"></i>-->
            	<div class="progress-w" id="per"><i class="p-right"><%=nowcount %></i></div>
        	</div>
        </div>
		<div class="count clear">
			<span class="cou_01">1</span>
			<span class="cou_02">3</span>
			<span class="cou_03">9</span>
		</div> 
    </div>
</div>
<div class="hei_15"></div>
<div class="menu">
			<ul>
				<li class="list_cj"><a href="javascript:;">我的团员</a>
					<ul class="contt clear" style="display:block;">
                        <asp:Literal ID="tuanyuan" runat="server"></asp:Literal>
						<%--<li><img src="images/03.jpg"  /><span class="s02">王小花</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">潘小树</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">宣小草</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">王小花</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">潘小树</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">宣小草</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">王小花</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">潘小树</span></li>
						<li><img src="images/03.jpg"  /><span class="s02">宣小草</span></li>--%>
					</ul>				
				</li>
                 <li class="hei_15"></li>
                 <li class="list_yy"><a href="javascript:;">活动规则</a>
                <ul class="cont clear pirse">
                    		<li><p>1、请遵守本团规则 </p><p>2、邀请2位好友组成3人团就可获得3人团购价<strong><%=sanprice %></strong>元</p><p>3、邀请8位好友组成9人团就可获得9人团购价<strong><%=jiuprice %></strong>元</p><p>4、最终解释权归本站所有</p></li>
					</ul>	
               </li>
                <li class="hei_15"></li>
				<li class="list_aq"><a href="javascript:;"  >商品详情</a>
					<ul class="cont clear"  >
                    	<li><%=spxq %></li>
					</ul>				
				</li>
                <li class="hei_15"></li>
				<li class="list_hj"><a href="javascript:;">商品特色</a>
					<ul class="cont clear">
                    	<li>
                    	<%=spts %>
                        </li>
					</ul>					
				</li>
                 <li class="hei_15"></li>
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
               </li>
			</ul>
</div>

  
<div class="m_15">  <div class ="copyright">PoweredBy <a href="http://hongdou.creatrue.net/appv/index.aspx?wwx=gh_4891e4667327">红豆万花城</a></div></div>
<div class="bott">
	<div class="wrap padd_10 clear">
    	<%--<div class="price fl"><strong>¥ <%=bzprice %></strong><em>¥ <%=scprice %></em></div>--%>
       
        <div class="buy_btt fr buy_bt02"><input type="button" id="buy" runat="server" onclick="go()"  value="再来一单" /></div>
         <div class="buy_btt fl buy_bt01"><input type="button" id="ding" runat="server" onclick="document.getElementById('mcover').style.display = 'block';" value="分享" /></div>
    </div>
</div>
</body>
</html>
