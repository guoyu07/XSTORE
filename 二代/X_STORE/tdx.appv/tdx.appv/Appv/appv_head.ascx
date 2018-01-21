<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="appv_head.ascx.cs" Inherits="tdx.appv.appv_head" %>
<div class="i_head">
    <ul>
        <asp:Literal ID="lt_menu" runat="server" EnableViewState="false"></asp:Literal>
    </ul>
       <div id="mcover" onclick="document.getElementById('mcover').style.display='';"><img src="/appv/images/icon_guide.png"></div>
</div>
<div class="i_Navigation" id="Navigation">
    <div class="i_arrow">
        ◆
    </div>
    <ul>
       <asp:Literal ID="lt_menu2" runat="server" EnableViewState="false"></asp:Literal>
    </ul>
</div>
     
