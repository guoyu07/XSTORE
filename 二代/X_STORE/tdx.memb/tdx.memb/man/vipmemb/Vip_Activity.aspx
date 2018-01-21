<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vip_Activity.aspx.cs" Inherits="tdx.memb.man.vipmemb.Vip_Activity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员活动设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
     <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkAll(field, c) {
            for (i = 0; i < field.length; i++)
                field[i].checked = c.checked;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <strong>会员卡活动</strong></h1>
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
            <input type="button" class="btnAdd" onclick="location.href='Edit_Activity.aspx'"
                value="添加活动" />
            <input name="delBtn" value="彻底删除" onclick="return confirm('确定删除吗？删除后将不可恢复！');" runat="server"
                id="delBtn" class="btnDelete" type="submit" onserverclick="delActivity_Click" />
        </div>
        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false">
            </asp:Literal>
        </div>
    </div>
   
    </form>
</body>
</html>
