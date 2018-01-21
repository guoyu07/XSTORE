<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_Log.aspx.cs" Inherits="tdx.memb.man.Texts.vote_Log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投票日志</title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../js/tdx_member.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <h1>
        <strong>投票日志查看</strong></h1>
    <div id="nei_content" class="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <div class="nei_seach">
            <input type="text" id="sousuo_txt" runat="server" class="sousuo_px" placeholder="请填写投票项名或投票项目进行查询">
            <input id="Button1" type="button" value="搜索" runat="server" onserverclick="btn_save_ServerClick"
                class="btnGray">
            <input id="Button2" type="button" value="导出EXCEL" runat="server" onserverclick="btn_downexcel"
                class="btnSave">
            <asp:Literal ID="xiazai" runat="server"></asp:Literal></div>
        <div class="btn_container">
            <asp:Literal ID="tianjia" runat="server">
                      
            </asp:Literal></div>
        <div class="tdh">
            <asp:Literal ID="zdList" runat="server" EnableViewState="false">

            </asp:Literal>
            <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal></div>
    </div>
    </form>
</body>
</html>
