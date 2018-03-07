<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="employeeManager.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.employeeManager" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
		<title>幸事多私享空间-人员管理</title>
		<link rel="icon" href="../img/logo.png" type="image/x-icon"/>
		<link rel="stylesheet" href="../css/reset.css" />
		<link rel="stylesheet" href="../css/common.css" />
		<link rel="stylesheet" href="../fonts/iconfont.css">
		<link rel="stylesheet" href="../css/employeeManager.css" />
</head>
<body>
    <form id="form1" runat="server">
		<div class="interval"></div>
		<div class="main" style="-webkit-overflow-scrolling:touch;">
			<dl class="manager">
				<dt>人员信息管理</dt>
                <asp:Repeater runat="server" ID="people_repeater">
                    <ItemTemplate>
                        <dd>
					        <div class="link_a">
						        <h3>账号：<strong><%#Eval("用户名") %></strong></h3>
						        <p>姓名： <span><%#Eval("真实姓名") %></span>;&nbsp;&nbsp;&nbsp;&nbsp;电话：<span><%#Eval("手机号") %></span></p>
					        </div>
                            <div class="modify_a" ><a href="managerSetPsd.aspx?userId=<%#Eval("id") %>">修改</a></div>
				        </dd>
                    </ItemTemplate>
                </asp:Repeater>
			</dl>
		</div>
    </form>
</body>
</html>
