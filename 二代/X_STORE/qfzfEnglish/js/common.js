$(function() {
	var $wrapBox = $("#wrapBox");
	var windowWidth = $(window).width();
	var init = {//初始化对象属性
		".b1_01": {
			top: 415,
			opacity: 0
		},
		".b1_02": {
			//left: (1920 - windowWidth)/2 - 709,
			left: 300,
			opacity: 0
		},
		".b1_03": {
			top: 250,
			opacity: 0
		},
		".b1_03_btn": {
			//opacity: 0
		},
		".b1_04": {
			//top: 800
		},
		".b2_01": {
			top: 800,
			left: -200,
			opacity: 0
		},
		".b2_02": {
			left: 1100,
			opacity: 0
		},
		".b2_07": {
			left: 860,
			opacity: 0
		},
		".b2_03": {
			//top: 70,
			//opacity: 0
		},
		".b3_tl": {
			opacity: 0
		},
		".b3_01": {
			left: 480,
			opacity: 0
		},
		".b3_02": {
			left: 1065,
			opacity: 0
		},
		".b3_03": {
			left: 1135,
			opacity: 0
		},
		".b3_04": {
			left: 1065,
			opacity: 0
		},
		".b3_05": {
			left: 480,
			opacity: 0
		},
		".b3_06": {
			left: 419,
			opacity: 0
		}
	}

	for (var i in init) {
		var $i = $wrapBox.find(i);
		for (var j in init[i]) {
			$i.css(j, init[i][j]);
		}
	}

	function boxGoIn_1() {
		$(".b1_01").stop().animate({top: 350, opacity: 1}, 1200);
		$(".b1_02").stop().animate({left: 365, opacity: 1}, 1200);
		$(".b1_03").stop().animate({top: 300, opacity: 1}, 1200, function() {
			$(".b1_03_btn").addClass('anima');
		});
		//$(".b1_04").stop().animate({top: 470}, 1200);
	}
	function boxGoOut_1() {
		$(".b1_02").stop().animate({left: 300, opacity: 0}, 500);
		$(".b1_03").stop().animate({top: 250, opacity: 0}, 500, function() {
			$(".b1_03_btn").removeClass('anima');
		});
		$(".b1_01").stop().animate({top: 415, opacity: 0}, 800);
		//$(".b1_04").stop().animate({top: 800}, 600);
	}

	function boxGoIn_2() {
		$(".b2_01").stop().animate({left: 130, top: 175, opacity: 1}, 1000, function() {
			$(".b2_02").stop().animate({left: 980, opacity: 1}, 1000);
			$(".b2_07").stop().animate({left: 980, opacity: 1}, 1000);
		});
		
		// var b2_03 = function() {
		// 	$(".b2_03").stop().animate({top: 30, opacity: 1}, 3000, function() {
		// 		$(".b2_03").stop().animate({top: 70}, 3000, function() {
		// 			b2_03();
		// 		})
		// 	})
		// };
		// b2_03();
	}
	function boxGoOut_2() {
		$(".b2_02").stop().animate({left: 1100, opacity: 0}, 800);
		$(".b2_07").stop().animate({left: 860, opacity: 0}, 800, function() {
			$(".b2_01").stop().animate({left: -200, top: 800, opacity: 0}, 800);
		});

		//$(".b2_03").stop().animate({opacity: 0}, 500);
	}

	var box3Timer;
	var box3Now;
	var box3Order = [[1, 2], [6, 3], [5,4]]
	function boxGoIn_3() {
		clearInterval(box3Timer);
		$(".b3_img").addClass("transform");
		$(".b3_tl").stop().animate({opacity: 1}, 1500);
		box3Now = 0;
		var aJson = [{left: 525, opacity: 1},
			{left: 1110, opacity: 1},
			{left: 1180, opacity: 1},
			{left: 1110, opacity: 1},
			{left: 525, opacity: 1},
			{left: 464, opacity: 1}
		];

		for (var i=0; i<box3Order[box3Now].length; i++) {
			$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 1000);
		}
		box3Timer = setInterval(function() {
			box3Now++;
			for (var i=0; i<box3Order[box3Now].length; i++) {
				$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 1000);
			}
			if (box3Now>=2) {
			 	clearInterval(box3Timer);
			}
			// $(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
			// if (box3Now>6) {
			// 	clearInterval(box3Timer);
			// }
		}, 1000);
	}
	function boxGoOut_3() {
		clearInterval(box3Timer);
		$(".b3_img").removeClass("transform");
		box3Now = 2;
		var aJson = [{left: 480, opacity: 0},
			{left: 1065, opacity: 0},
			{left: 1135, opacity: 0},
			{left: 1065, opacity: 0},
			{left: 480, opacity: 0},
			{left: 420, opacity: 0}
		];

		// $(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
		// box3Timer = setInterval(function() {
		// 	box3Now--;
		// 	$(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
		// 	if (box3Now<=1) {
		// 		$(".b3_tl").stop().animate({opacity: 0}, 500);
		// 		clearInterval(box3Timer);
		// 	}
		// }, 500);

		for (var i=0; i<box3Order[box3Now].length; i++) {
			$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 1000);
		}
		box3Timer = setInterval(function() {
			box3Now--;
			for (var i=0; i<box3Order[box3Now].length; i++) {
				$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 1000);
			}
			if (box3Now<=0) {
				$(".b3_tl").stop().animate({opacity: 0}, 1500);
			 	clearInterval(box3Timer);
			}
			// $(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
			// if (box3Now>6) {
			// 	clearInterval(box3Timer);
			// }
		}, 1000);
	}

	boxGoIn_1();//默认第一个
	// window.onscroll = function() {
	// 	var top = document.documentElement.scrollTop || document.body.scrollTop;//获取滚动条位置
	// 	top = top/1.5;
	// 	//$wrapBox.css({"top": -top+60});
	// 	$wrapBox.stop().animate({"top": -top+60}, 800, 'linear', function() {
	// 		if (top<=400) {
	// 			boxGoIn_1();
	// 			$(".nav a").removeClass("cur").eq(0).addClass("cur");
	// 		} else if (top>600) {
	// 			boxGoOut_1();
	// 		}
	// 		if (top>400 && top<1200) {
	// 			boxGoIn_2();
	// 			$(".nav a").removeClass("cur").eq(1).addClass("cur");
	// 		} else if (top>1400 || top<400) {
	// 			boxGoOut_2();
	// 		}
	// 		if (top>1200 && top<2000) {
	// 			boxGoIn_3();
	// 			$(".nav a").removeClass("cur").eq(2).addClass("cur");
	// 		} else if (top>2200 || top<1200) {
	// 			boxGoOut_3();
	// 		}
	// 	});//#wrap 滚动

	// 	scrollTop = top;
	// }
});
function boxGoIn_1() {
		$(".b1_01").stop().animate({top: 350, opacity: 1}, 1200);
		$(".b1_02").stop().animate({left: 365, opacity: 1}, 1200);
		$(".b1_03").stop().animate({top: 300, opacity: 1}, 1200, function() {
			$(".b1_03_btn").addClass('anima');
		});
		//$(".b1_04").stop().animate({top: 470}, 1200);
	}
	function boxGoOut_1() {
		$(".b1_02").stop().animate({left: 300, opacity: 0}, 500);
		$(".b1_03").stop().animate({top: 250, opacity: 0}, 500, function() {
			$(".b1_03_btn").removeClass('anima');
		});
		$(".b1_01").stop().animate({top: 415, opacity: 0}, 800);
		//$(".b1_04").stop().animate({top: 800}, 600);
	}

	function boxGoIn_2() {
		$(".b2_01").stop().animate({left: 130, top: 175, opacity: 1}, 800, function() {
		});
			$(".b2_02").stop().animate({left: 980, opacity: 1}, 1000);
			$(".b2_07").stop().animate({left: 980, opacity: 1}, 1000);
		
		// var b2_03 = function() {
		// 	$(".b2_03").stop().animate({top: 30, opacity: 1}, 3000, function() {
		// 		$(".b2_03").stop().animate({top: 70}, 3000, function() {
		// 			b2_03();
		// 		})
		// 	})
		// };
		// b2_03();
	}
	function boxGoOut_2() {
		$(".b2_02").stop().animate({left: 1100, opacity: 0}, 300);
		$(".b2_07").stop().animate({left: 860, opacity: 0}, 300);
		$(".b2_01").stop().animate({left: -200, top: 800, opacity: 0}, 500);

		//$(".b2_03").stop().animate({opacity: 0}, 500);
	}

	var box3Timer;
	var box3Now;
	var box3Order = [[1, 2], [6, 3], [5,4]]
	function boxGoIn_3() {
		clearInterval(box3Timer);
		$(".b3_img").addClass("transform");
		$(".b3_img").stop().animate({opacity: 1}, 1500);
		$(".b3_tl").stop().animate({opacity: 1}, 1500);
		box3Now = 0;
		var aJson = [{left: 525, opacity: 1},
			{left: 1110, opacity: 1},
			{left: 1180, opacity: 1},
			{left: 1110, opacity: 1},
			{left: 525, opacity: 1},
			{left: 464, opacity: 1}
		];

		for (var i=0; i<box3Order[box3Now].length; i++) {
			$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 600);
		}
		box3Timer = setInterval(function() {
			box3Now++;
			for (var i=0; i<box3Order[box3Now].length; i++) {
				$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 600);
			}
			if (box3Now>=2) {
			 	clearInterval(box3Timer);
			}
			// $(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
			// if (box3Now>6) {
			// 	clearInterval(box3Timer);
			// }
		}, 500);
	}
	function boxGoOut_3() {
		clearInterval(box3Timer);
		//$(".b3_img").removeClass("transform");
		$(".b3_img").stop().animate({opacity: 0}, 1500, function() {
			$(".b3_img").removeClass("transform");
		});
		box3Now = 2;
		var aJson = [{left: 480, opacity: 0},
			{left: 1065, opacity: 0},
			{left: 1135, opacity: 0},
			{left: 1065, opacity: 0},
			{left: 480, opacity: 0},
			{left: 420, opacity: 0}
		];

		// $(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
		// box3Timer = setInterval(function() {
		// 	box3Now--;
		// 	$(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
		// 	if (box3Now<=1) {
		// 		$(".b3_tl").stop().animate({opacity: 0}, 500);
		// 		clearInterval(box3Timer);
		// 	}
		// }, 500);

		for (var i=0; i<box3Order[box3Now].length; i++) {
			$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 300);
		}
		box3Timer = setInterval(function() {
			box3Now--;
			for (var i=0; i<box3Order[box3Now].length; i++) {
				$(".b3_0" + box3Order[box3Now][i]).stop().animate(aJson[box3Order[box3Now][i]-1], 300);
			}
			if (box3Now<=0) {
				$(".b3_tl").stop().animate({opacity: 0}, 1500, function() {});
			 	clearInterval(box3Timer);
			}
			// $(".b3_0" + box3Now).stop().animate(aJson[box3Now-1], 500);
			// if (box3Now>6) {
			// 	clearInterval(box3Timer);
			// }
		}, 500);
	}

	boxGoIn_1();