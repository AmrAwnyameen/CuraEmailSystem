function confirmDelete(options) {

    options.confirmMsg;
    options.confirmDelete;
    options.callback;
    options.confirmTitle;
    options.targetButton;
    $(options.targetButton).on('click', function () {
        bootbox.dialog({
            message: options.confirmMsg,
            title: options.confirmTitle,
            buttons: {
                cancel: {
                    label: cancleBTn,
                    className: "btn-success",
                    callback: $(".bootbox-sm").css("display", "none")
                },
                delete: {
                    label: deleteBTn,
                    className: "btn-danger",
                    callback: options.callback

                }
            },
            className: "bootbox-sm"
        });
    });
}

function confirmGridDelete(options) {

    options.confirmMsg;
    options.confirmDelete;
    options.callback;
    options.confirmTitle;
    bootbox.dialog({
        message: options.confirmMsg,
        title: options.confirmTitle,
        buttons: {
            cancel: {
                label: cancleBTn,
                className: "btn-success",
                callback: $(".bootbox-sm").css("display", "none")
            },
            delete: {
                label: deleteBTn,
                className: "btn-danger",
                callback: options.callback

            }
        },
        className: "bootbox-sm"
    });
}