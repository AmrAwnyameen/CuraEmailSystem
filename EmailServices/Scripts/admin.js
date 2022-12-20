$(document).ready(function () {
    // create DatePicker from input HTML element
    $("#startDate").kendoDatePicker();

    $("#endDate").kendoDatePicker({
    });
});
$("#button").click(function () {

    if ($('#startDate').val().length === 0 || $('#endDate').val().length === 0) {
        return toastr.success(' Date filed Required filed ');
    }
    showPageLoadingSpinner();
    $.ajax({
        url: "/ManageShop/PartialAdmin",
        type: "Post",
        data: {
            StartDate: $("#startDate").val(),
            EndDate: $("#endDate").val()
        },
        success: function (data) {
            $("#error").addClass('hide');
            $("#Myshops").removeClass('hide');
            $('.ajax-loader').remove();
            $('#ajaxLoaderDiv').hide();
            $("#Myshops").html(data);
        },
        error: function (data) {
            $("#error").removeClass('hide');
            $("#Myshops").addClass('hide');
        }
    });

});


