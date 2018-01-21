<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WX_users.aspx.cs" Inherits="tdx.memb.man.manager.WX_users" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>微信用户</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #rcb_jd_Arrow {
            width: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <telerik:RadAjaxPanel runat="server">
            <div class="location">
            </div>
            <div class="toolbar-wrap">
                <div id="floatHead" class="toolbar">
                    <div class="l-list">
                        <ul class="icon-list">
                            <li>&nbsp;&nbsp;<span style="font-size: 12px;">用户名</span>&nbsp;<asp:TextBox ID="txt_name" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                            <li>&nbsp;&nbsp;<span style="font-size: 12px;">手机号</span>&nbsp;<asp:TextBox ID="txt_tp" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                            <li>&nbsp;&nbsp;<span style="font-size: 12px;">酒店名</span>&nbsp;
                            <telerik:RadComboBox ID="rcb_jd" runat="server" LocalizationPath="~/Language"
                                DataTextField="仓库名" DataValueField="id" Filter="Contains" MarkFirstMatch="true"
                                AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true">
                                <ItemTemplate>
                                    <%# Eval("仓库名") %><span style="display: none;"><%# Eval("仓库名") %></span>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                            </li>
                            <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1">
                                <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span>
                                </asp:LinkButton></span>
                            </li>
                        </ul>
                        <ul class="icon-list">
                                <li><a class="add" href="WXUsersEdit.aspx?id=-1"><i></i><span>新增</span></a></li>
                                <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                                <li>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="del"
                                    OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i>
                                    <span>删除</span></asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
                <!--列表-->
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th style="width: 10%">选择</th>
                        <th style="width: 10%">用户名</th>
                        <th style="width: 10%">openid</th>
                        <th style="width: 10%">手机号</th>
                        <th style="width: 10%">真实姓名</th>
                        <th style="width: 10%">QQ<br />
                            Email</th>
                        <th style="width: 10%">微信昵称</th>
                        <th style="width: 10%">微信头像</th>
                        <th style="width: 10%">权限</th>
                        <th style="width: 10%">操作</th>
                    </tr>
                    <asp:Repeater ID="Rp_users" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                </td>
                                <td style="text-align: center;"><%#Eval("用户名")%></td>
                                <td style="text-align: center;"><%#Eval("openid")%></td>
                                <td style="text-align: center;"><%#Eval("手机号")%></td>
                                <td style="text-align: center;"><%#Eval("真实姓名")%></td>
                                <td style="text-align: center;"><%#Eval("QQ")%><br />
                                    <%#Eval("Email")%></td>
                                <td style="text-align: center;"><%#Eval("微信昵称")%></td>
                                <td style="text-align: center;">
                                    <img src='<%#Eval("微信头像")%>' style="width: 50px; height: 50px;" /></td>
                                <td style="text-align: center;"><%#Eval("角色类型")%></td>
                                <td style="text-align: center;"><a href="WXUsersEdit.aspx?id=<%#Eval("id")%>">修改</a><br />
                                    <%-- <a href="WX_user_hotel_manage.aspx?id=<%#Eval("id")%>">配置</a><br/> --%>
                                    <a href="VipManageHotel.aspx?id=<%#Eval("id") %>">权限管理</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
       
        <div class="tdh">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator" 
                NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CurrentPageButtonClass="cpb" 
                PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
             </telerik:RadAjaxPanel>
    </form>
</body>
</html>
