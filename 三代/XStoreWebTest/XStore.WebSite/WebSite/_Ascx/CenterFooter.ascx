<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CenterFooter.ascx.cs" Inherits="XStore.WebSite.WebSite._Ascx.CenterFooter" %>
<%@ Import Namespace="XStore.Entity" %>
<div class="warp">
<nav id="foot">
    <ul class="clearfix">
        <li style="width: 50%;">
            <a href='<%=Constant.JsOperationDic+"RoomSelect.aspx" %>' class="current">

                <div class="index_bot">
                    <img class="picOff" src="/Content/Images/pickUp.png" alt="" />
                    <img class="picOn" src="/Content/Images/pickUp_on.png" alt="" />
                </div>
                <p>常规补货</p>
            </a>
        </li>
        <li style="width: 50%;">
            <a href='<%=Constant.JsCenterDic+"EmployeeCenter.aspx" %>'>
                <div class="index_bot">
                    <img class="picOff" src="/Content/Images/myself.png" alt="" />
                    <img class="picOn" src="/Content/Images/myself_on.png" />
                </div>
                <p>我的</p>
            </a>
        </li>

    </ul>
</nav>
    </div>
<script type="text/javascript">
    $(function () {
        $("a[name='con']").each(function () {
            $(this).removeClass("");
            switch (page) {
                case "roomStatus":
                    $("a[name='con']").eq(0).addClass("on");
                    break;
                case "PickUp":
                    $("a[name='con']").eq(1).addClass("on");
                    break;
                case "disMyself":
                    $("a[name='con']").eq(2).addClass("on");
                    break;
            }
        })

    })
</script>
