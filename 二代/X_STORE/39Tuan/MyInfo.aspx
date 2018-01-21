<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyInfo.aspx.cs" Inherits="Tuan.MyInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>拼好货-会员中心</title>
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
<body class="our_body">
    <div class="container">

        <div class="my_top">
            <div class="pic"><img src="images/banner.jpg" /></div>
        </div>
        <div class="my_message">
            <span>
                <%=headimg %></span>
            <b><%=name %></b>
        </div>
        <div class="titleline_our">
            <div class="wrap">
                <div class="title"><a href="MyDing.aspx"><s class="our_list01"></s>全部订单</a></div>
            </div>
        </div>
        <div class="hei_15"></div>
        <div class="titleline_our">
            <div class="wrap">
                <div class="title"><a href="MyShare.aspx"><s class="our_list03"></s>我的分享</a></div>
            </div>
        </div>
        <div class="hei_15"></div>
        <div class="titleline_our">
            <div class="wrap">
                <div class="title"><a href="MyFan.aspx"><s class="our_list03"></s>我的返利</a></div>
            </div>
        </div>
        <div class="hei_15"></div>
        <div class="titleline_our">
            <div class="wrap">
                <div class="title"><a href="MyQuan.aspx"><s class="our_list03"></s>我的优惠券</a></div>
            </div>
        </div>
        <div class="hei_15"></div>
        <div class="titleline_our">
            <div class="wrap">
                <div class="title"><a href="MyAddress.aspx"><s class="our_list02"></s>收货地址</a></div>
            </div>
        </div>
        <div class="hei_15"></div> 
    </div>
    <div class="m_15">
        <div class="copyright">红豆万花城</div>
    </div>
    <!--导航开始-->
    <div class="bott_m">
        <div class="menu_b">
            <ul>
                <li><a href="Homepage.aspx">
                    <div class="home"><b></b></div>
                    <div>首页</div>
                </a></li>
                <li><a href="ListView.aspx">
                    <div class="list"><b></b></div>
                    <div>类别</div>
                </a></li>
                <li><a href="ShopCar.aspx">
                    <div class="trolley"><b></b></div>
                    <div>购物车</div>
                </a></li>
                <li class="on"><a href="MyInfo.aspx">
                    <div class="user"><b></b></div>
                    <div>会员</div>
                </a></li>
            </ul>
        </div>
    </div>
    <!--导航结束-->
</body>
</html>
