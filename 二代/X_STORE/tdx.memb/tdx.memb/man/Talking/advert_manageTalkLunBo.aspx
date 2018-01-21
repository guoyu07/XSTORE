<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advert_manageTalkLunBo.aspx.cs" Inherits="tdx.memb.man.Talking.advert_manageTalkLunBo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
   <!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="../Shop/advert_manage.aspx"><span>广告管理</span></a>
  <i class="arrow"></i>
  <span>内容列表</span>
</div>
<!--/导航栏-->
<!--工具栏-->
<%--<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="text-list">

    </div>
    <div class="clear line10"></div>
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="../Talking/advert_operateTalk.aspx?Act=Add"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
    <div class="r-list">
    </div>
  </div>
</div>--%>
    <!--列表展示.开始-->
    <asp:Repeater ID="rptList1" runat="server" >
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
      <tr>
        <th width="60px">选择</th>
        <th align="left" style="width:150px">代码</th>
        <th align="left">名称</th>
        <th width="60px">操作</th>
      </tr>
    <!--advert=A--> 
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hideID" Value='<%#Eval("id")%>' runat="server" /></td>
        <td align="left"><%#Eval("code")%></td>
        <td align="left"><%#Eval("name")%></td>
        <td>
           <a href="advert_operateTalkLunBo.aspx?ID=<%#Eval("id")%>&Act=Edit">修改</a><iframe name='ajax' style="display:none"></iframe>
        </td>
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
