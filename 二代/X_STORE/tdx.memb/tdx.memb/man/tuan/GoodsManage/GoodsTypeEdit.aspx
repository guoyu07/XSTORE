<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsTypeEdit.aspx.cs"
    Inherits="tdx.memb.man.Tuan.GoodsManage.GoodsTypeEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>商品管理</span> <i class="arrow"></i><span>商品类别添加</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">商品类别</a></li>
                </ul>
            </div>
        </div>
    </div>
    <%-- 商品 --%>
    <div class="tab-content">
        <dl>
            <dt>类别名</dt>
            <dd>
                <asp:TextBox ID="txt_leibieming" runat="server" placeholder="类别名不能为空" MaxLength="255"
                    CssClass="input normal" />
                <span class="Validform_checktip">*必填</span>
            </dd>
        </dl>
        <dl>
            <dt>类别编号</dt>
            <dd>
                <asp:TextBox ID="txt_leibiebianhao" runat="server" ReadOnly="true" MaxLength="255"
                    CssClass="input normal" />
            </dd>
        </dl>
        <dl>
            <dt>图片</dt>
            <dd>
                <img src='<%=src %>' style='width: 7%; height: 7%;' /><br />
                <asp:TextBox ID="txt_img" runat="server" MaxLength="255" CssClass="input normal" />
                <input type="file" name="t_source_file" runat="server" id="t_source_file" class="px"
                    maxlength="255" />
           
            </dd>
        </dl>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <br />
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="Button2_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
