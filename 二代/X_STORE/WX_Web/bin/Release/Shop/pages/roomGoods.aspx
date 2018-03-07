<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomGoods.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.roomGoods" %>

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
    <link rel="stylesheet" href="../css/roomGoods.css" />
    <link href="../css/distributer.css" rel="stylesheet" />
    <style type="text/css">
           
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="clearfix topTitle">
            <p class="roomNumber"><%=room_name %></p>
            <p class="distributer">配送员：<span><%=psy_name %></span></p>
        </div>
        <div class="interval"></div>
         <div id='view' style="-webkit-overflow-scrolling: touch; overflow: auto!important;">
            <div id="mySpace" class="roomGoods">
                <ul class="clearfix" style="margin-bottom:40px;">
                    <asp:Repeater ID="box_rp" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href="javascript:void(0);" position='<%#Eval("位置").ObjToInt(0) %>' runat="server" onserverclick="SingleOpenBoxClick">
                                    <div class="pic">
                                        <img src="<%#Eval("图片路径")%>" alt="" />
                                        <p class="goodsName over"><span style="font-weight:bolder;"><%#Eval("实际商品编码")%>&nbsp;&nbsp;</span><%#Eval("实际商品品名")%></p>
                                    </div>
                                    <div class="price">¥ <span><%#Eval("本站价").ObjToDecimal(0)%></span></div>
                               
                                <p style="display: none"><%#Eval("实际商品id")%></p>
                                <div class="model "  style='<%#link_ul(Eval("实际商品id").ObjToInt(0)) %>'>
                                    <p>暂无商品</p>
                                </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <table style=" width:100%;">
                    <tr>
                        <td style=" width:45%;">
                            <div class="btnWrap">
                                <asp:LinkButton runat="server" ID="markSure" CssClass="makeSure" OnClick="makeSure_ServerClick">开箱检查</asp:LinkButton>
                            </div>
                        </td>
                        <td style=" width:45%;">
                            <div class="btnWrap">
                                <asp:LinkButton runat="server" ID="finishCheck" CssClass="finishSure" OnClick="finishCheck_Click">完成检查</asp:LinkButton>

                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
