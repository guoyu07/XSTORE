<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FerightMainEdit.aspx.cs" Inherits="tdx.memb.man.Shop.GoodsManage.FerightMainEdit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="fckeditorv2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../js/layout.js"></script>
    <link href="../../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../OrdersManage/build/My97DatePicker/WdatePicker.js"></script>
    <!--百度编辑器!-->
    <script src="../../../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../../../ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script src="../../../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript">
        var UEDITOR_HOME_URL = "./ueditor/"; //从项目的根目录开始
    </script>
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
    <script>
        function chkAll(obj) {
            if ($(obj).prop("checked")) {
                //$(obj).siblings().attr("checked", true);
                $(obj).siblings().prop("checked",true);
            }
            else {
                //$(obj).siblings().attr("checked", false);
                $(obj).siblings().prop("checked", false);
            }
            
        }
        var x = 3;
        function Addnewrow() {
            x += 1;
            var trHtml = "<tr><td id=\"td_"+x+"\"><a href=\"javascript:;\" onclick=\"add(this)\">编辑</a><input type=\"text\" value=\"\" /></td><td><input type=\"text\" value=\"1\" /></td><td><input type=\"text\" value=\"1\" /></td><td><input type=\"text\" value=\"1\" /></td><td><input type=\"text\" value=\"1\" /></td><td><input type=\"checkbox\" value=\"平邮\"/>平邮<input type=\"checkbox\" value=\"快递\"/>快递<input type=\"checkbox\" value=\"EMS\"/>EMS</td><td><a href=\"javascript:;\" onclick=\"del(this)\">删除</a></td></tr>";
            var $tr = $("#tabId tr:last");
            $tr.after(trHtml);
        }

        function add(obj) {
            $("#areaSelect").attr("style", "");
            var td = $(obj).parent().attr("id");
            //alert(td);
            $("#btnSure").attr("onclick", "AddtoTd("+td + ")");
        }
        function AddtoTd(x) {
            var area = "";
            $("input[class='ck']").each(function () {
                if ($(this).prop("checked")) {
                    area += $(this).val() + ",";
                }
            })
            if (area !== "") {
                area = area.substring(0, area.length - 1);
            }
            $(x).parent().find("input:eq(0)").val(area);
            //$(x).attr("value", area);
            $("#areaSelect").hide();
        }
        function del(obj) {
            $(obj).parent().parent().remove();
        }


        function getChkbox(i, x, y) {
            var tableObj = document.getElementById("tabId");
            var cbk = tableObj.rows[i].cells[x].getElementsByTagName("INPUT");
            if (cbk[y].checked) {
                return cbk[y].value;
            }
            else {
                return "无";
            }
        }

        function AjaxAdd() {
            var A模板名称 = $("#txt_bianhao").val();
            var A发货时间 = $("#selTime").val();
            var A计价方式 = $("input[name='rdoSelect']:checked").val();
            var A运送方式 = "";
                $("input[class='ckb']").each(function () {
                    if ($(this).prop("checked")) {
                        A运送方式 += $(this).val() + ",";
                    }
                    else {
                        A运送方式 += "无,";
                    }
            });
            var A默认重量 = $("#txt默认kg").val();
            var A默认元 = $("#txt默认元").val();
            var A增重 = $("#txt增加kg").val();
            var A增元 = $("#txt增加元").val();
           // alert(A模板名称);
            var tableObj = document.getElementById("tabId");
            var jsonstr = "[";
            for (var i = 1; i < tableObj.rows.length; i++) //遍历Table的所有Row
            {
                jsonstr += "{";
                //  for (var j = 0; j < tableObj.rows[i].cells.length; j++) {   //遍历Row中的每一列
                //tableInfo += tableObj.rows[i].cells[j].innerText;   //获取Table中单元格的内容
                jsonstr += "\"j地区\":\"" + tableObj.rows[i].cells[0].getElementsByTagName("INPUT")[0].value + "\",\"j首重\":\"" + tableObj.rows[i].cells[1].getElementsByTagName("INPUT")[0].value + "\",\"j首费\":\"" + tableObj.rows[i].cells[2].getElementsByTagName("INPUT")[0].value + "\",\"j续重\":\"" + tableObj.rows[i].cells[3].getElementsByTagName("INPUT")[0].value + "\",\"j续费\":\"" + tableObj.rows[i].cells[4].getElementsByTagName("INPUT")[0].value + "\",\"j运送方式\":\"" + getChkbox(i, 5, 0) + "," + getChkbox(i, 5, 1) + "," + getChkbox(i, 5, 2) + "\" ";
                // }                                                                                                                                                                                                                                                                                                                                                                                                                                                             tableObj.rows[i].cells[5].getElementsByTagName("checkbox")[0].value//tableObj.rows[i].cells[5].getElementsByTagName("checkbox")[1].value//tableObj.rows[i].cells[5].getElementsByTagName("checkbox")[2].checked.value 
                jsonstr += "},";
            }
            //jsonstr = jsonstr.substring(0, jsonstr.length - 1);
            jsonstr += "{\"j地区\":\"默认\",\"j首重\":\"" + A默认重量 + "\",\"j首费\":\"" + A默认元 + "\",\"j续重\":\"" + A增重 + "\",\"j续费\":\"" + A增元 + "\",\"j运送方式\":\"" + A运送方式 + "\"}]";

            $.ajax({
                type: "post",
                datatype: "text",
                url: "FerightEdit.ashx",
                data: { jsonstr: jsonstr, A模板名称: A模板名称, A计价方式: A计价方式 },
                async: false,
                success: function (data) {
                    if (data == "1") {
                        alert('操作成功');
                        location.href = 'FerightList.aspx';
                    }
                }
            })
        }

        function change(obj) {
            if ($(obj).prop("checked") && $(obj).attr("id") == "rdoj")
            {
                $("#cgTitle1").html("件内");
                $("#cgTitle2").html("件");
                $("#changeTitle1").html("首件(件)");
                $("#changeTitle2").html("续件(件)");
            }
            else if ($(obj).prop("checked") && $(obj).attr("id") == "rdoW")
            {
                $("#cgTitle1").html("kg内");
                $("#cgTitle2").html("kg");
                $("#changeTitle1").html("首重(kg)");
                $("#changeTitle2").html("续重(kg)");
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
        <div class="tab-content">
            <dl>
                <dt>模板名称</dt>
                <dd>
                    <asp:TextBox ID="txt_bianhao" runat="server" placeholder="模板名称" CssClass="input normal"
                        datatype="*0-100" sucmsg=" " />
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>
 <%--           <dl>
                <dt>发货时间</dt>
                <dd>          
                    <select id="selTime">
                        <option>12:00~14:00</option>
                        <option>08:00~09:00</option>
                        <option>16:00~17:00</option>
                    </select>
                    <span class="Validform_checktip">*必填</span>
                </dd>
            </dl>--%>
            <dl>
                <dt>计价方式</dt>
                <dd>
                   <input type="radio" id="rdoj" name="rdoSelect" value="0" onclick="change(this)"/>按件数
                    <input type="radio"id="rdoW" name="rdoSelect" checked="checked" onclick="change(this)" value="1"/>按重量
                </dd>
            </dl>
             <dl>
                <dt>运送方式</dt>
                <dd>除指定地区外，其他地区的运费采用“默认运费”
                  
                </dd>
            </dl>
             <div class="tdh_1_1">
                 <div class="tdh_1">         
                  默认运费:<input type="text" id="txt默认kg" /><span id="cgTitle1">kg内</span>,<input type="text" id="txt默认元" />元，每增加<input type="text" id="txt增加kg" /><span id="cgTitle2">kg</span>,增加<input type="text" id="txt增加元" />元。运送方式: <input type="checkbox" class="ckb" value="平邮" id="ck平邮"/>平邮
                    <input type="checkbox" class="ckb" value="快递" id="ck快递"/>快递
                    <input type="checkbox" class="ckb" value="EMS" id="ckEMS"/>EMS</div>    
                 <input type="button" id="btnAddNewRow" class="btn btn_pb" value="新增" onclick="Addnewrow()"/> <br />                
                 <table id="tabId" class="ltable">
                     <thead>
                        <tr>
                            <th>运送到</th><th id="changeTitle1">首重(kg)</th><th>首费(元)</th><th id="changeTitle2">续重(kg)</th><th>续费(元)</th><th>运送方式</th><th>操作</th>
                        </tr>
                     </thead>
                     <tbody>
                         <tr>
                             <td id="td_1"><a href="javascript:;"  onclick="add(this)">编辑</a><input type="text" value="" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="checkbox" value="平邮"/>平邮<input type="checkbox" value="快递"/>快递<input type="checkbox" value="EMS"/>EMS</td><td><a href="javascript:;" onclick="del(this)">删除</a> </td>
                         </tr>
                          <tr>
                             <td id="td_2"><a href="javascript:;" onclick="add(this)">编辑</a><input type="text" value="" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="checkbox" value="平邮"/>平邮<input type="checkbox" value="快递"/>快递<input type="checkbox" value="EMS"/>EMS</td><td><a href="javascript:;" onclick="del(this)">删除</a> </td>
                         </tr>
                          <tr>
                             <td id="td_3"><a href="javascript:;"  onclick="add(this)">编辑</a><input type="text" value=""/></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="text" value="1" /></td><td><input type="checkbox" value="平邮"/>平邮<input type="checkbox" value="快递"/>快递<input type="checkbox" value="EMS"/>EMS</td><td><a href="javascript:;" onclick="del(this)">删除</a> </td>
                         </tr>
                     </tbody>
                 </table>
             </div>
        </div>
        <div id="areaSelect" style="display:none">
            <dl>
                <dd>
            <input type="checkbox" value="华东" onclick="chkAll(this)" />华东  <input type="checkbox" class="ck" value="上海" />上海 <input type="checkbox" class="ck"  value="江苏" />江苏 <input type="checkbox" class="ck"  value="浙江" />浙江 <input type="checkbox" class="ck"  value="安徽" />安徽 <input type="checkbox" class="ck"  value="江西" />江西
                    </dd>
                <dd>
            <input type="checkbox" value="华北" onclick="chkAll(this)" />华北  <input type="checkbox" class="ck"  value="北京" />北京 <input type="checkbox" class="ck"  value="天津" />天津 <input type="checkbox" class="ck"  value="山西" />山西 <input type="checkbox" class="ck"  value="山东" />山东 <input type="checkbox" class="ck"  value="河北" />河北
                                                    <input type="checkbox" value="内蒙古"  class="ck" />内蒙古
                    </dd>
                <dd>
            <input type="checkbox" value="华中" onclick="chkAll(this)"/>华中  <input type="checkbox" class="ck"  value="湖南" />湖南 <input type="checkbox" class="ck"  value="湖北" />湖北 <input type="checkbox" class="ck"  value="河南" />河南
                    </dd>
                <dd>
            <input type="checkbox" value="华南" onclick="chkAll(this)"/>华南  <input type="checkbox"  class="ck" value="广东" />广东 <input type="checkbox" class="ck"  value="广西" />广西 <input type="checkbox" class="ck"  value="福建" />福建 <input type="checkbox" class="ck"  value="海南" />海南
                    </dd>
                <dd>
            <input type="checkbox" value="东北" onclick="chkAll(this)" />东北  <input type="checkbox" class="ck"  value="辽宁" />辽宁 <input type="checkbox" class="ck"  value="吉林" />吉林 <input type="checkbox" class="ck"  value="黑龙江" />黑龙江
                    </dd>
                <dd>
            <input type="checkbox" value="西北" onclick="chkAll(this)"/>西北  <input type="checkbox" class="ck"  value="陕西" />陕西 <input type="checkbox" class="ck"  value="新疆" />新疆 <input type="checkbox" class="ck"  value="甘肃" />甘肃 <input type="checkbox" class="ck"  value="宁夏" />宁夏<input type="checkbox" class="ck"  value="青海" />青海
                    </dd>
                <dd>
            <input type="checkbox" value="西南" onclick="chkAll(this)"/>西南  <input type="checkbox" class="ck"  value="重庆" />重庆 <input type="checkbox" class="ck"  value="云南" />云南 <input type="checkbox" class="ck"  value="贵州" />贵州  <input type="checkbox" class="ck"  value="西藏" />西藏<input type="checkbox" class="ck"  value="四川" />四川
                    </dd>
                <dd>
            <input type="checkbox" value="港澳台" onclick="chkAll(this)"/>港澳台 <input type="checkbox" class="ck"  value="香港" />香港 <input type="checkbox" class="ck"  value="澳门" />澳门<input type="checkbox" class="ck"  value="台湾" />台湾 
                    </dd>
                <dd>
            <input type="checkbox" value="海外" onclick="chkAll(this)" />海外 <input type="checkbox" class="ck"  value="海外" />海外
                    </dd>
           </dl>
            <input type="button" id="btnSure" class="btn" value="确定" />  
        </div>
        <!--/内容-->
        <!--工具栏-->
        <br />
        <div class="page-footer">
            <div class="btn-list">
               <%-- <asp:Button ID="Button2" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />--%>
                <input type="button" id="btnAjax" value="提交保存" class="btn" onclick="AjaxAdd()" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear">
            </div>
        </div>
        <!--/工具栏-->
    </form>
</body>
</html>
