<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zuji_manage.aspx.cs" Inherits="tdx.memb.man.Shop.zuji_manage" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="advert_manage.aspx"><span>浏览量统计</span></a>
            <i class="arrow"></i>
            <span>内容列表</span>
        </div>
        <!--/导航栏-->
        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="text-list">
                    开始时间<input type="text" class="input normal Wdate" runat="server" id="txt_starttime" onclick="WdatePicker()" />
                    结束时间<input type="text" class="input normal Wdate" runat="server" id="txt_endtime" onclick="WdatePicker()" />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>

                </div>
                <%-- <div class="clear line10"></div>
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="add" href="advert_operate.aspx?Act=Add"><i></i><span>新增</span></a></li>
                        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                        <li>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                    </ul>
                </div>
                <div class="r-list">
                </div>--%>
            </div>
        </div>
        <!--列表展示.开始-->
        <asp:Repeater ID="rptList1" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th align="center">商品名称</th>
                        <th align="left" width="150px">浏览量</th>
                    </tr>
                    <!--advert=A-->
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%#Eval("name")%></td>
                    <td align="left"><%#Eval("num")%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList1.Items.Count == 0 ? "<tr><td align='center' colspan='4'>暂无记录</td></tr>" : ""%>
      </table>
            </FooterTemplate>
        </asp:Repeater>
        <!--列表展示.结束-->
        <!--工具栏-->

        <!--/工具栏-->
    </form>
</body>
</html>
