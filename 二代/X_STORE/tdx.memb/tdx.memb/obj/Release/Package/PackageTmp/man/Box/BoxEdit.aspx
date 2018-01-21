<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BoxEdit.aspx.cs" Inherits="tdx.memb.man.Box.BoxEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../js/select2.js"></script>
    <link href="../css/select2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>仓库管理</span> <i class="arrow"></i><span>仓库管理</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <%-- 商品 --%>
        <telerik:RadAjaxPanel runat="server">
            <div class="tab-content   dropup">
                <asp:HiddenField ID="hidd_boxid" runat="server" />

                <dl>
                    <dt>选择省</dt>
                    <dd>
                        <asp:DropDownList CssClass="input" ID="ddl_shen" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shen_SelectedIndexChanged" ></asp:DropDownList>
                    </dd>
                </dl>
                <dl>
                    <dt>酒店选择</dt>
                    <dd>
                        <asp:DropDownList CssClass="input" ID="ddl_hotel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_hotel_SelectedIndexChanged"></asp:DropDownList>
                    </dd>
                </dl>
                <dl>
                    <dt>仓库选择</dt>
                    <dd>
                        <asp:DropDownList CssClass="input" ID="ddl_warehouse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_warehouse_SelectedIndexChanged"></asp:DropDownList>
                    </dd>
                </dl>
                <dl>
                    <dt>库位选择</dt>
                    <dd>
                        <asp:DropDownList CssClass="input" ID="ddl_kw" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_kw_SelectedIndexChanged"></asp:DropDownList>
                    </dd>
                </dl>
                <dl>
                    <dt>MAC</dt>
                    <dd>
                       <%-- <input type="text" runat="server" id="input_mac" />--%>
                        <asp:TextBox runat="server" ID="mac_input"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hiddid" />
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>位置</dt>
                    <dd>
                        <input id="input6" runat="server" type="hidden" />
                        <asp:DropDownList ID="ddl_wz" runat="server" CssClass="input">
                            <asp:ListItem Value="0">位置</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                        </asp:DropDownList>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>默认商品</dt>
                    <dd>
                        <telerik:RadComboBox Width="200px" ID="rcb_mr" runat="server" MaxHeight="203" LocalizationPath="~/Language" DataTextField="品名" DataValueField="id" Filter="Contains" MarkFirstMatch="true" AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true">
                            <ItemTemplate>
                                <%# Eval("品名") %><span style="display: none;"><%# Eval("品名") %></span>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>实际商品</dt>
                    <dd>
                        <telerik:RadComboBox Width="200px" ID="rcb_sj" runat="server" MaxHeight="203" LocalizationPath="~/Language" DataTextField="品名" DataValueField="id" Filter="Contains" MarkFirstMatch="true" AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true" AutoPostBack="true">
                            <ItemTemplate>
                                <%# Eval("品名") %><span style="display: none;"><%# Eval("品名") %></span>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
            </div>
            <!--/内容-->
        </telerik:RadAjaxPanel>
        <!--工具栏-->
        <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="AjaxAdd()" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
