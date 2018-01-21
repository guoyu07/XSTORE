var allTime = 30;
var tt;
//猜谜出题
function GetMiyu(_acID, _wwv,_guid) {
    //alert("hello");
    //获取谜语题目
    $.ajax({
        async: true,
        cache: false,
        global: true,
        timeout: 120000,
        contentType: 'application/x-www-form-urlencoded',

        type: 'POST',
        url: "GetMiYu.ashx",
        dataType: 'text',
        data: { "acID": _acID, "wwv": _wwv,"guid": _guid },
        beforeSend: function () {
            //显示等待层 
            var _x = $(document.body).offset().left - 10;
            var _y = $(document.body).offset().top - 2;
            $(".waiting").css("top", _y).css("left", _x).show(100);
        },
        success: function (data) {
            //alert(data);
            if (data != "") {
                var data2 = eval("(" + data + ")");
                //alert(data2.IDs);
                $("#h_tID").val(data2.IDs);
                $("#lt_cm_title").val(data2.Title);
                timer(); //开始计时
            }
        },
        complete: function () {
            $(".waiting").hide();
        }
    });
}

//答题
function anSwerMiYu() {
    //获取谜语题目
    //alert("hello");
    $.ajax({
        async: true,
        cache: false,
        global: true,
        timeout: 120000,
        contentType: 'application/x-www-form-urlencoded',

        type: 'POST',
        url: "AnswerMiYu.ashx",
        dataType: 'text',
        data: { "acID": $("#h_acID").val(), "wwv": $("#h_WWV").val(), "tID": $("#h_tID").val(), "tAnswer": $("#lt_cm_answer").val(), "guid": $("#h_guid").val() },
        beforeSend: function () {
            //显示等待层 
            var _x = $(document.body).offset().left - 10;
            var _y = $(document.body).offset().top - 2;
            $(".waiting").css("top", _y).css("left", _x).show(100);
        },
        success: function (data2) {
            //alert(data2);
            if (data2 != "") {
                var data = eval("(" + data2 + ")");
                if (data.code == "OKOKOK") {
                    //答对三道题
                    alert(data.msg);
                    //alert("honor_action2.aspx?wwx=" + $("#h_WWX").val() + "&wwv=" + $("#h_WWV").val() + "&acID=" + $("#h_acID").val());
                    location.href = "honor_action2.aspx?wwx=" + $("#h_WWX").val() + "&wwv=" + $("#h_WWV").val() + "&acID=" + $("#h_acID").val();
                }
                else if (data.code == "OK") {
                    //答对一道题
                    alert(data.msg);
                    //alert("honor_action2.aspx?wwx=" + $("#h_WWX").val() + "&wwv=" + $("#h_WWV").val() + "&acID=" + $("#h_acID").val());
                    
                    $("#lt_cm_answer").val("");
                    GetMiyu($("#h_acID").val(), $("#h_WWV").val(), $("#h_guid").val());
                }
                else {
                    alert(data.msg);
                    $("#mainPage").hide();
                    $("#btnRefresh").show();
                    //location.reload();
                }
            }
        },
        complete: function () {
            $(".waiting").hide();
        }
    });
}


function SayHello(_hello) {
    alert(_hello);
}

//SayHello("hello world"); 
function timer() {
    window.clearInterval(tt);
    allTime = 60;
    tt = window.setInterval(timerGo, 1000);
}
function timerGo()
{
    if(allTime <= 0) {
        window.clearInterval(tt);
        alert("时间到！猜谜失败，很遗憾~~~");
        $("#mainPage").hide();
        $("#btnRefresh").show();        
        return;
    }
    allTime--;
    $("#quion_timer").html(allTime);
}

