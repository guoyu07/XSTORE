<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderAddressEdit.aspx.cs" Inherits="tdx.memb.man.Tuan.OrdersManage.OrderAddressEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="nav_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单管理</span>
            <i class="arrow"></i>
            <span>订单地址编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">订单地址编辑</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <input id="txt_openid" runat="server" type="hidden"/>
             <input id="txt_id" runat="server" type="hidden"/>
            <dl>
                <dt>收货人</dt>
                <dd>
                    <asp:TextBox ID="txt_shouhuoren" runat="server" MaxLength="255" CssClass="input normal" />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>手机号</dt>
                <dd>
                    <asp:TextBox ID="txt_telephone" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>


            <dl>
                <dt>省</dt>
                <dd>
                    <asp:TextBox ID="txt_sheng" runat="server" CssClass="input  normal"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>市</dt>
                <dd>
                    <asp:TextBox ID="txt_shi" runat="server" CssClass="input  normal"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>区</dt>
                <dd>
                    <asp:TextBox ID="txt_qu" runat="server" CssClass="input  normal"></asp:TextBox>

                </dd>
            </dl>
            <dl>
                <dt>详细地址</dt>
                <dd>
                  <textarea runat="server" id="txt_address" rows="10" cols="250" class="input  normal"></textarea>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <br />

        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear"></div>

        <!--/工具栏-->

    </form>
</body>
</html>
