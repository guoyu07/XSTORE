<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myself.aspx.cs" Inherits="Wx_NewWeb.Shop.Buyer.myself" %>

<%@ Register Src="~/Shop/ascx/UserFooter.ascx" TagPrefix="uc" TagName="UserFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/buyerIndex.css" />
    <link rel="stylesheet" href="../../style/footer.css" />
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="myself">
                <div class="hasOrder" id="has" runat="server">
                    <ul class="goodsList">
                        <asp:Repeater ID="My_self" runat="server">
                            <ItemTemplate>
                                <li class="clearfix">
                                    <img class="l" src="<%#Eval("图片路径").ToString() %>" alt="" />
                                    <div class="r">
                                        <p class="goodsName">
                                            <%#Eval("品名").ToString()%>
                                        </p>
                                        <p class="price">
                                            ¥ <span><%#Eval("本站价").ToString()%></span>
                                        </p>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <span id="order_lbl" runat="server" style="display: none;"></span>
                    <div class="pd3">
                        <div class="openBox">立即开箱</div>
                    </div>
                </div>
                <div class="noOrder" id="empty" runat="server">
                    <div class="imgWrap">
                        <img src="../img/null.png" alt="" />
                    </div>
                    <p>你还没有购买过商品，暂无订单</p>
                </div>
                <a class="tel" href="tel:<%=telphone %>" style="margin-top: 0;">
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

            </div>
        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:UserFooter ID="UserFooter" runat="server" EnableViewState="False"></uc:UserFooter>
        </div>
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/plugins/vipspa.js"></script>
        <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
        <script src="../js/plugins/layer.js"></script>
        <%--        <script src="../../js/jquery-1.7.2.min.js"></script>--%>
        <script src="../js/modules/myself.js"></script>
        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(2).addClass("on");
                $(".openBox").on('click', function () {
                    $.ajax({
                        url: '../ashx/openbox.ashx',
                        data: {
                            openid: $('#order_lbl').text()
                        },
                        type: 'get',
                        success: function (result) {
                            layer.open({
                                content: result,
                                time: 2
                            })
                        }
                    })
                })
            })
        </script>

    </form>
</body>
</html>
