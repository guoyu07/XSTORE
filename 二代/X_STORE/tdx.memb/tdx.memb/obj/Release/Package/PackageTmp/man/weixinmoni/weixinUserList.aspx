<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weixinUserList.aspx.cs" Inherits="tdx.memb.man.weixinmoni.weixinUserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkAll(field, c) {
            for (i = 0; i < field.length; i++)
                field[i].checked = c.checked;
        }
    </script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>粉丝统计</strong></h1>
    <div class="nei_content" id="nei_content">
     <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <!--内容-->
        <div class="nei_seach">
            <input type="text" id="sousuo_txt" runat="server" class="sousuo_px" placeholder="请选择相应条件，填写对应内容进行查询">
            <input id="Button1" type="button" value="搜索" runat="server" onserverclick="btn_save_ServerClick"
                class="btnGray">
            <input id="Button2" type="button" value="导出EXCEL" runat="server" onserverclick="btn_downexcel"
                class="btnSave">
            <asp:Literal ID="xiazai" runat="server"></asp:Literal>
        </div>
        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
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

