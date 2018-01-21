<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbconfig.aspx.cs" Inherits="tdx.installer.install.dbconfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无锡实创科技安装</title>
    <meta name="keywords" content="无锡实创科技安装" />
    <meta name="description" content="无锡实创科技安装" />
    <meta name="generator" content="无锡实创科技 1.0.1" />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link rel="icon" href="favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" href="main.css" type="text/css" media="all" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <link rel="stylesheet" href="js/jquery_boxy/css/common.css" type="text/css" />
    <link rel="stylesheet" href="js/jquery_boxy/css/boxy.css" type="text/css" />
    <script type="text/javascript" src="js/jquery_boxy/js/jquery.boxy.js"></script>
</head>
<body>
<div class="wrap cl">
	<h2><img alt="无锡实创科技" src="images/logo.png" /><cite><b>1.0.1</b>安装程序</cite></h2>
	<div class="nav">
        <ul>
		    <li  class="finish"><span id="index">欢迎</span></li>
		    <%--<li  class="finish"><span>环境检测</span></li>--%>
		    <li  class="cur"><span>数据库配置</span></li>
		    <li ><span>网站配置</span></li>
		    <li ><span>安装</span></li>
        </ul>
	</div>
    
    <div class="main cl">
		<h1>数据库配置</h1>
		<div class="inner">
			<form action="" method="post">
			    <table width="100%" cellspacing="0" cellpadding="0" summary="数据库配置">
			        <tbody>
			            <tr>
				            <td class="title">数据库地址:</td><td><input id="sql_ip" name="sql_ip" class="txt" type="text" value="112.213.99.142,2012"/></td>
			            </tr>
			            <tr>
				            <td class="title">数据库名称:</td><td><input id="sql_name" name="sql_name" class="txt" type="text" value="dxxj"/></td> <%--<span>填写不存在的数据库名称会尝试自动创建</span>--%>
			            </tr>
			            <tr>
				            <td class="title">数据库用户名:</td><td><input id="sql_username" name="sql_username" class="txt" type="text" value="dxxj"/></td>
			            </tr>
			            <tr>
				            <td class="title">数据库密码:</td><td><input id="sql_password" name="sql_password" class="txt" type="password" value="dx123xj"/></td>
			            </tr>
			            <%--<tr>
				            <td class="title">表前辍:</td><td><input id="table_prefix" name="table_prefix" class="txt" type="text" value="dnt_"/></td>
			            </tr>--%>
                    </tbody>
			    </table>
			</form>
		</div>
	</div>
	<div class="btn cl">
		<a href="javascript:history.back();" class="back">上一步</a>
		<a href="###" onclick="checkDbset();" class="next">下一步</a>		
	</div>
    <script type="text/javascript">
        var showbox;
        var alerthead = "<p style=\"width:300px;font-size:14px;\"><img src=\"../images/common/loading.gif\" alt=\"loading\" />";
        var createdDb = 0;
        var runstep = 0;
        var steptime = 700;

        function checkDbset() {
            var sqlip = $('#sql_ip').val();
            var sqlname = $('#sql_name').val();
            var loginname = $('#sql_username').val();
            var password = $('#sql_password').val();
//            var tableprefix = $('#table_prefix').val();

            if (sqlip == "") {
                Boxy.alert('数据库地址不能为空', false, { width: 400 });
                return;
            }
            if (sqlname == "") {
                Boxy.alert('数据库名称不能为空', false, { width: 400 });
                return;
            }
            if (loginname == "") {
                Boxy.alert('数据库登录名不能为空', false, { width: 400 });
                return;
            }
            if (password == "") {
                Boxy.alert('数据库登录密码不能为空', false, { width: 400 });
                return;
            }
//            if (tableprefix == "") {
//                Boxy.alert('表前缀不能为空', false, { width: 400 });
//                return;
//            }

            showbox = new Boxy(alerthead + "正在检测数据库连接,该检测可能比较耗时,请耐心等待......</p>", { closeable: false, modal: true, center: true });

            checkDbAjax(sqlip, sqlname, loginname, password); //, tableprefix
        }

        function checkDbAjax(sqlip, sqlname, loginname, password) {//, tableprefix
            showbox.setContent(alerthead + "正在检测数据库连接,该检测可能比较耗时,请耐心等待......</p>");
            showbox.show();

            $.ajax({
                type: "get",
                url: "ajax.ashx",
                data: { 't': 'checkdbconnection', 'ip': sqlip, 'name': sqlname, 'loginname': loginname, 'loginpwd': password, 'time': Math.random() },
                dataType: "json",
                success: function (data) {
                    var callback = data;
                    if (callback.result == "no") {
                        if (callback.code == "4060") {
                            showbox.hide();
                            //                            Boxy.confirm("您填写的数据库\"" + sqlname + "\"不存在,是否尝试在数据库自动创建该名称的数据库?",
                            //                                function on() {
                            //                                    runstep = 0;
                            //                                    createDbAjax(sqlip, sqlname, loginname, password, tableprefix);
                            //                                }, { title: "是否创建数据库" });
                            Boxy.alert("您填写的数据库\"" + sqlname + "\"不存在,或用户名密码有误", null, { width: 400 });
                        }
                        else if (callback.code == "53") {
                            //                            setTimeout(function on() {
                            //                                showbox.hide();
                            //                                Boxy.alert("数据库连接超时,请检查数据库地址是否正确", null, { width: 400 });
                            //                                runstep = 0;
                            //                            }, ++runstep * steptime);
                        }
                        else {
                            setTimeout(function on() {
                                showbox.hide();
                                Boxy.alert(callback.message, null, { width: 400 });
                                runstep = 0;
                            }, ++runstep * steptime);
                        }
                    } else {
                        setTimeout(function on() {
                            //checkDBCollation(sqlip, sqlname, loginname, password, tableprefix);
                            DBSourceExist(sqlip, sqlname, loginname, password); //, tableprefix
                        }, ++runstep * steptime);
                    }
                },
                error: function (data) {
                    showbox.hide();
                    Boxy.alert("您填写的数据库\"" + sqlname + "\"不存在,或用户名密码有误", null, { width: 400 });
                }
            });

//            jQuery.get('ajax.aspx', { 't': 'checkdbconnection', 'ip': sqlip, 'name': sqlname, 'loginname': loginname, 'loginpwd': password, 'time': Math.random() },
//            function (data) {
//                var callback = eval("(" + data + ")");
//                var callback = data;
//                if (!callback.result) {
//                    if (createdDb == 0 && callback.code == "4060") {
//                        showbox.hide();
//                        Boxy.confirm("您填写的数据库\"" + sqlname + "\"不存在,是否尝试在数据库自动创建该名称的数据库?",
//                        function on() {
//                            runstep = 0;
//                            createDbAjax(sqlip, sqlname, loginname, password, tableprefix);
//                        }, { title: "是否创建数据库" });
//                    }
//                    else if (callback.code == "53") {
//                        setTimeout(function on() {
//                            showbox.hide();
//                            Boxy.alert("数据库连接超时,请检查数据库地址是否正确", null, { width: 400 });
//                            runstep = 0;
//                        }, ++runstep * steptime);
//                    }
//                    else {
//                        setTimeout(function on() {
//                            showbox.hide();
//                            Boxy.alert(callback.message, null, { width: 400 });
//                            runstep = 0;
//                        }, ++runstep * steptime);
//                    }
//                } else {
//                    setTimeout(function on() {
//                        checkDBCollation(sqlip, sqlname, loginname, password, tableprefix);
//                    }, ++runstep * steptime);
//                }
//            });
        }

        function DBSourceExist(sqlip, sqlname, loginname, password) { //, tableprefix
            showbox.show();
            showbox.setContent(alerthead + "正在检测数据库已有数据......</p>");

            $.ajax({
                type: "get",
                url: "ajax.ashx",
                data: { 't': 'dbsourceexist', 'ip': sqlip, 'name': sqlname, 'loginname': loginname, 'loginpwd': password, 'time': Math.random() }, //, 'prefix': tableprefix
                dataType: "json",
                success: function (data) {
                    var callback = data;
                    if (callback.result == "ok") {
                        showbox.hide();
                        runstep = 0;
                        Boxy.confirm('系统检测到数据库"' + sqlname + '"已经包含系统所需的数据表,继续安装会清空之前数据,是否继续?',
                        function on() {
                            saveDbSet(sqlip, sqlname, loginname, password); //, tableprefix
                        }
                        , { title: "是否继续安装?" });
                    }
                    else {
                        saveDbSet(sqlip, sqlname, loginname, password); //, tableprefix
                    }
                }
            });
                
        }

        function checkDBCollation(sqlip, sqlname, loginname, password) { //, tableprefix
            showbox.show();
            showbox.setContent(alerthead + "正在检测数据库排序规则......</p>");
            jQuery.get('ajax.aspx', { 't': 'checkdbcollation', 'ip': sqlip, 'name': sqlname, 'loginname': loginname, 'loginpwd': password, 'time': Math.random() },
                function (data) {
                    var callback = eval("(" + data + ")");
                    if (callback.result=="ok") {
                        setTimeout(function on() {
                            DBSourceExist(sqlip, sqlname, loginname, password); //, tableprefix
                        }, ++runstep * steptime);
                    }
                    else {
                        showbox.hide();
                        Boxy.alert(callback.message, null, { width: 400 });
                        runstep = 0;
                    }
                });
        }

        function createDbAjax(sqlip, sqlname, loginname, password) { //, tableprefix
            showbox.show();
            showbox.setContent(alerthead + "正在创建数据库......</p>");
            jQuery.get('ajax.aspx', { 't': 'createdb', 'ip': sqlip, 'name': sqlname, 'loginname': loginname, 'loginpwd': password, 'time': Math.random() },
                function (data) {
                    var callback = eval("(" + data + ")");
                    if (callback.result=="ok") {
                        createdDb = 1;
                        setTimeout(function on() {
                            checkDbAjax(sqlip, sqlname, loginname, password); //, tableprefix
                        }, ++runstep * steptime);
                    } else if (callback.code = "262") {
                        createdDb = 0;
                        setTimeout(function on() {
                            showbox.hide();
                            Boxy.alert('数据库用户 \'' + loginname + '\' 没有创建数据库的权限,创建新数据库失败,请填写已有的数据库 ', null, { width: 400 });
                            runstep = 0;
                        }, ++runstep * steptime);
                    } else {
                        createdDb = 0;
                        setTimeout(function on() {
                            showbox.hide();
                            Boxy.alert(callback.message, null, { width: 400 });
                            runstep = 0;
                        }, ++runstep * steptime);
                    }
                }
            );
        }

        function saveDbSet(sqlip, sqlname, loginname, password) { //, tableprefix
            showbox.show();
            showbox.setContent(alerthead + "正在保存数据库配置......</p>");
            $.ajax({
                type: "get",
                url: "ajax.ashx",
                data: { 't': 'savedbset', 'ip': sqlip, 'name': sqlname, 'loginname': loginname, 'loginpwd': password, 'time': Math.random() }, //, 'prefix': tableprefix
                dataType: "json",
                success: function (data) {
                    var callback = data;
                    if (callback.result == "ok") {
                        setTimeout(function on() {
                            showbox.hide();
                            Boxy.alert(callback.message, function on() { window.location = 'siteconfig.aspx'; }, { width: 400 });
                            runstep = 0;
                        }, ++runstep * steptime);
                    }
                }
            });
        }

    </script>
    
	<div class="copy">
		无锡实创科技有限责任公司 &copy; 2001 - 2014 CHINA-MAIL.COM.CN. 
	</div>
</div>
</body>
</html>
