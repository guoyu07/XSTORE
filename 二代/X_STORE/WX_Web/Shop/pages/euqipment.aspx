<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="euqipment.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.euqipment" %>

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
		<link rel="stylesheet" href="../css/equipment.css"/>
</head>
<body>
    <form id="form1" runat="server">
		<div class="clearfix topTitle">
			<img src="../img/delivery.png" alt="" class="l"/>
			<div class="disInfo l">
				<h3>房间号：<span><asp:Label id="kwm" runat="server"></asp:Label></span></h3>
				<p><asp:Label  id="jdqc" runat="server"></asp:Label></p>
			</div>
		</div>
		<div class="interval"></div>
		<div class="btnWrap">
			<p id="normal" class="normal" runat="server">无需补货</p>
			<p id="fault" class="fault" runat="server">设备故障</p>
			<p id="offLine" class="offLine" runat="server">设备离线</p>
			<p id="replenishment" class="replenishment" runat="server">需补货</p>
	<%--		<p id="need" class="opened" runat="server">需补货</p>--%>
		</div>
		<p class="remindTitle">
			温馨提示
		</p>
		<p class="remindContent">操作失误，请联系管理员<i class="iconfont icon-dianhua"></i><a href="tel:400-880-2482">400-880-2482</a></p>
    </form>
</body>
</html>
