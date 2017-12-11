<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="AlarmSetting.aspx.cs" Inherits="IERM.Views.AlarmSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <title>报警设置</title>
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
                                <li><a href="javascript:void(0)">报警设置</a></li>
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
                                <button id="btn_add" type="button" data-toggle="modal" data-target="#myModal" class="btn btn-success">
                                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
                                </button>
                            </div>
                            <table id="tb_dev"></table>
                        </div>
                    </div>
                </div>


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
                                                        <li><a href="#tab1" data-toggle="tab">设备房信息</a></li>
                                                        <li><a href="#tab2" data-toggle="tab">报警设置</a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        <form id="devform" class="form-horizontal" role="form">
                                            <input type="hidden" id="hd_devid" />
                                            <input type="hidden" id="hd_community" value="<%=defaultCommunity.communityID %>" />
                                            <div class="tab-content">
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
                                                        <label for="devID" class="col-sm-2 control-label">设备房编号</label>
                                                        <div class="col-sm-10">
                                                            <input type="text" class="form-control" id="devID" name="devID" placeholder="设备房编号">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="devName" class="col-sm-2 control-label">设备房名称</label>
                                                        <div class="col-sm-10">
                                                            <input type="text" class="form-control" id="devName" name="devName" placeholder="设备名称">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="devType" class="col-sm-2 control-label">设备房类型</label>
                                                        <div class="col-sm-10">
                                                            <select style="min-width: 200px; font-size: larger;" id="devType" name="devType">
                                                                <%foreach (var item in devtypelist)
                                                                    { %>
                                                                <option value="<%=item.dtID %>"><%=item.devTypeName %></option>
                                                                <%} %>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="devType" class="col-sm-2 control-label">包含系统类型</label>
                                                        <div class="col-sm-10">
                                                            <table class="table table-bordered">
                                                                <tr>
                                                                    <td>
                                                                        <%foreach (var item in systypelist)
                                                                            { %>
                                                                        <div class='col-md-2 col-sm-3 checkbox'>
                                                                            <label for='chk<%=item.tID %> '>
                                                                                <input name='systype' type='checkbox' id='chk<%=item.tID %> ' value='<%=item.tID %>'><%=item.typeName %></label>
                                                                        </div>
                                                                        <%} %>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="tab-pane" id="tab2">
                                                    <table class="table table-bordered table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>报警编码</th>
                                                                <th>报警名称</th>
                                                                <th>上限值</th>
                                                                <th>下限值</th>
                                                                <th>启用</th>
                                                                <th>延时（秒）</th>
                                                                <th>发送短信</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
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
            </div>

        </div>
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

    <script type="text/javascript">
     
        $(function () {
            initTreeView();

            $('#rootwizard').bootstrapWizard({
                onTabShow: function (tab, navigation, index) {

                },
                onNext: function (tab, navigation, index) {
                    if(index==1)
                    {
                        if(!$("#devform").data('bootstrapValidator').isValid()) {                         
                            $("#devform").bootstrapValidator('validate');
                            return false;
                        }  
                        else
                        {
                            $("#devform").data("bootstrapValidator").updateStatus("devID","NOT_VALIDATED",null ); 
                            $("#devform").data("bootstrapValidator").updateStatus("devName","NOT_VALIDATED",null ); 

                            var paramsetting={"action":"getalarmsetting"};
                            //动态生产报警设置表
                            if($('#hd_devid').val()==0)
                            {
                                paramsetting.devType=$('#devType').val();
                            }
                            else
                            {
                                paramsetting.devID=$('#hd_devid').val();
                            }
                            $('#tab2 tbody').empty();
                            $.getJSON("../Handler/AlarmHandler.ashx?r="+Math.random(),paramsetting,function(res){
                                if(res.IsSucceed){
                                    $('#tab2 tbody').append($("#alarmSettingTemplate").tmpl(res.Data));
                                    $("[name='my-checkbox']").bootstrapSwitch({onText:"开",offText:"关",size:"small"});
                                }
                            });
                            
                        }
                    }                  
                }
            });
            $('#rootwizard .finish').click(function () {
                $('#myModal').modal('hide');
                var chks=[];
                $("input[name='systype']:checked").each(function(){
                    chks.push(($(this).val()));
                });
                //保存设置
                if ($('#hd_devid').val() == "0") {
                    //新增操作
                    $.post("../Handler/AlarmHandler.ashx", 
                        {
                            "settingData":JSON.stringify(TableToJson("#tab2 table")),
                            "action":"savealarmsetting",
                            "isUpdate":false,
                            "devID":$('#devID').val(),
                            "devName":$('#devName').val(), 
                            "devType":$('#devType').val(),
                            "communityID":$('#hd_community').val(),
                            "systype":chks.join(',')
                        }, 
                        function (res) {
                            if (res.IsSucceed) {
                                $('#alertMsg small').html('添加成功！');
                                $('#alertMsg').show();
                                initTable($('#hd_community').val());
                            }
                            else {
                                $('#alertMsg small').html('添加失败！');
                            }
                            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                        }, "json");
                }
                else {
                    //更新操作
                    $.post("../Handler/AlarmHandler.ashx", 
                        {
                            "settingData":JSON.stringify(TableToJson("#tab2 table")),
                            "action":"savealarmsetting",
                            "isUpdate":true,
                            "devID":$('#devID').val(),
                            "devName":$('#devName').val(), 
                            "devType":$('#devType').val(),
                            "communityID":$('#hd_community').val(),
                            "systype":chks.join(',')
                        }, 
                        function (res) {
                            if (res.IsSucceed) {
                                $('#alertMsg small').html('修改成功！');
                                $('#alertMsg').show();
                                initTable($('#hd_community').val());
                            }
                            else {
                                $('#alertMsg small').html('修改失败！');
                            }
                            setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                        }, "json");
                }
            });

            formValidator();

            $('#btn_add').click(function(){              
                $('#rootwizard').bootstrapWizard('show', 0);
                $('#devID').val("");
                $('#devID').removeAttr("readonly");
                $('#devName').val("");     
                $('#devType').get(0).selectedIndex=0;
                $("input[name='systype']").each(function(index,item){
                    if(index==0){
                        $(this).prop("checked", true);
                    }else
                    {
                        $(this).prop("checked", false);
                    }

                });
                $('#hd_devid').val(0);
            });

            $('#myModal').on('hidden.bs.modal', function() {
                $("#devform").data('bootstrapValidator').destroy();
                $('#devform').data('bootstrapValidator', null);
                formValidator();
            });

            //切换设备房类型，选择默认系统
            $('#devType').change(function(){
                var selindex=$('#devType').get(0).selectedIndex;
                if(selindex==0){
                    $("input[name='systype']").each(function(index,item){
                        if(index==0){
                            $(this).prop("checked", true);
                        }else
                        {
                            $(this).prop("checked", false);
                        }

                    });
                }else if(selindex==1){
                    $("input[name='systype']").each(function(index,item){
                        if(index==2){
                            $(this).prop("checked", true);
                        }else
                        {
                            $(this).prop("checked", false);
                        }

                    });
                }else{
                    $("input[name='systype']").each(function(index,item){
                        $(this).prop("checked", false);
                    });
                }

            });
        });

        function formValidator(){
            $('#devform').bootstrapValidator({
                message: '验证未通过!',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    devID: {
                        message: '设备编号输入无效',
                        validators: {
                            notEmpty: {
                                message: '设备编号不能为空'
                            },
                            stringLength: {
                                min: 1,
                                max: 4,
                                message: '设备编号长度在1~4之间'
                            }
                        }
                    },
                    devName: {
                        message:'设备名输入无效',
                        validators: {
                            notEmpty: {
                                message: '设备名不能为空'
                            },
                            stringLength: {
                                min: 2,
                                max: 30,
                                message: '设备名长度必须在2到30之间'
                            }
                        }
                    }
                }
            });
        }

        //初始化treeview
        function initTreeView() {
            $.getJSON("../Handler/CityAndCommunity.ashx?action=getpcc&r=" + Math.random(), 
                {
                    "pid":<%=defaultCommunity.provinceid%>,
                    "cid":<%=defaultCommunity.pCityID%>,
                    "cmid":<%=defaultCommunity.communityID%>,
                }, function (res) {
                    if (res.IsSucceed) {
                        $('#devtree').treeview({
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
                        initTable(<%=defaultCommunity.communityID%>);
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
                    url: "../Handler/CityAndCommunity.ashx?action=getdevbycid&r=" + Math.random(), //获取数据的Servlet地址  
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
                            communityID: communityid,
                            timeliness:true
                        };
                        return param;
                    },
                    rowStyle: function (row, index) {
                        var strclass = "";
                        switch (row.devTypeName) {
                            case "变配电":
                                //strclass = 'warning';
                                strclass = 'text-warning';
                                break;
                            case "给排水":
                                strclass = 'text-success';
                                //strclass = 'success';
                                break;
                            default:
                                strclass = 'text-danger';
                                //strclass = 'danger';
                                break;
                        }
                        return { classes: strclass }
                    },
                    onLoadSuccess: function () {  //加载成功时执行  

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
                        field: 'devName',
                        title: '设备房名称',
                        align: 'center'
                    },
                    {
                        field: 'devTypeName',
                        title: '设备房类型',
                        align: 'center'
                    },
                    {
                        field: 'devID',
                        title: '设备房编号',
                        align: 'center'
                    },
                    {
                        title: '操作',
                        formatter: function (value, row, index) {
                            var e = '<a data-toggle="modal" href="javascript:void(0);"  data-target="#myModal" style="margin-right:18px;" onclick="edit(this)"><span class="glyphicon glyphicon-edit"></span> 编辑</a> ';
                            var d = '<a href="javascript:void(0)" onclick="del(\'' + row.devID + '\')"><span class="glyphicon glyphicon-trash"></span> 删除</a> ';
                            return e + d;
                        }
                    }]
                });
            }

            //编辑
            function edit(obj) {
                $('#rootwizard').bootstrapWizard('show', 0);             
                $('#devID').attr("readonly","readonly");
                var thisrow=$(obj).parent().parent();
                $('#devID').val(thisrow.find("td:eq(3)").text());              
                $('#devName').val(thisrow.find("td:eq(1)").text()); 
                var dt=thisrow.find('td:eq(2)').text();

                $('#devType option').each(function(){
                    if($(this).text()==dt){
                        $(this).attr("selected",true);
                    }else
                    {
                        $(this).prop("selected", false);
                    }
                });

                $.getJSON("../Handler/CityAndCommunity.ashx?action=getdevhousesystype&r=" + Math.random(), 
                {
                    "devhouseID":$('#devID').val()
                }, function (res) {
                    if (res.IsSucceed) {
                        $("input[name='systype']").each(function(){
                            $(this).prop("checked", false);
                        });
                        $.each(res.Data,function(index,item){
                            $("input[name='systype']").each(function(){
                                if($(this).val()==item.systypeID){
                                    $(this).prop("checked", true);
                                }
                            });
                        });
                        
                    }
                });
                $('#hd_devid').val($('#devID').val());
            }

            //删除
            function del(devid) {
                if(confirm("确认删除设备房吗？")){
                    $.post("../Handler/AlarmHandler.ashx", 
                           {
                               "devID":devid,
                               "action":"delete"
                           }, 
                           function (res) {
                               if (res.IsSucceed) {
                                   $('#alertMsg small').html(res.Msg);
                                   $('#alertMsg').show();
                                   initTable($('#hd_community').val());
                               }
                               else {
                                   $('#alertMsg small').html(res.Msg);
                               }
                               setTimeout(function () { $('#alertMsg').hide(); }, 3000);
                           }, "json");
                }
            }

            //数据表转换成json数据
            function TableToJson(selector)
            {
                var data=[];
                $(selector).find('tr:gt(0)').each(function(){
                    var item={};
                    item.devID=$('#devID').val();
                    item.isDigital=$(this).attr("data-isdigital");
                    item.alarmCode=$(this).find("td:eq(0)").text();
                    item.maxValue=$(this).find("td:eq(2) input").val();
                    item.minValue=$(this).find("td:eq(3) input").val();
                    item.isWork=$(this).find("td:eq(4) input").bootstrapSwitch('state');
                    item.delayed=$(this).find("td:eq(5) select").val();
                    item.isSend=$(this).find("td:eq(6) input").bootstrapSwitch('state');
                    data.push(item);
                });
                return data;
            }
    </script>

    <script id="alarmSettingTemplate" type="text/x-jquery-tmpl">
        <tr data-isdigital="${$data.isDigital}" {{if $data.isDigital==1}} class="text-success" {{else}}class="text-warning" {{/if}}>
            <td>${$data.alarmCode}</td>
            <td>${$data.alarmName}</td>
            <td>{{if $data.isDigital==0}} <input type='number' class='form-control' value="${$data.maxValue}" /> {{/if}}</td>
            <td>{{if $data.isDigital==0}} <input type='number' class='form-control' value="${$data.minValue}" /> {{/if}}</td>
            <td><input type="checkbox" name="my-checkbox" {{if $data.isWork==1}} checked="checked" {{/if}} />
            </td>
            <td><select class='form-control' style='width:70px;'>
                <option {{if $data.delayed==30}} selected='selected'{{/if}}  value='30'>30</option>
                <option {{if $data.delayed==60}} selected='selected'{{/if}}  value='60'>60</option>
                <option {{if $data.delayed==90}} selected='selected'{{/if}}  value='90'>90</option>
                </select></td>
            <td>
                <input type='checkbox' name='my-checkbox' {{if $data.isSend==1}} checked="checked"  {{/if}} />

            </td>
        </tr>           
    </script>
</asp:Content>
