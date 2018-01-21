<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipList.aspx.cs" Inherits="tdx.memb.man.manager.VipList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">用户名</span>&nbsp;<asp:TextBox ID="txt_user_ame" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">姓名</span>&nbsp;<asp:TextBox ID="txt_xm" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">昵称</span>&nbsp;<asp:TextBox ID="txt_nick_name" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;<asp:LinkButton runat="server" ID="lb_sousuo" OnClick="lb_sousuo_Click"  CssClass="btn-search">搜索</asp:LinkButton></li>
                    </ul>
                </div>

                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="VipAdd.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>

            </div>
            <!--/工具栏-->


            <!--列表-->
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="8%">ID</th>
                    <th width="14%">用户名</th>
                    <th width="8%">姓名</th>
                    <th width="8%">昵称</th>
                    <th width="8%">性别</th>
                    <th width="8%">地区</th>
                    <th width="8%">消费</th>
                    <th width="8%">注册时间</th>
                    <th width="14%">操作</th>
                </tr>
                <asp:Repeater ID="Rp_VipInfo" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                            </td>
                            <td style="text-align: center;"><%#Eval("username")%></td>
                            <td style="text-align: center;"><%#Eval("xingming")%></td>
                            <td style="text-align: center;"><%#Eval("nickname")%></td>
                            <td style="text-align: center;"><%#Eval("EmailAddress")%></td>
                            <td style="text-align: center;"><%#Eval("gender")%></td>
                            <td style="text-align: center;"><%#Eval("totalprice")%></td>
                            <td style="text-align: center;"><%#Eval("creationtime")%></td>
                            <td style="text-align: center;"><a href="VipEdit.aspx?id=<%#Eval("id")%>">修改</a><br/>
                                                            
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--/列表-->

            <%-- 分页2015.6.25 --%>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="" LastPageText=""
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CssClass="pages" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
            <%-- 分页2015.6.25 --%>
    </form>
</body>
</html>
