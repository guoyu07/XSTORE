<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="daohang.aspx.cs" Inherits="tdx.memb.man.daohang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/memb/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
    <%--<h1>
        <strong>欢迎登陆会员管理系统</strong></h1>--%>
    <div class="nei_content">
        <!--center content-->
        <%--<h2>
            <asp:Literal ID="lt_mem" runat="server"></asp:Literal></h2>--%>
        <div style=" text-align:center;"><a href="Sets/wx_mp_add.aspx?nav=true" class="btnSave">我要搭建微官网</a>
        <br />
        <img src="/memb/images4/setUp_flowChart.jpg" alt="创建步骤" style="height: 90%;"/>
        </div>
        
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
