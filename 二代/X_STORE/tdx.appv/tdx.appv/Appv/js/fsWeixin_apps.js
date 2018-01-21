// JavaScript Document
$(function () {
    //获取更多商品
    $("#prolsit_more").click(function () {

        //获取更多商品
        $.ajax({
            async: true,
            cache: false,
            global: true,
            timeout: 120000,
            contentType: 'application/x-www-form-urlencoded',

            type: 'POST',
            url: "prolist.ashx",
            dataType: 'text',
            data: { "cno": $("#txtCno").val(), "page": $("#txtPage").val() },
            beforeSend: function () {
                //显示等待层 
                var _x = $("#prolsit_more").offset().left - 10;
                var _y = $("#prolsit_more").offset().top - 2;
                $(".waiting").css("top", _y).css("left", _x).show(100).html($(".waiting").html() + $("#txtCno").val() + ":" + $("#txtPage").val());
            },
            success: function (data) {
                //alert(data);
                if (data != "") {
                    //$("#Div_prolist").html($("#Div_prolist").html()+data);
                    $(data).appendTo($("#Div_prolist ul").eq($("#Div_prolist ul").length - 1));
                    var _h = ScollPostion().top + $(window).height();
                    $("html,body").animate({ scrollTop: (_h - 200) }, 1000);
                    $("#txtPage").val($("#txtPage").val() / 1 + 1);
                }
            },
            complete: function () {
                $(".waiting").hide();
            }
        });

    });
    $("#newslsit_more").click(function () {
        //执行ajax功能，加入购物车
        $.ajax({
            async: true,
            cache: false,
            global: true,
            timeout: 120000,
            contentType: 'application/x-www-form-urlencoded',

            type: 'POST',
            url: "newslist.ashx",
            dataType: 'text',
            data: { "cno": $("#txtCno").val(), "page": $("#txtPage").val(),"wwx": $().val() },
            beforeSend: function () {
                //显示等待层 
                //alert($("#txtCno").val());
                //alert($("#txtPage").val());
                var _x = $("#newslsit_more").offset().left - 10;
                var _y = $("#newslsit_more").offset().top - 2;
                $(".waiting").css("top", _y).css("left", _x).show(100);
            },
            success: function (data) {
                var sr = data;
                //alert(data);
                if (sr != "") {
                    var _h = ScollPostion().top + $(window).height();
                    //$("#Div_prolist").html($("#Div_prolist").html()+result);
                    $(sr).appendTo($("#Div_prolist ul").eq($("#Div_prolist ul").length - 1));
                    $("html,body").animate({ scrollTop: (_h - 200) }, 1000);
                    $("#txtPage").val($("#txtPage").val() / 1 + 1);
                }
            },
            error: function (XMLHttpRequest, textStatus) {
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
               // alert(textStatus);
            },
            complete: function () {
                $(".waiting").hide();
                //alert("hello");
            }
        });
    });
	$("#i_content_left").click(function(){
						
			var _width=$(".i_content ul li").width();
			var _num = $(".i_content ul li").size();
			var _width2 = $("#i_content_left").width();
			_width = (_width+10) * _num;
			 
			var _width_old=435;
			var _left = $(".i_content ul li").slice(0,1).offset().left;  
			_left = _left  - _width_old;

			alert(_left);
			 
			if(Math.abs(_left) > (_width - _width_old) )
			{
				 _left = _width_old - _width - _width2;
			}
			alert(_left);
			$(".i_content ul li").css("left", _left);  
	});
	$("#i_content_right").click(function(){
			var _width=$(".i_content ul").width();
			var _width_old=565;
			var _left = $(".i_content ul").css("margin-left");
			if( (_left + _width) <_width_old)
			{
				$(".i_content ul").css("margin-left",0);
			}
			else
		   {
				$(".i_content ul").css("margin-left",_left-_width_old);
		   }
	});
})
function addToCart(_id, _wwx) {
    //alert($("#proItemCart_orderNum_"+_id).val());
    //$("#ButtonDiv").load("addcart.ashx?guid=" + _id + "&qnt=" + $("#proItemCart_orderNum_"+_id).val()); 
    $.ajax({
        async: true,
        cache: false,
        global: true,
        timeout: 120000,
        contentType: 'application/x-www-form-urlencoded',

        type: 'POST',
        url: "addcart.ashx",
        dataType: 'text',
        data: { "guid": _id, "qnt": $("#proItemCart_orderNum_" + _id).val(), "WWX": _wwx },
        beforeSend: function () {
            //显示等待层 
            var _x = $("#btn_cart" + _id).offset().left - 10;
            var _y = $("#btn_cart" + _id).offset().top - 2;
            $(".waiting").css("top", _y).css("left", _x).show(100);
        },
        success: function (data) {
            if (data != "") {
                $("#btn_cart" + _id).parent().html(data);
                $("#proItemCart_orderNum_" + _id).parent().html("");
            }
        },
        complete: function () {
            $(".waiting").hide();
        }
    }); 
}
function ModToCart(_id) {
    //alert("orderCart_mod.ashx?guid=" + _id + "&gnum="+$("#proItemCart_orderNum_" + _id).val());
    $("#zj_cart").load("orderCart_mod.ashx?guid=" + _id + "&gnum=" + $("#proItemCart_orderNum_" + _id).val());
}
function DelToCart(_id) {
    $("#zj_cart").load("orderCartDel.ashx?guid=" + _id);
    $("#OrderItem_" + _id).remove();
}
function setOrderNum(_id, _gprice) {
    $('#xj_' + _id).html("￥" + fmoney($("#proItemCart_orderNum_" + _id).val() * _gprice, 2));
}
function clickMenu(th) {
    var _src = $('#' + th).attr("src");
    //alert(_src);
    if ($("#topMenu_sub").is(":hidden")) {
        $('#' + th).attr("src", _src.replace("menu_up.png", "menu_down.png"));
        var _x = $("#topMenu_img").offset().left - 86;
        //alert(_x);
        $("#topMenu_sub").css("left", _x).show();
    }
    else {
        $("#topMenu_sub").hide();
        $('#' + th).attr("src", _src.replace("menu_down.png", "menu_up.png"));
    }
}
/*******************************************************************

常用函数

********************************************************************/
function ScollPostion() {//滚动条位置
    var t, l, w, h;
    if (document.documentElement && document.documentElement.scrollTop) {
        t = document.documentElement.scrollTop;
        l = document.documentElement.scrollLeft;
        w = document.documentElement.scrollWidth;
        h = document.documentElement.scrollHeight;
    } else if (document.body) {
        t = document.body.scrollTop;
        l = document.body.scrollLeft;
        w = document.body.scrollWidth;
        h = document.body.scrollHeight;
    }
    return { top: t, left: l, width: w, height: h };
}

//var h =document.body.clientHeight;  //页面高度
//var c = scollPostion().top; //滚动条top
//var wh = $(window).height(); //页面可试区域高度
//var s = h - (c + wh);
//if (  s/h>0.7   ) {
////  loadings(); // 试试
//}

function transLetter(s) {
    var tr1 = /\'/g;
    var tr2 = /\"/g;

    s = s.replace(tr1, "");
    s = s.replace(tr2, "");
    //s=s.replace(tr1,"&actue;");
    //s=s.replace(tr2,"&quot;");			
    return s;
}
function fmoney(s, n) {
    n = n > 0 && n <= 20 ? n : 2;
    s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";
    var l = s.split(".")[0].split("").reverse(),
	   r = s.split(".")[1];
    t = "";
    for (i = 0; i < l.length; i++) {
        t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");
    }
    return t.split("").reverse().join("") + "." + r;
}
function rmoney(s) {
    return parseFloat(s.replace(/[^\d\.-]/g, ""));
}
function addfavorite() {
    if (document.all) {
        window.external.addFavorite(this.location.href, '微信网站');
    }
    else if (window.sidebar) {
        window.sidebar.addPanel('微信网站', this.location.href, "");
    }
}
function cartMod(th) {
    location.href = "orderCart_mod.ashx?gid=" + th + "&gnum=" + $("#g" + th).val();
}
function cartMod1(th) {
    location.href = "orderCart_mod.ashx?gid=" + th + "&gnum=" + ($("#g" + th).val() / 1 - 1);
}
function cartMod2(th) {
    location.href = "orderCart_mod.ashx?gid=" + th + "&gnum=" + ($("#g" + th).val() / 1 + 1);
}

function NavigationShow() {
    if ($("#Navigation").is(":hidden")) {
        $("#Navigation").show();
        $("#Navigation").offset({ left: ($("body").width() - $("#Navigation").width() - 16) / 2, top: $(".i_head").offset().top + 42 });
    }
    else {
        $("#Navigation").hide();
    }
}