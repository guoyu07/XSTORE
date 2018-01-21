<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipAdd.aspx.cs" Inherits="tdx.memb.man.manager.VipAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>拼好货</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form2" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="VipList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>会员管理</span>
            <i class="arrow"></i>
            <span>会员编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">用户注册</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>用户名</dt>
                <asp:TextBox ID="username" runat="server" CssClass="input normal"  datatype="*1-100" sucmsg=" "  nullmsg="请输入名称" ></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
                <asp:Label ID="userabout" runat="server"></asp:Label>
            </dl>
            <dl>
                <dt>姓</dt>
                <asp:TextBox ID="surname" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "  nullmsg="请输入姓氏"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>名</dt>
                <asp:TextBox ID="name" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "  nullmsg="请输入姓名"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>性别</dt>
                        <div class="rule-single-select">
                        <asp:DropDownList CssClass="input" ID="Gender" runat="server">
                        </asp:DropDownList>

            </dl>
            <dl>
                <dt>邮件地址</dt>
                <asp:TextBox ID="emailaddress" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "  nullmsg="请输入邮箱地址"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
                <asp:Label ID="aboutemail" runat="server"></asp:Label>
            </dl>
            <dl>
                <dt>登陆密码</dt>
                <asp:TextBox ID="pwdmm" runat="server" CssClass="input normal" TextMode="Password" datatype="*1-100" sucmsg=" "  nullmsg="请输入密码"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>确认密码</dt>
                <asp:TextBox ID="repassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*1-100" sucmsg=" "  nullmsg="请确认密码"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
                <asp:Label ID="about" runat="server"></asp:Label>
            </dl>
            <dl>
                <dt>授予角色</dt>
                <asp:DropDownList ID="role" runat="server" CssClass="input normal"></asp:DropDownList>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <br />

        <div class="btn-list">
            <asp:Button ID="btnSubmit2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click2" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear"></div>

        <!--/工具栏-->

    </form>
</body>
</html>

