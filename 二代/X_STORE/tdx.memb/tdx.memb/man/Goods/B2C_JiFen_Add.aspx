<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_JiFen_Add.aspx.cs" Inherits="tdx.memb.man.Goods.B2C_JiFen_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script language="javascript" src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" language="javascript" type="text/javascript"></script>
</head>
<body>   
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1>
        <strong>添加积分产品</strong></h1>
    <div class="nei_content" id="nei_content">
     <asp:Literal ID="ltHead" runat="server"></asp:Literal>

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
        <input type="hidden" name="bid" value="" id="bid" runat="server" />
        <input type="hidden" name="no" value="" id="no" runat="server" />
        <input type="hidden" name="txm" value="" id="txm" runat="server" />
        <input type="hidden" name="price_B" value="0" id="price_B" runat="server" /> 
        <input type="hidden" name="lowN" value="0" id="lowN" runat="server" />
        <input type="hidden" name="rd_xn" value="0" id="rd_xn" runat="server" />
        <input type="hidden" name="rd_buytype" value="2" id="rd_buytype" runat="server" />
        <input type="hidden" name="gdown" value="" id="gdown" runat="server" />
        <input type="hidden" name="filename" value="" id="filename" runat="server" />
        <input type="hidden" name="title" value="" id="title" runat="server" />
        <input type="hidden" name="_key" value="" id="_key" runat="server" />
        <input type="hidden" name="_description" value="" id="_description" runat="server" />
        <input type="hidden" name="_isURL" id="_isURL" value="0" runat="server" />
        <input type="hidden" name="_url" id="_url" value="" runat="server" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    产品品牌
                </td>
                <td class="enter_content">
                    <select id="sbid" name="sbid" runat="server" class="select-field">
                        <option></option>
                    </select>                   
                    <br />
                    <span class="gray">请选择产品品牌</span><br />
                    <br />
                </td>
               <td class="rb">
                    *
                </td>
            </tr>
             <tr>
                <td class="enter_title">
                    产品名称
                </td>
                <td class="enter_content">
                    <input type="text" placeholder="产品名称,不得为空" class="px" runat="server" id="name" maxlength="200" /><br />
                    <span class="gray">产品名称,不得为空,最长200个字符</span><br />
                    <br />
                   
                </td>
                <td class="rb">
                    *
                </td>
            </tr>

            <tr>
                <td class="enter_title">
                    单位
                </td>
                <td class="enter_content">
                    <input type="text" name="unit" placeholder="请输入单位，也可从右侧选择" class="px" runat="server"
                        id="unit" maxlength="10" /><br />
                    <span class="gray">请输入单位，如：斤、个、台、套等。也可从下面选择现有的单位。最长10个字符</span><br />
                    <br />
                    <select id="unit2" name="unit2" size="1" runat="server" class="select-field" onchange="document.form1.unit.value=this[this.selectedIndex].value">
                        <option value="">选择单位</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    价格
                </td>
                <td class="enter_content">
                    <input type="text" name="price_S" placeholder="价格，默认0积分,必须为数字。价格+积分=商品完整价格" class="px" runat="server"
                        id="price_S" /><br />
                    <span class="gray">价格，默认0积分,必须为数字。价格+积分=商品完整价格</span>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ControlToValidate="price_M" ErrorMessage="必须为数字" ValidationExpression="^\d{1,12}(?:\.\d{1,4})?$"></asp:RegularExpressionValidator>--%>
                    <br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    积分
                </td>
                <td class="enter_content">
                    <input type="text" name="g_cent" placeholder="积分，默认0积分,必须为数字。价格+积分=商品完整价格" class="px" runat="server"
                        id="g_cent" /><br />
                    <span class="gray">积分，默认0积分,必须为数字。价格+积分=商品完整价格</span>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ControlToValidate="price_M" ErrorMessage="必须为数字" ValidationExpression="^\d{1,12}(?:\.\d{1,4})?$"></asp:RegularExpressionValidator>--%>
                    <br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            
            <tr>
                <td class="enter_title">
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="sort" placeholder="排序默认为99且只能为数字" class="px" runat="server"
                        id="sort" /><br />
                    <span class="gray">排序默认为99且只能为数字</span>
                    <br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    代表图片
                </td>
                <td class="enter_content">
                    <input id="gif" type="file" class="px" runat="server" maxlength="300" onchange="Preview()" /><br />
                    <span class="gray">最大宽高:360*200 像素:72 格式:jpg png gif</span><br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    简述
                </td>
                <td class="enter_content">
                    <textarea id="des" placeholder="产品简述,最多150字" name="des" runat="server" class="px2"></textarea><br />
                    <span class="gray">产品简述,最多150字</span><br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    详细描述
                </td>
                <td class="enter_content">
                    <fckeditorv2:FCKeditor ID="_msg" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                        Height="350px">
                    </fckeditorv2:FCKeditor>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnSave" runat="server" id="btnSave" onserverclick="btnSave_ServerClick"/>
                </td>
            </tr>
            <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
        </table>
        <div class="enter_remind">
        </div>
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
