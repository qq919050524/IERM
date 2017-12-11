<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="MonitorElectricity.aspx.cs" Inherits="IERM.Views.MonitorElectricity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="../css/bpd/bfb.css" rel="stylesheet" />
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
                    <div class="content">
                        <div class="eleve">
                            <a class="eleveDesk">11号柜</a>
                            <a class="elehe">合</a>
                            <a class="tenDesk">10号柜</a>
                            <a class="tenFa">
                                <img src="../img/bpd/tengui.jpg" class="tenFaImg" /></a>
                        </div>
                        <div class="twe">
                            <a class="tweDesk">12号柜</a>
                            <a class="twehe">合</a>
                            <a class="tenArr"></a>
                        </div>
                        <div class="thre">
                            <a class="threDesk">13号柜</a>
                            <a class="threhe">合</a>
                            <a class="threIco"></a>
                            <a class="wgbc">无功补偿</a>
                        </div>
                        <div class="redBorder">
                        </div>
                        <div class="centerBlock">
                            <a class="centerDesk">14号柜</a>
                            <ul class="bpdUl">
                                <li class="bpdLi">
                                    <a class="xfdt">2#楼消防电梯二</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">1#楼消防电梯一</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">2#楼消防电梯二</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">1#楼消防电梯二</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">2#楼消防电梯一</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">3#楼消防电梯二</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">3#楼消防电梯一</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">5#楼消防电梯二</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">5#楼消防电梯一</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                            </ul>
                        </div>
                        <div class="centerBlock">
                            <a class="centerDesk">15号柜</a>
                            <ul class="bpdUl">
                                <li class="bpdLi">
                                    <a class="xfdt">ECCM</a>
                                    <a class="bg"></a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">1#楼客梯(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">2#楼客梯(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">3#楼客梯(备供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">5#客梯</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">备用</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">备用</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">地下室应急照明一</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">备用</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                            </ul>
                        </div>
                        <div class="centerBlock">
                            <a class="centerDesk">16号柜</a>
                            <ul class="bpdUl">
                                <li class="bpdLi">
                                    <a class="xfdt">防火分区(一)消防</a>
                                    <a class="bg">负荷（主供）</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">防火分区(二)消防 </a>
                                    <a class="bg">负荷(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">防火分区(五)消防</a>
                                    <a class="bg">负荷(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">3#楼消防电梯(一)</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">排水泵(一）</a>
                                    <a class="bg">（备供）</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">幼儿园照明</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">备用</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">地下室照明（一）</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                            </ul>
                        </div>
                        <div class="centerBlock">
                            <a class="centerDesk">17号柜</a>
                            <ul class="bpdUl">
                                <li class="bpdLi">
                                    <a class="xfdt">备用</a>
                                    <a class="bg"></a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">1#楼公共照明</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">2#楼公共照明</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">3#楼公共照明</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">5#楼公共照明</a>
                                    <a class="bg">(备供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">醉江月电梯</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">1#商铺公共照明</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">幼儿园照明</a>
                                    <a class="bg"></a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">备用</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                            </ul>
                        </div>
                        <div class="centerBlock">
                            <a class="centerDesk">18号柜</a>
                            <ul class="bpdUl">
                                <li class="bpdLi">
                                    <a class="xfdt">汉口银行</a>
                                    <a class="bg"></a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">1#楼商铺照明一</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">1#楼商铺照明一</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt">3#楼营销中心</a>
                                    <a class="bg">(主供)</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">3#楼商铺照明</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">醉江月商铺一</a>
                                    <span class="ulHe status"></span>
                                    <span class="redArr"></span>
                                </li>
                                <li class="bpdLi">
                                    <a class="xfdt"></a>
                                    <a class="bg">备用</a>
                                    <span class="ulFen status"></span>
                                    <span class="redArr"></span>
                                </li>
                            </ul>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div class="introduce">
                        <ul class="ulOne">
                            <li>
                                <a>环境温度：<span class="hjwd spanReg">48.7</span>℃</a>
                            </li>
                            <li>
                                <a>环境湿度：<span class="hjsd spanReg">14.6</span>RH%</a>
                            </li>
                            <li>
                                <a>变压器温度：<span class="shsxyw spanReg">1.5</span>m</a>
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
                                <a>C线电流：<span class="cxdl spanReg">11.5</span>A</a>
                            </li>
                        </ul>
                        <ul class="ulFour">
                            <li>
                                <a>功率因数：<span class="glys spanReg">0.99</span></a>
                            </li>
                            <li>
                                <a>有功电能：<span class="ygdn spanReg">147172.5</span>kW•h</a>
                            </li>
                            <li>
                                <a>无功电能：<span class="ygdn spanReg">35031.5</span>kW•h</a>
                            </li>


                        </ul>
                        <div style="clear: both;">
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
