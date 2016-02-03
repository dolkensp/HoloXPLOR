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

        $('#upload .modal-body').html('<p>Now uploading...</p>');

    }).on("fileerror.upload", function (e, file, response) {

        $('#upload .modal-body').html('<p>There was an error uploading the file.</p>' +
                                      '<p>If the errors persist, please email your hangar XML to <a href="mailto:plugins@ddrit.com?subject=Failing+Inventory+Upload">plugins@ddrit.com</a>.</p>' +
                                      '<p>Alternatively, you can try deleting your inventory XML, and launching your hangar to get a fresh copy from CIG.</p>');

    }).on("fileprogress.upload", function (e, file, percent) {

        $('#upload .modal-body').html('<p>Now uploading (' + percent + '%)...</p>');

    }).on("filecomplete.upload", function (e, file, response) {

        window.location.href = response.UrlPath;

    })
});