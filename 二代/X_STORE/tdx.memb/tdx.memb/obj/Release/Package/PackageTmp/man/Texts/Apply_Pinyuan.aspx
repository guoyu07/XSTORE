<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply_Pinyuan.aspx.cs" Inherits="tdx.memb.man.Texts.Apply_Pinyuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/man/images4/nei.css" type="text/css" rel="stylesheet" />
    <title>后台管理</title>
    <script src="/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var pageSize = 30;
        window.onload = function () {
            changeCurrentPage(1)
            requestPage(1, pageSize);

            document.getElementById("getAllRows").onclick = function () {
                if (document.getElementById("getAllRows").checked) {
                    $(".delFlag").prop("checked", true);
                }
                else {
                    $(".delFlag").prop("checked", false);
                }
            };

            document.getElementById("delRows").onclick = function () {
                var rows = "";
                $(".delFlag").each(function () {
                    if ($(this).prop("checked")) {
                        rows += $(this).val() + "|";
                    }
                });
                rows = rows.substr(0, rows.length - 1);
                if (rows.length > 0) {
                    DelRows(rows);
                }
                else {
                    alert("请选中要删除的行!");
                }
            };

        };
        //删除行
        function DelRows(rows) {
            document.getElementById("delRows").disabled = true;
            $.ajax({
                type: "get",
                url: "Apply_actions.ashx",
                data: { "type": "del", "rows": rows },
                dataType: "json",
                error: function () {
                    document.getElementById("delRows").disabled = false;
                    alert("操作失败");
                },
                success: function (data) {
                    if (data.status == "ok") {
                        refreshCurrentPage();
                    } else if (data.status == "no") {
                        alert(data.msg);
                    }
                },
                complete: function () {
                    document.getElementById("delRows").disabled = false;
                }
            });
        }
        //请求页数据
        function requestPage(pa, ps) {
            $.ajax({
                type: "get",
                url: "Apply_actions.ashx",
                data: { "type": "first", "page": pa, "pagesize": ps },
                dataType: "json",
                success: function (data) {
                    if (data != null) {
                        makeTable(data.array);
                        setPageCount(data.pages);
                        if (parseInt(document.getElementById("currentPage").innerText) > data.pages) {
                            changeCurrentPage(data.pages);
                        }
                    }
                }
            });
        }
        function jumpToPage() {
            var page = document.getElementById("pagejump").value;
            if (/^[1-9]\d*$/.test(page)) {
                clearTable();
                requestPage(page, pageSize);
                changeCurrentPage(page);
            }
            else {
                alert("请输入正确的页码");
            }
        }
        function makeTable(jsonArr) {
            for (var i = 0; i < jsonArr.length; i++) {
                makeTr(jsonArr[i]);
            }
        }
        function makeTr(rowData) {
            var tbList = document.getElementById("userInfor");
            var newRow = tbList.insertRow(-1); //追加行
            newRow.insertCell(-1).innerHTML = "<input type=\"checkbox\" class=\"delFlag\" value = \"" + rowData.id + "\" />";
            newRow.insertCell(-1).innerHTML = rowData.company;
            newRow.insertCell(-1).innerHTML = rowData.address;
            newRow.insertCell(-1).innerHTML = rowData.range;
            newRow.insertCell(-1).innerHTML = rowData.contact;
            newRow.insertCell(-1).innerHTML = rowData.phone;
            newRow.insertCell(-1).innerHTML = rowData.mail;
            newRow.insertCell(-1).innerHTML = rowData.qq;
            newRow.insertCell(-1).innerHTML = rowData.trademark;
            newRow.insertCell(-1).innerHTML = rowData.patent;
            newRow.insertCell(-1).innerHTML = rowData.regTime;
            
        }

        

        function changeCurrentPage(page) {
            document.getElementById("currentPage").innerText = page;
        }
        //刷新当前页
        function refreshCurrentPage() {
            var curPage = document.getElementById("currentPage").innerText;
            var page = parseInt(curPage);
            clearTable();
            requestPage(page, pageSize);
        }

        //上一页
        function prePage() {
            var curPage = document.getElementById("currentPage").innerText;
            var page = parseInt(curPage) - 1;
            if (page < 1) {
                //page = 1;
                return;
            }
            clearTable();
            requestPage(page, pageSize);
            changeCurrentPage(page);
        }
        //下一页
        function nextPage() {
            var curPage = document.getElementById("currentPage").innerText;
            var page = parseInt(curPage) + 1;
            var pageCount = parseInt(document.getElementById("pageCount").innerText);
            if (page > pageCount) {
                //page = pageCount;
                return;
            }
            clearTable();
            requestPage(page, pageSize);
            changeCurrentPage(page);
        }
        //清空表
        function clearTable() {
            var tb = document.getElementById("userInfor");
            var rowCount = tb.rows.length;
            for (var i = rowCount - 1; i > 0; i--) {
                tb.deleteRow(i);
            }
        }
        function setPageCount(pages) {
            document.getElementById("pageCount").innerText = pages;
        }
        
    </script>
</head>
<body>
    <!--中间开始-->
    <form id="form1" runat="server">
    <h1><strong>留言列表</strong></h1>
    <div class="nei_content">
        <!--center content-->
        <input type="button" id="delRows" value="彻底删除" />
        <table id="userInfor" width="100%" border="1" cellspacing="0" cellpadding="5">
            <tr><th><input type="checkbox" id="getAllRows" /></th><th>企业名称</th><th>联系地址</th><th>企业经营范围</th><th>联系人</th><th>手机号</th><th>邮箱</th><th>QQ号</th><th>意向商标</th><th>专利方向</th><th>申请时间</th></tr>
        </table>
        <div  class="page">
           <a id="prev" href="javascript:void(0)" onclick="prePage()">上一页</a>
           <span id="currentPage"></span>
           <a id="next" href="javascript:void(0)" onclick="nextPage()">下一页</a>
           共<span id="pageCount">1</span>页
           <input value="1" id="pagejump" onkeydown="if(window.event.keyCode == 13){jumpToPage();}" />
           <input value="GO" id="jumpto" type="button" onclick="jumpToPage()" />
        </div>
        <!--center content end-->
    </div>
    </form>
    <!--中间结束-->
</body>
</html>
