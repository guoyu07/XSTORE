<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payCenter.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.payCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>幸事多私享空间-支付中心</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/payCenter.css" />
    <%--    <script src="../js/vconsole.min.js"></script>--%>
    <script src="../../js/jquery-1.11.0.min.js"></script>
    <script src="../js/weui.js"></script>
    <style type="text/css">
        .submitBtn {
            display: block;
        }
    </style>
    <script type="text/javascript">
        

    </script>
    <script type="text/javascript">//2015年7月13日 20:55:03 微信分享JSSDK
        $(function () {
            window.addEventListener("popstate", function (e) {
                window.location.href = "../Buyer/mySpace.aspx";
            }, false);
       
            setInterval('checkOrder()', 5000);
        });
        function checkOrder(){
            var order = $("#hid_order").val();
            var xmlhttp;
            if (window.XMLHttpRequest) {
                // IE7+, Firefox, Chrome, Opera, Safari 浏览器执行代码
                xmlhttp = new XMLHttpRequest();
            }
            else {
                // IE6, IE5 浏览器执行代码
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    var o = eval('(' + xmlhttp.responseText + ')');
                    if (o.state === 1) {
                        window.location.href = "../pages/paySuccess.aspx?order=" + order + "";
                    } 
                }
            }
            xmlhttp.open("GET", "../ashx/AlipayEnter.ashx?order=" + order + "", true);
            xmlhttp.send();
        
        }
    </script>

    <script type="text/javascript">
        //调用微信JS api支付
        function jsApiCall() {
            WeixinJSBridge.invoke(
            'getBrandWCPayRequest',
            <%=wxJsApiParam%>,//josn串
            function (res) {
               
            });
        }
        function callpay() {
            if (typeof WeixinJSBridge == "undefined") {
                if (document.addEventListener) {
                    document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
                }
                else if (document.attachEvent) {
                    document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                    document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
                }
            }
            else {
                jsApiCall();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- 支付方式 -->
        <asp:HiddenField ID="hid_order" runat="server" />
        <!-- 订单金额 -->

        <ul class="clearfix">
            <asp:Repeater ID="car_rp" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="pic">
                            <img src="<%#string.IsNullOrEmpty(Eval("图片路径").ObjToStr())?no_img:Eval("图片路径").ObjToStr() %>" alt="" />
                            <p class="goodsName over"><%#Eval("品名") %></p>
                        </div>
                        <div class="price">¥ <span><%#Eval("单价") %></span></div>

                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="interval"></div>
        <div class="total_money pd3 clearfix">
            <div class="l">合计：</div>
            <div class="r">¥ <span runat="server" id="total_price"></span></div>
        </div>
        <div class="interval"></div>
        <div class="payWay clearfix">
            <div class="wxPay pd3 clearfix">
                <input type="radio" name="payWay" checked="checked" class="l" id="wxPay" />
                <p class="l">微信支付</p>
            </div>
            <div class="zfbPay pd3 clearfix">
                <input type="radio" name="payWay" class="l" id="zfbPay" />
                <p class="l">支付宝支付</p>
            </div>
        </div>
        <div class="interval"></div>
        <div class="submit pd3">
            <a class="submitBtn" id="wx_submit_order" onclick="callpay()">确认支付</a>
            <a class="submitBtn" id="zfb_submitBtn" onclick="javascript:window.location.href='../pages/payWaiting.html?order=<%=OrderNo %>&money=<%=TotalPrice %>'">确认支付</a>
        </div>
        <div class="remind">
            <p>可以选择微信或支付宝支付。选择好支付方式后，点击确认支付，付款。付完款后售货箱会自动打开，您在规定时间内取货即可</p>
        </div>
    </form>
    <script src="../js/payCenter.js"></script>
</body>
</html>
