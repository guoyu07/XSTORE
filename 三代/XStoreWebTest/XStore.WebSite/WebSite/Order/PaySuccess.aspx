<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaySuccess.aspx.cs" Inherits="XStore.WebSite.WebSite.Order.PaySuccess" %>
<%@ Import Namespace="XStore.Entity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%:Title %></title>
    <meta name="viewport" charset="UTF-8" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link rel="icon" href="/Content/Icon/logo.png" type="image/x-icon" />
    <%: System.Web.Optimization.Styles.Render("~/bundles/CommonStyle","~/bundles/paysuccess/css")%>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/CommonJs","~/bundles/weui/js","~/bundles/paysuccess/js")%>
    <script type="text/javascript">
        $(function () {
            $("#progress_bar").myProgress({ speed: 30000, percent: 100 });
            setTimeout('delayer()', 3000);

        });
        function delayer() {
            $.ajax({
                url: '<%=Constant.ApiDic%>'+'CheckOrderState.ashx',
                type: 'GET',
                success: function (response) {
                    var jsonData = $.parseJSON(response);
                    if (jsonData.success) {
                        if (jsonData.pay && jsonData.deliver) {
                            window.location.href = '<%=Constant.OrderDic+"PaySuccess.aspx"%>';
                        }
                        else {
                            window.location.href = '<%=Constant.OrderDic%>' + "PayFail.aspx";
                        }
                    }
                    else {
                        system_alert(jsonData.message);
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
