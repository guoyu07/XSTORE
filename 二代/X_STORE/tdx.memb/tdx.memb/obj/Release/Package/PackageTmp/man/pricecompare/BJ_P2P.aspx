<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BJ_P2P.aspx.cs" Inherits="tdx.memb.man.pricecompare.BJ_P2P" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js" charset="utf-8"></script>
    <script type="text/javascript" src="../css/tdx_member.js"></script>  
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>编辑比价信息</strong></h1>
    <asp:HiddenField ID="wid" runat="server" />
    <asp:HiddenField ID="isE" runat="server" />
    <div class="nei_content" id="nei_content">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
            <tbody>
                <tr>
                    <td align="center" height="40" width="20%">
                        <asp:HiddenField ID="dangqianid" runat="server" />
                        商品名称
                    </td>
                    <td width="60%">
                        <input name="title" id="shangpinming" runat="Server" readonly="readonly" placeholder="商品名称"
                            class="px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="center" height="40" width="20%">
                        商品价格
                    </td>
                    <td>
                        <input name="title" id="jiage" runat="Server" readonly="readonly" placeholder="商品价格，必须为大于0的数字"
                            class="px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="center" height="40" width="20%">
                        微信价格
                    </td>
                    <td>
                        <input name="t_sort" id="weixinjiage" runat="Server" readonly="readonly" placeholder="99"
                            class="px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Literal ID="shangjia" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <input name="btn_save" onclick="return jiance(form1.neirongprice);" runat="server"
                            id="btn_s" value=" 保 存 " onserverclick="baocunbianji" class="btnGreen" type="submit" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
