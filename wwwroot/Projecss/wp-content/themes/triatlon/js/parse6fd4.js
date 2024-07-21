jQuery(document).ready(function($) {

  $('#search').keyup(function() {
    $('#city_load_more_out').empty();
    if (!this.value) {} else {
      if (this.value.match(/^[\u0400-\u04ff]+$/)) {


        $('#result').html('');
        $('#state').val('');
        var searchField = $('#search').val();
        console.log(searchField);
        var counter = 0;
        var result = document.getElementById('city_load_more_out');
        var ourReqest = new XMLHttpRequest();
        ourReqest.open('GET', 'https://www.triathlon.org.ua//wp-json/wp/v2/athlete?_embed&per_page=10&order=asc&search=' + searchField);
        ourReqest.onload = function() {
          var ourData = JSON.parse(ourReqest.responseText);
          for (var i = 0; i < ourData.length; i++) {
            result.innerHTML += '<div class="atlete_serch"> <img class="atlete_serch_img" src="' + ourData[i]._embedded["wp:featuredmedia"][0].source_url + '" alt=""><a href="' + ourData[i].link + '" class="atlete_serch_text" target="_blank">' + ourData[i].title.rendered + '</a></div>';
            counter++;
          }

          if (counter == 0) {
            $('#city_load_more_out').append('<div class="col-lg-12" style="color: #fff"><p>Извините, по результатам поиска нет совпадений</p></div>');
          }
          if (ourReqest.status != 200) {
            // обработать ошибку
          } else {}
        };
        ourReqest.send();
      } else {
        $('#city_load_more_out').append('<div class="col-lg-12" style="color: #fff"><p>Используйте русскоязычную раскладку</p></div>');
      }
    }
  });


});