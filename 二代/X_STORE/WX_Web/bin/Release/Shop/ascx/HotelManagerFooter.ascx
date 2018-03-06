<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HotelManagerFooter.ascx.cs" Inherits="Wx_NewWeb.Shop.ascx.HotelManagerFooter" %>
<!--酒店经理-->
<nav id="foot">
    <ul class="clearfix">
        <li>
            <a href="../views/home.aspx">
                <div class="index_bot">
                    <img class="picOff" src="../img/home.png" alt="" />
                    <img class="picOn" src="../img/home_on.png" alt="" />
                </div>
                <p>首页</p>
            </a>
        </li>
        <li>
            <a href="../views/hotelList.aspx">
                <div class="index_bot">
                    <img class="picOff" src="../img/list.png" alt="" />
                    <img class="picOn" src="../img/list_on.png" />
                </div>
                <p>列表</p>
            </a>
        </li>
        <li>
            <a href="../views/goodsList.aspx">
                <div class="index_bot">
                    <img class="picOff" src="../img/report.png" alt="" />
                    <img class="picOn" src="../img/report_on.png" alt="" />
                </div>
                <p>报表</p>
            </a>
        </li>
    </ul>
</nav>
<script src="../js/jquery-1.7.2.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("a[name='con']").each(function () {
          $(this).removeClass("");
            switch (page) {
                case "home":
                    $("a[name='con']").eq(0).addClass("on");
                    break;
                case "hotelList":

                    $("a[name='con']").eq(1).addClass("on");
                    break;
                case "goodsList":

                    $("a[name='con']").eq(2).addClass("on");
                    break;
            }
        })
    })
</script>
