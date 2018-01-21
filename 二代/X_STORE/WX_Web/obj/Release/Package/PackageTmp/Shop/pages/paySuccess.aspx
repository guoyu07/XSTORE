<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paySuccess.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.paySuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>幸事多私享空间-支付成功</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/paySuccess.css" />
    <link rel="stylesheet" href="../css/layer.css" />
<%--    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        function tuikuan(orderno) {
            if (confirm('确认此笔订单进行退款吗？')) {
                $.ajax({
                    type: "post",
                    datatype: "text",
                    url: "../ashx/tuikuan.ashx",
                    data: { orderno: orderno },
                    async: false,
                    success: function (data) {
                        alert(data);
                        window.location.href = "../buyer/myself.aspx";
                    }
                });
            }

        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="banner clearfix">
            <div class="l">
                付款成功
		
            </div>
            <img src="../img/paymentSuccessed.png" alt="" class="r" />
        </div>
        <div class="total_money">
            合计：<i>¥ <span><%=pay_price %></span></i>
        </div>
        <div class="cutDown clearfix">
            <div class="l">开箱倒计时</div>
            <div class="r countDown"></div>
        </div>
        		<div class="remind">
			<p>请付款后15分钟内开箱取走商品，否则将视作放弃！</p>
		</div>
        <div class="menu clearfix">

            <asp:Button ID="look_order" runat="server" Text="查看订单" CssClass="l" OnClick="look_order_Click" Style="background-color: #fff;" />
            <input type="button" class="r" id="open_now" disabled="disabled" style="background: #ccc; border: none;" value="立即开箱" />
        </div>
<%--        <div class="refund">
            <div class="refundBTN" onclick="tuikuan('<%=order%>')">立即申请退款</div>
        </div>--%>
                <a class="tel" href="tel:<%=telphone %>">
			<div class="telWrap">
				<div class="telContent clearfix">
					<img src="../img/tel.png" class="l" alt="" />
					<span class="l">联系前台：<em><%=telphone %></em></span>
				</div>
			</div>
		</a>
        <a class="tel" href="tel:400-880-2482">
            <div class="telWrap">
                <div class="telContent clearfix">
                    <img src="../img/tel.png" class="l" alt="" />
                    <span class="l">联系客服：<em>400-880-2482</em></span>
                </div>
            </div>
        </a>

        <a class="problem" href="problem.html">常见问题</a>

        <div class="qrcode">
            <img src="../img/qrcode.jpg" alt="" />
        </div>
        <div class="isRefund">
			<dl>
				<dd><a href="tel:<%=telphone %>" >联系前台:<span><%=telphone %></span></a></dd>
				<dd><a href="tel:400-880-2482">联系客服:<span>400-880-2482</span></a></dd>
				<dd class="toRefund"><a>去退款</a></dd>
			</dl>
		</div>
        <asp:Label runat="server" ID="order_lbl" Style="display: none"></asp:Label>
        <asp:Label runat="server" ID="pay_time" Style="display: none"></asp:Label>
        <asp:Label runat="server" ID="state_lbl" style="display:none"></asp:Label>

    </form>
    		<script src="../js/plugins/zepto.min.js"></script>
		<script src="../js/plugins/layer.js"></script>
    <script>
        $(function () {
            $.ajax({
                url: '../ashx/paySucessOpenbox.ashx',
                data: {},
                dataType: 'json',
                success: function (result) {
                    //alert(result);
                    if (result.state != 1) {
                        layer.open({
                            content: '开箱失败，请点击立即开箱',
                            time: 2
                        });
                        cutDown($('#pay_time').text());
                        $('#open_now').removeAttr('disable').css('background', '#f60');
                    };
                }
            })
            $('#open_now').on('click', function () {
                $.ajax({
                    url: '../ashx/openbox.ashx',
                    type: 'get',
                    data: {
                        orderno: $('#order_lbl').text()
                    },
                    success: function (result) {
                        layer.open({
                            content: result,
                            time: 2
                        });
                    }
                })
            });
            $('.refundBTN').on('click', function () {
                $('.isRefund').show();
            });
            $('.isRefund').on('click', function () {
                $(this).hide();
            });
            $('.isRefund dl').on('click', function (event) {
                event.stopPropagation();
            });
            $('.toRefund').on('click', function () {
                $('.isRefund').hide();
                layer.open({
                    content: '亲~真的不要了吗？',
                    btn: ['确认', '取消', ],
                    yes: function (index) {
                        layer.close(index);
                        $.ajax({
                            url: '../ashx/tuikuan.ashx',
                            type: 'get',
                            data: {
                                orderno: $('#order_lbl').text()
                            },
                            success: function (result) {
                                layer.open({
                                    content: result,
                                    time: 2
                                });
                            }
                        })
                    }
                });
            });
            var flag = true;
           // cutDown('2017-06-07 18:24:00');
            function cutDown(param) {
                $('#open_now').one('click', function () {
               //     alert(6666);
                    clearInterval(clock);
                    $(this).css('background', '#ccc');
                    $('.refundBTN').hide();
                    //var orderno = $('#order_lbl').text();
                    //applyInfo(orderno);
                });
                var clock = setInterval(function () {
                    var paramTime = dealDay(param);
                    var EndTime = new Date(paramTime);
                    var NowTime = new Date();
                    var t = EndTime.getTime() + 15 * 60 * 1000 - NowTime.getTime();
                    console.log(t);
                    if (t <= 0) {
                        clearInterval(clock);
                        $('#open_now').attr('disabled', 'disabled').css('background', '#ccc');
                        $('.refundBTN').hide();
                    } else {
                        var m = addZero(parseInt(Math.floor(t / 1000 / 60 % 60)));
                        var s = addZero(parseInt(Math.floor(t / 1000 % 60)));
                        $('.countDown').html(m + ':' + s);
                        if (flag) {
                            $('#open_now').removeAttr('disabled').css('background', '#FF6600');
                            flag = false;
                        }
                    }
                }, 1000);
            }
            function dealDay(dayTime) {
                var result = dayTime.replace(/-/g, "/");
                return result;
            }
            function addZero(num) {
                if (num < 10) {
                    num = '0' + num;
                };
                return num;
            }
        })

    </script>
</body>
</html>
