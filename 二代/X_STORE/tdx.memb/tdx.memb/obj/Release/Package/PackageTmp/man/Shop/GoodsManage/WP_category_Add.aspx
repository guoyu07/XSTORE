﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WP_category_Add.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.WP_category_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>

</head>
<body>
    <asp:Literal ID="ltHead" runat="server"></asp:Literal>
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
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">商品类别</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <!--提示-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>

        <input type="hidden" name="class_parent" value="0" id="class_parent" runat="server" />
        <input type="hidden" name="class_level" value="0" id="class_level" runat="server" />
        <input type="hidden" name="txturl" id="txturl" value="" runat="server" />
        <div class="tab-content">
            <dl>
                <dt>类别名</dt>
                <dd>
                    <input type="text" name="txtmc" placeholder="产品类别名称,不得为空" class="px" runat="server"
                        id="txtmc" maxlength="200" /><br />
                    <span class="gray">产品类别名称,不得为空,最长200字符</span>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>

            <dl>
                <dt>代表图片</dt>
                <dd>
                    <input id="txtgif" type="file" class="px" runat="server" maxlength="300" /><br />
                    <span class="gray">最大宽高:200*200 像素:72 格式:jpg png gif</span><br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Width="100" Height="100" />
                </dd>
            </dl>
            <dl>
                <dt>是否显示</dt>
                <dd>
                    <asp:RadioButtonList ID="txt_show" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
            </dl>
            <dl>
                <dt>排序 </dt>
                <dd>
                    <input type="text" name="txtpx" placeholder="排序默认为99且只能为数字" class="px" runat="server"
                        id="txtpx" /><br />
                    <span class="gray">排序规则，必须为数字，默认为99。越小越靠前</span>

                </dd>
            </dl>
            <dl>
                <dt>描述</dt>
                <dd>
                    <textarea id="txtms" cols="30" placeholder=" 产品类别描述信息,最多150字" rows="2" name="txtms"
                        runat="server" class="px2"></textarea><br />
                    <span class="gray">产品类别描述信息,最多150字</span><br />
                </dd>
            </dl>
        </div>
        <!--工具栏-->
        <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button runat="server" Text="提交保存" CssClass="btn" ID="btnSave" OnClick="btnSave_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->

    </form>
    <!--中间结束-->
</body>
</html>
