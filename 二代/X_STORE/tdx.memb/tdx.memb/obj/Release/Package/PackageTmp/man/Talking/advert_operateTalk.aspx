<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advert_operateTalk.aspx.cs" Inherits="tdx.memb.man.Talking.advert_operateTalk" %>

<!DOCTYPE html>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/choose_talk.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证

            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    </asp:UpdatePanel>
    <asp:HiddenField ID="hideid" runat="server" />
    <!--导航栏-->
    <div class="location">
        <a href="../Talking/advert_manageTalk.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="../Talking/advert_manageTalk.aspx">
                <span>广告管理</span></a> <i class="arrow"></i><span>编辑信息</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>代码</dt>
            <dd>
                <asp:TextBox ID="txtcode" runat="server" CssClass="input normal" datatype="*1-100"
                    sucmsg=" " nullmsg="请输入代码" />
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl>
            <dt>名称</dt>
            <dd>
                <asp:TextBox ID="txtname" runat="server" CssClass="input normal" datatype="*1-100"
                    sucmsg=" " nullmsg="请输入名称" />
                <span class="Validform_checktip"></span>
            </dd>
        </dl>
        <dl>
            <dt>图片数组</dt>
            <dd>
                <asp:Button ID="btnAdd" runat="server" Text="添加图片" CssClass="btn" OnClick="btnAdd_Click" />
                <ul>
                    <asp:Repeater ID="rptlist1" runat="server">
                        <ItemTemplate>
                            <li style="margin-top: 5px; margin-bottom: 5px; padding: 4px; border-top: 1px solid #ccc;
                                padding-bottom: 3px; padding-top: 5px; width: 600px; background-color: #f3f3f3;">
                                <img src="<%#Eval("pic") %>" class="upload-path" height="60px" />
                                <div style="line-height: 5px; height: 5px;">
                                </div>
                                <asp:TextBox ID="url" runat="server" CssClass="input normal" Text='<%#Eval("url") %>' placeholder="请输入链接地址(http://)" />
                             <%--   <a href="javascript:;;" onclick="choose_talk(this,'single')"  >选择</a>--%>
                                <br />
                                <asp:TextBox ID="pic" runat="server" CssClass="input normal upload-path" Text='<%#Eval("pic") %>' placeholder="图片路径" />
                                <div class="upload-box upload-img">
                                </div>
                                <asp:Button ID="btnDel" runat="server" Text="删除图片" OnClick="btnDel_Click" CssClass="btn" />
                                <br /><span>序号</span><asp:TextBox ID="txt_ordernum" runat="server" Width="50px" CssClass="input normal" Text='<%#Eval("ordernum") %>' placeholder="图片展示序号" />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </dd>
        </dl>
    </div>
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: window.history.back(-1)" />
            <asp:Button ID="btnInsert" runat="server" Text="添加" CssClass="btn" OnClick="btnInsert_Click"
                Visible="false" />
            <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="btn" OnClick="btnUpdate_Click"
                Visible="false" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>

