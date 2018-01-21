<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Better.aspx.cs" Inherits="Wx_NewWeb.Shop.pages.Better" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="UTF-8">
	    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
	    <link rel="stylesheet" type="text/css" href="../css/reset.css"/>
	    <link rel="stylesheet" type="text/css" href="../css/mui.min.css"/>			
		<title>幸事多私享空间-改善点</title>
		<style type="text/css">
			#betterBox {
			    width: 100%;
			    background-color: #fff;
			}
			#betterBox .mui-segmented-control.mui-segmented-control-inverted .mui-control-item.mui-active {
			    color: #FE8355;
			    border-bottom: 2px solid #FF5C12;
			    border-bottom-width: 50%;
			}
			.betterBoxControlContents{
				width: 100%;
				margin-top: 10px;
			}	
			#betterBoxControlContents .chevronList{
				padding-right: 15px;
				font-size: 14px;
			}
			#betterBoxControlContents .chevronList span{
				line-height: 31px;
			}
			#betterBoxControlContents .chevronList input{
				border: none;
				color: #fff;
				background-color: #FF5001;
				font-size: 14px;
				margin-left: 15px;
			}
			#betterBoxControlContents .mui-table-view-cell .title{
				font-size: 14px;
				color: #000000;
			}
			#betterBoxControlContents .mui-table-view-cell .mui-navigate-right{
				font-size: 14px;
				color: #000000;
			}
			#OtherHomeListPopOver{
				width: 90%;
				margin-left: 5%;
				height: 400px;
				background-color: #fff;
			}
			._table{
				width: 100%;
				background-color: #fff;
			}
			._table tbody tr th{
				padding:10px 8px;
				border-bottom: 1px solid #ddd;
				text-align: center;
				font-size: 15px;
			}
			._table tbody tr td{
				padding:10px 8px;
				border-bottom: 1px solid #ddd;
				text-align: center;
				font-size: 14px;
			}
			.popTitle{
				padding: 10px 15px;
				font-size: 16px;
				border-bottom: 1px solid #ddd;
			}
		</style>
</head>
<body>
    <form id="form1" runat="server">
   <div id="betterBox">
			<div id="betterControl" class="mui-slider-indicator mui-segmented-control mui-segmented-control-inverted ">
				<a class="mui-control-item mui-active" id="house" href="#content1">房间</a>
				<a class="mui-control-item" id="product" href="#content2">产品</a>
			</div>
		</div>	
<div id="betterBoxControlContents" class="betterBoxControlContents">
			<div id="content1" class="mui-control-content mui-active">         
				<ul class="mui-table-view mui-table-view-chevron">
					<li class="mui-table-view-cell mui-collapse">
						<a class="mui-navigate-right title" href="#">30天无销售</a>
						<ul class="mui-table-view mui-table-view-chevron">
							<li class="mui-table-view-cell chevronList">
								<span class="mui-pull-left">1501</span>
								<input type="button" value="换房" class="mui-pull-right"/>
							</li>
							<li class="mui-table-view-cell chevronList">
								<span class="mui-pull-left">1502</span>
								<input type="button" value="换房" class="mui-pull-right"/>
							</li>
							<li class="mui-table-view-cell chevronList">
								<span class="mui-pull-left">1503</span>
								<input type="button" value="换房" class="mui-pull-right"/>
							</li>
						</ul>
					</li>
					<li class="mui-table-view-cell mui-collapse">
						<a class="mui-navigate-right title" href="#">其他房间</a>
						<ul class="mui-table-view mui-table-view-chevron">
							<li class="mui-table-view-cell OtherHomeList">
								<a class="mui-navigate-right" href="#"><span class="mui-pull-left">1501</span></a>							
							</li>
							<li class="mui-table-view-cell OtherHomeList">
								<a class="mui-navigate-right" href="#"><span class="mui-pull-left">1502</span></a>
							</li>
							<li class="mui-table-view-cell OtherHomeList">
								<a class="mui-navigate-right" href="#"><span class="mui-pull-left">1503</span></a>
							</li>
						</ul>
					</li>
				</ul>				
			</div>
			<div id="content2" class="mui-control-content">	
	         <!--
		       	作者：995564763@qq.com
		       	时间：2017-06-02
		       	描述：顶部切换栏产品对应内容
	      	 -->				
				<ul class="mui-table-view mui-table-view-chevron">
					<li class="mui-table-view-cell mui-collapse">
						<a class="mui-navigate-right title" href="#">30天无销售</a>
						<ul class="mui-table-view mui-table-view-chevron">
							<li class="mui-table-view-cell chevronList">
								<span class="mui-pull-left">1501</span>								
								<input type="button" value="单价申请" class="mui-pull-right"/>
								<input type="button" value="换产品" class="mui-pull-right"/>
							</li>
							<li class="mui-table-view-cell chevronList">
								<span class="mui-pull-left">1502</span>					
								<input type="button" value="单价申请" class="mui-pull-right"/>
								<input type="button" value="换产品" class="mui-pull-right"/>
							</li>
							<li class="mui-table-view-cell chevronList">
								<span class="mui-pull-left">1503</span>					
								<input type="button" value="单价申请" class="mui-pull-right"/>
								<input type="button" value="换产品" class="mui-pull-right"/>
							</li>
						</ul>
					</li>
					<li class="mui-table-view-cell mui-collapse">
						<a class="mui-navigate-right title" href="#">其他房间</a>
						<ul class="mui-table-view mui-table-view-chevron">
							<li class="mui-table-view-cell OtherHomeList">
								<a class="mui-navigate-right" href="#"><span class="mui-pull-left">1501</span></a>							
							</li>
							<li class="mui-table-view-cell OtherHomeList">
								<a class="mui-navigate-right" href="#"><span class="mui-pull-left">1502</span></a>
							</li>
							<li class="mui-table-view-cell OtherHomeList">
								<a class="mui-navigate-right" href="#"><span class="mui-pull-left">1503</span></a>
							</li>
						</ul>
					</li>
				</ul>
			</div>
			
			<div id="OtherHomeListPopOver" class="mui-popover">
				<div class="mui-scroll-wrapper">
				    <div class="mui-scroll">
				    	<div class="mui-popup-title popTitle">
				    		房间记录
				    	</div>
					    <table border="" cellspacing="" cellpadding="" class="_table">
					      <tr>							  
						      <th>商品名</th>
						      <th>单价</th>
						      <th>箱号</th>
						      <th>时间</th>
					   	  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
						  <tr>
						    <td>白雪公主</td>
						    <td>¥ <span>99.98</span></td>
						    <td><span>10</span></td>
						    <td>2017-06-02</td>
						  </tr>
					    </table>
					</div>
				</div>
			</div>
		</div>	
		
		<script src="../js/plugins/mui.min.js" type="text/javascript" charset="utf-8"></script>
		<script type="text/javascript">
			var OtherHomeListPopOver = document.getElementById("OtherHomeListPopOver");
			OtherHomeListPopOver.style.height = screen.height * 0.6 + 'px';
			OtherHomeListPopOver.style.bottom = screen.height * 0.15 + 'px';
			mui('body').on('tap','.OtherHomeList',function(){
				mui('#OtherHomeListPopOver').popover('toggle');
			})
			mui('.mui-scroll-wrapper').scroll();
		</script>


    </form>
</body>
</html>
