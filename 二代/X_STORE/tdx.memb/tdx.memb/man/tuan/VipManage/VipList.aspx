<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipList.aspx.cs" Inherits="tdx.memb.man.Tuan.VipManage.VipList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>拼好货</title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>会员管理</span>
            <i class="arrow"></i>
            <span>会员列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">微信昵称</span>&nbsp;<asp:TextBox ID="txt_Name" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">手机号</span>&nbsp;<asp:TextBox ID="txt_Telephone" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                    </ul>
                </div>
            </div>

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <%--<li><a class="add" href="VipEdit.aspx"><i></i><span>新增</span></a></li>--%>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本导航及下属子导航，是否继续？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                    </ul>
                </div>
                <div style="float: right;">
                    <asp:Button ID="btn_baobiao" runat="server" CssClass="btn" OnClick="btn_baobiao_Click" Text="导出Excel表格" /></div>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="8%">选择</th>
                <th width="8%">openid</th>
                <th width="8%">微信昵称</th>
                <th width="8%">微信头像</th>
                <th width="8%">订单数</th>
                <th width="8%">手机号</th>
                <th width="12%">操作</th>
            </tr>
            <asp:Repeater ID="Rp_VipInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("openid")%></td>
                        <td style="text-align: center;"><%#Eval("wx昵称")%></td>
                        <td style="text-align: center;">
                            <img src='<%#Eval("wx头像")%>' style="width: 50px; height: 25px;" /></td>
                             <td style="text-align: center;"><%#Eval("ordercount")%></td>
                        <td style="text-align: center;"><%#Eval("手机号")%></td>
                        <td style="text-align: center;"><a href="VipEdit.aspx?id=<%#Eval("id")%>">修改</a> </td>
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
