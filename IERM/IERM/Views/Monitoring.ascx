<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Monitoring.ascx.cs" Inherits="IERM.Views.Monitoring" %>

<link href="/css/treeview/bootstrap-treeview.min.css" rel="stylesheet" />
<link href="/css/select2andtree/select2.min.css" rel="stylesheet" />
<link href="/css/select2andtree/select2-bootstrap.min.css" rel="stylesheet" />
<div class="detailSearch">
    <div class="form-inline heightAll">
        <div class="text-left heightAll vertical">
            <div class="input-group" style="margin-right: 20px; margin-left: 20px;">
                <span class="input-group-addon">物业公司：</span>
                <select id="property" class="form-control" style="margin-right: 10px;" runat="server">
                    <option value="0">未选择</option>
                    <%foreach (System.Data.DataRow item in propertyList.Rows)
                        { %>
                    <option value="<%=Convert.ToInt32(item["propertyID"])%>"><%=item["propertyName"].ToString() %></option>
                    <%} %>
                </select>
            </div>

            <div class="input-group" style="margin-right: 20px;">
                <span class="input-group-addon">项目选择：</span>
                <select id="test" class="form-control" style="margin-right: 10px;">
                </select>
            </div>

            <div class="input-group" style="margin-right: 10px;">
                <span class="input-group-addon">设备房：</span>
                <select class="form-control" id="devhouse">
                </select>
            </div>

            <button id="serach" type="button" class="btn btn-info input-group"><span class="glyphicon glyphicon-search"></span>筛选</button>
            <span class="sxt">
                <img src="/img/bar/sxt.png" class="sxtImg"></span>
        </div>
    </div>
</div>
<input type="hidden" id="mID" runat="server" />
<input type="hidden" id="communityID" runat="server" />
<input type="hidden" id="devhouseID" runat="server" />
<input type="hidden" id="systypeID" runat="server" />
<input type="hidden" id="pageUrls" runat="server" />
<script src="/js/select2andtree/select2.min.js"></script>
<script src="/js/select2andtree/i18n/zh-CN.js"></script>
<script src="/js/select2andtree/select2tree.js"></script>
<script type="text/javascript">

    $(function () {
        //初始化物业公司
        initSelectTree($('#property').val(), true);

        $("#test").change(function () {
            initDevHouse(false);
        });

        $("#property").change(function () {
            initSelectTree($('#property').val(), false);
        });
        //$("#serach").hide();
        $("#serach").click(function () {
            var communityid = $('#test option:selected').attr('data-value');
            var devhouseid = $('#devhouse option:selected').val();
            var systypeid = $('#devhouse :selected').data("tid");
            var mid = $('#mID').val();

            if (systypeid == 3) {
                var byq = "";
                if ($('#byqsl').val()) {
                    byq = $('#byqsl').val();
                }
                window.location.href = "/Handler/MonitorController.ashx?communityID=" + communityid + "&devhouseID=" + devhouseid + "&systypeID=" + systypeid + "&showurl=" + byq;
            }
            else {
                window.location.href = "/Handler/MonitorController.ashx?communityID=" + communityid + "&devhouseID=" + devhouseid + "&systypeID=" + systypeid;
            }

        });

    });

    //初始化省市小区树列表
    function initSelectTree(pid, initflag) {
        $.getJSON("/Handler/CityAndCommunity.ashx?action=getcpoe&r=" + Math.random(), { "propertyID": pid }, function (res) {
            if (res.IsSucceed) {
                $("#test").empty();
                $("#test").append(res.Data).select2tree();
                // $("#test option[data-value='" + $('#communityID').val() + "'][data-level='3']").attr("selected", true).trigger("change");
                //初始化
                if (initflag) {
                    var communityID = request("communityID");
                    if (communityID != "") {
                        //设置默认选项
                        $("#test option[data-value='" + communityID + "'][data-level='3']").attr("selected", true).trigger("change");
                        initDevHouse(true);
                    } else {
                        initDevHouse(false);
                    }
                }


            }
        });
    }

    //获取设备房列表
    function initDevHouse(initflag) {
        var paras = {
            "communityID": $('#test option:selected').data("value"),
            "attribute": $('#cph_body_hidden_Attribute').val(),
            "systypeID": request("systypeID")
        };
        $.getJSON("/Handler/CityAndCommunity.ashx?action=getdevhouseandsystype&r=" + Math.random(), paras, function (res) {
            $("#devhouse").empty();
            if (res.IsSucceed) {
                $.each(res.Data, function (key, value) {
                    $("#devhouse").append("<option data-tid='" + this.systypeID + "' value='" + this.devID + "'>" + this.devName + "---" + this.systypeName + "</option>");
                });

            }
            else { $("#devhouse").append("<option value='0'>未设置</option>"); }

            if (initflag) {
                var devhouseID = request("devhouseID");
                var systypeID = $('#systypeID').val();
                if (!devhouseID) {
                    devhouseID = $('#devhouseID').val();
                }
                setTimeout(function () {
                    $("#devhouse option[data-tid='" + systypeID + "'][value='" + devhouseID + "']").prop("selected", true);
                    $("#serach").show();
                    if (typeof GetDevice === "function") {
                        GetDevice(true);
                    }
                }, 100);
            }
        });
    }

</script>
