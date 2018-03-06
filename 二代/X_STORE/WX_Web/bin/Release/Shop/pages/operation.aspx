<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="operation.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.operation" %>

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
		<link rel="stylesheet" href="../css/operation.css"/>
</head>
<body>
    <form id="form1" runat="server">
		<div class="clearfix topTitle">
			<img class="l" src="<%=goods_img %>"/>
			<div class="l disInfo">
				<p class="goodsName"><%=goods_name %></p>
				<p class="situation">货栈状态: <span class="status">正常</span> / 序号: <span class="serialNumber"><%=wz %></span></p>
                <p style="display:none"><%=box_id %>></p>
			</div>
		</div>
		<div class="interval"></div>
		<ul>
			<li class="clearfix">
				<div class="l">打开箱子</div>
				<div class="r iconfont icon-gengduo"></div>
			</li>
			<li class="clearfix">
				<div class="l">设为空箱</div>
				<div class="r iconfont icon-gengduo"></div>
			</li>
			<li class="clearfix">
				<div class="l">设为开箱</div>
				<div class="r iconfont icon-gengduo"></div>
			</li>
			<li class="clearfix">
				<div class="l">设为故障</div>
				<div class="r iconfont icon-gengduo"></div>
			</li>
			<li class="clearfix">
				<div class="l">设为停用</div>
				<div class="r iconfont icon-gengduo"></div>
			</li>
		</ul>
		<div class="interval"></div>
		<div class="btnWrap">
			<a href="roomGoods.aspx?kw_id=<%=room_id %>">返回房间</a>
		</div>
    </form>
</body>
</html>
