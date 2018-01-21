<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomSatus.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.roomSatus" %>

<%@ Register Src="~/Shop/ascx/psyFooter.ascx" TagPrefix="uc" TagName="psyFooter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/distributer.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多私享空间-配货系统</title>
    <script src='../js/plugins/zepto.min.js'></script>
    <script src='../js/plugins/vipspa.js'></script>
    <script src="../js/plugins/vipspa-dev.js"></script>
    <script src="../js/modules/roomStatus.js"></script>
    <script src="../../js/jquery-1.7.2.min.js"></script>
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
            <div id="roomStatus">
                <div class="clearfix topTitle">
                    <img src="../img/delivery.png" alt="" class="l" />
                    <div class="disInfo l">
                        <h3 class="over">
                            <asp:Label runat="server"><%=hotel_name %></asp:Label></h3>
                        <p>
                            <asp:Label runat="server"><%=hotel_address %></asp:Label></p>
                    </div>
                </div>
                <div class="interval"></div>
                <ul class="clearfix">
                    <asp:Repeater runat="server" ID="roomsatus_rp">
                        <ItemTemplate>
                            <li>
                                <a href="../pages/roomGoods.aspx?kwid=<%#Eval("id") %>">
                                    <img src="../img/room.png" />
                                    <p class="roomNumber"><%#Eval("库位名") %></p>
                                    <p class="label" id="is_lixian" style="display: none">离</p>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>

        </div>
        <div style="display: block;" class="footer_bar openwebview">
            <uc:psyFooter ID="dismyself" runat="server" EnableViewState="False"></uc:psyFooter>
        </div>

        <script type="text/javascript">
            $(function () {
                $("a[name='con']").eq(0).addClass("on");
            })
        </script>
    </form>
</body>
</html>
