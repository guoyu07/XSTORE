<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_ADS_List2.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_ADS_List2" %>

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
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1>
        <strong>幻灯片设置 </strong>
    </h1>
    <div class="nei_content">
        <!--center content-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
            <div class="btn_container">
        <asp:Literal ID="lb_cate" runat="server"></asp:Literal>
        <asp:Button ID="delBtn" runat="server" Text="彻底删除" OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')"
            class="btnDelete" /></div>
        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
            <div class="page">
                <asp:Literal ID="lt_pagearrow" runat="server"> </asp:Literal></div>
        </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>

