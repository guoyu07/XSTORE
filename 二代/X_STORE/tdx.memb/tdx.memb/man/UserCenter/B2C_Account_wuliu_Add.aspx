<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Account_wuliu_Add.aspx.cs" Inherits="tdx.memb.man.UserCenter.B2C_Account_wuliu_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑管理员</title>
    <script src="../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../JS/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="../JS/lhgdialog.js?skin=idialog" type="text/javascript"></script>
    <script src="../JS/layout.js" type="text/javascript"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
            <a href="B2C_Accout_wuliu2_List.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>新增</span>
        </div>

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">账户变动(手工入款)</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">



            <dl>
                <dt>会 员</dt>
                <dd>
                    <asp:Literal ID="lt_mem" runat="server"></asp:Literal>
                    <input type="hidden" name="lt_memid" id="lt_memid" runat="server" />
                </dd>

            </dl>
            <dl>
                <dt>途径</dt>
                <dd>
                    <div class="rule-single-select">
                        <select id="t_cno" name="t_cno" runat="server" size="1">
                        </select>
                    </div>
                </dd>

            </dl>
            <dl>
                <dt>账户</dt>
                <dd>
                    <div class="rule-single-select">
                        <select id="t_pt" name="t_pt" runat="server" size="1">
                        </select>
                    </div>
                </dd>

            </dl>
            <dl>
                <dt>操作金额</dt>
                <dd>
<%--                    <input type="text" name="t_num" value="" class="wida" runat="server" id="t_num" maxlength="50" />--%>
                    <asp:TextBox ID="t_num" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                </dd>
                <td width="30%"></td>
            </dl>
            <dl>
                <dt>摘 要</dt>
                <dd>
                    <textarea id="t_msg" runat="server" name="t_msg" cols="40" rows="8"></textarea>
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

