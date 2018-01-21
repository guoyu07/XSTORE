<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPhotoList.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.GoodsPhotoList" %>
 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
    <script type="text/javascript">
        $(function () {
            //控制 显示 显示与不显示 admin显示
            var td = '<%=td%>';

             if (td == 0) {
                 
                 $(".xg").removeClass("hide");
             } else {
                
                 $(".xg").addClass("hide");
             }
              
         });
    </script>
     <style type="text/css">
        .hide {
        display:none;
        } 
    </style>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>商品管理</span>
            <i class="arrow"></i>
            <span>商品图片</span>
        </div>
        <!--/导航栏-->
        <br/>
        <span style="font-size: 12px;">品名</span>&nbsp;  <div class="rule-single-select"> <asp:DropDownList CssClass="input" ID="drp_photo" runat="server" OnSelectedIndexChanged="drp_photo_SelectedIndexChanged"  AutoPostBack="true" ></asp:DropDownList></div>
        <!--工具栏-->
        <div class="toolbar-wrap">
           
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="GoodsPhotoEdit.aspx"><i></i><span>新增</span></a></li> 
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
                <th width="6%">标题</th>
                <th width="6%">图片</th>
                <th width="8%">操作</th>
              
               
            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("标题")%></td>
                         
                        <td style="text-align: center;">
                            <img src='<%#Eval("图片路径")%>' style="width: 50px; height: 25px;" /></td>

                        <td  style="text-align: center;"><a href="GoodsPhotoEdit.aspx?id=<%#Eval("id")%>">修改</a> </td>
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
