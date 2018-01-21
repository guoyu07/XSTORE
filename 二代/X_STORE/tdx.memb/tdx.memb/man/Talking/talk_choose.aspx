<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="talk_choose.aspx.cs" Inherits="tdx.memb.man.Talking.talk_choose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //窗口API
            var api = frameElement.api, W = api.opener;
            api.button({
                name: '确定',
                focus: true,
                callback: function () {
                    var choose = "<%=this.choose %>";
                     var values = "";
                     var value = "";
                     $("input[type=checkbox]").each(function () {
                         if ($(this).is(":checked")) {

                             switch (choose) {
                                 case "single":
                                     values = $(this).attr("name").replace("tr", "").replace("div", "");
                                     $("#<%=url %>", api.opener.document).val(values);

                                     break;
                                 case "multiple":
                                     value = $(this).attr("name").replace("tr", "").replace("div", "");
                                     values += value + ",";
                                     break;
                             }
                         }
                     })

                     api.close();
                     return false;

                 }
             }, {
                 name: '取消'
             });
         });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">名称</span>&nbsp;<asp:TextBox ID="txt_pinming" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " /></li>


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

            <div class="toolbar">
                <div class="l-list">
                </div>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="8%">选择</th>
                <th width="6%">编号<br />名称</th>
                <th width="6%">类别号</th>
                <th width="6%">发布人</th>
                <th width="6%">发布时间</th>
                <th width="6%">是否置顶</th>


            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <input type="checkbox" name="tr<%#Eval("id") %>" /><asp:HiddenField ID="hideID" Value='<%#Eval("id")%>' runat="server" />

                        </td>
                        <td style="text-align: center;"><%#Eval("编号")%>
                            <br />
                            <%#Eval("名称")%> </td>
                        <td style="text-align: center;"><%#Eval("类别号")%></td>
                        <td style="text-align: center;"><%#Eval("发布人")%></td>
                        <td style="text-align: center;"><%#Eval("创建时间")%></td>
                        <td style="text-align: center;"><%#Eval("是否置顶").ToString()=="1"?"是":"否"%>
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

