<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelWarehousekw.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.HotelWarehousekw" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>doubi</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
        </div>
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                         <div style="display: block; overflow:hidden;margin-bottom:10px;">
                                <li>&nbsp;&nbsp;<span style="font-size: 12px;">省</span>
                                    <asp:DropDownList CssClass="input" ID="ddl_shen" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shen_SelectedIndexChanged"></asp:DropDownList>
                                </li>
                                <%-- <li>&nbsp;&nbsp;<span style="font-size: 12px;">市</span>
                                    <asp:DropDownList CssClass="input" ID="ddl_shi" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shi_SelectedIndexChanged"></asp:DropDownList>
                                </li>--%>
                                <li>&nbsp;&nbsp;<span style="font-size: 12px;">酒店集团</span>
                                    <asp:DropDownList CssClass="input" ID="ddl_hotel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_hotel_SelectedIndexChanged"></asp:DropDownList>
                                </li>
                                <li>&nbsp;&nbsp;<span style="font-size: 12px;">酒店名</span>
                                    <asp:DropDownList CssClass="input" ID="ddl_warehouse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_warehouse_SelectedIndexChanged"></asp:DropDownList>
                                </li>
                                <li>&nbsp;&nbsp;<span style="font-size: 12px;">房间</span>
                                    <asp:DropDownList CssClass="input" ID="ddl_box" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_box_SelectedIndexChanged"></asp:DropDownList>
                                </li>
                                <li>
                                     &nbsp; &nbsp; <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton>
                                </li>
                        </div>
                        <li><a class="add" href="HotelWarehousekwAdd.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>

            <!--列表-->
            <table style="width:100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th style="width:16%">选择</th>
                    <th style="width:16%">酒店集团</th>
                    <th style="width:16%">酒店名</th>
                    <th style="width:16%">房间名称</th>
                    <th style="width:16%">MAC</th>
                    <th style="width:16%">操作</th>
                </tr>
                <asp:Repeater ID="Rp_hotelwarehousebox" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;">
                                <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                                <asp:HiddenField ID="hidId" Value='<%#Eval("库位id")%>' runat="server" />
                            </td>
                            <td style="text-align: center;"><%#Eval("酒店全称")%><br />
                            </td>
                            <td style="text-align: center;"><%#Eval("仓库")%></td>
                            <td style="text-align: center;"><%#Eval("库位")%></td>
                             <td style="text-align: center;"><%#Eval("箱子MAC")%></td>
                            <td style="text-align: center;" runat="server">
                                <div>
                                    <a class="add" href="HotelWarehouseBoxEdit.aspx?id=<%#Eval("库位id")%>">修改</a>
                                </div>
                                <div runat="server" visible='<%#getdisplay(Eval("库位").ObjToStr())%>'>
                                    <a class="add" href='../Box/BoxManage.aspx?id=<%#Eval("库位id")%>' value='<%#Eval("库位id")%>'>箱子配置</a>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    <%#Rp_hotelwarehousebox.Items.Count == 0 ? "<tr><td align='center' colspan='6'>暂无记录</td></tr>" : ""%>
                </FooterTemplate>
                </asp:Repeater>
            </table>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator" 
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>

</body>
</html>
