// JavaScript Document
				var _height = 210;
                var _speed = [10, 15, 30];//必须是_height的约数
                var _stop = 0;
                var _run = 0;
                var _win;
                var roll = function() {
                        _run = 1;
                        var r = 0;
                        for(var i=0; i<3; ++i) {
                                var pos = $('#g'+i).position();
                                if((_stop==1 && pos.top%_height==0 && pos.top!=-210*_win[i]) || (_stop==2 && pos.top==-210*_win[i])) continue;
                                if(pos.top <= -10*_height) {
                                        pos.top = _speed[i];
                                }
                                $('#g'+i).css('top', pos.top-_speed[i]);
                                ++r;
                        }
                        if(r) window.setTimeout(roll, 10);
                        else _run = 0;
                };
                var start = function() {
                        _stop = 0;
                        if(!_run) window.setTimeout(roll, 10);
                };
                var stop = function() {
                        _stop = 1;
                        _win = [8, 8, 8];//中奖号码
                };
                var stop_win = function() {
                        _stop = 2;
                        _win = [7, 7, 7];//中奖号码
                }