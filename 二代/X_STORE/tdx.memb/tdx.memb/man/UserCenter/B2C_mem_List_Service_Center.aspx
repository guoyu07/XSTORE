<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_mem_List_Service_Center.aspx.cs" Inherits="tdx.memb.man.UserCenter.B2C_mem_List_Service_Center" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员列表</title>
    <script src="../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../JS/lhgdialog.js?skin=idialog" type="text/javascript"></script>
    <script src="../JS/layout.js" type="text/javascript"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/nei.css" rel="stylesheet" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>待审会员列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:;" onclick="checkAll2(this);"><i></i><span>全选</span></a></li>
                        <li><a class="add" href="B2C_mem_Add_Service_Center.aspx?M_isactive=-2"><i></i><span>新增</span></a></li>

                        <li>
                            <asp:LinkButton ID="lkbtnstar" runat="server" CssClass="add" OnClick="lkbtnstar_Click"><i></i><span>审核通过</span></asp:LinkButton>

                        </li>
                        <li>
                            <asp:LinkButton ID="lkbtnstar2" runat="server" CssClass="add"
                                OnClick="lkbtnstar2_Click"><i></i><span>审核拒绝</span></asp:LinkButton>

                        </li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton>
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
<%--                            <input type="text" value="" class="px" name="ss_keyword" id="ss_keyword" runat="server" style="width: 256px" />--%>
                            <asp:TextBox ID="ss_keyword" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                            <div class="rule-single-select">
                                <select name="ss_cid" id="ss_cid" size="1" class="select-field" runat="server" style="width: 180px">
                                    <option value="0">按手机号</option>
                                    <option value="1">按真实姓名</option>
                                </select>&nbsp;
                            </div>
                            <div class="rule-single-select">
                                <select name="ss_cityID" id="ss_cityID" size="1" class="select-field" runat="server" style="width: 180px">
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
            <tr>
                <td height="30" colspan="2">&nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>



