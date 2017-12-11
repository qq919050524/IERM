/**
 * Particleground demo
 * @author Jonathan Nicol - @mrjnicol
 */

$(document).ready(function() {
  $('#particles').particleground({
    dotColor: '#5cbdaa',
    lineColor: '#5cbdaa'
  });
  $('.intro').css({
    'margin-top': -($('.intro').height() / 2),
    'margin-left': -($('.intro').width() / 2)
  });
});

window.onresize=function(){
	$('.intro').css({
    'margin-top': -($('.intro').height() / 2),
    'margin-left': -($('.intro').width() / 2)
  });
};