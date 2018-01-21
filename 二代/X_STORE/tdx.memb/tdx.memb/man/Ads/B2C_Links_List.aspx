<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Links_List.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_Links_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="/master/images/nei.css" type="text/css" rel="stylesheet" /> 
<title>后台管理</title> 
<script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
<script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>
</head> 
<body>  
 <!--中间开始-->
 <form  id="form1" runat="server"  >    
  			<h1><strong>友链列表</strong></h1>
            <div class="nei_content">
            	<!--center content-->   
             <div class="errMsgBox">
                    <asp:Literal ID="lt_result" runat="server" ></asp:Literal>
             </div> 
             <table width="98%" cellpadding="0" cellspacing="0" border="0" align="center">
                <tr>
                    <td width="80%" align="left" height="40"  class='borderBottom'><input type="checkbox" class="btn"  name="delAll" id="delAll" runat="server" onclick ="this.value=checkAll(form1.delbox,this);" />全部&nbsp;&nbsp;
                                
                            &nbsp;<asp:Button  ID="delBtn" runat="server" Text="彻底删除" ForeColor="Red" OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" class="btnGray"/>
                                &nbsp;</td>
                            <td width="20%"  align="center"  class='borderBottom'><asp:Label ID="lb_cateadd" runat ="server" > </asp:Label></td>
                        </tr> 
                      <tr> 
                        <td colspan="2" align="center" > 
                          <asp:Literal ID="lb_catelist" runat ="server" > </asp:Literal>       
                        </td>    
                      </tr>
                      <tr> 
                        <td height="30" colspan="2">
                            <asp:Literal ID="lt_pagearrow" runat ="server" > </asp:Literal>  
                        </td>
                      </tr>
            </table>
        <!--center content end-->
            </div> 
   </form>  
 <!--中间结束--> 
</body></html> 
