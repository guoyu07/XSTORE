 $(function(){

    function close_slide(){
	    $(".nav_bg1").css({"left":"-32%"});
    } 
	
   
	$('.nav_toggle').on('click',function(){

	    if($(".nav_bg1").css("left")!=="0px")
	    {$(".nav_bg1").css({"left":"0%"});} 
	    else{
	 	close_slide()
	    }
		return false;
	})
    
	$("*").on('click',function(e){
		var target = $(e.target);
		if(target.closest(".slide_l").length == 0){
		close_slide()
	    }
    }) 
 
    
 
 })
    




	
	