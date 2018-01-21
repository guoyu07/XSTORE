<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipEdit.aspx.cs" Inherits="tdx.memb.man.Tuan.VipManage.VipEdit" %>

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
            <a href="VipList.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
             <i class="arrow"></i>
            <span>会员管理</span>
            <i class="arrow"></i>
            <span>会员编辑</span>
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
                <dt>openid</dt>
                <dd>
                    <asp:TextBox ID="txt_openid" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
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
                <dt>微信头像</dt>
                <dd>
                    <asp:TextBox ID="txt_Headimg" runat="server" CssClass="input normal"></asp:TextBox>
                    <input type="file" name="t_source_file" runat="server" id="t_source_file" class="px"
                        maxlength="255" /> 
                        <span class="gray">最大宽高:360*200 像素:72 格式:jpg png gif</span> 
                    
                </dd>
            </dl>
            
             
            <dl>
                <dt>微信昵称</dt>
                <dd>
                    <asp:TextBox ID="txt_nicheng" runat="server" CssClass="input Wdate normal" onClick="WdatePicker()"></asp:TextBox>
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

