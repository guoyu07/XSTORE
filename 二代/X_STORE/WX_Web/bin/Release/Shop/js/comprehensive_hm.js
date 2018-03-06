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
			$('.user ul').on('click','li',function(){
				$(this).toggleClass('showContent').find('dl').toggle();
			});
			$('.user input').on('blur',function(){
				//$.get('',{},function(){})
			})
		},
		getData:function(){
			
		}
	};
	goodsListObj.init();
})