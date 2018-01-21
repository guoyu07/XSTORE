 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsEdit.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GoodsManage.GoodsEdit" validateRequest="false"%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/.js"></script>
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

        function del(obj) {
            $(obj).parent().parent().remove();
        }

        function save_sel() {
            var number = "";
            $(".hidid_class").each(function () {
                number += $(this).val() + ",";//收入数量
            });
            document.getElementById("Bindlist_hidd").value = number;
        }

        $(function () {
            $(".betags").focus(function () {
                $(this).attr("id", "tags");
                var all = "[";
                $("#txt_leibiehao").find("option").each(function () {
                    all += $(this).text() + ",";
                    //alert($(this).text())
                })
                all = all.substring(0, all.length - 1);
                all += "]";
                //var all = [ "ActionScript","AppleScript", "Asp","BASIC", "C", "C++", "Clojure", "COBOL"];
                // alert(all);
                var arry = all.split(',');
                //alert(arry);
                var availableTags = arry;
                $("#tags").autocomplete({
                    source: availableTags
                });
            })
        })
    </script>
    <script>
        $(function () {
            $(".betags").blur(function () {
                $(this).attr("id", "");
                var v = $(this).val();
                //alert(v);
                $(this).next().find("option:contains('" + v + "')").attr("selected", true);
                // $("#drpmanager option:contains('71000614_谢红早')").attr("selected", true);
            })
        })
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

    <script>
        var x = 0
        function Addnewrow() {
            $("#btnSave").attr("style", "");
           x += 1;
           var trHtml = "<tr id=\"trId_" + x + "\"><td><input type=\"text\" id=\"txt编号new" + x + "\"/><input type=\"hidden\" id=\"txtid" + x + "\" value=\"-1\"/></td><td><input type=\"text\" id=\"txt规格" + x + "\"  /></td><td><input type=\"text\" id=\"txt重量" + x + "\"  /></td><td><input type=\"text\" id=\"txt市场价" + x + "\"  /></td><td><input type=\"text\" id=\"txt本站价" + x + "\"  /></td><td><input type=\"text\" id=\"txt库存" + x + "\"/></td><td><a href=\"javascript:;\" onclick=\"del(this)\">删除</a></td></tr>";
            var $tr = $("#tabId tr:last");
            $tr.after(trHtml);
        }


    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>商品管理</span> <i class="arrow"></i><span>商品管理</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
       <telerik:RadAjaxPanel runat="server">
            <div class="content-tab-wrap">
                <asp:HiddenField ID="Bindlist_hidd" runat="server" Value="0" />
                <div id="floatHead" class="content-tab">
                    <div class="content-tab-ul-wrap">
                        <ul>
                            <li><a href="javascript:;" onclick="tabs(this);" class="selected">商品</a></li>
                            <li><a href="javascript:;" onclick="tabs(this);">详情</a></li>
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
                        <asp:TextBox ID="txt_bianhao" runat="server" ReadOnly="true" placeholder="商品编号" CssClass="input normal"
                            datatype="*0-100" sucmsg=" " />
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>类别</dt>
                    <dd>
                        <div class="">
                            <select id="txt_leibiehao" name="txt_leibiehao" runat="server" class="select-field select-field_sousuo" style="width:200px;"></select>&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <script type="text/javascript">
                            $(document).ready(function () {
                                $("#txt_leibiehao").select2();
                            });
                        </script>

                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>组名</dt>
                    <dd>
                        <asp:TextBox ID="txt_pinming" runat="server" placeholder="商品名称" MaxLength="255" CssClass="input normal" />
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>单位</dt>
                    <dd>
                        <asp:TextBox ID="txt_danwei" runat="server" CssClass="input normal"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>编码</dt>
                    <dd>
                        <asp:TextBox ID="txt_bianma" runat="server" placeholder="编码" CssClass="input   normal"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
              <%--  <dl>
                    <dt>显示顺序</dt>
                    <dd>
                        <asp:TextBox ID="txt_number1" runat="server" placeholder="序号整数" CssClass="input   normal"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>--%>
                  <dl>
                <div class="tdh_1">
                    <input type="button" id="btnAdd" value="新增" runat="server" class="btn" onclick="Addnewrow()" />
                    <table id="tabId">
                        <tr>
                            <td style="width: 80px">条形码</td>
                            <td style="width: 80px">规格</td>
                            <td style="width: 80px">重量(kg)</td>
                            <td style="width: 80px">市场价</td>
                            <td style="width: 80px">本站价</td>
                            <td style="width: 80px">库存数量</td>
                            <td style="width: 80px">操作</td>
                        </tr>
                        <tr id="tr规格">
                            <td>
                                <input type="text" runat="server" id="txt编号new" /></td>
                            <td>
                                <input type="text" runat="server" id="txt规格" /></td>
                            <td>
                                <input type="text" runat="server" id="txt重量" /></td>
                            <td>
                                <input type="text" runat="server" id="txt市场价" /></td>
                            <td>
                                <input type="text" runat="server" id="txt本站价" /></td>
                            <td>
                                <input type="text" runat="server" id="txt库存" /></td>
                        </tr>
                        <asp:Literal ID="ltrTr" runat="server"></asp:Literal>
                        <%--              <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("编号new")%></td>
                                    <td><%#Eval("规格")%></td>
                                    <td><%#Eval("重量")%></td>
                                    <td><%#Eval("市场价")%></td>
                                    <td><%#Eval("本站价")%></td>
                                    <td><%#Eval("库存数量")%></td>
                                    <td>
                                        <asp:LinkButton runat="server" Text="删除" CommandArgument='<%#Eval("id")%>' CommandName="DelLine" OnClientClick="return confirm('确认删除？')" /></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                        <%--             <tr id="trId" style="display:none">
                           <td><input type="text" id="add规格"/></td><td><input type="text" id="add重量"/></td><td><input type="text" id="add市场价"/></td><td><input type="text" id="add本站价"/></td>
                      </tr>--%>
                    </table>
                    <asp:HiddenField ID="AddorEdit" Value="1" runat="server" />
                    <%--<input type="hidden" id="AddorEdit" val="1" />编辑是0新增是1--%>
                </div>
            </dl>


                <dl>
                    <dt>限购数量</dt>
                    <dd>
                        <asp:TextBox ID="txt_max_number" runat="server" placeholder="限购数量整数" CssClass="input   normal"></asp:TextBox>
                        <span class="Validform_checktip"></span>
                    </dd>
                </dl>
                <%--<dl>
                    <dt>是否卖家承担运费</dt>
                    <dd>
                        <asp:RadioButtonList ID="txt_yunfei" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </dd>
                </dl>--%>

             <%--   <dl>
                    <dt>运费模板</dt>
                    <dd>
                        <div class="rule-single-select">
                            <select id="yunfeimoban" name="txt_leibiehao" runat="server" class="select-field"></select>

                        </div>
                    </dd>
                </dl>--%>

                <dl>
                    <dt>上架日期</dt>
                    <dd>
                        <input type="text" class="input normal Wdate" runat="server" id="Jxl" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>
                <dl>
                    <dt>下架日期</dt>
                    <dd>
                        <input type="text" class="input normal  Wdate" runat="server" id="Jx2" onclick="    WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })" />
                        <span class="Validform_checktip"></span>
                    </dd>
                </dl>
                <dl>
                    <dt>是否上架</dt>
                    <dd>
                        <asp:RadioButtonList ID="txt_shifoushangjia" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="上架" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="下架" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </dd>
                </dl>
                <dl runat="server" visible="false">
                    <dt>商品类型</dt>
                    <dd>
                        <asp:RadioButtonList ID="txt_spleibie" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="普通" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="返利" Value="2"></asp:ListItem>
                            <asp:ListItem Text="红包" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </dd>
                </dl>
          <%--      <dl>
                    <dt>分销率</dt>
                    <dd>
                        <asp:TextBox ID="txt_分销率" runat="server" placeholder="分销率" CssClass="input   normal"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>--%>
               <%-- <dl>
                    <dt>折扣率</dt>
                    <dd>
                        <asp:TextBox ID="txt_zhekou" runat="server" CssClass="input   normal"></asp:TextBox>
                        <span class="Validform_checktip">*必填</span>
                    </dd>
                </dl>--%>

              <%--  <dl>
                    <dt>更新时间是否计入排序</dt>
                    <dd>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </dd>
                </dl>--%>

                <%--            <dl>
                <dt>满多少包邮</dt>
                <dd>
                    <asp:TextBox ID="txt_baoyou" runat="server" CssClass="input   normal"></asp:TextBox>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>--%>
            </div>
            <!--/内容-->
            <%-- 详情 --%>
            <div class="tab-content" style="display: none">
                <%--            <dl>
                <dt>描述</dt>
                <dd>
                    <fckeditorv2:FCKeditor ID="txt_miaoshu" runat="server" BasePath="~/master/fckeditor/"
                        ToolbarSet="Basic" Height="350px" Width="500px">
                    </fckeditorv2:FCKeditor>
                </dd>
            </dl>--%>
                <em class="suggest_1">图片最佳宽度:600</em>
                <dl>
                    <dt>描述</dt>
                    <dd>
                        <script id="editor" type="text/plain"
                            style="width: 860px; height: 450px;"></script>
                        <asp:HiddenField ID="UEContent" runat="server" />
                    </dd>
                </dl>

                <dl style="display: none;">
                    <dt>特点</dt>
                    <dd>
                        <fckeditorv2:FCKeditor ID="txt_tedian" runat="server" BasePath="~/master/fckeditor/"
                            ToolbarSet="Basic" Height="350px" Width="500px">
                        </fckeditorv2:FCKeditor>
                    </dd>
                </dl>
                <dl style="display: none;">
                    <dt>注意事项</dt>
                    <dd>
                        <fckeditorv2:FCKeditor ID="txt_zhuyishixiang" runat="server" BasePath="~/master/fckeditor/"
                            ToolbarSet="Basic" Height="350px" Width="500px">
                        </fckeditorv2:FCKeditor>
                    </dd>
                </dl>
                <dl style="display: none;">
                    <dt>品牌介绍</dt>
                    <dd>
                        <fckeditorv2:FCKeditor ID="txt_pinpaijieshao" runat="server" BasePath="~/master/fckeditor/"
                            ToolbarSet="Basic" Height="350px" Width="500px">
                        </fckeditorv2:FCKeditor>
                    </dd>
                </dl>
                <dl style="display: none;">
                    <dt>资质证明</dt>
                    <dd>
                        <fckeditorv2:FCKeditor ID="txt_zizhizhengming" runat="server" BasePath="~/master/fckeditor/"
                            ToolbarSet="Basic" Height="350px" Width="500px">
                        </fckeditorv2:FCKeditor>
                    </dd>
                </dl>
            </div>
            <%-- 详情 --%>
        
            <div class="tab-content" style="display: none">
                <em class="suggest_2">图片最佳尺寸 600*600px 仅第一张有效</em>
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
                                        <br />
                                        <span>序号：</span><input type="text" class="normal input" style="width: 50px" name="txt_序号" value='<%#Eval("序号")%>' />
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <asp:HiddenField runat="server" id="ps"/>
            </div>
           </telerik:RadAjaxPanel>
            <!--/内容-->
            <!--工具栏-->
            <br />
            <div class="page-footer">
                <div class="btn-list">
                    <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" OnClientClick="save_sel();" />
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
<%--    </telerik:RadAjaxPanel>--%>
    </form>
</body>
</html>
