<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Wx_NewWeb.Shop.Buyer.cart" %>

<%@ Register Src="~/Shop/ascx/UserFooter.ascx" TagPrefix="uc" TagName="UserFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/swiper.min.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../css/buyerIndex.css" />
    <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <style>
        #form1 {
            width: 100%;
            height: 100%;
        }
        #cart_id {
            display:none;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="cart">

                <div class="hasGoods" id="has" runat="server">
                    <div class="topic clearfix">
                        <div class="l">幸事多商城</div>
                        <div class="r editor">编辑</div>
                        <div class="r finish">完成</div>
                    </div>
                    <ul class="goodsBox" style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
                        <asp:Repeater ID="cart_rp" runat="server">
                            <ItemTemplate>
                                <li class="clearfix">
                                   
                                    <div class="imgWrap l"><%-- Style="display: none;"--%>
                                        <label id="cart_id"><%#Eval("id") %></label>
                                        <img src="<%#Eval("图片路径") %>" alt="" />
                                    </div>
                                    <div class="l info">
                                        <h3 class="over"><%#Eval("品名") %></h3>
                                        <p>¥ <span><%#Eval("单价") %></span></p>
                                    </div>
                                    <div class="del r">删除</div>

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                    <div class="settlement clearfix">
                        <div class="totalMoney l">总金额： ¥ <span><%=totalprice %></span></div>
                        <%--<div class="r goBuy">去结算</div>--%>
                        <asp:Button CssClass="r goBuy" ID="submit_order" OnClick="submit_order_Click" runat="server" Text="去结算" style="border:none" />
                        
                    </div>
                </div>
                <div class="empty" id="emp" runat="server">
                    <div class="imgWrap">
                        <img src="../img/null.png" alt="" />
                    </div>
                    <p>购物车空空如也</p>
                </div>
            </div>
        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:UserFooter ID="UserFooter" runat="server" EnableViewState="False"></uc:UserFooter>
        </div>

        <script type="text/javascript" src="../js/plugins/zepto.min.js"></script>
        <script type="text/javascript" src="../js/modules/cart.js"></script>
        <script src="../js/plugins/layer.js"></script>
        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(1).addClass("on");
                //$("ul").on('click', '.del', function () {
                //    var num = $(this).parents('li').find('#cart_id').text();
                //    console.log(num);
                //    $.ajax({
                //        url: 'CartDel.ashx',
                //        type: 'get',
                //        data: {
                //            CartId: num
                //        },
                //        success: function (result) {
                //           // window.location.reload();
                //        }
                //    })
                //})
            })
        </script>
    </form>
</body>
</html>
