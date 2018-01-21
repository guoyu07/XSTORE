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
    <script src="../../js/jquery-1.11.0.min.js"></script>
    <script src="../js/weui.js"></script>
    <style type="text/css">
        .submitBtn {
            display:block;
        }
    </style>
 <script type="text/javascript">//2015年7月13日 20:55:03 微信分享JSSDK
     $(function () {
         var appid = 'wx4b52212c5d5983ad';
         wx.config({
             debug: false,// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
             appId: 'wx4b52212c5d5983ad', // 必填，公众号的唯一标识  wx4b52212c5d5983ad
             timestamp: 1421142450,
             nonceStr: '9hKgyCLgGZOgQmEI',// 必填，生成签名的随机串
             signature: '<%=jsdkSignature%>',// 必填，签名，见附录1
                jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage']
            });
            wx.ready(function () {
                //1 判断当前版本是否支持指定 JS 接口，支持批量判断
                wx.checkJsApi({
                    jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage'],

                });
                wx.onMenuShareTimeline({
                    title: '幸事多', //
                    link: "<%=url_fenxiang%>",
                    imgUrl: "http://www.x-store.com.cn/upload/201705/10/201705101124575754.jpg",
                });
                wx.onMenuShareAppMessage({
                    title: '幸事多',
                    desc: "无锡幸事多为专业跨境电商企业，产品涵盖母婴、美妆、美食、洗护、保健等各个品类......！", //
                    link: "<%=url_fenxiang%>",
                    imgUrl: "http://www.x-store.com.cn/upload/201705/10/201705101124575754.jpg",
                    type: 'link',

                });
            });
        });
    </script>


    <script type="text/javascript">

        //调用微信JS api支付
        function jsApiCall() {
            WeixinJSBridge.invoke(
            'getBrandWCPayRequest',
            <%=wxJsApiParam%>,//josn串
                    function (res) {
                        //提示支付成功//更新表
                        if (res.err_msg.indexOf("ok") > 0) {
                            var orderno = $("#hid_order").val();
                            var ordermoney = $("#hid_order1").val();
                            var openid = $(".openid_txt").val();
                           
                            $.ajax({
                           
                                type: "post", //用POST方式传输
                                dataType: "json", //数据格式:JSON
                                url: '../ashx/update_wporder.ashx', //目标地址
                                data: {
                                    orderno: orderno, ordermoney: ordermoney, openid: openid
                                },
                                success: function (data) {
                                   //  alert(data.state);
                                    if (data.state == '1') {
                                        $.weui.toast('支付成功');
                                        setTimeout(function () {
                                            location.href = "../pages/paySuccess.aspx?order="+orderno+""; 
                                        }, 1000);
                                    }
                                }
                            });
                        }
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
        <asp:HiddenField ID="hid_order1" runat="server" />
        <input type="hidden" id="openid_txt" runat="server" class="openid_txt" />
        <!-- 订单金额 -->

        <ul class="clearfix">
                        <asp:Repeater ID="car_rp" runat="server">
                <ItemTemplate>
            <li>
                    <div class="pic">
                        <img src="<%#Eval("图片路径") %>" alt="" />
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
                <input type="radio" name="payWay" checked="checked" class="l" id="wxPay"/>
                <p class="l">微信支付</p>
            </div>
            <div class="zfbPay pd3 clearfix">
                <input type="radio" name="payWay" class="l" id="zfbPay"/>
                <p class="l">支付宝支付</p>
            </div>
        </div>
        <div class="interval"></div>
        <div class="submit pd3">
            <a class="submitBtn" id="wx_submit_order" onclick="callpay()">确认支付</a>
            <a class="submitBtn" id="zfb_submitBtn" onclick="javascript:window.location.href='../pages/payWaiting.html?order=<%=order_no_val %>&money=<%=money_val %>'">确认支付</a>
        </div>
        <div class="remind">
            <p>可以选择微信或支付宝支付。选择好支付方式后，点击确认支付，付款。付完款后售货箱会自动打开，您在规定时间内取货即可</p>
        </div>
    </form>
    <script src="../js/payCenter.js"></script>
</body>
</html>
