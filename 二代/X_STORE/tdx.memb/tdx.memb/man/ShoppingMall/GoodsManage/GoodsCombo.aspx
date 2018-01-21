<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsCombo.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GoodsManage.GoodsCombo" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
        //弹窗
        function open_dialog(sender) {
            var h = 500;
            //var w = $(window).width() / 2;
            var w = 800;
            var obj = $(sender);
            var id = obj.attr("hotel-id");
            var show = $.dialog({
                id: 'suibian',
                lock: true,
                min: false,
                title: "",
                content: 'url:ShoppingMall/GoodsManage/GoodsConfig.aspx?id=' + id,
                width: w,
                height: h

            });
            show.data = window.document;
            show.window = window;
        }


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

        function sorx(id) {
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'SOrX.ashx', //目标地址
                data: "id=" + id,
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {

                    if (msg > 0) {
                        var s = $("#sorx" + id).text();

                        if (s == "是") {
                            $("#sorx" + id).text("否");
                        }
                        else {
                            $("#sorx" + id).text("是");
                        }
                    }
                }
            });
        }
        function addCombo() {
            window.location.href = 'GoodsAddCombo.aspx';
        }


    </script>

    <style type="text/css">
        .auto-style1 {
            width: 27px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
            <%-- <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>商品管理</span>
            <i class="arrow"></i>
            <span>商品列表</span>--%>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">品名/条形码</span>&nbsp;
                            <asp:TextBox ID="txt_pinming" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                        <li>&nbsp;&nbsp;<span style="font-size: 12px;">编码</span>&nbsp;
                                <asp:TextBox ID="txt_bianma" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                        </li>
                    </ul>
                </div>
                <span style="font-size: 12px;">类别</span>&nbsp; 
                <div class="rule-single-select">
                    <asp:DropDownList CssClass="input" ID="drp_photo" runat="server"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <span style="font-size: 12px;">上下架</span>&nbsp; 
                    <div class="rule-single-select">
                        <asp:DropDownList CssClass="input" ID="sxj" runat="server"
                            AutoPostBack="true">
                            <asp:ListItem Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">上架</asp:ListItem>
                            <asp:ListItem Value="2">下架</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                <div class="l-list">
                    <ul class="icon-list">
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LBtn_sousuo" runat="server" OnClick="LBtn_sousuo_Click"><span>搜索</span></asp:LinkButton></span></li>
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;<span style="border-left: solid 1px #e1e1e1"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="open_combo"><span>单样</span></asp:LinkButton></span></li>
                    </ul>
                </div>
            </div>

            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <%--  <li><a class="add" href="GoodsAddCombo.aspx"><i></i><span>新增</span></a></li>--%>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>

<%--
                        <li>
                            <asp:TextBox ID="txt_distribution" runat="server" CssClass="input"></asp:TextBox></li>
                        <li>
                          <asp:LinkButton ID="btn_save_distribution" runat="server" OnClick="btn_save_distribution_Click" CssClass="add"><i></i><span>设置折扣率</span></asp:LinkButton></li>--%>  
                        <li>
                            <asp:LinkButton ID="btn_batch_putaway" runat="server" OnClick="btn_batch_putaway_Click" CssClass="add"><i></i><span>批量上架</span></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="btn_batch_soldout" runat="server" OnClick="btn_batch_soldout__Click" CssClass="add"><i></i><span>批量下架</span></asp:LinkButton></li>
                        <%--<li><asp:LinkButton CssClass="add" id="btn_combined_package" onclick="btn_combined_package_Click" runat="server"><i></i><span>组合套餐</span></asp:LinkButton></li>--%>
                        <li>
                            <asp:LinkButton ID="LBtn_Export" runat="server" OnClick="LBtn_Export_Click" CssClass="add"><i></i><span>导出</span></asp:LinkButton></li>
                    </ul>
                </div>
                <%--<div style="float:right;"><asp:Button ID="btn_baobiao" runat="server" CssClass="btn" OnClick="btn_baobiao_Click" Text="导出Excel表格" /></div>--%>
            </div>
        </div>
        <!--/工具栏-->
        <!--列表-->
        <table style="width:100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th style="width:5%">选择</th>
                <%--     <th style="width:8%">用户名<br/>手机号</th>--%>
                <th style="width:6%">缩略图</th>
                <th style="width:15%">条形码<br />
                    品名</th>
                <th style="width:6%">类别</th>
                <th style="width:6%">单位<br />
                    规格</th>
                <th style="width:6%">重量</th>
                <th style="width:6%">市场价<br />
                    本站价</th>
                <th style="width:6%">库存<br />
                    已售数量<br />
                    限购数量</th>
                <th style="width:6%">上架时间<br />
                    下架时间</th>
                <th style="width:6%">上架/下架</th>
<%--                <th style="width:6%">折扣率</th>--%>

                <th style="width:6%">是否卖家承担运费</th>
                <%--                <th style="width:6%">满多少包邮</th>--%>
                <th style="width:10%" colspan="3">操作</th>
            </tr>
            <asp:Repeater ID="sptList1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox name="angel" ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("商品id")%>' runat="server" />
                        </td>
                        <%--     <td style="text-align: center;"><%#Eval("user_name")%><br/><%#Eval("telephone")%></td>--%>
                        <td style="text-align: center">
                            <img src="<%#Eval("图片路径")%>" style="width:60" height="60" />
                        </td>
                        <td style="text-align: center;"><%#Eval("编号new")%>
                            <br />
                            <%#Eval("品名")%> </td>
                        <td style="text-align: center;"><%#Eval("编码")%></td>
                        <td style="text-align: center;"><%#Eval("类别")%></td>
                        <td style="text-align: center;"><%#Eval("单位")%><br />
                            <%#Eval("规格")%></td>
                        <td style="text-align: center;"><%#DTcms.Common.Utils.ObjToDecimal(Eval("重量"),0).ToString("f2")%></td>
                        <td style="text-align: center;">
                            <dl>
                                <%#Eval("市场价")%>
                                <br />
                                <%#Eval("本站价")%>
                            </dl>
                        </td>
                        <td style="text-align: center;"><%#Eval("库存数量")%><br />
                            <%#Eval("已售数量")%><br />
                            <%#Eval("限购数量")%></td>
                        <td style="text-align: center;">
                            <dl>
                                <dt><%#Eval("上架时间") %></dt>
                                <dt><%#Eval("下架时间")%></dt>
                            </dl>
                        </td>

                        <%-- <td style="text-align: center;"><%#Eval("库存数量")%></td>--%>
                        <%--  <td style="text-align: center;"><%#Eval("类型").ToString()=="1"?"普通":Eval("类型").ToString()=="2"?"返利":"红包"%></td>--%>
                        <%--                        <td style="text-align: center;"><a href="GoodsPhotoList.aspx?spbh=<%#Eval("编号")%>">查看图片</td>--%>
                        <%--<td class="tdd hide" style="text-align: center;"><a href="javascript:;" onclick='isshow(<%#Eval("商品id")%>)'><span id='span<%#Eval("商品id")%>'><%#Eval("IsShow").ToString()=="1"?"通过":"不通过"%></span></a></td>--%>
                        <td style="text-align: center;"><a href="javascript:;" onclick='yesorno(<%#Eval("商品id")%>)'><span id='yesno<%#Eval("商品id")%>'><%#Eval("是否上架").ToString()=="1"?"上架":"下架"%></span></a></td>
                      <%--  <td style="text-align: center;">
                            <%#Eval("折扣率")%></td>--%>
                        <td style="text-align: center;"><a href="javascript:;" onclick='sorx(<%#Eval("商品id")%>)'><span id='sorx<%#Eval("商品id")%>'><%#Eval("是否卖家承担运费").ToString()=="1"?"是":"否"%></span></a></td>
                        <%--                        <td style="text-align: center;"><%#Eval("是否卖家承担运费").ToString()=="1"?"是":"否"%></td>--%>
                        <%--                        <td style="text-align: center;"><%#Eval("满多少包邮")%></td>--%>

                        <td style="text-align: center;"><a href="GoodsEdit.aspx?id=<%#Eval("商品id")%>">修改</a>
                            <a href=" javascript:void(0);" onclick="open_dialog(this)" hotel-id='<%#Eval("商品id")%>'>配置</a>
                            <%--<a onclick="window.open('/shop/chanpin.aspx?gid=<%#Eval("商品id")%>&WHC=123', '', 'height=543,width=376,scrollbars=yes,status=yes');">预览</a> </td>--%>
                    </tr>
                </ItemTemplate>



            </asp:Repeater>

        </table>
        <!--/列表-->
        <%-- 分页2017-4-24 --%>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页" CssClass="paginator" 
            NextPageText="下一页" OnPageChanging="AspNetPager1_PageChanging"  
            CurrentPageButtonClass="cpb" PrevPageText="上一页">
        </webdiyer:AspNetPager>
        <%--  分页2017-4-24 --%>
    </form>
</body>
</html>
