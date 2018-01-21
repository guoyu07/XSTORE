<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlitem.aspx.cs" Inherits="tdx.memb.man.formcontrols.controlitem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js" charset="utf-8"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="wid" runat="server" />
    <asp:HiddenField ID="isE" runat="server" />
    <h1>
        <strong><asp:Literal ID="qianzhui" runat="server"></asp:Literal></strong><asp:Literal ID="ziduanmingzi" runat="server"></asp:Literal></h1>
    <div id="nei_content" class="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/memb/images4/ts.png">
            <span class="tsxx_2"> <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/memb/images4/xx.png">
        </div>
        <div class="ziduanming">
            <h2>
                字段类型:
                <asp:Literal ID="leixing" runat="server"></asp:Literal>
            </h2>
            <h2>
                字段名称:
                <asp:Literal ID="name" runat="server"></asp:Literal>
            </h2>
            <h2>
                排序:
                <asp:Literal ID="sort" runat="server"></asp:Literal>
            </h2>
        </div>
        <div class="btn_container">
            <asp:Literal ID="tianjiaxiangmu" runat="server"></asp:Literal>
            <input name="delBtn" value="彻底删除" onclick="return confirm('确定删除吗？删除后将不可恢复！');" id="delBtn"
                class="btnDelete" runat="Server" onserverclick="del" type="submit"></div>
        <div class="tdh">
            <asp:Literal ID="xiangmu" runat="server"></asp:Literal></div>
    </div>
    </form>
</body>
</html>

