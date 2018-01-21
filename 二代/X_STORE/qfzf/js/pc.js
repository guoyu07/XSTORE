//导航
$(function(){
  $('.nav_toggle').click(function(){
        if($(".nav_bg1").css("left")!=="0px")
	    {$(".nav_bg1").stop().animate({left:"0%"},200);} 
	    else{
	 	close_slide()
	    }
  })
    
  function close_slide(){
	    $(".nav_bg1").stop().animate({left:"-32%"},200);
	
  }
  
  $("*").bind("click",function(e){
		var target = $(e.target);
		if(target.closest(".slide_l").length == 0){
		close_slide()
	    }
  }) 
  
  $(document).scroll(function(){
	if($(document).scrollTop()>300)
    {close_slide()}
  })
  
   $(window).resize(function(){
    var a=$(window).width();
	if(a>1000)
	{close_slide()}
   
   })
  
})






