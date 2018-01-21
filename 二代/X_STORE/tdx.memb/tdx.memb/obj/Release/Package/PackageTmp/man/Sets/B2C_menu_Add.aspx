<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_menu_Add.aspx.cs" Inherits="tdx.memb.man.Sets.B2C_menu_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#bma_right").offset({ top: $("#nei_content table").offset().top, left: $("#nei_content table").offset().left + $("#nei_content table").width() + 16 });
            $("#txtmc").click(function () {
                point($(this), "imgurl", $("#bma_right"));
            });  //txtgif
            var c = 0;
            $("#txtgif").hover(function () {
                var _this = $(this);
                c = setTimeout(function () { point(_this, "imgurl", $("#bma_right")); }, 500);
            }, function () {
                clearTimeout(c);
            });
            $("#txtmc").click();
            $("#txtmc").focus();
        });
        
    </script>
</head>
<body>
    <!--中间开始-->    
    <form id="form1" runat="server">
    
    <h1>
        <strong>首页栏目设置</strong></h1>
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
            <span class="tsxx_2"> <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
             
       
        <input type="hidden" name="class_level" value="1" id="class_level" runat="server" />
        <table class="enter_table">
            <tr style="display: none">
                <td align="center" height="40">
                    分类
                </td>
                <td>
                    <select id="class_parent" name="class_parent" size="1" runat="server" class="select-field">
                    </select>
                </td>
                <td>
                    <span class="rb">*</span>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    栏目名称
                </td>
                <td class="enter_content">
                    <input type="text" name="txtmc" placeholder="菜单名称" class="px" runat="server" id="txtmc"
                        imgurl="../images4/b2c_menu_add_biaoti.jpg" maxlength="200" />
                    <%--<asp:RequiredFieldValidator ID="Reqmc" runat="server" ControlToValidate="txtmc" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                </td>  
                <td class="rb">*</td>             
            </tr>
            <tr>
                <td class="enter_title">
                    图标
                </td>
                <td class="enter_content">
                    <input id="txtgif" type="file" class="px" runat="server" maxlength="300" imgurl="../images4/b2c_menu_add_caidan.jpg" /><br />
                    <span class="gray">图片最佳尺寸200*200，支持格式:jpg gif png</span><br />
                    <asp:Image ID="Image1" runat="server" Width="100" />
                </td>
                <td>
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
                <td>
                    <span class="rb">*</span>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="txtpx" placeholder="排序规则,必须为数字，默认为99" class="px" runat="server" id="txtpx" />
                    <%--<asp:RegularExpressionValidator ID="Regpx" runat="server" ControlToValidate="txtpx"
                        ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>--%>
                </td>
                <td>
                 <span class="rb">*</span>                   
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    描述
                </td>
                <td class="enter_content">
                    <textarea id="txtms" placeholder="描述信息" cols="30" rows="2" name="txtms" runat="server"
                        class="px2" ></textarea><br />
                        <span class="gray">描述最多不超过500字</span>
                </td>
                <td>
                </td>
            </tr>
            <tr>
            <td class="enter_title"></td>
                <td class="enter_content">
                <asp:Button ID="Button1" Text=" 保 存 " runat="server" CssClass="btnSave" OnClick="btnSave_ServerClick" />                                                            
                 </td>                  
            </tr>
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
        </table>
        <div id="bma_right" class="enter_remind">
    </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
