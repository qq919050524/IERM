<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site1.Master" AutoEventWireup="true" CodeBehind="Elevator.aspx.cs" Inherits="IERM.Views.Elevator.Elevator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
    <link href="/css/Elevator/Elevator.css" rel="stylesheet" />
    <link href="/css/table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="/css/layer/layer.css" rel="stylesheet" />
    <style>
        .elevatorOne {
            width: 33.3%
        }

        #dropdownmenu {
            padding: 5px;
            border: 0px;
        }

        .fixed-table-container {
            height: 300px;
        }

            .fixed-table-container tbody .selected td {
                background-color: #d0e9c6;
            }

        .table-hover tbody tr:hover td,
        .table-hover tbody tr:hover th {
            background-color: #d0e9c6;
        }

        .detailIco {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div class="detailSearch">
        <input type="hidden" id="hidCommunityID" />
        <input type="hidden" id="hidRegistrationCode" />
        <input type="hidden" id="hidSearchBtnClick" value="0" />
        <div class="form-inline heightAll">
            <div class="text-left heightAll vertical">
                <div class="input-group" style="margin-right: 20px; margin-left: 20px;">
                    <span class="input-group-addon">物业公司：</span>
                    <select id="property" class="form-control" style="width: 120px; margin-right: 10px;" runat="server">
                    </select>
                </div>
                <div class="col-md-4">
                    <div class="input-group col-md-12">
                        <input class="form-control" id="parentname" name="parentname" placeholder="请选择电梯" readonly="readonly" type="text" value="" autocomplete="off">
                        <div id="dropdownmenuDiv" class="input-group-btn" style="width: 1%">
                            <button type="button" class="btn  btn-blue dropdown-toggle" data-toggle="dropdown">
                                <span class="glyphicon glyphicon-th"></span>
                            </button>
                            <ul id="dropdownmenu" class="dropdown-menu dropdown-menu-right" role="menu">
                                <li>
                                    <table id="table"></table>
                                </li>
                            </ul>
                        </div>
                        <!-- /btn-group -->
                    </div>
                </div>
                <button id="searchBtn" type="button" class="btn btn-info input-group"><span class="glyphicon glyphicon-search"></span>筛选</button>
                <span id="videoBtn" class="sxt">
                    <img src="/img/bar/sxt.png" class="sxtImg">
                </span>
            </div>
        </div>
    </div>

    <div class="introImg vertical">
        <div class="eleLeft">
            <img src="/img/elevator/elevator.png" class="elevatorImg">
            <span id="elevatorInfoNum" class="elevatorNum">-</span>
        </div>
        <div class="eleRight">
            <div id="alertError" style="z-index: 999; display: none; position: absolute; width: 60%; left: 15%" class="alert alert-info alert-dismissible" role="alert">
                <strong>操作提示：</strong><small></small>
            </div>
            <div class="elevatorRTop">
                <p class="elevatorTitle">报警状态</p>
                <div class="eleIco">
                    <div class="detailIco" id="forHelp">
                        <p class="icoOuter">
                            <img src="/img/elevator/alarm.png" class="Ico"><img src="/img/elevator/alarmRed.png" class="Ico2">
                        </p>
                        <a class="icoTitle">手动报警</a>
                    </div>
                    <div class="detailIco" id="trapped">
                        <p class="icoOuter">
                            <img src="/img/elevator/kr.png" class="Ico"><img src="/img/elevator/krRed.png" class="Ico2">
                        </p>
                        <a class="icoTitle">困人</a>
                    </div>
                    <div style="clear: both; width: 100%; text-align: left; vertical-align: central; margin: 10px 0px -15px 0.8rem; padding-top: 10px;">
                        <div id="alertMsg" style="display: " class="alert alert-info alert-dismissible" role="alert">
                            <strong>报警信息：</strong>
                            <span id="elevatorInfoErrorMsg" style="color: red;">-</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="elevatorRDown">
                <p class="elevatorTitle">电梯基本信息</p>
                <div class="elevatorInf">
                    <ul class="elevatorOne">
                        <li class="elevatorTwoLi">电梯厂商名称：<span id="elevatorInfoCSname">-</span></li>
                        <li class="elevatorTwoLi">电梯品牌：<span id="elevatorInfoBrand">-</span></li>
                        <li class="elevatorTwoLi">电梯注册码：<span id="elevatorInfoRegistercode">-</span></li>
                        <li class="elevatorTwoLi">电梯型号：<span id="elevatorInfoLiftmodel">-</span></li>
                        <li class="elevatorTwoLi">电梯出厂日期：<span id="elevatorInfoOutfacdate">-</span></li>
                        <li class="elevatorTwoLi">投入使用日期：<span id="elevatorInfoBeginusedate">-</span></li>
                        <li class="elevatorThreeLi">最近年检时间：<span id="elevatorInfoYcdate">-</span></li>
                        <li class="elevatorTwoLi">电梯注册机构：<span id="elevatorInfoRegisterorg">-</span></li>
                    </ul>
                    <ul class="elevatorOne">
                        <li class="elevatorOneLi">城市：<span id="elevatorInfoCity">-</span><span id="elevatorInfoDistrict">-</span></li>
                        <li class="elevatorOneLi">小区：<span id="elevatorInfoYZname">-</span></li>
                        <li class="elevatorThreeLi">电梯所在位置：<span id="elevatorInfoAddress">-</span></li>
                        <li class="elevatorThreeLi">电梯编号：<span id="elevatorInfoInternalnum">-</span></li>
                        <li class="elevatorThreeLi">电梯当前运行状态：<span id="elevatorInfoLiftstatus">-</span></li>
                        <li class="elevatorThreeLi">电梯类型：<span id="elevatorInfoLifttypename">-</span></li>
                        <li class="elevatorThreeLi">电梯使用类型：<span id="elevatorInfoUsingtypename">-</span></li>
                        <li class="elevatorThreeLi">提升高度(停靠层站)：<span id="elevatorInfoTsgd">-</span></li>
                    </ul>
                    <ul class="elevatorOne">
                        <li class="elevatorOneLi">物业：<span id="elevatorInfoWYname">-</span></li>
                        <li class="elevatorOneLi">物业联系人：<span id="elevatorInfoWYlinkman">-</span></li>
                        <li class="elevatorOneLi">物业联系电话：<span id="elevatorInfoWYlinktel">-</span></li>
                        <li class="elevatorOneLi">维保单位：<span id="elevatorInfoWBname">-</span></li>
                        <li class="elevatorOneLi">维保联系人：<span id="elevatorInfoWBlinkman">-</span></li>
                        <li class="elevatorOneLi">维保联系电话：<span id="elevatorInfoWBlinktel">-</span></li>
                        <li class="elevatorThreeLi">区段长度：<span id="elevatorInfoSyqdcd">-</span></li>
                        <li class="elevatorThreeLi">备注：<span id="elevatorInfoRemark">-</span></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="wordWarp">
        <div class="wordIntro">
            <ul class="elevatorUl">
                <li class="elevatorLi">
                    <a class="elevatorA">当前楼层：<span id="elevatorInfoFloor" class="floor">-</span></a>
                </li>
                <li class="elevatorLi">
                    <a class="elevatorA">运行方向：<span id="elevatorInfoDerection" class="derection">-</span></a>
                </li>
                <li class="elevatorLi">
                    <a class="elevatorA">电梯运行速度：<span id="elevatorInfoRunningSpeed" class="runningSpeed">-</span></a>
                </li>
                <li class="elevatorLi">
                    <a class="elevatorA">轿厢门状态：<span id="elevatorInfoCarDoor" class="carDoor">-</span></a>
                </li>
                <li class="elevatorLi">
                    <a class="elevatorA">载客状况：<span id="elevatorInfoCarry" class="carry">-</span></a>
                </li>
            </ul>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_script" runat="server">
    <script type="text/javascript" src="/js/table/bootstrap-table.min.js"></script>
    <script type="text/javascript" src="/js/table/bootstrap-table-zh-CN.min.js"></script>
    <script src="/js/layer/layer.js"></script>
    <%--页面初始化--%>
    <script>
        $(function () {
            $(".introImg").removeClass("vertical");
            $(".introImg").css("height", "82%");
            $(".wordWarp").css("height", "11.4%");
        })
    </script>
    <%--table初始化--%>
    <script>
        $(function () {
            init();
            var width = $("#parentname").width();
            $("#dropdownmenu").width(width * 1.5);
            $(".search").find("input").width(width * 1.5 - 15);
            $(".dropdown-menu").click(function (e) {
                e.stopPropagation();
            });
            $("#cph_body_property").change(function () {
                $("#table").bootstrapTable("refresh");
            });
        })
        function init() {
            $('#table').bootstrapTable({
                url: '/Handler/ElevatorHandler.ashx?action=GetListCommunityElevator&r=' + Math.random(),
                height: 0,
                //toolbar: '#toolbar',                //工具按钮用哪个容器
                pagination: true, //启动分页  
                pageSize: 10,  //每页显示的记录数  
                pageNumber: 1, //当前第几页  
                pageList: [10, 20, 30],  //记录数可选列表  
                sidePagination: "server", //表示服务端请求  
                minimumCountColumns: 2, //最少允许的列数
                selectItemName: 'checkbox',//复选框
                maintainSelected: true,//记住checkbox
                checkboxHeader: true,
                clickToSelect: true,
                singleSelect: true,//禁止多选
                striped: true,  //表格显示条纹  
                search: true,
                showColumns: false,
                showRefresh: false,
                showToggle: false,
                queryParamsType: "undefined",
                queryParams: function queryParams(params) {   //设置查询参数  
                    var param = {
                        pageNumber: params.pageNumber,
                        pageSize: params.pageSize,
                        property: $('#cph_body_property').val(),
                        searchText: params.searchText
                    };
                    return param;
                },
                columns:
                [
                    {
                        field: 'eID',
                        title: '主键',
                        align: 'center',
                        visible: false,
                        width: 50
                    },
                    {
                        field: 'communityID',
                        title: '小区id',
                        align: 'center',
                        visible: false,
                        width: 50
                    },
                    {
                        field: 'registrationCode',
                        title: '电梯注册码',
                        align: 'center',
                        visible: false,
                        width: 50
                    },
                    {
                        field: 'communityName',
                        title: '小区名',
                        align: 'center'
                    },
                    {
                        field: 'elevatorPosition',
                        title: '电梯位置',
                        align: 'center',
                    }
                ],
                onClickRow: function (row) {
                    $("#hidRegistrationCode").val(row.registrationCode);
                    $("#hidCommunityID").val(row.communityID);
                    $("#parentname").val(row.communityName + "-" + row.elevatorPosition + "-" + row.registrationCode);
                }
            });
        }
    </script>
    <%--调取数据--%>
    <script>
        var setTimeoutID;
        $(function () {
            $('#searchBtn').click(function (e) {
                e.stopPropagation();
                $("span[id^='elevatorInfo']").html("-");
                $(".Ico2").css("display", "none");
                $(".icoTitle").css({ "color": "#000", "textDecoration": "none" });

                clearTimeout(setTimeoutID);
                seach();
            });
            $('#videoBtn').click(function (e) {
                video();
            })
        })
        function seach() {
            $("#dropdownmenuDiv").removeClass("open");
            var registrationCode = $('#hidRegistrationCode').val();
            var communityID = $('#hidCommunityID').val();
            if (registrationCode) {
                var clickValue = $('#hidSearchBtnClick').val();
                if (!clickValue) clickValue = 0;
                clickValue++;
                $('#hidSearchBtnClick').val(clickValue);
                detail(communityID, registrationCode, clickValue);
            }
            else {
                alertError("请选择电梯");
            }
        }
        function video() {
            var registrationCode = $('#elevatorInfoRegistercode').html();
            if (registrationCode && registrationCode.length > 0 && registrationCode != "-") {
                $.post("/Handler/ElevatorHandler.ashx",
                    {
                        "action": "GetLiftVideo",
                        "registrationCode": registrationCode
                    },
                    function (res) {
                        if (res.IsSucceed) {
                            var msgJson = JSON.parse(res.Data);
                            layer.open({
                                type: 2,
                                title: false,
                                area: ['600px', '600px;'],
                                shade: 0.8,
                                closeBtn: 0,
                                shadeClose: true,
                                content: [msgJson.url, 'no']
                            });
                        }
                        else {
                            alertError("获取电梯视频失败，" + res.Msg);
                        }
                    }, "json");
            }
            else {
                alertError("请选择电梯");
            }
        }
        //电梯明细
        function detail(communityID, registrationCode, clickValue) {
            $.post("/Handler/ElevatorHandler.ashx",
                {
                    "action": "GetLiftDetail",
                    "registrationCode": registrationCode
                },
                function (res) {
                    if (res.IsSucceed) {
                        var msgJson = JSON.parse(res.Data);
                        setHtml("elevatorInfoCity", msgJson.city);
                        setHtml("elevatorInfoDistrict", msgJson.district);
                        setHtml("elevatorInfoYZname", msgJson.yzname);
                        setHtml("elevatorInfoWYname", msgJson.wyname);
                        setHtml("elevatorInfoWYlinkman", msgJson.wylinkman);
                        setHtml("elevatorInfoWYlinktel", msgJson.wylinktel);
                        setHtml("elevatorInfoWBname", msgJson.wbname);
                        setHtml("elevatorInfoWBlinkman", msgJson.wblinkman);
                        setHtml("elevatorInfoWBlinktel", msgJson.wblinktel);
                        setHtml("elevatorInfoCSname", msgJson.csname);
                        setHtml("elevatorInfoBrand", msgJson.brand);
                        setHtml("elevatorInfoLiftmodel", msgJson.liftmodel);
                        setHtml("elevatorInfoOutfacdate", msgJson.outfacdate);
                        setHtml("elevatorInfoRegistercode", msgJson.registercode);
                        setHtml("elevatorInfoBeginusedate", msgJson.beginusedate);
                        setHtml("elevatorInfoRegisterorg", msgJson.registerorg);
                        setHtml("elevatorInfoAddress", msgJson.address);
                        setHtml("elevatorInfoInternalnum", msgJson.internalnum);
                        setHtml("elevatorInfoLiftstatus", msgJson.liftstatus);
                        setHtml("elevatorInfoLifttypename", msgJson.lifttypename);
                        setHtml("elevatorInfoYcdate", msgJson.ycdate);
                        setHtml("elevatorInfoUsingtypename", msgJson.usingtypename);
                        setHtml("elevatorInfoTsgd", msgJson.tsgd);
                        setHtml("elevatorInfoSyqdcd", msgJson.syqdcd);
                        setHtml("elevatorInfoRemark", msgJson.remark);


                        setTimeout(function () { runData(communityID, registrationCode, clickValue); }, 2000);
                    }
                    else {
                        alertError("获取电梯明细失败，" + res.Msg);
                    }
                }, "json");
        }
        //运行数据
        function runData(communityID, registrationCode, clickValue) {
            //var hidRegistrationCode = $("#hidRegistrationCode").val();
            //if (hidSearchBtnClick != hidRegistrationCode) return;
            var hidSearchBtnClick = $("#hidSearchBtnClick").val();
            if (clickValue != hidSearchBtnClick) return;

            $.post("/Handler/ElevatorHandler.ashx",
                {
                    "action": "GetLiftRunData",
                    "registrationCode": registrationCode,
                    "communityID": communityID
                },
                function (res) {
                    if (res.IsSucceed) {
                        var msgJson = JSON.parse(res.Data);
                        setHtml("elevatorInfoNum", msgJson.Floor);
                        setHtml("elevatorInfoFloor", msgJson.Floor);
                        setHtml("elevatorInfoCarDoor", msgJson.Open == 0 ? "关门" : "开门");
                        setHtml("elevatorInfoDerection", msgJson.UpOrDown == 0 ? "停止 " : msgJson.UpOrDown == -1 ? "下行" : "上行");
                        if (msgJson.ErrorCodeType || msgJson.ErrorCodeMean) {
                            setHtml("elevatorInfoErrorMsg", msgJson.ErrorCodeType + "，" + msgJson.ErrorCodeMean);
                        }
                        else {
                            setHtml("elevatorInfoErrorMsg", "-");
                        }

                        if (msgJson.ForHelp) {
                            $("#forHelp .Ico2").css("display", "block");
                            $("#forHelp .icoTitle").css({ "color": "#d73440", "textDecoration": "none" });
                        }
                        if (msgJson.Trapped) {
                            $("#trapped .Ico2").css("display", "block");
                            $("#trapped .icoTitle").css({ "color": "#d73440", "textDecoration": "none" });
                        }

                        setTimeoutID = setTimeout(function () { runData(communityID, registrationCode, clickValue) }, 2000);
                    }
                    else {
                        alertError("获取运行数据失败，" + res.Msg);
                        setTimeoutID = setTimeout(function () { runData(communityID, registrationCode, clickValue) }, 3000);
                    }
                }, "json");
        }
        function alertError(msg) {
            $('#alertError small').html(msg);
            $('#alertError').show();
            setTimeout(function () { $('#alertError').hide(); }, 3000);
        }
        function setHtml(id, value) {
            var oldValue = $("#" + id).html();
            if (value && oldValue != value) {
                $("#" + id).html(value);
            }
        }
    </script>
</asp:Content>
