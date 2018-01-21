<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siteconfig.aspx.cs" Inherits="tdx.installer.install.siteconfig" %>

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
		    <li  class="finish"><span>数据库配置</span></li>
		    <li  class="cur"><span>网站配置</span></li>
		    <li ><span>安装</span></li>
        </ul>
	</div>
    
	<div class="main cl">
		<h1>网站配置</h1>
		<div class="inner">
			<form id="forumset" action="" method="post">
				<table width="100%" cellspacing="0" cellpadding="0" summary="网站配置">
				<tbody>
					<tr>
						<td class="title">管理员名称:</td><td><input id="adminname" name="adminname" class="txt" type="text"/></td>
					</tr>
					<tr>
						<td class="title">管理员密码:</td><td><input id="adminpassword" name="adminpassword" class="txt" type="password"/></td>
					</tr>
					<tr>
						<td class="title">管理员密码确认:</td><td><input id="confirmpassword" name="confirmpassword" class="txt" type="password"/></td>
					</tr>
				</tbody>
				</table>
			</form>
		</div>
	</div>
	<div class="btn cl">
		<a href="javascript:history.back();" class="back">上一步</a>
		<a href="###" onclick="checkforumset();" class="next">下一步</a>		
	</div>
    <script type="text/javascript">
        function checkforumset() {
            var adminname = $('#adminname').val();
            var adminpassword = $('#adminpassword').val();
            var confirmpassword = $('#confirmpassword').val();

            if (adminname == "") {
                Boxy.alert('管理员名称不能为空', false, { width: 400 });
                return;
            }
            if (adminpassword == "") {
                Boxy.alert('管理员密码不能为空', false, { width: 400 });
                return;
            }
            if (adminpassword != confirmpassword) {
                Boxy.alert('两次输入的密码不一致', false, { width: 400 });
                return;
            }

            $('#forumset').attr("action", "installer.aspx?user=" + adminname + "&pwd=" + adminpassword);
            $('#forumset').submit();
        }
    </script>
    
	<div class="copy">
		无锡实创科技有限责任公司 &copy; 2001 - 2014 CHINA-MAIL.COM.CN. 
	</div>
</div>
</body>
</html>
