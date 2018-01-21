$(function(){
	var goodsListObj={
		init:function(){
			this.render();
			this.bindEvent();
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
			var userPicker1 = new mui.PopPicker();
			var dataPackage1;
			//可选房间
			mui.ajax('http://x.x-store.com.cn:8092/Home/readyToChangeRooms',{
				data:{
					user_id:userId
				},
				dataType:'json',
				type:'get',
				success:function(result){
					if(result.state==1){
						dataPackage1=result.data;
						console.log(dataPackage1);
						userPicker1.setData(dataPackage1);
						mui('body').on('tap','.user input', function(event) {
							var result=this.lastElementChild;
							userPicker1.show(function(items) {
								result.innerText = items[0].text;
								result.setAttribute('data-id',items[0].value);
							});
						}, false);
					}else{
						layer.open({
							content:'数据获取失败',
							time:2,
						})
					}
				}
			});
		}
	};
	goodsListObj.init();
})