<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderAddressList.aspx.cs" Inherits="tdx.memb.man.Shop.OrdersManage.OrderAddressList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="build/My97DatePicker/WdatePicker.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单管理</span>
            <i class="arrow"></i>
            <span>地址列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <%--<li><a class="add" href="GoodsEdit.aspx"><i></i><span>新增</span></a></li>--%>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本导航及下属子导航，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                    </ul>
                </div>

            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="7%">选择</th>

                <th width="10%">openid<br />
                    昵称 </th>
                <th width="10%">省 </th>
                <th width="10%">市  </th>
                <th width="10%">区 </th>
                <th width="10%">详细地址 </th>
                <th width="10%">手机号</th>
                <th width="10%">收货人</th> 
                <th width="10%">操作</th>

            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>


                        <td style="text-align: center;">
                           <%#Eval("订单编号")%><br />
                            <%#getnicheng(Eval("订单编号").ToString())%> </td>
                        <td style="text-align: center;"><%#Eval("省")%></td>
                        <td style="text-align: center;"><%#Eval("市")%> </td>
                        <td style="text-align: center;"><%#Eval("区")%> </td>
                        <td style="text-align: center;"><%#Eval("详细地址")%> </td>
                        <td style="text-align: center;"><%#Eval("手机号")%> </td>
                        <td style="text-align: center;"><%#Eval("收货人")%> </td>
                        <td style="text-align: center;"><a href="OrderAddressEdit.aspx?id=<%#Eval("id")%>">修改</a> </td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--/列表-->


        <%-- 分页2015.6.25 --%>
        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
            <div class="page">
                <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal>
            </div>
        </div>
        <%-- 分页2015.6.25 --%>
    </form>
</body>
</html>
