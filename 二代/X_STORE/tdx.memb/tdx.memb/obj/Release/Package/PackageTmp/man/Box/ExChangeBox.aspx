<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExChangeBox.aspx.cs" Inherits="tdx.memb.man.Box.ExChangeBox" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../man/ShoppingMall/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function open_dialog(sender) {
            var h = 250;
            var w = $(window).width() / 2;
            var obj = $(sender);
            var id = obj.attr("am_id");//申请表id
            var show = $.dialog({
                id: 'suibian',
                lock: true,
                min: false,
                title: "",
                content: 'url:/man/Box/ApplicationManage.aspx?id=' + id + '&lx=2',//只能用绝对路径
                width: w,
                height: h

            });
            show.data = window.document;
            show.window = window;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="location">
        </div>
        <div class="toolbar-wrap">
            <!--选择具体仓库库位-->
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">mac</span>&nbsp;<asp:TextBox ID="mac_name" runat="server" CssClass="input"
                                datatype="*0-100" sucmsg=" " />
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">状态</span>
                            <asp:DropDownList CssClass="input" ID="zt_lx" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">换房申请中</asp:ListItem>
                                <asp:ListItem Value="2">申请通过</asp:ListItem>
                                <asp:ListItem Value="3">申请失败</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                    </ul>
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">申请开始日期</span>&nbsp;
                        <input type="text" class="input normal Wdate" runat="server" id="Jxl"
                            onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                        </li>
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">申请结束日期</span>&nbsp;
                        <input type="text" class="input normal  Wdate" runat="server" id="Jx2"
                            onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                        </li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1">
                            <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span>
                            </asp:LinkButton></span>
                        </li>
                    </ul>
                </div>
            </div>
            <telerik:RadAjaxPanel runat="server">
                <table width=" 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width=" 14%;">MAC</th>
                        <th width=" 14%;">原库位名</th>
                        <th width=" 14%;">新库位名</th>
                        <th width=" 14%;">申请人</th>
                        <th width=" 14%;">申请时间</th>
                        <th width=" 14%;">操作时间</th>
                        <th width=" 14%;">操作</th>
                    </tr>
                    <asp:Repeater ID="Rp_changeGoods" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;"><%#Eval("mac")%>
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                </td>
                                <td style="text-align: center;"><%#Eval("原库位名")%></td>
                                <td style="text-align: center;"><%#Eval("新库位名")%></td>
                                <td style="text-align: center;"><%#Eval("用户名")%></td>
                                <td style="text-align: center;"><%#Eval("申请时间")%></td>
                                <td style="text-align: center;"><%#Eval("操作时间")%></td>
                                <td style="text-align: center; display: <%#Getzt(Eval("状态").ObjToStr())%>">
                                    <a href=" javascript:void(0);" onclick="open_dialog(this)" am_id='<%#Eval("id") %>'><%#GetztName(Eval("状态").ObjToStr())%></a></td>
                                <td style="text-align: center; display: <%#Getzt2(Eval("状态").ObjToStr())%>"><%#GetztName(Eval("状态").ObjToStr())%></td>
                                <td style="text-align: center; display: <%#Getzt3(Eval("状态").ObjToStr())%>"><%#GetztName(Eval("状态").ObjToStr())%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </telerik:RadAjaxPanel>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPagerIn" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator"
                    NextPageText="下一页" OnPageChanging="AspNetPagerIn_PageChanged" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>

        </div>
    </form>
</body>
</html>
