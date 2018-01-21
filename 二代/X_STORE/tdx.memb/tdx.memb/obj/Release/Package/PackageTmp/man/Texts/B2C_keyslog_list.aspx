<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_keyslog_list.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_keyslog_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_date.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 220px;
        }
    </style>
    <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>
    <script type="text/javascript">
        $(function () {
            $(".btnReply").click(function () {
                mask($(this));
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>粉丝咨询记录</strong>
    </h1>
    <input type="hidden" id="txtSql" name="txtSql" value="1=1" runat="server" enableviewstate="false" />
    <div class="nei_content" id="nei_content">    
     <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>  
        <div class="nei_seach">
            开始时间:&nbsp;<input type="text" id="kaishi" onfocus="HS_setDate(this)" class="sousuo_px"
                readonly="readonly" runat="server" placeholder="请选择开始时间">
            结束时间:&nbsp;<input type="text" id="jieshu" onfocus="HS_setDate(this)" class="sousuo_px"
                readonly="readonly" runat="server" placeholder="请选择结束时间">
            昵称:&nbsp;<input type="text" id="weixin" runat="server" class="sousuo_px" placeholder="请输入要查询的昵称">
            <input type="button" id="sousuo" runat="server" value="搜 索" onserverclick="btn_Sousuo_ServerClick"
                class="btnGray" />
            <input type="button" id="ss_btn" runat="server" value="" onserverclick="ss_btn_ServerClick"
                class="btnGray" style="display:none" />
        </div>
        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false">
            </asp:Literal>
        </div>
        <div class="tdh">
            <div class="page">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
        </div>
        <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal>
    </div>    
    </form>
</body>
</html>

