<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WP_HotelList.aspx.cs" Inherits="tdx.memb.man.Shop.GrogshopManage.WP_HotelList" %>

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
            //window.location.href = "hotel_auth_operate.aspx?id=<%#Eval("A_id")%>&action=Edit&pindex=pindex";

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>酒店管理</span>
            <i class="arrow"></i>
            <span>酒店列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏 id="floatHead"-->
        <div class="toolbar-wrap">
            <div class="toolbar">

                <div class="l-list">
                    <ul class="icon-list">
                       
                            <li>&nbsp;&nbsp;<span style="font-size: 14px;">酒店名</span>&nbsp;<asp:TextBox ID="txt_jdm" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                            <li>&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                            <li>
                                <div>
                                    &nbsp; &nbsp;<span style="font-size: 14px; text-align: center;">区域</span>&nbsp;&nbsp;&nbsp;
                                <div style="font-size: 14px !important; position: relative !important; display: inline-block !important; margin-right: 5px !important; cursor: pointer !important;">
                                    <asp:DropDownList CssClass="input" ID="ddl_area" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddl_area_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                </div>
                            </li>
                        <li><a class="add" href="WP_HotelEdit.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <table style="width: 100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th style="width: 4%">选择</th>
                <th style="width: 10%">酒店全称/简称</th>
                <th style="width: 6%">Logo</th>
                <th style="width: 4%">区域id</th>
                <th style="width: 8%">地址</th>
                <th style="width: 8%">电话</th>
                <th style="width: 5%">总数</th>
                <th style="width: 5%">总额</th>
                <th style="width: 4%">区域管理id</th>
                <th style="width: 4%">酒店管理id</th>
                <th style="width: 10">操作</th>
            </tr>

            <asp:Repeater ID="Rp_hotelInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("酒店全称")%><br />
                            <%#Eval("酒店简称")%>
                        </td>
                        <td style="text-align: center;"><%#Eval("Logo")%></td>
                        <td style="text-align: center;"><%#Eval("区域id")%></td>
                        <td style="text-align: center;"><%#Eval("地址")%></td>
                        <td style="text-align: center;"><%#Eval("电话")%></td>
                        <td style="text-align: center;"><%#Eval("总数")%></td>
                        <td style="text-align: center;"><%#Eval("总额")%></td>
                        <td style="text-align: center;"><%#Eval("区域管理id")%></td>
                        <td style="text-align: center;"><%#Eval("酒店管理id")%></td>
                        <td style="text-align: center;"><a class="add" href="WP_HotelEdit.aspx?id=<%#Eval("id")%>">修改</a></td>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div class="tdh">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator"
                NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging" CurrentPageButtonClass="cpb" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
