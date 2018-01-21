<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPhotoEdit.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.GoodsPhotoEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="nav_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>用户信息</span>
            <i class="arrow"></i>
            <span>用户信息添加</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">图片</a></li>
                         
                    </ul>
                </div>
            </div>
        </div>
 
         
       
        <%-- 图片--%>
        
            <div class="tab-content"  >
                <dl>
                    <dt>品名</dt>
                    <dd>
                        <div class="rule-single-select"> <asp:DropDownList CssClass="input" ID="drp_photo" runat="server"   ></asp:DropDownList></div>
                    </dd>
                </dl>
                <dl>
                    <dt>标题</dt>
                    <dd>
                        <asp:TextBox ID="txt_biaoti" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                        <span class="Validform_checktip"></span>
                    </dd>
                </dl>
                <dl>
                    <dt>图片</dt>
                    <dd>
                       <img src='<%=src %>' style='width:7%;height:7%;'/><br/>
                         <asp:TextBox ID="txt_img" runat="server" MaxLength="255" CssClass="input normal" />  
                         <input type="file" name="t_source_file" runat="server" id="t_source_file" class="px"
                        maxlength="255" /> 
                        <span class="gray">最佳尺寸：800*414 格式:jpg png gif</span> 
                    </dd>
                </dl>
                 

            </div>
            <!--/内容-->

            <!--工具栏-->
            <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>


