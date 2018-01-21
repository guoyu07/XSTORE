<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VIPUser.aspx.cs" Inherits="tdx.memb.man.vipmemb.VIPUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>会员统计</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2" >
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>

        <div class="nei_seach">
            <select name="select_sousuo" runat="server" id="select_sousuo" class="select-field_sousuo">
                <option value="会员名">- 会员名</option>
                <option value="手机号">- 手机号</option>
                <option value="原始号">- 原始号</option>
            </select>
            <input type="text" id="sousuo_txt" runat="server" class="sousuo_px" placeholder="请选择相应条件，填写对应内容进行查询">
            <input id="Button1" type="button" value="搜索" runat="server" onserverclick="btn_save_ServerClick"
                class="btnGray">
            <input id="refresh" type="button" value="刷新" runat="server" onserverclick="btn_refresh_ServerClick"
                class="btnSave">
            <input id="Button2" type="button" value="导出EXCEL" runat="server" onserverclick="btn_downexcel"
                class="btnSave">
        </div>

        <div class="btn_container">
            <asp:Literal ID="xiazai" runat="server"></asp:Literal>
        </div>

        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
        </div>
    </div>
    <!--内容结束-->
    </form>
</body>
</html>
