<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarCodeCreate.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GrogshopManage.BarCodeCreate" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <!-- fancybox -->
    <script type="text/javascript" src="../../FancyBox/lib/jquery.mousewheel.pack.js?v=3.1.3"></script>
	<script type="text/javascript" src="../../FancyBox/source/jquery.fancybox.pack.js?v=2.1.5"></script>
	<link rel="stylesheet" type="text/css" href="../../FancyBox/source/jquery.fancybox.css?v=2.1.5" media="screen" />
	<link rel="stylesheet" type="text/css" href="../../FancyBox/source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
	<script type="text/javascript" src="../../FancyBox/source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>
	<link rel="stylesheet" type="text/css" href="../../FancyBox/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
	<script type="text/javascript" src="../../FancyBox/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>
	<script type="text/javascript" src="../../FancyBox/source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>
     <!--  -->
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    


    <script type="text/javascript">
        $(document).ready(function() {
            $(".fancybox").fancybox({
                padding: 0,

                openEffect: 'elastic',
                openSpeed: 150,
                autoScale: false,
                closeEffect: 'elastic',
                closeSpeed: 150,
                autoSize: false,
                closeClick: true,
                maxWidth  : 230,
                maxHeight: 250,
                autoHeight: false,
                autoWidth: false,
                helpers: {
                    overlay: null
                }
            });
            $(".viewfancybox").click(function() {
                $(this).next().click();

            });


        });

        function isshow(id) {
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'IsShow.ashx', //目标地址
                data: "id=" + id,
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
        .hide
        {
            display: none;
        }
    </style>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
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
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">

                        <li>
                            <asp:LinkButton ID="btnLeading" runat="server" OnClick="btnLeading_Click"><i></i><span>导入IMEI</span></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnLeadOut" runat="server" OnClick="btnLeadOut_OnClick"><i></i><span>导出</span></asp:LinkButton>

                        </li>
                        <li>
                            <asp:LinkButton ID="btnDownload" runat="server" OnClick="btnDownload_OnClick"><i></i><span>下载</span></asp:LinkButton>
                        </li>
                    </ul>
                </div>
                  <div class="r-list">
                      <asp:DropDownList runat="server" ID="has_bind_ddl">
                          <asp:ListItem Selected="True" Value="99">--请选择--</asp:ListItem>
                          <asp:ListItem Value="0">未绑定</asp:ListItem>
                          <asp:ListItem Value="1">已绑定</asp:ListItem>
                      </asp:DropDownList>
                      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"/>
                      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
                      
                  </div>
            </div>
        </div>
        <!--/工具栏-->


        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                
                <th style="width: 120px;">IMEI </th>
                <th style="width: 120px;">图片</th>
                <th style="width: 120px;">ICCID|编码</th>

                <th style="width: 150px;">流水号|号码</th>

                <th style="width: 180px;">绑定的房间</th>
                <th style="width: 80px;">是否绑定</th>
                <th style="width: 150px;">绑定时间</th>
                <th style="width: 150px;">创建时间</th>
            </tr>
            <!-- id	 	name	shouzhong	xuzhong	areas	createtime-->
            <asp:Repeater ID="barcode_repeater" runat="server">
                <ItemTemplate>
                    <tr>
                      
                        <td style="text-align: center;"><%#Eval("IMEI")%></td>
                        <td style="text-align: center;"><img class="viewfancybox" style="width: 25px; height: 25px; cursor: pointer;"  src='<%# Eval("图片路径") %>'/>
                            <img class="fancybox" style=" display: none;" src='<%# Eval("图片路径") %>'/>
                        </td>
                        <td style="text-align: center;"><%#Eval("ICCID")%>
                            <br/><%#Eval("二维码下面编码")%></td>
                        <td style="text-align: center;"><%#Eval("流水号")%><br/><%#Eval("号码")%></td>
                        <td style="text-align: center;"><%#Eval("绑定酒店")+"-"+Eval("绑定房间")%></td>
                        <td style="text-align: center;"><%# GetHasBind(Eval("HasBind").ObjToInt(0))%></td>
                        <td style="text-align: center;"><%#Eval("BindTime") == null?"":((DateTime)Eval("BindTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                        <td style="text-align: center;"><%#((DateTime)Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <!--/列表-->
    </form>
</body>
</html>
