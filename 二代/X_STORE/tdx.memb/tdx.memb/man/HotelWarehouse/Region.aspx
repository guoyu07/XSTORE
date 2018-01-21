<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Region.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.Region" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="location">
        </div>
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 14px;">地区名</span>&nbsp;&nbsp;<input id="Region_Name" runat="server" class="selected" />
                            &nbsp; &nbsp;
                            <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton>
                        </li>
                        <li><a class="add" href="RegionEdit.aspx?id=-1"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','您将删除酒店和房间相关的数据<br/>确认删除吗？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
            <telerik:RadAjaxPanel runat="server">
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th style="width: 25%">选择</th>
                        <th style="width: 25%">地区名称</th>
                        <th style="width: 25%">区号</th>
                        <th style="width: 25%">操作</th>
                    </tr>
                    <asp:Repeater ID="Rp_region" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                </td>
                                <td style="text-align: center;"><%#Eval("名称")%></td>
                                <td style="text-align: center;"><%#Eval("区号")%></td>
                                <td style="text-align: center;"><a href="RegionEdit.aspx?id=<%#Eval("id")%>">修改</a><br />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </telerik:RadAjaxPanel>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator"
                    NextPageText="下一页" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>

        </div>
    </form>
</body>
</html>
