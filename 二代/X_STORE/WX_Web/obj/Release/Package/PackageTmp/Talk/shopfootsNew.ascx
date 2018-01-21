<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="shopfootsNew.ascx.cs" Inherits="Wx_NewWeb.Talk.shopfootsNew" %>
<ul class="warp clearfix">
    <li>
        <!--<li class="on">-->
        <a href="../Shop/index.aspx" page_click_button="底部_首页" name="con"><i class="new_icon"></i><span>首页</span> </a></li>
    <li><a href="../Shop/fenleinew.aspx" page_click_button="底部_品牌" name="con"><i class="new_icon"></i>
        <span>分类</span> </a></li>
    <li>
        <%=carhtml%></li>
    <li><a href="../Shop/user.aspx?openid=<%=openid %>" page_click_button="底部_我的"
        name="con"><i class="new_icon"><strong style="display: none;"></strong></i><span>我的</span>
    </a></li>
</ul>
<script type="text/javascript">
    $(function () {

        $("a[name='con']").each(function () {

            //$(this).click(function () {

            //    $("a[name='con']").each(function () {
            //        $(this).removeClass("");
            //    })
            //    $(this).addClass("on");
            //});
            $(this).removeClass("");
            var page = "<%=page %>";

            switch (page) {

                case "index":

                    $("a[name='con']").eq(0).addClass("on");
                    break;
                case "fenleinew":

                    $("a[name='con']").eq(1).addClass("on");
                    break;
                case "car":

                    $("a[name='con']").eq(2).addClass("on");
                    break;
                case "usercenter":

                    $("a[name='con']").eq(3).addClass("on");
                    break;
            }



        })

    })
</script>
