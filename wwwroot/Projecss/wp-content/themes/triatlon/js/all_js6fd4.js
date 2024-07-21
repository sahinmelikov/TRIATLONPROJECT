"use strict";

$(document).ready(function () {
  // burger
  $(".burger").click(function () {
    $(".header-nav").fadeToggle();
    $(".burger__line").toggleClass("active");
  });

  // search
  $(".header .search").click(() => {
    $(".search-form").fadeToggle();
  });

  // order form
  $(".order-page-rulers__item").first().addClass("active");

  $(".order-page-rulers__item-header").click(function () {
    // $(".order-page-rulers__item-body").not($(this)).slideUp();
    // $(".order-page-rulers__item").not($(this)).removeClass("active");

    $(this).next().slideToggle();
    $(this).parent().toggleClass("active");
  });

  // gallery
  $(".gallery-slider__item").each((i, e) => {
    let hrefGallary = $(e).find($("img")).attr("src");
    $(e)
      .find($("img"))
      .wrap('<a data-fancybox="gallery" href="' + hrefGallary + '"></a>');
  });

  // sliders

  $(".news-screen-slider, .results-screen-slider, .gallery-slider").slick({
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 1,
    nextArrow: '<div class="btn custom-arrow custom-arrow-right"></div>',
    prevArrow: '<div class="btn custom-arrow custom-arrow-left"></div>',
    dots: true,
    responsive: [
      {
        breakpoint: 1200,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        },
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
    ],
  });
  $(".calendar-slider, .future-slider, .atlet-results-slider ").slick({
    infinite: true,
    slidesToShow: 1,
    slidesToScroll: 1,
    nextArrow: '<div class="btn custom-arrow custom-arrow-right"></div>',
    prevArrow: '<div class="btn custom-arrow custom-arrow-left"></div>',
    dots: true,
  });
  $(".team-screen-slider,.sponsors-screen-slider").slick({
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 1,
    nextArrow: '<div class="btn custom-arrow custom-arrow-right"></div>',
    prevArrow: '<div class="btn custom-arrow custom-arrow-left"></div>',
    dots: true,
    responsive: [
      {
        breakpoint: 1200,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        },
      },
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
    ],
  });
  $(".event-option").hide();
  $(".event-option").first().show();
  $(".event-filter__item").click(function (event) {
    event.preventDefault();
    $(".event-filter__item").removeClass("active");
    $(this).addClass("active");
    $(".event-option").hide();
    $(".event-option").each((i, e) => {
      if ($(this).data("event-id") === $(e).attr("id")) {
        $(e).show();
      }
    });
  });

  // modal
  $(".open-call-back").click(() => {
    $(".modal-call-back-wrap").addClass("active");
  });
  $(".modal-close").click(function () {
    $(".modal-wrap").removeClass("active");
  });

  // btn lines
  $(".btn_lines").wrap('<div class="btn_lines-wrap"></div>');
  $(".btn_line-right").wrap('<div class="btn_line-right-wrap"></div>');
});
