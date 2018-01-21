<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BsjActivity.aspx.cs" Inherits="tdx.memb.man.formcontrols.BsjActivity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>活动编辑</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 253px;
        }
        #kaishi
        {
            width: 194px;
        }
        #Text1
        {
            width: 173px;
        }
    </style>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script> 
</head>
<body>

            <form id="form1" runat="server">
            <h1>
                    <strong>会员信息编辑</strong></h1>
            <div class="nei_content" id="nei_content">
                
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                    <tbody>                      
                        <tr>
                            <td align="center" height="40" width="20%">
                                活 动
                            </td>
                            <td class="style2" >                               
                                <asp:DropDownList AutoPostBack="true" ID="M_activity" OnSelectedIndexChanged="Select_Change" runat="server">
                                </asp:DropDownList>
                                <span class="rb">*</span>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>                                                                                                                                         
                        <tr>
                            <td align="center" height="40" width="20%">
                                开始时间
                            </td>
                            <td class="style2" >
                                <input name="kaishi" id="kaishi" onfocus="HS_setDate(this)"  readonly="readonly" runat="server" maxlength="5000"
                                    type="text">
                            </td width="20%">
                            <td>
                            结束时间
                            </td>
                            <td>
                              <input name="jieshu" id="jieshu" onfocus="HS_setDate(this)" readonly="readonly"  runat="server" maxlength="5000"
                                    type="text">
                            </td>
                        </tr>                                                                       

                        <tr>
                            <td colspan="3" align="center" height="30">
                                <input name="btn_save" runat="server" onserverclick="btn_save_ServerClick" id="btn_save"
                                    value=" 保 存 " class="btnGreen" type="button">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--内容-->
            <!--内容结束-->
            </form>
</body>
</html>
