<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wx_keys_Edit.aspx.cs" Inherits="tdx.memb.man.Texts.wx_keys_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../images4/B2C_msg_Add.css" />
    <script src="../../js/jquery.form.js" type="text/javascript"></script>
    <script src="../../js/B2C_msg_Add.js" type="text/javascript"></script>
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="nei_content">
    <div style="padding: 32px 0 0 32px;">
        <span>关键字：</span>
        <input type="text" runat="server" id="txt_gtitle" style="background: none repeat scroll 0 0 #fff;
            border: 1px solid #999; border-radius: 3px; height: 20px; line-height: 20px;
            padding: 4px; width: 360px;" /><span style="color: #999; margin-left: 8px;">关键词之前用,分隔</span></div>
    <div class="main">
        <asp:HiddenField ID="hfGuid" runat="server" />
        <asp:HiddenField ID="hfwid" runat="server" />
        <input type="hidden" id="delItem" value="" />
        <div class="main_left">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="otherAdd">
                <a href="javascript:void(0)">添加</a>
            </div>
        </div>
        <div class="main_right">
            <div class="main_edit" target="titlePageInfo">
                <div class="edit_item">
                    <p>
                        标题</p>
                    <div class="edit_item_msgbg">
                        <input type="text" id="txtTitle" /></div>
                </div>
                <div class="edit_item" style="display: none;">
                    <p>
                        作者</p>
                    <div class="edit_item_msgbg">
                        <input type="text" id="txtAuthor" /></div>
                </div>
                <div class="edit_item">
                    <p>
                        上传图片</p>
                    <div class="edit_item_msgbg">
                        <input type="file" id="selectFile" accept="image/*" runat="server" />
                        <div style="margin: 8px;">
                            <img id="_thisImg" src="" />
                            <a href="javascript:void(0)" id="delImg">删除</a>
                        </div>
                    </div>
                </div>
                <div class="edit_item">
                    <p>
                        摘要</p>
                    <div class="edit_item_msgbg">
                        <textarea id="summary" rows="4"></textarea>
                    </div>
                </div>
                <div class="edit_item">
                    <p>
                        正文</p>
                    <div class="edit_item_msgbg">
                        <fckeditorv2:FCKeditor ID="_msg" runat="server" BasePath="~/master/fckeditor/" ToolbarSet="Basic"
                            Width="548px" Height="350px">
                        </fckeditorv2:FCKeditor>
                    </div>
                </div>
                <div class="edit_item">
                    <p>
                        跳转链接</p>
                    <div class="edit_item_msgbg">
                        <input type="text" id="txtBodyUrl" /></div>
                    <div class="edit_item_tip">
                        填写此项,正文内容将无效</div>
                </div>
            </div>
            <div class="main_edit_arrow">
            </div>
        </div>
        <p id="json">
        </p>
    </div>
    <div style="text-align: center;">
        <input type="button" value=" 保 存 " class="btnGreen" id="btn_wxkey_AjaxUpdate" /></div><div class="nei_temp"><img /></div></div>
    </form>
</body>
</html>
