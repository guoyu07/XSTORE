<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="installer.aspx.cs" Inherits="tdx.installer.install.installer" %>

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
		    <li  class="finish"><span>数据库配置</span></li>
		    <li  class="finish"><span>网站配置</span></li>
		    <li  class="cur"><span>安装</span></li>
        </ul>
	</div>
    
    <div class="main cl">
		<h1>安装</h1>
		<div class="inner">
			<ul id="processlist" class="list">
            </ul>
		</div>
        <input type="hidden" id="adminname" name="adminname" value="<%=user %>" />
        <input type="hidden" id="adminpassword" name="adminpassword" value="<%=pwd %>" />

	</div>
	<div class="btn cl">
		<a href="###" class="back">上一步</a>
		<a id="successlink" href="###" class="back">完成</a>
	</div>
    <script type="text/javascript">
        var adminname = $('#adminname').val();
        var adminpassword = $('#adminpassword').val();

        var runstep = 0;
        var steptime = 500;
        function runinstall() {
            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>资源准备中......</li>');

            if (adminname == "" || adminpassword == "") {
                $('#processlist').append('<li><img alt="失败" src="images/error.gif"/>管理员帐号数据异常,安装失败......</li>');
                return;
            }
            createTable();
        }

        function createTable() {
            $.ajax({
                type: "get",
                url: "ajax.ashx",
                data: { 't': 'createtable', 'time': Math.random() },
                dataType: "json",
                success: function (data) {
                    var callback = data;
                    if (callback.result=="ok") {
                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>数据表创建成功......</li>');
                        }, ++runstep * steptime);
//                        createSP();
                        initSource()
                    }
                    else {
                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="失败" src="images/error.gif"/>内部异常,数据表创建失败......</li>');
                        }, ++runstep * steptime);
                    }
                }
            });
//            jQuery.get('ajax.aspx', { 't': 'createtable', 'time': Math.random() },
//                function (data) {
//                    var callback = eval("(" + data + ")");
//                    if (callback.result) {
//                        setTimeout(function on() {
//                            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>数据表,约束和索引创建成功......</li>');
//                        }, ++runstep * steptime);
//                        createSP();
//                    }
//                    else {
//                        setTimeout(function on() {
//                            $('#processlist').append('<li><img alt="失败" src="images/error.gif"/>内部异常,数据表创建失败......</li>');
//                        }, ++runstep * steptime);
//                    }
//                }
//            );

        }

        function createSP() {
            jQuery.get('ajax.aspx', { 't': 'createsp', 'time': Math.random() },
                function (data) {
                    var callback = eval("(" + data + ")");
                    if (callback.result) {
                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>选择创建SqlServer ' + callback.message + ' 版本存储过程......</li>');
                        }, ++runstep * steptime);

                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>存储过程创建成功......</li>');
                        }, ++runstep * steptime);

                        initSource();
                    }
                    else {
                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="失败" src="images/error.gif"/>内部异常,存储过程创建失败......</li>');
                        }, ++runstep * steptime);
                    }
                }
            );
        }

        function initSource() {

            $.ajax({
                type: "get",
                url: "ajax.ashx",
                data: { 't': 'initsource', 'admin': adminname, 'pwd': adminpassword, 'time': Math.random() },
                dataType: "json",
                success: function (data) {
                    var callback = data;
                    if (callback.result=="ok") {
                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>初始数据添加成功......</li>');
                        }, ++runstep * steptime);
                        showSuccessLink();
                    }
                    else {
                        setTimeout(function on() {
                            $('#processlist').append('<li><img alt="失败" src="images/error.gif"/>内部异常,' + callback.message + ',请检查......</li>');
                        }, ++runstep * steptime);
                    }
                }
            });

//            jQuery.get('ajax.aspx', { 't': 'initsource', 'admin': adminname, 'pwd': adminpassword, 'time': Math.random() },
//                function (data) {
//                    var callback = eval("(" + data + ")");
//                    if (callback.result) {
//                        setTimeout(function on() {
//                            $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>初始数据添加成功......</li>');
//                        }, ++runstep * steptime);
//                        showSuccessLink();
//                    }
//                    else {
//                        setTimeout(function on() {
//                            $('#processlist').append('<li><img alt="失败" src="images/error.gif"/>内部异常,' + callback.message + ',请检查......</li>');
//                        }, ++runstep * steptime);
//                    }
//                }
//            );
        }

        function showSuccessLink() {
            setTimeout(function on() {
                $('#successlink').attr('class', 'next');
                $('#successlink').attr('href', '../man/index.aspx');
                $('#processlist').append('<li><img alt="成功" src="images/ok.gif"/>安装成功,点击"完成"进入首页......</li>');
            }, ++runstep * steptime);
        }

        runinstall();
    </script>
    
	<div class="copy">
		无锡实创科技有限责任公司 &copy; 2001 - 2014 CHINA-MAIL.COM.CN. 
	</div>
</div>
</body>
</html>
