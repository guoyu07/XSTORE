<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Collocate.aspx.cs" Inherits="tdx.memb.man.jiesuan.Collocate" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div style="width: 100%;" class="tab-content">
            <telerik:RadAjaxPanel runat="server">
                <asp:Label runat="server" Style="text-align: center; color: red; font-size: 18px; width: 100%">
                    <br/>*当数量、商品、物流公司或者单号都不为空的时候,<br/>
                            如对数量、商品、物流公司或者单号进行修改,则为同意申请。<br/>
                            请与相关人员沟通后谨慎修改*
                </asp:Label>
                <dl>

                    <dd>
                        <span>操作人</span>&nbsp;&nbsp;&nbsp;
                       <%-- <asp:Label ID="lb_czy" runat="server"></asp:Label>--%>
                        <asp:TextBox runat="server" ReadOnly="true" ID="tb_czy"></asp:TextBox>
                    </dd>
                </dl>
                <dl>
                    <dd>
                        <span>时间</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Label ID="lb_time" runat="server"></asp:Label>--%>
                         <asp:TextBox runat="server" ReadOnly="true" ID="tb_time"></asp:TextBox>
                    </dd>
                </dl>
                <dl>
                    <dd>
                        <span>酒店集团</span>
                       <%-- <asp:Label ID="lb_hotelGroup" runat="server"></asp:Label>--%>
                         <%--<asp:TextBox runat="server" ReadOnly="true" ID="tb_hotelGroup"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddl_hotelGroup" CssClass="input normal" runat="server" 
                            AutoPostBack="true"></asp:DropDownList>
                    </dd>
                </dl>
                <dl>
                    <dd>
                        <span>酒店</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Label ID="lb_hotel" runat="server"></asp:Label>--%>
                         <%--<asp:TextBox runat="server" ReadOnly="true" ID="tb_hotel"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddl_hotel" CssClass="input normal" runat="server" 
                            AutoPostBack="true"></asp:DropDownList>
                    </dd>
                </dl>
                <dl>
                    <%--品名--%>
                    <dd runat="server">
                        <span>品名</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <telerik:RadComboBox Width="145px" ID="group_name" runat="server" MaxHeight="203"
                            LocalizationPath="~/Language" DataTextField="品名" DataValueField="商品id" Filter="Contains"
                            MarkFirstMatch="true" AppendDataBoundItems="true" Show
                            ToggleImage="false" AllowCustomText="true"
                            AutoPostBack="true" ToolTip="*必填">
                            <ItemTemplate>
                                <%# Eval("品名") %><span style="display: none;"><%# Eval("品名") %></span>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <span>&nbsp;&nbsp;*必填</span>
                    </dd>
                </dl>
                <dl>
                    <%--数量--%>
                    <dd runat="server">
                        <span>数量</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox runat="server" AutoPostBack="true" ID="tb_number" ToolTip="*必填">
                        </asp:TextBox>
                        <span>&nbsp;&nbsp;*必填</span>
                    </dd>
                </dl>
                <dl>
                    <%--物流公司--%>
                    <dd runat="server">
                        <span>物流公司</span>
                        <telerik:RadComboBox Width="145px" ID="rcb_wl" runat="server" MaxHeight="203"
                            LocalizationPath="~/Language" DataTextField="快递公司" DataValueField="id" Filter="Contains"
                            MarkFirstMatch="true" AppendDataBoundItems="true" ShowToggleImage="false" AllowCustomText="true"
                            AutoPostBack="true" ToolTip="*必填">
                            <ItemTemplate>
                                <%# Eval("快递公司") %><span style="display: none;"><%# Eval("快递公司") %></span>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <span>&nbsp;&nbsp;*必填</span>
                    </dd>
                </dl>
                <dl>
                    <%--物流单号--%>
                    <dd runat="server">
                        <span>物流单号</span>
                        <asp:TextBox runat="server" AutoPostBack="true" ID="wuliu_number"></asp:TextBox>
                        <span>&nbsp;&nbsp;*必填</span>
                    </dd>
                </dl>
            </telerik:RadAjaxPanel>
        </div>
        <div class="btn-list">
            <asp:Button ID="Button2" runat="server" Text="确定" CssClass="btn"
                OnClick="Button2_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
    </form>
</body>
</html>
