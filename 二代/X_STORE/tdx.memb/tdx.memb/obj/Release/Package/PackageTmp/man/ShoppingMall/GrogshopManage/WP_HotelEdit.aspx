<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WP_HotelEdit.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GrogshopManage.WP_HotelEdit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <script src="../../js/select2.js"></script>
    <link href="../../css/select2.css" rel="stylesheet" />

    <!--百度编辑器!-->
    <script src="../../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
    <script src="../../js/jquery-ui.js"></script>
 <script src="../../../scripts/swfupload/swfupload.js"></script>
    <script src="../../../scripts/swfupload/swfupload.handlers.noxuhao.js"></script>
    <script src="../../../scripts/swfupload/swfupload.queue.js"></script>
    <%--    <script src="../../js/form_common.js"></script>
    <script src="../../js/layout.js"></script>--%>
<script src="../../../Scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript">
        $(function () {
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../../Tools/upload1.ashx", size: "50x50,1600x1600", flashurl: "../../../Scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                var field = $(this).attr("field");
                $(this).InitSWFUpload({ field: field, btntext: "上传图片", btnwidth: 66, single: false, water: true, thumbnail: true, filesize: "2048", size: "50*50", sendurl: "../../../Tools/upload1.ashx", flashurl: "../../../Scripts/swfupload.swf", flashurl: "../../../Scripts/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
        });

        function del(obj) {
            $(obj).parent().parent().remove();
        }
    </script>

    <script>
        function Ajaxdel(obj) {
            var id = $(obj).parent().parent().children("td:eq(0)").find("input").eq(1).val();
            $.ajax({
                type: "post",
                datatype: "text",
                url: "AjaxDel.ashx",
                data: { id: id },
                async: false,
                success: function (data) {
                    if (data == "1") {
                        alert('操作成功');
                        location.reload(true);
                    }
                }
            })
        }
    </script>

</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>酒店信息</span> <i class="arrow"></i><span>酒店信息修改</span>
        </div>
        <div class="line10">
        </div>
        <div class="tab-content">
            <dl>
                <dt>酒店全称&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox ID="txtjdmc" runat="server" CssClass="input normal" ></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>酒店简称&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox ID="txtjdjc" runat="server" CssClass="input normal"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>Logo&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <dd>
                    <div class="padd_26">
                        <div class="upload-box upload-album" field="pics"></div>
                        <span class="Validform_checktip">*必填&nbsp;&nbsp;<em style="color: red;">图片最佳尺寸 600*600px 仅第一张有效</em></span>
                        <div id="showAttachList11" class="photo-list">
                            <ul>

                                <asp:Repeater ID="rptlogo" runat="server">
                                    <ItemTemplate>
                                        <li>
                                          <input name="hid_photo_name"type="hidden" value='0|<%#Eval("Logo")%>' />
                                            <div class="img-box">
                                                <a href="<%#Eval("Logo")%>" class="fancy" rel="lightbox-group">
                                                    <img src='<%#Eval("Logo")%>'></img>
                                                </a>
                                            </div>
                                            <a href="javascript:;" onclick="delImg(this,'pics')">删除</a>
                                            <br />
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    
                    <%--<input id="isshow111" runat="server" type="hidden" />--%>
                    <%--  <asp:TextBox ID="txt_bianhao11" runat="server" ReadOnly="true" placeholder="商品编号" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />--%>
                </dd>
            </dl>
<%--          <dl>
                <asp:Label ID="lblx" runat="server"></asp:Label>
            </dl>--%>
            <dl>
                <dt>所在地区&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:DropDownList ID="dparea" CssClass="input normal" runat="server" AutoPostBack="true"></asp:DropDownList>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <%--<dl>
                <dt>详细地址&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox runat="server" ID="txtdizhi" CssClass="input normal"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>
            <dl>
                <dt>前台电话&nbsp;&nbsp;&nbsp;&nbsp;</dt>
                <asp:TextBox runat="server" ID="txtphone" CssClass="input normal"></asp:TextBox>
                <span class="Validform_checktip">*必填</span>
            </dl>--%>

        </div>

        <!--/工具栏-->
               <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Btnhotel" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="AjaxAdd()" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
       <%-- <script type="text/javascript">
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
        </script>--%>

    </form>
</body>
</html>

