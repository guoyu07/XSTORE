<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="tdx.memb.man.Box.SupplierList" %>

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
    <script type="text/javascript" src="../../js/.js"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <script src="../../man/ShoppingMall/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/select2.js"></script>
    <link href="../../css/select2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
        </div>
        <div class="toolbar-wrap">
            <!--选择具体仓库库位-->
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">公司名</span>&nbsp;<asp:TextBox ID="txt_company_name" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                        <li>&nbsp;&nbsp;
                            <span style="font-size: 12px;">电话</span>&nbsp;<asp:TextBox ID="txt_phono" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;
                            <span style="border-left: solid 1px #e1e1e1">
                                <asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span>
                                </asp:LinkButton></span>
                        </li>
                    </ul>

                </div>
            </div>

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="SupplierAdd.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="11%">选择</th>
                <th width="11%">公司名称</th>
                <th width="11%">公司地址</th>
                <th width="11%">联系人</th>
                <th width="11%">电话</th>
                <th width="11%">邮编</th>
                <th width="11%">电子邮件</th>
                <th width="11%">网址</th>
                <th width="11%">操作</th>
            </tr>
            <asp:Repeater ID="Rp_supplier" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("编号")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("公司名称")%></td>
                        <td style="text-align: center;"><%#Eval("公司地址")%></td>
                        <td style="text-align: center;"><%#Eval("联系人")%></td>
                        <td style="text-align: center;"><%#Eval("电话")%></td>
                        <td style="text-align: center;"><%#Eval("邮编")%></td>
                        <td style="text-align: center;"><%#Eval("电子邮件")%></td>
                        <td style="text-align: center;"><%#Eval("网址")%></td>
                        <td style="text-align: center;">
                            <a class="add" href="SupplierEdit.aspx?id=<%#Eval("编号")%>">修改</a>&nbsp;
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
         <div class="tdh">
            <webdiyer:AspNetPager ID="AspNetPagerIn" runat="server" FirstPageText="" LastPageText=""
                NextPageText="下一页" OnPageChanging="AspNetPagerIn_PageChanging" CssClass="pages" CurrentPageButtonClass="cpb" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>

    </form>
</body>
</html>
