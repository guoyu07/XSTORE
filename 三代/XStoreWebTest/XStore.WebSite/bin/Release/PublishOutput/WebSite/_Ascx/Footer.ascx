<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="XStore.WebSite.WebSite._Ascx.Footer" %>
<!--用户-->
<%@ Import Namespace="XStore.Entity" %>
<nav id="foot">
	<ul class="clearfix">
		<li style="width: 33%;">
			<a href='<%=Constant.JsGoodsDic+"GoodsList.aspx" %>'  name="con">
				<div class="index_bot">
					<img class="picOff" src="/Content/Images/mySpace.png" alt="" />
					<img class="picOn" src="/Content/Images/mySpace_on.png"/>
				</div>
				<p>私享空间</p>
			</a>
		</li>
		<li style="width:33%;">
			<a href="../Buyer/myself.aspx">
				<div class="index_bot">
					<img class="picOff" src="/Content/Images/myself.png" alt="" />
					<img class="picOn" src="/Content/Images/myself_on.png" alt=""/>
				</div>
				<p>我的</p>
			</a>
		</li>
		<li style="width: 33%;">
			<a href="../Buyer/x-store.aspx">
				<div class="index_bot">
					<img class="picOff" src="/Content/Images/xs.png" alt="" />
					<img class="picOn" src="/Content/Images/xs_on.png"/>
				</div>
				<p>操作指南</p>
			</a>
		</li>
	</ul>
</nav>