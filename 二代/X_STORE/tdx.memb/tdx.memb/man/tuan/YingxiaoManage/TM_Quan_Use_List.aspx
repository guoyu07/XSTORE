﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TM_Quan_Use_List.aspx.cs" Inherits="tdx.memb.man.tuan.YingxiaoManage.TM_Quan_Use_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>优惠券使用列表</title>
    <script src="../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../skin/nei.css" rel="stylesheet" />
     <script src="../JS/layout.js" type="text/javascript"></script>
    <script src="../../../js/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>优惠券使用列表</span>
        </div>
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:;" onclick="checkAll2(this);"><i></i><span>全选</span></a></li>
                        <%--                        <li><a class="add" href="TM_Quan_Add.aspx"><i></i><span>新增</span></a></li>  --%>
                        <li>
                            <asp:LinkButton ID="btnDelete1" runat="server" CssClass="del" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" OnClick="btnDelete1_Click"><i></i><span style="clear: both; width: 70px; color:red;" >彻底删除</span></asp:LinkButton>
                        </li>

                    </ul>
                </div>
            </div>
        </div>
        <div class="nei_seach">
            <div class="r-list">
                <table border="0" width="100%">
                    <tr>
                        <td>
<%--                            关键词：<input type="text" value="" class="px" name="ss_keyword" id="ss_keyword" runat="server" style="width: 256px" />
                            &nbsp;--%>
                                             时间：
                        <asp:TextBox ID="txtbtime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})">
                        </asp:TextBox>To:
                         <asp:TextBox ID="txtetime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                            <input type="button" id="ss_btn" runat="server" style="clear: both; width: 50px;" class="input" value="搜 索" onserverclick="ss_btn_ServerClick" />
                             <asp:LinkButton ID="lbtn_Export" runat="server" CssClass="btn" OnClick="lbtn_Export_Click"><span>优惠券信息导出</span></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <table width="100%" cellpadding="4" cellspacing="0" border="0">
            <tr>
                <td coslpan="2" align="center" colspan="2">
                    <asp:Literal ID="lb_prolist" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2">
                    <asp:Literal ID="lt_pagearrow" runat="server" EnableViewState="False"> </asp:Literal>
                </td>
            </tr>

        </table>

    </form>
</body>
</html>
