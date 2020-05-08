// Price Range
var price = document.getElementById('price');
noUiSlider.create(price, {
  start: [20, 80],
  connect: true,
  range: {
    'min': 0,
    'max': 100
  }
});
price.noUiSlider.on('update', function(values, handle) {
  var value = values[handle];
  if (handle) {
    $('#max-price').text('$' + Math.round(value));
    $('input[name="max-price"]').text(Math.round(value));
  } else {
    $('#min-price').text('$' + Math.round(value));
    $('input[name="min-price"]').text(Math.round(value));
  }
});