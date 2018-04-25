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
});