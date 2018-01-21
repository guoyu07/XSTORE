<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FerightMainDEdit.aspx.cs" Inherits="tdx.memb.man.ShoppingMall.GoodsManage.FerightMainDEdit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>

    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <!--百度编辑器!-->
    <script src="../../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>

    <script src="../../js/selectcity/jquery.js"></script>
    <script src="../../js/selectcity/city.min.js"></script>
    <script src="../../js/selectcity/jquery.cityselect.js"></script>
   <%--  <link href="../../js/selectcity/common.css" rel="stylesheet" />--%>

     <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../../scripts/swfupload/swfupload.js"></script>
    <script src="../../../scripts/swfupload/swfupload.handlers.js"></script>
    <script src="../../../scripts/swfupload/swfupload.queue.js"></script>
    <script src="../../../Scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
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

    <script type="text/javascript">
        //function getcity() {
        //    var city = $(".prov").val() + "," + $(".city").val() + "," + $(".dist").val();
        //    $("#txt_地区").val(city);
        //}
        function ckprince(obj)
        {
            var area = $("#txt_地区").val();
            var ckvalue = $(obj).val();
            var str="";  
            $('input[class="chk"]:checked').each(function () {
                str += $(this).val() + ",";
            });
            $("#txt_地区").val(str);
            //if (ckvalue == "true") {
            //    var newares = ckvalue.replace(area, "") + area;
            //    $("#txt_地区").val(newares);
            //}
            //else
            //{
            //    var newares = ckvalue.replace(area, "");
            //    $("#txt_地区").val(newares);
            //}
        }
        function checkui()
        {
            var muban = $("#select_模板").val();
            if (muban == "")
            {
                alert("请选择模板");
                return false;
            }

            var mingcheng = $("#txt_名称").val();
            if (mingcheng = "")
            {
                alert("请输入名称");
                return false;
            }
            var shouzhong = $("#txt_首重").val();
            if (shouzhong==""||!/^[0-9.]*$/.test(shouzhong))
            {
                alert("请输入首重，纯数字");
                return false;
            }
            var xuzhong = $("#txt_续重").val();
            if (xuzhong==""||!/^[0-9.]*$/.test(shouzhong)) {
                alert("请输入续重，纯数字");
                return false;
            }
            var diqu = $("#txt_地区").val();
            if (diqu == "")
            {
                alert("请输入地区");
                return false;
            }
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>用户信息</span> <i class="arrow"></i><span>用户信息添加</span>
        </div>
        <div class="line10">
        </div>
        <!--/导航栏-->
        <!--内容-->
        <%-- 商品 --%>
        <div class="tab-content" runat="server">
            <dl>
                <dt>模板名称</dt>
                <dd>
                    <div class="rule-single-select">
                        <select ID="select_模板" class="select-field" runat="server" placeholder="模板名称" ></select>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>名称</dt>
                <dd>
                    <asp:TextBox ID="txt_名称" runat="server" placeholder="名称" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>首重</dt>
                <dd>
                    <asp:TextBox ID="txt_首重" runat="server" placeholder="首重" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                     <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>续重</dt>
                <dd>
                    <asp:TextBox ID="txt_续重" runat="server" placeholder="商品编号" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
            <dl>
                <dt>地区</dt>
                <dd>
                    <asp:TextBox ID="txt_地区" runat="server" placeholder="地区" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
                <%--<dd>
                    <asp:HiddenField ID="hidecity" runat="server" />
                    <div id="city" class="rule-single-select">
                        <select class="prov select-field"  ></select><!--onmouseup ="getcity()"-->
                        <select class="city select-field"   disabled="disabled"></select>
                        <select class="dist select-field"   disabled="disabled"></select>
                    </div>
                        <script type="text/javascript">
                            $("#city").citySelect();
                     </script>
                </dd>--%>
            </dl>
            <dl>
                <dt>省份选择</dt>
                <dd>
                     <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                         <tr>                     
                                 <th width="8%">选择</th>
                         </tr>

                    <asp:Repeater ID="rptPrince" runat="server">
                        <ItemTemplate>
                              <tr>
                        <td style="text-align: center;">
                            <input type="checkbox" value=' <%#Eval("ProvinceName")%>' id="provck" runat="server" class="chk" onchange ="ckprince(this)"/>
                            <%#Eval("ProvinceName")%>
                            <asp:HiddenField ID="procname" runat="server" Value='<%#Eval("ProvinceName")%>'/>
                            </td>
                                  </tr>
                        </ItemTemplate>
     
                    </asp:Repeater>
                             </table> 
                </dd>
            </dl>
        </div>
        
        <!--/内容-->
        <!--工具栏-->
        <br />
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClientClick="javascript:return checkui()" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
