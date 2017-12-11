<%@ Page Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="ElevatorInfo.aspx.cs" Inherits="IERM.Views.Elevator.ElevatorInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>小区绑定电梯注册码</title>
    <link href="/css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="/css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="/css/Wizard/prettify.css" rel="stylesheet" />
    <link href="/css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="/css/bootstrapvalidator/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="/css/bootstrap-switch/bootstrap-switch.min.css" rel="stylesheet" />
    <style type="text/css">
        #tab2 tbody input {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="container-fluid" style="padding: 0px">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group" >
                            <span class="input-group-addon">项目：</span>
                            <input id="cpartname" type="text" class="form-control" placeholder="小区名关键字">
                        </div>
                        <button id="serach" type="button" class="btn btn-info input-group" style="margin-right: 68px;">筛选</button>
                    </div>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="panel-body" style="min-height: 580px;">

                <div class="form-group col-md-3">
                    <div id="devtree"></div>
                </div>
                <div class="form-group col-md-9">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <ul id="breadcrumb">
                                <li><a href="javascript:void(0)">电梯注册码</a></li>
                                <li><a href="javascript:void(0)"><%=defaultCommunity.provincename %></a></li>
                                <li><a href="javascript:void(0)"><%=defaultCommunity.cityname %></a></li>
                                <li><a href="javascript:void(0)"><%=defaultCommunity.communityName %></a></li>
                            </ul>
                        </div>
                        <div class="panel-body">
                            <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                                <strong>操作提示</strong> <small></small>
                            </div>
                            <div id="toolbar" class="btn-group">
                                <button id="btn_add" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success" onclick="formInit()">
                                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                                </button>
                            </div>
                            <table id="tb_dev"></table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">电梯注册码绑定</h4>
                </div>
                <div class="modal-body">
                    <form id="devform" class="form-horizontal" role="form">
                        <input type="hidden" id="hd_eid" />
                        <input type="hidden" id="hd_community" value="<%=defaultCommunity.communityID %>" />
                        <div class="tab-pane" id="tab1">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">省份</label>
                                <div class="col-sm-10">
                                    <input readonly type="text" class="form-control" id="_province" value="<%=defaultCommunity.provincename %>">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">城市</label>
                                <div class="col-sm-10">
                                    <input readonly type="text" class="form-control" id="_city" value="<%=defaultCommunity.cityname %>">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">项目</label>
                                <div class="col-sm-10">
                                    <input readonly type="text" class="form-control" id="_community" value="<%=defaultCommunity.communityName %>">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="registrationCode" class="col-sm-2 control-label">电梯注册码</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="registrationCode" name="registrationCode" placeholder="电梯注册码">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="elevatorPosition" class="col-sm-2 control-label">电梯位置</label>
                                <div class="col-sm-10">
                                    <input type="text" class="form-control" id="elevatorPosition" name="elevatorPosition" placeholder="电梯位置">
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button id="rrsubmit" type="button" class="btn btn-success" onclick="save()">提交</button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript" src="/js/treeview/bootstrap-treeview.min.js"></script>
    <script type="text/javascript" src="/js/Wizard/jquery.bootstrap.wizard.min.js"></script>
    <script type="text/javascript" src="/js/Wizard/prettify.js"></script>
    <script type="text/javascript" src="/js/table/bootstrap-table.min.js"></script>
    <script type="text/javascript" src="/js/table/bootstrap-table-zh-CN.min.js"></script>
    <script type="text/javascript" src="/js/bootstrapvalidator/bootstrapValidator.min.js"></script>
    <script type="text/javascript" src="/js/bootstrapvalidator/zh_CN.js"></script>
    <script type="text/javascript" src="/js/bootstrap-switch/bootstrap-switch.min.js"></script>
    <script type="text/javascript" src="/js/jquery.tmpl.min.js"></script>
    <%--初始化tree和table--%>
    <script type="text/javascript">

        $(function () {
            initTreeView();
            initTable(<%=defaultCommunity.communityID%>);
        });

        //初始化treeview
        function initTreeView() {
            $.getJSON("/Handler/CityAndCommunity.ashx?action=getpcc&r=" + Math.random(),
                {
                    "pid":<%=defaultCommunity.provinceid%>,
                    "cid":<%=defaultCommunity.pCityID%>,
                    "cmid":<%=defaultCommunity.communityID%>,
                }, function (res) {
                    if (res.IsSucceed) {
                        var $selectableTree = $('#devtree').treeview({
                            data: res.Data,         // data is not optional
                            levels: 1,
                            //selectable: true,
                            onhoverColor: "#E8E8E8",
                            highlightSelected: true,
                            onNodeSelected: function (event, node) {
                                //alert(node.id + "---" + node.text);
                                var c = $('#devtree').treeview('getParent', node);
                                var p = $('#devtree').treeview('getParent', c);
                                //标题头
                                $('#breadcrumb a:eq(1)').text(p.text);
                                $('#breadcrumb a:eq(2)').text(c.text);
                                $('#breadcrumb a:eq(3)').text(node.text);
                                //编辑框
                                $('#_province').val(p.text);
                                $('#_city').val(c.text);
                                $('#_community').val(node.text);

                                initTable(node.id);
                                $('#hd_community').val(node.id);
                            },
                            onNodeExpanded: function (event, node) {
                                //$('#devtree').treeview('getSiblings', node).treeview('collapseNode');
                            }
                        });
                        $("#serach").on("click", function () {
                            var findSelectableNodes = function () {
                                return $selectableTree.treeview('search', [$('#cpartname').val(), { ignoreCase: true, exactMatch: false }]);
                            };
                            var selectableNodes = findSelectableNodes();
                            $selectableTree.treeview('selectNode', [selectableNodes, { silent: false }]);
                        })
                    }
                });
        }

        //初始化设备表
        function initTable(communityid) {
            //先销毁表格  
            $('#tb_dev').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_dev").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/ElevatorHandler.ashx?action=GetListInElevatorInfo&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 175,
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
                        communityID: communityid
                    };
                    return param;
                },
                onLoadSuccess: function () {  //加载成功时执行  

                },
                columns: [
                    {
                        field: 'eID',
                        title: 'eID',
                        visible: false,
                    },
                    {
                        field: 'num',
                        title: '序号',
                        align: 'center',
                        formatter: function (value, row, index) {
                            return index + 1;
                        }
                    },
                    {
                        field: 'elevatorPosition',
                        title: '电梯位置',
                        align: 'center'
                    },
                    {
                        field: 'registrationCode',
                        title: '注册码',
                        align: 'center'
                    },
                    {
                        title: '操作',
                        formatter: function (value, row, index) {
                            var data = JSON.stringify(row);
                            var e = '<a data-toggle=\'modal\' href=\'javascript:void(0);\'  data-target=\'#myModal\' style=\'margin-right:18px;\' onclick=\'edit(' + data + ')\'><span class=\'glyphicon glyphicon-edit\'></span> 编辑</a> ';
                            var d = '<a href="javascript:void(0)" onclick="del(\'' + row.eID + '\')"><span class="glyphicon glyphicon-trash"></span> 删除</a> ';
                            return e + d;
                        }
                    }]
            });
        }

    </script>

    <script>
        $(function () {
            formValidator();
        })
        $('#myModal').on('hidden.bs.modal', function () {
            $("#devform").data('bootstrapValidator').destroy();
            $('#devform').data('bootstrapValidator', null);
            formValidator();
            formInit();
        });
        function formValidator() {
            $('#devform').bootstrapValidator({
                message: '验证未通过!',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    registrationCode: {
                        message: '注册码输入无效',
                        validators: {
                            notEmpty: {
                                message: '注册码不能为空'
                            }
                        }
                    },
                    elevatorPosition: {
                        message: '电梯位置输入无效',
                        validators: {
                            notEmpty: {
                                message: '电梯位置'
                            }
                        }
                    }
                }
            });
        }
        function formInit() {
            $('#registrationCode').val("");
            $('#elevatorPosition').val("");
            $('#hd_eid').val(0);
        }
        function edit(row) {
            $('#registrationCode').val(row.registrationCode);
            $('#elevatorPosition').val(row.elevatorPosition);
            $("#hd_eid").val(row.eID);
        }
        //新增、编辑
        function save() {
            if (!$("#devform").data('bootstrapValidator').isValid()) {
                $("#devform").bootstrapValidator('validate');
                return false;
            }
            else {
                $("#devform").data("bootstrapValidator").updateStatus("registrationCode", "NOT_VALIDATED", null);
                $("#devform").data("bootstrapValidator").updateStatus("elevatorPosition", "NOT_VALIDATED", null);
            }
            $('#myModal').modal('hide');
            var id = parseInt($("#hd_eid").val());
            if (id > 0) {
                //编辑
                $.post("/Handler/ElevatorHandler.ashx",
                    {
                        "action": "EditElevatorInfo",
                        "registrationCode": $('#registrationCode').val(),
                        "elevatorPosition": $('#elevatorPosition').val(),
                        "eID": $('#hd_eid').val()
                    },
                    function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsg small').html('编辑成功！');
                            initTable($('#hd_community').val());
                        }
                        else {
                            $('#alertMsg small').html(res.Msg);
                        }
                        $('#alertMsg').show();
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
            }
            else {
                //新增
                $.post("/Handler/ElevatorHandler.ashx",
                    {
                        "action": "AddElevatorInfo",
                        "registrationCode": $('#registrationCode').val(),
                        "elevatorPosition": $('#elevatorPosition').val(),
                        "communityID": $('#hd_community').val()
                    },
                    function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsg small').html('添加成功！');
                            initTable($('#hd_community').val());
                        }
                        else {
                            $('#alertMsg small').html(res.Msg);
                        }
                        $('#alertMsg').show();
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
            }
        }
        function del(eID) {
            if (confirm("确认删除吗？")) {
                $.post("/Handler/ElevatorHandler.ashx",
                    {
                        "action": "DeleteElevatorInfo",
                        "eID": eID,
                    },
                    function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsg small').html('删除成功！');
                            initTable($('#hd_community').val());
                        }
                        else {
                            $('#alertMsg small').html(res.Msg);
                        }
                        $('#alertMsg').show();
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
            }
        }
    </script>
</asp:Content>
