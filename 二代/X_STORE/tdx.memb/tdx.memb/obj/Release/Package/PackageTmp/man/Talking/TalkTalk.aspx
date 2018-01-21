<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkTalk.aspx.cs" Inherits="tdx.memb.man.Talking.TalkTalk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />

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
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>评论管理</span>
            <i class="arrow"></i>
            <span>评论列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">帖子名称</span>&nbsp;<asp:TextBox ID="txt_pinming" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>

                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                    </ul>
                </div>
<%--                <span style="font-size: 12px;">类别</span>&nbsp; 
                <div class="rule-single-select">
                    <asp:DropDownList CssClass="input" ID="drp_photo" runat="server"
                        AutoPostBack="true" OnSelectedIndexChanged="drp_photo_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>--%>
            </div>

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
<%--                        <li><a class="add" href="TalkEdit.aspx"><i></i><span>新增</span></a></li>--%>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

                    </ul>
                </div>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="8%">选择</th>
                <th width="6%">帖子名称</th>
                <th width="6%">类别号<br/>类别</th>
                <th width="6%">评论内容</th>
                <th width="6%">评论时间</th>
                <th width="6%">评论人</th>

            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("名称")%></td>
                        <td style="text-align: center;"><%#Eval("类别编号")%><br/><%#Eval("类别名")%></td>
                                                <td style="text-align: center;"><%#Eval("评论内容")%></td>
                        <td style="text-align: center;"><%#Eval("评论时间")%></td>
                        <td style="text-align: center;"><%#Eval("wx昵称")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--/列表-->

        <%-- 分页 --%>
        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
            <div class="page">
                <asp:Literal ID="lt_pagearrow" runat="server"></asp:Literal>
            </div>
        </div>
        <%-- 分页 --%>
    </form>
</body>
</html>
