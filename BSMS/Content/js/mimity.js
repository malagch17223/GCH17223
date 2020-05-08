// Function to check element is exist
$.fn.exist = function(){ return $(this).length > 0; }

// Function to get window width
function get_width() {
  return $(window).width();
}

// Function to set color & style
function set_color() {
  var color = localStorage.getItem('mimity-color');
  var style = localStorage.getItem('mimity-style');
  $('#color-chooser').val(color);
  $('#style-chooser').val(style);
  $('#theme').attr('href','css/style.'+color+'.'+style+'.css');
  $('.logo img').attr('src','images/logo-'+color+'.png');
}

$(function(){

  // Change Color Style
  $('.chooser-toggle').click(function(){
    $('.chooser').toggleClass('chooser-hide');
  });
  if (localStorage.getItem('mimity-color') == null) {
    localStorage.setItem('mimity-color', 'teal');
  }
  if (localStorage.getItem('mimity-style') == null) {
    localStorage.setItem('mimity-style', 'flat');
  }
  set_color();
  $('#color-chooser').change(function(){
    localStorage.setItem('mimity-color', $(this).val());
    set_color();
  });
  $('#style-chooser').change(function(){
    localStorage.setItem('mimity-style', $(this).val());
    set_color();
  });

  // open navigation dropdown on hover (only when width >= 768px)
  $('ul.nav li.dropdown').hover(function() {
    if (get_width() >= 767) {
      $(this).addClass('open');
    }
  }, function() {
    if (get_width() >= 767) {
      $(this).removeClass('open');
    }
  });

  // Navigation submenu
  $('ul.dropdown-menu [data-toggle=dropdown]').on('click', function(event) {
    event.preventDefault();
    event.stopPropagation();
    $(this).parent().siblings().removeClass('open');
    $(this).parent().toggleClass('open');
  });

  // owlCarousel for Home Slider
  if ($('.home-slider').exist()) {
    $('.home-slider').owlCarousel({
      items:1,
      loop:true,
      autoplay:true,
      autoplayHoverPause:true,
      dots:false,
      nav:true,
      navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
    });
  }

  // owlCarousel for Widget Slider
  if ($('.widget-slider').exist()) {
    var widget_slider = $('.widget-slider');
    widget_slider.owlCarousel({
      items:1,
      dots: false,
      nav: true,
      navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
      responsive:{
        0:{
          items:1,
        },
        480:{
          items:2,
        },
        768:{
          items:3,
        },
        992:{
          items:1,
        }
      }
    });
  }

  // owlCarousel for Product Slider
  if ($('.product-slider').exist()) {
    var product_slider = $('.product-slider')
    product_slider.owlCarousel({
      dots: false,
      nav: true,
      navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
      responsive:{
          0:{
            items:1,
          },
          480:{
            items:2,
          },
          768:{
            items:3,
          },
          992:{
            items:3,
          },
          1200:{
            items:4,
          }
        }
    });
  }

   // owlCarousel for Related Product Slider
  if ($('.related-product-slider').exist()) {
    var related_product_slider = $('.related-product-slider')
    related_product_slider.owlCarousel({
      dots: false,
      nav: true,
      navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
      responsive:{
          0:{
            items:1,
          },
          480:{
            items:2,
          },
          768:{
            items:3,
          },
          992:{
            items:5,
          },
          1200:{
            items:6,
          }
        }
    });
  }

  // owlCarousel for Brand Slider
  if ($('.brand-slider').exist()) {
    var brand_slider = $('.brand-slider');
    brand_slider.owlCarousel({
      dots:false,
      nav:true,
      navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
      responsive:{
        0:{
          items:1,
        },
        480:{
          items:2,
          margin:15
        },
        768:{
          items:3,
          margin:15
        },
        992:{
          items:4,
          margin: 30
        },
        1200:{
          items:6,
          margin: 30
        }
      }
    });
  }

  // Tooltip
  $('button[data-toggle="tooltip"]').tooltip({container:'body',animation:false});
  $('a[data-toggle="tooltip"]').tooltip({container:'body',animation:false});

  // Back top Top
    $(window).scroll(function(){
    if ($(this).scrollTop()>70) {
      $('.back-top').fadeIn();
    } else {
      $('.back-top').fadeOut();
    }
  });

  // Touchspin
  if ($('.input-qty').exist()) {
    $('.input-qty input').TouchSpin({
      verticalbuttons: true,
      prefix: 'qty'
    });
  }

  // Typeahead example
  $('.search-input').typeahead({
    fitToElement: true,
    source: [
      'IncultGeo Print Polo T-Shirt',
      'Tommy HilfigerNavy Blue Printed Polo T-Shirt',
      'WranglerNavy Blue Solid Polo T-Shirt',
      'NikeAs Matchup -Pq Grey Polo T-Shirt',
      'CelioKhaki Printed Round Neck T-Shirt',
      'CelioOff White Printed Round Neck T-Shirt',
      'Levi\'sNavy Blue Printed Round Neck T-Shirt',
      'IncultAcid Wash Raglan Crew Neck T-Shirt',
      'Avoir EnvieOlive Printed Round Neck T-Shirt',
      'ElaboradoBrown Printed Round Neck T-Shirt',
    ]
  });

  // metisMenu for vertical-menu
  if ($('.vertical-menu').exist()) {
    $('.vertical-menu').metisMenu();
  }

});