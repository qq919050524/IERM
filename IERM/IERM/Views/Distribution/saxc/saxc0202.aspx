<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="saxc0202.aspx.cs" Inherits="IERM.Views.saxc.saxc0202" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/Distribution/bpd.css" rel="stylesheet" />
    <script src="/js/Distribution/InitDistribution.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Monitoring runat="server" ID="Monitoring" />
    <div class="introImg vertical">
        <form runat="server" id="ContentForm2">
            <input id="hidden_Attribute" type="hidden" value="0" runat="server" />
        </form>
        <div class="ele" id="eleOne">
            <span class="heBefore eleBe"></span>
            <span class="sideHe eleHe"></span>
            <span class="heAfter eleAf"></span>
        </div>
        <div class="twe" style="border-right: none;" id="tweOne">
            <ul class="introOne">
                <li class="introOneLi">
                    <a class="introOneA">功率因数: <span class="temWord">--</span></a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">有功电能: <span class="temWord">--</span>Kw·h</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">无功电能: <span class="temWord">--</span>Kvar·h</a>
                </li>

            </ul>
            <ul class="introTwo">
                <li class="introOneLi">
                    <a class="introOneA">AB电压线: <span class="temWord">--</span>V</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">BC电压线: <span class="temWord">--</span>V</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">CA电压线: <span class="temWord">--</span>V</a>
                </li>
            </ul>
            <ul class="introThree">
                <li class="introOneLi">
                    <a class="introOneA">A线电流: <span class="temWord">--</span>A</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">B线电流: <span class="temWord">--</span>A</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">C线电流: <span class="temWord">--</span>A</a>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">14号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt">G6-1塔楼电梯</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G6-2塔楼电梯</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G5-1塔楼电梯</a>
                    <a class="bg">主供</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G6-1塔楼消防电梯</a>
                    <a class="bg">正压风机主</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">AT2-3弱电电源</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">2#地下室排烟风机备</a>
                    <a class="bg">AT2-4</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">无标识</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">15号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">幼儿园备</a>
                    <a class="bg">幼儿园动力</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">2#地下排烟风机</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G5-2塔楼电梯</a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G5-2塔楼消防电梯</a>
                    <a class="bg">正压风机主</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G6-2塔楼消防电梯</a>
                    <a class="bg">正压风机主</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G5-1塔楼消防电梯</a>
                    <a class="bg">正压风机主</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">室外景观动力G5</a>
                    <a class="bg">G7园林动力</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">至2#地下室</a>
                    <a class="bg">弱电机房AT2-5</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>
        <div class="ele" id="eleTwo">
            <span class="heBefore eleBe"></span>
            <span class="sideHe eleHe"></span>
            <span class="heAfter eleAf"></span>
        </div>
        <div class="twe" id="tweTwo" style="border-right: none;">
            <ul class="introOne">
                <li class="introOneLi">
                    <a class="introOneA">功率因数: <span class="temWord">--</span></a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">有功电能: <span class="temWord">--</span>Kw·h</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">无功电能: <span class="temWord">--</span>Kvar·h</a>
                </li>

            </ul>
            <ul class="introTwo">
                <li class="introOneLi">
                    <a class="introOneA">AB电压线: <span class="temWord">--</span>V</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">BC电压线: <span class="temWord">--</span>V</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">CA电压线: <span class="temWord">--</span>V</a>
                </li>
            </ul>
            <ul class="introThree">
                <li class="introOneLi">
                    <a class="introOneA">A线电流: <span class="temWord">--</span>A</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">B线电流: <span class="temWord">--</span>A</a>
                </li>
                <li class="introOneLi">
                    <a class="introOneA">C线电流: <span class="temWord">--</span>A</a>
                </li>
            </ul>
        </div>
        <div class="center">
            <a class="centerDesk gui">16号柜</a>
            <ul class="centerUl">
                <li class="centerLi">
                    <a class="xfdt">G5-2应急照明公共</a>
                    <a class="bg">(公共)备</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G5-1应急照明公共</a>
                    <a class="bg">(公共)备</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">2#地下室应急照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">G6-1应急照明</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">G6-2应急照明</a>
                    <a class="bg">(公共)备</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt">2#地下室应急照明</a>
                    <a class="bg">AEL2-1(备)</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">护管队宿舍屋</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">居委会</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
                <li class="centerLi">
                    <a class="xfdt"></a>
                    <a class="bg">备用</a>
                    <span class="ulFen status"></span>
                    <span class="redArr"></span>
                </li>
            </ul>
        </div>

        <div class="input-group" style="width: 180px; margin-right: 10px;">
            <span class="input-group-addon">变压器：</span>
            <select class="form-control" id="byqsl">
                <%=urls.ToString() %>
            </select>
        </div>
    </div>
    <ul class="introFour">
        <li class="introOneLi">
            <a class="introOneA">环境温度: <span class="temWord">--</span>℃</a>
        </li>
    </ul>
    <ul class="introFive">
        <li class="introOneLi">
            <a class="introOneA">环境湿度: <span class="temWord">--</span>RH%</a>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript">
        (function () {
            $(".introImg").removeClass("vertical");
            $(".introImg").css({ "paddingTop": "0.45rem", "height": "86%" });
            $(".wordWarp").css("height", "7.2%");

            LoadData();
            setInterval(function () { LoadData(); }, 10000);
        })();

        function LoadData() {
            $.getJSON("/Handler/WCFHandler.ashx?action=getdatabydevhouseid&r=" + Math.random(), { "devhouseID": 8 }, function (res) {
                if (res.IsSucceed) {
                    //功率因数1
                    $("#tweOne ul:eq(0) li:eq(0) span:eq(0)").text(res.Data.N2_PF);
                    //有功电能1
                    $("#tweOne ul:eq(0) li:eq(1) span:eq(0)").text(res.Data.N2_KWH);
                    //无功电能1
                    $("#tweOne ul:eq(0) li:eq(2) span:eq(0)").text(res.Data.N2_KVARH);
                    //AB电压线1
                    $("#tweOne ul:eq(1) li:eq(0) span:eq(0)").text(res.Data.N2_UAB);
                    //BC电压线1
                    $("#tweOne ul:eq(1) li:eq(1) span:eq(0)").text(res.Data.N2_UBC);
                    //CA电压线1
                    $("#tweOne ul:eq(1) li:eq(2) span:eq(0)").text(res.Data.N2_UCA);
                    //A线电流1
                    $("#tweOne ul:eq(2) li:eq(0) span:eq(0)").text(res.Data.N2_IA);
                    //B线电流1
                    $("#tweOne ul:eq(2) li:eq(1) span:eq(0)").text(res.Data.N2_IB);
                    //C线电流1
                    $("#tweOne ul:eq(2) li:eq(2) span:eq(0)").text(res.Data.N2_IC);

                    //功率因数2
                    $("#tweTwo ul:eq(0) li:eq(0) span:eq(0)").text(res.Data.N1_PF);
                    //有功电能2
                    $("#tweTwo ul:eq(0) li:eq(1) span:eq(0)").text(res.Data.N1_KWH);
                    //无功电能2
                    $("#tweTwo ul:eq(0) li:eq(2) span:eq(0)").text(res.Data.N1_KVARH);
                    //AB电压线2
                    $("#tweTwo ul:eq(1) li:eq(0) span:eq(0)").text(res.Data.N1_UAB);
                    //BC电压线2
                    $("#tweTwo ul:eq(1) li:eq(1) span:eq(0)").text(res.Data.N1_UBC);
                    //CA电压线2
                    $("#tweTwo ul:eq(1) li:eq(2) span:eq(0)").text(res.Data.N1_UCA);
                    //A线电流2
                    $("#tweTwo ul:eq(2) li:eq(0) span:eq(0)").text(res.Data.N1_IA);
                    //B线电流2
                    $("#tweTwo ul:eq(2) li:eq(1) span:eq(0)").text(res.Data.N1_IB);
                    //C线电流2
                    $("#tweTwo ul:eq(2) li:eq(2) span:eq(0)").text(res.Data.N1_IC);
                    //环境温度
                    $(".introFour li:eq(0)").find(".temWord").text(res.Data.T_ROOM);
                    //环境湿度
                    $(".introFive li:eq(0)").find(".temWord").text(res.Data.H_ROOM);

                    //进线柜断路器状态1
                    res.Data.N1_JXG ? $("#eleOne span:eq(1)").attr("class", "sideHe eleHe") : $("#eleOne span:eq(1)").attr("class", "sideFen eleFen");
                    //进线柜断路器状态2
                    res.Data.N1_JXG ? $("#eleTwo span:eq(1)").attr("class", "sideHe eleHe") : $("#eleTwo span:eq(1)").attr("class", "sideFen eleFen");

                    //14号柜
                    res.Data.N2_G1.f1 ? $(".centerUl:eq(0) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f2 ? $(".centerUl:eq(0) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f3 ? $(".centerUl:eq(0) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f4 ? $(".centerUl:eq(0) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f5 ? $(".centerUl:eq(0) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f6 ? $(".centerUl:eq(0) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f7 ? $(".centerUl:eq(0) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G1.f8 ? $(".centerUl:eq(0) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(0) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulFen status");

                    //15号柜
                    res.Data.N2_G2.f1 ? $(".centerUl:eq(1) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f2 ? $(".centerUl:eq(1) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f3 ? $(".centerUl:eq(1) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f4 ? $(".centerUl:eq(1) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f5 ? $(".centerUl:eq(1) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f6 ? $(".centerUl:eq(1) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f7 ? $(".centerUl:eq(1) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f8 ? $(".centerUl:eq(1) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N2_G2.f9 ? $(".centerUl:eq(1) .centerLi:eq(8)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(1) .centerLi:eq(8)").find("span:eq(0)").attr("class", "ulFen status");

                    //16号柜
                    res.Data.N1_G1.f1 ? $(".centerUl:eq(2) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(0)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f2 ? $(".centerUl:eq(2) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(1)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f3 ? $(".centerUl:eq(2) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(2)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f4 ? $(".centerUl:eq(2) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(3)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f5 ? $(".centerUl:eq(2) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(4)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f6 ? $(".centerUl:eq(2) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(5)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f7 ? $(".centerUl:eq(2) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(6)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f8 ? $(".centerUl:eq(2) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(7)").find("span:eq(0)").attr("class", "ulFen status");
                    res.Data.N1_G1.f9 ? $(".centerUl:eq(2) .centerLi:eq(8)").find("span:eq(0)").attr("class", "ulHe status") : $(".centerUl:eq(2) .centerLi:eq(8)").find("span:eq(0)").attr("class", "ulFen status");
                }
            });
        };
    </script>
</asp:Content>
