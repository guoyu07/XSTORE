// JavaScript Document
var nullimg = '../images/error.jpg';
function lod(t) {
    t.onerror = null;
    t.src = nullimg
}

$(document).ready(function () {
    $("img").each(function () {
        if ($(this).attr("src") == "") {
            $(this).attr({ "src": nullimg })
        }
    })
})

$(function(){
	$('.core_lists li:odd').addClass('odd');
	
	
	$(window).resize(function(){
		$(".tour_top_r_special").each(function(){
			var sub_dom=$(this).find("h4 a");
			var sub_width=sub_dom.width();
			sub_dom.text('');
			var sub_font=sub_dom.attr("title");
			sub_dom.text(sub_font);
			var sub_size=16;
			var objLength=sub_font.length;
			var font_count=Math.floor((sub_width/sub_size)*2);
			if(objLength > font_count){
			  sub_dom.text(sub_font.substr(0,font_count)+'...');
			}
	   })
	   
	   $("#tour_special li").each(function(){
			var sub_dom=$(this).find(".inner");
			var sub_width=$(this).find(".tour_top_l_special").width()-40;
			var sub_font=sub_dom.text();
			sub_dom.text(sub_font);
			var sub_size=16;
			var objLength=sub_font.length;
			var font_count=Math.floor((sub_width/sub_size)*5);
			if(objLength > font_count){
			  sub_dom.text(sub_font.substr(0,font_count)+'...');
			}
	   })
	   
	   $(".topic_inner .topic_list li").each(function(){
			var sub_dom=$(this).find(".text_box");
			var sub_width=sub_dom.width();
			var sub_font=$.trim(sub_dom.text());
			sub_dom.text(sub_font);
			var sub_size=15;
			var objLength=sub_font.length;
			var font_count=Math.floor((sub_width/sub_size)*3);
			if(objLength > font_count){
			  sub_dom.text(sub_font.substr(0,font_count)+'...');
			}
	   })
	   
	})
  $(window).resize();
})

$(function () {
    $('.table_list tr').each(function (index, element) {
        $(this).find('td:first').addClass('first');
    });



    $(".header .search_txt input").focus(function () {
        var email_txt = $(this).val();
        if (email_txt == this.defaultValue) {
            $(this).val("");
        }
    })
    $(".header .search_txt input").blur(function () {
        var email_txt = $(this).val();
        if (email_txt == "") {
            $(this).val(this.defaultValue);
        }
    })


    $(window).resize(function () {
        var bili = 1350 / 533;
        $(".view_box .list").css("height", $(window).width() / bili);

    })


    $(".honer_box li:nth-child(3n+1)").addClass("an");
    $(".honer_box li").eq(-3).addClass("an1");
    $(".honer_box li").eq(-2).addClass("an1");
    $(".honer_box li").eq(-1).addClass("an1");
    $(".partner_list li:last").addClass("last");

    $(".news_news ul li:nth-child(3n+1)").addClass("an");
    $(".news_news ul .tour_top_r_special").eq(-3).addClass("an1");
    $(".news_news ul .tour_top_r_special").eq(-2).addClass("an1");
    $(".news_news ul .tour_top_r_special").eq(-1).addClass("an1");



    $(".cases_special .tour_top_l_special").hover(function () {
        $(this).find(".t_hover").show()
    }, function () {
        $(this).find(".t_hover").hide()
    })



    $(".header .share .icon2").hover(function () {
        $(".header .show_wechat").show()
    }, function () {
        $(".header .show_wechat").hide()
    })


    $(".job_company li").mouseover(function () {
        var index = $(this).index();
        $(this).addClass("on").siblings().removeClass("on");
        $(".tab_box .tab_sub").eq(index).show().siblings().hide()
    })


    $(".core_tab span").mouseover(function () {
        //var index=$(this).index();
        //$(this).addClass("on").siblings().removeClass("on");
        //$(".core_box .core_list").eq(index).show().siblings().hide()
    })

    $(".service_menu .list li").mouseover(function () {
        var s_index = $(".service_menu .list li").index(this);
        $(this).addClass("on").siblings().removeClass("on");
        $(".service_slider .image img").eq(s_index).fadeIn().siblings().fadeOut();
        $(".service_cont li").eq(s_index).fadeIn().siblings().fadeOut();
    })

    $(".history .years").click(function () {
        $(".mouth_box").hide();
        $(".history .years").removeClass("on");
        $(this).addClass("on")
        $(this).next(".mouth_box").show()
    })







    function scroll_l_cul(obj) {
        var $self = obj.find("ul:first");
        if (!$self.is(":animated")) {
            var lineWidth = $self.find("li:first").outerWidth(true);
            $self.css({ marginLeft: -lineWidth });
            $self.find("li:first").before($self.find("li:last"))
            $self.animate({ "marginLeft": 0 + "px" }, 1000)
        }
    }

    function scroll_r_cul(obj) {

        var $self = obj.find("ul:first");
        if (!$self.is(":animated")) {
            var lineWidth = $self.find("li:first").outerWidth(true);
            $self.animate({ "marginLeft": -lineWidth + "px" }, 1000, function () {
                $self.css({ marginLeft: 0 }).find("li:first").appendTo($self);
            })
        }

    }


    var $autoFun;
    function autoSlide() {
        $(".ind_leader_list .next").trigger('click');
        $autoFun = setTimeout(autoSlide, 2000);
    }
    autoSlide();

    $(".ind_leader_list .prev").click(function () {

        scroll_l_cul($(".leader_list_box"))
    })

    $(".ind_leader_list .next").click(function () {
        scroll_r_cul($(".leader_list_box"))
    })



    $(window).resize();

    $('.menu_btn').bind('click', function () {

        if (!$(".nav").hasClass("show")) {
            $(".nav").addClass("show");
            return false;
        } else {
            $(".nav").removeClass("show");
        }
    });


    if ($(window).width() > 767) {

        var pop_w;
        var pop_h;
        var time1;
        var time2;
        var _this;
        var blank = $(".view_box").width() * 0.006;
        $(".view_box .list li .inner").hover(function () {

            pop_w = $(".view_box .list li.box1 .inner").outerWidth(true);
            pop_h = $(".view_box .list li.box1 .inner").outerHeight(true);
            pop_l = $(this).position().left + pop_w;

            clearTimeout(time1);
            $(".pop_box").hide();
            _this = $(this)


            if ($(this).parents("li").index() == 3) {
                _this.find(".pop_box").css({ "width": pop_w, "height": pop_h, "right": _this.width() + blank }).fadeIn();
            } else if ($(this).parents("li").index() == 5) {
                _this.find(".pop_box").css({ "width": pop_w, "height": pop_h, "right": _this.width() + blank }).fadeIn();
            } else {
                _this.find(".pop_box").css({ "width": pop_w, "height": pop_h, "left": _this.width() + blank }).fadeIn();
            }

        }, function () {
            time1 = setTimeout(function () {
                _this.find(".pop_box").hide();
            }, 400)
        })


        $(".view_box .list li .inner").find(".pop_box").hover(function () {
            clearTimeout(time1);
            $(this).show();
        }, function () {
            clearTimeout(time1);
            $(this).hide();
        })

        $(".view_box .list li").mouseover(function () {
            $(this).css("z-index", "9999").siblings().css("z-index", "10")
        })
    }




    if ($(window).width() > 767) {


        var time_nav1;
        var time_nav2;
        var _this_nav;
        $(".header_wrap .nav li > a ").hover(function () {
            clearTimeout(time_nav1);
            _this_nav = $(this);
            var drop = $(this).next(".drop");
            var top = $(".header_wrap .nav").height() + 5;
            var screen_width = $(document).width();
            var drop_width = $(".drop").width();
            var this_width = $(document).width() - $(this).offset().left;

            $(".header_wrap li .drop").hide()
            if (this_width > drop_width) {
                drop.css({ "left": $(this).offset().left, "top": top }).show();
            } else {
                drop.css({ "left": $(this).offset().left - drop_width + $(this).width(), "top": top }).show();
            }

        }, function () {

            time_nav1 = setTimeout(function () {

                _this_nav.next(".drop").hide();

            }, 400)


        })


        $(".header_wrap li .drop").hover(function () {
            clearTimeout(time_nav1);
            $(this).show();
        }, function () {
            clearTimeout(time_nav1);
            $(this).hide();
        })

    }


    if ($(window).width() < 767) {

        $(".header_wrap .nav .list li").click(function () {
            if (!$(this).children(".drop").is(":visible")) {
                $(this).addClass("on").siblings().removeClass("on");
                $(this).children(".drop").show().end().siblings().children(".drop").hide()
            } else {
                $(this).removeClass("on");
                $(this).children(".drop").hide()
            }
        })
    }
    //模拟下拉
    $(".select").each(function (i) {
        $(this).find("dt").click(function (e) {
            e.preventDefault();
            e.stopPropagation();
            $(this).parents("li").css("z-index", "1000").siblings("li").css("z-index", 1)
            $(".select").eq(i).find("dd").show();
            $(".select").eq(i).find("dd a").each(function (x) {
                $(this).click(function () {
                    $(".select").eq(i).find("dd a").removeClass("on")
                    $(this).addClass("on")
                    $(".select").eq(i).find("dt i").text($(this).text())
                    $(".select").eq(i).next(".select_hidden").val($(this).attr("data-val"))
                })
            })
        })
    })
    $(document).click(function () {
        $(".select dd").hide();
    })



    var gotop = $('<a  class="returnTop" href="javascript:;">top</a>').hide().appendTo(document.body);

    gotop.bind('click', function () {
        $('html,body').animate({
            scrollTop: 0
        });
        return false;
    });


    $(window).scroll(function () {
        var top = $(window).scrollTop();
        if (top > 100) {
            $(".returnTop").show();
        } else {
            $(".returnTop").hide();
        }
    });
	
	
	

})


$(function () {
    $('div.edit_con_original').map(function () {
        var $this = $(this);
        var edit_con_original = $this.html();
        if (edit_con_original != undefined) {
            var arr = new Array();
            arr = edit_con_original.split('<hr style="page-break-after:always;" class="ke-pagebreak">');
            var tempContent = '';
            var tempHref = '</div><div class=\"page\">';
            for (var i = 0; i < arr.length; i++) {
                tempContent += "<div class=\"edit_con_original_content\" style=\"display:" + (i == 0 ? "block" : "none") + "\">" + arr[i] + "</div>";
                tempHref += "<a class=\"a_con_original " + (i == 0 ? "on" : "") + "\" href=\"javascript:void(0);\">" + (i + 1) + "</a>";
            }
            $this.html(tempContent + (arr.length > 1 ? tempHref : ""));
            $(document).on('click', 'a.a_con_original', function () {
                $('div.edit_con_original_content').eq($('a.a_con_original').index($(this))).show().siblings().hide();
                $(this).addClass('on').siblings().removeClass('on');
                $('.page').show();
            });
        }
    });
})


$(function(){
	$(".text_box").each(function(){
		var description=$(this).text();
		var descriptLink=$(this).parent().find(".text_title a").attr("href");
		$(this).html("").append("<a href='"+descriptLink+"' target='_blank'></a>");
		$(this).find("a").text(description);
	})	
})


				