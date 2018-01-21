<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.OrdersManage.OrdersList" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="build/My97DatePicker/WdatePicker.js"></script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>子订单管理</span>
            <i class="arrow"></i>
            <span>订单列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">订单编号</span>&nbsp;<asp:TextBox ID="txt_bianhao" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">所属用户</span>&nbsp;<asp:TextBox ID="txt_Telephone" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">收货人</span>&nbsp;<asp:TextBox ID="txt_ren" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                    </ul>
                </div>
            </div>
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>
                            &nbsp;&nbsp;<span style="font-size: 12px;">起始日期</span>&nbsp;<input type="text" class="input Wdate" runat="server" id="Jxl" onclick="WdatePicker()" />&nbsp;&nbsp;&nbsp;<span style="font-size: 12px;">结束日期</span>&nbsp;<input type="text" class="input   Wdate" runat="server" id="Jx2" onclick="    WdatePicker()" /></li>
                        <li>
                           &nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                    </ul>
                </div>
            </div>
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <%--<li><a class="add" href="GoodsEdit.aspx"><i></i><span>新增</span></a></li>--%>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除吗？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                    </ul>
                </div>
                <div style="float: right;">
                    <%--<asp:Button ID="btn_baobiao" runat="server" CssClass="btn" OnClick="btn_baobiao_Click" Text="导出Excel表格" />--%>
                </div>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="7%">选择</th>
                <th width="10%">商品</th>
                <th width="10%">订单编号</th>
                <%--<th width="10%">微信头像<br />
                    微信昵称
                    <br />
                    下单时间</th>--%>
                    <th width="10%">
                    所属用户
                    <br/>
                    昵称
                    <br />
                    下单时间</th>
                <th width="10%">价格
                    <br />
                    数量<br />
                    订单总金额</th>
               <%-- <th width="10%">荐微信头像<br />
                    荐微信昵称<br /> 
                    荐订单号</th>--%>
                <th width="10%">省<br />
                    市<br />
                    区<br />
                    详情地址<br/>
                    手机号<br />
                    收货人</th>
                <th width="10%">备注</th>
                <th width="10%">
                    状态
                </th>
            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>

                        <td style="text-align: center;"><a href="../GoodsManage/GoodsList.aspx?spbh=<%#Eval("商品编号") %>"><%#getpinming(Eval("商品编号").ToString())%></a> </td>
                        <td style="text-align: center;"><%#Eval("订单编号")%></td>
                        <td style="text-align: center;">
                            <%--<img src='<%#gettouxiang(Eval("openid").ToString())%>' style="width: 35px; height: 25px;" alt='<%#Eval("openid")%>' /><br />--%>
                            <%#getuser(Eval("openid").ToString())%><br/>
                            <%#getnicheng(Eval("openid").ToString())%>

                            <br />
                            <%#Eval("下单时间").ToString()%></td>
                        <td style="text-align: center;"><%#Eval("价格")%>
                            <br />
                            <%#Eval("数量")%><br />
                            <%#Eval("总金额")%></td>
                  <%--      <td style="text-align: center;">
                            <img src='<%#gettouxiang(Eval("推荐人openID").ToString())%>' style="width: 35px; height: 25px;" alt='<%#Eval("推荐人openID")%>' /><br />
                            <%#getnicheng(Eval("推荐人openID").ToString())%>
                            <br />
                            <%#Eval("推荐人订单号")%></td>--%>
                        <td style="text-align: center;"><%#Eval("省")%><br />
                            <%#Eval("市")%>
                            <br />
                            <%#Eval("区")%>
                            <br />
                            <%#Eval("详细地址")%><br/>
                            <%#Eval("手机号")%><br />
                            <%#Eval("收货人")%></td>
                            <td style="text-align: center;"><%#Eval("备注")%></td>
                        <td style="text-align: center;">
                           <%-- <%#getispay(Eval("openid").ToString(),Eval("订单编号").ToString()) %>--%>
                          <%#getstate(Eval("is_del").ToString(),Eval("state").ToString()) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--/列表-->


        <%-- 分页2015.6.25 --%>
        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
            <div class="page">
                <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal>
            </div>
        </div>
        <%-- 分页2015.6.25 --%>
    </form>
</body>
</html>
