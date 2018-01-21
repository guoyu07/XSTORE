	$(function(){
		$(".nyMainTA a").click(function(){
			var id2=$(this).attr("id");
			if(id2 && id2.indexOf("btn2_")==0)
				mainHotSaleShow2(id2.replace("btn2_",""));
		})
	});
	function mainHotSaleShow2(_id2){
		$(".nyMainCAC").not("#"+_id2).hide();
		$("#"+_id2).show();
		$("#btn2_main4LBtn1").removeClass("nyMainASel");
		$("#btn2_main4LBtn2").removeClass("nyMainASel");
		$("#btn2_main4LBtn3").removeClass("nyMainASel");
		$("#btn2_main4LBtn4").removeClass("nyMainASel");
		$("#btn2_main4LBtn5").removeClass("nyMainASel");
		$("#btn2_main4LBtn6").removeClass("nyMainASel");
		$("#btn2_"+_id2).addClass("nyMainASel");
	}