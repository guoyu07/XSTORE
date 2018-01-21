<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelWarehouseAdd.aspx.cs" Inherits="tdx.memb.man.HotelWarehouse.HotelWarehouseAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增酒店</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../man/js/layout.js"></script>
    <link href="../../man/skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../man/css/nei.css" rel="stylesheet" type="text/css" />
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
        </div>
        <div class="tab-content">
            <dl>
                <dt>选择省</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_shen" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shen_SelectedIndexChanged"></asp:DropDownList>
                </dd>
            </dl>
           <%-- <dl>
                <dt>选择市</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_shi" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_shi_SelectedIndexChanged"></asp:DropDownList>
                </dd>
            </dl>--%>
            <dl>
                <dt>酒店集团</dt>
                <dd>
                    <asp:DropDownList CssClass="input" ID="ddl_hotel" runat="server" AutoPostBack="true"></asp:DropDownList>
                     <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
        <%--    <dl>
                <dt>所在地区&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:DropDownList ID="dparea" CssClass="input normal" runat="server" ></asp:DropDownList>
                <span class="Validform_checktip">*必填</span>
            </dl>--%>
            
            <dl>
                <dt>酒店</dt>
                <dd>
                    <input type="text" name="txtck" placeholder="仓库名称,不得为空" class="px" runat="server" id="txtck" maxlength="200" /><br />
                    <span class="gray">仓库名称,不得为空,最长200字符</span>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>详细地址&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox runat="server" ID="txtdizhi" CssClass="input normal"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>前台电话&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox runat="server" ID="txtphone" CssClass="input normal"></asp:TextBox>
                <span class="Validform_checktip">*必填  例:0150-85213303</span>
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
