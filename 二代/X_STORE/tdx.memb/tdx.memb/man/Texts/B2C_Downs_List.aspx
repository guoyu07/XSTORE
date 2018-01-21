<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_Downs_List.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_Downs_List" %>

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
  			<h1><strong>下载列表</strong></h1>
            <div class="nei_content">
            	<!--center content-->
             <div class="errMsgBox">
                   <div class="notice rb"><asp:Literal ID="lt_result" runat="server" ></asp:Literal></div> 
             </div> 
            <table width="98%" cellpadding="0" cellspacing="0" border="0" align="center">
                <tr>
                    <td class='borderBottom' height="40">关键词：<input type="text" value="" name="ss_keyword" id="ss_keyword" runat="server" class="px"  />
                        <select name="ss_cid" id="ss_cid" size=1 runat="server" class="select-field">
                            <option value="">---选择类别---</option>
                        </select>
                        <input type="button" id="ss_btn" runat="server" class="btnGray" value="搜 索" onserverclick="ss_btn_ServerClick" />
                          </td> 
                </tr> 
            </table>  
	<table width="98%" cellpadding="0" cellspacing="0" border="0" align="center">
       <tr>
         <td width="80%" align="left" height="40" class='borderBottom'>
            <input type=checkbox  name="delAll" id="delAll" style=" clear:both; width:20px;" runat=server onclick ="this.value=checkAll(form1.delbox,this);" />全部  
             
            <asp:Button ID="delBtn" runat="server" ForeColor="Red" Text="彻底删除" CssClass="btnGray" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" OnClick="delBtn_Click" />
                        </td>
         <td width="20%"  align="center" class='borderBottom'><asp:Literal ID="lb_proadd" runat ="server" ></asp:Literal>   </td>
      </tr> 
      <tr> 
        <td colspan="2" align="center" > 
            <asp:Literal ID="lb_prolist" runat ="server" ></asp:Literal>      
        </td> 
     </tr>
     <tr> 
       <td height="30" colspan="2"><asp:Literal ID="lt_pagearrow" runat ="server" ></asp:Literal> </td>
     </tr>
   </table>
  <!--center content end-->
            </div> 
   </form>  
 <!--中间结束--> 
</body></html> 
