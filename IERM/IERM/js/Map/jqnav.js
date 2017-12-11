$(document).ready(function () {

    maphover();

   
});

function maphover() {
    var self = "";
    $(".city").hover(
    //	function () {
    //	    self = $(this);
    //	    self.find(".xm").show();
    //	    self.children("a").css("z-index", "10");
    //	    self.siblings().children("a").css("z-index", "9");
    //	    self.addClass("hover").children("img").show();
    //	    self.siblings().children("img").hide().removeClass("hover");
    //	},
    	function () {
    	    self = $(this);
    	    self.find(".xm").hide();
    	    self.children("img").hide();
    	    self.removeClass("hover");
    	}
    );

    $('.city').each(function () {
        $(this).click(function () {
            self = $(this);
            self.find(".xm").show();
            self.children("a").css("z-index", "10");
            self.siblings().children("a").css("z-index", "9");
            self.addClass("hover").children("img").show();
            self.siblings().removeClass("hover");
            self.siblings().children("img").hide();
            //取得省名字
            var province = self.children("a").attr("title");
            var num = self.find(".xm")[0].firstChild;
            GetProvinceCommunity(province, num);
        })
    });
};

