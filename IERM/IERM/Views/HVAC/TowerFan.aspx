<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="TowerFan.aspx.cs" Inherits="IERM.Views.HVAC.TowerFan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/HVAC/TowerFan.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Monitoring runat="server" ID="Monitoring" />
    <div class="introImg vertical">
        <div class="ImgWarp">
            <img src="/img/HVAC/tfj.png" class="tfjImg">
            <span class="statu yx lqt"></span>
            <span class="statu yx zlj1"></span>
            <span class="statu tz zlj2"></span>
            <span class="circle ciryx circle1"></span>
            <span class="circle cirtz circle2"></span>
            <span class="circle ciryx circle3"></span>
            <a class="number number1"><span class="bottomSsd">20.0</span>℃</a>
            <a class="number number2"><span class="bottomMpa">0.02</span>MPa</a>
            <a class="number number3"><span class="topMpa">0.02</span>MPa</a>
            <a class="number number4"><span class="topSsd">30.0</span>℃</a>
        </div>
    </div>
    <div class="wordIntroLeft">
        <ul class="wordIntroUl">
            <li class="wordIntroLi">
                <a class="wordIntroA">环境温度：<span class="temper footertag">48.7</span>℃</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">环境湿度：<span class="shidu footertag">14.6</span>RH%</a>
            </li>
        </ul>
    </div>
    <div class="wordIntroMid">
        <p class="firstP">电源合闸状态：<span class="hz footertag">合闸</span></p>
        <a class="leftA">制冷机控制柜</a>
        <ul class="wordIntroUl midLeft">
            <li class="wordIntroLi">
                <a class="wordIntroA">AB线电压：<span class="ab footertag">380.2</span>V</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">BC线电压：<span class="bc footertag">380.2</span>V</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">CA线电压：<span class="ca footertag">380.2</span>V</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">&nbsp;功率因数：<span class="glys footertag">0.99</span></a>
            </li>
        </ul>
        <ul class="wordIntroUl midRight">
            <li class="wordIntroLi">
                <a class="wordIntroA">A线电流：<span class="dlA footertag">150.1</span>A</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">B线电流：<span class="dlB footertag">150.1</span>A</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">C线电流：<span class="dlC footertag">150.1</span>A</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">有功电能：<span class="glys footertag">50.2</span>KW•h</a>
            </li>
        </ul>
    </div>
    <div class="wordIntroRight">
        <p class="firstP">电源合闸状态：<span class="hz footertag">合闸</span></p>
        <a class="leftA">冷冻泵控制柜</a>
        <ul class="wordIntroUl midLeft">
            <li class="wordIntroLi">
                <a class="wordIntroA">AB线电压：<span class="ab footertag">380.2</span>V</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">BC线电压：<span class="bc footertag">380.2</span>V</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">CA线电压：<span class="ca footertag">380.2</span>V</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">&nbsp;功率因数：<span class="glys footertag">0.99</span></a>
            </li>
        </ul>
        <ul class="wordIntroUl midRight">
            <li class="wordIntroLi">
                <a class="wordIntroA">A线电流：<span class="dlA footertag">150.1</span>A</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">B线电流：<span class="dlB footertag">150.1</span>A</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">C线电流：<span class="dlC footertag">150.1</span>A</a>
            </li>
            <li class="wordIntroLi">
                <a class="wordIntroA">有功电能：<span class="glys footertag">50.2</span>KW•h</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript">
        (function () {
            $(".introImg").css("height", "72%");
            $(".wordWarp").css("height", "21.4%");
        })();
    </script>
</asp:Content>
