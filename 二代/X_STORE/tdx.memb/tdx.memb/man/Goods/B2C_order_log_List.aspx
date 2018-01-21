<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_order_log_List.aspx.cs" Inherits="tdx.memb.man.Goods.B2C_order_log_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
         <link href="../images4/nei.css" type="text/css" rel="stylesheet"> 
            <title>后台管理</title> 
        </head>
        <body>
            <form id="form1" runat="server"> 
                <h1>
                    <strong>订单处理</strong></h1>
                <div class="nei_content">
                    <div class="errMsgBox">
                        <div class="notice rb"><asp:Literal ID="lt_result" runat="server" ></asp:Literal></div> 
                    </div>
                   <table width="98%" cellpadding="0" cellspacing="0" border="0" align="center">
                        <tr>
                            <td width="80%" align="left" height="40"  class='borderBottom'><input type="checkbox" class="btn"  name="delAll" id="delAll" runat="server" onclick ="this.value=checkAll(form1.delbox,this);" />全部&nbsp;
                               <asp:Button  ID="delBtn" runat="server" Text="删除" class="btnGray" ForeColor="Red" OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" /></td>
                            <td  width="20%" align="right" height="40"  class='borderBottom'><asp:Label ID="lb_cateadd" runat ="server" > </asp:Label></td>
                        </tr>  
                      <tr> 
                        <td colspan="2" align="center"> 
                          <asp:Literal ID="lb_catelist" runat ="server" > </asp:Literal>       
                        </td>    
                      </tr>
                      <tr> 
                        <td height="30" colspan="2">&nbsp;</td>
                      </tr>
                    </table>
    </div> 
            </form>
</body>
</html>
