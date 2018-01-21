<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wxConfig_url.aspx.cs" Inherits="tdx.memb.man.Sets.wxConfig_url" %>

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
 <form  id="form1" runat="server"  >   
  			<h1><strong>外链快捷URL地址</strong></h1>
            <div class="nei_content">
            	<!--center content-->  
                    <br />
                    <br />
                    <table width="90%" cellpadding="0" cellspacing="0" border="0" align="center" class="borderTable"> 
                          <tr> 
                            <td align="center" > 
                                功能  
                            </td>   
                            <td align="center" > 
                                  外链地址
                            </td>
                          </tr>
                          <asp:Literal ID="lb_catelist" runat="server" ></asp:Literal>
                          <tr> 
                            <td height="30" colspan="2">&nbsp;</td>
                          </tr>
                        </table> 
                        
     <!--center content end-->
            </div> 
   </form>  
 <!--中间结束--> 
</body></html> 

