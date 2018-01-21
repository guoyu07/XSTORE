<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_MoRen_Edit.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_MoRen_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1>
        <strong>默认回复: </strong>
        <asp:Literal ID="lt_mp" runat="server" EnableViewState="false"></asp:Literal>
    </h1>
    <div class="nei_content" id="nei_content">
        <!--center content-->
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
        <input type="hidden" name="txtWID" id="txtWID" runat="server" enableviewstate="false" />
        <table class="enter_table">
            <tr style="display: none">
                <td class="enter_title">
                    广告位置
                </td>
                <td class="enter_content">
                    <select id="selno" name="D1" runat="server" class="inline-block select-field">
                        <option></option>
                    </select>
                    <input type="hidden" name="txt" id="txt" value="003" runat="server" enableviewstate="false" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    默认回复标题
                </td>
                <td class="enter_content">
                    <input type="text" name="txtname" placeholder="请输入默认回复标题" runat="server" id="txtname"
                        imgurl="../images4/biaoti.jpg" class="px" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ControlToValidate="txtname" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    图片
                </td>
                <td class="enter_content">
                    <input id="fileimg" type="file" size="30" runat="server" class="px" imgurl="../images4/tupian.jpg" /><br />
                    <span class="gray">(宽高:720*400,像素72,格式:jpg png gif)</span><br />
                    <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    跳转链接
                </td>
                <td class="enter_content">
                    <input id="txturl" type="text" class="px" placeholder="http://www.tdx.cn" runat="server"
                        maxlength="1000" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="display: none">
                <td class="enter_title">
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="txtsort" placeholder="9" value="99" class="px" runat="server"
                        id="txtsort" maxlength="5" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="txtsort" ErrorMessage="必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    描述
                </td>
                <td class="enter_content">
                    <textarea id="txtdes" placeholder="描述信息" name="txtdes" cols="20" runat="server" rows="2"
                        imgurl="../images4/miaoshu.jpg" class="px2"></textarea>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input id="btnsave" type="button" value=" 保 存 " runat="server" onserverclick="btnsave_ServerClick"
                        class="btnSave" />
                </td>
            </tr>
        </table>
        <div class="enter_remind phone_remind">
            <img src="../images4/defaultReply_phone.jpg" />
        </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
