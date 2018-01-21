<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_tpage_Add.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_tpage_Add" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
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
        <strong>页面内容编辑</strong></h1>
    <div class="nei_content" id="nei_content">
    <asp:Literal ID="ltHead" runat="server"></asp:Literal>
        <!--center content-->
         <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>

        <div class="tsxx">
            <img class="tsxx_1" src="/memb/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal>
            </span>
            <img class="tsxx_3" src="/memb/images4/xx.png"></div>
        <input type="hidden" name="t_r1" id="t_r1" runat="server" value="" />
        <input type="hidden" name="t_r2" id="t_r2" runat="server" value="" />
        <input type="hidden" name="t_isUrl" id="t_isUrl" runat="server" value="0" />
        
          <input type="hidden" class="px"  name="t_url" id="t_url" runat="server" value="" />
        <table class="enter_table">
            <tr>
                <td class="enter_title">
                    页面类别
                </td>
                <td class="enter_content">
                    <select name="ss_cid" id="ss_cid" runat="server" class="select-field_sousuo">
                    </select>
                     <asp:Literal ID="add_leib" runat="server"></asp:Literal>                    
                    <br />
                <span class="gray"> 请选择页面类别。页面类别，即页面所在的栏目</span><br />
                <br />
                </td>  
                <td> 
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    标 题
                </td>
                <td class="enter_content">
                    <input type="text" name="txt_gtitle" placeholder="请输入页面标题" class="px" size="30" runat="server"
                        id="txt_gtitle" maxlength="255" />
                    <span class="gray">请输入页面标题，最长300文字</span><br />
                    <br />
                </td>
                <td>
                <span class="rb">*</span>
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
                    排序
                </td>
                <td class="enter_content">
                    <input type="text" name="txt_g_sort" placeholder="排序规则，必须为数字，默认为99" class="px" size="30"
                        runat="server" id="txt_g_sort" /><br /> 
                          <span class="gray">排序规则，必须为数字，默认为99。越小越靠前</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    内 容
                </td>
                <td class="enter_content">
                    <fckeditorv2:FCKeditor ID="txtbody" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic" Height="350px">
                    </fckeditorv2:FCKeditor>
                    <br />
                     <span class="gray">请输入页面内容,必填项</span><br />
                    <br />
                </td>
                <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    文件名</td>
                <td class="enter_content">
      <input class="px" name="txt_gfile" type="text" id="txt_gfile" runat="server" value="" /><br /> 
                          <span class="gray">请输入文件名</span><br /></td>
            </tr>
            <tr>
                <td class="enter_title">
                    页面Title</td>
                <td class="enter_content">
        <input name="t_title" type="text" class="px"  id="t_title" runat="server" value="" /><br /> 
                          <span class="gray">请输入页面Title</span><br /></td>
            </tr>
            <tr>
                <td class="enter_title">
                    页面Key</td>
                <td class="enter_content">
        <input  name="t_keyword" type="text" class="px" id="t_keyword" runat="server" value="" /><br /> 
                          <span class="gray">请输入页面Key</span><br /></td>
            </tr>
            <tr>
                <td class="enter_title">
                    页面Des</td>
                <td class="enter_content">
        <input  name="t_des" type="text" class="px" id="t_des" runat="server" value="" /><br /> 
                          <span class="gray">请输入页面Des</span><br /></td>
            </tr>
            <tr>
                <td class="enter_title">
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnSave" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
        </table>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>

