
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
                    url: '/Book/Delete/' + e.data.BookId,
                    dataType: 'number',
                    success: function (data) {
                        $('#books-grid').data('kendoGrid').dataSource.read();
                        $('#books-grid').data('kendoGrid').refresh();
                        e.success(data);
                    },
                    error: function (data) {
                        $('#books-grid').data('kendoGrid').dataSource.read();
                        $('#books-grid').data('kendoGrid').refresh();
                        e.error("", "404", data);
                    }
                });
            },
        },

        schema:
            {
                model:
                    {
                        id: "BookId",
                        fields: {
                            BookId: { editable: false, nullable: true, type: "number" },
                            Name: { editable: true, nullable: true, type: "string" },
                            AuthorName: { editable: true, nullable: true, type: "string" },
                            YearOfPublishing: { editable: false, nullable: true, type: "number" },
                        }
                    }
            },
        batch: false,
        pageSize: 10

    });

    $("#books-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: {
            mode: "inline",
            confirmation: false
        },

        columns: [
            {
                field: "Name",
                title: "Name",
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
