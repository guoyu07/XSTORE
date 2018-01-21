<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welConfig.aspx.cs" Inherits="tdx.memb.man.Sets.welConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title></title>
    <script language="javascript" type="text/javascript">
    </script>
</head>
<body>
    <asp:Literal ID="ltHead" runat="server"></asp:Literal>
    <form id="form1" runat="server">
    <h1>
        <strong>欢迎图片设置 </strong>
    </h1>
    <div class="nei_content" id="nei_content">
        <!--center content-->
        <div class="errMsgBox">
            <div class="notice rb">
            </div>
        </div>
            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20%" align="center" height="40" class="enter_title">
                        欢迎显示图片
                    </td>
                    <td width="60%" class="enter_content">
                        <input id="fileimg" type="file" size="30" runat="server" class="px" /><br />
                        <asp:Image ID="Image1" runat="server" Width="100" Height="100" />
                    </td>
                    <td>
                    </td>
                </tr>
                <%-- <tr>
                <td width="20%" align="center" height="40">
                    欢迎语</td>
                <td colspan="2">
                    <textarea id="txtdes" name="txtdes" cols="20" runat="server" rows="2" onchange="if(this.value.length> 150){alert( '最多150字！ ');return   false;}"
                        class="px2"></textarea>
                        <br />
                        欢迎语，最多150字
                </td>
                <br />
                输入最多150字
            </tr>--%>
                <tr>
                    <td colspan="3" align="center" style="height: 30px">
                        <input id="btnsave" type="button" value=" 保 存 " runat="server" onserverclick="btnsave_ServerClick"
                            class="btnGreen" />
                    </td>
                </tr>
                <asp:Literal ID="ltFoot" runat="server"></asp:Literal>
            </table>
        </div>
    </form>
</body>
</html>

