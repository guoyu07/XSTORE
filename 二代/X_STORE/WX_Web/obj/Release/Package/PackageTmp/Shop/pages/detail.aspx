<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>幸事多私享空间-商品详情</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/swiper.min.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/detail.css" />
    <link href="../css/layer.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height: 100%;">
        <div class="main" style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div class="banner swiper-container">
                <div class="imgWrap">
                    <img src="<%=goods_img %>" alt="">
                </div>
                <div class="swiper-pagination"></div>
            </div>
            <div class="clearfix pd3">
                <div class="l goodsName"><%=goods_name %></div>
                <div class="r goodsPrice">¥ <span><%=goods_benzhanjia %></span></div>
            </div>
            <div class="pd3 des">
                <%=goods_guige %>
            </div>
            <div class="goodsInfo pd3">
                <ul class="topic clearfix">
                    <li class="clickOn">商品详情</li>
                    <asp:Repeater runat="server" ID="zuhe_rp">
                        <ItemTemplate>
                            <li><%#Eval("子商品品名") %></li>

                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
                <dl class="goodsContent">
                    <dd class="showTime">
                        <div class="remind">
                            <p>选择一个商品后，您可以直接购买。如果还需要购买其他物品，可以先把本物品放到购物车内，然后统一付款。</p>
                        </div>
                        <%=goods_miaoshu %>
                    </dd>
                    <asp:Repeater runat="server" ID="zuhe_info">
                        <ItemTemplate>
                            <dd>
                                <%#Eval("子商品描述") %>
                            </dd>

                        </ItemTemplate>
                    </asp:Repeater>


                </dl>
            </div>




        </div>
        <span id="goods_info_id" runat="server" style="display: none"></span>
        <span id="goods_info_weizhi" runat="server" style="display: none"></span>
        <span id="goods_info_kw" runat="server" style="display: none"></span>
        <%--        <div class="cartLabel">
            <a href="../Buyer/cart.aspx">
                <span runat="server" id="cart_nums">6</span>
                <img src="../img/shoppingCart.png" alt="" />
            </a>
        </div>--%>
        <div class="cartLabel">
            <a href="../Buyer/cart.aspx">
                <span runat="server" id="cart_nums">6</span>
                <div class="circle">
                    <img src="../img/cart_on.png" alt="" />
                </div>
            </a>
        </div>
        <div class="settlement clearfix">
            <div class="priceInfo l">
                价格: ¥ <span><%=goods_benzhanjia %></span>
            </div>
            <%--           <a class="buyBtn r" href="payCenter.aspx?goods_id=<%=good_id %>">立即购买</a>--%>
            <%-- <asp:Button CssClass="buyBtn r" Style="border: none" runat="server" ID="buyNow" OnClick="buyNow_Click" Text="立即购买" />--%>
            <input type="button" runat="server" id="buy" class="buyBtn r" style="border: none;" value="立即购买" />
            <input type="button" runat="server" id="join_cart" class="addCart r" style="border: none" value="加入购物车" />
        </div>

        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/plugins/swiper.min.js"></script>
        <script src="../js/plugins/layer.js"></script>
        <script>

            $(function () {
                var mySwiper = new Swiper('.swiper-container', {
                    direction: 'horizontal',
                    loop: true,
                    autoplay: 2000,
                    autoplayDisableOnInteraction: false,
                    // 如果需要分页器
                    pagination: '.swiper-pagination',
                });
                $('.topic').on('click', 'li', function () {
                    $(this).addClass('clickOn').siblings().removeClass('clickOn');
                    var index = $(this).index();
                    $('.goodsContent dd').eq(index).addClass('showTime').siblings().removeClass('showTime');
                });
                $('#buy').on('click', function () {

                    $.ajax({
                        url: '../ashx/buynow.ashx',
                        data: {
                            addgoodsid: $('#goods_info_id').text(),
                            addgoodsweizhi: $('#goods_info_weizhi').text(),
                            addgoodskwid: $('#goods_info_kw').text()
                        },
                        type: 'get',
                        dataType: 'json',
                        success: function (result) {
                            console.log(result);
                            if (result.state == '1') {
                                console.log(1);
                                window.location.href = result.guid;
                                console.log(2);
                            }
                            else {
                                console.log(3);
                                console.log(result.info);
                            }
                        }
                    })
                })


                $('.addCart').on('click', function () {
                    var cart_nums = $('.cartLabel span').html();

                    $.ajax({
                        url: '../ashx/addcart.ashx',
                        data: {
                            addgoodsid: $('#goods_info_id').text(),
                            addgoodsweizhi: $('#goods_info_weizhi').text(),
                            addgoodskwid: $('#goods_info_kw').text()
                        },
                        type: 'get',
                        dataType: 'json',
                        success: function (result) {
                            if (result.state == '1') {
                                //layer.open({
                                //    content: result.info,
                                //    btn: ['ok'],
                                //    yes: function (index) {
                                //        $('.cartLabel span').text(parseInt(cart_nums) + 1);
                                //        layer.close(index);
                                //    }
                                //});
                                $('.cartLabel span').text(parseInt(cart_nums) + 1);
                                       layer.close(index);
                            }
                            else {
                                layer.open({
                                    content: result.info,
                                    btn: ['ok'],
                                    yes: function (index) {
                                        layer.close(index);
                                    }
                                });
                            }
                        },

                        error: function (xhr, status, error) {
                            var err = eval("(" + xhr.responseText + ")");
                            console.log(err.Message);
                        }

                    })
                })
            })
        </script>
        <script src="../../js/weui.js"></script>
        <%--        <script type="text/javascript">
            function enableButton(flag) {
                $("#join_car").attr("disabled", flag ? "" : "disabled");
            }
            $(document).ready(
            function () {
                $("#join_car").click(
                function () {
                    $.weui.toast("加入购物车成功");

                    setTimeout(function () {
                        enableButton(false);
                        location.reload();
                    },
                    1000);
                }
                );
            }
            );

        </script>--%>
    </form>
</body>
</html>
