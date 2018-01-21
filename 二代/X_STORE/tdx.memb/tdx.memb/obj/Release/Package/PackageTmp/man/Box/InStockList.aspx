<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InStockList.aspx.cs" Inherits="tdx.memb.box.InStockList" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>入库</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/.js"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <script src="../../man/ShoppingMall/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/select2.js"></script>
    <link href="../../css/select2.css" rel="stylesheet" />
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
                        <%--<li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">品名</span>&nbsp;<asp:TextBox ID="txt_pinming" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>--%>
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">入库号</span>&nbsp;<asp:TextBox ID="rk_number" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">酒店集团/酒店</span>&nbsp;<asp:TextBox ID="txt_hotel" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">供应商</span>
                            <asp:DropDownList CssClass="input" ID="gys" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">入库类型</span>
                            <asp:DropDownList CssClass="input" ID="rk_lx" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">正常入库</asp:ListItem>
                                <asp:ListItem Value="2">其他入库</asp:ListItem>
                                <asp:ListItem Value="3">转入库</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        </ul>
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">开始日期</span>&nbsp;
                        <input type="text" class="input normal Wdate" runat="server" id="Jxl" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                        </li>

                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">结束日期</span>&nbsp;
                        <input type="text" class="input normal  Wdate" runat="server" id="Jx2" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                        </li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1">
                            <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span>
                            </asp:LinkButton></span>
                            
                        </li>
                        
                    </ul>
                </div>
            </div>
            <div id="floatHead" class="toolbar" style="align-content:center;vertical-align: middle;">
                <div class="l-list" >
                    <ul class="icon-list">
                        <li><a class="add" href="InStockAdd.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton>
                        </li>
                    </ul>
                    <ul style="float:right;">
                        <asp:Label runat="server" ID="lb_sum"/>
                    </ul>
                </div>
            </div>


            <telerik:RadAjaxPanel runat="server">

                <table width=" 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width=" 10%;">选择</th>
                        <th width=" 10%;">操作日期</th>
                        <th width=" 10%;">入库号</th>
                        <th width=" 10%;">入库人</th>
                        <th width=" 10%;">供应商</th>
                        <th width=" 10%;">酒店集团<br />
                            酒店</th>
                        <th width=" 10%;">房间</th>
                        <th width=" 10%;">总数量<br />
                            总额</th>
                        <th width=" 10%;">入库类型</th>
                        <th width=" 10%;">操作</th>
                    </tr>
                    <asp:Repeater ID="Rp_Instocklist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center;">
                                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                                </td>
                                <td style="text-align: center;"><%#Eval("操作日期")%></td>
                                <td style="text-align: center;"><%#Eval("单据编号")%></td>
                                <td style="text-align: center;"><%#Eval("用户名")%></td>
                                <td style="text-align: center;"><%#Eval("公司名称")%></td>
                                <td style="text-align: center;"><%#Eval("酒店全称")%><br />
                                    <%#Eval("仓库")%></td>
                                <td style="text-align: center;"><%#Eval("库位")%></td>
                                <td style="text-align: center;"><%#Eval("总数")%><br />
                                    <%#Eval("总额") %></td>
                                <td style="text-align: center;"><%#getlx(Eval("入库类型").ObjToStr()) %></td>
                                <td style="text-align: center;">
                                    <a class="add" href="InStockEdit.aspx?id=<%#Eval("单据编号")%>">修改</a>&nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </telerik:RadAjaxPanel>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPagerIn" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator"
                    NextPageText="下一页" OnPageChanging="AspNetPagerIn_PageChanging" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
