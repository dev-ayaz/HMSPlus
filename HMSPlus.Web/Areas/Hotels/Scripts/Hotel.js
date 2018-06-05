
var Hotel = {

    selectors: {
        HotelTable: "#HotelsTable",
        EditButton: ".btnEdit",
        AddHotelForm: "#HotelForm",
        modalEditHotel: "#modalEditHotel",
        DivEditHotel: "#DivEditHotel"
    },

    services: {

        controller: "Hotel",
        actions: {
            List: "HotelsList",
            Edit: "Edit"

        }

    },

    Callbacks: {

        InsertSuccess: function (response) {
            AppAlerts.actionAlert(response);

            if (!response.IsError) {

                IAC.Utilities.resetForm(Hotel.selectors.AddHotelForm);
                $(Hotel.selectors.HotelTable).DataTable().draw();
            }
        },
        UpdateSuccess: function (response) {

            AppAlerts.actionAlert(response);

            if (!response.IsError) {

                $(Hotel.selectors.modalEditHotel).modal("hide");

                $(Hotel.selectors.HotelTable).DataTable().draw();

                Hotel.InitEvents();


            }
        },
        EditHotel: function ($this) {

            var HotelId = $this.attr("data-id");

            var utilities = IAC.Utilities;

            var url = [utilities.getSiteRoot(), Hotel.services.controller, "/", Hotel.services.actions.Edit].join("");

            utilities.postToController(url, utilities.formMethods.Get, { id: HotelId }, function (request) {

                $(Hotel.selectors.DivEditHotel).html(request);

                $(Hotel.selectors.modalEditHotel).modal("show");

                Hotel.InitEvents();
            });
        }

    },

    InitEvents: function () {


        $(Hotel.selectors.ResetRequestFormButton + ":not(.bound)").addClass("bound").click(function () {

            IAC.Utilities.resetForm($(Hotel.selectors.AddHotelForm));
        });

        $(Hotel.selectors.EditButton + ":not(.bound)").addClass("bound").click(function () {

            Hotel.Callbacks.EditHotel($(this));
        });

    },
    domConfigurations: {



        initTable: function () {
            var utilities = IAC.Utilities;
            var listUrl = [utilities.getSiteRoot(), Hotel.services.controller, "/", Hotel.services.actions.List].join("");


            var actions = [

                {
                    actionName: " Edit",
                    icon: "fa fa-pencil",
                    classes: "btnEdit",
                    dataAttr: ["Id"]

                }
                ,
                {
                    actionName: "Delete",
                    icon: "fa fa fa-times",
                    classes: "btnDelete",
                    dataAttr: ["Id"]

                }
            ];

            var dataTable = $(Hotel.selectors.HotelTable).dataTable({
                "bServerSide": true,
                "ajax": {
                    "url": listUrl,
                    "data": function (data) {
                        var params = IACdataTable.setDataTableFilters(data);
                        return params;
                    }
                },
                "bProcessing": false,
                "filter": true, //set to false to Disable filter (search box)
                "initComplete": function (settings, json) {
                    $(Hotel.selectors.HotelTable + "_filter input").unbind();
                    $(Hotel.selectors.HotelTable + "_filter input").bind("keyup", function (e) {
                        if (e.keyCode === 13) {
                            dataTable.fnFilter(this.value);
                        }
                    });

                },
                "drawCallback": function (settings) {
                    Hotel.InitEvents();
                },
                "columns": [
                    {
                        mRender: function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;

                        },
                        "sortable": false, "autoWidth": false
                    },

                    { data: "Name", "sortable": true },
                    { data: "HotelType", "sortable": true },
                    { data: "NumberOfRooms", "sortable": true },
                    { data: "Address", "sortable": true },
                    { data: "IsActive", name: "IsActive" },
                    {
                        mRender: function (data, type, row) { return IACdataTable.htmlWrapers.ActionMenu.replace("{li}", IACdataTable.createActionLink(actions, row)); },
                        "sortable": false, "autoWidth": false
                    }
                ],
                "aaSorting": [0, "asc"]
            });

        }
    }
}