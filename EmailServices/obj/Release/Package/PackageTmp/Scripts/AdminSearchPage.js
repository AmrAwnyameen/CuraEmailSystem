$(document).ready(function () {
    var categoryValue = localStorage.getItem("categoryIndex");
    var governorateValue = localStorage.getItem("governoratesIndex");
    var citiesValue = localStorage.getItem("citiesIndex");
    if (governorateValue !== null) {
        $("#Governorates").data("kendoDropDownList").value(governorateValue);
    }
    if (categoryValue !== null) {
        $("#Category").data("kendoDropDownList").value(categoryValue);
    }
    if (citiesValue !== null) {
        $("#Cities").data("kendoDropDownList").value(citiesValue);
    }
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
    var query = $("#Query").val();
    var searchBy = $('input[name=SerchBy]:checked').val();
    if (query !== null) {
        return window.location = "/ManageShop/Edit?id=" + dataItem.Id + "&" +
            "query=" +
            query + "&"
            +
            "searchBy="
            + searchBy + "&" +
         "viewName=" + "AdminSearch";
    }
    window.location = "/ManageShop/Edit?id=" + dataItem.Id + "&" + "viewName=" + "AdminSearch";
};
$("#button").click(function () {

    var categorySessionValue = localStorage.getItem("categoryIndex");
    var governorateSessionValue = localStorage.getItem("governoratesIndex");
    var citiesSessionValue = localStorage.getItem("citiesIndex");

    var dropGovernorates = $("#Governorates").val();
    var dropGategoryValue = $("#Category").val();
    var dropCityValue = $("#Cities").val();

    if (localStorage === null) {
        localStorage.setItem("governoratesIndex", dropGovernorates);
        localStorage.setItem("categoryIndex", dropGategoryValue);
        localStorage.setItem("citiesIndex", dropCityValue);
    }
    if (localStorage !== null && dropGovernorates === categorySessionValue) {

        localStorage.setItem("governoratesIndex", governorateSessionValue);
        localStorage.setItem("categoryIndex", categorySessionValue);
        localStorage.setItem("citiesIndex", citiesSessionValue);
    }
    if (localStorage !== null && dropGovernorates !== categorySessionValue) {
        localStorage.setItem("governoratesIndex", dropGovernorates);
        localStorage.setItem("categoryIndex", dropGategoryValue);
        localStorage.setItem("citiesIndex", dropCityValue);
    }

    showPageLoadingSpinner();
    $("#adminSearchGrid").addClass('hide');
    $("#button").prop('disabled', true);
    $.ajax({
        url: "/ManageShop/AdminShopPartial",
        type: "Post",
        data: {
            Governorates: $("#Governorates").val(),
            Cities: $("#Cities").val(),
            SerchBy: $('input[name=SerchBy]:checked').val(),
            query: $("#Query").val(),
            Category: $("#Category").val()

        },
        success: function (data) {
            $("#error").addClass('hide');
            $("#Myshops").removeClass('hide');
            $('.ajax-loader').remove();
            $('#ajaxLoaderDiv').hide();
            $("#adminSearchGrid").removeClass('hide');
            $("#Myshops").html(data);
            $("#button").prop('disabled', false);
        },
        error: function (data) {
            $("#ajaxerror").removeClass('hide');
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
                className: "btn-danger",
                callback: function () {
                    var dataItem = $("#shops").data("kendoGrid").dataSource.getByUid(uid);
                    var grid = $("#shops").data("kendoGrid");
                    grid.dataSource.remove(dataItem);
                    grid.saveChanges();
                }
            }
        },
        className: "bootbox-lg text-center  col-md-offset-2"

    });
}