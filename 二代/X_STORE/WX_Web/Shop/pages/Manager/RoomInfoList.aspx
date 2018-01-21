<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomInfoList.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.Manager.RoomInfoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多私享空间-基础信息(房间)</title>
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
            <div class="room item">
                <ul>
                    <li class="clearfix">
                        <a href="">
                            <div class="l" style="width: 15%;">
                                <p class="roomNumber"><span>房间号</span></p>
                            </div>
                    
                            <div class="l" style="margin-left: 5px; width: 25%;">
                                <p class="roomNumber"><span>上次补货</span></p>

                            </div>
                            <div class="r status" >
                                <p class="roomNumber"><span>状态</span></p>
                            </div>
			    <div class="l"  style="margin-left: 1px; width: 20%;">
                                <p class="roomNumber"><span>离线时长</span></p>
                            </div>
                            <div class="l"  style="margin-left: 1px; width: 25%;">
                                <p  class="roomNumber">
                                    <span onclick="sort_amount_click()">销售金额</span>
                                    <asp:ImageButton runat="server" Width="12" Height="12" ID="SortImgBtn" ImageUrl='' Sort="down" 
OnClick="SortImgBtn_OnClick" />
                                </p>
                            </div>
                        </a>
                    </li>
                    <asp:Repeater ID="psy_rp" runat="server">

                        <ItemTemplate>
                            <li class="clearfix">
                                <a href="">
                                    <div class="l" style="width: 15%;">
                                        <p class="roomNumber"><span><%#Eval("库位名") %></span>室</p>
                                       
                                        
                                    </div>

                                    <div class="l" style="margin-left: 1px; width: 25%;">
                                        <p class="roomNumber"><span><%# string.IsNullOrEmpty(Eval("补货时间").ObjToStr())?"--":((DateTime)Eval("补货时间")).ToString("yyyy-MM-dd") %> </span></p>

                                    </div>
<div class="l" style="margin-left: 1px; width: 20%;">
<p class="roomNumber"><%#Eval("离线时长")==null?"--":Eval("离线时长").ObjToStr() %>小时</p>
</div>

                                    <div class="r status" >
                                        <%#GetOnline(Eval("id").ObjToInt(0)) %>
                                        
                                    </div>
                                    <div class="l" style="margin-left: 1px; width: 20%;">
                                        <p class="roomNumber">¥<span><%#Eval("SelledAmount").ObjToDecimal(0) %></span></p>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clearfix fixBottom">
                    <p class="r">活跃房间数量合计： <span runat="server" id="room_count"></span></p>
                </div>
            </div>
    </form>
</body>
</html>
