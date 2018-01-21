<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_tmsg_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_tmsg_Add" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../ColorPicker/jquery.js" type="text/javascript"></script>
    <script src="../ColorPicker/jquery.colorpicker.js" type="text/javascript"></script>
    
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            font-size: 12px;
            color: #333;
            padding-right: 56px;
            padding-top: 8px;
            width: 100px;
            font-family: Microsoft YaHei;
            min-width: 70px;
            height: 26px;
        }
        .auto-style2 {
            padding: 8px 4px 0 0;
            min-width: 570px;
            display: block;
            height: 26px;
        }
    </style>
    
</head>
<body>
    <!--中间开始-->    
    <form id="form1" runat="server">
    <h1>
        <strong>图文内容编辑</strong></h1>
      
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
            <span class="tsxx_2">
                  <asp:Literal ID="lt_result" runat="server"></asp:Literal>
            </span>
            <img class="tsxx_3" src="/man/images4/xx.png"></div>
              
        <input type="hidden" name="t_isUrl" id="t_isUrl" runat="server" value="0" />
        <%--<input type="hidden" name="t_url" id="t_url" runat="server" value="" />--%>
        
      

            <table class="enter_table">
            <tr>
                <td class="enter_title">
                    类 别
                </td>
                <td class="enter_content">
                    <select id="cid" name="cid" runat="server" class="select-field">
                        <option></option>
                    </select>
                     <asp:Literal ID="addWant" runat="server"></asp:Literal>                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    标 题
                </td>
                <td class="enter_content">
                    <input type="text" name="t_title" placeholder="请填写图文标题" class="px" runat="server" id="t_title"
                        maxlength="255" />
                    <input type="text" name="t_title" runat="server" id="Text1" style="display:none" value="black" />
                    <input type="text" name="t_title" runat="server" id="Text2" style="display:none" value="white" />
                        <img src="../ColorPicker/colorpicker.png" id="titlecolor" style="cursor:pointer;color:rgb(51,255,153);" />
                        <img src="../ColorPicker/colorpicker.png" id="titlebcolor" style="cursor:pointer;color:rgb(51,255,153);" />
                        <script type="text/javascript">
                            //设置默认颜色
                            $("#t_title").css("color", $("#Text1").val()); //
                            $("#t_title").css("background-color", $("#Text2").val());

                            $("#titlecolor").colorpicker({
                                fillcolor: true,
                                success: function (o, color) {

                                    $("#t_title").css("color", color); //
                                    $("#Text1").val(color);

                                }
                            });

                            $("#titlebcolor").colorpicker({
                                fillcolor: true,
                                success: function (o, color) {

                                    $("#t_title").css("background-color", color);
                                    $("#Text2").val(color);
                                }
                            });
                        </script>
                        <br />
                        <br />                       
                         <span class="gray">请填写图文标题,最长不超过255个字符</span><br />
                </td>
                  <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    作 者
                </td>
                <td class="enter_content">
                    <input type="text" name="t_author" placeholder="作者信息" class="px" runat="server" id="t_author"
                        maxlength="10" /><br />
                        <span class="gray">作者信息,最长10个字符</span><br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    出 处
                </td>
                <td class="enter_content">
                    <input type="text" name="t_source" placeholder="自定义出处" class="px" runat="server" id="t_source"
                        maxlength="10" /><br />
                         <span class="gray">自定义出处,最长10个字符</span><br />
                         <br />
                    <select id="t_source2" name="t_source2" size="1" runat="server" class="select-field"
                        onchange="document.form1.t_source.value=this[this.selectedIndex].value">
                        <option value="">选择出处</option>
                    </select>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    图 片
                </td>
                <td class="enter_content">
                    <input type="file" name="t_gif" class="px" runat="server" id="t_gif" maxlength="255" /><br />
                    <span class="gray">最大宽高:360*200 像素:72 格式:jpg png gif</span><br />
                     <asp:Image ID="Image1" runat="server" Width="180" Height="100" />
                </td>                
            </tr>
            <tr>
                <td class="enter_title">
                    排 序
                </td>
                <td class="enter_content">
                    <input type="text" name="t_sort" placeholder="排序规则，必须为数字，默认为99" class="px" runat="server"
                        id="t_sort" /><br />
                        <span class="gray">排序规则，必须为数字，默认为99</span><br />
                    <%--<asp:RegularExpressionValidator ID="Regpx" runat="server" ControlToValidate="t_sort"
                        ErrorMessage="*必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>--%>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    简 介
                </td>
                <td class="enter_content" >
                    <textarea class="px2" placeholder="简介信息" name="t_des" id="t_des" runat="server" ></textarea><br />
                    <span class="gray">简介信息</span><br />
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    内 容
                </td>
                <td class="enter_content" >
                    <fckeditorv2:FCKeditor ID="t_msg"  runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                        Height="250px">
                    </fckeditorv2:FCKeditor><br />
                    <span class="gray">请输入图文内容</span><br />
                </td>
                  <td class="rb">*</td>
            </tr>
             <tr>
                <td class="enter_title">
                    链接
                </td>
                <td class="enter_content" >
                    <input type="text" class="px" placeholder="请输入图文链接" name="t_url" id="url" runat="server" value="" /> <br />
                    <span class="gray">请输入图文链接</span><br />
                </td>
            </tr>
            <tr>
            <td class="auto-style1">
                
                文件名</td>
                <td class="auto-style2">
                      <input class="px" type="text" name="t_filename" id="t_filename" runat="server" value="" />
                <span class="gray">请输入文件名</span><br />
                    </td>
            </tr>
            <tr>
            <td class="enter_title">
                
                页面Key</td>
                <td class="enter_content">
                  <input class="px" type="text" name="t_keyword" id="t_keyword" runat="server" value="" /> 
                     <span class="gray">请输入页面关键字</span><br />
                </td>
            </tr>
            <tr>
            <td class="enter_title">
                
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnSave" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="daohang_Button" runat="server"></asp:Literal>
        </table>
     
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
