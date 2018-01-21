<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Group_fran.aspx.cs" Inherits="tdx.memb.man.vipmemb.Group_fran" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
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
      <strong>
            会员卡分组管理</strong></h1>
    <div class="nei_content" id="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <!--内容-->
        <div class="btn_container">            
            <input type="button" class="btnAdd"  onclick="location.href='Group_franEdit.aspx'" value="添加分组"/>
            <input name="delBtn" value="彻底删除" onclick="return confirm('确定删除吗？删除后将不可恢复！');" runat="server"
                id="delBtn" class="btnDelete" type="submit" onserverclick="delGroup" />
        </div>
        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
        </div>
    </div>
    <!--内容结束-->
    </form>
</body>
</html>
