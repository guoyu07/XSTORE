<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistriBution_head.ascx.cs" Inherits="Wx_NewWeb.Talk.DistriBution_head" %>

<div class="t_head">
    <div class="wrap">
        <div class="back"><i class="icons" onclick="GoBack()"></i></div>
        <h3 class="title"><%=page %></h3>
        <div class="home_tb"><i class="icons" onclick="Home()"></i></div>
    </div>
</div>


<script>
    function GoBack() {
        history.go(-1);
    }

    function Home() {
        location.href = "index2.aspx";
    }
</script>





