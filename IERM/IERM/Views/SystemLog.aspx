<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="SystemLog.aspx.cs" Inherits="IERM.Views.SystemLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>系统日志</title>
    <link href="../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class='container-fluid'>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group">
                            <span class="input-group-addon">操作类型：</span>
                            <select class="form-control" id="typeselect">
                                <option selected value="0">全部</option>
                                <option value="1">添加用户</option>
                                <option value="2">编辑用户</option>
                                <option value="3">删除用户</option>
                                <option value="4">报警设置</option>
                                <option value="5">用户登录</option>
                            </select>
                        </div>
                        <div class="input-group" style="margin-left: 30px;">
                            <span class="input-group-addon">昵称：</span>
                            <input id="nickname" type="text" class="form-control" placeholder="昵称关键字">
                        </div>

                        <div class="input-group" style="margin-left: 30px;">
                            <div class="controls">
                                <div class="input-prepend input-group">
                                    <span class="add-on input-group-addon">时间段:</span>
                                    <input type="text" readonly style="width: 200px" name="reservation" id="reservation" class="form-control" value='' />
                                </div>
                            </div>
                        </div>

                        <button id="serachlog" type="button" class="btn btn-info" style="margin-left: 20px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <table id="tb_log"></table>
            </div>
        </div>

    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">用户操作详情</h4>
                </div>
                <div class="modal-body" style="min-height: 450px;">
                    <ul class="list-group">
                        
                    </ul>
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
    <script type="text/javascript">
        $(function () {
            $('#serach').click(function () {
                $('#reservation').startDate()
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

            initTable();

            $('#serachlog').click(function () {
                initTable();
            });
        });

        //初始化系统日志
        function initTable() {
            //先销毁表格  
            $('#tb_log').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_log").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/SysLog.ashx?action=getsyslog&r=" + Math.random(), //获取数据的Servlet地址  
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
                        typeID: $('#typeselect').val(),
                        partName: $('#nickname').val().trim(),
                        timeSpan: $('#reservation').val()
                    };
                    return param;
                },
                onLoadSuccess: function () {  //加载成功时执行  

                },
                onLoadError: function () {  //加载失败时执行  

                },
                columns: [{
                    field: 'num',
                    title: '序号',
                    align: 'center',
                    formatter: function (value, row, index) {
                        return index + 1;
                    }
                },
                {
                    field: 'nickName',
                    title: '昵称',
                    align: 'center',
                    //formatter: function (value, row, index) {
                    //    return '<img style="width:32px;height:32px;" src=' + row.headimg + ' alt=' + row.nickName + ' />';
                    //}
                },
                 {
                     field: 'ipAddress',
                     title: '登录IP',
                     align: 'center',
                     //formatter: function (value, row, index) {
                     //    return '<img style="width:32px;height:32px;" src=' + row.headimg + ' alt=' + row.nickName + ' />';
                     //}
                 },
                {
                    field: 'typeName',
                    title: '操作类型',
                    align: 'center',
                    clickToSelect: false
                },
                {
                    field: 'opTime',
                    title: '操作时间',
                    align: 'center'
                },
                {
                    title: '内容',
                    formatter: function (value, row, index) {
                        return '<a href="javascript:void(0)" onclick="show(\'' + row.oid + '\')">详情</a> ';
                    }
                }]
            });
        }

        function show(oid) {
            $('#myModal').modal('show');

            $.getJSON("../Handler/SysLog.ashx?action=getlogdetails&r=" + Math.random(), { "oid": oid }, function (res) {
                if (res.IsSucceed) {
                    $('#myModal .list-group').empty();
                    $.map(res.Data, function (val) {
                        $('#myModal .list-group').append("<li class='list-group-item'>"+val+"</li>");
                    });
                    
                }
            });
        }
    </script>
</asp:Content>
