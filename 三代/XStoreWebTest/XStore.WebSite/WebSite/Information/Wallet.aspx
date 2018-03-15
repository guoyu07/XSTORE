<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wallet.aspx.cs" Inherits="XStore.WebSite.WebSite.Information.Wallet" %>
<%@ Import Namespace="XStore.Entity" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="UTF-8" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title><%:Title %></title>
    <link rel="icon" href="/Content/Icon/logo.png" type="image/x-icon" />
    <link href="/Content/fonts/iconfont.css" rel="stylesheet" />
    <%: System.Web.Optimization.Styles.Render("~/bundles/CommonStyle","~/bundles/paycenter/css")%>
    <%: System.Web.Optimization.Scripts.Render("~/bundles/CommonJs")%>
    <style>
        .divcenter {
            margin: 0 auto; /* 居中 这个是必须的，，其它的属性非必须 */
            width: 100%; /* 给个宽度 顶到浏览器的两边就看不出居中效果了 */
            text-align: center; /* 文字等内容居中 */
        }

        .t80 {
            margin-top: 80px;
        }

        .divfont {
            font-weight: 900;
            font-size: 28px;
        }

        .a_fenrun {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divcenter">
            <div class="t80">
                <img src="/Content/Icon/钱币.png" style="height: 50px; width: 50px; margin: 0 auto;" />
                <div class="divfont">¥<span runat="server" id="mymoney"></span></div>
            </div>
        </div>
        <div class="submit pd3" style="margin-top: 50px;">
            <a class="submitBtn" id="extract" runat="server" onserverclick="extract_ServerClick">提现</a>
        </div>
        <div class="divcenter a_fenrun"><a href="<%=Constant.JsInformationDic+"ShareDetail.aspx" %>"">流水明细>></a></div>
    </form>
</body>
</html>
