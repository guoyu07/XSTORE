$(function(){
  $('.nav li:last').css("background","none")
})

$(function(){
  $('.inleft ul li:last').css("background-image","url(images/inleftbottom.jpg)"),
  $('.inleft ul li:last').css("height","20px")
})

$(function(){
  $(".nosub").css({display:"none"});
$("#sub1").show();
$("#sub2").show();
$(".submenu > dl > div > dt:first").addClass("nyNav1");
$(".submenu > dl > div > dt").bind("click",function(){
	if($(this).hasClass("nyNav1")){
        $(this).parent().find("dd").hide("slow"); 
        $(".submenu > dl > div > dd").removeClass("nosub");
		$(this).removeClass("nyNav1");		
	}else
	{
        $(".submenu > dl > div > dd").hide("fast");
        $(this).parent().find("dd").show("slow"); 
        $(".submenu > dl > div > dd").addClass("nosub");
		$(".submenu > dl > div > dt").removeClass("nyNav1");
		$(this).addClass("nyNav1");
	}
        })
$(".submenu > dl > div > dd").bind("click",function(){
        $(".submenu > dl > div > dd").addClass("nosub");
        $(this).removeClass("nosub");
        $(this).addClass("has");
        $(this).children().find("ul").show("slow");
        })
$(".submenu > dl > div > dd > ul > li").bind("click",function(){
        $(".submenu > dl > div > dd > ul > li").removeClass("this");
        $(this).addClass("this");
        })
    

})
