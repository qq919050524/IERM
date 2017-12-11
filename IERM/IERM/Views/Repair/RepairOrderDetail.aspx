<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Site1.Master" CodeBehind="RepairOrderDetail.aspx.cs" Inherits="IERM.Views.Repair.RepairOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>维修工单-详情</title>
    <link href="/css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="/css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="/css/layer/layer.css" rel="stylesheet" />
    <style>
        #content {
            background-color: #fff;
        }

        .header {
            line-height: 28px;
            margin-bottom: 16px;
            margin-top: 18px;
            padding-bottom: 4px;
            border-bottom: 1px solid #000000;
            border-bottom-color: #000000;
        }

            .header a {
                cursor: pointer;
            }

            .header span {
                float: none;
                line-height: 28px;
                font-size: 25px !important;
            }

        #info .form-inline .input-group {
            margin-left: 20px;
        }

            #info .form-inline .input-group span {
                width: 100px;
                font-size: 15px !important;
            }

            #info .form-inline .input-group input {
                width: 240px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <input type="hidden" id="orderID" runat="server" />
    <div class="col-xs-12">
        <h3 class="header">
            <span class="col-sm-6">维修工单-详情</span>
            <span class="col-sm-6" style="font-size: 15px !important;">
                <a onclick="javascript:window.history.go(-1);">返回</a>
            </span>
        </h3>
        <div id="info">
            <!-- /.详情信息 -->
            <div class="form-inline col-xs-12">
                <div class="input-group">
                    <span class="input-group-addon">工单编号：</span>
                    <input class="form-control" type="text" readonly="readonly" id="orderSN" runat="server" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">派单人：</span>
                    <input class="form-control" type="text" readonly="readonly" id="dispatchName" runat="server" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">创建时间：</span>
                    <input class="form-control" type="text" readonly="readonly" id="createTime" runat="server" />
                </div>
            </div>
            <div class="form-inline col-xs-12">
                <div class="input-group">
                    <span class="input-group-addon">责任人：</span>
                    <input class="form-control" type="text" readonly="readonly" id="receiverName" runat="server" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">工单状态：</span>
                    <input class="form-control" type="text" readonly="readonly" id="orderStatus" runat="server" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">完成期限：</span>
                    <input class="form-control" type="text" readonly="readonly" id="termTime" runat="server" />
                </div>
            </div>
            <div class="form-inline col-xs-12">
                <div class="input-group">
                    <span class="input-group-addon">协同人员：</span>
                    <input class="form-control" type="text" readonly="readonly" id="coordinationNames" runat="server" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">完成时间：</span>
                    <input class="form-control" type="text" readonly="readonly" id="endTime" runat="server" />
                </div>
                <div class="input-group">
                    <span class="input-group-addon">维修原因：</span>
                    <input class="form-control" type="text" readonly="readonly" id="reason" runat="server" />
                </div>
            </div>
            <!-- /.详情信息 -->
            <!-- /.设备信息 -->
            <div class="col-xs-12" style="">
                <table id="tb_equipment"></table>
            </div>
            <!-- /.设备信息 -->
        </div>
    </div>
    <div class="col-xs-12">
        <h3 class="header">
            <span class="col-sm-6">实施记录</span>
        </h3>
        <div class="col-xs-12" style="">
            <table id="tb_implement"></table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="/js/table/bootstrap-table.min.js"></script>
    <script src="/js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="/js/daterangepicker/moment.min.js"></script>
    <script src="/js/daterangepicker/daterangepicker.js"></script>
    <script src="/js/daterangepicker/DateFormat.js"></script>
    <script src="/js/layer/layer.js"></script>
    <script type="text/javascript">
        $(function () {
            initEquipmentTable();
        });
        //初始化
        function initEquipmentTable() {
            var orderSN = $("#cph_body_orderSN").val();
            //先销毁表格  
            $('#tb_equipment').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_equipment").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/RepairOrderHandler.ashx?action=getorderequipment&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: 300,
                toolbar: '#toolbar',                //工具按钮用哪个容器
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
                        orderSN: orderSN,
                    };
                    return param;
                },
                columns: [
                    {
                        field: 'order_sn',
                        title: '订单号',
                        visible: false,
                    },
                    {
                        field: 'equCode',
                        title: '设备编码',
                        align: 'center'
                    },
                    {
                        title: '设备名',
                        field: 'equName',
                        align: 'center'
                    },
                    {
                        title: '所属系统',
                        field: 'devide_type_name',
                        align: 'center'
                    },
                    {
                        title: '地点',
                        field: 'devName',
                        align: 'center'
                    },
                    {
                        title: '安装日期',
                        field: 'setupDate',
                        align: 'center'
                    },
                    {
                        title: '厂家',
                        field: 'manufacturer',
                        align: 'center'
                    }
                ]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            initImplementTable();
        });
        //初始化
        function initImplementTable() {
            var orderID = $('#cph_body_orderID').val();
            //先销毁表格  
            $('#tb_implement').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_implement").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/RepairOrderHandler.ashx?action=getorderimplementlist&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: 300,
                toolbar: '#toolbar',                //工具按钮用哪个容器
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
                        orderID: orderID,
                    };
                    return param;
                },
                columns: [
                    {
                        field: 'implement_id',
                        title: 'id',
                        visible: false,
                    },
                    {
                        field: 'device_standard',
                        title: '标准',
                        visible: false,
                    },
                    {
                        title: '设备名',
                        field: 'equName',
                        align: 'center'
                    },
                    {
                        title: '内容',
                        field: 'implement_content',
                        align: 'center'
                    },
                    {
                        title: '时间',
                        field: 'implement_time',
                        align: 'center'
                    },
                    {
                        title: '人员',
                        field: 'nickName',
                        align: 'center'
                    },
                    {
                        title: '图片',
                        align: 'center',
                        width: '100px',
                        formatter: function (value, row, index) {
                            var data = JSON.stringify(row);
                            var i = '<a  href=\'javascript:void(0);\'  style=\'margin-right:10px;\' onclick=\'viewImg(' + data + ')\'>查看图片</a> ';
                            return i;
                        }
                    },
                    {
                        title: '标准',
                        align: 'center',
                        width: '100px',
                        formatter: function (value, row, index) {
                            var data = JSON.stringify(row);
                            var d = '<a  href=\'javascript:void(0);\'  style=\'margin-right:10px;\' onclick=\'viewStandard(' + data + ')\'>查看标准</a> ';
                            return d;
                        }
                    }
                ]
            });
        }
        //查看图片
        function viewImg(row) {
            var imgurl = "";
            //请求获取图片地址
            $.ajaxSettings.async = false;//设置同步执行
            $.getJSON("../../Handler/ImplementHandler.ashx?action=getimplementimg&r=" + Math.random(),
                {
                    implementid: row.implement_id,
                    type: 3
                },
                function (res) {
                    if (res.IsSucceed) {//获取成功，组合图片
                        var array = res.Data;
                        for (var i = 0; i < array.length; i++) {
                            imgurl += "<img src=\"" + array[i].img_path + "\" style='max-width:600px;'/>";
                        }
                    }
                });

            layer.open({
                type: 1,
                title: false,
                closeBtn: 0,
                shadeClose: true,
                area: ['600px', '450px'],
                content: imgurl
            });

        }
        function viewStandard(row) {
            layer.open({
                type: 1,
                title: false,
                closeBtn: 0,
                shadeClose: true,
                area: ['600px', '450px'],
                content: "<div style='font-size: 15px !important;'>" + row.device_standard + "</div>"
            });
        }
    </script>
</asp:Content>
