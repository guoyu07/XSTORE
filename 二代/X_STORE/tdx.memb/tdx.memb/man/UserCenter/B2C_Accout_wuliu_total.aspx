<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Accout_wuliu_total.aspx.cs" Inherits="tdx.memb.man.UserCenter.B2C_Accout_wuliu_total" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>账户列表</title>
    <script src="../JS/jquery-1.10.2.min.js" type="text/javascript"></script>
<%--    <script src="../JS/datepicker/WdatePicker.js" type="text/javascript"></script>--%>
    <script src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../JS/lhgdialog.js?skin=idialog" type="text/javascript"></script> 
    <script src="../JS/layout.js" type="text/javascript"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<%--    <link href="../CSS/WdatePicker.css" rel="stylesheet" />--%>
    <link href="../../js/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" />
    <link href="../CSS/nei.css" rel="stylesheet" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>财务汇总表</span>
        </div>  
            <div class="nei_seach">
                <div class="r-list">
                  <table border="0" width="100%">
                    <tr>
                    <td>关键词：
<%--                        <input type="text" value="" class="px" name="ss_keyword" id="ss_keyword" runat="server" style="width: 256px" />--%>
                        <asp:TextBox ID="ss_keyword" runat="server" CssClass="input" datatype="*0-100" sucmsg=" " />
                     时间：
                        <asp:TextBox ID="txtbtime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})">
                        </asp:TextBox>To:
                         <asp:TextBox ID="txtetime" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                      
                    <input type="button" id="ss_btn" runat="server" style="clear: both; width: 50px;" class="input" value="搜 索" onserverclick="ss_btn_ServerClick" />
                    <input type="hidden" id="ss_mid" value="0" runat="server" />
                </td> 
                    </tr>
                  </table> 
                    </div>
                </div>
       
    
        <table width="100%" cellpadding="4" cellspacing="0" border="0">
           
            <tr>
                <td coslpan="2" align="center" colspan="2">
                    <asp:Literal ID="lb_prolist" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2">
                    <asp:Literal ID="lt_pagearrow" runat="server" EnableViewState="False"> </asp:Literal>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>

