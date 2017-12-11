<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Site1.Master" CodeBehind="PlanList.aspx.cs" Inherits="IERM.Views.Plan.PlanList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>计划列表</title>
    <link href="../../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../../css/jquery-confirm.min.css" rel="stylesheet" />
    <link href="../../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/ztree/metroStyle.css" rel="stylesheet" />
    <link href="/css/bootstrapvalidator/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="../../css/layer/layer.css" rel="stylesheet" />
    <link href="../../css/Wizard/prettify.css" rel="stylesheet" />
    <style>
        #tab4 table tr td {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <input type="hidden" id="userID" runat="server" />
    <section id="userlist">
        <div class="panel panel-default heightAll">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group" >
                            <span class="input-group-addon">项目选择：</span>
                            <select id="community" style="width: 250px; margin-right: 20px;">
                            </select>
                        </div>
                        <div class="input-group" >
                            <div class="controls">
                                <div class="input-prepend input-group">
                                    <span class="add-on input-group-addon">发起时间:</span>
                                    <input type="text" readonly style="width: 200px" name="reservation" id="reservation" class="form-control" value='' />
                                </div>
                            </div>
                        </div>
                        <button id="serach" type="button" class="btn btn-info input-group" style="margin-left: 20px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>
            <div class="panel-body">
                <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                    <strong>操作提示</strong> <small></small>
                </div>
                <div id="toolbar" class="btn-group">
                    <button id="adduser" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success" onclick="Reset();">
                        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                    </button>
                </div>
                <table id="tb_plan"></table>
            </div>
        </div>
    </section>


    <!--计划 start-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">报警管理</h4>
                </div>
                <div class="modal-body">
                    <section id="wizard">
                        <div id="rootwizard">
                            <div class="navbar">
                                <div class="navbar-inner">
                                    <div class="container">
                                        <ul>
                                            <li><a href="#tab1" data-toggle="tab">计划信息</a></li>
                                            <li><a href="#tab2" data-toggle="tab">设备设置</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <form id="devform" class="form-horizontal" role="form">
                                <input type="hidden" id="planid" />
                                <input type="hidden" id="communityid" />
                                <div class="tab-content">
                                    <div class="tab-pane" id="tab1">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalCommunity" class="control-label">项目选择：</label>
                                                </div>
                                            <div class="col-sm-8">
                                                <select id="modalCommunity">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalCommunity" class="control-label">计划类型：</label>
                                                </div>
                                            <div class="col-sm-8">
                                                <select id="plantype">
                                                    <option value="1">巡检</option>
                                                    <option value="2">维保</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalEndDate" class="control-label">开始时间：</label>
                                                </div>
                                            <div class="col-sm-3">
                                                <input size="16" id="modalStartDate" name="modalEndDate" type="text" readonly class="form_datetime form-control">
                                            </div>
                                            <div class="col-sm-2">
                                            <label for="modalEndDate" class="control-label"><input name="endtime" type="radio" checked="checked" value="0" />结束时间：</label>
                                                </div>
                                            <div class="col-sm-3">
                                                <input size="16" id="modalEndDate" name="modalEndDate" type="text" readonly class="form_datetime form-control">
                                                或<input name="endtime" type="radio" value="1" />无结束时间
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalEndDate" class="control-label">计划周期：</label>
                                                </div>
                                            <div class="col-sm-3">
                                                <select id="plancycle">
                                                    <option value="0">重复</option>
                                                    <option value="1">一次</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-2">
                                            <label for="modalEndDate" class="control-label">计划规则：</label>
                                                </div>
                                            <div class="col-sm-3">
                                                <select id="planrole">
                                                    <option value="0">年</option>
                                                    <option value="1">季</option>
                                                    <option value="2">月</option>
                                                    <option value="3">周</option>
                                                    <option value="4">日</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalCommunity" class="control-label">执行频率：</label>
                                                </div>
                                            <div class="col-sm-4">
                                               每<input id="txt_frequency" type="text" style="width:50px;" /><label id="lb_role">年</label>第一天生成工单
                                            </div>
                                             <div class="col-sm-4">
                                               在<input id="term_day" type="text" style="width:50px;" />天内完成
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalCommunity" class="control-label">是否启用：</label>
                                                </div>
                                            <div class="col-sm-8">
                                                <input name="planstates" type="radio" checked="checked" value="1" />启用
                                                <input name="planstates" type="radio" value="0" />禁用
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            <label for="modalCommunity" class="control-label">关联设备：</label>
                                                </div>
                                            <div class="col-sm-8">
                                                <input name="choosetype" type="radio" checked="checked" value="0" />设备类型
                                                <input name="choosetype" type="radio" value="1" />设备
                                            </div>
                                        </div>
                                    </div>

                                    <div class="tab-pane" id="tab2">
                                        <div class="form-group">
                                            <label for="modalEqu" class="control-label">选择：</label>
                                            <div id="devtree" class="ztree"></div>
                                        </div>
                                    </div>

                                    <ul class="pager wizard">
                                        <li class="previous"><a href="javascript:void(0);">上一步</a></li>
                                        <li class="next"><a href="javascript:void(0);">下一步</a></li>
                                        <li class="finish"><a href="javascript:void(0);">保 存</a></li>
                                    </ul>
                                </div>
                            </form>

                        </div>
                    </section>

                </div>
                <div class="modal-footer">
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->

    </div>
    <!--计划 end-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../../js/table/bootstrap-table.min.js"></script>
    <script src="../../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../js/daterangepicker/moment.min.js"></script>
    <script src="../../js/daterangepicker/daterangepicker.js"></script>
    <script src="../../js/daterangepicker/DateFormat.js"></script>
    <script src="../../js/datetimepicker/bootstrap-datetimepicker.js"></script>
    <script src="../../js/datetimepicker/bootstrap-datetimepicker.zh-CN.js"></script>
    <script src="../../js/jquery-confirm.min.js"></script>
    <script src="../../js/select2andtree/select2.min.js"></script>
    <script src="../../js/select2andtree/i18n/zh-CN.js"></script>
    <script src="../../js/select2andtree/select2tree.js"></script>
    <script src="../../js/ztree/jquery.ztree.all.js"></script>
    <script type="text/javascript" src="/js/bootstrapvalidator/bootstrapValidator.min.js"></script>
    <script type="text/javascript" src="/js/bootstrapvalidator/zh_CN.js"></script>
    <script type="text/javascript" src="../../js/Wizard/jquery.bootstrap.wizard.min.js"></script>
    <script type="text/javascript" src="../../js/Wizard/prettify.js"></script>
    <script src="../../js/layer/layer.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#serach').click(function () {
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

            initCommunitySelect();
        });
        //初始化
        function initTable() {
            var communityID = $('#community option:selected').data("value");
            var timeSpan = $('#reservation').val();
            //先销毁表格  
            $('#tb_plan').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_plan").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/PlanHandler.ashx?action=getplan&r=" + Math.random(), //获取数据的Servlet地址  
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
                        communityID: communityID,
                        timeSpan: timeSpan,
                    };
                    return param;
                },
                columns: [
                    {
                        field: 'plan_id',
                        title: '计划id',
                        visible: true,
                        align: 'center'
                    },
                    {
                        field: 'plan_stime',
                        title: '开始时间',
                        align: 'center',
                        formatter: function (value) {
                            return new Date(parseInt(value) * 1000).toLocaleString().substr(0, 9);
                        }
                    },
                    {
                        field: 'plan_etime',
                        title: '结束时间',
                        align: 'center',
                        formatter: function (value) {
                            if (value != null) {
                                return new Date(parseInt(value) * 1000).toLocaleString().substr(0, 9);
                            }
                            else { return "无";}
                        }
                    },
                    {
                        title: '说明',
                        align: 'left',
                        formatter: function (value, row, index) {
                            var c = "该计划为：";
                            c += row.plan_type == "1" ? "巡检计划" : "维保计划";
                            c += "   与";
                            c += row.choose_type == "0" ? "设备类型" : "设备";
                            c += "关联";
                            var a = "周期：";
                            a += row.plan_cycle == "0" ? "重复" : "一次";
                            var b = "每" + row.execution_frequency;
                            var role = row.plan_role
                            if (role == "0") { role = "年"; }
                            else if (role == "1") { role = "季"; }
                            else if (role == "2") { role = "月"; }
                            else if (role == "3") { role = "周"; }
                            else if (role == "4") { role = "日"; }
                            else { }
                            b += role;
                            b += "第一天执行  在" + row.term_day + "天内完成";
                            return c + "<br />" + a + "<br />" + b;
                        }
                    },
                    {
                        title: '状态',
                        field: 'plan_stats',
                        align: 'center',
                        formatter: function (value, row, index) {
                            if (value == 0) {
                                return "禁用";
                            } else if (value == 1) {
                                return "启用";
                            }
                        }
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: '150px',
                        formatter: function (value, row, index) {
                            var data = encodeURI(JSON.stringify(row));
                            var s = '<a  href=\'javascript:void(0);\' onclick=\'updatestates('
                            s += row.plan_stats == "0" ? "1" : "0";
                            s += "," + row.plan_id + ')\'> ';
                            s += row.plan_stats == "0" ? "启用" : "禁用";
                            s += '</a> ';
                            var e = '<a data-toggle=\'modal\' data-target=\'#myModal\' href=\'javascript:void(0)\' onclick=\'edit("' + data + '")\'>编辑</a> ';
                            //var a = '<a target="_blank" href="PlanDetail.aspx?id=' + row.plan_id + '")\'>详情</a> ';
                            var d = '<a href="javascript:void(0)" onclick="del(\'' + row.plan_id + '\')"> 删除</a> ';
                            return e + "<br />" + s + d;
                        }
                    }
                ]
            });
        }

        //加载小区
        function initCommunitySelect() {
            $.getJSON("/Handler/CityAndCommunity.ashx?action=getcommunitybyuser&r=" + Math.random(), { userID: $("#cph_body_userID").val() }, function (res) {
                if (res.IsSucceed) {
                    $("#community").append(res.Data).select2tree();
                    initTable();
                }
            });
        }
    </script>
    <%--modal--%>
    <script>
        //向导插件
        $(function () {
            $('.form_datetime').val(new Date().Format('yyyy-MM-dd'));
            $('.form_datetime').datetimepicker({
                language: 'zh-CN',
                format: 'yyyy-mm-dd',
                weekStart: 1,
                todayBtn: 1,
                clearBtn: true,
                autoclose: 1,
                todayHighlight: 1,
                startView: 2,
                minView: 2,
                forceParse: true,
            });

            $.getJSON("/Handler/CityAndCommunity.ashx?action=getcommunitybyuser&r=" + Math.random(), { userID: $("#cph_body_userID").val() }, function (res) {
                if (res.IsSucceed) {
                    $("#modalCommunity").append(res.Data).select2tree();

                    //initTreeView($('#modalCommunity option:selected').data("value"));
                }
            });

            //向导插件 显示和下一步
            $('#rootwizard').bootstrapWizard({
                onTabShow: function (tab, navigation, index) {

                },
                onNext: function (tab, navigation, index) {
                    if (vail_add()) {
                        initTreeView($('#modalCommunity option:selected').data("value"), $("input[name='choosetype']:checked").val());
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            });
            //向导插件 完成
            $('#rootwizard .finish').click(function () {
                if (vail_add2()) {
                    var equCodes = [];//所勾选的树菜单内容
                    var tree = $menuTree.getCheckedNodes();
                    $.each(tree, function (i, n) {
                        if (n.id != 0)
                            equCodes.push(n.id);
                    });

                    var endtime = $("input[name='endtime']:checked").val();//结束时间判断
                    if (endtime == "0") {
                        endtime = $("#modalEndDate").val();
                    }
                    else { endtime = ""; }

                    //保存
                    if ($('#planid').val() == "") {
                        //新增操作
                        $.post("../../Handler/PlanHandler.ashx",
                            {
                                "action": "addplan",
                                "plancycle": $("#plancycle").val(),
                                "planrole": $('#planrole').val(),
                                "executionfrequency": $('#txt_frequency').val(),
                                "term_day": $('#term_day').val(),
                                "planstime": $('#modalStartDate').val(),
                                "planetime": endtime,
                                "communityID": $('#modalCommunity option:selected').data("value"),
                                "planstats": $("input[name='planstates']:checked").val(),
                                "choosetype": $("input[name='choosetype']:checked").val(),
                                "plantype": $("#plantype").val(),
                                "Codes": equCodes.join(',')
                            },
                            function (res) {
                                if (res.IsSucceed) {
                                    $('#alertMsg small').html('添加成功！');
                                    $('#alertMsg').show();
                                    $("#myModal").modal("hide");
                                    initTable();
                                }
                                else {
                                    $('#alertMsg small').html('添加失败！');
                                }
                                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                            }, "json");
                    }
                    //更新
                    else {
                        var communityID = $('#modalCommunity option:selected').data("value");//小区判断
                        if (typeof (communityID) == "") {
                            communityID = $("#communityid").val();
                        }
                        //更新操作
                        $.post("../../Handler/PlanHandler.ashx",
                            {
                                "action": "updateplan",
                                "plancycle": $("#plancycle").val(),
                                "planrole": $('#planrole').val(),
                                "executionfrequency": $('#txt_frequency').val(),
                                "term_day": $('#term_day').val(),
                                "planstime": $('#modalStartDate').val(),
                                "planetime": endtime,
                                "communityID": communityID,
                                "planstats": $("input[name='planstates']:checked").val(),
                                "choosetype": $("input[name='choosetype']:checked").val(),
                                "plantype": $("#plantype").val(),
                                "Codes": equCodes.join(','),
                                "planid": $("#planid").val()
                            },
                            function (res) {
                                if (res.IsSucceed) {
                                    $('#alertMsg small').html('修改成功！');
                                    $('#alertMsg').show();
                                    $("#myModal").modal("hide");
                                    initTable();
                                }
                                else {
                                    $('#alertMsg small').html('修改失败！');
                                }
                                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                            }, "json");
                    }
                }
            });

            $("#planrole").change(function () {
                $("#lb_role").html($("#planrole").find("option:selected").text());
            });

        })

        var $menuTree;
        //初始化treeview  第二步显示的树内容
        function initTreeView(communityID, type) {
            $.getJSON("/Handler/EquipmentHandler.ashx?action=getequipmentinfolistbycommunityforplan&r=" + Math.random(),
                {
                    communityID: communityID,
                    type: type
                },
                function (res) {
                    if (res.IsSucceed) {
                        if (type == "1")//显示设备
                        {
                            var array = [];
                            var obj = [];
                            $.each(res.Data, function (i, n) {
                                obj[n.devide_type_name] = n.devide_type_name;
                            });
                            for (var key in obj) {//遍历键值对  
                                var p = { "text": key, "id": 0 };
                                var temp = [];
                                $.each(res.Data, function (i, n) {
                                    if (n.devide_type_name == key) {
                                        var d = { "text": n.equName, "id": n.equCode };
                                        temp.push(d)
                                    }
                                });
                                p.nodes = temp;
                                array.push(p);
                            }


                            $menuTree = $.fn.zTree.init($('#devtree'), {
                                data: {
                                    key: {
                                        name: "text",
                                        children: "nodes",
                                    }
                                },
                                check: {
                                    enable: true
                                },
                                callback: {
                                    onClick: function (e, treeId, treeNode, clickFlag) {
                                        $menuTree.checkNode(treeNode, !treeNode.checked, true);
                                    }
                                }
                            }, array);
                            $menuTree.expandAll(true);
                        }
                        else if (type == "0")//显示设备类型
                        {
                            var array = [];
                            $.each(res.Data, function (i, n) {
                                var p = { "text": n.devide_type_name, "id": n.device_type_code };
                                array.push(p);
                            });
                            $menuTree = $.fn.zTree.init($('#devtree'), {
                                data: {
                                    key: {
                                        name: "text",
                                        //children: "nodes",
                                    }
                                },
                                check: {
                                    enable: true
                                },
                                callback: {
                                    onClick: function (e, treeId, treeNode, clickFlag) {
                                        $menuTree.checkNode(treeNode, !treeNode.checked, true);
                                    }
                                }
                            }, array);
                            $menuTree.expandAll(true);
                        }
                    }
                });
        }

    </script>
    <%--表单--%>
    <script>
        //编辑显示计划
        function edit(obj) {            
            var data = JSON.parse(decodeURI(obj));
            $("#planid").val(data.plan_id);
            $("#communityid").val(data.communityID);
            $("#plantype option[value='" + data.plan_type + "']").attr("selected", true);
            $("#modalStartDate").val(formattime(data.plan_stime));
            if (data.plan_etime != "") { $("#modalEndDate").val(formattime(data.plan_etime)); $("input[name='endtime'][value='0']").attr("checked", true); }
            else { $("input[name='endtime'][value='1']").attr("checked", true); }
            $("#plancycle option[value='" + data.plan_cycle + "']").attr("selected", true);
            $("#planrole option[value='" + data.plan_role + "']").attr("selected", true);
            $("#lb_role").html($("#planrole").find("option:selected").text());
            $("#txt_frequency").val(data.execution_frequency);
            $("#term_day").val(data.term_day);
            $("input[name='planstates'][value='" + data.plan_stats + "']").attr("checked", true);
            $("input[name='choosetype'][value='" + data.choose_type + "']").attr("checked", true);
        }
        //删除计划
        function del(planid) {
            if (confirm("确认删除吗？")) {
                $.post("/Handler/PlanHandler.ashx",
                    {
                        "action": "deleteplan",
                        "planID": planid,
                    },
                    function (res) {
                        if (res.IsSucceed) {
                            $('#alertMsg small').html('删除成功！');
                            initTable();
                        }
                        else {
                            $('#alertMsg small').html(res.Msg);
                        }
                        $('#alertMsg').show();
                        setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                    }, "json");
            }
        }
        //修改计划状态
        function updatestates(planstates, planid) {
            $.post("/Handler/PlanHandler.ashx",
                {
                    "action": "updatestates",
                    "planid": planid,
                    "planstats": planstates
                },
                function (res) {
                    if (res.IsSucceed) {
                        $('#alertMsg small').html('修改成功！');
                        initTable();
                    }
                    else {
                        $('#alertMsg small').html(res.Msg);
                    }
                    $('#alertMsg').show();
                    setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                }, "json");
        }
        function alertHide() {
            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
        }

        //验证开始
        function vail_add() {
            if ($("#txt_frequency").val() == "" || $("#term_day").val() == "" || isNaN($("#txt_frequency").val()) == true || isNaN($("#term_day").val()) == true) {
                alert("执行频率必填,且为数字！");
                return false;
            }
            return true;
        }
        function vail_add2()
        {
            var tree = $menuTree.getCheckedNodes();
            if (tree.length == 0) {
                alert("请勾选设备类型或者设备！");
                return false;
            }
            return true;
        }
        //验证结束

        //时间戳转为时间 开始
        function add0(m) { return m < 10 ? '0' + m : m }
        function formattime(timestamp) {
            //timestamp是整数，否则要parseInt转换,不会出现少个0的情况

            var time = new Date(timestamp*1000);
            var year = time.getFullYear();
            var month = time.getMonth() + 1;
            var date = time.getDate();
            return year + '-' + add0(month) + '-' + add0(date);
        }
        //时间戳转为时间 结束

        function Reset()
        {
            $("#planid").val("");
            $("#communityid").val();
        }
    </script>
</asp:Content>
