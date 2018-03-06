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
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/jquery.myProgress.js"></script>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
        }

        body {
            font-family: 'Microsoft YaHei UI';
        }

        .box {
            margin: 20px auto;
            width: 350px;
            border: 1px orange solid;
            min-height: 500px;
            background-color: #fff;
        }

        .top {
            width: 100%;
            background-color: #ff6600;
            min-height: 100px;
            position: relative;
        }

            .top p {
                color: #fff;
                width: 60%;
                margin-left: 15px;
                line-height: 80px;
                font-size: 16px;
            }

            .top img {
                position: absolute;
                margin-left: 70%;
                margin-top: -60px;
                width: 50px;
                height: 50px;
            }

        .middle {
            margin-top: 12px;
            background-color: #fff;
            min-height: 300px;
            width: 100%;
        }

            .middle img {
                width: 100%;
            }

            .middle p {
                width: 88%;
                margin: 0 auto;
                padding: 20px 0;
            }

        .middle2 {
            margin-top: 12px;
            background-color: #fff;
            min-height: 150px;
            width: 100%;
        }

        .gif-box {
            width: 60%;
            margin: 0 auto;
        }

        .middle2 img {
            width: 100%;
            height: auto;
            margin-bottom: 20px;
        }

        .middle2 p {
            width: 88%;
            margin: 0 auto;
            padding: 20px 0;
        }

        .bottom {
            width: 100%;
            background-color: #fff;
            margin-top: 15px;
            padding: 20px 0;
        }

            .bottom p {
                width: 80%;
                margin: 0 auto;
                font-size: 12px;
            }

        /*进度条*/
        .progress-out {
            position: relative;
            border: 1px solid #ff6600;
            background-color: #fff;
            margin: 0 auto;
        }

        .progress-in {
            position: absolute;
            height: 100%;
            width: 0%;
            border: none;
            background-color: #ff6600;
            background-image: linear-gradient(top, #ff6600 0%, #ff6600 40%, #ff6600 100%);
            background-image: -webkit-linear-gradient(top, #ff6600 0%, #ff6600 40%, #ff6600 100%);
            background-image: -moz-linear-gradient(top, #ff6600 0%, #ff6600 40%, #ff6600 100%);
            background-image: -o-linear-gradient(top, #ff6600 0%, #ff6600 40%, #ff6600 100%);
            background-image: -ms-linear-gradient(top, #ff6600 0%, #ff6600 40%, #ff6600 100%);
            text-align: center;
            color: #fff;
            z-index: 1;
        }

        .direction-left {
            left: 0;
            border-top-right-radius: 2px;
            border-bottom-right-radius: 2px;
        }

        .direction-right {
            right: 0;
            border-top-left-radius: 2px;
            border-bottom-left-radius: 2px;
        }

        .percent-show {
            position: absolute;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            color: orange;
            text-align: center;
            z-index: 2;
        }

        /*jdt*/
        .jdt {
            width: 100%;
        }

        .restart {
            display: none;
            width: 100%;
            padding-top: 95px;
        }

            .restart button {
                width: 80%;
                background-color: #ff6600;
                padding: 5px 15px;
                border: 1px solid orange;
                margin: 20px auto;
                display: block;
                color: #fff;
                cursor: pointer;
            }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#progress_bar").myProgress({ speed: 30000, percent: 100 });
            setTimeout('delayer()', 30000);

        });
        function delayer() {
            $.ajax({
                url: '../ashx/CheckOrderState.ashx',
                type: 'get',
                data: {
                    orderno: $('#order_lbl').text()
                },
                success: function (result) {
              
                    if (result === "True") {
                        window.location.href = "paySuccess.aspx?order=" + $('#order_lbl').text();
                    } else {
                        window.location.href = "payFail.aspx?order=" + $('#order_lbl').text();;
                    }
                    
                  
                }
            });

        }
        function closeBar() {

            $("#barcodediv").hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="banner clearfix">
            <div class="l">
                <span class="suc"><%=success_str %></span>

            </div>
            <img src="<%=success_link %>" alt="" class="r" />
        </div>

        <div class="total_money">
            合计：<i>¥ <span><%=pay_price %></span></i>
        </div>
        <div style="<%=undisplay %>">
            <div class="remind">
                <p>请付款后15分钟内开箱取走商品，否则将视作放弃！</p>
            </div>

        </div>
        <div style="<%=display %>">
            <div class="middle">
                <div class="jdt">
                    <h4 style="text-align: center; font-family: '微软雅黑'; color: #ff6600; margin: 20px;">开心一刻</h4>
                    <div style="margin: 15px; width: 90%; overflow-y: auto; height: 300px;">

                        <img src="../img/joker.jpg" alt="" />
                    </div>

                    <div class="progress-out" id="progress_bar">
                        <div class="percent-show"><span>0</span>%</div>
                        <div class="progress-in"></div>
                    </div>
                    <p>努力开箱中...</p>

                </div>
                <div class="restart">
                    <a class="tel" href="tel:400-880-2482">
                        <div class="telWrap">
                            <div class="telContent clearfix">
                                <span class="l">如开箱失败，请拨打客服电话</span>
                                <br />
                                <img src="../img/tel.png" class="l" alt="" />

                                <span class="l"><em>400-880-2482</em></span>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div id="barcodediv" style="<%=undisplay %>">
        <div class="qrcode" style="display: block; width:100%;height:100%; position:fixed; top:0px; left:0px;">
            <img src="../images/1.jpg" style=" width:100%;height:100%; "/>
<%--            <img src="../img/qrcode.jpg" alt="" />--%>
            <div style="position:absolute; top:10px; right:10px; font-size:24px;"><a href="javascript:void(0);"  onclick="closeBar();">X</a></div>
        </div>
            </div>
        <asp:Label runat="server" ID="order_lbl" Style="display: none"></asp:Label>
        <asp:Label runat="server" ID="pay_time" Style="display: none"></asp:Label>
        <asp:Label runat="server" ID="state_lbl" Style="display: none"></asp:Label>
        <input type="hidden" id="mac_input" runat="server" class="mac_input" />

    </form>
    <script src="../js/plugins/zepto.min.js"></script>
    <script src="../js/plugins/layer.js"></script>
    <script type="text/javascript">
      
    </script>
</body>
</html>
