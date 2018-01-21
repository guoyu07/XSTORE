<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxConfig.aspx.cs" Inherits="tdx.memb.man.Sets.wxConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script src="../../js/area.js" type="text/javascript"></script>
    <style type="text/css">
        #s3
        {
            width: 114px;
        }
        #s2
        {
            width: 100px;
        }
        #cid
        {
            width: 161px;
        }
        #s1
        {
            width: 87px;
        }
    </style>
</head>
<body>
    <!--中间开始-->
    <asp:Literal ID="ltHead" runat="server"></asp:Literal>
    <form id="form1" runat="server">
     <div  class="wxmpadd_head">
        <h1>
            <strong>我的信息</strong></h1>
    </div>
    <div class="nei_content" id="nei_content">
        <!--center content-->
        <div class="errMsgBox">
            <div class="notice rb">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal>
            </div>
        </div>
        <input type="hidden" name="hf" id="hf" runat="server" value="" />
        <div class="wxmpadd_enter">
        <table> 
            <tr>
                <td class="enter_title">
                    网站名称
                </td>
                <td class="enter_content">
                    <input type="text" name="txtNichen" placeholder="请输入网站的名称" class="px" runat="server" id="txtNichen"
                        maxlength="255" /><br />
                        <span class="gray">请输入您的微官网名称，将显示在您的微官网标题上</span><br />
                        <br />
                </td>
                <td>
                    <span class="rb">*</span>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    公 司
                </td>
                <td class="enter_content">
                    <input type="text" name="txtCompany" placeholder="请输入公司的名称" class="px" runat="server" id="txtCompany" /><br />
                    <span class="gray">请输入您的公司名称</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    电 话
                </td>
                <td class="enter_content">
                    <input type="text" name="txtTel" placeholder="联系电话" class="px" runat="server" id="txtTel" /><br />
                     <span class="gray">请输入您的直线电话，将显示在您的微官网热线电话位置</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    手 机
                </td>
                <td class="enter_content">
                    <input type="text" name="txtMobile" placeholder="手机号码" class="px" runat="server" id="txtMobile" /><br />
                    <span class="gray">请输入您的手机号码</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
             
            <tr>
                <td class="enter_title">
                    Email
                </td>
                <td class="enter_content">
                    <input type="text" name="txtMail" placeholder="邮箱" class="px" runat="server" id="txtMail" /><br />
                     <span class="gray">请输入您常用的Email地址,此Email地址也用来接受预定、订单的通知</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
           
            <tr>
                <td class="enter_title">
                    私人微信号
                </td>
                <td class="enter_content">
                    <input type="text" name="wx_name" placeholder="此处填写您的私人微信号" class="px" runat="server" id="wx_name" /><br />
                     <span class="gray">请输入您的私人微信号,在您关注我们的服务号后，我们会给您发一些通知信息，例如订单通知</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    QQ
                </td>
                <td class="enter_content">
                    <input type="text" name="txtQq" placeholder="QQ号码" class="px" runat="server" id="txtQq" /><br />
                     <span class="gray">请输入您的QQ号码</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    位置
                </td>
                <td class="enter_content">
                    <input type="text" name="txtMap" placeholder="位置信息,可以输入百度地图短网址" class="px" runat="server" id="txtMap" /><br />
                     <span class="gray">请输入百度地图短网址</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
             <tr>
                <td class="enter_title">
                    地区
                </td>
                <td class="enter_content">
                   <select id="Select1" name="Select1" runat="server">
                    </select><select id="Select2" name="Select2" runat="server"></select><select id="Select3" name="Select3" runat="server"></select><br />
                      <span class="gray">请选择您所在的地区,我们将在同地区推广您的微官网</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="enter_title">
                    行业
                </td>
                <td class="enter_content">
                 <select id="hy" name="hy" runat="server" >                      
                    </select><br />
                     <span class="gray">请选择您的行业,我们将在同行业推广您的微官网</span><br />
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="3" align="center">
                    <input type="button" value="  保 存  " class="btnGreen" runat="server" id="Button1"
                        onserverclick="Button1_ServerClick" />
                </td>
            </tr>
            <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
        </table>
        <!--center content end-->
    </div>
    <script language="javascript">
        addressInit('Select1', 'Select2', 'Select3');
        </script>
      <asp:Literal ID="sc" runat="server" ></asp:Literal>
    </form>
    <!--中间结束-->
</body>
</html>
