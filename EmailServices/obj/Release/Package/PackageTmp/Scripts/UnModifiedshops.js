$(document).ready(function () {
    $("#button").trigger("click");
});
function filterGovernorate() {
    return {
        governorateId: $("#Governorates").val(),
        city: $("input[aria-owns$='Cities_listbox']").val()
    };
}
function onView(uid) {
    // capture the grid and dataItem
    var grid = $('#shops').data('kendoGrid');
    var dataItem = grid.dataSource.getByUid(uid);
    window.location = "/ManageSearch/Edit?id=" + dataItem.Id;
}
$("#button").click(function () {
    showPageLoadingSpinner();
    $("#button").prop('disabled', true);
    $.ajax({
        url: "/ManageShop/UnModifiedShopPartial",
        type: "Post",
        data: {
            Governorates: $("#Governorates").val(),
            Cities: $("#Cities").val(),
            SerchBy: $('input[name=SerchBy]:checked').val(),
            query: $("#Query").val()
        },
        success: function (data) {
            $("#error").addClass('hide');
            $("#Myshops").removeClass('hide');
            $('.ajax-loader').remove();
            $('#ajaxLoaderDiv').hide();
            $("#button").prop('disabled', false);
            $("#Myshops").html(data);
        },
        error: function (data) {
            toastr.error("حدث خطا ما");
            $("#Myshops").addClass('hide');
            $("#button").prop('disabled', false);
        }
    });
});
