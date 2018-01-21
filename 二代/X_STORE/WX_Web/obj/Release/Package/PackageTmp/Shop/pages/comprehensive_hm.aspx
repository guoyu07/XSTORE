<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="comprehensive_hm.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.comprehensive_hm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <title>幸事多私享空间-综合查询</title>
    <link rel="icon" href="../img/logo.png" type="image/x-icon" />
    <link rel="stylesheet" href="../css/reset.css" />
    <link rel="stylesheet" href="../css/common.css" />
    <link rel="stylesheet" href="../fonts/iconfont.css">
    <link rel="stylesheet" href="../css/comprehensive.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="topNav clearfix">
            <ul>
                <li class="l clickOn">房间</li>
                <li class="l">商品</li>
                <li class="l" id="product">注册用户</li>

            </ul>
        </div>
        <input hidden value="0" id="hiddenButton" />
        <div class="main" style="-webkit-overflow-scrolling: touch;">
            <div class="room item">
                <div class="topInputContaienr">
                    <%--           <input type="text" id="" value="" placeholder="请输入房间号" />--%>
                    <asp:TextBox runat="server" ID="search_rooms" placeholder="请输入房间号" Text="" OnTextChanged="search_rooms_TextChanged" AutoPostBack="true"></asp:TextBox>

                </div>
                <ul>
                    <asp:Repeater ID="psy_rp" runat="server">
                        <ItemTemplate>
                            <li class="clearfix">
                                <a href="">
                                    <div class="l">
                                        <p class="roomNumber"><span><%#Eval("库位名") %></span>室</p>
                                        <p>前台：<span><%#Eval("用户名") %></span></p>
                                    </div>
                                    <div class="r">
                                        <p class="num"><%#Eval("数量") %></p>
                                        <%--                                   <p class="status">离线</p>--%>
                                    </div>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <%--  <div class="distributer item">
            <div class="topInputContaienr" style="display:none;">
                <input type="text" id="" value="" placeholder="请输入姓名"/>
            </div>
            <ul>
                <asp:Repeater ID="qhjd_rp" runat="server">
                    <ItemTemplate>
                        <li class="clearfix">
                            <a href="disRoomList.aspx?ckid=<%#Eval("id") %>">
                                <div class="l iconfont icon-peisongzhong"></div>
                                <div class="l disInfo">
                                    <p class="replenishment"><%#Eval("仓库名") %>补货</p>
                                    <p class="roomSum"><span><%#Eval("总数") %></span>个房间</p>
                                </div>
                                <div class="r num"><%#Eval("数量") %></div>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>--%>
            <div class="goods item" style="-webkit-overflow-scrolling: touch;">
                <div class="topInputContaienr">
                    <input id="search_goods" type="text" placeholder="请输入商品名称"></input>
                </div>
                <div class="goods">
                    <table border="1">
                        <thead>
                            <tr class="topic">
                                <th>图片</th>
                                <th>商品</th>
                                <th>单价</th>
                                <th>库存</th>
                                <th>销量</th>
                            </tr>
                        </thead>
                        <%--        <tbody>--%>
                        <asp:Repeater ID="goods_rp" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img src="<%#Eval("图片路径") %>" alt="" /></td>
                                    <td><%#Eval("品名") %></td>
                                    <td>¥ <span><%#Eval("本站价") %></span></td>
                                    <td>× <span><%#Eval("库存数") %></span></td>
                                    <td>× <span><%#Eval("出库数") %></span></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--   <tbody>--%>
                    </table>
                </div>
            </div>
            <div class="user item">
                <ul>
                   
                                    <asp:Repeater ID="hm_user_item_rp" runat="server">
                                        <ItemTemplate>
                                            <li class="clearfix">
					<h1 class="l">酒店<%#Eval("角色类型") %></h1>
					<h2 class="r"><%#Eval("真实姓名") %></h2>
		    	</li>

                                        </ItemTemplate>
                                    </asp:Repeater>

                </ul>
            </div>




        </div>
                <script src="../js/jquery-1.7.2.min.js"></script>
        <script src="../js/comprehensive_hm.js"></script>
<%--        <script src="../js/plugins/layer.js"></script>--%>
    </form>
</body>
</html>
