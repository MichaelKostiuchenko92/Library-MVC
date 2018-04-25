
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
                    url: '/Brochure/Delete/' + e.data.BrochureId,
                    dataType: 'number',
                    success: function (data) {
                        $('#brochures-grid').data('kendoGrid').dataSource.read();
                        $('#brochures-grid').data('kendoGrid').refresh();
                        e.success(data);
                    },
                    error: function (data) {
                        $('#brochures-grid').data('kendoGrid').dataSource.read();
                        $('#brochures-grid').data('kendoGrid').refresh();
                        e.error("", "404", data);
                    }
                });
            },
        },

        schema:
            {
                model:
                    {
                        id: "BrochureId",
                        fields: {
                            BrochureId: { editable: false, nullable: true, type: "number" },
                            Name: { editable: true, nullable: true, type: "string" },
                            TypeOfCover: { editable: true, nullable: true, type: "string" },
                            NumberOfPages: { editable: false, nullable: true, type: "number" },
                        }
                    }
            },
        batch: false,
        pageSize: 10

    });

    $("#brochures-grid").kendoGrid({
        dataSource: dataSource,
        sortable: true,
        editable: {
            mode: "inline",
            confirmation: false
        },
        toolbar: [{
            template:
                '<a class="grid" href="Create">Add new Brochure</a>',
        }],

        columns: [
            {
                field: "Name",
                title: "Brochure",
                sortable: true
            },
            {
                field: "TypeOfCover",
                title: "Cover",
                sortable: true
            },

            {
                field: "NumberOfPages",
                title: "Pages",
                sortable: true
            },

            {
                field: "BrochureId",
                title: "Actions", sortable: false,
                template:
                    '<a href="Edit/#= BrochureId #" >Edit</a>',
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



