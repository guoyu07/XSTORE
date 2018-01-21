<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PickUp.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.PickUp" %>

<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-配货系统</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/distributer.css" />
    <script src='../js/plugins/zepto.min.js'></script>
    <script src='../js/plugins/vipspa.js'></script>
    <script src="../js/plugins/vipspa-dev.js"></script>
    <script src="../js/modules/pickUp.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
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
            <div id="pickUp">
                <div class="clearfix topTitle">
                    <img src="../img/delivery.png" alt="" class="l" />
                    <div class="disInfo l">
                        <h3 class="over">
                            <asp:Label ID="hotel_name" runat="server"></asp:Label></h3>
                        <p class="over">
                            <asp:Label ID="hotel_address" runat="server"></asp:Label></p>
                    </div>
                </div>
                <div class="interval"></div>
                <ul>
                    <asp:Repeater ID="Rp_pickup" runat="server">
                        <ItemTemplate>
                            <li class="clearfix">
                                <div class="imgWrap l">
                                    <img src="<%#Eval("图片路径") %>" alt="" />
                                </div>
                                <div class="info l">
                                    <h3><%#Eval("品名") %></h3>
                                </div>
                                <div class="num r iconfont icon-cha"><span><%#Eval("数量") %></span></div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="btnWrap">
                    <a class="makeSure" href="../pages/roomsPickUp.aspx?kwid=<%=pick_up_qr %>">确认</a>
                </div>
            </div>
        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:psyFooter ID="psyFooter" runat="server" EnableViewState="False"></uc:psyFooter>
        </div>

        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(1).addClass("on");

            })
        </script>
    </form>
</body>
</html>
