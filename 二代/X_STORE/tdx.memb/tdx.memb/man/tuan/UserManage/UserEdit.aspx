<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="tdx.memb.man.Tuan.UserManage.UserEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>拼好货</title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body  class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="nav_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
             <i class="arrow"></i>
            <span>用户管理</span>
            <i class="arrow"></i>
            <span>用户编辑</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">HouseInfo_Add</a></li>
                    </ul>
                </div>
            </div>
        </div>
         
        <div class="tab-content">
            <dl>
                <dt>用户名</dt>
                <dd>
                    <asp:TextBox ID="txt_Name" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>密码</dt>
                <dd>
                    <asp:TextBox ID="txt_mima" runat="server" MaxLength="255" CssClass="input normal" />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>手机号</dt>
                <dd>
                    <asp:TextBox ID="txt_Telephone" runat="server" MaxLength="255" CssClass="input normal" />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            
            <dl>
                <dt>openid</dt>
                <dd>
                    <asp:TextBox ID="txt_openid" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl> 
              <dl>
                <dt>商家地址</dt>
                <dd>
                    <asp:TextBox ID="txt_address" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl> 
            
        </div>
        <!--/内容-->

       <!--工具栏-->
         <br/>
       
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        
        <!--/工具栏-->

    </form>
</body>
</html>

