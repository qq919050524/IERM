<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="EnergyEntering.aspx.cs" Inherits="IERM.Views.EnergyEntering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>能耗录入</title>
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/datetimepicker/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
    <link href="../css/jquery-confirm.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">

    <div class='container-fluid'>
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="form-inline">
                    <div class="text-left">
                        <div class="input-group" style="margin-right: 10px;">
                            <span class="input-group-addon">省份：</span>
                            <select class="form-control" id="province">
                            </select>
                        </div>
                        <div class="input-group" style="margin-right: 10px;">
                            <span class="input-group-addon">城市：</span>
                            <select class="form-control" id="city">
                            </select>
                        </div>
                        <div class="input-group" style="margin-right: 10px;">
                            <span class="input-group-addon">小区：</span>
                            <select class="form-control" id="community">
                            </select>
                        </div>
                        <div class="input-group" style="margin-right: 10px;">
                            <span class="input-group-addon">能耗类型：</span>
                            <select class="form-control" id="typeselect">
                                <option selected value="0">全部</option>
                                <option value="1">用电能耗</option>
                                <option value="2">用水能耗</option>
                                <option value="3">用气能耗</option>
                            </select>
                        </div>
                        <div class="input-group" style="margin-right: 10px; width: 150px;">
                            <div class="input-group-addon">时间：</div>
                            <input size="16" type="text" id="qym" readonly class="form_datetime form-control">
                        </div>

                        <button id="serachlog" type="button" class="btn btn-info"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div id="alertMsg" style="display: none;" class="alert alert-info alert-dismissible" role="alert">
                    <strong>操作提示</strong> <small></small>
                </div>
                <div id="toolbar" class="btn-group text-right" style="margin-bottom: 10px;">
                    <button id="btn_add" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success">
                        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                    </button>
                </div>
                <table id="tb_energy"></table>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-lg modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">能耗录入</h4>
                </div>
                <div class="modal-body" style="min-height: 450px;">
                    <ul id="breadcrumb">
                        <li><a href="javascript:void(0);"></a></li>
                        <li><a href="javascript:void(0);"></a></li>
                        <li><a href="javascript:void(0);"></a></li>
                        <li><a href="javascript:void(0);"></a></li>
                    </ul>

                    <form id="eneform" role="form">
                        <input type="hidden" id="hd_operate" />
                        <input type="hidden" id="hd_communityID" name="hd_communityID" />
                        <input type="hidden" id="hidPid" />
                        <input type="hidden" id="hidTid" />
                        <input type="hidden" id="hidNid" />
                        <input type="hidden" id="hidValue" />
                        <div class="row">
                            <div class="col-md-3">
                                <div class="input-group">
                                    <div class="input-group-addon" style="width: 80px;">
                                        时间：
                                    </div>
                                    <input id="sym" name="sym" type="text" readonly="readonly" class="form_datetime form-control" style="width: 80px;">
                                </div>
                                <div class="input-group  energytypelist" style="width: 160px; text-align: center">
                                    <a href="javascript:void(0);" class="list-group-item" data-typeid="1">用电能耗</a>
                                    <a href="javascript:void(0);" class="list-group-item" data-typeid="2">用水能耗</a>
                                    <a href="javascript:void(0);" class="list-group-item" data-typeid="3">用气能耗</a>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <div class="row">
                                    <div id="right_content" class="panel panel-default col-lg-11" style="min-height: 250px; padding: 10px;">
                                    </div>
                                </div>

                            </div>
                        </div>
                    </form>

                    <div class="modal-footer">
                        <button id="rrsubmit" type="button" class="btn btn-success">提交</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script src="../js/table/bootstrap-table.min.js"></script>
    <script src="../js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="../js/datetimepicker/bootstrap-datetimepicker.js"></script>
    <script src="../js/jquery-confirm.min.js"></script>
    <script src="../js/datetimepicker/bootstrap-datetimepicker.zh-CN.js"></script>

    <script type="text/javascript">
        $(function () {
            $('.form_datetime').datetimepicker({
                startDate: new Date().toLocaleDateString(),
                language: 'zh-CN',
                format: 'yyyy-mm',
                weekStart: 1,
                todayBtn: 1,
                clearBtn: true,
                autoclose: 1,
                todayHighlight: 1,
                startView: 3,
                minView: 3,
                forceParse: 0,
            });

            //添加 能耗记录
            $('#btn_add').click(function () {
                changetitle();
                $('#hd_operate').val(0);
                $('#right_content').empty();
                $("#sym").val("");
                $('#hd_communityID').val($('#community').val());
                $(".energytypelist a").removeClass("list-group-item-info");
            });

            $('#serachlog').click(function () {
                initTable();
            });

            //加载省份信息
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getprovinces&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#province option').remove();
                    $.map(res.Data, function (item) {
                        $('#province').append("<option value='" + item.areaID + "'>" + item.areaName + "</option>")
                    });
                    initCityList($('#province').val());
                }
            });

            //省份切换
            $('#province').change(function () {
                $('#city option').remove();
                initCityList($('#province').val());
            });

            //城市切换
            $('#city').change(function () {
                $('#community option').remove();
                initCommunityList($('#city').val());
            });
            //能耗切换
            $(".energytypelist a").click(function () {
                $(this).addClass("list-group-item-info").siblings().removeClass("list-group-item-info");

                var pid = $(this).attr("data-typeid")
                createtmpl(pid);

                var tid = $("#hidTid").val();
                //alert($("#hidValue").val());
                //加载数据
                setTimeout(function () {
                    $("#right_content input[name='t" + tid + "']").val($("#hidValue").val());
                    $("#right_content input[name='t" + tid + "']").attr("data-nid", $("#hidNid").val());
                    $("#right_content input[name!='t" + tid + "']").attr("disabled", "disabled");
                }, 100);
            });

            //添加 编辑后保存能耗
            $('#rrsubmit').click(function () {
                var count = 0;
                $("#right_content input").each(function () {
                    if ($(this).val().length == 0) {
                        $(this).attr("disabled", "disabled");
                    } else {
                        count++;
                    }
                });

                if ($('#hd_operate').val() == 0 && count > 0) {
                    $.post("../Handler/EnergyHandler.ashx?action=add", { "pms": $('#eneform').serialize() }, function (res) {
                        $('#alertMsg small').html(res.Msg);
                        if (res.IsSucceed) {
                            $('#alertMsg').show();
                            initTable();
                        }
                    }, "json");
                }
                else {
                    $.post("../Handler/EnergyHandler.ashx?action=update",
                        {
                            "newdata": $("#right_content input[data-nid]").val(),
                            "eneid": $("#right_content input[data-nid]").data("nid")
                        }, function (res) {
                            $('#alertMsg small').html(res.Msg);
                            if (res.IsSucceed) {
                                $('#alertMsg').show();
                                initTable();
                            }
                        }, "json");
                }
                $('#myModal').modal('hide');
                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
            });
        });

        //加载城市信息
        function initCityList(pid) {
           
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcitys&pid=" + pid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#city option').remove();
                    $.map(res.Data, function (item) {
                        $('#city').append("<option value='" + item.areaID + "'>" + item.areaName + "</option>")
                    });

                    initCommunityList($('#city').val());
                }
            });
        };

        //加载小区信息
        function initCommunityList(cid) {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getcommunity&cid=" + cid + "&r=" + Math.random(), null, function (res) {
                if (res.IsSucceed) {
                    $('#community option').remove();
                    $.map(res.Data, function (item) {
                        $('#community').append("<option value='" + item.communityID + "'>" + item.communityName + "</option>")
                    });
                    $('#hd_communityID').val($('#community option').val());
                    //initTable();
                }
            });
        }

        //初始化能耗表
        function initTable() {
            //先销毁表格  
            $('#tb_energy').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_energy").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/EnergyHandler.ashx?action=getenergylog&r=" + Math.random(), //获取数据的Servlet地址  
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
                        communityID: $('#community').val(),
                        pTypeID: $('#typeselect').val(),
                        egyDate: $("#qym").val()
                    };
                    return param;
                },
                columns: [
                {
                    field: 'typeName',
                    title: '类型名',
                    align: 'center',
                    formatter: function (value, row, index) {
                        return "<p data-tid='" + row.tID + "' data-pid='" + row.pID + "' data-nid='" + row.nID + "'>" + value + "</p>";
                    }
                },
                {
                    field: 'year',
                    title: '年份',
                    align: 'center'
                },
                {
                    field: 'month',
                    title: '月份',
                    align: 'center'
                },
                {
                    field: 'engValue',
                    title: '能耗值',
                    align: 'center'
                },
                {
                    field: 'insertTime',
                    title: '录入时间',
                    align: 'center',
                },
                {
                    title: '操作',
                    formatter: function (value, row, index) {
                        var e = '<a data-toggle="modal" href="javascript:void(0);"  data-target="#myModal" style="margin-right:18px;" onclick="edit(this)"><span class="glyphicon glyphicon-edit"></span> 编辑</a> ';
                        var d = '<a href="javascript:void(0)" onclick="del(\'' + row.nID + '\')"><span class="glyphicon glyphicon-trash"></span> 删除</a> ';
                        return e + d;
                    }
                }]
            });
        }

        //编辑
        function edit(obj) {
            changetitle();
            $('#hd_operate').val(1);
            var thisrow = $(obj).parent().parent();
            var nid = thisrow.find("td:eq(0) p").data("nid");
            var tid = thisrow.find("td:eq(0) p").data("tid");
            var pid = thisrow.find("td:eq(0) p").data("pid");
            $("#hidNid").val(nid);
            $("#hidPid").val(pid);
            $("#hidTid").val(tid);
            createtmpl(pid);
            $(".energytypelist").find("a[data-typeid='" + pid + "']").addClass("list-group-item-info").siblings().removeClass("list-group-item-info");
            $('#hd_communityID').val($('#community').val());
            setTimeout(function () {
                $("#right_content input[name='t" + tid + "']").val(thisrow.find("td:eq(3)").text());
                $("#right_content input[name='t" + tid + "']").attr("data-nid", nid);
                $("#right_content input[name!='t" + tid + "']").attr("disabled", "disabled");
                $("#sym").val(thisrow.find("td:eq(1)").text() + "-" + thisrow.find("td:eq(2)").text());
                $("#hidValue").val(thisrow.find("td:eq(3)").text());//将能耗值存储起来
            }, 100);
        }

        //删除
        function del(nid) {
            $.confirm({
                title: '警告',
                content: "您确定要删除该条能耗数据吗？",
                buttons: {
                    ok: {
                        text: "确定",
                        btnClass: 'btn-primary',
                        keys: ['enter'],
                        action: function () {
                            $.post("../Handler/EnergyHandler.ashx?action=delete",
                       {
                           "eneid": nid
                       }, function (res) {
                           $('#alertMsg small').html(res.Msg);
                           if (res.IsSucceed) {
                               $('#alertMsg').show();
                               initTable();
                           }
                       }, "json");
                            $('#myModal').modal('hide');
                            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                        }
                    },
                    cancel: {
                        text: "取消",
                        btnClass: 'btn-default',
                        keys: ['Esc']
                    }
                }
            });
        }

        //更新小区指示
        function changetitle() {
            $('#breadcrumb a:eq(1)').text($('#province option:selected').text());
            $('#breadcrumb a:eq(2)').text($('#city option:selected').text());
            $('#breadcrumb a:eq(3)').text($('#community option:selected').text());
        }

        //创建能耗录入模板
        function createtmpl(pid) {
            //清空内容
            var time = document.getElementById('sym').value;
            if (time != "" && time != undefined && time != null) {
                $('#right_content').empty();
                $.getJSON("../Handler/EnergyHandler.ashx?action=getenrgytmpl&pID=" + pid + "&r=" + Math.random(), {}, function (res) {
                    if (res.IsSucceed) {
                        var dw = "";
                        switch (parseInt(pid)) {
                            case 1: dw = "度";
                                break;
                            case 2: dw = "吨";
                                break;
                            case 3: dw = "立方";
                                break;
                            default: dw = "未知类型";
                                break;
                        }
                        //liuli:修改页面显示问题
                        $.each(res.Data, function () {
                            var a = res.Data;
                            $("<div class='form-group '><div class='input-group'><div class='input-group-addon'>" + this.typeName + "</div><input class='form-control' name='t" + this.tID + "' type='Number' placeholder='能耗值' value=" + this.tID + "><div class='input-group-addon'>" + dw + "</div></div></div>").appendTo('#right_content');
                        });
                    }
                });
            }
            else {
                alert("请选择时间");
            }
        }
    </script>
</asp:Content>
 