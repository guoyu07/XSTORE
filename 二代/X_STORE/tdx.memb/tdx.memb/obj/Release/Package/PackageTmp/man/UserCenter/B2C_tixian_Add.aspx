<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_tixian_Add.aspx.cs" Inherits="tdx.memb.man.UserCenter.B2C_tixian_Add" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑管理员</title>
    <script src="../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../JS/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="../JS/lhgdialog.js?skin=idialog" type="text/javascript"></script>
    <script src="../JS/layout.js" type="text/javascript"></script>
    <link href="../CSS/nei.css" rel="stylesheet" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
            <a href="B2C_tixian_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="B2C_tixian_List.aspx"><span>提现管理</span></a>
            <i class="arrow"></i>
            <span>新增申请</span>
        </div>
        <div class="line10"></div>

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑提现申请</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">

            <dl>
                <dt>会员名称：</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="drop_M_vip" runat="server" CssClass="select-field"></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>提现额度：</dt>
                <dd>
                    <asp:TextBox ID="txt_M_psw" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="Regulapwdne" runat="server"
                        ControlToValidate="txt_M_psw" ErrorMessage="只能输入数字"
                        ValidationExpression="^[0-9]+.?[0-9]*$"></asp:RegularExpressionValidator>
                </dd>
            </dl>

            <dl>
                <dt>当前状态：</dt>
                <dd>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="申请" GroupName="sex"
                        Width="100px" Checked="true" />
                </dd>

            </dl>

        </div>
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>

    </form>
</body>
</html>

