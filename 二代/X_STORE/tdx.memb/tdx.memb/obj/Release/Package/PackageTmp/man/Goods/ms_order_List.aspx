<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ms_order_List.aspx.cs" Inherits="tdx.memb.man.Goods.ms_order_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="../images4/nei.css" type="text/css" rel="stylesheet">
      <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/tdx_date.js" type="text/javascript"></script>
    <title>后台管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript" language="javascript" src="../../js/calendar.js" charset="utf-8"></script>
    <h1>
        <strong>秒杀订单</strong></h1>
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
        <div class="nei_seach">
            订单编号：<input type="text" value="" name="ss_keyword" id="ss_keyword" runat="server" placeholder="请输入订单号查询"
                class="sousuo_px" onclick="this.value='';" />
            &nbsp;<input id="txt_StartCPXG" runat="server" cssclass="edLine" onfocus="HS_setDate(this)" readonly="readonly" placeholder="请输入起始时间，缺省从当月1号开始"
                class="sousuo_px" type="text" />
            &nbsp;
            <input id="txt_StartCPXG_DATE" runat="server" cssclass="edLine" onfocus="HS_setDate(this)" readonly="readonly" placeholder="请输入截止时间，缺省截止到当天"
                class="sousuo_px" type="text" />
            &nbsp;
            <select name="txt_cid" id="txt_cid" size="1" runat="server" class="select-field_sousuo">
            </select>
            &nbsp;&nbsp;
            <input type="checkbox" name="ss_isDel" id="ss_isDel" value="1" runat="server" />回收站&nbsp;&nbsp;
            <asp:Button ID="ss_btn" runat="server" OnClick="ss_btn_Click" Text="搜索" CssClass="btnGray" /></div>
        <div class="btn_container">
            <input id="isdelBtn" type="button" runat="server" class="btnGray" value="删 除" onserverclick="isdelBtn_ServerClick" />
            <asp:Button ID="delBtn" runat="server" Text="彻底删除" class="btnDelete" OnClick="delBtn_ServerClick"
                OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" /></div>
        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
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

