<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="tdx.memb.man.Box.SupplierEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title></title>
    <script src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../js/select2.js"></script>
    <link href="../css/select2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="tab-content">
            <dl>
                <dt>公司名称</dt>
                <dd>
                    <asp:TextBox ID="txt_company_name" runat="server" placeholder="公司名称" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>公司地址</dt>
                <dd>
                    <asp:TextBox ID="txt_company_site" runat="server" placeholder="公司地址" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>联系人</dt>
                <dd>
                    <asp:TextBox ID="txt_contacts" runat="server" placeholder="联系人" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>电话</dt>
                <dd>
                    <asp:TextBox ID="txt_phono" runat="server" placeholder="电话" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填 格式:0510-1234567(0510-12345678)</span>
                </dd>
            </dl>
            <dl>
                <dt>邮编</dt>
                <dd>
                    <asp:TextBox ID="txt_postcode" runat="server" placeholder="邮编" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填 格式:224000</span>
                </dd>
            </dl>
        </div>
        <div class="page-footer">
                <div class="btn-list">
                    <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="save_sel();" />

                    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
                </div>
                <div class="clear">
                </div>
            </div>
    </form>
</body>
</html>
