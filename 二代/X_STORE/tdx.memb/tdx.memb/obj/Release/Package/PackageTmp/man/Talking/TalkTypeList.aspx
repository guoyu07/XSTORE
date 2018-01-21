<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkTypeList.aspx.cs" Inherits="tdx.memb.man.Talking.TalkTypeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>帖子类别管理</span>
            <i class="arrow"></i>
            <span>帖子类别列表</span>
        </div>
        <div class="">
            <div class="tsxx">
                <img class="tsxx_1" src="/man/images4/ts.png">
                <span class="tsxx_2">
                    <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
                <img class="tsxx_3" src="/man/images4/xx.png">
            </div>
        </div>

        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li><a class="add" href="TalkTypeEdit.aspx?parent=<%=parents %>&level=<%=levels%>"><i></i><span>新增</span></a></li>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="delBtn" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','确认删除？');" OnClick="delBtn_ServerClick"><i></i><span>删除</span></asp:LinkButton></li>

                </ul>
            </div>
            <%--<div style="float:right;"><asp:Button ID="btn_baobiao" runat="server" CssClass="btn" OnClick="btn_baobiao_Click" Text="导出Excel表格" /></div>--%>
        </div>


        <div class="tdh">
            <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
        </div>
    </form>
    <!--中间结束-->
</body>
</html>