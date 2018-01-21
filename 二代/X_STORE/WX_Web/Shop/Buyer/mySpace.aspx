<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mySpace.aspx.cs" Inherits="Wx_NewWeb.Shop.Buyer.mySpace" %>

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
            <div id="mySpace">
                <ul class="clearfix">
                    <asp:Repeater ID="goods_list" runat="server">
                        <ItemTemplate>
                            <li class="<%#list_li(Eval("实际商品id").ObjToInt(0),Eval("位置").ObjToInt(0),Eval("库位id").ObjToInt(0)) %>">
                                <a href="<%#link_detail((int)Eval("实际商品id"),(int)Eval("位置"),(int)Eval("库位id")) %>">
                                    <div class="pic">
                                        <img src="<%#Eval("图片路径")%>" alt="" />
                                        <p class="goodsName over"><%#Eval("实际商品品名")%></p>

                                    </div>
                                    <div class="price">¥ <span><%#Eval("本站价").ObjToDecimal(0)%></span></div>
                                </a>
                                <p style="display: none"><%#Eval("实际商品id")%></p>
                                <div class="model">
                                    <p>暂无商品</p>
                                </div>
                            </li>

                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="info">
                    <div class="infoWrapper">
                        <p class="topic">私密的事情私密地做</p>
                        <p>1.购买过程中，不需填写任何个人私密信息，就可以从平台上轻松购买，获取商品。</p>
                        <p>2.在酒店特定环境里，您可以放心使用这些私密产品。</p>
                        <p>3.使用后的产品，您可以方便地随身带走。</p>
                        <p>4.多种商品，供您选择。如想一次购买多个商品，可添加到购物车内，一次支付。当然，您也可以单独购买。</p>

                    </div>
                </div>
            </div>
        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:UserFooter ID="UserFooter" runat="server" EnableViewState="False"></uc:UserFooter>
        </div>
        <script src="../js/plugins/zepto.min.js"></script>
        <script src="../js/plugins/vipspa.js"></script>
        <script src="../js/modules/mySpace.js"></script>
        <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
        <script src="../../js/jquery-1.7.2.min.js"></script>

        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(0).addClass("on");

            })
        </script>
    </form>

</body>
</html>
