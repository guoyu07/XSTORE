$(function(){
	var goodsListObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			
		},
		bindEvent:function(){
			$('.topNav li').on('click',function(){
				$(this).addClass('clickOn').siblings().removeClass('clickOn');
				var index=$(this).index();
				$('.item').eq(index).show().siblings().hide();
			});
		},
		getData:function(){
			
		}
	};
	goodsListObj.init();
})