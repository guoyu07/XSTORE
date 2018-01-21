<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelWarehousekwAdd.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.HotelWarehousekwAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
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
            <span>仓库管理</span>
            <i class="arrow"></i>
            <span>库位管理</span>
        </div>
        <div class="tab-content">
            <dl>
                <dt>选择省</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_shen" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shen_SelectedIndexChanged"></asp:DropDownList>
                    <span class="Validform_checktip">*必选</span>
                </dd>
            </dl>
            <%--<dl>
                <dt>选择市</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_shi" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shi_SelectedIndexChanged"></asp:DropDownList>
                </dd>
            </dl>--%>
            <dl>
                <dt>酒店集团</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_hotel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_hotel_SelectedIndexChanged"></asp:DropDownList>
                    <span class="Validform_checktip">*必选</span>
                </dd>

            </dl>
            <dl>
                <dt>酒店</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_warehouse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_warehouse_SelectedIndexChanged"></asp:DropDownList>
                     <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>房间</dt>
                <dd>
                    <input type="text" name="txt" placeholder="房间名称,不得为空" class="px" runat="server" id="txtkw" maxlength="200" /><br />
                    <span class="gray">房间名称,不得为空,最长200字符</span>
                    <span class="Validform_checktip">*必选</span>
                </dd>
            </dl>
              <dl>
                <dt>MAC&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox runat="server" ID="txt_mac" CssClass="input normal"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
        </div>
        <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button runat="server" Text="提交保存" CssClass="btn" ID="btnSave" OnClick="btnSave_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
    </form>
</body>
</html>
