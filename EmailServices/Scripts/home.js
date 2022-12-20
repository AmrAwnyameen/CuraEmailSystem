
    function filterGovernorate() {
        return {
            governorateId: $("#Governorates").val()
        };
    }


    //get gride Id

    function onView(uid) {
        // capture the grid and dataItem
        var grid = $('#shops').data('kendoGrid');
        var dataItem = grid.dataSource.getByUid(uid);
        window.location = "/ManageShop/Edit?id=" + dataItem.Id;
    }

//ajax Call To Partial view

$("#button").click(function () {

    $.ajax({
        url: "/ManageShop/ShopPartial",
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
            $("#Myshops").html(data);
       

        },
        error: function (data) {
            $("#ajaxerror").removeClass('hide');
            $("#Myshops").addClass('hide');
        }
    });
});
