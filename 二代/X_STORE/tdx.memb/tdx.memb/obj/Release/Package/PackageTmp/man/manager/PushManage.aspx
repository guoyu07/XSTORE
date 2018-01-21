<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PushManage.aspx.cs" Inherits="tdx.memb.man.manager.PushManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  <div class="toolbar-wrap">
                <div class="toolbar">
                    <div class="l-list">
                        <ul class="icon-list">
                            <li>&nbsp;&nbsp;<span style="font-size: 12px;">提醒时间</span>&nbsp;
                                <input type="text" class="input normal Wdate" runat="server" id="txt_start" 
                                    onclick="WdatePicker()" />
                            </li>
                            <li>&nbsp;&nbsp;<span style="font-size: 12px;">提醒时间</span>&nbsp;
                                <input type="text" class="input normal Wdate" runat="server" id="txt_end" 
                                    onclick="WdatePicker()" />
                            </li>
                            <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1">
                                <asp:LinkButton ID="LBtn_sousuo" runat="server" >
                                    <span>搜索</span>
                                </asp:LinkButton></span>
                            </li>
                            <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1">
                                <asp:LinkButton ID="LBtn_replenishment" runat="server" OnClick="LBtn_replenishment_Click">
                                    <span>补货推送</span>
                                </asp:LinkButton></span>
                            </li>
                        <%--    <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1">
                                <asp:LinkButton ID="LBtn_users" runat="server" OnClick="LBtn_users_Click">
                                    <span>用户推送</span>
                                </asp:LinkButton></span>
                            </li>--%>
                        </ul>
                    </div>
                </div>
        <table style="width:100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th style="width:25%">推送时间</th>
                <th style="width:25%">提醒内容</th>
                <th style="width:25%">类型</th>
                <th style="width:25%">推送人员</th>
            </tr>
            <asp:Repeater ID="rp_push" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                            <%#Eval("推送时间") %>
                        </td>
                        <td style="text-align: center;"><%#Eval("推送内容") %></td>
                        <td style="text-align: center;"><%#Eval("推送类型") %></td>
                        <td style="text-align: center;"><a href="" ></a>推送至人员</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rp_push.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                </FooterTemplate>
            </asp:Repeater>
        </table>
             <div style="padding:10px 0;">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator" 
                NextPageText="下一页" CurrentPageButtonClass="cpb" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
      </div>

    </form>
</body>
</html>
