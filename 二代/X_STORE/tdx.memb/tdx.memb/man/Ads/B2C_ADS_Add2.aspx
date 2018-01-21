<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_ADS_Add2.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_ADS_Add2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title> 
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.form.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/hdp.js" type="text/javascript"></script> 
    <script type="text/javascript">
        $(function () {
            ads_show();
        })

    </script>
</head>
<body>
    <!--中间开始-->
    
    <form id="form1" runat="server">
    <h1>
        <strong>幻灯片设置 </strong>
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
        <input type="hidden" name="txtWID" id="itemId" runat="server" />
        <div class="ads_show_body">
            <table class="enter_table">
                <tr>
                    <td class="enter_title">
                    </td>
                    <td class="enter_content">
                        <div class="ads_show">
                            <ul>
                                <asp:Literal ID="images" runat="server"></asp:Literal></ul>
                            <ol>
                            </ol>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                    </td>
                    <td class="enter_content">
                        <%--<input id="file1" type="button" class="btnAdd" value="添加一张新图片" />--%>
                    </td>
                </tr>
            </table>
        </div>
        <div class="ads_content">
            <table class="enter_table" _type="edit">
                <tr style="display: none">
                    <td align="center" height="40">
                        广告位置
                    </td>
                    <td>
                        <select id="selno" name="D1" runat="server" class="select-field" style="display: none">
                            <option></option>
                        </select>
                        <input type="hidden" name="txt" id="txt" value="009" runat="server" enableviewstate="false" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        幻灯片名称
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtname" placeholder="请输入幻灯片名称" maxlength="50" runat="server"
                            id="txtname" class="px" /> 
                    </td>
                    <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        图片
                    </td>
                    <td class="enter_content">
                        <input id="fileimg" type="file" size="30" runat="server" class="px" /><br />
                        <span class="gray">图片最佳尺寸:480*250,格式:jpg,gif,png</span>
                    </td>
                    <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        跳转链接
                    </td>
                    <td class="enter_content">
                        <asp:Literal ID="lt_funcSelectBox" runat="server" ></asp:Literal> 
                        <br />
                        <textarea id="txturl" cols="30" rows="2" name="txturl" runat="server" class="px2"></textarea><br />
                        <span class="gray">您可以选择其他地址，然后在文本框中输入您要跳转的站外网址，也可以通过下拉框选择站内内容</span>
                       
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        排序
                    </td>
                    <td class="enter_content">
                        <input type="text" name="txtsort" placeholder="排序规则，必须为数字，默认为99" class="px" runat="server"
                            id="txtsort" maxlength="5" /> 
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="center" height="40">
                        描述
                    </td>
                    <td>
                        <textarea id="txtdes" placeholder="输入最多300字的描述！" name="txtdes" cols="20" runat="server"
                            rows="2" onchange="if(this.value.length> 300){alert( '最多300字！ ');return   false;}"
                            class="px2"></textarea>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                    </td>
                    <td class="enter_content">
                        <input id="btnsave" type="button" value=" 保 存 " runat="server" class="btnSave" onclick="return btnsave_onclick()" />
                    </td>
                </tr>
                <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
            </table>
        </div>
        <div class="enter_remind phone_remind">
            <img src="../images4/ads_phone.jpg" />
        </div>
    </div>
    <div class="nei_temp">
        <img></div>
    </form>
    <!--中间结束-->
</body>
</html>
