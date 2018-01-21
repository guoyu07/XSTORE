<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_mp_List.aspx.cs" Inherits="tdx.memb.man.Sets.wx_mp_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>公众号绑定</strong></h1>
    <div class="nei_content">

     <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>

        <div class="btn_container">
            <asp:Literal ID="lb_cateadd" runat="server"></asp:Literal>
            <asp:Button ID="delBtn" class="btnDelete" runat="server" Text="彻底删除" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')"
                OnClick="delBtn_Click" />
        </div>

        <div class="tdh">
            <asp:Literal ID="lb_prolist" runat="server"></asp:Literal>
        </div>
        <div class="tdh">
            <div class="page">
                <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
