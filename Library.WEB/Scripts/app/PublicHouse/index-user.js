
$(document).ready(function () {
    var dataSource = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                $.ajax({
                    type: 'GET',
                    url: "getall",
                    dataType: "json",
                    success: function (data) {
                        return e.success(data);
                    }
                });
            },


            destroy: function (e) {

                $.ajax({
                    type: 'POST',
                    url: '/PublicHouse/Delete/' + e.data.PublicHouseId,
                    dataType: 'number',
                    success: function (data) {
                        $('#publichouses-grid').data('kendoGrid').dataSource.read();
                        $('#publichouses-grid').data('kendoGrid').refresh();
                        e.success(data);
                    },
                    error: function (data) {
                        $('#publichouses-grid').data('kendoGrid').dataSource.read();
                        $('#publichouses-grid').data('kendoGrid').refresh();
                        e.error("", "404", data);
                    }
                });
            },
        },

        schema:
            {
                model:
                    {
                        id: "PublicHouseId",
                        fields: {
                            PublicHouseId: { editable: false, nullable: true, type: "number" },
                            PublicHouseName: { editable: true, nullable: true, type: "string" },
                            Country: { editable: true, nullable: true, type: "string" },
                        }
                    }
            },
        batch: false,
        pageSize: 10

    });

    $("#publichouses-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: {
            mode: "inline",
            confirmation: false
        },

        columns: [
            {
                field: "PublicHouseName",
                title: "Name",
                sortable: true
            },
            {
                field: "Country",
                title: "Country",
                sortable: true
            }

        ],
        height: "500px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});