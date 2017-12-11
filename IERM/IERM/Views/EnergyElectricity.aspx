<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="EnergyElectricity.aspx.cs" Inherits="IERM.Views.EnergyElectricity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>用电能耗</title>
    <link href="/css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="/css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="/css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group" >
                            <span class="input-group-addon">能耗年份：</span>
                            <select class="form-control" id="energyyear">
                                <option value="2016">2016</option>
                                <option value="2017" selected>2017</option>
                                <option value="2018">2018</option>
                                <option value="2019">2019</option>
                                <option value="2020">2020</option>
                                <option value="2021">2021</option>
                                <option value="2022">2022</option>
                                <option value="2023">2023</option>
                                <option value="2024">2024</option>
                                <option value="2025">2025</option>
                            </select>
                        </div>

                        <div class="input-group" >
                            <span class="input-group-addon">能耗项目：</span>
                            <select id="test" style="width: 250px; margin-right: 20px;">
                            </select>
                        </div>
                        <button id="serach" type="button" class="btn btn-info input-group" style="margin-right: 68px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <div class="panel-body" style="min-height: 580px;">
                <div class="row-fluid form-inline">
                    <ul class="nav nav-tabs" role="tablist" id="eleTab">
                        <li role='presentation'><a data-tid="0" href='#eleinfo' role='tab' data-toggle='tab'>用电能耗汇总</a></li>
                    </ul>
                    <div class="tab-content" id="elecontent">
                        <div role='tabpanel' class='tab-pane fade in active' id='eleinfo'>
                            <div id='eleinfo-content' class='form-group col-lg-12' style='height: 600px;'></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="/js/select2andtree/select2.min.js"></script>
    <script src="/js/select2andtree/i18n/zh-CN.js"></script>
    <script src="/js/select2andtree/select2tree.js"></script>
    <script src="/js/echarts.js"></script>
    <script type="text/javascript">
        var chartdata = null;
        $(function () {

            initSelectTree();

            //筛选按钮
            $('#serach').click(function () {

                $.getJSON("../Handler/EnergyHandler.ashx?action=GetChartsData&r=" + Math.random(), {
                    "selYear": $('#energyyear').val(),
                    "areaLevel": $('#test option:selected').attr('data-level'),
                    "areaID": $('#test option:selected').attr('data-value'),
                    "energyType": 1
                }, function (res) {
                    if (res.IsSucceed) {
                        chartdata = res.Data;
                        if ($('#eleTab li:first').hasClass("active")) {
                            DrawBarChart(document.getElementById("eleinfo-content"), chartdata[0]);
                        }
                        else {
                            $('#eleTab a:first').tab('show');
                        }
                    }
                    else if (!res.IsSucceed) {
                        alert($('#test option:selected').val() + "项目(" + $('#energyyear').val() + "年)暂无数据");
                    }
                });
            });
        });

        //生成图表框架
        function initElePanel(index) {
            $.getJSON("../Handler/EnergyHandler.ashx?action=getenrgytmpl&pID=1&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $.each(res.Data, function () {
                        $('#eleTab').append("<li role='presentation'><a data-tid='" + this.tID + "' href='#e" + this.tID + "' role='tab' data-toggle='tab'>" + this.typeName + "</a></li>");
                        $('#elecontent').append("<div role='tabpanel' class='tab-pane fade' id='e" + this.tID + "'><div id='e" + this.tID + "-content' class='form-group col-lg-12' style='height: 600px;'></div></div>");
                    });

                    $("#eleTab a:eq(" + index + ")").tab('show');
                    $.getJSON("../Handler/EnergyHandler.ashx?action=GetChartsData&r=" + Math.random(), {
                        "selYear": $('#energyyear').val(),
                        "areaLevel": $('#test option:selected').attr('data-level'),
                        "areaID": $('#test option:selected').val(),
                        "energyType": 1
                    }, function (res) {
                        if (res.IsSucceed) {
                            chartdata = res.Data;
                            $("#eleTab a[data-toggle='tab']").on('shown.bs.tab', function (e) {
                                var tid = $(e.target).attr("data-tid");
                                if (tid == "0") {
                                    DrawBarChart(document.getElementById("eleinfo-content"), chartdata[tid]);
                                }
                                else {
                                    DrawLineChart(document.getElementById("e" + tid + "-content"), chartdata[tid]);
                                }
                            });
                        }
                    });


                }
            });
        }

        //绘制折线图
        function DrawLineChart(obj, data) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);

            // 指定图表的配置项和数据
            option = {
                title: {
                    text: data.Title,
                    left: '50%',
                    textAlign: 'center'
                },
                tooltip: {
                    trigger: 'asix',
                    axisPointer: {
                        lineStyle: {
                            color: '#ddd'
                        }
                    },
                    backgroundColor: 'rgba(255,255,255,1)',
                    padding: [5, 10],
                    textStyle: {
                        color: '#7588E4',
                    },
                    extraCssText: 'box-shadow: 0 0 5px rgba(0,0,0,0.3)'
                },
                legend: {
                    right: 20,
                    orient: 'vertical',
                    data: data.Legend
                },
                xAxis: {
                    type: 'category',
                    data: data.xAxis,
                    boundaryGap: false,
                    splitLine: {
                        show: true,
                        interval: 'auto',
                        lineStyle: {
                            color: ['#D4DFF5']
                        }
                    },
                    axisTick: {
                        show: false
                    },
                    axisLine: {
                        lineStyle: {
                            color: '#609ee9'
                        }
                    },
                    axisLabel: {
                        margin: 10,
                        textStyle: {
                            fontSize: 14
                        }
                    }
                },
                yAxis: {
                    type: 'value',
                    splitLine: {
                        lineStyle: {
                            color: ['#D4DFF5']
                        }
                    },
                    axisTick: {
                        show: false
                    },
                    axisLine: {
                        lineStyle: {
                            color: '#609ee9'
                        }
                    },
                    axisLabel: {
                        margin: 10,
                        textStyle: {
                            fontSize: 14
                        }
                    }
                },
                series: [{
                    name: data.Series[0].name,
                    type: data.Series[0].type,
                    smooth: true,
                    showSymbol: false,
                    symbol: 'circle',
                    symbolSize: 6,
                    data: data.Series[0].data,
                    areaStyle: {
                        normal: {
                            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                offset: 0,
                                color: 'rgba(199, 237, 250,0.5)'
                            }, {
                                offset: 1,
                                color: 'rgba(199, 237, 250,0.2)'
                            }], false)
                        }
                    },
                    itemStyle: {
                        normal: {
                            color: '#f7b851'
                        }
                    },
                    lineStyle: {
                        normal: {
                            width: 3
                        }
                    }
                }, {
                    name: data.Series[1].name,
                    type: data.Series[1].type,
                    smooth: true,
                    showSymbol: false,
                    symbol: 'circle',
                    symbolSize: 6,
                    data: data.Series[1].data,
                    areaStyle: {
                        normal: {
                            color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                offset: 0,
                                color: 'rgba(216, 244, 247,1)'
                            }, {
                                offset: 1,
                                color: 'rgba(216, 244, 247,1)'
                            }], false)
                        }
                    },
                    itemStyle: {
                        normal: {
                            color: '#58c8da'
                        }
                    },
                    lineStyle: {
                        normal: {
                            width: 3
                        }
                    }
                }]
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
        };


        ///绘制柱形图
        function DrawBarChart(obj, data) {
            //alert(JSON.stringify(data));
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(obj);
            var colors = ['#5793f3', '#d14a61', '#675bba'];
            // 指定图表的配置项和数据
            option = {
                color: colors,

                tooltip: {
                    trigger: 'axis'
                },
                grid: {
                    right: '1%',
                    left:'1%'
                },
                legend: {
                    data: data.Legend
                },
                xAxis: [
                    {
                        axisLabel: {
                            //X轴刻度配置
                            interval: '0', //0：表示全部显示不间隔；auto:表示自动根据刻度个数和宽度自动设置间隔个数
                            rotate: 60
                        },
                        type: 'category',
                        axisTick: {
                            alignWithLabel: true
                        },
                        data: data.xAxis
                    }
                ],
                yAxis: data.yAxis,
                series: data.Series
            };

            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option);
        }

        //初始化省市小区列表
        function initSelectTree() {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcpot&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $("#test").append(res.Data).select2tree();

                    initElePanel(1);
                }
            });
        }

    </script>
</asp:Content>
