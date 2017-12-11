<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="EnergyStatistics.aspx.cs" Inherits="IERM.Views.EnergyStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>运行数据分析</title>
    <link href="/css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="/css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="/css/Wizard/prettify.css" rel="stylesheet" />
    <link href="/css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="/css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="/css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="panel panel-default ">
        <ul class="nav nav-tabs" role="tablist" id="eleTab" style="height: auto!important;">
            <li role='presentation' style="margin-right: 50px"><a data-tid="0" href='#eleinfo' role='tab' data-toggle='tab'>能耗数据统计</a></li>
            <li role='presentation' style="margin-right: 50px"><a data-tid="1" href='#e1' role='tab' data-toggle='tab'>设备使用情况统计</a></li>
            <li role='presentation'><a data-tid="2" href='#e2' role='tab' data-toggle='tab'>重要数据统计</a></li>
        </ul>
        <div class="tab-content" id="elecontent" style="height: 95%">
            <div role='tabpanel' class='tab-pane fade in active' id='eleinfo'>
                <div id='eleinfo-content' class='form-group col-lg-12'>
                    <div class="panel_heading ">
                        <div class="form-inline " style="margin-top: 5px">
                            <div class="text-left">
                                <div class="input-group" style="margin-right: 15px;">
                                    <span class="input-group-addon">物业公司：</span>
                                    <select class="form-control" id="selectppi">
                                        <%foreach (var item in lstproperty)
                                            { %>
                                        <option value="<%=item.propertyID %>"><%=item.propertyName %></option>
                                        <%} %>
                                    </select>
                                </div>

                                <div class="input-group" style="margin-right: 15px;">
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
                                        <option value="2026">2026</option>
                                    </select>
                                </div>

                                <div class="input-group" style="margin-right: 15px;">
                                    <span class="input-group-addon">能耗类型：</span>
                                    <select class="form-control" id="energyType">
                                        <option value="1">用电能耗</option>
                                        <option value="2">用水能耗</option>
                                        <option value="3">用气能耗</option>
                                    </select>
                                </div>
                                <button id="serachEnergy" type="button" class="btn btn-info input-group"><span class="glyphicon glyphicon-search"></span>筛选</button>
                            </div>
                        </div>
                    </div>
                    <div id='eleinfo-data' class="panel-body" style="min-height: 500px; margin-top: 50px;"></div>
                </div>
            </div>

            <div role='tabpanel' class='tab-pane fade' id='e1'>
                <div id='eleinfo-content1' class='form-group col-lg-12'>
                    <div class="panel_heading ">
                        <div class="form-inline" style="margin-top: 5px">
                            <div class="text-left">
                                <div class="input-group" style="margin-right: 15px;">
                                    <span class="input-group-addon">物业公司：</span>
                                    <select class="form-control" id="selectpro">
                                        <%foreach (var item in lstproperty)
                                            { %>
                                        <option value="<%=item.propertyID %>"><%=item.propertyName %></option>
                                        <%} %>
                                    </select>
                                </div>
                                <button id="serachAlarm" type="button" class="btn btn-info input-group" style="margin-right: 68px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                            </div>
                        </div>
                    </div>
                    <div style="clear:both"></div>
                    <div id='eleinfo-data1' class="panel-body" style="min-height: 240px; margin-top: 50px; width:45%; float:left"></div>
                    <div id='eleinfo-xf' class="panel-body" style="min-height: 240px; margin-top: 50px;width:45%; float:left"></div>
                      <div style="clear:both"></div>
                    <div id='eleinfo-pd' class="panel-body" style="min-height: 240px; margin-top: 120px;width:45%;float:left"></div>
                    <div id='eleinfo-ntkt' class="panel-body" style="min-height: 240px; margin-top: 120px;width:45%;float:left"></div>
                       
                </div>
            </div>

            <div role='tabpanel' class='tab-pane fade' id='e2'>
                <div id='eleinfo-content2' class='form-group col-lg-12'>
                    <div class="panel_heading ">
                        <div class="form-inline" style="margin-top: 5px">
                            <div class="text-left">
                                <div class="input-group" style="margin-right: 15px;">
                                    <span class="input-group-addon">物业公司：</span>
                                    <select class="form-control" id="selectpro1">
                                        <%foreach (var item in lstproperty)
                                            { %>
                                        <option value="<%=item.propertyID %>"><%=item.propertyName %></option>
                                        <%} %>
                                    </select>
                                </div>
                                <div class="input-group" >
                                    <span class="input-group-addon">能耗年份：</span>
                                    <select class="form-control" id="datayear">
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
                                        <option value="2026">2026</option>
                                    </select>
                                </div>
                                <button id="serachData" type="button" class="btn btn-info input-group" style="margin-right: 68px;"><span class="glyphicon glyphicon-search"></span>筛选</button>

                            </div>
                        </div>
                    </div>
                    <div id='eleinfo-data2' style='min-height: 740px; margin-top: 50px;' class="panel-body"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/daterangepicker/moment.min.js"></script>
    <script src="../js/daterangepicker/daterangepicker.js"></script>
    <script src="../js/daterangepicker/DateFormat.js"></script>
    <script src="../js/select2andtree/select2.min.js"></script>
    <script src="../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../js/select2andtree/select2tree.js"></script>
    <script src="../js/echarts.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#eleTab a:eq(0)").tab('show');
            //默认加载电能能耗

            $("#serachEnergy").click(function () {
                initElePanel();
            });

            $('#serachAlarm').click(function () {
                initAralmPiePanel();
            });

            $('#serachData').click(function () {
                initDataColumsPanel();
            });
            //initElePanel();
        });
        //能源统计
        function initElePanel() {
            $.post("../Handler/EnergyStatistics.ashx?action=getenergy&prono="
                + $('#selectppi').val()
                + "&year=" + $('#energyyear').val()
               + "&type=" + $('#energyType').val()
                + "&r=" + Math.random(), null, function (res) {
                    DrawLineEnergy(res);
                });
        }

        ///设备使用情况统计
        function initAralmPiePanel() {
            $.getJSON("../Handler/EnergyStatistics.ashx?action=getalarmcount" +
                "&prono=" + $('#selectpro').val() +
                "&r=" + Math.random(), null, function (res) {
                    // DarwPieFault(res);
                    DrawPiePS(res);
                    DrawPieXF(res);
                    DrawPiePD(res);
                    DarwPieNT(res);
                });
        }

        //事件统计
        function initDataColumsPanel() {
            $.getJSON("../Handler/EnergyStatistics.ashx?action=getimportantcount" +
                "&prono=" + $('#selectpro').val() +
                "&year=" + $('#datayear').val() +
                "&r=" + Math.random(), null, function (res) {
                    DarwColumnDatas(res);
                });
        }

        //绘制折线图
        function DrawLineEnergy(data) {
            // 基于准备好的dom，初始化echarts实例
            var myChart = echarts.init(document.getElementById('eleinfo-data'));

            // 指定图表的配置项和数据
            option = {
                title: {
                    text: '能耗统计',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['用电耗能'],
                    align: 'right',
                    right: 200,
                    //textStyle: { color: "#DC143C" }
                },
                grid: {
                    top: '50px',
                    left: '3%',
                    right: '4%',
                    containLabel: true
                },
                toolbox: {
                    feature: {
                        mark: { show: true },
                        magicType: { show: true, type: ['line', 'bar'] },
                        restore: { show: true },
                        saveAsImage: { show: true }
                    }
                },
                xAxis: [{
                    splitLine: {
                        show: true,
                    },
                    type: 'category',
                    boundaryGap: false,
                    data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
                }],
                yAxis: [
                        {
                            type: 'value',
                            name: '用电耗能',
                            position: 'left',
                            offset: 10,
                            axisLine: {
                                lineStyle: {
                                    color: "#DC143C"
                                }
                            },
                            axisLabel: {
                                formatter: '{value} (Kw·h)' // formatter: '{value} (m³)' formatter: '{value} (Nm³/h)'
                            }
                        },
                ],
                series: [
                       {
                           name: '用电耗能',
                           type: 'line',
                           itemStyle: {
                               normal: {
                                   lineStyle: {
                                       color: '#DC143C'
                                   }
                               }
                           },
                           data: []
                       },
                ]
            };

            var year = $('#energyyear').val();
            var energyType = $("#energyType").val();
            //根据读取不同的能耗类型设置不同样式
            switch (energyType) {
                case "1":
                    option.color = "#DC143C";
                    option.legend.data[0] = "用电能耗";
                    option.series[0].name = "用电能耗";
                    option.series[0].itemStyle.normal.lineStyle.color = "#DC143C";
                    option.yAxis[0].name = "用电能耗";
                    option.yAxis[0].axisLine.lineStyle.color = "#DC143C";
                    option.yAxis[0].axisLabel.formatter = "{value} (Kw·h)";
                    break;
                case "2":
                    option.color = "#000080";
                    option.legend.data[0] = "用水能耗";
                    option.series[0].name = "用水能耗";
                    option.series[0].itemStyle.normal.lineStyle.color = "#000080";
                    option.yAxis[0].name = "用水能耗";
                    option.yAxis[0].axisLine.lineStyle.color = "#000080";
                    option.yAxis[0].axisLabel.formatter = "{value} (m³)";
                    break;
                case "3":
                    option.color = "#00BFFF";
                    option.legend.data[0] = "用气能耗";
                    option.series[0].name = "用气能耗";
                    option.series[0].itemStyle.normal.lineStyle.color = "#00BFFF";
                    option.yAxis[0].name = "用气能耗";
                    option.yAxis[0].axisLine.lineStyle.color = "#00BFFF";
                    option.yAxis[0].axisLabel.formatter = "{value} (Nm³/h)";
                    break;
                default:
                    option.color = "#DC143C";
                    option.legend.data[0] = "用电能耗";
                    option.series[0].name = "用电能耗";
                    option.series[0].itemStyle.normal.lineStyle.color = "#DC143C";
                    option.yAxis[0].name = "用电能耗";
                    option.yAxis[0].axisLine.lineStyle.color = "#DC143C";
                    option.yAxis[0].axisLabel.formatter = "{value} (Kw·h)";
                    break;
            }
            var energyData = JSON.parse(data);
            for (var i = 0; i < energyData.length; i++) {
                option.series[0].data.push(energyData[i]);
            }
            //清除数据缓存
            myChart.clear();
            // 使用刚指定的配置项和数据显示图表。
            myChart.setOption(option, true);
        };
        /*
        绘制排水系统饼状图
        2017年5月16日 15:12:08 BY 潘阳
        */
        function DrawPiePS(datas)
        {
            var myCharts1 = echarts.init(document.getElementById('eleinfo-data1'));
            var ArrNum = [{ value: datas[0], name: '故障设备' }, { value: datas[1] - datas[0], name: '正常设备' }];
            option1 = {
                color: ['#FF0000', '#00FF00'],
                title: {
                    text: '排水系统',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    data: ['故障设备', '正常设备']
                },
                toolbox: {
                    show: true,
                    feature: {
                        mark: { show: true },
                        dataView: { show: false, readOnly: false },
                        magicType: {
                            show: true,
                            type: ['pie', 'funnel']
                        },
                        restore: { show: false },
                        saveAsImage: { show: true }
                    }
                },
                calculable: true,

                series: [
                    {
                        name: '排水系统',
                        type: 'pie',
                        radius: [30, 50],
                        center: ['50%', '40%'],
                        roseType: 'area',
                        data: ArrNum
                    }
                ]
            };
            //排水系统
          
            myCharts1.setOption(option1);
        }
        /*
        绘制消防系统饼状图
        2017年5月16日 15:12:08 BY 潘阳
        */
        function DrawPieXF(datas) {
            var myCharts1 = echarts.init(document.getElementById('eleinfo-xf'));
            var ArrNum = [{ value: datas[2], name: '故障设备' }, { value: datas[3] - datas[2], name: '正常设备' }];
            option1 = {
                color: ['#FF0000', '#00FF00'],
                title: {
                    text: '消防系统',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    data: ['故障设备', '正常设备']
                },
                toolbox: {
                    show: true,
                    feature: {
                        mark: { show: true },
                        dataView: { show: false, readOnly: false },
                        magicType: {
                            show: true,
                            type: ['pie', 'funnel']
                        },
                        restore: { show: false },
                        saveAsImage: { show: true }
                    }
                },
                calculable: true,

                series: [
                    {
                        name: '消防系统',
                        type: 'pie',
                        radius: [30, 50],
                        center: ['50%', '40%'],
                        roseType: 'area',
                        data: ArrNum
                    }
                ]
            };
            
            myCharts1.setOption(option1);
        }
        /*
         绘制交配电系统饼状图
         2017年5月16日 15:12:08 BY 潘阳
         */
        function DrawPiePD(datas) {
            var myCharts1 = echarts.init(document.getElementById('eleinfo-pd'));
            var ArrNum = [{ value: datas[4], name: '故障设备' }, { value: datas[5] - datas[4], name: '正常设备' }];
            option1 = {
                color: ['#FF0000', '#00FF00'],
                title: {
                    text: '交配电系统',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    //right: 300,
                    data: ['故障设备', '正常设备']
                },
                toolbox: {
                    show: true,
                    feature: {
                        mark: { show: true },
                        dataView: { show: false, readOnly: false },
                        magicType: {
                            show: true,
                            type: ['pie', 'funnel']
                        },
                        restore: { show: false },
                        saveAsImage: { show: true }
                    }
                },
                calculable: true,
                series: [
                    {
                        name: '交配电系统',
                        type: 'pie',
                        radius: [30, 50],
                        center: ['50%', '40%'],
                        roseType: 'area',
                        data: ArrNum
                    }
                ]
            };
            
            myCharts1.setOption(option1);
        }
        /*
        绘制暖通空调系统饼状图
        2017年5月16日 15:12:08 BY 潘阳
        */
        function DarwPieNT(datas) {
            var myCharts1 = echarts.init(document.getElementById('eleinfo-ntkt'));
            var ArrNum = [{ value: datas[6], name: '故障设备' }, { value: datas[7] - datas[6], name: '正常设备' }];
            option1 = {
                color: ['#FF0000', '#00FF00'],
                title: {
                    text: '暖通空调系统',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    //right: 300,
                    data: ['故障设备', '正常设备']
                },
                toolbox: {
                    show: true,
                    feature: {
                        mark: { show: true },
                        dataView: { show: false, readOnly: false },
                        magicType: {
                            show: true,
                            type: ['pie', 'funnel']
                        },
                        restore: { show: false },
                        saveAsImage: { show: true }
                    }
                },
                calculable: true,
               
                series: [
                    {
                        name: '暖通空调系统',
                        type: 'pie',
                        radius: [30, 50],
                        center: ['50%', '40%'],
                        roseType: 'area',
                        data: ArrNum
                    }
                ]
            };
            myCharts1.setOption(option1);
        }

        //柱形图重要数据统计
        function DarwColumnDatas(data) {
            var fireList = data[0].split(',');
            var issuedList = data[1].split(',');
            var completeList = data[2].split(',');
          
            var myCharts1 = echarts.init(document.getElementById('eleinfo-data2'));
            option1 = {
                title: {
                    text: '事故查询'
                },
                color: ['#3399FF', '#CC3333', '#666699', '#696969'],
                tooltip: {
                    trigger: 'axis',
                    axisPointer: { // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow' // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                legend: {
                    data: ['电梯困人事故', '消防系统报警', '当月总派单数量', '当月派单完成数量'],
                    align: 'right',
                    right: 10
                },
                grid: {
                    left: '3%',
                    right: '4%',
                    bottom: '3%',
                    containLabel: true
                },
                xAxis: [{
                    type: 'category',
                    data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
                }],
                yAxis: [{
                    type: 'value',
                    name: '总量(件)',
                    axisLabel: {
                        formatter: '{value}'
                    }
                }],
                series: [{
                    name: '电梯困人事故',  //暂无
                    type: 'bar',
                    data: []
                }, {
                    name: '消防系统报警',
                    type: 'bar',
                    data: []
                }, {
                    name: '当月总派单数量',
                    type: 'bar',
                    data: []
                }, {
                    name: '当月派单完成数量',
                    type: 'bar',
                    data: []
                }]
            };
            //电梯困人
            //暂时没做
            //消防
            for (var i = 0; i < fireList.length; i++) {
                option1.series[1].data.push(fireList[i]);
            }
            //当月总派单任务数量
            for (var i = 0; i < issuedList.length; i++) {
                option1.series[2].data.push(issuedList[i]);
            }
            //'当月派单任务完成数量
            for (var i = 0; i < completeList.length; i++) {
                option1.series[3].data.push(completeList[i]);
            }

            myCharts1.setOption(option1);
        }

    </script>
</asp:Content>
