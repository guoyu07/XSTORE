<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TM_Quan_Card_Add.aspx.cs" Inherits="tdx.memb.man.tuan.YingxiaoManage.TM_Quan_Card_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>生成卡券</title>
    <script src="../../../scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../../scripts/Validform_v5.3.2_min.js" type="text/javascript"></script>
    <script src="../../../scripts/lhgdialog.js?skin=idialog" type="text/javascript"></script>
    <script src="../../JS/layout.js" type="text/javascript"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" />
    <link href="../../skin/nei.css" rel="stylesheet" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <a href="TM_Quan_List.aspx"><span>生成卡券</span></a>
            <i class="arrow"></i>
            <span>生成卡券</span>
        </div>
        <div class="line10"></div>

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">生成卡券</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="tab-content">

            <dl>
                <dt>卡券数量：</dt>
                <dd>
                    <asp:TextBox ID="txt_Num" runat="server" class="px"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>

            <dl>
                <dt>卡券位数：</dt>
                <dd>
                    <asp:TextBox ID="txt_Wei"  runat="server" class="px"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
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
