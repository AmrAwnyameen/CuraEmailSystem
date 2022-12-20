function confirmMsgFunc(messageTitle, messageBody, cancelLabel, confirmLabel,callback) {

    bootbox.dialog({
        message: messageBody,
        title: messageTitle,
        className: "bootbox-sm",
        buttons: {
            danger: {
                label: cancelLabel,
                className: "btn-success",
                callback: function () {
                    return;
                }
            },
             success: {
                label: confirmLabel,
                className: "btn-danger",
                callback: callback
            }
            }
        });
}



//this function just used in clinical notes =>> "swapped the button that sign be green and cancel red"
function confirmSign(messageTitle, messageBody, cancelLabel, confirmLabel, callback) {

    bootbox.dialog({
        message: messageBody,
        title: messageTitle,
        className: "bootbox-sm",
        buttons: {
            danger: {
                label: cancelLabel,
                className: "btn-danger",
                callback: function () {
                    return;
                }
            },
            success: {
                label: confirmLabel,
                className: "btn-success",
                callback: callback
            }
        }
    });
}
function confirmMessagFuncWithDismissHandler(messageTitle, messageBody, cancelLabel, confirmLabel, callback, dismissCallback, onDismissHandler) {

    bootbox.dialog({
        message: messageBody,
        title: messageTitle,
        className: "bootbox-sm",
        onEscape: onDismissHandler,
        buttons: {
            danger: {
                label: cancelLabel,
                className: "btn-danger",
                callback: dismissCallback
            },
            success: {
                label: confirmLabel,
                className: "btn-success",
                callback: callback
            }
        }
    });
}

//this function used in clinicl notes to handel what cancel and x buttons do when they triggered
function confirmMsgFuncWithDismissHandler(messageTitle, messageBody, cancelLabel, confirmLabel, callback, dismissCallback, onDismissHandler) {

    bootbox.dialog({
        message: messageBody,
        title: messageTitle,
        className: "bootbox-sm",
        onEscape: onDismissHandler,
        buttons: {
            danger: {
                label: cancelLabel,
                className: "btn-success",
                callback: dismissCallback
            },
            success: {
                label: confirmLabel,
                className: "btn-danger",
                callback: callback
            }
        }
    });
}