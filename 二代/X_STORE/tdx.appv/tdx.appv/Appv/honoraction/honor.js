//中奖后用户提交
$(function () {




    $("#save-btn").click(function () {
        var tel = $("#tel").val();
        if (tel == '') { alert("请输入手机号码"); return }
        var regu = /^[1][0-9]{10}$/;
        var re = new RegExp(regu);
        if (!re.test(tel)) {
            alert("请输入正确手机号码");
            return
        }
        $.ajax({
            async: true,
            cache: false,
            global: true,
            timeout: 120000,
            contentType: 'application/x-www-form-urlencoded',

            type: 'POST',
            url: "honor_cj.ashx?action=tijiao",
            dataType: 'text',
            data: { "tel": tel, "sn": $("#sncode").text(), "acID": $("#h_acID").val(), "WWV": $("#h_WWV").val(),
                "name": $("#name").val(), "comp": $("#comp").val(), "addr": $("#addr").val(), "email": $("#email").val()
            },
            success: function (data) {
                if (data == "success") {
                    $("#zjbox").empty();
                    $("#zjbox").append('<div class="Detail serv_res"><span  class="red"> 提交成功 </span></div>');
                }
                else {
                    $("#servspan").html(data);

                }
            }
        });

    });


});
/////转盘

$(function () {
    window.requestAnimFrame = (function () { return window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame || function (callback) { window.setTimeout(callback, 1000 / 60) } })();
    var totalDeg = 360 * 3 + 0;
    var steps = [];
    var lostDeg = [36, 66, 96, 156, 186, 216, 276, 306, 336];
    var prizeDeg = [6, 126, 246];
    var prize, sncode;
    var count = 0;
    var now = 0;
    var a = 0.01;
    var outter, inner, timer, running = false;
    function countSteps() {
        var t = Math.sqrt(2 * totalDeg / a); var v = a * t;
        for (var i = 0; i < t; i++) {
            steps.push((2 * v * i - a * i * i) / 2)
        }
        steps.push(totalDeg)
    }
    function step() {
        outter.style.webkitTransform = 'rotate(' + steps[now++] + 'deg)';
        outter.style.MozTransform = 'rotate(' + steps[now++] + 'deg)';
        if (now < steps.length) {
            requestAnimFrame(step)
        }
        else {
            running = false;
            setTimeout(function () {
                if (prize != null) {
                    $("#sncode").text(sncode); var type = "";
                    if (prize == 1) {
                        type = "一等奖"
                    }
                    else if (prize == 2) {
                        type = "二等奖"
                    }
                    else if (prize == 3) {
                        type = "三等奖"
                    }
                    $("#prizetype").text(type);
                    $("#zjl").slideToggle(500);
                    $("#outercont").slideUp(500)
                }
                else {
                    alert("谢谢您的参与，下次再接再厉")
                }
            }, 200)
        }
    }
    function start(deg) {
        deg = deg || lostDeg[parseInt(lostDeg.length * Math.random())]; running = true; clearInterval(timer); totalDeg = 360 * 5 + deg; steps = []; now = 0; countSteps(); requestAnimFrame(step)
    }
    window.start = start;
    outter = document.getElementById('outer');
    inner = document.getElementById('inner');
    i = 10;
    $("#inner").click(function () {
        if (running) return;
        if (count >= $("#chjnum").val()) { alert("您抽奖次数已用完。"); return }
        if (prize != null) { alert("亲，你不能再参加本次活动了喔！下次再来吧~"); return }
        $.ajax({
            url: "honor_cj.ashx?action=zhuanpan",
            dataType: "json",
            data: { "typeID": $("#h_acID").val(), "WWV": $("#h_WWV").val(), t: Math.random() },
            beforeSend: function () { running = true; timer = setInterval(function () { i += 5; outter.style.webkitTransform = 'rotate(' + i + 'deg)'; outter.style.MozTransform = 'rotate(' + i + 'deg)' }, 1) },
            success: function (data) {
                if (data.success == "invalid") {
                    alert("您抽奖次数已用完。");
                    count = $("#chjnum").val();
                    clearInterval(timer);
                    return
                }
                if (data.success == "getsn") {
                    alert('本次活动你已经中过奖，兑奖SN码为:' + data.sn);
                    clearInterval(timer);
                    return;
                    //                                    count = 3;
                    //                                    clearInterval(timer);
                    //                                    prize = data.prizetype;
                    //                                    sncode = data.sn;
                    //                                    start(prizeDeg[data.prizetype - 1]);

                }
                if (data.success == "zhong") {
                    prize = data.prizetype;
                    sncode = data.sn;
                    start(prizeDeg[data.prizetype - 1])
                } else {
                    prize = null;
                    start()
                }
                running = false;
                count++
            },
            error: function () { prize = null; start(); running = false; count++ }, timeout: 4000
        })
    })
});

/////转盘........................................end


/////刮刮乐

window.sncode = "null";
window.prize = "谢谢参与";

var zjl = false;
var num = 0;
var goon = true;
var award = "谢谢参与";
var award_no = 0;
$(function () {
    try {


        $("#scratchpad").wScratchPad({
            width: 150,
            height: 40,
            color: "#a9a9a7",
            scratchMove: function () {
                $(this.canvas).css('margin-right', $(this.canvas).css('margin-right') == "0px" ? "1px" : "0px");
                num++;
                if (num == 1) {
                    var datainfo = { "typeID": $("#h_acID").val(), "WWV": $("#h_WWV").val(), t: Math.random() };
                    $.getJSON("honor_cj.ashx?action=zhuanpan", datainfo, function (data) {

                        if (data.success == "invalid") {
                            alert("您抽奖次数已用完。");
                            return
                        }
                        if (data.success == "getsn") {
                            alert('本次活动你已经中过奖，兑奖SN码为:' + data.sn);
                            return
                        }
                        if (data.success == "zhong") {
                            //$("#result").html("恭喜，您中得" + res.prize + "!");
                            var jiangpintype = "";
                            if (data.prizetype == 1) {
                                jiangpintype = "一等奖"
                            }
                            else if (data.prizetype == 2) {
                                jiangpintype = "二等奖"
                            }
                            else if (data.prizetype == 3) {
                                jiangpintype = "三等奖"
                            }
                            $("#prizetype").html(jiangpintype);
                            $("#prize").html(jiangpintype);
                            zjl = true;
                            $("#sncode").html(data.sn);


                        } else {
                            //$("#result").html("很遗憾,您没能中奖!");

                        }
                    });
                }
                if (zjl && num > 20 && goon) {
                    //$("#zjl").fadeIn();
                    goon = false;
                    $("#zjl").show(500);
                    //$("#zjl").slideToggle(500);
                    //$("#outercont").slideUp(500)
                }

            }
        });
    } catch (e) {

    }

    //$("#prize").html("谢谢参与");
    //loadingObj.hide();
    //$(".loading-mask").remove();





});

// 保存数据
$("#save-btnn").bind("click", function () {
    //var btn = $(this);
    var submitData = {
        tid: 438,
        code: $("#sncode").text(),
        parssword: $("#parssword").val(),
        action: "setTel"
    };
    $.post('index.php?ac=acw', submitData,
				function (data) {
				    if (data.success == true) {
				        alert(data.msg);
				        if (data.changed == true) {
				            window.location.href = location.href;
				        }
				        return
				    } else { }
				},
				"json")
});

/////刮刮乐........................................end

/////砸金蛋
var hammerone = false;
function eggClick(obj) {
    if (hammerone) {
        alert("刷新后再来");
        return;
    }
    hammerone = true;
    var _this = obj;
    var datainfo = { "typeID": $("#h_acID").val(), "WWV": $("#h_WWV").val(), t: Math.random() };
    $.getJSON("honor_cj.ashx?action=zhuanpan", datainfo, function (data) {

        if (_this.hasClass("curr")) {
            alert("蛋都碎了，别砸了！刷新再来.");
            return false;
        }
        //_this.unbind('click');
        $(".hammer").css({ "top": _this.position().top - 55, "left": _this.position().left + 185 });
        $(".hammer").animate({
            "top": _this.position().top - 25,
            "left": _this.position().left + 125
        },
									30,
									 function () {
									     _this.addClass("curr"); //蛋碎效果
									     _this.find("sup").show(); //金花四溅
									     $(".hammer").hide();
									     $('.resultTip').css({ display: 'block', top: '100px', left: '30%', opacity: 0 }).animate({ top: '25px', opacity: 1 }, 300, function () {

									         if (data.success == "invalid") {
									             $("#result").html("您抽奖次数已用完。");
									             return
									         }
									         if (data.success == "getsn") {
									             $("#result").html('本次活动你已经中过奖，兑奖SN码为:' + data.sn);
									             return
									         }
									         if (data.success == "zhong") {
									             var jiangpintype = "";
									             if (data.prizetype == 1) {
									                 jiangpintype = "一等奖"
									             }
									             else if (data.prizetype == 2) {
									                 jiangpintype = "二等奖"
									             }
									             else if (data.prizetype == 3) {
									                 jiangpintype = "三等奖"
									             }
									             $("#result").html("恭喜，您中得" + jiangpintype + "!");
									             $("#prize1").html(jiangpintype);
									             $("#sncode").html(data.sn);
									             $("#zjl").show(500);


									         } else {
									             $("#result").html("很遗憾,您没能中奖!");

									         }
									     });
									 }
							);
    });
}

$(function () {
    $(".eggList li").click(function () {
        $(this).children("span").hide();
        eggClick($(this));
    });

    $(".eggList li").hover(function () {
        var posL = $(this).position().left + $(this).width();
        $("#hammer").show().css('left', posL);
    })
});
/////砸金蛋........................................end