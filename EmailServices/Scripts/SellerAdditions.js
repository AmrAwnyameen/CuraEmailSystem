function onView(uid) {
    // capture the grid and dataItem
    var grid = $('#shops').data('kendoGrid');
    var dataItem = grid.dataSource.getByUid(uid);
    window.location = "/ManageShop/Edit?id=" + dataItem.Id + "&" + "viewName=" + "SellerView";
}
function locations(uid) {
    // capture the grid and dataItem
    var grid = $('#shops').data('kendoGrid');
    var dataItem = grid.dataSource.getByUid(uid);
    if (dataItem.Longtuide === null || dataItem.Latituide === null) {
        return toastr.warning(' لايوجد بيانات لهذا الموقع');
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
        dataItem.Address + "&" + "ImageUrl=" + dataItem.ImageUrl;
}
function openImage(imageUrl) {
    window.open(imageUrl);
}
function onDelete(uid) {
    bootbox.dialog({
        message: 'هل انت متاكد',
        title: 'حذف',
        buttons: {
            cancel: {
                label: 'رجوع',
                className: "btn-success",
                callback: $(".bootbox-sm").css("display", "none")
            },
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
