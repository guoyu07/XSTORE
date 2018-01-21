<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_acm_test_Add.aspx.cs" Inherits="tdx.memb.man.caimi.wx_acm_test_Add" %>

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
        <strong>谜语编辑</strong></h1>
      
    <div class="nei_content" id="nei_content"> 
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
      
            <table class="enter_table">
            <tr>
                <td class="enter_title">
                    难度等级
                </td>
                <td class="enter_content">
                    <select id="lid" name="lid" runat="server" class="select-field">
                        <option></option>
                    </select> 
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    适合节日
                </td>
                <td class="enter_content">
                    <asp:CheckBoxList ID="hid" runat="server" >
                        
                    </asp:CheckBoxList>
                </td>
                <td>
                </td>
            </tr>
             <tr>
                <td class="enter_title">
                    适合氛围
                </td>
                <td class="enter_content">
                    <asp:CheckBoxList ID="whid" runat="server" >
                        
                    </asp:CheckBoxList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    谜 面
                </td>
                <td class="enter_content">
                    <input type="text" name="t_title" placeholder="请填写谜语谜面" class="px" runat="server" id="t_title"
                        maxlength="255" /><br />                       
                         <span class="gray">请填写谜语的谜面,最长不超过255个字符</span><br />
                </td>
                  <td class="rb">*</td>
            </tr>
            <tr>
                <td class="enter_title">
                    答 案
                </td>
                <td class="enter_content">
                    <input type="text" name="t_answer" placeholder="请填写谜语答案" class="px" runat="server" id="t_answer"
                        maxlength="10" /><br />
                        <span class="gray">请填写谜语答案,最长20个字符</span><br />
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
                
                </td>
                <td class="enter_content">
                    <input type="button" value=" 保 存 " class="btnSave" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                </td>
            </tr> 
        </table>
     
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
