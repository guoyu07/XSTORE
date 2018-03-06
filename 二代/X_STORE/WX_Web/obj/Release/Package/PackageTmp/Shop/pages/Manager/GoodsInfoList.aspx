<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsInfoList.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.Manager.GoodsInfoList" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多私享空间-基础信息(商品)</title>
    <link rel="icon" href="../../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../../css/reset.css" />
    <link rel="stylesheet" href="../../css/common.css" />
    <link rel="stylesheet" href="../../fonts/iconfont.css">
    <link rel="stylesheet" href="../../css/comprehensive.css" />
    <style>
        .roomInfoHead {
            text-align: center;
            margin: auto;
            border-bottom: 1px solid #ccc;
            padding: 15px;
            font-weight: bolder;
            font-size: 24px;
        }
        .lh {
            line-height: 60px;
        }
    </style>
    <script>
        function sort_amount_click() {
            $("#SortImgBtn").click();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input hidden value="0" id="hiddenButton" />
        <div class="roomInfoHead">
            <h1><%=HotelInfo["仓库名"] %></h1>
        </div>
        <div class="main" style="-webkit-overflow-scrolling: touch;">
            <div class="goods">
                <ul>
                    <li class="clearfix">
                      
                            <div class="l" style="width: 20%;text-align: center;">
                                <p class="roomNumber"><span>图片</span></p>
                            </div>
                            <div class="l" style="margin-left: 1px;text-align: center; width: 25%;">
                                <p class="roomNumber"><span>名称</span></p>
                            </div>
                            <div class="l" style="margin-left: 1px;text-align: center; width: 15%;">
                                <p class="roomNumber"><span>编码</span></p>

                            </div>
                            <div class="l" style="margin-left: 1px;text-align: center; width: 15%;">
                                <p class="roomNumber"><span>单价</span></p>
                            </div>
                            <div class="l" style="margin-left: 1px;text-align: center; width: 20%;">
                                <p class="roomNumber">
                                    <span onclick="sort_amount_click()">累计销量</span>
                                </p>
                            </div>
                  
                    </li>
                    <asp:Repeater ID="goods_rp" runat="server">
                        <ItemTemplate>
                            <li class="clearfix">
                         
                                    <div class="l" style="width: 20%;">
                                        <p class="roomNumber"><span>
                                            <img src='<%#Eval("图片路径") %>' alt="" class="l" /></span></p>
                                    </div>
                                    <div class="l lh" style="margin-left: 1px;  width: 25%;">
                                        <p class="roomNumber"><span><%#Eval("品名") %></span></p>
                                    </div>
                                    <div class="l lh" style="margin-left: 1px; text-align: center; width: 15%;">
                                        <p class="roomNumber"><span><%#Eval("编码") %></span></p>

                                    </div>
                                    <div class="l lh" style="margin-left: 1px; text-align: center;width: 15%;">
                                        <p class="roomNumber"><span><%#Eval("本站价") %></span></p>
                                    </div>
                                    <div class="l lh" style="margin-left: 1px;text-align: center; width: 20%;">
                                        <p class="roomNumber">
                                            <span onclick="sort_amount_click()"><%#Eval("累计销售") %></span>
                                        </p>
                                    </div>
                             
                            </li>

                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
                <div class="clearfix fixBottom">
                    <p class="r">在售商品数量合计： <span runat="server" id="goods_count"></span></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
