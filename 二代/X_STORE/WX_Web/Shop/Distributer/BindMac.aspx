<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindMac.aspx.cs" Inherits="Wx_NewWeb.Shop.Distributer.BindMac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1, user-scalable=no">
	<meta charset="UTF-8">
		<title>幸事多-房间配置</title>
		<link rel="icon" href="img/logo.png" type="image/x-icon"/>
		<link rel="stylesheet" href="../css/mui.min.css" />
		<style>
			html body .info {
          width: 100%;
          padding: 3%; }
          html body .info .infoWrapper {
            background: #fff;
            border: solid 1px #ccc;
            border-radius: 2px;
            padding: 3%;
            width: 100%; }
            html body.info .infoWrapper p {
              width: 100%;
              word-wrap: break-word;
              word-break: normal;
              font: 14px/20px "microsoft yahei";
              color: #999999;
              margin:0; }
            html body .info .infoWrapper .topic {
              font: 16px/20px "microsoft yahei";
              color: #FF6600; }
            ul{
            	list-style: none;
            	width:100%;
            	padding:0;
            	margin:0;
            }
            li{
            	width:25%;
            	text-align: center;
            	margin-bottom: 10px;
            }
            .mui-btn-outlined.mui-btn-blue, .mui-btn-outlined.mui-btn-primary{
            	color:#f60;
            }
            .mui-btn-blue{
            	border-color:#f60;
            }
            .mui-btn-blue.mui-active:enabled, .mui-btn-blue:enabled:active, .mui-btn-primary.mui-active:enabled, .mui-btn-primary:enabled:active, input[type=submit].mui-active:enabled, input[type=submit]:enabled:active{
            	color: #fff;
			    border: 1px solid #f60;
			    background-color: #f60;
            }
		</style>
    <script src="../js/plugins/zepto.min.js"></script>
    <script type="text/javascript">
        function button_click(sender) {
            if (!confirm("确定绑定？")) {
                return;
            }
            var obj = $(sender);
            var kuwei_id = obj.attr("kuwei-id");
            var mac = $(".mac_input").val();
            $.ajax({
                url: '../ashx/bind_mac.ashx',
                data: { kuwei_id: kuwei_id, mac: mac },
                dataType: 'json',
                success: function (result) {
                    if (result.state == 0) {
                        alert(result.info);
                        window.location.href = "BindMac.aspx";
                    }
                    else {
                        alert(result.info);
                    }
                   
                }
            })
          
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="info">
			<div class="infoWrapper">
				<p class="topic">温馨提示</p>
				<p style="margin:0;">请选择您要配置该设备的房间号</p>
			</div>
		</div>
		<ul class="mui-clearfix">
            <asp:Repeater runat="server" ID="hotel_repeater">
                <ItemTemplate>
                    <li class="mui-pull-left">
				        <button type="button"  kuwei-id=' <%#Eval("id") %>' class="hotel_name mui-btn mui-btn-blue mui-btn-outlined" onclick="button_click(this)"><%#Eval("库位名") %></button>
			        </li>
                </ItemTemplate>
            </asp:Repeater>
			
		</ul>
    
        <input type="hidden" id="mac_input" class="mac_input"  runat="server"/>
    </form>
</body>
</html>
