<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Franchises.aspx.cs" Inherits="tdx.memb.man.vipmemb.Franchises" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="../../js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script src="../../js/jQueryLoadImg.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/tdx_date.js"> </script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <script type="text/javascript">
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
      <strong>会员卡特权管理</strong></h1>
    <div class="nei_content" id="nei_content">

     <div class="greenRemind">
            <abbr>
            </abbr>
            <span>
                <asp:Literal ID="lt_friendly" runat="server"></asp:Literal></span> <a class="closeRemind"
                    href="javascript:void(0)"></a>
        </div>
        <!--内容-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>
        <div class="btn_container">            
            <input type="button" class="btnAdd"  onclick="location.href='FranchisesEdit.aspx'" value="添加新会员卡特权"/>
            <asp:Button ID="delBtn" runat="server" Text="彻底删除" class="btnDelete" 
                OnClick="delBtn_ServerClick" OnClientClick="return confirm('确定删除吗？删除后将不可恢复！')" />
            <input type="button" class="btnAdd"  onclick="location.href='Group_fran.aspx'" value="管理会员卡分组"/>

        </div>
        <div class="tdh">
            <asp:Literal ID="ylList" runat="server" EnableViewState="false"></asp:Literal>
        </div>
    </div>
    <!--内容结束-->
    </form>
</body>
</html>
