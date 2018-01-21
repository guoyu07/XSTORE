<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wxfoot.ascx.cs" Inherits="Wx_NewWeb.wxfoot" %>
<div class="i_copyright">
    <div class="copy_r">
       &copy;
       <asp:Literal ID='lt_nichen' runat='server'></asp:Literal>微信网站系统
    </div>
    <div class="shchkj">
       技术支持：
       <a href="http://www.china-mail.com.cn/appv/index.aspx?WWX=gh_4891e4667327" target="_blank">实创科技</a>
    </div>
</div>

<div class="i_foot">
    <ul>
        <asp:Literal ID="lt_menu" runat="server" EnableViewState="false"></asp:Literal>
    </ul>
</div>
<div class="waiting">
    <img border="0" style="margin-top: 8px;" src="images/loading.gif" alt="" />
</div>
<!--快捷方式-->
 <asp:Literal ID="lt_color" runat="server"></asp:Literal>
<div class="plug-div">
    <div class="plug-phone">
        <div class="plug-menu bgcolor">
            <span class="close"></span>
        </div>
        <div class="bgcolor plug-btn plug-btn1 close">
            <asp:Literal ID="lt_plus_tel" runat="server" ></asp:Literal> 
        </div>
        <div class="bgcolor plug-btn plug-btn2 close">
            <asp:Literal ID="lt_plus_map" runat="server" ></asp:Literal>  
        </div>
        <div class="bgcolor plug-btn plug-btn3 close">
            <asp:Literal ID="lt_plus_index" runat="server" ></asp:Literal>  
        </div>
        <script type="text/javascript">
            $(".plug-div .plug-btn3").click(function () {
                window.scrollTo(0, 0);
                $(".plug-menu span").removeClass("open").addClass("close");
                $(".plug-btn").removeClass("open").addClass("close");
            });
          </script>
        <div class="bgcolor plug-btn plug-btn4 close">
            <asp:Literal ID="lt_plus_qq" runat="server" ></asp:Literal>  
        </div>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        $(".plug-menu").click(function () {
            var span = $(this).find("span");
            if (span.attr("class") == "open") {
                span.removeClass("open");
                span.addClass("close");
                $(".plug-btn").removeClass("open");
                $(".plug-btn").addClass("close");
            } else {
                span.removeClass("close");
                span.addClass("open");
                $(".plug-btn").removeClass("close");
                $(".plug-btn").addClass("open");
            }
        });
        $(".plug-menu").on('touchmove', function (event) { event.preventDefault(); });
    });
</script>
