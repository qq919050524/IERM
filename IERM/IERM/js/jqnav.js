$(document).ready(function() {
	maphover();
});

function maphover() {
	var self = "";
	$(".city").hover(
		function() {
			self = $(this);
			self.addClass("hover").children("div").show();
			self.siblings().children("div").hide().removeClass("hover");
			
		},
		function() {
			self = $(this);
			self.children("div").hide();
			self.removeClass("hover");
		}
	);

	$('.city').each(function() {
		$(this).click(function() {			
			self = $(this);
			self.addClass("hover").children("div").show();			
			self.siblings().removeClass("hover");
			self.siblings().children("div").hide();
		})
	});
};

