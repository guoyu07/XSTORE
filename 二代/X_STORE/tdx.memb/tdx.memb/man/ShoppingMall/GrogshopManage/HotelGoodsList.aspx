<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelGoodsList.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GrogshopManage.HotelGoodsList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../images4/nei.css" type="text/css" rel="stylesheet" />
    <%--    <script language="javascript" src="../../js/jquery-1.7.2.min.js" charset="utf-8"></script>--%>
    <script language="javascript" src="../../js/tdx_member.js" charset="utf-8"></script>
    <script type="text/javascript">

        function modify_click(sender) {
            var pageindex = document.getElementById("pihideID").value;
            var url = "";
            var obj = $(sender);
            var A_id = obj.attr("data-id");
            //alert(A_id);
            if (pageindex != "") {
                url = "WP_HotelListEdit.aspx?id=" + A_id + "&action=Edit&pindex=" + pageindex + "";
            }
            else {
                url = "WP_HotelListEdit.aspx?id=" + A_id + "&action=Edit";
            }
            window.location.href = url;

        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
        </div>
        <!--/导航栏-->

        <!--工具栏 -->
        <div class="toolbar-wrap">
            <div class="toolbar">

                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 14px;">酒店集团/酒店名</span>&nbsp;<asp:TextBox ID="txt_jdm" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>
                            <div>
                                &nbsp; &nbsp;<span style="font-size: 14px; text-align: center;">区域</span>&nbsp;&nbsp;&nbsp;
                                <div style="font-size: 14px !important; position: relative !important; display: inline-block !important; margin-right: 5px !important; cursor: pointer !important;">
                                    <asp:DropDownList CssClass="input" ID="ddl_area" runat="server" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </li>
                        <li>&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>

                    </ul>
                </div>
            </div>
            <!--/工具栏-->
            <telerik:RadAjaxPanel runat="server">
                <table style="width:100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th style="width:20%">酒店集团</th>
                        <th style="width:20%">酒店</th>
                        <th style="width:20%">Logo</th>
                        <th style="width:20%">地址</th>
                        <th style="width:20%">操作</th>
                    </tr>

                    <asp:Repeater ID="Rp_hotelInfo" runat="server">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hidId" Value='<%#Eval("仓库id")%>' runat="server" />
                                <td style="text-align: center;"><%#Eval("酒店全称")%></td>
                                <td style="text-align: center;"><%#Eval("仓库名")%></td>
                                <td style="text-align: center;">
                                    <img style="height: 100px; width: 100px;" src='<%#Eval("Logo")%>' /></td>
                                <td style="text-align: center;"><%#Eval("名称")%></td>
                                <td style="text-align: center;">
                                    <a class="add" href='HotelGoodsEdit.aspx?hotel_id=<%#Eval("仓库id") %>'>酒店商品</a>
                                </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </telerik:RadAjaxPanel>
            <div class="tdh">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                    NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CssClass="paginator"
                    CurrentPageButtonClass="cpb" PrevPageText="上一页">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </form>
</body>
</html>
