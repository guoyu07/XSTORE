<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageBuy.aspx.cs" Inherits="Tuan.PageBuy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>立即购买</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-status-bar-style" content="default" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <link href="css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script language="javascript" src="js/swipe.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" src="js/menu_min.js"></script>
    <script src="jquery-1.7.min.js" type="text/javascript"></script>
    <script src="js/Area.js" type="text/javascript"></script>
    <script src="js/AreaData_min.js" type="text/javascript"></script>
    
    <link href="css/checkbox.css" rel="stylesheet" type="text/css" />
   
    <style type="text/css">
        .show {
            display: block;
            width: 96%;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
     <%-- <script type="text/javascript">
          // 对浏览器的UserAgent进行正则匹配，不含有微信独有标识的则为其他浏览器
          var useragent = navigator.userAgent;
          if (useragent.match(/MicroMessenger/i) != 'MicroMessenger') {
              // 这里警告框会阻塞当前页面继续加载
              alert('已禁止本次访问：您必须使用微信内置浏览器访问本页面！');
              // 以下代码是用javascript强行关闭当前页面
              var opened = window.open('about:blank', '_self');
              opened.opener = null;
              opened.close();
          }
</script>--%>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js"></script>
    <script type="text/javascript">//2015年7月13日 20:55:03 微信分享JSSDK
        $(function () {
        
            wx.config({
                debug: false,// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: "<%=appid%>", // 必填，公众号的唯一标识 wx752aa82143c09a8a
                timestamp: '<%=timestamp%>', // 必填，生成签名的时间戳
                nonceStr: '<%=nonceStr%>', // 必填，生成签名的随机串
                signature: '<%=signature%>',// 必填，签名，见附录1
                jsApiList: ['checkJsApi','onMenuShareTimeline', 'onMenuShareAppMessage']
            });     // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
   
    

            wx.ready(function () {
                //1 判断当前版本是否支持指定 JS 接口，支持批量判断
               
                wx.checkJsApi({
                    jsApiList: ['checkJsApi', 'onMenuShareTimeline', 'onMenuShareAppMessage'],

                });

            <%--   var link = "http://hongdou.creatrue.net/index.aspx?attach=::" + '<%=spbh%>';
                var imgUrl = "http://hongdou.creatrue.net" + '<%=pic%>';--%>

                wx.onMenuShareTimeline({
                    title: '<%=title%>', //
                    link: "http://hongdou.creatrue.net/tuan/index.aspx?attach=::"+"<%=spbh%>:"+"<%=wxid%>",
                    imgUrl: "http://hongdou.creatrue.net"+"<%=picurl%>"
                });


                wx.onMenuShareAppMessage({
                    title: '<%=title%>', //<%=title%>
                    desc: "<%=title%>", //
                    link: "http://hongdou.creatrue.net/tuan/index.aspx?attach=::"+"<%=spbh%>:"+"<%=wxid%>",
                    imgUrl: "http://hongdou.creatrue.net"+"<%=picurl%>",
                    type: 'link',

                });
            });
        });
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $(".menu ul li").menu();
            $("#aaa").removeClass("active").addClass("inactive");
        });
    </script>

    <script> 
        $(function () {
            //initComplexArea('seachprov', 'seachcity', 'seachdistrict', area_array, sub_array, '32', '3202', '0');
            addressInit('cmbProvince', 'cmbCity', 'cmbArea', '江苏', '无锡市', '崇安区');
        });

       
    </script>

    <script type="text/javascript">

        //调用微信JS api 支付
        function jsApiCall()
        {
            
            var openid='<%=pinopen %>';
            var ddbh='<%=ddbh %>';
            var otheropenid='<%=otheropenid%>';
            var otherddbh='<%=otherddbh%>';
            var name=$("#name").val();
            var tel=$("#tel").val();
            var spbh = '<%=spbh %>';
            var dzid = $("#ddddid").val();
    
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'PaySQL.ashx', //目标地址
                data: { openid: openid, ddbh: ddbh, spbh: spbh, name: name, tel: tel,otheropenid:otheropenid,otherddbh:otherddbh,dzid:dzid},
                error: function (msg) { },
                success: function (msg) {
                    
                    if(msg=="请完善收获地址！")
                    {
                        alert(msg);
                        return;
                    }
                    else if(msg.length>0)
                    {
                        //  alert("成功"+msg);
                      
                        WeixinJSBridge.invoke(
                         'getBrandWCPayRequest',
                          <%=wxJsApiParam%>,//josn串
                        function (res)
                        {
                           
                            if(res.err_msg=="get_brand_wcpay_request:cancel")
                            {
                                alert("用户取消了订单");
                                return;
                            }
                            else if(res.err_msg=="get_brand_wcpay_request:ok")
                            {
                                var lx='<%=lx%>';
                         
                                if(lx=="2")
                                {
                                    $.ajax({
                                        type: "POST", //用POST方式传输
                                        dataType: "text", //数据格式:JSON
                                        url: 'Pay.ashx', //目标地址
                                        data: { msg: msg, type: "13" },
                                        //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                                        success: function (msg2) {
                   
                                            window.location.href="DingInfo.aspx?attach="+msg+"";
                                            window.event.returnValue = false;
                                            WeixinJSBridge.log(res.err_msg);
                                        }
                                    });
                                }
                                else
                                {
                                   
                                    $.ajax({
                                        type: "POST", //用POST方式传输
                                        dataType: "text", //数据格式:JSON
                                        url: 'Pay.ashx', //目标地址
                                        data: { msg:msg,type:"13"},
                                        //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                                        success: function (msg2) {
                                            
                                            window.location.href=msg2;
                                            window.event.returnValue = false;
                                            WeixinJSBridge.log(res.err_msg);
                                        }
                                    });
                                
                                }
                                
                            }
  
                        }
                       
                        ); 
                          
                    }
                    //else
                    //{
                    //    alert('失败'+msg);
                    //}
                }
            });
               
    }

    function callpay()
    {
        if (typeof WeixinJSBridge == "undefined")
        {
            if (document.addEventListener)
            {
                document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
            }
            else if (document.attachEvent)
            {
                document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
            }
        }
        else
        {
            jsApiCall();
        }
    }
               
    </script>


    <%-- 地址操纵2015.6.30 --%>
    <script type="text/javascript">




        $(function()
        {  
            $("#zitidizhi").hide();//自提地址

            $("#chk_ziti").removeClass("yesxz").addClass("noxz");

            $("#chk_kuaidi").removeClass("noxz").addClass("yesxz");

            $("#chk_ziti").click(function(){
                
                $("#chk_ziti").removeClass("noxz1").addClass("yesxz1");

                $("#chk_kuaidi").removeClass("yesxz1").addClass("noxz1");

                $("#zitidizhi").show() ;//自提地址
               
                
                $("#ddddid").val(0);
                $("#kuaididizhi").hide() ;//快递地址
                    
            });
            $("#chk_kuaidi").click(function(){

                $("#chk_ziti").removeClass("yesxz1").addClass("noxz");

                $("#chk_kuaidi").removeClass("noxz1").addClass("yesxz");
               
                $("#zitidizhi").hide() ;//自提地址
                
                $("#kuaididizhi").show() ;//快递地址
                gettop1();
              
            });

        });

        function gettop1()
        {
            var unionid='<%=unionid%>';
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'AddressTop.ashx', //目标地址
                data: { unionid: unionid,type:"info"},
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    $("#<%=lit_dizhi.ClientID%>").html(msg); 
                         
              
                        $.ajax({
                            type: "POST", //用POST方式传输
                            dataType: "text", //数据格式:JSON
                            url: 'AddressTop.ashx', //目标地址
                            data: { unionid: unionid,type:"id"},
                            //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                            success: function (msg) {
                               
                    $("#ddddid").val(msg);
              
                 
                }
                   });
                    }
         });
        }

        /// 切换收货地址
        function qiehuandizhi(id){ 
          
       
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'AddressQie.ashx', //目标地址
                data: { id: id},
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    $("#<%=lit_dizhi.ClientID%>").html(msg); 
                    $("#ddddid").val(id);
                    //refreshdizhi();
                 
                }
            });
            guan();
            
        }
        function refreshdizhi()
        {
            var unionid='<%=unionid%>';
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'RefreshDizhi.ashx', //目标地址
                data: { unionid: unionid},
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                   
                        $("#<%=lit_dizhiall.ClientID%>").html(msg); 
                   
           //         $("#dbtc2").fadeIn();
                    $('#dbtc2').animate({ bottom: '0px', opacity: 'show' }, 500, function () { $('#dbtc2').show(); });
                    $("#dbtc").hide();
                    $("#dbtc3").hide();
                }
             });
        }


        ////新增地址操作
        function shiyong()
        {   var openid='<%=pinopen %>';
            var ddbh='<%=ddbh %>';
            var ismoren=document.getElementById("ismoren");
            var name=$("#name").val();
            var tel=$("#tel").val(); 
            var address = $("#address").val();
            if(name==""||tel==""||address=="")
            {
                alert('请完善地址信息！');
                return;
            }
           
            var partten = /^1[3,5,8]\d{9}$/;
            if(partten.test(tel))
            {
               
            }
            else
            {
                alert('手机号格式不正确,请重新输入');
                $("#tel").val("");
                return;
                
            }
            
            var sheng = $("#cmbProvince").val();
            var shi = $("#cmbCity").val();
            var qu= $("#cmbArea").val();
          

            if(sheng==""||shi==""||qu=="")
            {
                alert('请选择省市区！');
                return;
            }
            var moren=0;
            
            
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'dizhi.ashx', //目标地址
                data: { openid: openid, ddbh: ddbh,  name: name, tel: tel, sheng: sheng, shi: shi, qu: qu,address:address,moren:moren,type:"add" },
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    if (msg>0) {
                         //var s= "<div class=\"shr clear\"><span class=\"fl\">收货人：" +name+ "</span><span class=\"fr\">" + tel + "</span></div><div class=\"shaddress\">收货地址：" +sheng+shi+qu+address+"</div>";
                        var  s = "<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + name + "</span><span class=\"tel\">" + tel + "</span></div><div class=\"bot_a\">收货地址：" + sheng + shi  +qu + address + "</div></div></div></div>";
                        $("#<%=lit_dizhi.ClientID%>").html(s); 
                         $("#ddddid").val(msg);  
                         $("#name").val("");
                         $("#tel").val(""); 
                         $("#address").val("");
                         alert("保存成功");
                        // refreshdizhi();
                        
                     <%--   $.ajax({
                            type: "POST", //用POST方式传输
                            dataType: "text", //数据格式:JSON
                            url: 'RefreshDizhi.ashx', //目标地址
                            data: { unionid: unionid},
                            //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                            success: function (msg) {
                                $("#<%=lit_dizhiall.ClientID%>").html(msg); 
                              
                                $("#dbtc2").fadeIn();
                                $("#dbtc").hide();
                            
                            }
                        });
                       --%>
                    }
                   
                }
            });
            guan();
        }
    </script>
        <script type="text/javascript">
            $(function () {
                $("#bg").hide();
                $("#dbtc").hide();
                $("#dbtc2").hide();
                $("#dbtc3").hide();
                });
           
            

    </script>
    <script>

        function guan()
        {
          
            $("#bg").hide();
            $("#dbtc").hide().css("bottom","-100px");
            $("#dbtc2").hide().css("bottom","-100px");
            $("#dbtc3").hide().css("bottom","-100px");
            //$('#dbtc').animate({ bottom: 'hide', opacity: 'hide' }, 500, function () { $('#dbtc').hide(); });
            //$('#dbtc2').animate({ bottom: 'hide', opacity: 'hide' }, 500, function () { $('#dbtc2').hide(); });
            //$('#dbtc3').animate({ bottom: 'hide', opacity: 'hide' }, 500, function () { $('#dbtc3').hide(); });

            //$('#dbtc2').animate({ bottom: '0px', opacity: 'hide' }, 500, function () { $('#dbtc2').hide(); });
            //$('#dbtc3').animate({ bottom: '0px', opacity: 'hide' }, 500, function () { $('#dbtc3').hide(); });

        }

        function xinzeng() {
           
                $("#dbtc3").hide();
                $("#dbtc2").hide();
                //$("#dbtc").fadeIn();
                $('#dbtc').animate({ bottom: '0px', opacity: 'show' }, 500, function () { $('#dbtc').show(); });
          
        }
        function edit(id)
        {
           
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'AddressPass.ashx', //目标地址
                data: { id: id},
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    var fen=msg.split(':');
                    $("#name1").val(fen[0]);
                    $("#tel1").val(fen[1]);
                    //$("#sheng").val(fen[2]);
                    addressInit('cmbProvince1', 'cmbCity1', 'cmbArea1', fen[2], fen[3], fen[4]);
                    //$("#shi").val(fen[3]);
                 //   $("#qu").val(fen[4]);
                    $("#address1").val(fen[5]);
                    var moren = document.getElementById("switch-on");
                    if(fen[6]=="0")
                    {
                        moren.checked=false;
                    }
                    else
                    {
                        moren.checked=true;
                    }
                    $("#editid").val(id);
                    $("#dbtc").hide();
                    $("#dbtc2").hide();
                  //  $("#dbtc3").fadeIn();
                    $('#dbtc3').animate({ bottom: '0px', opacity: 'show' }, 500, function () { $('#dbtc3').show(); });
                }
          });
        }

        function tc()
        {
            if($("#bg").css("display")=="block")
            {
                $("#bg").hide();
                $("#dbtc").hide();
                $("#dbtc2").hide();
                $("#dbtc3").hide();
                //$('#dbtc').animate({ bottom: '500px', opacity: 'hide' }, 0, function () { $('#dbtc').hide(); });
                //$('#dbtc2').animate({ bottom: '500px', opacity: 'hide' }, 0, function () { $('#dbtc2').hide(); });
                //$('#dbtc3').animate({ bottom: '500px', opacity: 'hide' }, 0, function () { $('#dbtc3').hide(); });
            }
            else
            {
                var id= $("#ddddid").val();
               
                if(id==""||id==0)
                {
                    $("#bg").show();
                    $("#dbtc2").hide();
                    $("#dbtc3").hide();
                  //  $("#dbtc").fadeIn();
                    $('#dbtc').animate({ bottom: '0px', opacity: 'show' }, 500, function () { $('#dbtc').show(); });
                   
                }
                else
                {  
                    refreshdizhi();
                    $("#bg").show();
              //  $("#dbtc2").fadeIn();
                $('#dbtc2').animate({ bottom: '0px', opacity: 'show' }, 500, function () { $('#dbtc2').show(); });
                    $("#dbtc3").hide();
                    $("#dbtc").hide();
            
                }
               
            }
        }

        function editbtn()
        {
         
            var openid='<%=pinopen %>';
            var ddbh='<%=ddbh %>';
            var ismoren=document.getElementById("switch-on");
            var name=$("#name1").val();
            var tel=$("#tel1").val(); 
            var address = $("#address1").val();
            if(name==""||tel==""||address=="")
            {
                alert('请完善地址信息！');
                return;
            }
           
            var partten = /^1[3,5,8]\d{9}$/;
            if(partten.test(tel))
            {
               
            }
            else
            {
                alert('手机号格式不正确,请重新输入');
                $("#tel1").val("");
                return;
                
            }
            
            var sheng = $("#cmbProvince1").val();
            var shi = $("#cmbCity1").val();
            var qu= $("#cmbArea1").val();
          

            if(sheng==""||shi==""||qu=="")
            {
                alert('请选择省市区！');
                return;
            }
            var moren=0;
            if(ismoren.checked=true)
            {
                moren=1;
            }
            var id= $("#editid").val();
            
          
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'dizhi.ashx', //目标地址
                data: {id:id, openid: openid, ddbh: ddbh,  name: name, tel: tel, sheng: sheng, shi: shi, qu: qu,address:address,moren:moren,type:"edit" },
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                    if (msg>0) {
                        var  s = "<div class=\"address_list\"><div class=\"wrap padd_10\"><div class=\"yuana\" ><div class=\"top_a clear\"><span class=\"name\">收货人：" + name + "</span><span class=\"tel\">" + tel + "</span></div><div class=\"bot_a\">收货地址：" + sheng + shi  +qu + address + "</div></div></div></div>";
                        
                      //  var s= "<div class=\"shr clear\"><span class=\"fl\">收货人：" +name+ "</span><span class=\"fr\">" + tel + "</span></div><div class=\"shaddress\">收货地址：" +sheng+shi+qu+address+"</div>";
                        $("#<%=lit_dizhi.ClientID%>").html(s); 
                        $("#ddddid").val(msg);  
                        $("#name1").val("");
                        $("#tel1").val(""); 
                        $("#address1").val("");
                        alert("修改成功");
                       
                        refreshdizhi();
                
                        
                    }
                   
                }
            });
        
        }
        function delbtn()
        {
            var id= $("#editid").val();
            var openid='<%=pinopen %>';
          
            $.ajax({
                type: "POST", //用POST方式传输
                dataType: "text", //数据格式:JSON
                url: 'dizhi.ashx', //目标地址
                data: {id:id,openid:openid, type:"del" },
                //error: function (XMLHttpRequest, textStatus, errorThrown) { },
                success: function (msg) {
                     
             
                        $("#<%=lit_dizhi.ClientID%>").html(msg); 
                        $("#name1").val("");
                        $("#tel1").val(""); 
                        $("#address1").val("");
                        alert("删除成功");
                       
                        refreshdizhi();
                
                 
                   
                }
            });
        }

    </script>
    
 
    <script src="js/jsAddress.js"></script>
</head>
<body>
    <form runat="server">
        
                <div class="order_messgae">
                                      <div class="addresszy">
            <a href="javascript:;" id="close">
                <div id="bg"></div>
            </a>
            <div id="dbtc" class="dbtc_g">
                <div id="xinzeng" class="wrap">
                                                            <div class="title_address"><span>收货地址</span><a href="javascript:;" onclick="guan()">×</a></div>
                    <ul class="cont conts clear">
                        <li class="clear">
                            <label>收货人</label><input type="text" id="name" runat="server" class="name" /></li>
                        <li class="clear">
                            <label>联系电话</label><input type="text" id="tel" runat="server" class="tel" /></li>
                        <li class="clear">
                            <label>选择地区</label><select id="cmbProvince"></select><select id="cmbCity"></select><select id="cmbArea"></select></li>
                        <li class="clear">
                            <label>地址</label><input type="text" id="address" runat="server" class="add" /></li>
                       <%-- <li class="clear">
                            <label>邮编：</label><input type="text" id="ub" runat="server" class="ub" /></li>--%>
                      </ul>
                          <%-- <div class="address_more clear">
                               <label class="default">设为默认地址</label>
                            <div class="onoffswitch greensea">
                      <input type="checkbox" name="onoffswitch" class="onoffswitch-checkbox" id="switch-on" checked="" />
                      <label class="onoffswitch-label" for="switch-on">
                        <span class="onoffswitch-inner"></span>
                        <span class="onoffswitch-switch"></span>
                         </label>
                                </div>
                       <!--     <input type="checkbox" id="ismoren" value="是否设为默认地址" />-->
                        </div>--%>
                        <div class=" btn_address_add clear">
                            <input type="button" class="btn_address" id="btn_shiyong" value="保存" onclick="shiyong()" />
                        </div>
                   
                </div>
            </div>
            <div id="dbtc2"  class="dbtc_g">
                <div id="liebiao" class="wrap">
               <div class="title_address"><span>收货地址</span><a href="javascript:;" onclick="guan()">×</a></div>
                    <ul class="adlist clear">
                        <asp:Label ID="lit_dizhiall" runat="server"></asp:Label>
                         </ul>
                        <div class="btn_address_add clear">
                            <input type="button" class="btn_address" id="btnadd" value="新增" onclick="xinzeng()" />
                        </div>
                   
                </div>
            </div>
                                <!---->
             <div id="dbtc3"  class="dbtc_g">
                <div id="xiugai" class="wrap">
                                        <div class="title_address"><span>修改收货地址</span><a href="javascript:;" onclick="guan()">×</a></div>
                    <ul class="cont conts  clear">
                        <li class="clear">
                            <label>收货人</label><input type="text" id="name1" runat="server" class="name" /></li>
                        <li class="clear">
                            <label>联系电话</label><input type="text" id="tel1" runat="server" class="tel" /></li>
                        <li class="clear">
                            <label>选择地区</label><select id="cmbProvince1"></select><select id="cmbCity1"></select><select id="cmbArea1"></select></li>
                
                        <li class="clear">
                            <label>详细地址</label><input type="text" id="address1" runat="server" class="add" /></li>
                        </ul>
                        <div class="address_more clear">
                            <label class="default">设为默认地址</label>
                           <div class="onoffswitch greensea">
                      <input type="checkbox" name="onoffswitch" class="onoffswitch-checkbox" id="switch-on"   />
                      <label class="onoffswitch-label" for="switch-on">
                        <span class="onoffswitch-inner"></span>
                        <span class="onoffswitch-switch"></span>
                      </label>
                    </div>
                       <input type="hidden" id="editid" value="" />
                           <!-- <input type="checkbox" id="ismoren1" value="是否设为默认地址" />-->
                        </div>
                          
                        <div class=" btn_address_add clear">
                         
                            <input type="button" class="btn_address" id="btn_edit" value="修改" onclick="editbtn()" />
                        </div>
                         <div class=" btn_address_add clear">
                            <input type="button" class="btn_address" id="btn_del" value="删除" onclick="delbtn()" />
                        </div>
                   
                </div>
            </div>



        </div>
            <div class="wrap padd_10">
                <div class="title">收货信息</div>
                <div class="menu">

                    <%-- </div>
            </div>
        </div>

        <div class="hei_15"></div>
        <div class="order_messgae">
            <div class="wrap padd_10">--%>
                    <div class="title clear">
                        <%--<input id="chk_ziti" type="radio" name="chk" />&nbsp;自提&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="chk_kuaidi" name="chk" type="radio" checked />&nbsp;快递--%>
                        <span id="chk_ziti">自提</span><span id="chk_kuaidi">快递</span>
                    </div>
                    <div id="zitidizhi" class="we_buy2 clear"><%=sjdz %></div> <!--自提地址-->
                    <div id="kuaididizhi" onclick="tc()">
                        <asp:Label ID="lit_dizhi" runat="server"></asp:Label><input type="hidden" id="ddddid" runat="server" /></div>
               

<%--                    <ul id="caonima">
                        <li class="list_cj"><a id="xuanze" href="javascript:;">选择其他地址</a>
                            <ul id="iscont" class="cont clear ad_li">
                                <asp:Literal ID="lit_dizhiall" runat="server"></asp:Literal>
                            </ul>
                        </li>
                        <br />

                        <li class="list_cj"><a id="xinzeng" href="javascript:;">新增收货地址</a>
                            <ul class="cont conts clear">
                                <li class="clear">
                                    <label>* 姓名：</label><input type="text" id="name" runat="server" class="name" /></li>
                                <li class="clear">
                                    <label>* 手机：</label><input type="text" id="tel" runat="server" class="tel" /></li>
                                <li class="clear">
                         
                                    <label>* 省份：</label><select id="cmbProvince"></select></li>
                                <li class="clear">
                                    <label>* 城市：</label><select id="cmbCity"></select></li>
                                <li id="seachdistrict_div" class="clear">
                                    <label>* 区镇：</label><select id="cmbArea"></select></li>
                                <li class="clear">
                                    <label>* 地址：</label><input type="text" id="address" runat="server" class="add" /></li>
                                <li class="clear">
                                    <label>邮编：</label><input type="text" id="ub" runat="server" class="ub" /></li>
                                <li class="clear">
                                    <input type="button" id="btn_shiyong" value="保存" onclick="shiyong()" />
                                </li>
                            </ul>
                        </li>
                    </ul>--%>
                </div>
            </div>
            </div>
         <div class="hei_15"></div>
        <div class="order_messgae">
            <div class="wrap padd_10">
                <div class="title">订单信息</div>
              <%=spinfo %>

                <div class="price"><span>合计：</span><strong>¥ <%=price %></strong></div>
            </div>
        </div>
        <div class="hei_15"></div>
 
            <div class="order_messgae">
                <div class="wrap padd_10">
                    <div class="title">支付方式</div>
                    <!--满送规则-->
                    <asp:Literal ID="lt_jian" runat="server" ></asp:Literal> 
                    <!--优惠券规则--> 
                    <asp:Literal ID="lt_quan" runat="server" ></asp:Literal>  
                    <!--微信支付-->
                    <asp:Literal ID="lt_wxpay" runat="server" ></asp:Literal> 
                    <!--<div class="we_buy clear"><a href="javascript:;">微信支付</a></div>-->

                </div>
            </div>
            <div class="hei_15 m_15"></div>

            <div class="bott">
                <div class="wrap padd_10 clear">
                    <div class="buy_bt2 fr">
                        <input type="button" id="tijiao" runat="server" value="提交订单" onclick="jsApiCall()" />

                    </div>
                </div>
            </div>

         

    </form>
</body>
</html>
