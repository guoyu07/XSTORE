<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WP_People_Add.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GoodsManage.WP_People_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    
</head>
<body>
    <asp:Literal ID="ltHead" runat="server"></asp:Literal>
    <form id="form1" runat="server">
    <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>弹幕人员管理</span>
            <i class="arrow"></i>
            <span>弹幕人员管理</span>
        </div>
        <!--/导航栏-->
         <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">商品类别</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--提示-->
        <div class="tsxx">
            <img class="tsxx_1" src="/man/images4/ts.png">
            <span class="tsxx_2">
                    <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/man/images4/xx.png">
        </div>


    <div class="tab-content">
        <dl>
            <dt>人员名称</dt>
            <dd>
               <input type="text" name="txtmc" placeholder="人员名称" class="px" runat="server"
                        id="txtmc" maxlength="200" /><br />
                        <span class="gray">人员名称</span>      
            </dd>
        </dl>



   </div>
 <!--工具栏-->
    <br />
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button  runat="server" Text="提交保存" CssClass="btn" id="btnSave"   onclick="btnSave_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->  
       
    </form>
    <!--中间结束-->
</body>
</html>
