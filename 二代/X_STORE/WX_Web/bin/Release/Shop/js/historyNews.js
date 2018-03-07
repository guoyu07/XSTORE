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
			$('ul').on('click','li',function(){
				$(this).toggleClass('showContent').find('dl').toggle();
			});
		},
		getData:function(){

		}
	};
	goodsListObj.init();
})