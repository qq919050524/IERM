<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="MaintenanceManage.aspx.cs" Inherits="IERM.Views.MaintenanceManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>维保管理</title>
    <link href="../css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2.min.css" rel="stylesheet" />
    <link href="../css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
    <link href="../css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../css/mybreadcrumb/breadcrumb.css" rel="stylesheet" />
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
                                <option value="0">未选择</option>
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
                            </select>
                        </div>

                        <div class="input-group" >
                            <span class="input-group-addon">所属系统：</span>
                            <select id="sysType" class="form-control" style="width: 150px; margin-right: 20px;">
                                <option value="0">未选择</option>
                                <%foreach (var item in systemList)
                                    { %>
                                <option value="<%=item.tID %>"><%=item.typeName %></option>
                                <%} %>
                            </select>
                        </div>

                        <button id="serach" type="button" class="btn btn-info input-group" style="margin-right: 68px;"><span class="glyphicon glyphicon-search"></span>筛选</button>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <div class="panel-body" style="min-height: 280px;">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <ul style="margin-left: 20px;" id="breadcrumb">
                            <li><a href="javascript:void(0)">维保计划</a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                            <li><a href="javascript:void(0)"></a></li>
                        </ul>
                    </div>
                    <div class="panel-body">
                        <div id="alertMsg" style="display: none;" class="alert alert-success alert-dismissible" role="alert">
                            <strong>操作提示</strong> <small></small>
                        </div>
                        <div id="toolbar" class="btn-group">
                            <button id="btn_add" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success">
                                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                            </button>
                        </div>

                        <table id="tb_setting"></table>
                    </div>
                </div>

                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-lg modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">维保(巡检)计划管理</h4>
                            </div>
                            <div class="modal-body">
                                <form id="settingform" class="form-horizontal" role="form">
                                    <input type="hidden" id="settingid" name="settingid" />
                                    <table id="t1" class="table table-hover table-bordered table-striped">
                                        <tr>
                                            <td colspan="2">
                                                <div class="form-group">
                                                    <label for="equID" class="col-sm-4 control-label">选择设备：</label>
                                                    <div class="col-sm-4">
                                                        <select  id="equID" name="equID" class="form-control">
                                                        </select>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group ">
                                                    <label for="equCode" class="col-sm-4 control-label">设备编码：</label>
                                                    <div class="col-sm-8">
                                                        <input type="text" readonly class="form-control" id="equCode" placeholder="设备编码">
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-group ">
                                                    <label for="equNum" class="col-sm-4 control-label">设备型号：</label>
                                                    <div class="col-sm-8">
                                                        <input type="text" readonly class="form-control" id="equNum" placeholder="设备型号">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="form-group ">
                                                    <label for="lastDate" class="col-sm-4 control-label">上次执行日期：</label>
                                                    <div class="col-sm-8">
                                                        <input type="text" readonly class="form-control" id="lastDate" placeholder="上次执行日期">
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="form-group ">
                                                    <label for="nextDate" class="col-sm-4 control-label">下次执行日期：</label>
                                                    <div class="col-sm-8">
                                                        <input type="text" readonly class="form-control" id="nextDate" placeholder="下次执行日期">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="panel panel-success">
                                                    <div class="panel-heading">
                                                        <div class="form-inline">
                                                            <div class="text-left">
                                                                <h3>设置计划</h3>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="panel-body" style="min-height: 180px;">
                                                        <div class="form-group">
                                                            <label for="mType" class="col-sm-2 control-label">计划类型</label>
                                                            <div class="col-sm-10">
                                                                <select class="form-control" id="mType" name="mType">
                                                                    <option value="1">维保</option>
                                                                    <option value="2">巡检</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="mType" class="col-sm-2 control-label">运行状态</label>
                                                            <div class="col-sm-10">
                                                                <select class="form-control" id="status" name="status">
                                                                    <option value="0">已停止</option>
                                                                    <option value="1">运行中</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="cycLength" class="col-sm-2 control-label">周期</label>
                                                            <div class="col-sm-10">
                                                                <div class="form-inline">
                                                                    <div class="form-group" style="margin-left: 0px;">
                                                                        <input type="text" class="form-control" id="cycLength" name="cycLength" placeholder="周期长">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <select class="form-control" id="cycUnit" name="cycUnit">
                                                                            <option value="1">日</option>
                                                                            <option value="2">周</option>
                                                                            <option value="3">月</option>
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="mType" class="col-sm-2 control-label">重复</label>
                                                            <div class="col-sm-10">
                                                                <select class="form-control" id="isCyclic" name="isCyclic">
                                                                    <option value="0">仅执行一次</option>
                                                                    <option value="1">周期循环执行</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="panel panel-default">
                                                            <div class="panel-heading">
                                                                <div class="form-inline">
                                                                    <div class="text-left">
                                                                        <div class="form-group">
                                                                            <label for="systypeID" style="margin: 10px;">所属系统</label>
                                                                            <select disabled class="form-control" id="systypeID" name="systypeID">
                                                                                <%foreach (var item in systemList)
                                                                                    { %>
                                                                                <option value="<%=item.tID %>"><%=item.typeName %></option>
                                                                                <%} %>
                                                                            </select>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div id="settingcontent" class="panel-body" style="min-height: 180px;"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button id="rrsubmit" type="button" class="btn btn-success">提交</button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal">取消</button>
                            </div>
                        </div>
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

    <script type="text/javascript">
        var settingdata = null;
        var equdata = null;
        $(function () {
            initSelectTree($('#property').val());

            $("#test").change(function () {
                initDevHouse();
            });
            //物业公司改变
            $("#property").change(function () {
                initSelectTree($('#property').val());
            });

            $("#serach").click(function () {
                initTable();
            });

            $('#btn_add').click(function () {
                $("#settingid").val(0);
                $("#equID").removeAttr("disabled");
                $("#equID option:eq(0)").attr("selected", "selected");
                $("#t1 tr:eq(2)").hide();
                $('#settingform')[0].reset();
                LoadEquInfo($("#equID").val());
            });

            ///切换设备
            $("#equID").change(function () {
                //alert("in");
                LoadEquInfo($("#equID").val());
                initSettingType($('#systypeID').val());
            });

            //点击保存按钮
            $('#rrsubmit').click(function () {
                $('#myModal').modal('hide');
                var mcontent = [];
                if($('#settingid').val()==0)
                {
                    //新增
                    $("#settingcontent input:checked").each(function () {
                        mcontent.push($(this).val());
                    });

                    $.post("../Handler/MaintenanceHandler.ashx?action=Add&r=" + Math.random(),
                        {
                            "mSetting": $('#settingform').serialize(),
                            "mContent": mcontent.join(',')
                        },
                        function (res) {
                            $('#alertMsg small').html(res.Msg);
                            if (res.IsSucceed) {
                                $('#alertMsg').show();
                                initTable();
                            }                           
                            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                        }
                    ,"json");
                }
                else
                {                   
                    //更新
                    $("#settingcontent input:checked").each(function () {
                        mcontent.push($(this).val());
                    });
                    $("#equID").removeAttr("disabled");
                    $.post("../Handler/MaintenanceHandler.ashx?action=update&r=" + Math.random(),
                        {
                            "mSetting": $('#settingform').serialize(),
                            "mContent": mcontent.join(',')
                        },
                        function (res) {
                            $("#equID").attr("disabled", "disabled");
                            if (res.IsSucceed) {
                                $('#alertMsg small').html('更新维保计划成功！');
                                $('#alertMsg').show();
                                initTable();
                            }
                            else {
                                $('#alertMsg small').html('更新维保计划失败！');
                            }
                            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                        }
                    ,"json");
            
                }
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
                $("#devhouse").empty();
                if (res.total > 0) {
                    $.each(res.rows, function (key, value) {
                        if (key == 0) {
                            $("#devhouse").append("<option selected value='" + this.devID + "'>" + this.devName + "</option>");
                        }
                        else {
                            $("#devhouse").append("<option value='" + this.devID + "'>" + this.devName + "</option>");
                        }
                    });
                } else { $("#devhouse").append("<option value='0'>未设置</option>"); }

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

        //初始化维保计划表
        function initTable() {
            //先销毁表格  
            $('#tb_setting').bootstrapTable('destroy');
            //初始化表格,动态从服务器加载数据  
            $("#tb_setting").bootstrapTable({
                method: "get",  //使用get请求到服务器获取数据  
                url: "../Handler/MaintenanceHandler.ashx?action=getmaintenancesetting&r=" + Math.random(), //获取数据的Servlet地址  
                striped: true,  //表格显示条纹  
                height: $(window).height() - 175,
                toolbar: '#toolbar',                //工具按钮用哪个容器
                pagination: true, //启动分页  
                clickToSelect: true,    //是否启用点击选中行
                uniqueId: "sID",      //每一行的唯一标识，一般为主键列
                pageSize: 10,  //每页显示的记录数  
                pageNumber: 1, //当前第几页  
                pageList: [10, 20, 30],  //记录数可选列表  
                search:false,  //是否启用查询  
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
                        devhouseID: $('#devhouse').val(),
                        systypeID: $('#sysType').val()
                    };
                    return param;
                },
                rowStyle: function (row, index) {
                    var strclass = "";
                    if (row.status == 0) {
                        strclass = 'warning';
                    }
                    return { classes: strclass }
                },
                onLoadSuccess: function (data) {  //加载成功时执行  
                    settingdata = data;
                },
                columns: [{
                    field: 'sID',
                    title: '序号',
                    align: 'center',
                    visible: false
                },
                {
                    field: 'equName',
                    title: '设备名称',
                    align: 'center'
                },
                {
                    field: 'equCode',
                    title: '设备编码',
                    align: 'center'
                },
                //{
                //    field: 'equNum',
                //    title: '设备型号',
                //    align: 'center'
                //},
                 {
                     field: 'systypeName',
                     title: '所属系统',
                     align: 'center'
                 },
                {
                    field: 'cycLength',
                    title: '周期',
                    align: 'center',
                    formatter: function (value, row, index) {
                        var dw = "";
                        if (row.cycUnit == 1) {
                            dw = "日";
                        } else if (row.cycUnit == 2) {
                            dw = "周";
                        } else { dw = "月"; }
                        return value + dw;
                    }
                },
                {
                    field: 'isCyclic',
                    title: '重复',
                    align: 'center',
                    formatter: function (value, row, index) {
                        var dw = "";
                        if (value) {
                            return "周期";
                        } else { return "仅一次"; }
                    }
                },
                {
                    field: 'mType',
                    title: '计划类型',
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (value == 1) {
                            return "维保";
                        } else {
                            return "巡检";
                        }
                    }
                },
                {
                    field: 'status',
                    title: '状态',
                    align: 'center',
                    formatter: function (value, row, index) {
                        if (value) {
                            return "运行中";
                        } else {
                            return "<font color='red'>已停止</font>";
                        }
                    }
                },
                //{
                //    field: 'mPhoneNum',
                //    title: '维保电话',
                //    align: 'center'
                //},
                 {
                     field: 'flagTime',
                     title: '上次维保日期',
                     align: 'center',
                     formatter: function (value, row, index) {
                         return value.lastDate;
                     }
                 },
                  {
                      field: 'flagTime',
                      title: '下次维保日期',
                      align: 'center',
                      formatter: function (value, row, index) {
                          return value.nextDate;
                      }
                  },
                {
                    title: '操作',
                    formatter: function (value, row, index) {
                        var e = '<a data-toggle="modal" href="javascript:void(0);"  data-target="#myModal" style="margin-right:18px;" onclick="edit(\'' + row.sID + '\')"><span class="glyphicon glyphicon-edit"></span> 编辑</a> ';
                        var d = '<a href="javascript:void(0)" onclick="del(\'' + row.sID + '\')"><span class="glyphicon glyphicon-trash"></span> 删除</a> ';
                        return e + d;
                    }
                }]
            });
        }

        //编辑维保计划
        function edit(sid) {
            $("#settingid").val(sid);
            $("#equID").attr("disabled", "disabled");
            $("#t1 tr:eq(2)").show();
            LoadEditEquInfo(sid);

        }

        //删除维保计划
        function del(sid) {
            $.post("../Handler/MaintenanceHandler.ashx?action=delete&r=" + Math.random(), { "settingID": sid }, function (res) {
                if (res.IsSucceed) {
                    $('#alertMsg small').html(res.Msg);
                    $('#alertMsg').show();
                    initTable();
                }
                else {
                    $('#alertMsg small').html(res.Msg);
                }
                setTimeout(function () { $('#alertMsg').hide(); }, 3000);
            }, "json");
        }

        function str2Json(str) {
            str = str.replace(/&/g, "','");
            str = str.replace(/=/g, "':'");
            str = "({'" + str + "'})";
            obj = eval(str);
            return obj;
        }

        //初始化维保内容
        function initSettingType(tid) {
            $.getJSON("../Handler/MaintenanceHandler.ashx?action=getmaintenancetype&r=" + Math.random(), { "systypeID": tid }, function (res) {
                if (res.IsSucceed) {
                    $('#settingcontent').empty();
                    $.each(res.Data, function () {
                        $('#settingcontent').append("<div class='col-md-6 col-sm-12 col-lg-3 checkbox'><label for='chk" + this.mID + "'><input id='chk" + this.mID + "' type='checkbox' value='" + this.mID + "'>" + this.mtypeName + "</label></div>");
                    });
                }
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

        //载入制定设备信息
        function LoadEquInfo(eid) {
            $.each(equdata, function () {
                if (this.eID == eid) {
                    $('#equCode').val(this.equCode);
                    $('#equNum').val(this.equNum);
                    $('#systypeID').val(this.sysTypeID);
                    initSettingType(this.sysTypeID);
                    return false;
                }
            });
        }

        ///载入编辑计划信息
        function LoadEditEquInfo(sid) {
            var t = null;
            $.each(settingdata.rows, function () {
                if (this.sID == sid) {
                    $("#equID").val(this.equID);
                    $('#equCode').val(this.equCode);
                    $('#equNum').val(this.equNum);
                    $('#systypeID').val(this.systypeID);
                    $('#lastDate').val(this.flagTime.lastDate);
                    $('#nextDate').val(this.flagTime.nextDate);
                    $('#mType').val(this.mType);
                    $('#status').val(Number(this.status));
                    $('#cycLength').val(this.cycLength);
                    $('#cycUnit').val(this.cycUnit);
                    $('#isCyclic').val(Number(this.isCyclic));
                    t = this.mtypeList;
                    return false;
                }
            });

            $.getJSON("../Handler/MaintenanceHandler.ashx?action=getmaintenancetype&r=" + Math.random(), { "systypeID": $('#systypeID').val() }, function (res) {
                if (res.IsSucceed) {
                    $('#settingcontent').empty();
                    $.each(res.Data, function () {
                        $('#settingcontent').append("<div class='col-md-6 col-sm-12 col-lg-3 checkbox'><label for='chk" + this.mID + "'><input id='chk" + this.mID + "' type='checkbox' value='" + this.mID + "'>" + this.mtypeName + "</label></div>");
                    });

                    $.each(t, function () {
                        $("#settingcontent input[value='" + this.mID + "']").prop("checked", true);
                    });
                }
            });

        }
    </script>
</asp:Content>
