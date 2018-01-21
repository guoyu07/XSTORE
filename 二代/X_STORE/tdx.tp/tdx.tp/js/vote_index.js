$(function () {
    var tempvoteSum = parseInt($(".vote_index_list").attr("votesum"));
    voteSum(tempvoteSum);
    vote();
    //    $(".vote_index_list dl dd p a").click(function () {
    //        if ($(this).attr("class") == "cant") {
    //            alert("您已经投过票，不能再次投票！");
    //        }
    //        else {
    //            alert("投票成功！一个微信帐号每次只能投一票！");
    //        }
    //        $(".vote_index_list dl dd p a").each(function () {
    //            $(this).unbind().addClass("cant");
    //        });
    //        var voteNumList = new Array();
    //        var dl_this = $(this).parent().parent().parent();
    //        var vid = (dl_this.attr("vid") == null) ? 0 : dl_this.attr("vid");
    //        var this_voteNum = parseInt(dl_this.attr("votenum")) + 1
    //        if (dl_this.attr("votenum") == null || dl_this.attr("votenum") == "") {
    //            this_voteNum = 1;
    //        }
    //        ++tempvoteSum;
    //        $(".vote_index_list").attr("votesum");
    //        dl_this.attr("votenum", this_voteNum);
    //        for (var i = 0; i < $(".vote_index_list dl").length; i++) {
    //            for (var j = i; j < $(".vote_index_list dl").length; j++) {
    //                var i_dl = $(".vote_index_list dl").eq(i);
    //                var j_dl = $(".vote_index_list dl").eq(j);
    //                var i_voteNum = parseInt(i_dl.attr("votenum"));
    //                var j_voteNum = parseInt(j_dl.attr("votenum"));
    //                if (j_voteNum > i_voteNum) {
    //                    i_dl.before(j_dl);
    //                }
    //            }
    //        }
    //        voteSum(tempvoteSum);
    //        $.ajax({ url: "../vote/vote.ashx?t=vote&vid=" + vid });
    //    });

    $("#vote_imgShow").width($(window).width());
    $(".vote_index_list dl dt").click(function () {
        $("#vote_imgShow img").attr("src", $(this).children("img").attr("src"));
        $("#vote_imgShow").show();
        $("#vote_imgShow").unbind().click(function () {
            $(this).hide();
        });
    });

    $(".cant").unbind("click");
})
function vote() {
    var tempvoteSum = parseInt($(".vote_index_list").attr("votesum"));
    $(".vote_index_list dl dd p a").unbind().click(function () {
        if ($(this).attr("class") == "cant") {
            alert("您已经投过票，不能再次投票！");
        }
        else {
            alert("投票成功！一个微信帐号每次只能投一票！");
        }
        $(".vote_index_list dl dd p a").each(function () {
            $(this).unbind().addClass("cant");
        });
        var voteNumList = new Array();
        var dl_this = $(this).parent().parent().parent();
        var vid = (dl_this.attr("vid") == null) ? 0 : dl_this.attr("vid");
        var this_voteNum = parseInt(dl_this.attr("votenum")) + 1
        if (dl_this.attr("votenum") == null || dl_this.attr("votenum") == "") {
            this_voteNum = 1;
        }
        ++tempvoteSum;
        $(".vote_index_list").attr("votesum");
        dl_this.attr("votenum", this_voteNum);
        for (var i = 0; i < $(".vote_index_list dl").length; i++) {
            for (var j = i; j < $(".vote_index_list dl").length; j++) {
                var i_dl = $(".vote_index_list dl").eq(i);
                var j_dl = $(".vote_index_list dl").eq(j);
                var i_voteNum = parseInt(i_dl.attr("votenum"));
                var j_voteNum = parseInt(j_dl.attr("votenum"));
                if (j_voteNum > i_voteNum) {
                    i_dl.before(j_dl);
                }
            }
        }
        $.ajax({ url: "vote.ashx?t=vote&vid=" + vid });
        voteSum(tempvoteSum);
    });
}
function voteSum(tempvoteSum) {
    $(".vote_index_list").attr("votesum", tempvoteSum);
    var voteSum = tempvoteSum;
    $(".vote_index_list dl").each(function (i) {
        var dl_this = $(this);
        var voteNum = dl_this.attr("votenum");
        var width = ((parseInt(voteNum) / parseInt(voteSum)) * 100) + "%";
        dl_this.children("dd").children("p").children("i").children("em").width(width);
        dl_this.children("dt").children("i").text(i + 1);
    });
}
var s = 0;
function scroll() {
    if (($("html").height() - $("body").scrollTop()) <= ($(window).height() + ($(".vote_index_list dl").eq(0).height() / 2)) || ($("html").height() - document.documentElement.scrollTop) <= ($(window).height() + ($(".vote_index_list dl").eq(0).height() / 2))) {
        if (s == 0) {
            s = 1;
            if ($("#isOver").length == 0) {
                var page = parseInt($(".vote_index_list").attr("page")) + 1;
                $(".vote_index_list").attr("page", page);
                $.ajax({
                    type: "post",
                    url: "vote.ashx?t=page&p=" + page + "&vid=" + queryString('id') + "&wwv=" + queryString("wwv"),
                    dataType: "text",
                    beforeSend: function () {
                        $("#loading,#isOver").remove(); $(".vote_index_list").append("<div id='loading' style='text-align:center; padding:8px; '>正在加载更多</div>");
                    },
                    success: function (data) {
                        s = 0;
                        $("#loading,#isOver").remove();
                        $(".vote_index_list").append(data);
                        vote();
                        var tempvoteSum = parseInt($(".vote_index_list").attr("votesum"));
                        voteSum(tempvoteSum);
                        $("dl").each(function (i) { $(this).children("dt").children("i").text(i + 1) });
                        $("#vote_imgShow").width($(window).width());
                        $("#vote_imgShow").height($(window).height());
                        $(".vote_index_list dl dt").click(function () {
                            $("#vote_imgShow img").attr("src", $(this).children("img").attr("src"));
                            $("#vote_imgShow").show();
                            $("#vote_imgShow").unbind().click(function () {
                                $(this).hide();
                            });
                        });
                    }
                });
            }
        }
    }
}
function queryString(str) {
    var result = location.search.match(new RegExp("[\?\&]" + str + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}