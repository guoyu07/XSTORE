<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="center.aspx.cs" Inherits="tdx.memb.admin.center" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>管理首页</title>
<link href="skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/layout.js"></script>
    <link href="skin/additional.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>管理中心</span>
</div>
<!--/导航栏-->

<!--内容-->
<div class="line10"></div>
<div class="nlist-1">
  <ul>
    <li>本次登录IP：<asp:Literal ID="litIP" runat="server" Text="-" /></li>
    <li>上次登录IP：<asp:Literal ID="litBackIP" runat="server" Text="-" /></li>
    <li>上次登录时间：<asp:Literal ID="litBackTime" runat="server" Text="-" /></li>
  </ul>
</div>
<div class="line10"></div>

<div class="datalist">
   <h3>数据统计</h3>
   <ul>
      <li>产品:<span id="pros">0</span></li>
      <li>页面:<span id="pages"></span></li>
      <li>新闻:<span id="news"></span></li>
      <li>图片:<span id="pics"></span></li>
      <%--<li>下载:<span id="download"></span></li>--%>
      <li>微信:<span id="wechat"></span></li>
      <li>订单:<span id="orders"></span></li>
   </ul>
</div>
<script type="text/javascript">
    function getCountInfor() {
        $.ajax({
            type: "get",
            url: "../tools/myopera.ashx",
            data: { 'type': 'getcount' },
            dataType: "json",
            success: function (data) {
                if (data != null) {
                    $("#pros").text(data.goods);
                    $("#pages").text(data.pages);
                    $("#news").text(data.news);
                    $("#pics").text(data.pics);
                    $("#wechat").text(data.wechat);
                    $("#orders").text(data.orders);
                }
            }
        });
    }
    getCountInfor();
</script>
<div class="line20"></div>
<div class="nlist-2">
  <h3><i></i>站点信息</h3>
  <ul>
    <li>站点名称：<%=siteConfig.webname %></li>
    <li>安装目录：<%=siteConfig.webpath %></li>
    <li>网站管理目录：<%=siteConfig.webmanagepath %></li>
    <li>附件上传目录：<%=siteConfig.filepath %></li>
    <li>服务器名称：<%=Server.MachineName%></li>
    <li>服务器IP：<%=Request.ServerVariables["LOCAL_ADDR"] %></li>
    <li>NET框架版本：<%=Environment.Version.ToString()%></li>
    <li>操作系统：<%=Environment.OSVersion.ToString()%></li>
    <li>IIS环境：<%=Request.ServerVariables["SERVER_SOFTWARE"]%></li>
    <li>服务器端口：<%=Request.ServerVariables["SERVER_PORT"]%></li>
    <li>目录物理路径：<%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%></li>
    <li>系统版本：V<%=DTcms.Common.Utils.GetVersion()%></li>
  </ul>
</div>




<!--/内容-->
</form>
</body>
</html>
