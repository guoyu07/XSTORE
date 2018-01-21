<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ms_Orders_Detail.aspx.cs" Inherits="tdx.memb.man.Goods.ms_Orders_Detail" %>

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
                    <strong>秒杀订单处理</strong></h1>
                <div class="nei_content">
                    <div class="errMsgBox">
                        <div class="notice rb"><asp:Literal ID="lt_result" runat="server" ></asp:Literal></div> 
                    </div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center"> 
              <tr> 
                <td align="right" height="40"  class='borderBottom'>  
                    <select id="selFlag" runat="server" class="select-field"> 
                    </select>
                    <input type="submit" name="btnFlag" value="更新状态" id="btnFlag" runat="server" class="input" onserverclick="btnFlag_ServerClick" />&nbsp;&nbsp;&nbsp;
                </td>
              </tr>
              <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%" class="borderTable">  
                       <tr> 
                            <td height="30"> &nbsp;订单号: <asp:Label ID="lblBillNo" runat="server" Text=""></asp:Label></td>
                            <td> &nbsp;下单时间: <asp:Label ID="lblTradeDate" runat="server" Text=""></asp:Label></td>
                            <td> &nbsp;下单人: <asp:Label ID="lblTradeMan" runat="server" Text=""></asp:Label></td>  
                       </tr> 
                       <tr>
                            <td height="30"> &nbsp;配送方式:  
                                    <select id="selFlag2" runat="server" class="select-field"> 
                                    </select>
                                    <input type="submit" name="btnFlag2" value="更新配送方式" id="btnFlag2" runat="server" class="input" onserverclick="btnFlag2_ServerClick" /> 
                            </td>
                            <td>&nbsp;配送价格: <asp:Label ID="lblSendCost" runat="server" Text=""></asp:Label></td>
                            <td> &nbsp;金额: <asp:Label ID="lblCost" runat="server" Text=""></asp:Label>
                                / <asp:Label ID="lblAllCost" runat="server" Text=""></asp:Label>
                            </td>
                       </tr> 
                     </table>
                 </td>
              </tr> 
            </table>
        
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">  
                <tr>
                   <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%" class="borderTable">  
                            <tr>
                                <td align="right">
                                    <input id="billId" type="hidden" runat="server" />
                                    <input type="submit" name="btnModBill" value="修改订单" id="btnModBill" runat="server" class="input" onserverclick="btnModBill_ServerClick" />
                                </td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%" class="borderTable">    
                            <tr>
                                <td height="30">&nbsp;收货人: <asp:Label ID="lblConsignee" runat="server" Text=""></asp:Label></td>
                                <%--<td>&nbsp;性别: <asp:Label ID="lblSex" runat="server" Text=""></asp:Label></td>--%>
                                <td>&nbsp;地址: <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
                                <td>&nbsp;邮编: <asp:Label ID="lblZipcode" runat="server" Text=""></asp:Label></td> 
                            </tr>
                            <tr>
                                <td height="30">&nbsp;电话: <asp:Label ID="lblTelephone" runat="server" Text=""></asp:Label></td>
                                <%--<td>&nbsp;传真: <asp:Label ID="lblFax" runat="server" Text=""></asp:Label></td>--%>
                                <td>&nbsp;手机: <asp:Label ID="lblCellphone" runat="server" Text=""></asp:Label></td>
                                <td>&nbsp;送货时间: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3" height="30">&nbsp;备注: <asp:Label ID="lblRemarks" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                   </td>
                </tr> 
            </table>
        
            <table width="98%" cellpadding="0" cellspacing="0" border="0" align="center">
                <tr>
                    <td  width="80%" align="left" height="40"  class='borderBottom'>
                        <input type="checkbox" name="delAll" id="delAll" runat="server" onclick="this.value=checkAll(form1.delbox,this);" />全部
                        <input id="btnDelete" type="submit" runat="server" value="删除" onserverclick="btnDelete_ServerClick" style="color: #FF0000;" class="btnGray" onclick="javascript:return confirm('确定将此记录删除?')" />
                    </td>
                    <td align="center"  class='borderBottom'>
                        <asp:Label ID="lblOrderDAdd" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>                                         
                <tr> 
                    <td colspan="2" align="center"> 
                        <asp:Literal ID="ltrOrderDList" runat="server"></asp:Literal>      
                    </td>    
                </tr>
                <tr> 
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                    <td colspan="2" align="center">
                        <asp:Literal ID="ltrOrderLogList" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr> 
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </div> 
            </form>
</body>
</html>

