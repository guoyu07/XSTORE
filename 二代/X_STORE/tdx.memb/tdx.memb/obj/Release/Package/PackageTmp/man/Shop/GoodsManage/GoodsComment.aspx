﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsComment.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.GoodsComment" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
            <span>商品评论管理</span>
            <i class="arrow"></i>
            <span>商品评论列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">


            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <%--                        <li class="xg hide" ><a class="add" href="GoodsTypeEdit.aspx"><i></i><span>新增</span></a></li> --%>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                    </ul>
                </div>

            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="8%">选择</th>
                <th width="8%">条形码<br />
                    品名<br />
                    规格</th>
                <th width="8%">订单编号</th>
                <th width="8%">评论人</th>
                <th width="6%">评论内容</th>
                <th width="6%">评论时间</th>
            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("编号new")%><br />
                            <%#Eval("品名")%><br />
                            <%#Eval("规格")%></td>
                        <td style="text-align: center;"><%#Eval("订单编号")%></td>
                        <td style="text-align: center;"><%#Eval("评论人")%></td>
                        <td style="text-align: center;"><%#Eval("评论内容")%></td>
                        <td style="text-align: center;"><%#Eval("createtime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--/列表-->


    </form>
</body>
</html>

