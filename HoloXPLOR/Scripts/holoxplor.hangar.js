$('.js-download').bind('click', function (e) {

    ga('send', 'event', 'HoloXPLOR.Hangar', 'Download Start', $.cookie('js_handle') + '.xml');

    $('#download').modal('show');

});