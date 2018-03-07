<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoList.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.Manager.UserInfoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多私享空间-基础信息(注册用户)</title>
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
            <div class="user">
            <asp:Repeater ID="hm_user_item_rp" runat="server">
                <HeaderTemplate>
                    <table border="1">
			          <tr class="topic">
			  	        <th style="width: 25%;">账号</th>
			  	        <th style="width: 25%;">姓名</th>
			            <th style="width: 25%;">职务</th>
                        <th style="width: 25%;">上次登录</th>
			          </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
			  	        <td><%#Eval("用户名") %></td>
			            <td><%#Eval("真实姓名") %>
                            tel:<%#Eval("手机号") %>
			            </td>
			            <td><%#Eval("角色类型") %></td>
			         
                        <td><%#Eval("LastLoginTime").ObjToStr() %></td>
			        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        </div>
    </form>
</body>
</html>