<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrMember.aspx.cs" Inherits="tdx.memb.man.Shop.DrMember.DrMember" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hide {
            display: none;
        }
    </style>
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
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">会员卡号</span>&nbsp;<asp:TextBox ID="txt_codecard" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="btnSearch_Click"><span>搜索</span></asp:LinkButton></span></li>
                    </ul>
                </div>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="6%">会员编号</th>
                <th width="15%">会员卡号</th>
                <th width="6%">会员类型</th>
                <th width="6%">会员姓名</th>
                <th width="6%">生效日期</th>
                <th width="6%">失效日期</th>
<%--                <th width="6%">会员状态</th>--%>
                <th width="6%">联系电话</th>
                <th width="6%">储值余额</th>
            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;"><%#Eval("会员编号")%></td>
                        <td style="text-align: center;"><%#Eval("会员卡号")%></td>
                        <td style="text-align: center;"><%#Eval("会员类型")%></td>
                        <td style="text-align: center;"><%#Eval("会员姓名")%></td>
                        <td style="text-align: center;"><%#Eval("生效日期")%></td>
                        <td style="text-align: center;"><%#Eval("失效日期")%></td>
<%--                        <td style="text-align: center;"><%#Eval("会员状态")%></td>--%>
                        <td style="text-align: center;"><%#Eval("联系电话")%></td>
                        <td style="text-align: center;"><%#Eval("储值余额")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#Rp_UserInfo.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
            <!--/列表-->
            <!--内容底部-->
            <div class="line20"></div>
            <div class="pagelist">
                <%--            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>--%>
                <div id="PageContent" runat="server" class="default"></div>
            </div>
            <!--/内容底部-->
    </form>
</body>
</html>
