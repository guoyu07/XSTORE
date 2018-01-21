<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qfzfWebEnglish.aspx.cs" Inherits="qfzfEnglish.qfzfWebEnglish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; width: 100%;  ">

            <table style="margin-left: auto; margin-right: auto; margin-top: 50px;">
                <tr>
                    <td height="50">
                        <asp:Button ID="btn_index" runat="server" CssClass="pagego" Text="生成首页" OnClick="btn_index_Click" /></td>
                </tr>
                <tr>
                    <td height="50">
                        <asp:Button ID="btn_neiye" runat="server" CssClass="pagego"  Text="生成内页" OnClick="btn_neiye_Click" /></td>
                </tr>
                <tr>
                    <td height="50">
                        <asp:Button ID="btn_news" runat="server" CssClass="pagego"  Text="生成新闻" OnClick="btn_news_Click" /></td>
                </tr>
                <tr>
                    <td height="50">
                        <asp:Button ID="btn_product" runat="server"  CssClass="pagego" Text="生成产品" OnClick="btn_product_Click" /></td>
                </tr> 
                <tr>
                    <td height="50"></td>
                </tr>
                <tr>
                    <td height="50"></td>
                </tr>
            </table> 
        </div>
    </form>
</body>
</html>
