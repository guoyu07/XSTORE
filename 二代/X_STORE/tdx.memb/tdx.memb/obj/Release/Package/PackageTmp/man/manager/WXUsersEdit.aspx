<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WXUsersEdit.aspx.cs" Inherits="tdx.memb.man.manager.WXUsersEdit" ValidateRequest="false" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户信息</title>
    <script src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../ShoppingMall/OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../js/select2.js"></script>
    <link href="../css/select2.css" rel="stylesheet" />
    <!--百度编辑器!-->
    <script src="../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
    <script src="../../js/jquery-ui.js"></script>
    <script src="../../../scripts/swfupload/swfupload.js"></script>
    <script src="../../../scripts/swfupload/swfupload.handlers.js"></script>
    <script src="../../../scripts/swfupload/swfupload.queue.js"></script>
    <script src="../../js/form_common.js"></script>
    <script src="../../js/layout.js"></script>
    <script src="../../../Scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        $(function () {
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../../Tools/upload1.ashx", size: "50x50,1600x1600", flashurl: "../../../Scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                var field = $(this).attr("field");
                $(this).InitSWFUpload({ field: field, btntext: "上传图片", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", size: "50*50", sendurl: "../../../Tools/upload1.ashx", flashurl: "../../../Scripts/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>用户列表</span> <i class="arrow"></i><span>用户信息</span>
        </div>

        <div class="tab-content">
            <dl>
                <dt>管理角色</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlRoleId" runat="server" datatype="*" errormsg="请选择用户角色" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>用户名</dt>
                <dd>
                    <asp:TextBox ID="txt_name" runat="server" placeholder="用户名" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                    <asp:Label ID="user_name" runat="server"></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>密码</dt>
                <dd>
                    <asp:TextBox ID="txt_pwd" runat="server" placeholder="密码" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>验证密码</dt>
                <dd>
                    <asp:TextBox ID="txt_again_pwd" runat="server" placeholder="验证密码" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                    <asp:Label ID="pwd_yz" runat="server"></asp:Label>

                </dd>
            </dl>
            <dl>
                <dt>openid</dt>
                <dd>
                    <asp:TextBox ID="txt_openid" runat="server" placeholder="openid" MaxLength="255" CssClass="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>手机号</dt>
                <dd>
                    <asp:TextBox ID="txt_phono" runat="server" placeholder="手机号" MaxLength="12" CssClass="input normal" />
                </dd>
            </dl>

            <dl>
                <dt>真实姓名</dt>
                <dd>
                    <asp:TextBox ID="txt_real_name" runat="server" placeholder="真实姓名" MaxLength="12" CssClass="input normal" />
                </dd>
            </dl>

            <dl>
                <dt>QQ</dt>
                <dd>
                    <asp:TextBox ID="txt_qq" runat="server" placeholder="QQ" MaxLength="15" CssClass="input normal" />
                </dd>
            </dl>

            <dl>
                <dt>Email</dt>
                <dd>
                    <asp:TextBox ID="txt_email" runat="server" placeholder="Email" MaxLength="20" CssClass="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>微信昵称</dt>
                <dd>
                    <asp:TextBox ID="txt_wx_nick" runat="server" placeholder="微信昵称" MaxLength="255" CssClass="input normal" />
                </dd>
            </dl>
            <dl>
                <dt>微信头像</dt>
                &nbsp;&nbsp;&nbsp;&nbsp;

                <div class="upload-box upload-album" field="pics"></div>

                <div id="showAttachList" class="photo-list">
                    <ul>

                        <asp:Repeater ID="rptManagementAttachList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input name="hid_photo_name" type="hidden" value="0|<%#Eval("微信头像")%>" />
                                    <div class="img-box">
                                        <a href="<%#Eval("微信头像")%>" class="fancy" rel="lightbox-group">
                                            <img src='<%#Eval("微信头像")%>'></img>
                                        </a>
                                    </div>
                                    <a href="javascript:;" onclick="delImg(this,'pics')">删除</a>
                                    <br />
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <%-- </dd>--%>
            </dl>

            <div class="page-footer">
                <div class="btn-list">
                    <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="save_sel();" />

                    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
                </div>
                <div class="clear">
                </div>
            </div>
    </form>
</body>
</html>
