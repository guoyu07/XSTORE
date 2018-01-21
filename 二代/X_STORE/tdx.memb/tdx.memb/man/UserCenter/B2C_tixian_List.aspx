<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_tixian_List.aspx.cs" Inherits="tdx.memb.man.UserCenter.B2C_tixian_List" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提现申请列表</title>
    <script src="../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
<%--    <script src="../JS/WdatePicker.js" type="text/javascript"></script>--%>
    <script src="../JS/lhgdialog.js?skin=idialog" type="text/javascript"></script>
<%--    <script src="../JS/skins/WdatePicker.js" type="text/javascript"></script>--%>
        <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../JS/layout.js" type="text/javascript"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<%--    <link href="../CSS/WdatePicker.css" rel="stylesheet" />--%>
        <link href="../../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" />
    <link href="../CSS/nei.css" rel="stylesheet" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>提现申请列表</span>
        </div>
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:;" onclick="checkAll2(this);"><i></i><span>全选</span></a></li>
<%--                        <li><a class="add" href="B2C_tixian_Add.aspx"><i></i><span>新增</span></a></li>--%>
                        <li>
                            <asp:LinkButton ID="lkbtnstar" runat="server" CssClass="add" OnClick="lkbtnstar_Click"><i></i><span>通过</span></asp:LinkButton>

                        </li>
                        <li>
                            <asp:LinkButton ID="lkbtnstar2" runat="server" CssClass="add"
                                OnClick="lkbtnstar2_Click"><i></i><span>驳回</span></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lkbtnstar3" runat="server" CssClass="add"
                                OnClick="lkbtnstar3_Click"><i></i><span>已付款</span></asp:LinkButton>
                        </li>

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
                        <td>关键词：
                            <%--                        <input type="text" value="" class="px" name="ss_keyword" id="ss_keyword" runat="server" style="width: 256px" />--%>
                            <asp:TextBox ID="ss_keyword" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                            <div class="rule-single-select">
                                <select name="ss_cid" id="ss_cid" size="1" class="select-field" runat="server" style="width: 180px">
                                    <option value="0">按手机号</option>
                                    <option value="1">按真实姓名</option>
                                </select>
                            </div>
                            <div class="rule-single-select">
                                <select name="ss_cityID" id="ss_cityID" size="1" class="select-field" runat="server" style="width: 180px">
                                    <option value="">全部</option>
                                    <option value="0">申请</option>
                                    <option value="-1">拒绝</option>
                                    <option value="1">批准</option>
                                    <option value="2">已付款</option>
                                </select>&nbsp;
                            </div>
                            <input type="button" id="ss_btn" runat="server" style="clear: both; width: 50px;" class="input" value="搜 索" onserverclick="ss_btn_ServerClick" />

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

