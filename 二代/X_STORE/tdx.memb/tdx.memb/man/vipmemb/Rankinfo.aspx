<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rankinfo.aspx.cs" Inherits="tdx.memb.man.vipmemb.Rankinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--内容-->
    <h1>
        <strong>会员卡等级</strong></h1>
    <div class="nei_content" id="nei_content">

      <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <div class="btn_container">            
            <input type="button" class="btnAdd"  onclick="location.href='RankinfoEdit.aspx'" value="添加会员等级" />
        </div>
        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
        </div>
    </div>
    <!--内容结束-->
    </form>
</body>
</html>
