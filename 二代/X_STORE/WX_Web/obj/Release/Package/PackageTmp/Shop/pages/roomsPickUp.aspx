<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roomsPickUp.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.roomsPickUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
		<title>幸事多私享空间</title>
		<link rel="icon" href="../img/logo.png" type="image/x-icon">
		<link rel="stylesheet" href="../css/reset.css">
		<link rel="stylesheet" href="../css/common.css">
		<link rel="stylesheet" href="../fonts/iconfont.css">
		<link rel="stylesheet" href="../css/roomsPickUp.css">
	</head>
<body>
    <form id="form1" runat="server">
		<ul class="clearfix">
            <asp:Repeater ID="rooms_rp" runat="server">
                <ItemTemplate>
                    <li class="offLine">
			        <a href="roomDetail.aspx?kwid=<%#Eval("库位id") %>">
					<img src="../img/room.png"/>
					<p class="roomNumber"><%#Eval("库位名") %></p>
				</a>
			</li>
                </ItemTemplate>
            </asp:Repeater>
		</ul>
    </form>
</body>
</html>
