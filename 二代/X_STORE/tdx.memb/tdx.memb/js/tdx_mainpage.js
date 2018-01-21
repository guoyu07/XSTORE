// JavaScript Document
$(function () {
    /*JS控制DIV高度*/
    $(".htall").height($(window).height() - 44);
    $(window).resize(function () { $(".htall").height($(window).height() - 44); });
    /*JS控制DIV高度结束*/
    $(".httop .httop_right").click(function () {
        $(".httop").css("z-index", "1");
        $(".htall").css("z-index", "0");
        $(".httop_right_function").width($(".httop_user").width() + 8);
        if ($(this).attr("s") == null || $(this).attr("s") == "0") {
            $(this).addClass("httop_right_active");
            $(this).attr("s", "1");
        }
        else {
            $(this).removeClass("httop_right_active");
            $(this).attr("s", "0");
        }
    });
    $(".httop_mid").offset({ left: $(".httop_right").offset().left - $(".httop_mid").width() - 36 });

    /*与窗口同步变化*/
    $(window).resize(function () {
        $(".httop_mid").offset({ left: $(".httop_right").offset().left - $(".httop_mid").width() - 36 });
        //        /*左侧导航*/
        //        if ($(window).height() > $("body").height()) {
        //            $(".index_menu_list").height($(window).height() - $(".index_menu_list").offset().top);
        //        }
    });
    $(".httop_avatar img").LoadImage(false, 0, 0, "images4/avatar_logo.png");
    if ($(".htdh img").size() > 0) {
        $(".htdh img").hover(function () {
            var _imgurl = $(this).attr("src");
            if (_imgurl.indexOf("_s.jpg") == -1)
                $(this).attr("src", _imgurl.replace(".jpg", "_s.jpg"));
        }, function () {
            if (!$(this).hasClass("active")) {
                var _imgurl = $(this).attr("src");
                $(this).attr("src", _imgurl.replace("_s.jpg", ".jpg"));
            }
        });
        $(".htdh").each(function (index) {
            $(this).click(function () {
                $(".htdh img").each(function (index2) {
                    $(this).attr("src", $(this).attr("src").replace("_s.jpg", ".jpg"));
                    $(this).find("img").removeClass("active");
                });
                _imgurl = $(this).find("img").attr("src");
                $(this).find("img").attr("src", _imgurl.replace(".jpg", "_s.jpg"));
                $(this).find("img").addClass("active");
            });

        });
    } //顶部菜单js事件
    //处理左边的几个下拉位置
    if ($("#bg3").size() > 0) {
        $("#bg3").height($(window).height() - 596);
    }
    //菜单点击处理 
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
    $("#secondpane ul li.topLevel").each(function (index, element) {
        $(this).click(function () {//点击操作
            $("#secondpane ul li.topLevel").removeClass("active");
            $(this).addClass("active");
            //操作成鼠标滑过状态
            //右边字菜单改变
            $("#secondpane dd").removeClass("active");
            $("#secondpane dd").slice(index, index + 1).addClass("active");
        });
    });
    //子菜单点击
    $("#secondpane li.secondLevel").each(function (index, element) {
        $(this).click(function () {//点击操作
            $("#secondpane li.secondLevel").removeClass("active");
            $(this).addClass("active");
            //操作成鼠标滑过状态
            //右边字菜单改变
            $("#secondpane od").removeClass("active");
            $("#secondpane od").slice(index, index + 1).addClass("active");
        });
    });
    $("#secondpane od li").each(function (index, element) { //第三级的点击
        $(this).click(function () {
            $("#secondpane od li").removeClass("active");
            $(this).addClass("active");
        });
    });
    //    //绑定输入框提醒时间
    //    if ($(".nei_content").size() > 0) {
    //        init_input(".nei_content");
    //    }
    //登录下拉菜单
    if ($(".flip").size() > 0) {
        $(".flip").click(function () {
            var _xiaosanjiaoURL = $(".xiaosanjiao img").attr("src");
            if ($(".panel").is(":hidden")) {
                $(".panel").show();
                $(".xiaosanjiao img").attr("src", _xiaosanjiaoURL.replace(".png", "_s.png"));
            }
            else {
                $(".panel").hide();
                $(".xiaosanjiao img").attr("src", _xiaosanjiaoURL.replace("_s.png", ".png"));
            }
        });
    }
    /*是否显示新手引导*/
    if ($("#hfShowDH").val() == 1) {
        guide(0);
    }
});

function init_input(id) {
    var inp = $(id).find("input");
    for (var i = 0; i < inp.length; i++) {
        if (inp.slice(i, i + 1).attr("type") == "text") {
            inp.slice(i, i + 1).focus(function () {
                $(this).attr("rel", this.defaultValue);
                if ($(this).val() == $(this).attr("rel")) {
                    $(this).val("");
                } else {
                    $(this).select();
                }
            });
            inp.slice(i, i + 1).blur(function () {
                if ($(this).val() == "") {
                    $(this).val($(this).attr("rel"));
                }
            });
        }
    }
}



//通过函数
function checkAll(field, c) {
    for (i = 0; i < field.length; i++)
        field[i].checked = c.checked;
}
function selectChange(th, th2) {
    $(th2).empty();
    if ($(th).val() == "") {
        $("#txtUrl_2").hide();
        $("#txturl").show();
    }
    else {
        $("#txtUrl_2").show();
        $("#txturl").hide();
    }
    $.get("GetFunc.ashx?q=" + $(th).val(), function (data) {
        $(th2).append(data);
    });
}
function selectChange2(th, th2, th3) {
    var thValue = $(th).val();
    var th2Value = $(th2).val();
    switch (thValue) {
        case "newslist":
        case "prolist":
        case "teamlist":
        case "Goodslist":
        case "mslist":
        case "photolist":
            $("#txturl").val(thValue + ".aspx?cno=" + th2Value);
            break;
        case "honor_list":
            $("#txturl").val("honor_action.aspx?id=" + th2Value);
            $(th3).empty();
            if ($(th2).val() == "") {
                $("#txtUrl_2").hide();
                $("#txtUrl_3").hide();
                $("#txturl").show();
            }
            else {
                $("#txtUrl_2").show();
                $("#txtUrl_3").show();
                $("#txturl").hide();
            }
            $.get("GetFunc.ashx?r=" + $(th2).val(), function (data) {
                $(th3).append(data);
            });
            break;
        case "controls":
            $("#txturl").val("ShowControl.aspx?id=" + th2Value);
            break;
        case "tpage":
            $("#txturl").val(thValue + ".aspx?id=" + th2Value);
            break;
        default:
            $("#txtUrl_2").hide();
            $("#txturl").show();
            break;

    }
}


function select_Change3(th, th2, th3) {
    var thValue = $(th).val();
    th2Value = $(th2).val();
    var th3Value = $(th3).val();
    switch (thValue) {

        case "honor_list":
            $("#txturl").val(thValue + ".aspx?cno=" + th2Value + "&typeID=" + th3Value);
            break;
        default:
            $("#txtUrl_3").hide();
            $("#txtUrl_2").hide();
            $("#txturl").show();
            break;

    }
}

/*新手引导*/
var str = new Array()
str[0] = "httop_right,0";
str[1] = "index_novice,0";
str[2] = "index_setUp,0";
str[3] = "index_preview,0";
str[4] = "lv1,0";
str[5] = "lv1,1";
str[6] = "lv1,2";
str[7] = "lv1,3";
str[8] = "lv1,4";
str[9] = "lv1,5";
//str[10] = "lv1,6";
//str[11] = "lv1,7";
//str[12] = "lv1,8";
str[10] = "index_behalfSetUp,0";
str[11] = "index_behalfOperation,0";
str[12] = "index_behalfSpread,0";
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
    var o_zIndex = _this.css("z-index");
    /*提?示?图?片?的?定¨位?*/
    var gi_top = (_this.offset().top + _this.height()) + "px";
    var gi_left = _this.offset().left + "px";
    if ((_this.offset().left + $(".gImage").width()) > $(".gBody").width()) {
        gi_left = ($(".gBody").width() - $(".gImage").width()) + "px";
    }
    if (_index == 10 || _index == 11 || _index == 12) {
        gi_left = (_this.offset().left - ($(".gImage").width() - _this.width()) + 32) + "px";
    }
    /*提?示?图?片?的?定¨位?结á束?*/
    $(".gImage").animate({ "left": gi_left, "top": (_this.offset().top + _this.height()) + "px" }, 500, function () {
        if (_index == 0 || _index == 13 || _index == 14 || _index == 15) {
            var css = "arrowRight" + " txt" + str[_index].split(',')[0] + "_" + str[_index].split(',')[1];
            $(".gImage").children().eq(0).attr("class", css);
        }
        else {
            var css = "arrowLeft" + " txt" + str[_index].split(',')[0] + "_" + str[_index].split(',')[1];
            $(".gImage").children().eq(0).attr("class", css);
        }
    });
    $(".gLayer").animate({ "opacity": 0.5 }, 250, function () { $(".gLayer").animate({ "opacity": 0 }, 250); });
    $(".gLayer").animate({ "left": _this.offset().left + "px", "top": _this.offset().top + "px", "width": (str[_index].split(',')[0] == "lv1") ? (_this.width() + 8) : _this.width() + "px", "height": _this.height() + "px" }, 500, function () {
        if (str[_index].split(',')[0] == "lv1") { $(".httop").css("z-index", "0"); $(".htall").css("z-index", "1"); }
        else { $(".httop").css("z-index", "1"); $(".htall").css("z-index", "0"); }
        _this.after($(".gBody"));
        _this.parent().parent().children().css("z-index", "0");
        _this.parent().css("z-index", "1");
        $(".user_guide").show();
        if (_this.css("position") == "static" || _this.css("position") == null) {
            _this.css("position", "relative");
        }
        _this.css("z-index", "101");
        $(".gPrev").unbind().click(function () {
            $(".gLayer").stop();
            if (_this.css("position") != "absolute" && _this.css("position") != "fixed") {
                _this.css("position", "");
            }
            _this.css("z-index", o_zIndex);
            guide(_index - 1);
        });
        $(".gNext").unbind().click(function () {
            $(".gLayer").stop();
            if (_this.css("position") != "absolute" && _this.css("position") != "fixed") {
                _this.css("position", "");
            }
            _this.css("z-index", o_zIndex);
            guide(_index + 1);
        });
        $(".gLayer").css("z-index", "103");
    });
    $(".guideClose").unbind().click(function () {
        $(".gBody").hide();
        $(".gLayer").hide();
    });
}