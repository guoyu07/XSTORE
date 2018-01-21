<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Action_MsList.aspx.cs" Inherits="tdx.memb.man.Goods.Action_MsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>秒杀列表</title>
    <link href="../images4/nei.css" type="text/css" rel="stylesheet">
    <link href="/js/nei.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/js/tdx_member.js" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>秒杀活动列表</strong></h1>
    <div class="nei_content">
    <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>

        <!--center content-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2"><asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <div class="btn_container">
            <asp:Literal ID="lb_proadd" runat="server"></asp:Literal>
            <asp:Button  name="delBtn" runat="server" Text="彻底删除" ForeColor="Red" OnClick="delBtn_Click" ID="delBtn"
            OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" class="btnGray" /></div>
                <div class="tdh"><asp:Literal ID="lb_prolist" runat="server"></asp:Literal></div>
        
    </div>
    </form>
</body>
</html>
