<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_ADS_Add3.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_ADS_Add3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
        //            $(function () {
        //                $("#fileimg").hover(function () {
        //                    point($(this), "imgurl", $("#div_right"));
        //                });
        //                $("#fileimg").focus(function () {
        //                    point($(this), "imgurl", $("#div_right"));
        //                });
        //                $("#fileimg").focus();
        //            });
        //                   
    </script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1>
        <strong>背景图片设置 </strong>
    </h1>
    <div class="nei_content" id="nei_content">
        <asp:Literal ID="daohang_Image" runat="server"></asp:Literal>
        <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <!--center content-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2" href="">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
        <input type="hidden" name="txtWID" id="txtWID" runat="server" enableviewstate="false" />
        <table class="enter_table">
            <tr style="display: none">
                <td width="20%" align="center" height="40" class="enter_title">
                    广告位置
                </td>
                <td width="60%" class="enter_content">
                    <select id="selno" name="D1" runat="server" class="select-field">
                    </select>
                    <input type="hidden" name="txt" id="txt" value="010" runat="server" enableviewstate="false" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="display: none">
                <td width="20%" align="center" height="40" class="enter_title">
                    广告名称
                </td>
                <td width="60%" class="enter_content">
                    <input type="text" value="图片" name="txtname" placeholder="广告名称" runat="server" id="txtname"
                        class="px" imgurl="../images4/background_pic.jpg" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ControlToValidate="txtname" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="20%" align="center" height="40" class="enter_title">
                    图片
                </td>
                <td width="60%" class="enter_content">
                    <input id="fileimg" type="file" size="30" runat="server" class="px" imgurl="../images4/background_pic.jpg" /><br />
                    <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="display: none">
                <td width="20%" align="center" height="40" class="enter_title">
                    广告url
                </td>
                <td width="60%" class="enter_content">
                    <input id="txturl" type="text" class="px" placeholder="http://www.baidu.com" runat="server"
                        maxlength="200" />
                </td>
                <td>
                </td>
            </tr>
            <tr style="display: none">
                <td width="20%" align="center" height="40" class="enter_title">
                    排序
                </td>
                <td width="60%" class="enter_content">
                    <input type="text" name="txtsort" value="9" placeholder="9" class="px" runat="server"
                        id="txtsort" maxlength="5" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="txtsort" ErrorMessage="必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr style="display: none">
                <td width="20%" align="center" height="40" class="enter_title">
                    描述
                </td>
                <td colspan="2" class="enter_content">
                    <textarea id="txtdes" placeholder="描述信息" name="txtdes" cols="20" runat="server" rows="2"
                        onchange="if(this.value.length> 150){alert( '最多150字！ ');return   false;}" class="px2"></textarea>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input id="Button1" type="button" value="删除" runat="server" onserverclick="btnsave_DeleteClick"
                        class="btnGray" />&nbsp;&nbsp;&nbsp;
                    <input id="btnsave" type="button" value=" 保 存 " runat="server" onserverclick="btnsave_ServerClick"
                        class="btnSave" />
                </td>
            </tr>
            <tr>
             <td class="enter_title">
                </td>
                <td class="enter_content">
                <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
                </td>
            </tr>
            
        </table>
        <div class="enter_remind phone_remind">
            <img src="../images4/bg_phone.jpg" />
        </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
