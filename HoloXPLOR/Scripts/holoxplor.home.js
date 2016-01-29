$(document).ready(function () {
    var hideOverlay = 0;
    var $form = $('#form-upload');

    if ($form.length == 0) return;

    $("html").upload({

        action: $form.attr('action'),
        label: false,
        dataType: "json",
        maxSize: 0x200000,
        multiple: false,
        autoUpload: true,
        maxQueue: 1,

    }).on("filedragover.upload", function (e, file) {
        window.clearTimeout(hideOverlay);
        if ($('.modal-backdrop').length == 0) {
            $('#upload').modal('show');
        }
    }).on("filedragleave.upload", function (e, file) {
        window.clearTimeout(hideOverlay);
        hideOverlay = window.setTimeout(function () {
            $('#upload').modal('hide');
        }, 200);
    }).on("filestart.upload", function (e, file) {

        // TODO: Display Upload Overlay

    }).on("fileerror.upload", function (e, file, response) {

        // TODO: Display Error Overlay

    }).on("fileprogress.upload", function (e, file, percent) {

        // TODO: Display Upload Progress

    }).on("filecomplete.upload", function (e, file, response) {

        window.location.href = response.UrlPath;

    })
});