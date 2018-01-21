<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TalkEdit.aspx.cs" Inherits="tdx.memb.man.Talking.TalkEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <!--百度编辑器!-->
    <script src="../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
    <script src="../../scripts/swfupload/swfupload.js"></script>
    <script src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script src="../../scripts/swfupload/swfupload.queue.js"></script>
    <%--    <script src="../../js/form_common.js"></script>
    <script src="../../js/layout.js"></script>--%>
    <script src="../../Scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        $(function () {
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../../Tools/upload1.ashx", size: "50x50,1600x1600", flashurl: "../../../Scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                var field = $(this).attr("field");
                $(this).InitSWFUpload({ field: field, btntext: "批量图片", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", size: "50*50", sendurl: "../../../Tools/upload1.ashx", flashurl: "../../../Scripts/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
        });
    </script>

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>用户信息</span> <i class="arrow"></i><span>用户信息添加</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">帖子</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">图片</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <%-- 商品 --%>
        <div class="tab-content">
            <dl>
                <dt>编号</dt>
                <dd>
                    <input id="isshow" runat="server" type="hidden" />
                    <asp:TextBox ID="txt_bianhao" runat="server" ReadOnly="true" placeholder="编号" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>类别号</dt>
                <dd>
                    <div class="rule-single-select">
                        <select id="txt_leibiehao" name="txt_leibiehao" runat="server" class="select-field"></select>

                    </div>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txt_pinming" runat="server" placeholder="名称" MaxLength="255" CssClass="input normal" />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>内容</dt>
                <dd>
                    <script id="editor" type="text/plain"
                        style="width: 860px; height: 450px;"></script>
                    <asp:HiddenField ID="UEContent" runat="server" />
                </dd>
            </dl>
            <dl>
                <dt>是否置顶</dt>
                <dd>
                    <asp:RadioButtonList ID="txt_shifoushangjia" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
            </dl>

        </div>

        <div class="tab-content" style="display: none">

            <div class="padd_26">
                <div class="upload-box upload-album" field="pics"></div>

                <div id="showAttachList" class="photo-list">
                    <ul>

                        <asp:Repeater ID="rptManagementAttachList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input name="hid_photo_name" type="hidden" value="0|<%#Eval("图片路径")%>" />
                                    <div class="img-box">
                                        <a href="<%#Eval("图片路径")%>" class="fancy" rel="lightbox-group">
                                            <img src='<%#Eval("图片路径")%>'><%#Eval("标题")%></img>
                                        </a>
                                    </div>
                                    <a href="javascript:;" onclick="delImg(this,'pics')">删除</a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>

        </div>

        <!--/内容-->
        <!--工具栏-->
        <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->

        <script type="text/javascript">
            //实例化编辑器
            var ue = baidu.editor.ui.Editor();
            ue.render('editor');
            function getContent() {
                document.getElementById("UEContent").value = ue.getContent();
            }
            function setContent() {
                var val = document.getElementById("UEContent").value;
                ue.setContent(val);
            }
            $(document).ready(function () {
                $("#Button2").click(function () {
                    getContent();
                });
                ue.ready(function () {
                    setContent();
                })
            });
        </script>

    </form>
</body>
</html>
