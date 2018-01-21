$(function(){
	var myselfObj={
		init:function(){
			this.render();
			this.bindEvent();
		},
		bindEvent:function(){
			$('.openBox').on('click',function(){
				$.ajax({
		    		url:'openbox.ashx',
		    		type:'get',
		    		data:{
		    			orderno:$('#order_lbl').text()
		    		},
		    		success:function(result){
		    			layer.open({
		    				 content: result,
		    				 time:2
		    			});
		    		}
		    	})
			});
			$('.goRefund').on('click',function(){
				$('.isRefund').show();
			});
			$('.isRefund').on('click',function(){
				$(this).hide();
			});
			$('.isRefund dl').on('click',function(event){
				event.stopPropagation();
			});
			$('.toRefund').on('click',function(){
				$('.isRefund').hide();
			  	layer.open({
			    	content: '亲~真的不要了吗？',
			    	btn: ['确认','取消',],
			    	yes: function(index){
				    layer.close(index);
				    	$.ajax({
				    		url:'tuikuan.ashx',
				    		type:'get',
				    		data:{
				    			orderno:$('#order_lbl').text()
				    		},
				    		success:function(result){
				    			layer.open({
				    				 content: result,
				    				 time:2
				    			});
				    		}
				    	})
				    }
			  	});
			});
		},
		render:function(){
			$('#foot ul li').eq(2).addClass('clickOn').siblings().removeClass('clickOn');
		}
	}
	myselfObj.init();
})
