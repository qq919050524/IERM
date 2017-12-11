<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="MonitorWater.aspx.cs" Inherits="IERM.Views.MonitorWater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="../css/9beng/9.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group">
                            <span class="input-group-addon">角色筛选：</span>
                            <select class="form-control">
                                <option value="0" selected>全部</option>
                                <option value="0" selected>全部</option>
                                <option value="0" selected>全部</option>
                            </select>
                        </div>
                        <div class="input-group" style="margin-left: 30px;">
                            <span class="input-group-addon">昵称筛选：</span>
                            <input type="text" class="form-control" placeholder="昵称关键字">
                        </div>
                        <button id="serach" type="button" class="btn btn-info" style="margin-left: 20px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                        <button id="adduser" type="button" class="btn btn-success" style="margin-left: 20px;" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span>添加</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="index">
                <div class="container-16">
                    <div class="subcontainer">
                        <!--警报-->
                        <div class="warn">
                            <p class="warnp"><span class="warnImg"></span>X<span class="warnNum">3</span></p>
                        </div>
                        <!--水泵-->
                        <div class="shuibeng">
                            <div class="shui">
                                <img src="../img/9beng/bac.png" class="bengImg">
                                <!--高区供水-->
                                <span class="highTem temperature">000.0</span>
                                <span class="highTagOne tag yx"></span>
                                <span class="highTagTwo tag yx"></span>
                                <span class="highTagThree tag yx"></span>

                                <!--中区供水-->
                                <span class="midTem temperature">000.0</span>
                                <span class="midTagOne tag yx"></span>
                                <span class="midTagTwo tag yx"></span>
                                <span class="midTagThree tag yx"></span>

                                <!--低区供水-->
                                <span class="downTem temperature">000.0</span>
                                <span class="downTagOne tag yx"></span>
                                <span class="downTagTwo tag yx"></span>
                                <span class="downTagThree tag yx"></span>
                                <!--水箱温度-->
                                <span class="tank">000.0</span>
                            </div>

                        </div>
                        <div class="introduce">
                            <!--颜色提示-->
                            <div class="colorTip">
                                <a class="tzTip"><span class="tzImg"></span>停止</a>
                                <a class="yxTio"><span class="yxImg"></span>运行</a>
                                <a class="gzTip"><span class="gzImg"></span>故障</a>
                            </div>
                            <div class="introDetail">
                                <ul class="ulOne">
                                    <li>
                                        <a>环境温度：<span class="hjwd spanReg">48.7</span>℃</a>
                                    </li>
                                    <li>
                                        <a>环境湿度：<span class="hjsd spanReg">14.6</span>RH%</a>
                                    </li>
                                    <li>
                                        <a>生活水箱液位：<span class="shsxyw spanReg">1.5</span>m</a>
                                    </li>
                                </ul>
                                <ul class="ulFour">
                                    <li>
                                        <a>电合闸状态：<span class="dhz spanReg">合闸</span></a>
                                    </li>
                                    <li>
                                        <a>有功电能：<span class="ygdn spanReg">1.25</span>kW•h</a>
                                    </li>
                                    <li>
                                        <a>功率因数：<span class="glys spanReg">0.99</span></a>
                                    </li>

                                </ul>
                                <ul class="ulTwo">

                                    <li>
                                        <a>AB线电压：<span class="ab spanReg">380.2</span>V</a>
                                    </li>
                                    <li>
                                        <a>BC线电压：<span class="bc spanReg">380.2</span>V</a>
                                    </li>
                                    <li>
                                        <a>CA线电压：<span class="ca spanReg">380.2</span>V</a>
                                    </li>
                                </ul>
                                <ul class="ulThree">
                                    <li>
                                        <a>A线电流：<span class="axdl spanReg">48.7</span>A</a>
                                    </li>
                                    <li>
                                        <a>B线电流：<span class="bxdl spanReg">14.6</span>A</a>
                                    </li>
                                    <li>
                                        <a>C线电流：<span class="cxdl spanReg">1.5</span>A</a>
                                    </li>

                                </ul>

                                <ul class="ulFive">
                                    <li>
                                        <a>市政供水压力：<span class="szgsyl spanReg">0.42</span>MPa</a>
                                    </li>
                                    <li>
                                        <a>低区供水压力：<span class="dqgsyl spanReg">0.61</span>MPa</a>
                                    </li>
                                    <li>
                                        <a>中区供水压力：<span class="zqgsyl spanReg">0.93</span>MPa</a>
                                    </li>
                                </ul>
                                <ul class="ulSix">
                                    <li>
                                        <a>高区供水压力：<span class="gqgsyl spanReg">1.21</span>MPa</a>
                                    </li>
                                    <li>
                                        <a>超高区供水压力：<span class="cgqgsyl spanReg">1.45</span>MPa</a>
                                    </li>
                                </ul>
                                <div style="clear: both;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script>
        var heights = $(window).height();
        var introheights = $(".introDetail").height();
        var conheights = $(".container-fluid").height();
        $(".index").css("padding-bottom", heights - 171 + "px");
        $(".shui").css("padding-bottom", heights - 216 - introheights + "px");
        //$(".shui").css("padding-bottom", conheights - introheights + "px");
        $(window).resize(function () {
            var heights = $(window).height();
            var introheights = $(".introDetail").height();
            $(".index").css("padding-bottom", heights - 171 + "px");
            $(".shui").css("padding-bottom", heights - 216 - introheights + "px");
            //$(".shui").css("padding-bottom", conheights - introheights + "px");
        })
    </script>
</asp:Content>
