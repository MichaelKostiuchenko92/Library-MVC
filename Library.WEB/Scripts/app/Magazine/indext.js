
$(document).ready(function () {
    dataSource = new kendo.data.DataSource({

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
                    url: '/Magazine/Delete/' + e.data.MagazineId,
                    dataType: 'number',
                    success: function (data) {
                        $('#magazines-grid').data('kendoGrid').dataSource.read();
                        $('#magazines-grid').data('kendoGrid').refresh();
                        e.success(data);
                    },
                    error: function (data) {
                        $('#magazines-grid').data('kendoGrid').dataSource.read();
                        $('#magazines-grid').data('kendoGrid').refresh();
                        e.error("", "404", data);
                    }
                });
            },
        },

        schema:
            {
                model:
                    {
                        id: "MagazineId",
                        fields: {
                            MagazineId: { editable: false, nullable: true, type: "number" },
                            Name: { editable: true, nullable: true, type: "string" },
                            AuthorName: { editable: true, nullable: true, type: "string" },
                            YearOfPublishing: { editable: false, nullable: true, type: "number" },
                        }
                    }
            },
        batch: false,
        pageSize: 10

    });

    $("#magazines-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: {
            mode: "inline",
            confirmation: false
        },
        toolbar: [{
            template:
                '<a class="grid" href="Create">Add new Magazine</a>',

        }],

        columns: [
            {
                field: "Name",
                title: "Magazine",
                sortable: true
            },
            {
                field: "AuthorName",
                title: "Author",
                sortable: true
            },

            {
                field: "YearOfPublishing",
                title: "Year",
                sortable: true
            },

            {
                field: "MagazineId",
                title: "Actions", sortable: false,
                template:
                    '<a href="Edit/#= MagazineId #" >Edit</a>',
            },

            {
                command: ['destroy'], title: '&nbsp;'
            }

        ],
        height: "600px",
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
    }).data("kendoGrid");
});