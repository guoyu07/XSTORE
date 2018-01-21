<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B2C_TPclass_List.aspx.cs" Inherits="tdx.memb.man.Texts.B2C_TPclass_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script> 
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1>
        <strong>页面类别列表</strong></h1>
    <div class="nei_content">
        <!--center content-->
        <div class="errMsgBox">
            <asp:Literal ID="lt_result" runat="server"></asp:Literal>
        </div>

        <div class="btn_container">
        <asp:Label ID="lb_cateadd" runat="server"> </asp:Label>
        <asp:Button ID="delBtn" runat="server" Text="彻底删除" class="btnGray" ForeColor="Red"
                        OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" />
       </div>

        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">

            <%--<tr>
                <td width="80%" height="40" align="left" class='borderBottom'>
                    <input type="checkbox" class="btn" name="delAll" id="delAll" runat="server" onclick="this.value=checkAll(form1.delbox,this);" />全部&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="delBtn" runat="server" Text="彻底删除" class="btnGray" ForeColor="Red"
                        OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" />
                </td>
                <td width="20%" align="center">
                    <asp:Label ID="lb_cateadd" runat="server"> </asp:Label>
                </td>
            </tr>--%>

            <tr>
                <td colspan="2" align="center">
                    <div class="tdh">
                        <asp:Literal ID="lb_catelist" runat="server"> </asp:Literal>
                    </div>
                </td>
            </tr>
            <tr>
                <td height="30" colspan="2">
                    &nbsp;
                </td>
            </tr>
        </table>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>

