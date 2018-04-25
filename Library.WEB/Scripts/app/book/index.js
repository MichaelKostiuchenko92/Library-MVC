

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
        toolbar: [{
            template:
                '<a class="grid" href="Create">Add new Book</a>',
        }],

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
            },

            {
                field: "BookId",
                title: "Actions",
                sortable: false,
                template:
                    '<a href="Details/#= BookId #" >Details</a>',
            },

            {
                template:

                    '<a href="Edit/#= BookId #" >Edit</a>'
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






















//$(document).ready(function () {

//    dataSource = new kendo.data.DataSource({
//        transport: {
//            read:
//                {
//                    url: "book/getall",
//                    dataType: "json",
//                },
//        },

//        schema:
//            {
//                model:
//                    {
//                        id: "BookId",
//                        fields: {
//                            BookId: { editable: false, nullable: true, type: "number" },
//                            Name: { editable: true, nullable: true, type: "string" },
//                            AuthorName: { editable: true, nullable: true, type: "string" },
//                            YearOfPublishing: { editable: false, nullable: true, type: "number" },
//                        }
//                    }
//            }
//    });

//    $("#books-grid").kendoGrid({
//        dataSource: dataSource,
//        sortable: true,
//        editable: "inline",

//        toolbar: [{
//            template:
//                '<a href="Book/Create">Add new Book</a>',

//        }],

//        columns: [
//            {
//                field: "Name",
//                title: "Name",
//                sortable: true,
//            },

//            {
//                field: "AuthorName",
//                title: "Author",
//                sortable: true
//            },

//            {

//                field: "YearOfPublishing",
//                title: "Year",
//                sortable: true
//            },


//            {
//                field: "BookId",
//                title: "Actions", sortable: false,

//                template:
//                    '<a href="Book/Edit/#= BookId #" >Edit</a>',
//            },

//            {
//                template:
//                    '<a href="Book/Details/#= BookId #" >Details</a>'
//            }

//            {
//                template:
//                    '<a href="Book/Delete/#= BookId #" >Delete</a>'
//            }
//        ],

//        height: "500px",
//        pageable: {
//            refresh: true,
//            pageSizes: true,
//            buttonCount: 5
//        },
//    }).data("kendoGrid");


//});