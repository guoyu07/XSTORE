
var XMLHttp = {
    _objPool: [],
    _getInstance: function ()
    {
        for (var i = 0; i < this._objPool.length; i ++)
        {
            if (this._objPool[i].readyState == 0 || this._objPool[i].readyState == 4)
            {
                return this._objPool[i];
            }
        }
       
        this._objPool[this._objPool.length] = this._createObj();
        return this._objPool[this._objPool.length - 1];
    },
    _createObj: function ()
    {
        var objXMLHttp  = false;
		if (window.XMLHttpRequest)
        {
            objXMLHttp = new XMLHttpRequest();
        }
        else
        {
            var MSXML = ['MSXML2.XMLHTTP.5.0', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP', 'Microsoft.XMLHTTP'];
            for(var n = 0; n < MSXML.length; n ++)
            {
                try
                {
                    objXMLHttp = new ActiveXObject(MSXML[n]);
                    break;
                }
                catch(e)
                {
                }
            }
         }          
		if (!objXMLHttp) { // 
			window.alert("can't open objXMLHttp.");
			return false;
		}
        if (objXMLHttp.readyState == null)
        {
            objXMLHttp.readyState = 0;
            objXMLHttp.addEventListener("load", function ()
                {
                    objXMLHttp.readyState = 4;
                    if (typeof objXMLHttp.onreadystatechange == "function")
                    {
                        objXMLHttp.onreadystatechange();
                    }
                },  false);
        }
        return objXMLHttp;
    },
   
    sendReq: function (method, url, data, callback)
    {
        var objXMLHttp = this._getInstance();
        with(objXMLHttp)
        {
            try
            {
             
                if (url.indexOf("?") > 0)
                {
                    url += "&randnum=" + Math.random();
                }
                else
                {
                    url += "?randnum=" + Math.random();
                }
                open(method, url, true);
              
                setRequestHeader('Content-Type', 'application/x-www-form-urlencoded; charset=gb2312');
                send(data);
                onreadystatechange = function ()
                {
                    if (objXMLHttp.readyState == 4 && (objXMLHttp.status == 200 || objXMLHttp.status == 304))
                    {
                        callback(objXMLHttp);
                    }
                }
            }
            catch(e)
            {
                alert(e);
            }
        }
    }
}

    function findfood(_key)
    {
       XMLHttp.sendReq('GET', 'search.ashx?keyword='+escape(_key)+'&type=0&ipage=1', '', findfood2);
    }
	function findfood2(obj)
	{
		var str=obj.responseText;
		if(str!="")
		{
			testLB.innerHTML=str;
		}
	}
	function fenye(_type,_ipage,_keyword)
	{
		XMLHttp.sendReq('Get', 'search.ashx?keyword='+escape(_keyword)+'&type='+_type+'&ipage='+_ipage, '', findfood2);
	}	
	function AddtoCart(_guid)
	{
		XMLHttp.sendReq('get', 'addCart.ashx?guid='+_guid, '', AddtoCart2);
	}
	function AddtoCart2(obj)
	{
		var str = obj.responseText;
		//alert(str);
		if (str!="")
		{			
			orderForm_content.innerHTML=str;
		}
	}
	function Update(_guid,_N)
	{
		XMLHttp.sendReq('get', 'UpdateCart.ashx?guid='+_guid+'&gnum='+_N, '', AddtoCart2);
	}
	function Del(_guid)
	{
		XMLHttp.sendReq('get', 'DelCart.ashx?guid='+_guid, '', AddtoCart2);
	}
	function SubmitCart()
	{
			with(document.form1)
			{
				if(username.value=="")
				{
					alert("很显然,您必须告诉我们收货人.");
					return;
				}
				else if(useraddr.value=="")
				{
					alert("很显然,您必须告诉我们送货地址。");
					return;
				}
				else if(usertel.value=="")
				{
					alert("您难道不想告诉我们您的电话号码吗？");
					return;
				}
				else 
				{		
				
					var _usercity="";
					if(usercity[0].checked)
					{
						_usercity="无锡";
					}
					else if (usercity[1].checked)
					{
						_usercity="苏州";
					}
					else if(usercity[2].checked)
					{
						_usercity="其他";
					}
				//订单确认处理过程
						if(confirm("先生(女士),您好！您确定购买这些商品吗？"))
						{
						//	alert("hell0");
							XMLHttp.sendReq('get', 'saveCart.ashx?username='+transLetter(username.value)+'&useraddr='+transLetter(useraddr.value)+'&usercity='+_usercity+'&usertel='+transLetter(usertel.value)+'&usermsg='+transLetter(usermsg.value),'', submitCart2);
						}
						else
						{
							alert("您取消了订单.");
						}				
				}
			}
	}
	function checkCart()
	{		
		XMLHttp.sendReq('get', 'checkCart.ashx','', checkCart2);
	}
	function checkCart2(obj)
	{
			var str = obj.responseText;
			if(str=="1")
			{
				alert("您还没有选购任何商品喔。小提示：您可以直接从左边选购您想要的商品.");					
			}
			else if(str=="2")
			{
				alert("您的订单金额不能低于50元.");	
			}
			else
			{
					SubmitCart();
			}		
	}
	function submitCart2(obj)
	{
		var str =  obj.responseText;
		if (str=="1")
		{
			alert("恭喜，您的订单已经成功提交！我们将在第一时间为您送达，谢谢!!!");
			location.reload();
		}
		else if(str=="2")
		{
			alert("写入订单表失败");
		}
		else
		{
			alert("写入订单明细表订购失败。");
		}
	}
	function transLetter(s)
	{
		var re=/\'/g;
		var re1=/\"/g;
		s=s.replace(re,"&acute;");
		s=s.replace(re1,"&quot;");
		return escape(s);
	}
    function changeMenuCss(th)
	{
			var obj = document.getElementById('mainMenu');  //.getElementsByTagName("ul");
			obj=obj.getElementsByTagName("ul")[0];
			//obj = obj.getElementsByTagName("li");
			//obj.className="normal";
			for(var tmpi=0;tmpi<obj.getElementsByTagName("li").length;tmpi++)
			{
				obj.getElementsByTagName("li")[tmpi].className="normal";
			}				
		th.className="curr_menu";
	}
	function changeProCss(_type,th)
	{
		if(_type==1)
			th.className="pro_mouseover";
		else
			th.className="pro_mouseout";
	}
	function showpic(_guid,th)
	{
		 var e = event || window.event, x = e.clientX+document.documentElement.scrollLeft, y = e.clientY+document.documentElement.scrollTop;
		  var o = th, xx=0, yy = 0;
		  while(o!=null){
		   xx += o.offsetLeft;
		   yy += o.offsetTop;
		   o = o.offsetParent;
		  }
        var x = xx + 120;
        var y =yy - 20;
		
		document.getElementById("float").style.display = "";
		document.getElementById("float").style.left=x + "px";
		document.getElementById("float").style.top=y + "px";
		var obj=document.getElementById("float").getElementsByTagName("img")[0];
		obj.src="/product/"+_guid+".jpg";
		//document.getElementById("float").getElementsByTagName("img")[0].style.src="/product/"+_guid+".jpg";
	}
	function hiddenpic(_guid)
	{
		//setTimeout(function(){document.getElementById("float").style.display="none"},10);
		document.getElementById("float").style.display="none";
	}