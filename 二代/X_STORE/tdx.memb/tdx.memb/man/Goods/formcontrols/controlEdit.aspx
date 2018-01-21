<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlEdit.aspx.cs" Inherits="tdx.memb.man.formcontrols.controlEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>实创科技后台管理系统</title>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js" charset="utf-8"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../../js/tdx_member.js" type="text/javascript"></script>
    <link href="../images4/nei.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="wid" runat="server" />
    <asp:HiddenField ID="isE" runat="server" />
    <h1>
        <strong>字段管理</strong></h1>
    <div id="nei_content" class="nei_content">
        <div class="tsxx">
            <img class="tsxx_1" src="/memb/images4/ts.png">
            <span class="tsxx_2">
                <asp:Literal ID="lt_result" runat="server"></asp:Literal></span>
            <img class="tsxx_3" src="/memb/images4/xx.png">
        </div>
        <table class="enter_table">
            <tbody>
                <tr>
                    <td class="enter_title">
                        字段类型
                    </td>
                    <td class="enter_content">
                        <select name="rankid" runat="server" id="select_type" enableviewstate="false" class="select-field">
                        </select>
                        <br />
                        <span class="gray">字段类型保存后不能修改</span><br />
                    </td>
                    <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        字段名称
                    </td>
                    <td class="enter_content">
                        <input name="title" id="name" placeholder="请输入表单字段名称如:姓名" class="px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        排序
                    </td>
                    <td class="enter_content">
                        <input name="t_sort" id="sort" placeholder="99" class="px" type="text" />
                    </td>
                     <td class="rb">
                        *
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                        相关参数设置
                    </td>
                    <td class="enter_content">
                        <div id="setting">
                        </div>
                        <%-- <textarea id="des" runat="server" style="height: 70px;" class="px" cols="20" rows="2"></textarea>--%>
                        <%--<input name="t_sort" style="height:70px;" id="Text3" value="" class="px" type="text"/>--%>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="enter_title">
                    </td>
                    <td class="enter_content">
                        <input name="btn_save" runat="server" id="btn_save" value=" 保 存 " class="btnGreen"
                            type="button" />
                    </td>
                    <%--onserverclick="btn_save_ServerClick"--%>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
    <script type="text/javascript">

        $(function () {

            function trim(str) { //删除左右两端的空格 
                return str.replace(/(^\s*)|(\s*$)/g, "");
            }
            function ltrim(str) { //删除左边的空格 
                return str.replace(/(^\s*)/g, "");
            }
            function rtrim(str) { //删除右边的空格 
                return str.replace(/(\s*$)/g, "");
            }
            function isNullOrEmpty(strVal) {

                if (strVal == '' || strVal == null || strVal == undefined) {
                    return true;

                } else {

                    return false;

                }

            }
            $('body').on('change', '#select_type', function () {

                $('input[name="title"]').val('表单名称');
                var type = $(this).val();
                // alert(type);
                $.post('controlItem.ashx', { type: type }, function (data) {
                    $('#setting').html(data);
                })
            });
            $('body').on('click', '#btn_save', function () {

                var titlename = $('input[name="title"]').val();
                var sort = $('input[name="t_sort"]').val();
                if (isNullOrEmpty($('input[name="title"]').val())) {
                    //如果为空则
                    alert("字段名称不能为空");
                    return;
                }
                if (isNullOrEmpty($('input[name="t_sort"]').val())) {
                    //如果为空则
                    alert("排序不能为空");
                    return;
                }
                var type = $('#select_type').val();
                var valuees = $('textarea[name="setting[options]"]').val();
                var valueDe = $('input[name="setting[defaultvalue]"]').val();
                if (isNullOrEmpty(valueDe)) {
                    valueDe = "dd";
                }
                if (isNullOrEmpty(valuees)) {
                    valuees = "请输入文本";
                }
                var isEd = $("#isE").val();
                var iswid = $("#wid").val();
                // alert(type);
                $.post('controlSave.ashx', { name: titlename, sort: sort, isedit: isEd, wid: iswid, type: type, values: valuees, valuedf: valueDe }, function (data) {
                    alert(data);
                    location.href = 'controlsList.aspx?id=' + iswid + '';
                })
            });

        })
    

    </script>
</body>
</html>

