
var deleteId;
$(document).ready(function () {
    // create DatePicker from input HTML element
    $("#startDate").kendoDatePicker({
        dateFormat: 'dd-mm-yy'
    });
    $("#endDate").kendoDatePicker({
        dateFormat: 'dd-mm-yy'
    });
    var startDate = $("#startDate").val();
    if ((startDate !== "")) {
        $("button").trigger("click");
    }

});

function onView(uid) {
    // capture the grid and dataItem
    var grid = $('#ModificationTimes').data('kendoGrid');
    var startDate = $("#startDate").val();
    var endDate = $("#endDate").val();
    var dataItem = grid.dataSource.getByUid(uid);
    window.location = "/ManageShop/SellerModifiedShops?UpdatedBy="
        +
        dataItem.UpdatedBy
        +
        "&" +
        "StartDate="
        +
        startDate +
        "&" +
        "EndDate=" +
        endDate;
}

function SellersAdditions(uid) {
    // capture the grid and dataItem
    var grid = $('#CreationTimes').data('kendoGrid');
    var dataItem = grid.dataSource.getByUid(uid);
    var startDate = $("#startDate").val();
    var endDate = $("#endDate").val();
    window.location = "/ManageShop/SellerAdditionsShops?createdBy="
        + dataItem.CreatedBy +
        "&" +
        "StartDate="
        +
        startDate +
        "&" +
        "EndDate=" +
        endDate;
}

function locations(uid) {
    // capture the grid and dataItem
    var grid = $('#shops').data('kendoGrid');
    var dataItem = grid.dataSource.getByUid(uid);
    if (dataItem.Longtuide === null || dataItem.Latituide === null) {
        return toastr.warning('لايوجد بيانات لهذا الموقع');
    }
    window.location = "/ManageShop/Map?Longtuide=" +
        dataItem.Longtuide +
        "&" +
        "Latituide=" +
        dataItem.Latituide +
        "&" +
        "ShopName=" +
        dataItem.Name +
        "&" +
        "Address=" +
        dataItem.Address +
        "&" +
        "ImageUrl=" +
        dataItem.ImageUrl;
}

function openImage(imageUrl) {
    window.open(imageUrl);
}

$("#button").click(function () {

    if ($('#startDate').val().length === 0) {
        return toastr.error(' حقل تاريخ البدايه مطلوب');
    }
    showPageLoadingSpinner();
    $("#button").prop('disabled', true);
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
            $("#button").prop('disabled', false);
        },
        error: function (data) {
            $("#error").removeClass('hide');
            $("#Myshops").addClass('hide');
            $("#button").prop('disabled', false);
        }
    });

});

function onDelete(uid) {
    bootbox.dialog({
        message: 'هل انت متاكد',
        buttons: {
            delete: {
                label: 'حذف',
                className: "btn-danger text-center",

                callback: function () {
                    var dataItem = $("#shops").data("kendoGrid").dataSource.getByUid(uid);
                    var grid = $("#shops").data("kendoGrid");
                    grid.dataSource.remove(dataItem);
                    grid.saveChanges();
                }
            }
        },
        className: "text-center"
    });
}
