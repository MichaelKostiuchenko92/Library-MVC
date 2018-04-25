$(document).ready(function () {
    dataSource = new kendo.data.DataSource({

        transport: {
            read:
                {
                    url: "getall",
                    dataType: "json",
                },
        },

        schema:
            {
                model:
                    {

                        fields: {
                            Name: { editable: true, nullable: true, type: "string" },
                            Type: { editable: true, nullable: true, type: "string" },
                        }
                    }
            },
        pageSize: 10

    });

    $("#library-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: "inline",

        columns: [
            {
                field: "Name",
                title: "Name",
                sortable: true
            },
            {
                field: "Type",
                title: "Type",
                sortable: false
            },

        ],
        height: "600px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});