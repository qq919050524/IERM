<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="NtelligentLighting.aspx.cs" Inherits="IERM.Views.NtelligentLighting.NtelligentLighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/NtelligentLighting/NtelligentLighting.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Monitoring runat="server" ID="Monitoring" />
    <div class="introImg vertical">
        <div class="ImgWarp">
            <img src="/img/NtelligentLighting/light.png" class="lightImg">
            <img src="/img/NtelligentLighting/dark.png" class="darkImg" style="display: none;">
        </div>
        <span class="zmBtn">
            <img src="/img/NtelligentLighting/openBtn.png" class="opBtnImg"><img src="/img/NtelligentLighting/closeBtn.png" class="cloBtnImg " style="display: none;">
        </span>
    </div>
    <ul class="msUl">
        <li class="msLi">
            <a class="msWord"><span class="ms">
                <img src="/img/NtelligentLighting/yyt.png" class="msImg"></span>阴雨天模式</a>
        </li>
        <li class="msLi">
            <a class="msWord"><span class="ms">
                <img src="/img/NtelligentLighting/bw.png" class="msImg"></span>傍晚模式</a>
        </li>
        <li class="msLi">
            <a class="msWord"><span class="ms">
                <img src="/img/NtelligentLighting/yw.png" class="msImg"></span>夜晚模式</a>
        </li>
        <li class="msLi">
            <a class="msWord"><span class="ms">
                <img src="/img/NtelligentLighting/sy.png" class="msImg"></span>深夜模式</a>
        </li>
        <li class="msLi">
            <a class="msWord"><span class="ms">
                <img src="/img/NtelligentLighting/jjr.png" class="msImg"></span>节假日模式</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript">
        var flag = true;
        $(".zmBtn").click(function () {
            if (flag == true) {
                $(".opBtnImg").css("display", "none");
                $(".cloBtnImg").css("display", "block");
                $(".lightImg").css("display", "none");
                $(".darkImg").css("display", "block");
                flag = false;
            } else {
                $(".opBtnImg").css("display", "block");
                $(".cloBtnImg").css("display", "none");
                $(".darkImg").css("display", "none");
                $(".lightImg").css("display", "block");
                flag = true;
            }

        })
    </script>
</asp:Content>
