$(document).ready(function () {
    var categoryValue = localStorage.getItem("categoryIndex");
    var governorateValue = localStorage.getItem("governoratesIndex");
    var citiesValue = localStorage.getItem("citiesIndex");

    if (governorateValue !== null && governorateValue !== '') {
        $("#Governorates").data("kendoDropDownList").value(governorateValue);
    }
    if (categoryValue !== null && categoryValue !== '') {
        $("#Category").data("kendoDropDownList").value(categoryValue);
    }
    if (citiesValue !== null && citiesValue !== '') {
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
//get gride Id
function onView(uid) {
    showPageLoadingSpinner();
    $("#sellerShop").addClass('hide');
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
            + searchBy;
    }
    $('.ajax-loader').remove();
    $('#ajaxLoaderDiv').hide();
     window.location = "/ManageShop/Edit?id=" + dataItem.Id;
};
//ajax Call To Partial view
$("#button").click(function () {

    var categorySessionValue = localStorage.getItem("categoryIndex");
    var governorateSessionValue = localStorage.getItem("governoratesIndex");
    var citiesSessionValue = localStorage.getItem("citiesIndex");

    var dropGovernorates = $("#Governorates").val();
    var dropGategoryValue = $("#Category").val();
    var dropCityValue = $("#Cities").val();

    if (dropGovernorates == '' || dropGategoryValue == '' || dropCityValue == '') {
        $("#Governorates").data("kendoDropDownList").dataSource.read();
        $("#Category").data("kendoDropDownList").dataSource.read();
        $("#Cities").data("kendoDropDownList").dataSource.read();

        dropGovernorates = $("#Governorates").val();
        dropGategoryValue = $("#Category").val();
        dropCityValue = $("#Cities").val();
    }

    if (governorateSessionValue === null || governorateSessionValue === '') {
        localStorage.setItem("governoratesIndex", dropGovernorates);
        localStorage.setItem("categoryIndex", dropGategoryValue);
        localStorage.setItem("citiesIndex", dropCityValue);
    }
    else if (dropGovernorates === categorySessionValue) {

        localStorage.setItem("governoratesIndex", governorateSessionValue);
        localStorage.setItem("categoryIndex", categorySessionValue);
        localStorage.setItem("citiesIndex", citiesSessionValue);
    }
    else if (dropGovernorates !== categorySessionValue) {
        localStorage.setItem("governoratesIndex", dropGovernorates);
        localStorage.setItem("categoryIndex", dropGategoryValue);
        localStorage.setItem("citiesIndex", dropCityValue);
    }
    showPageLoadingSpinner();
    $("#sellerShop").addClass('hide');
    $("#button").prop('disabled', true);
    $.ajax({
        url: "/ManageShop/ShopPartial",
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
            $("#sellerShop").removeClass('hide');
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