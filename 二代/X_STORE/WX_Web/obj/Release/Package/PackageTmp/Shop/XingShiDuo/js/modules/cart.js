$(function(){
	var cartObj={
		init:function(){
			this.render();
			this.bindEvent();
			this.getData();
		},
		render:function(){
			$('#foot ul li').eq(1).addClass('clickOn').siblings().removeClass('clickOn');
		},
		bindEvent:function(){
			var that=this;
			$('.editor').on('click',function(){
				$('.del').show();
				$(this).hide();
				$('.finish').show();
			});
			$('.finish').on('click',function(){
				$(this).hide();
				$('.editor').show();
				$('.del').hide();
			});
			$('.goodsBox').on('click','li .del',function(){
				var me=this;
				layer.open({
					content:'是否删除该商品？',
					btn:['确认','取消'],
					yes:function(index){
						$(me).parent().remove();
						layer.close(index);
						that.isEmpty();
					}
				})
			});
		},
		isEmpty:function(){
			console.log($('.goodsBox').children());
			if($('.goodsBox').children().length==0){
				$('.hasGoods').hide();
				$('.empty').show();
				$('.editor').show();
				$('.finish').hide();
			}else{
				$('.hasGoods').show();
				$('.empty').hide();
			}
		},
		getData:function(){

		}
	};
	cartObj.init();
})