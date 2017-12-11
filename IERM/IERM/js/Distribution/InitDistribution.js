

$(function () {
    
    //设备房下拉选择
    $("#devhouse").change(function () {
        GetDevice();
    });
});
/*
功能:获取配电房设备对应的页面
initflag:true：数据初始化；false：非数据初始化
2017年5月11日 14:43:39 BY 潘阳
*/
function GetDevice(initflag) {
    var devhouseid = $('#devhouse').val();
    var systypeid = $('#devhouse :selected').data("tid");
    if (systypeid == 3) {
        $.getJSON("/Handler/CityAndCommunity.ashx?action=getdevice&r=" + Math.random(), { "devhouseID": devhouseid }, function (res) {
            if (res.IsSucceed) {
                $('#byqsl').empty();
                $.each(res.Data, function (index) {
                    $('#byqsl').append('<option value="' + res.Data[index].deviceUrl + '">' + res.Data[index].deviceName + '</option>');
                });
                if (initflag)
                {
                    var devtype = request("pageUrls");
                    $('#byqsl').val(devtype);

                }
            }
        });
    }
}