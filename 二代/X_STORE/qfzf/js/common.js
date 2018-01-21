//下拉
$(function(){
    $('.selects li').each(function(){
	   if($(this).find('.slids a:first').hasClass('select'))
	   {return;}
	   else{$(this).find('.shows').css("color","#f08200")}
	})
	$(".selects li .shows").click(function(){
	   $(this).parent('div').parent('li').siblings('li').find('.slids').hide();
	   $(this).parent('div').parent('li').siblings('li').find('.shows').css("background-position","122px 21px");
	   if($(this).next('.slids').is(":hidden"))
	   {$(this).css("background-position","122px -79px");$(this).next('.slids').stop().slideDown()}
	   else
	   {$(this).css("background-position","122px 21px");$(this).next('.slids').stop().slideUp()}
    })
	$(document).bind("click",function(e){
		var target = $(e.target);
		if(target.closest("li").length == 0){
		$(".selects li .slids").hide();
		$(".selects li .shows").css("background-position","122px 21px")
		}
	}) 
	
	
})
