$(function(){
	var myselfObj={
		init:function(){
			this.render();
		},
		render:function(){
			$('#foot ul li').eq(2).addClass('clickOn').siblings().removeClass('clickOn');
            $("a[name='con']").eq(2).addClass("on");
		}
	}
	myselfObj.init();
})
