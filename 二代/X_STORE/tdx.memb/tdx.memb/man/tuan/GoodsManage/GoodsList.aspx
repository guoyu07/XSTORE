<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsList.aspx.cs" Inherits="tdx.memb.man.Tuan.GoodsManage.GoodsList" EnableEventValidation="false" ViewStateEncryptionMode="Never" EnableViewStateMac="false" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(function () {
            //控制 显示 显示与不显示 admin显示
            var td = '<%=td%>';

            if (td == 0) {
                $(".tdd").addClass("hide");
                $(".xg").removeClass("hide");
            } else {
                $(".tdd").removeClass("hide");
                $(".xg").addClass("hide");
            }

        });

        function isshow(id) {
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'IsShow.ashx', //目标地址
                data: "id=" + id,
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {

                    if (msg > 0) {
                        var s = $("#span" + id).text();

                        if (s == "通过") {
                            $("#span" + id).text("不通过");
                        }
                        else {
                            $("#span" + id).text("通过");
                        }
                    }
                }
            });
        }


        function yesorno(id) {
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'YesOrNo.ashx', //目标地址
                data: "id=" + id,
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {

                    if (msg > 0) {
                        var s = $("#yesno" + id).text();

                        if (s == "上架") {
                            $("#yesno" + id).text("下架");
                        }
                        else {
                            $("#yesno" + id).text("上架");
                        }
                    }
                }
            });
        }

    </script>
    <style type="text/css">
        .hide {
            display: none;
        }
    </style>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>商品管理</span>
            <i class="arrow"></i>
            <span>商品列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">品名/条形码</span>&nbsp;<asp:TextBox ID="txt_pinming" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>

                        <%--    <li>&nbsp;&nbsp;<span style="font-size: 12px;">用户名</span>&nbsp;<asp:TextBox ID="txt_username" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">手机号</span>&nbsp;<asp:TextBox ID="txt_telephone" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>--%>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>

                    </ul>
                </div>
                <span style="font-size: 12px;">类别</span>&nbsp;
                <div class="rule-single-select">
                    <asp:DropDownList CssClass="input" ID="drp_photo" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="drp_photo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="GoodsEdit.aspx"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                        <li>
                            <asp:TextBox ID="txt_分销率" runat="server" CssClass="input"></asp:TextBox></li>
                        <li>
                            <asp:LinkButton ID="btn_设置分销率" runat="server" OnClick="btn_设置分销率_Click" CssClass="add"><i></i><span>设置分销率</span></asp:LinkButton>
                        </li>

                        <li>
                            <asp:LinkButton ID="btn_批量上架" runat="server" OnClick="btn_批量上架_Click" CssClass="add"><i></i><span>批量上架</span></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="btn_批量下架" runat="server" OnClick="btn_批量下架_Click" CssClass="add"><i></i><span>批量下架</span></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton></li>

                    </ul>
                </div>
                <%--<div style="float:right;"><asp:Button ID="btn_baobiao" runat="server" CssClass="btn" OnClick="btn_baobiao_Click" Text="导出Excel表格" /></div>--%>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="5%">选择</th>
                <%--     <th width="8%">用户名<br/>手机号</th>--%>

                <th width="6%">缩略图</th>
                <th width="15%">条形码<br />
                    品名</th>
                <th width="6%">类别</th>
                <th width="6%">单位<br />
                    规格</th>
                <th width="6%">重量</th>
                <th width="6%">市场价<br />
                    团购价</th>
                <th width="6%">库存<br />
                    已售数量<br />
                    限购数量</th>
                <th width="6%">上架时间<br />
                    下架时间</th>

                <th width="6%">上架/下架</th>
                <th width="6%">团购/秒杀/预售</th>
                <%--                <th width="6%">折扣率</th>--%>
                <th width="6%">分销率<br />
                    折扣率</th>
                <th width="6%">是否卖家承担运费</th>
                <%--                <th width="6%">满多少包邮</th>--%>
                <th width="10%" colspan="3">操作</th>
            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("商品id")%>' runat="server" />
                        </td>
                        <%--     <td style="text-align: center;"><%#Eval("user_name")%><br/><%#Eval("telephone")%></td>--%>
                        <td style="text-align: center "><img src="<%#Eval("图片路径")%>" width="60" height="60"/> </td>
                            <td style="text-align: center;"><%#Eval("编号New")%>
                                <br />
                                <%#Eval("品名")%> </td>
                            <td style="text-align: center;"><%#Eval("c_name")%></td>
                            <td style="text-align: center;"><%#Eval("单位")%><br />
                                <%#Eval("规格")%></td>
                            <td style="text-align: center;"><%#Convert.ToDecimal(Eval("重量")).ToString("f2")%></td>
                            <td style="text-align: center;">
                                <dl>
                                    <dt><%#Eval("市场价")%></dt>
                                    <dt><%#Eval("本站价")%></dt>
                                </dl>
                            </td>
                            <td style="text-align: center;"><%#Eval("库存数量")%><br />
                                <%#Eval("salenum")%><br />
                                <%#Eval("限购数量")%></td>
                            <td style="text-align: center;">
                                <dl>
                                    <dt><%#Eval("上架时间")%></dt>
                                    <dt><%#Eval("下架时间")%></dt>
                                </dl>
                            </td>
                            <td class="tdd hide" style="text-align: center;"><a href="javascript:;" onclick='isshow(<%#Eval("商品id")%>)'><span id='span<%#Eval("商品id")%>'><%#Eval("IsShow").ToString()=="1"?"通过":"不通过"%></span></a></td>
                            <td style="text-align: center;"><a href="javascript:;" onclick='yesorno(<%#Eval("商品id")%>)'><span id='yesno<%#Eval("商品id")%>'><%#Eval("是否上架").ToString()=="1"?"上架":"下架"%></span></a></td>
                            <td style="text-align: center;"><%#GetTypeTuan(Eval("isTuan").ToString())%></td>
                            <%--                        <td style="text-align: center;"><%#Eval("折扣率")%></td>--%>
                            <td style="text-align: center;"><%#Eval("分销率")%><br />
                                <%#Eval("折扣率")%></td>
                            <td style="text-align: center;"><%#Eval("是否卖家承担运费").ToString()=="1"?"是":"否"%></td>
                            <%--                        <td style="text-align: center;"><%#Eval("满多少包邮")%></td>--%>
                            <td style="text-align: center;"><a href="GoodsEdit.aspx?id=<%#Eval("商品id")%>">修改</a> </td>
                                                <td style="text-align: center;"><a href="../../Shop/GoodsManage/GoodsComment.aspx?spid=<%#Eval("商品id")%> &types=TM ">查看评论</a> </td>
                            <td style="text-align: center;"><a onclick="window.open('/shop/chanpintuangou.aspx?gid=<%#Eval("商品id")%>&WHC=123', '', 'height=543,width=376,scrollbars=yes,status=yes');">预览</a> </td>
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
