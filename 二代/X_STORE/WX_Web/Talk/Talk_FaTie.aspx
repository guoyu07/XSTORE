<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Talk_FaTie.aspx.cs" Inherits="Wx_NewWeb.Talk.Talk_FaTie" %>

<%@ Register TagPrefix="uc" TagName="appFooter_1" Src="~/Shop/shopfoots.ascx" %>
<%@ Register TagPrefix="uc" TagName="shopfootsNew" Src="~/Talk/shopfootsNew.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>幸事多-发帖</title>
<%--    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_bbs.css" rel="stylesheet" type="text/css" />
    <script src="js/jqurey.js" type="text/javascript"></script>--%>
    
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="css/weui.css" rel="stylesheet" type="text/css" />
    <link href="css/common_bbs.css" rel="stylesheet" type="text/css" />
    <link href="css/style_bbs.css" rel="stylesheet" type="text/css" />
    <script src="js/jqurey.js" type="text/javascript"></script>
        <link rel="stylesheet" type="text/css" href="../style/footer.css">
    <link href="css/weui.css" rel="stylesheet" />
    <script>        __STAT.add('head_load');</script>
        <script src="../style/562a4c0e89.jquery-2.1.0.min.js"></script>

    <!--轮播图-->
    <script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>
    <!--回顶部-->
    <script type="text/javascript" src="js/zzsc.js"></script>
    <script src="js/weui.js"></script>
    <script type="text/javascript">
        $(function () {
            $(window).toTop({
                showHeight: 100,//设置滚动高度时显示
                speed: 300 //返回顶部的速度以毫秒为单位
            });
        });

        function Add() {
            var bianhao = '<%=GeteRandomNumber(15)%>';
            var cno = $("#drp_type").val();
            var title = $("#title").val();
            var textarea_jj = $("#textarea_jj").val();
            var regtime = '<%=DateTime.Now%>';
            var openid = '<%=openid%>';
            var id = '<%=类别号%>';
            if (cno == ""||cno=="-1")
            {
                alert('请选择主题');
                return;
            }
            if (title == "") {
                alert('请填写标题');
                return;
            }
            if (textarea_jj == "") {
                alert('请填写内容');
                return;
            }
            $.ajax({
                type: "POST",
                async: false,
                dataType: "text",
                url: 'AddTalk.ashx',                                               
                data: { bianhao: bianhao, cno: cno, title: title, textarea_jj: textarea_jj, regtime: regtime, openid: openid },
                        beforeSend: function () {
                            $("#LinkButton1").unbind("click");
                        },
                        success: function (msg) {
                            if (msg == "1")
                            {
                                $.weui.toast('发帖成功'); setTimeout(function () {
                                    location.href = 'Talk_List.aspx?cno=' + id;
                                }, 2000);
                                //location.href = 'Talk_List.aspx?cno=' + cno;
                            }                           
                        }
                      })
        }
    </script>

</head>
<body>
    <form runat="server">
                                <!--头部开始-->
<%--        <header id="header" class="u-header clearfix">
	<div class="u-hd-left f-left">
    	<a href="javascript:history.go(-1)" mars_sead="brand-detail-back_btn" class="J_backToPrev"><span class="u-icon i-hd-back"></span></a>
    </div>
    <span class="u-hd-tit">幸事多-发帖</span>
    <div class="u-hd-right f-right">
    	<a href="../Shop/index.aspx" mars_sead="nav_home_btn"><span class="u-icon i-hd-home"></span></a>
    </div>
</header>--%>
        <!--头部结束-->

        <!--正文列表开始-->
        <div class="f_title">
            <div class="wrap">
                <div class="ft_title">发帖</div>
            </div>
        </div>
        <div class="sport wrap">
            <div class="weui_cells">
                <div class="weui_cell_select">
                    <div class="weui_cell_bd weui_cell_primary">
                        <!--<select class="weui_select" name="select1">
                            <option selected="" value="1">微信号</option>
                            <option value="2">QQ号</option>
                            <option value="3">Email</option>
                        </select>-->
                        <asp:DropDownList CssClass="weui_select" ID="drp_type" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            
            
            <div class="weui_cells">
                <div class="weui_cell border_b">
                    <div class="weui_cell_bd weui_cell_primary">
                        <input class="weui_input" id="title" runat="server" name="name" type="text" placeholder="标题（必填）" />
                    </div>
                </div>
                <div class="weui_cell">
                    <div class="weui_cell_bd weui_cell_primary">
                        <textarea class="weui_textarea" id="textarea_jj" runat="server" placeholder="说两句吧" rows="3"></textarea>
                        <div class="weui_textarea_counter"><span id="count_jj">0</span>/200</div>
                        <div class="ft_title_sub"><span>所在板块</span>【<%=Gettheme()%>】</div>
                    </div>
                </div>

            </div>

            <div class="weui_btn_area">
                <asp:LinkButton runat="server" ID="LinkButton1" Text="发送"  OnClientClick="Add()" class="weui_btn weui_btn_primary" />
            </div>                                                        <%-- OnClick="button_OnClick"--%>
        </div>
        <!--正文列表结束-->
        <!--正文结束-->
        <!--文本域的字数控制-->

        <div class="layout-login-area" id="footer">
            <!--<div class="layout-login">
						<span class="layout-lg-bar">528062317@qq.com </span>
						<span class="layout-new-fr"><a href="">反馈</a></span>
			     </div>-->
            <div class="layout-copyright">
                © 幸事多 版权所有
            </div>
        </div>
        <!--以下是底部样式-->
<%--        <div style="display: block;" class="footer_bar openwebview">
            <uc:shopfootsNew ID="appFooter1"  runat="server" EnableViewState="False" />
        </div>--%>


        <script src="js/js_textarea.js"></script>

        <script src="js/weui.js"></script>
    </form>
</body>
</html>

