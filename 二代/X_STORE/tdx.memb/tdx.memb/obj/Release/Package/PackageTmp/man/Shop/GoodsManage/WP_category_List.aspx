<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WP_category_List.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.WP_category_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <%--  <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>--%>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <script src="../../js/layout.js"></script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>商品管理</span>
            <i class="arrow"></i>
            <span>商品类别列表</span>
        </div>
        <!--/导航栏-->
        <%--        <h1>
            <strong>商品类别列表</strong></h1>--%>
        <div class="">
            <div class="tsxx">
                <img class="tsxx_1" src="/man/images4/ts.png">
                <span class="tsxx_2">
                    <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
                <img class="tsxx_3" src="/man/images4/xx.png">
            </div>
        </div>
        <%--            <div class="btn_container">
                <asp:Literal ID="lb_cateadd" runat="server"></asp:Literal>
                <asp:Button ID="delBtn" runat="server" Text="彻底删除" class="btnDelete"
                    OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" />
            </div>--%>

        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <%--                    <li><a class="add" href="WP_category_Add.aspx?parent=<%=parents %>&level=<%=levels%>"><i></i><span>新增</span></a></li>--%>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <%--   <li><input class="all" type="checkbox" name="delAll"  id="delAll" onclick="this.value=checkAll(form1.delbox,this)";/><i></i>全选</li> --%>
                    <li>
                        <asp:LinkButton ID="delBtn" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="delBtn_ServerClick"><i></i><span>删除</span></asp:LinkButton></li>

                </ul>
            </div>
            <%--<div style="float:right;"><asp:Button ID="btn_baobiao" runat="server" CssClass="btn" OnClick="btn_baobiao_Click" Text="导出Excel表格" /></div>--%>
        </div>

        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th>选择</th>
                <th>编号</th>
                <th>名称</th>
                <th>排序</th>
                <th width="6%">图片</th>
                <th width="8%">操作</th>


            </tr>
            <asp:Repeater ID="Rp_UserInfo" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("c_id")%>' runat="server" />
                        </td>
                        <td style="text-align: center;"><%#Eval("c_no")%></td>
                        <td style="text-align: center;"><a href='?level=<%#Eval("c_level")%>&parent=<%#Eval("c_id")%>'><%#Eval("c_name")%></a></td>
                        <td style="text-align: center;"><%#Eval("c_sort")%></td>
                        <td style="text-align: center;">
                            <img src='<%#Eval("c_gif")%>' style="width: 50px; height: 25px;" /></td>
                        <td style="text-align: center;"><a href="WP_category_Add.aspx?id=<%#Eval("c_id")%>">
                            <img width="20" height="20" src="/man/images4/Icon_xiugai.png"></a> </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>



        <%--        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
        </div>--%>
    </form>
    <!--中间结束-->
</body>
</html>

