$(document).ready(function () {

    if ((location.host || location.hostname) == "holoxplor.azurewebsites.net" || /http:\/\/holoxplor.space/.test(location.href)) {
        window.location.replace("https://holoxplor.space/"); return;
    }

    var $form = $('#form-upload');

    if ($form.length == 0) return;

    var hideOverlay = 0;

    $("html").upload({

        action: $form.attr('action'),
        label: false,
        dataType: "json",
        maxSize: 0x1000000,
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

        ga('send', 'event', 'HoloXPLOR.Hangar', 'Upload Start', file.name);

        $('#upload .modal-body').html('<p>Now uploading...</p>');

    }).on("fileerror.upload", function (e, file, response) {

        ga('send', 'event', 'HoloXPLOR.Hangar', 'Upload Error: ' + response, file.name);

        switch (response) {
            case "size":
            case "Request Entity Too Large":
                $('#upload .modal-body').html('<p>The selected file is too large.</p>' +
                                              '<p>If the errors persist, please email a copy of your XML file to <a href="mailto:plugins@ddrit.com?subject=Failing+Inventory+Upload">plugins@ddrit.com</a> and I will review the size limits.</p>' +
                                              '<p>Alternatively, you can try deleting your <em>db_[yourhandle].xml</em> file, and launching your hangar to get a fresh copy from CIG.</p>');
                break;
            case "Unsupported Media Type":
                $('#upload .modal-body').html('<p>There was an error processing the file.</p>' +
                                              '<p>Please make sure you are uploading the <em>db_[yourhandle].xml</em> file from your USER/Database directory.</p>' +
                                              '<p>If the errors persist, please email a copy of your XML file to <a href="mailto:plugins@ddrit.com?subject=Failing+Inventory+Upload">plugins@ddrit.com</a>.</p>' +
                                              '<p>Alternatively, you can try deleting your <em>db_[yourhandle].xml</em> file, and launching your hangar to get a fresh copy from CIG.</p>');
                break;
            case "Internal Server Error":
            default:
                $('#upload .modal-body').html('<p>There was an error uploading the file.</p>' +
                                              '<p>If the errors persist, please email a copy of your XML file to <a href="mailto:plugins@ddrit.com?subject=Failing+Inventory+Upload">plugins@ddrit.com</a>.</p>' +
                                              '<p>Alternatively, you can try deleting your <em>db_[yourhandle].xml</em> file, and launching your hangar to get a fresh copy from CIG.</p>');
                break;
        }

    }).on("fileprogress.upload", function (e, file, percent) {

        $('#upload .modal-body').html('<p>Now uploading (' + percent + '%)...</p>');

    }).on("filecomplete.upload", function (e, file, response) {

        ga('send', 'event', 'HoloXPLOR.Hangar', 'Upload Complete', file.name);

        $.cookie('js_handle', response.Handle);

        window.location.href = response.UrlPath;

    });

    var $upload = $('input[type=file]');
    var $left = $('<span class="col-xs-6" />');

    $upload.addClass('btn btn-default');
    $left.append($upload);

    $form.addClass('row');
    $form.append($left);
    $form.append($('<span class="col-xs-6"><input type="submit" value="Manual Upload" class="btn btn-default" /></span>'));
});