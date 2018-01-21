$(function () {
    //htallHeight();
    topNavigationMinMove();
    leftMenu();
    rightUserInfo();
    $(".blockContent").height($(".blockContent").height() - 44);
    //guide2(0);
    $(window).resize(function () {
        //htallHeight();
        topNavigationMinMove();
    });
    /*img Loading*/
    $(".httop_avatar img").LoadImage(false, 40, 40, "images4/avatar_logo.png");
    /*iframe loading*/
    $("#Iframe1").load(function () {
        $(".iframe_Loading").stop();
        $(".iframe_Loading").animate({ "opacity": 0 }, function () { $(".iframe_Loading").hide(); });

    });
    $("a").click(function () {
        if ($(this).attr("target") == "mainFram") {
            $(".iframe_Loading").show();
            $(".iframe_Loading").animate({ "opacity": 0.7 });
        }
    });

    /*是否显示选择行业*/
    if ($("#hfSelectHY").val() == 1) {
        alertSelectHangYe();
    }
    else {
        //        /*是否显示新手引导*/
        //        if ($("#hfShowDH").val() == 1) {
        //            guide(0);
        //        }
    }
});

/*控制左侧导航和内页外框高度*/
function htallHeight() {
    var htallHeight = $(".htall").height();
    var leftMenuHeight = $(".index_menu_list").height();
    if (leftMenuHeight >= $(window).height()) {
        $(".htall").height(leftMenuHeight);
    }
    else {
        $(".htall").height($(window).height() - 44);
        $(".index_menu_list").height($(window).height() - 44);
    }
}
/*控制头部代搭建导航块位置*/
function topNavigationMinMove() {
    $(".topNavigation_mid").offset({ left: $(".topNavigation_right").offset().left - $(".topNavigation_mid").width() - 36 });
}
/*左侧导航菜单*/
function leftMenu() {
    $(".lv1").click(function () {
        var _this = $(this);
        if (_this.attr("class").indexOf("active") >= 0) {
            _this.removeClass("active");
            _this.next().removeClass("menu_active");
        }
        else {
            $(".lv1").each(function () {
                $(this).removeClass("active");
                $(this).next().removeClass("menu_active");
            });
            _this.addClass("active");
            _this.next().addClass("menu_active");
        }
    });
    $(".lv2").click(function () {
        var _this = $(this);
        if (_this.attr("class").indexOf("active2") >= 0) {
            _this.removeClass("active2");
            if (!(_this.next("[class*='lv2']").length > 0)) {
                _this.next().removeClass("menu_active2");
            }
        }
        else {
            $(".lv2").each(function () {
                $(this).removeClass("active2");
                $(this).next().removeClass("menu_active2");
            });
            _this.addClass("active2");
            if (!(_this.next("[class*='lv2']").length > 0)) {
                _this.next().addClass("menu_active2");
            }
        }
    });
}
/*顶部右侧用户操作*/
function rightUserInfo() {
    $(".topNavigation .topNavigation_right").click(function () {
        $(".topNavigation").css("z-index", "1");
        $(".htall").css("z-index", "0");
        $(".topNavigation_right_function").width($(".topNavigation_user").width() + 8);
        if ($(this).attr("s") == null || $(this).attr("s") == "0") {
            $(this).addClass("topNavigation_right_active");
            $(this).attr("s", "1");
        }
        else {
            $(this).removeClass("topNavigation_right_active");
            $(this).attr("s", "0");
        }
    });
}
/*新手引导*/
var str = new Array()
str[0] = "topNavigation_right,0";
str[1] = "index_novice,0";
str[2] = "index_setUp,0";
str[3] = "index_preview,0";
str[4] = "lv1,0";
//str[5] = "lv1,1";
str[5] = "lv1,1";
str[6] = "lv1,3";
str[7] = "lv1,4";
str[8] = "lv1,5";
//str[10] = "lv1,6";
//str[11] = "lv1,7";
//str[12] = "lv1,8";
str[9] = "index_behalfSetUp,0";
str[10] = "index_behalfOperation,0";
str[11] = "index_behalfSpread,0";
function guide(_index) {
    $(".gImage").animate({ "opacity": 0 }, 250, function () { $(".gImage").animate({ "opacity": 1 }, 250); });
    $(".gPrev").unbind();
    $(".gNext").unbind();
    $(".gBody").show();
    $(".gLayer").show();
    if ((_index + 1) >= str.length) { $(".gNext").hide(); }
    else { $(".gNext").show(); }
    if ((_index - 1) >= 0) { $(".gPrev").show(); }
    else { $(".gPrev").hide(); }
    var _this = $("." + str[_index].split(',')[0]).eq(parseInt(str[_index].split(',')[1]));
    /*提示图片的定位*/
    var gi_top = (_this.offset().top + _this.height()) + "px";
    var gi_left = _this.offset().left + "px";
    if ((_this.offset().left + $(".gImage").width()) > $(".gBody").width()) {
        gi_left = ($(".gBody").width() - $(".gImage").width()) + "px";
    }
    if (_index == 10 || _index == 11 || _index == 9) {
        gi_left = (_this.offset().left - ($(".gImage").width() - _this.width()) + 32) + "px";
    }

    $(".gImage").animate({ "left": gi_left, "top": (_this.offset().top + _this.height()) + "px" }, 500, function () {
        if (_index == 0 || _index == 12 || _index == 13 || _index == 14) {
            var css = "arrowRight" + " txt" + str[_index].split(',')[0] + "_" + str[_index].split(',')[1];
            $(".gImage").children().eq(0).attr("class", css);
        }
        else {
            var css = "arrowLeft" + " txt" + str[_index].split(',')[0] + "_" + str[_index].split(',')[1];
            $(".gImage").children().eq(0).attr("class", css);
        }
    });
    /*提示图片的定位结束*/
    $(".gLayer").animate({ "opacity": 0.5 }, 250, function () { $(".gLayer").animate({ "opacity": 0 }, 250); });
    $(".gLayer").animate({ "left": _this.offset().left + "px", "top": _this.offset().top + "px", "width": (str[_index].split(',')[0] == "lv1") ? (_this.width() + 8) : _this.width() + "px", "height": _this.height() + "px" }, 500, function () {
        _this.after($(".gBody"));
        /*层级判断*/
        if (_index > 3 && _index < 9) {
            $(".blockContent").css("z-index", "2");
            $(".blcokTop").css("z-index", "1");
            $(".leftNavigation").css("z-index", "1");
        }
        else {
            if (_index > 0) {
                $(".topNavigation_mid").css("z-index", "1");
            }
            else {
                $(".topNavigation_mid")[0].style.zIndex = '';
            }
            $(".blockContent")[0].style.zIndex = '';
            $(".blcokTop")[0].style.zIndex = '';
            $(".leftNavigation")[0].style.zIndex = '';
        }
        /*层级判断结束*/
        $(".user_guide").show();
        if (_this.css("position") == "static" || _this.css("position") == null) {
            _this.css("position", "relative");
        }
        _this.css("z-index", "101");
        /*上一步*/
        $(".gPrev").unbind().click(function () {
            _this[0].style.zIndex = ''
            $(".gLayer").stop();
            if (_this.css("position") != "absolute" && _this.css("position") != "fixed") {
                _this.css("position", "");
            }
            guide(_index - 1);
        });
        /*下一步*/
        $(".gNext").unbind().click(function () {
            _this[0].style.zIndex = ''
            $(".gLayer").stop();
            if (_this.css("position") != "absolute" && _this.css("position") != "fixed") {
                _this.css("position", "");
            }
            guide(_index + 1);
        });
        $(".gLayer").css("z-index", "103");
    });
    $(".guideClose").unbind().click(function () {
        _this[0].style.zIndex = ''
        $(".gBody").hide();
        $(".gLayer").hide();
    });
}
/*新手引导2*/
function guide2(_index) {
    var _this = $("." + str[_index].split(',')[0]).eq(parseInt(str[_index].split(',')[1]));
    $(".gImage").animate({ "opacity": 0 }, 250);
    $(".gright").hide();
    $(".gbottom").hide();
    $(".gleft").hide();
    $(".gtop").offset({ top: 0, left: 0 });
    $(".gtop").css("width", "100%");
    $(".gtop").css("height", "100%");
    $(".blcokTop,.blockContent").css("z-index", "0");
    $(".gLayer").animate({ "opacity": 0.5 }, 250, function () { $(".gLayer").animate({ "opacity": 0 }, 250); });
    $(".gLayer").animate({ "left": _this.offset().left + "px", "top": _this.offset().top + "px", "width": (str[_index].split(',')[0] == "lv1") ? (_this.width() + 8) : _this.width() + "px", "height": _this.height() + "px" }, 500, function () {
        $(".gright").show();
        $(".gbottom").show();
        $(".gleft").show();
        var kTop = _this.offset().top;
        var kLeft = _this.offset().left;
        var kBottom = _this.offset().top + _this.height();
        var kRight = _this.offset().left + _this.width();
        $(".gtop").offset({ top: 0, left: 0 });
        $(".gtop").height(kTop);
        $(".gright").offset({ top: kTop, left: kRight });
        $(".gright").height(_this.height());
        $(".gright").width($(window).width() - kRight);
        $(".gbottom").offset({ top: kBottom, left: 0 });
        $(".gbottom").height($(window).height() - kBottom);
        $(".gleft").offset({ top: kTop, left: 0 });
        $(".gleft").height(_this.height());
        $(".gleft").width(kLeft);
        /*提示图片的定位*/
        var gi_top = (_this.offset().top + _this.height()) + "px";
        var gi_left = _this.offset().left + "px";
        if ((_this.offset().left + $(".gImage").width()) > $(".gBody").width()) {
            gi_left = ($(".gBody").width() - $(".gImage").width()) + "px";
        }
        if (_index == 10 || _index == 11 || _index == 9) {
            gi_left = (_this.offset().left - ($(".gImage").width() - _this.width()) + 32) + "px";
        }
        if (_index == 0 || _index == 12 || _index == 13 || _index == 14) {
            var css = "arrowRight" + " txt" + str[_index].split(',')[0] + "_" + str[_index].split(',')[1];
            $(".gImage").children().eq(0).attr("class", css);
        }
        else {
            var css = "arrowLeft" + " txt" + str[_index].split(',')[0] + "_" + str[_index].split(',')[1];
            $(".gImage").children().eq(0).attr("class", css);
        }
        $(".gImage").animate({ "left": gi_left, "top": (_this.offset().top + _this.height()) + "px", "opacity": 1 }, 500);
        /*提示图片的定位结束*/
        /*上一步*/
        $(".gPrev").unbind().click(function () {
            _this[0].style.zIndex = ''
            $(".gLayer").stop();
            if (_this.css("position") != "absolute" && _this.css("position") != "fixed") {
                _this.css("position", "");
            }
            guide2(_index - 1);
        });
        /*下一步*/
        $(".gNext").unbind().click(function () {
            _this[0].style.zIndex = ''
            $(".gLayer").stop();
            if (_this.css("position") != "absolute" && _this.css("position") != "fixed") {
                _this.css("position", "");
            }
            guide2(_index + 1);
        });
    });

}
function alertSelectHangYe() {
    var $alert = $("<div class=\"mask_alert\"><h1 class=\"mask_Title\">选择行业</h1><div><iframe src='SelectHangYe.aspx'></iframe></div></div>");
    var $mask = $("<div class=\"mask\"></div>");
    var alertTop = 0, alertLeft = 0;
    $alert.appendTo($("body"));
    $mask.appendTo($("body"));
    $(".mask").show();
    $(".mask_alert").show();
    alertTop = ($(".mask").height() - $(".mask_alert").height() - 8) / 2;
    alertLeft = ($(".mask").width() - $(".mask_alert").width() - 8) / 2;
    $alert.offset({ top: alertTop, left: alertLeft });
}