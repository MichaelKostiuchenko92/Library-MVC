
var houses = $("#houses").val();
var houseIds = JSON.parse(houses).map(function (object) {
    return object.PublicHouseId;
})



$(document).ready(function () {
    $("#multiselect").kendoMultiSelect({
        placeholder: "--Select Public Houses--",
        dataTextField: "PublicHouseName",
        dataValueField: "PublicHouseId",
        autoBind: true,
        dataSource: {
            transport: {
                read: {
                    dataType: "json",
                    url: "/book/getallpublichouses"
                }
            }
        }
    });
    $("#multiselect").getKendoMultiSelect().value(houseIds);
});