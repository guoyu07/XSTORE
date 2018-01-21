<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Shop_Config.aspx.cs" Inherits="tdx.memb.man.Goods.B2C_Shop_Config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>微商城配置</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    是否显示类别
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_category" /><span class="gray">勾选代表显示类别</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示品牌
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_brand" /><span class="gray">勾选代表显示品牌</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示热卖商品
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_hot" /><span class="gray">勾选代表显示热卖商品</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示新品
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_new" /><span class="gray">勾选代表显示新品</span><br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示推荐商品
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_special" /><span class="gray">勾选代表显示推荐商品</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    是否显示新闻
                </td>
                <td class="enter_content">
                    <input runat="server" type="checkbox" id="show_msg" /><span class="gray">勾选代表显示新闻</span><br />
                    <br />
                </td>
            </tr>
            <tr style="border-bottom: 1px solid #999;">
                <td class="enter_title">
                    微信支付信息填写
                </td>
                <td class="enter_content">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    appId
                </td>
                <td class="enter_content">
                    <input type="text" name="_appId" placeholder="请输入您的appId" class="px" runat="server"
                        id="_appId" maxlength="50" /><br />
                    <span class="gray">请输入您的appId</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    appSecret
                </td>
                <td class="enter_content">
                    <input type="text" name="_appSecret" placeholder="请输入您的appSecret" class="px" runat="server"
                        id="_appSecret" maxlength="50" /><br />
                    <span class="gray">请输入您的appSecret</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    appSignKey
                </td>
                <td class="enter_content">
                    <input type="text" name="_appSignKey" placeholder="请输入您的appSignKey" class="px" runat="server"
                        id="_appSignKey" maxlength="50" /><br />
                    <span class="gray">请输入您的appSignKey</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    partnerId
                </td>
                <td class="enter_content">
                    <input type="text" name="_partnerId" placeholder="请输入您的partnerId" class="px" runat="server"
                        id="_partnerId" maxlength="50" /><br />
                    <span class="gray">请输入您的partnerId</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    partnerKey
                </td>
                <td class="enter_content">
                    <input type="text" name="_partnerKey" placeholder="请输入您的partnerKey" class="px" runat="server"
                        id="_partnerKey" maxlength="50" /><br />
                    <span class="gray">请输入您的partnerKey</span><br />
                    <br />
                </td>
            </tr>
            <tr style="border-bottom: 1px solid #999;">
                <td class="enter_title">
                    银联支付信息填写
                </td>
                <td class="enter_content">
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    securityKey
                </td>
                <td class="enter_content">
                    <input type="text" name="_securityKey" placeholder="请输入您的partnerKey" maxlength="50"
                        class="px" runat="server" id="_securityKey" /><br />
                    <span class="gray">请输入您的securityKey</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    merId
                </td>
                <td class="enter_content">
                    <input type="text" name="_merId" placeholder="请输入您的merId" class="px" runat="server"
                        id="_merId" maxlength="50" /><br />
                    <span class="gray">请输入您的merId</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    merAbbr
                </td>
                <td class="enter_content">
                    <input type="text" name="_merAbbr" placeholder="请输入您的merAbbr" class="px" runat="server"
                        id="_merAbbr" maxlength="50" /><br />
                    <span class="gray">请输入您的merAbbr</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    acqCode
                </td>
                <td class="enter_content">
                    <input type="text" name="_partnerKey" placeholder="请输入您的acqCode" class="px" runat="server"
                        id="_acqCode" maxlength="50" /><br />
                    <span class="gray">请输入您的acqCode</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                        value=" 保 存 " class="btnSave" type="button" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
