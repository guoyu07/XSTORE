$(function () {
    $(".slideshow_images").offset({ top: $(".nei_content table").offset().top - 32, left: $(".nei_content table").offset().left + $(".nei_content table").width() +32});
    function hiddenToShow(_targte) {
        /*标题*/
        $(".nei_content #txtname").val($("." + _targte).attr("_title"));
        /*图片地址*/
        $(".nei_content #Image1").attr("src", $("." + _targte).attr("_pic"));
        /*广告URL*/
        $(".nei_content #txturl").val($("." + _targte).attr("_url"));
        $(".nei_content #txtsort").val($("." + _targte).attr("_sort"));
        /*正文*/
        $("#itemId").val($("." + _targte).attr("_itemid"));
    }
    //点击编辑
    function editOtherInfo() {
        $("a.infoEdit").unbind("click").click(function () {
            var _this = $(this).parent().parent();
            $(".nei_content #txtname").val("");
            $(".nei_content #Image1").attr("src", "");
            $(".nei_content #txturl").val("");
            $(".nei_content #txtsort").val("");
            $("#itemId").val("");
            $("#fileimg").val("");
            hiddenToShow(_this.attr("id"));
        });
    }
    editOtherInfo();
    //////////////点击编辑显示



});