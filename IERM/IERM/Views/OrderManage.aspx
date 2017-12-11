<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="IERM.Views.OrderManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>派单管理</title>
    <link href="../css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class='container-fluid'>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group" >
                            <span class="input-group-addon">物业公司：</span>
                            <select id="property" class="form-control" style="width: 150px; margin-right: 20px;">
                                <option value="0">全部</option>
                                <%foreach (System.Data.DataRow item in propertyList.Rows)
                                    { %>
                                <option value="<%=Convert.ToInt32(item["propertyID"])%>"><%=item["propertyName"].ToString() %></option>
                                <%} %>
                            </select>
                        </div>

                        <div class="input-group" >
                            <span class="input-group-addon">项目选择：</span>
                            <select id="test" class="form-control" style="width: 250px; margin-right: 20px;">
                            </select>
                        </div>

                        <div class="input-group" >
                            <span class="input-group-addon">设备房：</span>
                            <select class="form-control" id="devhouse">
                                <option value="0">全部</option>
                            </select>
                        </div>
                        <div class="input-group" >
                            <div class="controls">
                                <div class="input-prepend input-group">
                                    <span class="add-on input-group-addon">时间段:</span>
                                    <input type="text" readonly style="width: 200px" name="reservation" id="reservation" class="form-control" value='' />
                                </div>
                            </div>
                        </div>
                        <div class="input-group" >
                            <span class="input-group-addon">派单类型：</span>
                            <select id="orderType" class="form-control" style="width: 150px; margin-right: 20px;">
                                <option value="0">全部</option>
                                <option value="1">报警</option>
                             <%--   <option value="2">维保</option>
                                <option value="3">巡检</option>--%>
                                <option value="2">维巡</option>
                            </select>
                        </div>

                        <button id="serach" type="button" class="btn btn-info input-group" style="margin-right: 68px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <div class="panel-body" style="min-height: 550px;">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <ul style="margin-left: 20px;" id="breadcrumb">
                            <li><a href="javascript:void(0)">派单管理</a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                        </ul>
                    </div>
                    <div class="panel-body">
                        <table id="tb_order"></table>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/select2andtree/select2.min.js"></script>
    <script src="../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../js/select2andtree/select2tree.js"></script>
    <script src="../js/daterangepicker/moment.min.js"></script>
    <script src="../js/daterangepicker/daterangepicker.js"></script>
    <script src="../js/daterangepicker/DateFormat.js"></script>
    <script type="text/javascript">

        $(function () {
            initSelectTree($('#property').val());

            $("#test").change(function () {
                initDevHouse();
            });

            $("#property").change(function () {
                initSelectTree($('#property').val());
            });

            $("#serach").click(function () {
                initTable();
            });

            $('#reservation').val(new Date().Format('yyyy-MM-01') + "-" + new Date().Format('yyyy-MM-dd'));

            $('#reservation').daterangepicker(
                 {
                     format: 'YYYY-MM-DD',
                     startDate: new Date().Format('yyyy-MM-01'),
                     endDate: new Date().Format('yyyy-MM-dd'),
                     locale: {
                         applyLabel: '确定',
                         cancelLabel: '取消',
                         fromLabel: '起始日期',
                         toLabel: '结束日期',
                         customRangeLabel: '自定义',
                         daysOfWeek: ['日', '一', '二', '三', '四', '五', '六'],
                         monthNames: ['一月', '二月', '三月', '四月', '五月', '六月',
                         '七月', '八月', '九月', '十月', '十一月', '十二月'],
                         firstDay: 1
                     }

                 },
                 function (start, end, label) {

                 });

            $('#devhouse').change(function () {
                $('#breadcrumb a:eq(4)').text($("#devhouse :selected").text());
            });
        });

        //初始化省市小区数列表
        function initSelectTree(pid) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcpoe&r=" + Math.random(), { "propertyID": pid }, function (res) {
                if (res.IsSucceed) {
                    $("#test").empty();
                    $("#test").append(res.Data).select2tree();
                    initDevHouse();
                }
            });
        }

        //获取设备房列表
        function initDevHouse() {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getdevbycid&r=" + Math.random(), {
                "pageNumber": 1,
                "pageSize": 20,
                "communityID": $('#test option:selected').data("value")
            }, function (res) {
                $("#devhouse option:gt(0)").remove();
                if (res.total > 0) {
                    $.each(res.rows, function (key, value) {
                        $("#devhouse").append("<option value='" + this.devID + "'>" + this.devName + "</option>");
                    });
                }

                $('#breadcrumb a:eq(4)').text($("#devhouse :selected").text());
                var community = $('#test option:selected');
                $('#breadcrumb a:eq(3)').text(community.text());
                var city = $("#test option[data-level=2][value='" + community.attr("parent") + "']");
                $('#breadcrumb a:eq(2)').text(city.text());
                var province = $("#test option[data-level=1][value='" + city.attr("parent") + "']");
                $('#breadcrumb a:eq(1)').text(province.text());

                initEquList($("#devhouse").val());
            });
        }

        //初始化工单表
        function initTable() {
            //先销毁表格  
            $('#tb_order').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_order").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/OrderHandler.ashx?action=getorderlog&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 175,
                //toolbar: '#toolbar',                //工具按钮用哪个容器
                pagination: true, //启动分页  
                pageSize: 10,  //每页显示的记录数  
                pageNumber: 1, //当前第几页  
                pageList: [10, 20, 30],  //记录数可选列表  
                search: false,  //是否启用查询  
                //showColumns: true,  //显示下拉框勾选要显示的列  
                //showRefresh: true,  //显示刷新按钮  
                sidePagination: "server", //表示服务端请求
                minimumCountColumns: 2, //最少允许的列数
                //showToggle: true,  //是否显示详细视图和列表视图的切换按钮
                //设置为undefined可以获取pageNumber，pageSize，searchText，sortName，sortOrder  
                //设置为limit可以获取limit, offset, search, sort, order  
                queryParamsType: "undefined",
                queryParams: function queryParams(params) {   //设置查询参数  
                    var param = {
                        pageNumber: params.pageNumber,
                        pageSize: params.pageSize,
                        "communityID": $('#test option:selected').data("value"),
                        "devhouseID": $('#devhouse').val(),
                        "orderType": $('#orderType').val(),
                        "timeSpan": $('#reservation').val()
                    };
                    return param;
                },
                rowStyle: function (row, index) {
                    var strclass = "";
                    if (row.orderType == 1) {
                        strclass = 'warning';
                    }
                    return { classes: strclass }
                },
                onLoadSuccess: function (data) {  //加载成功时执行  
                    settingdata = data;
                    $('[data-toggle="popover"]').popover({
                        html: true,
                        trigger: 'hover'
                    });
                },
                columns: [{
                    field: 'mID',
                    title: '序号',
                    align: 'center',
                    visible: false
                },
                {
                    field: 'orderCode',
                    title: '工单号',
                    align: 'center'
                },
                {
                    field: 'orderContent',
                    title: '工单内容',
                    align: 'center',
                    formatter: function (value, row, index) {
                        return "<a data-toggle='popover' title='工单内容' data-content='" + value + "'>" + value.substring(0, 8) + "......</a>";
                    }
                },
                 {
                     field: 'orderType',
                     title: '工单类型',
                     align: 'center',
                     formatter: function (value, row, index) {
                         var dw = "";
                         if (value == 1) {
                             dw = "报警";
                         } else if (value == 2) {
                             dw = "维保";
                         } else { dw = "巡检"; }
                         return dw;
                     }
                 },
                {
                    field: 'createTime',
                    title: '工单生成时间',
                    align: 'center'
                },
                {
                    field: 'operateTime',
                    title: '工单处理时间',//	
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (/^0001.+$/.exec(value)) {
                            return "无";
                        }
                        else {
                            return value;
                        }
                    }
                },
                {
                    field: 'status',
                    title: '工单状态',
                    align: 'center',
                    formatter: function (value, row, index) {
                        var dw = "";
                        switch (value) {
                            case 1:
                                dw = "<font color='orange'>等待处理</font>";
                                break;
                            case 2:
                                dw = "<font color='blue'>已接单</font>";
                                break;
                            case 3:
                                dw = "<font color='green'>已处理</font>";
                                break;
                            default:
                                dw = "<font color='red'>无法处理</font>";
                                break;
                        }
                        return dw;
                    }
                },
                {
                    field: 'remark',
                    title: '备注',
                    align: 'center'
                }]
            });
        }


        ///初始化设备列表
        function initEquList(devhouseid) {
            $.getJSON("../Handler/EquipmentHandler.ashx?action=getequinfobyhouseid&r=" + Math.random(), {
                "pageNumber": 1,
                "pageSize": 100,
                "houseID": devhouseid,
            }, function (res) {
                if (res.total > 0) {
                    $('#equID').empty();
                    equdata = res.rows;
                    $.each(res.rows, function () {
                        $('#equID').append("<option value='" + this.eID + "'>" + this.equName + "</option>");
                    });
                }
            });
        }




    </script>
</asp:Content>
