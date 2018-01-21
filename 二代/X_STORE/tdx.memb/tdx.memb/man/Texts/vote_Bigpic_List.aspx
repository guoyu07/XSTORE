<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vote_Bigpic_List.aspx.cs" Inherits="tdx.memb.man.Texts.vote_Bigpic_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投票项目列表</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../js/tdx_member.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>投票项目信息</strong></h1>
    <div class="nei_content">
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <!--提示-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <!--搜索-->
        <div class="nei_seach">
            关键词：<input type="text" placeholder="请输入投票项目进行搜索" value="" name="ss_keyword" id="ss_keyword"
                runat="server" class="px" />
            <input type="button" id="ss_btn" runat="server" value="搜 索" onserverclick="ss_btn_ServerClick"
                class="btnGray" />
            &nbsp;
        </div>
        <div class="btn_container">
            <asp:Literal ID="lb_cateadd" runat="server"></asp:Literal>
            <asp:Button ID="delBtn" runat="server" Text="批量停运" class="btnDelete" OnClick="delBtn_ServerClick" />
        </div>
        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
            <div class="page">
                <asp:Literal ID="lt_pagearrow" runat="server"> </asp:Literal>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
