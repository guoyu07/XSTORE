<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="disRoomList.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.disRoomList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
		<title>幸事多私享空间</title>
		<link rel="icon" href="img/logo.png" type="image/x-icon"/>
		<link rel="stylesheet" href="../css/reset.css" />
		<link rel="stylesheet" href="../css/common.css" />
		<link rel="stylesheet" href="../fonts/iconfont.css">
		<link rel="stylesheet" href="../css/disRoomList.css"/>
</head>
<body>
    <form id="form1" runat="server">
		<div class="clearfix topTitle">
			<div class="l iconfont icon-peisongzhong"></div>
			<div class="l disInfo">
				<p class="replenishment"><%=jd_name %>补货</p>
				<p class="roomSum"><span><%=jd_rooms %></span>个房间</p>
			</div>
		</div>
		<div class="interval"></div>
		<ul>
            <asp:Repeater ID="rooms_rp" runat="server">
                <ItemTemplate>
                    			<li>
				<a href="" class="clearfix">
					<div class="l"><span><%#Eval("库位名") %></span>室</div>
					<div class="r iconfont icon-gengduo"></div>
					<div class="r num"><%#Eval("总数") %></div>
				</a>
			</li>
                </ItemTemplate>
            </asp:Repeater>
		</ul>
    </form>
</body>
</html>
