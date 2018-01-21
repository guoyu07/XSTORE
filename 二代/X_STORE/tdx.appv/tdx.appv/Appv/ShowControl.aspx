<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowControl.aspx.cs" Inherits="tdx.appv.ShowControl" %>

<%@ Register Src="appv_head.ascx" TagPrefix="uc" TagName="appHeader" %>
<%@ Register Src="appv_foot.ascx" TagPrefix="uc" TagName="appFooter" %>
<!DOCTYPE html public "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="lt_title" runat="server"></asp:Literal></title>
    <asp:Literal ID='lt_keywords' runat='server'></asp:Literal>
    <asp:Literal ID='lt_description' runat='server'></asp:Literal>
    <%--<link href="images/black/Apps_main.css" rel="stylesheet" type="text/css" />--%>
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <asp:Literal ID='lt_theme' runat='server'></asp:Literal>

    <script language="javascript" src="/Appv/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="/Appv/js/fsWeixin_apps.js" type="text/javascript"
        charset="utf-8"></script>
    <script language="javascript" src="/Appv/js/swipe.js" charset="utf-8"></script>

    <style type="text/css">
        
    </style>
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
            var i = 0;
            $('body').on('click', '#btn_save', function () {
                var num = 0;
                $("input[type$='text']").each(function (n) {
                    if ($(this).val() == "") {
                        num++;
                    }
                });
                if (num > 0) {
                    alert("必填项不能为空!");
                    return false;
                }
              /* var $cr = $("#isRead");
                if ($cr.is(":checked")) { //jQuery方式判断
                } else {
                    alert("请阅读隐私协议!");
                    return false;
                }
                */
            })
            // return true;

            //                var sort = $('input[name="t_sort"]').val();
            //                if (isNullOrEmpty($('input[name="title"]').val())) {
            //                    //如果为空则
            //                    alert("字段名称不能为空");
            //                    return;
            //                }
            //                if (isNullOrEmpty($('input[name="t_sort"]').val())) {
            //                    //如果为空则
            //                    alert("排序不能为空");
            //                    return;
            //                }
            //                var type = $('#select_type').val();
            //                var valuees = $('textarea[name="setting[options]"]').val();
            //                var valueDe = $('input[name="setting[defaultvalue]"]').val();
            //                if (isNullOrEmpty(valueDe)) {
            //                    valueDe = "dd";
            //                }
            //                if (isNullOrEmpty(valuees)) {
            //                    valuees = "ddS";
            //                }
            //                var isEd = $("#isE").val();
            //                var iswid = $("#wid").val();
            //                // alert(type);
            //                $.post('controlSave.ashx', { name: titlename, sort: sort, isedit: isEd, wid: iswid, type: type, values: valuees, valuedf: valueDe }, function (data) {
            //                    alert(data);
            //                    location.href = 'controlsList.aspx?WWX=gh_9237d94886cf';
            //                })
            //            });

        })
    

    </script>
</head>
<body class="body">
    <uc:appHeader ID="appHeader1" runat="server" EnableViewState="False"></uc:appHeader>
    <div class="d_body">
        <div class="d_content">
    <div>
        <h5 class="biaoti">
            <asp:Literal ID="miaoshu" runat="server"></asp:Literal></h5>
    </div>
    <form id="form1" runat="server">
    <div class="controlName" id="controlName">
        <asp:HiddenField ID="wid" runat="server" />
        <asp:HiddenField ID="uid" runat="server" />
        <asp:Literal ID="resultStr" runat="server"></asp:Literal>
        <br />
        <%--<div class="yinsi">
            <span>
                <input type="checkbox" checked="checked" runat="server" id="isRead" /><label id="YueDu" runat="server" for="isRead">我已阅读了保时捷的<a
                    href="#">隐私政策</a></label>
            </span>
        </div>--%>
    </div>
    <div>
        <input type="submit" onserverclick="SaveButton" runat="Server" id="btn_save" class="btn3_mouseup"
            value="  提 交 " />
    </div>
    </form>
    </div>
    </div>
    <uc:appFooter ID="appFooter1" runat="server" EnableViewState="False"></uc:appFooter>
</body>
</html>
