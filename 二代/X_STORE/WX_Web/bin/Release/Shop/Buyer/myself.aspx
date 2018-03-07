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
        html body .remind {
      background: #fff;
      width: 94%;
      padding: 10px 3%;
      margin-bottom: 10px; }
      html body .remind p {
        width: 100%;
        text-align: center;
        font: 14px/20px "microsoft yahei";
        color: #666; }
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
                                    <img class="l" src="<%#Eval("图片路径")==null? "/shop/img/no-image.jpg":Eval("图片路径").ObjToStr() %>" alt="" />
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
                <input runat="server" id="mac_input" type="hidden" class="mac_input"/>
                
                <div class="noOrder" id="empty" runat="server">
                    <div class="imgWrap">
                        <img src="../img/null.png" alt="" />
                    </div>
                    <p>无待开箱订单</p>
                </div>
                <div class="remind" id="title" runat="server">
                    <table>
                        <tr>
                            <td colspan="2"  style="padding-bottom: 10px;"><p style="text-align: left;">开箱失败自主解决：</p></td>
                        </tr>
		                <tr>
		                    <td>
		                        <p>1.</p>
		                    </td>
		                    <td style="padding-bottom: 10px;">
		                        <p style="text-align: left;">请对售货机断电10秒钟后上电，等LED灯带闪烁停止后，然后点击“立即开箱”，即可实现取货。</p>
		                    </td>
		                </tr>
		                <tr style="margin-top: 10px;">
		                    <td>
		                        <p>2.</p>
		                    </td>
		                    <td>
		                        <p style="text-align: left;">如果还有问题，请拨打前台电话，由前台送货。</p>
		                    </td>
		                </tr>
		            </table>
                </div>
                <a class="tel" href="tel:<%= HotelPhone%>" style="margin-top: 0;">
                    <div class="telWrap">
                        <div class="telContent clearfix" style="display:none;">
                            <img src="../img/tel.png" class="l" alt="" />
                            <span class="l">联系前台：<em  style="font-size: 18px;"><%=HotelPhone %></em></span>
                        </div>
                    </div>
                </a>
                <a style="display:none;" class="tel" href="tel:400-880-2482">
                    <div class="telWrap">
                        <div class="telContent clearfix">
                            <img src="../img/tel.png" class="l" alt="" />
                            <span class="l">联系客服：<em style="font-size: 18px;">400-880-2482</em></span>
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
        </script>

    </form>
</body>
</html>
