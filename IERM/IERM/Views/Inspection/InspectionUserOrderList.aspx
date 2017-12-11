<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Site1.Master" CodeBehind="InspectionUserOrderList.aspx.cs" Inherits="IERM.Views.Inspection.InspectionUserOrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>巡检工单列表</title>
    <link href="../../css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../../css/jquery-confirm.min.css" rel="stylesheet" />
    <link href="../../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/ztree/metroStyle.css" rel="stylesheet" />
    <link href="/css/bootstrapvalidator/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="../../css/layer/layer.css" rel="stylesheet" />

    <!--批量上传文件样式-->
    <link href="../../Extend/fileinput/css/fileinput.css" rel="stylesheet" />
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
                <table id="tb_Inspection"></table>
            </div>
        </div>
    </section>

    <!--完成巡检工单 start-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <form id="InspectionForm" class="form-horizontal" role="form">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">提交工单实施记录</h4>
                    </div>
                    <div class="modal-body">
                        <div class="tab-pane" id="tab1">
                            <div class="col-lg-10">
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label for="modalCommunity" class="control-label">工单id：</label>
                                    </div>
                                    <div class="col-sm-8">
                                        <input class="form-control" type="text" readonly="readonly" id="orderID" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label for="modalCommunity" class="control-label">工单编号：</label>
                                    </div>
                                    <div class="col-sm-8">
                                        <input class="form-control" type="text" readonly="readonly" id="orderSN" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label for="modalEndDate" class="control-label">实施内容：</label>
                                    </div>
                                    <div class="col-sm-8">
                                        <textarea id="implement_content" class="form-control"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label for="modalEndDate" class="control-label">上传图片：</label>
                                    </div>
                                    <div class="col-sm-10">
                                        <input id="adImg" name="adImg" type="file" multiple class="file-loading" data-val="true" data-val-required="请选择图片.">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="clear: both;">
                        <button type="button" class="btn btn-success" onclick="save()">完成工单</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                        <input type="hidden" id="hidimg" />
                    </div>

                </form>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal -->
    </div>
    <!--完成巡检工单 end-->
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
    <script src="../../js/layer/layer.js"></script>

    <!--批量上传文件js-->
    <script src="../../Extend/fileinput/js/fileinput.js"></script>
    <script src="../../Extend/fileinput/js/zh.js"></script>
    <script src="../../Extend/fileinput/js/plugins/canvas-to-blob.js"></script>
    <script src="../../Extend/fileinput/js/plugins/purify.js"></script>
    <script src="../../Extend/fileinput/js/plugins/sortable.js"></script>

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
            $('#tb_Inspection').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_Inspection").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "/Handler/InspectionOrderHandler.ashx?action=getInspectionuserorderlist&r=" + Math.random(), //获取数据的Servlet地址  
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
                        field: 'order_id',
                        title: '主键',
                        visible: false,
                    },
                    {
                        field: 'community_id',
                        title: '小区id',
                        visible: false,
                    },
                    {
                        field: 'order_sn',
                        title: '订单号',
                        align: 'center'
                    },
                    {
                        title: '省',
                        field: 'areaName',
                        align: 'center'
                    },
                    {
                        title: '市',
                        field: 'cityName',
                        align: 'center'
                    },
                    {
                        field: 'propertyName',
                        title: '物业',
                        align: 'center'
                    },
                    {
                        title: '小区',
                        field: 'communityName',
                        align: 'center'
                    },
                    {
                        title: '发起时间',
                        field: 'order_time',
                        align: 'center',
                        formatter: function (value) {
                            return new Date(parseInt(value) * 1000).toLocaleString().substr(0, 9);
                        }
                    },
                    {
                        title: '状态',
                        field: 'order_stats',
                        align: 'center',
                        formatter: function (value, row, index) {
                            if (value == 0) {
                                return "未派单";
                            } else if (value == 1) {
                                return "已派单";
                            } else if (value == 2) {
                                return "已接单";
                            } else if (value == 3) {
                                return "处理中";
                            } else if (value == 4) {
                                return "完成";
                            }
                        }
                    },
                    {
                        title: '详情',
                        align: 'center',
                        width: '100px',
                        formatter: function (value, row, index) {
                            var data = JSON.stringify(row);
                            var i = '<a  href=\'javascript:void(0);\'  style=\'margin-right:10px;\' onclick=\'detail(' + data + ')\'><span class=\'glyphicon glyphicon-user\'></span> 查看</a> ';
                            return i;
                        }
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: '150px',
                        formatter: function (value, row, index) {
                            if (row.order_stats != "4") {
                                var c = '<a data-toggle="modal" href="javascript:void(0)"  data-target="#myModal" onclick="submitorder(\'' + row.order_sn + '\',\'' + row.order_id + '\')"><span class="glyphicon glyphicon-edit"></span>提交记录</a> ';
                                return c;
                            }
                            else { return "-"; }
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

                    initTreeView($('#modalCommunity option:selected').data("value"));
                }
            });


            $('#modalCommunity').change(function () {
                initTreeView($('#modalCommunity option:selected').data("value"));
            });

        })

        var $menuTree;
        //初始化treeview
        function initTreeView(communityID) {
            $.getJSON("/Handler/EquipmentHandler.ashx?action=getequipmentinfolistbycommunity&r=" + Math.random(), { communityID: communityID }, function (res) {
                if (res.IsSucceed) {
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
            });

        }

    </script>
    <%--表单--%>
    <script>
        //完成巡检工单
        function save() {
            if (vail()) {//验证参数，才能提交保存
                var order_id = $("#orderID").val();
                var order_sn = $("#orderSN").val();
                var content = $("#implement_content").val();
                var imgurl = $("#hidimg").val();
                $.post("../../Handler/ImplementHandler.ashx",
                    {
                        "action": "addinspectionimplement",
                        "orderid": order_id,
                        "ordersn": order_sn,
                        "content": content,
                        "imgurl": imgurl,
                        "type": 1 //1巡检2维保3维修，此处用1
                    },
                    function (res) {
                        if (res.IsSucceed) {
                            $('#myModal').modal('hide');
                            $('#alertMsg small').html('提交成功！');
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
        //详情
        function detail(row) {
            window.location = "/Views/Inspection/InspectionOrderDetail.aspx?orderID=" + row.order_id;
        }
        function alertHide() {
            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
        }
        function submitorder(order_sn, order_id) {
            $("#orderSN").val(order_sn);
            $("#orderID").val(order_id);
        }

        //上传图片
        var $adImg = $("#adImg");
        $(function () {
            var $fileinput = $adImg.fileinput({
                language: "zh",
                uploadUrl: "../../Handler/UploadImgHandler.ashx?action=uploadimg",
                uploadAsync: true,
                initialPreviewAsData: true,
                allowedFileExtensions: ['png', 'jpg', 'gif', 'bmp', 'svg', 'jpeg'],
                showUpload: true,
                validateInitialCount: true,
                showPreview: true,
                maxFileCount: 20
            });
            $fileinput.on('fileuploaderror', function (event, data, msg) {
                //ajaxLoadBtn("subbtn", 0);
                //refurbishHiddenToken();
            });
            //上传成功回掉
            $fileinput.on("fileuploaded", function (event, data) {
                var imgurl = data.response.Data;//图片上传成功后返回的地址
                //alert(imgurl);
                //把图片地址保存到隐藏空间中
                if ($("#hidimg").val() == "") {
                    $("#hidimg").val(imgurl);
                }
                else {
                    $("#hidimg").val($("#hidimg").val() + "," + imgurl);
                }
            })
        })

        //验证开始
        function vail() {
            if ($("#implement_content").val() == "") {
                alert("实施内容必填！");
                return false;
            }
            if ($("#hidimg").val() == "") {
                alert("必须上传实施图片！");
                return false;
            }
            return true;
        }
        //验证结束
    </script>
</asp:Content>
