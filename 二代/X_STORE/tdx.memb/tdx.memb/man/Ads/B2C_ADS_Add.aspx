<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_ADS_Add.aspx.cs" Inherits="tdx.memb.man.Ads.B2C_ADS_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="/master/images/nei.css" type="text/css" rel="stylesheet" /> 
<title>后台管理</title> 
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script> 
</head> 
<body>  
 <!--中间开始-->
 <form  id="form1" runat="server"  >          
  			<h1><strong>广告列表</strong></h1>
            <div class="nei_content" id="nei_content">
            	<!--center content--> 
             <div class="errMsgBox">
                    <div class="notice rb"><asp:Literal ID="lt_result" runat="server" ></asp:Literal></div>
             </div>
             <input type="hidden" name="txtWID" id="txtWID" runat="server" enableviewstate ="false" /> 
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" >   
                <tr> 
                    <td width="20%" align="center" height="40"> 广告位置</td>
                    <td width="60%">
                    <select id="selno" name="D1" runat="server" class="inline-block select-field"> 
                    </select></td>
                    <td> </td>   
                </tr>
                <tr> 
                    <td width="20%" align="center" height="40"> 广告名称</td>
                    <td width="60%"><input type=text name="txtname" value="" runat="server" id="txtname"  class="px"  placeHolder="请输入广告名称"/><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" 
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                    <td> </td>   
                </tr>
                <tr> 
                    <td width="20%" align="center" height="40"> 图片</td>
                    <td width="60%">
                    <input id="fileimg" type="file" size="30"  runat="server" class="px"  /><br />
                    <asp:Image ID="Image1" runat="server" Width="100" Height="100" />
                      </td>
                    <td> </td>  
                </tr> 
                <tr>  
                    <td width="20%" align="center" height="40">  广告url</td>
                    <td width="60%">
                        <input id="txturl" type="text"  class="px"  value="" runat="server" maxlength="200" placeHolder="http://www.google.com"/></td>
                    <td> </td>  
                </tr>  
                <tr>
                    <td width="20%" align="center" height="40"> 排序</td>
                    <td width="60%">
                    <input type=text name="txtsort" value="9" 
                         class="px" runat="server" id="txtsort" maxlength="5"  placeHolder="排序规则,必须为数字，越小越靠前。缺省为9"/><asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtsort" 
                        ErrorMessage="必须为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                    </td>
                    <td> </td>  
               </tr> 
               <tr>
                    <td width="20%" align="center" height="40"> 描述</td>
                    <td colspan="2">
                        <textarea id="txtdes" name="txtdes" cols="20" runat="server" rows="2" onchange="if(this.value.length> 150){alert( '最多150字！ ');return   false;}" class="px2"></textarea>
                        <br />
                        请输入最多150字的描述
                    </td> 
              </tr>  
              <tr>
                <td colspan="3" align="center" style="height: 30px">
                    <input id="btnsave" type="button" value=" 保 存 " runat="server" onserverclick="btnsave_ServerClick" class="btnGreen"  /></td>
              </tr>
            </table>
   <!--center content end-->
            </div> 
   </form>  
 <!--中间结束--> 
</body></html>
