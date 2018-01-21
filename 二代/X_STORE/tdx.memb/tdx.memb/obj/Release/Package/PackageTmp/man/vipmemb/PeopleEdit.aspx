<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PeopleEdit.aspx.cs" Inherits="tdx.memb.man.vipmemb.PeopleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员信息管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 74%;
        }
    </style>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script> 
</head>
<body>
    <form id="form1" runat="server">
            <h1>
                    <strong>个人微信编辑</strong></h1>
            <div class="nei_content" id="nei_content">
                
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                    <tbody>
                        <tr>
                            <td align="center" height="40" width="15%">
                                微信ID
                            </td>
                            <td class="style1">
                                <input name="wwv" value="" runat="server" id="wwv" class="px" maxlength="50" type="text">                               
                                <span class="rb">*</span>
                                </td>
                            <td width="30%">
                            
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="40" width="20%">
                                 昵 称
                            </td>
                             <td class="style1">
                                <input name="nicheng" value="" runat="server" id="nicheng" class="px" maxlength="50" type="text">                               
                                <span class="rb">*</span>
                                </td>
                            <td width="30%">                            
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="40" width="20%">
                                fakeID
                            </td>
                            <td class="style1">
                                <input name="fakeID" id="fakeID" value="" runat="server" class="px"  type="text">
                            </td>
                            <td>
                            </td>
                        </tr>
                       <tr>
                            <td align="center" height="40" width="20%">
                                微信名
                            </td>
                            <td class="style1">
                                <input name="weiName" id="weiName" value="" runat="server" class="px"  type="text">
                            </td>
                            <td>
                            </td>
                        </tr>
                       <tr>
                            <td align="center" height="40" width="20%">
                                性 别
                            </td>
                            <td class="style1">
                                <select name="xingbie" runat="server" id="xingbie" class="select-field">
                                    <option value="男">- 男</option>
                                    <option value="女">- 女</option>
                                </select>
                                <span class="rb">*</span>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="40" width="20%">
                                身 份
                            </td>
                            <td class="style1">
                                <input name="shengfen" id="shengfen" value="" runat="server" class="px"  type="text">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="40" width="20%">
                                城 市
                            </td>
                            <td class="style1">
                                <input name="chengshi" id="chengshi" value=" " runat="server" class="px"  type="text">
                            </td>
                            <td>
                            </td>
                        </tr>                       
                        <tr>
                            <td align="center" height="100" width="20%">
                                头像图片网址
                            </td>
                            <td class="style1">
                               <input runat="server" name="touxiang" id="touxiang" class="px" maxlength="255" type="file"><br />
                               <img runat="Server" width="100" id="m_ph" src="" />

                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="40" width="20%">
                              关注时间  
                            </td>
                            <td class="style1">
                                <input name="guanzhutime" id="guanzhutime" onfocus="HS_setDate(this)" readonly="readonly" value="" runat="server" class="px" type="text">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="40" width="20%">
                                地区
                            </td>
                            <td class="style1">
                                <input name="yuyan" id="yuyan" runat="server" value="" class="px"  type="text">
                            </td>
                            <td>
                            </td>
                        </tr>                                                

                        <tr>
                            <td colspan="2" align="center" height="30">
                                <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                                    value=" 保 存 " class="btnGreen" type="button">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>           
            </form>
</body>
</html>
