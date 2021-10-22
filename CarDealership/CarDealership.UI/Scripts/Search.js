$(document).ready(function () {


    $("#NewSearch").click(function (e) {
        e.preventDefault();
        GetNewSearchResults();

    });
    $("#UsedSearch").click(function (e) {
        e.preventDefault();
        GetUsedSearchResults();

    });
    $("#SalesSearch").click(function (e) {
        e.preventDefault();
        SalesSearchResults();
    });
    $("#VehiclesSearch").click(function (e) {
        e.preventDefault();
        VehiclesSearchResults();
    });
    $("#SalesReportSearch").click(function (e) {
        e.preventDefault();
        SalesReportResults();
    });
});

function GetNewSearchResults() {
    $("#NewVehiclesContainer").empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44380/newSearch" + "?searchString=" + $("#searchString").val() + "&minPrice=" + $("#minPrice").val() + "&maxPrice=" + $("#maxPrice").val() + "&minYear=" + $("#minYear").val() + "&maxYear=" + $("#maxYear").val(),
        dataType: 'json',
        success: function (itemArray) {
            var vehicleDiv = $("#NewVehiclesContainer");
            $.each(itemArray, function (index, vehicle) {
                var url = vehicle.ImgUrl;
                var v = `<div class="container-fluid" style="border:solid 5px; padding: 20px; margin-bottom: 10px">
                         <div class="row">
                             <div class="col-xs-8 col-sm-8 col-md-5 col-lg-4 year-make-model">
                                 <b>${vehicle.Year}
                                 ${vehicle.Make.MakeName}
                                 ${vehicle.Model.ModelName}</b>
                             </div>
                             
                         </div>
                         <div class="row container4rowsNimage">
                             <div class=" col-2 image" style="display:inline">
                                 <h5>
                                     <img class="carPic" style="width:100px; height:100px" src=${url} alt="Vehicle Picture Not Available"/>
                                 </h5>
                             </div>
                             <div class="col-10 container4rows" style="padding-top: 16px">
                                 <div class="row" style="justify-content:center">
                                     <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                         <h7>
                                             <b>Body Style: </b>
                                             ${bodyStyles[vehicle.BodyStyle - 1]}
                                         </h7>
                                     </div>
                                     <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" ">
                                         <h7 style="margin-left: 6%">
                                             <b>Interior: </b>
                                             ${interior[vehicle.Interior - 1]}
                                         </h7>
                                     </div>
                                     <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                         <h7 style="margin-left: 44%">
                                             <b>Sales Price: </b>
                                             $${vehicle.SalesPrice}
                                         </h7>
                                     </div>
                                 </div>
                                 <div class="row" style="justify-content:center">
                                     <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                         <h7 style="margin-left: 20%">
                                             <b>Trans: </b>
                                             ${transmission[vehicle.Transmission - 1]}
                                         </h7>
                                     </div>
                                     <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                         <h7 style="margin-left: 5%">
                                             <b>Mileage: </b>
                                             ${vehicle.Mileage}
                                         </h7>
                                     </div>
                                     <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                         <h7 style="margin-left: 57%">
                                             <b>MSRP: </b>
                                             $${vehicle.MSRP}
                                         </h7>
                                     </div>
                                 </div>
                                 <div class="row" style="justify-content:center">
                                     <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                                         <h7 style="margin-left: 29%">
                                             <b>Color: </b>
                                             ${color[vehicle.Color - 1]}
                                         </h7>
                                     </div>
                                     <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-left: 37px">
                                         <h7 style="margin-left: 5%">
                                             <b>VIN #: </b>
                                             ${vehicle.VIN}
                                         </h7>
                                     </div>
                                     <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                         <h7 style="margin-left: 69%">
                                             <a class="btn btn-primary btn-sm" href="Details/${vehicle.VehicleId}" role="button">Details</a>
                                         </h7>
                                                 </div>
                                             </div>
                                         </div>
                                     </div>`
                                     vehicleDiv.append(v);
                                 });
                            
                             },
                             error: function (jqXHR, ajaxOptions, thrownError) {
                                 alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
                             }
    });

}

function GetUsedSearchResults() {
    $("#UsedVehiclesContainer").empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44380/usedSearch" + "?searchString=" + $("#searchString").val() + "&minPrice=" + $("#minPrice").val() + "&maxPrice=" + $("#maxPrice").val() + "&minYear=" + $("#minYear").val() + "&maxYear=" + $("#maxYear").val(),
        dataType: 'json',
        success: function (itemArray) {
            var vehicleDiv = $("#UsedVehiclesContainer");
            $.each(itemArray, function (index, vehicle) {
                var url = vehicle.ImgUrl;
                var v = `<div class="container-fluid" style="border:solid 5px; padding: 20px; margin-bottom: 10px">
    <div class="row">
        <div class="col-xs-8 col-sm-8 col-md-5 col-lg-4 year-make-model">
            <b>${vehicle.Year}
            ${vehicle.Make.MakeName}
            ${vehicle.Model.ModelName}</b>
        </div>
        
    </div>
    <div class="row container4rowsNimage">
        <div class=" col-2 image" style="display:inline">
            <h5>
                <img class="carPic" style="width:100px; height:100px" src=${url} alt="Vehicle Picture Not Available"/>
            </h5>
        </div>
        <div class="col-10 container4rows" style="padding-top: 16px">
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7>
                        <b>Body Style: </b>
                        ${bodyStyles[vehicle.BodyStyle - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" ">
                    <h7 style="margin-left: 6%">
                        <b>Interior: </b>
                        ${interior[vehicle.Interior - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 44%">
                        <b>Sales Price: </b>
                        $${vehicle.SalesPrice}
                    </h7>
                </div>
            </div>
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7 style="margin-left: 20%">
                        <b>Trans: </b>
                        ${transmission[vehicle.Transmission - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 5%">
                        <b>Mileage: </b>
                        ${vehicle.Mileage}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 57%">
                        <b>MSRP: </b>
                        $${vehicle.MSRP}
                    </h7>
                </div>
            </div>
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7 style="margin-left: 29%">
                        <b>Color: </b>
                        ${color[vehicle.Color - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-left: 37px">
                    <h7 style="margin-left: 5%">
                        <b>VIN #: </b>
                        ${vehicle.VIN}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 69%">
                        <a class="btn btn-primary btn-sm" href="Details/${vehicle.VehicleId}" role="button">Details</a>
                    </h7>
                </div>
            </div>
        </div>
    

    </div>`
                vehicleDiv.append(v);
            });

        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });

}

function VehicleDetails() {
    $("#NewVehiclesContainer").empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44380/Inventory/Details/VehicleId",
        success: function (itemArray) {
            var vehicleDiv = $("#NewVehiclesContainer");
            $.each(itemArray, function (index, vehicle) {
                //move to Inventory/Details/VehicleId

            });
            vehicleDiv.append();
        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });
}

function SalesSearchResults() {
    $("#SalesSearchContainer").empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44380/salesSearch" + "?searchString=" + $("#searchString").val() + "&minPrice=" + $("#minPrice").val() + "&maxPrice=" + $("#maxPrice").val() + "&minYear=" + $("#minYear").val() + "&maxYear=" + $("#maxYear").val(),
        dataType: 'json',
        success: function (itemArray) {
            var vehicleDiv = $("#SalesSearchContainer");
            $.each(itemArray, function (index, sale) {
                var url = sale.Vehicle.ImgUrl;
                var v = `<div class="container-fluid" style="border:solid 5px; padding: 20px; margin-bottom: 10px">
    <div class="row">
        <div class="col-xs-8 col-sm-8 col-md-5 col-lg-4 year-make-model">
            <b>${sale.Vehicle.Year}
            ${sale.Vehicle.Make.MakeName}
            ${sale.Vehicle.Model.ModelName}</b>
        </div>
        
    </div>
    <div class="row container4rowsNimage">
        <div class=" col-2 image" style="display:inline">
            <h5>
                <img class="carPic" style="width:100px; height:100px" src=${url} alt="Vehicle Picture Not Available"/>
            </h5>
        </div>
        <div class="col-10 container4rows">
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7>
                        <b>Body Style: </b>
                        ${bodyStyles[sale.Vehicle.BodyStyle - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 6%">
                        <b>Interior: </b>
                        ${interior[sale.Vehicle.Interior - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 31%">
                        <b>Sales Price: </b>
                        $${sale.Vehicle.SalesPrice}
                    </h7>
                </div>
            </div>
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7 style="margin-left: 24%">
                        <b>Trans: </b>
                        ${transmission[sale.Vehicle.Transmission - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                     <h7 style="margin-left: 5%">
                        <b>Mileage: </b>
                        ${sale.Vehicle.Mileage}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 46%">
                        <b>MSRP: </b>
                        $${sale.Vehicle.MSRP}
                    </h7>
                </div>
            </div>
            <div class="row" style="justify-content:center">              
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7 style="margin-left: 24%">
                        <b>Color: </b>
                        ${color[sale.Vehicle.Color - 1]}
                    </h7>
                </div>
                <div class="col-xs-5 col-sm-5 col-md-5 col-lg-5">
                    <h7 style="margin-left: 10%">
                        <b>VIN #: </b>
                        ${sale.Vehicle.VIN}
                    </h7>
                </div>
                        <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                            <h7>
                                <button type="button" class="btn btn-primary btn-sm btn-block" style="max-width: 50%; justify-content:right; margin-left: 67%" onclick="window.location.href ='/Sales/Purchase/${sale.Vehicle.VehicleId}'">Purchase</button>
                            </h7>
                        </div>
                    </div>
                    </div>
                </div>
                <br />`
                vehicleDiv.append(v);
            });
        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });
}

function SalesReportResults() {
    $("#SalesReportContainer").empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44380/salesReportSearch" + "?User=" + $("#User").val() + "&StartDate=" + $("#StartDate").val() + "&EndDate=" + $("#Endate").val(),
        dataType: 'json',
        success: function (itemArray) {
            var reportDiv = $("#SalesReportContainer");
            var v = `<table class="table table-striped" style="border: solid 2px; padding: 20px">
                    <thead>
                    <tr>
                        <th scope="col">User</th>
                        <th scope="col">Total Sales</th>
                        <th scope="col">Total Vehicles</th>
                    </tr>
                    </thead>
                    <tbody>
                        `;
            $.each(itemArray, function (index, sale) {                
                      v +=   `<tr>
                            <td>${sale.User}</td>
                            <td>${sale.TotalSales}</td>
                            <td>${sale.TotalVehicles}</td>
                            </tr>`     
            });
            v += `</tbody>
             </table>`;
            reportDiv.append(v);
        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });
}

function VehiclesSearchResults() {
    $("#VehiclesSearchContainer").empty();
    $.ajax({
        type: "GET",
        url: "https://localhost:44380/vehiclesSearch" + "?searchString=" + $("#searchString").val() + "&minPrice=" + $("#minPrice").val() + "&maxPrice=" + $("#maxPrice").val() + "&minYear=" + $("#minYear").val() + "&maxYear=" + $("#maxYear").val(),
        dataType: 'json',
        success: function (itemArray) {
            var vehicleDiv = $("#VehiclesSearchContainer");
            $.each(itemArray, function (index, vehicle) {
                var url = vehicle.ImgUrl;
                var v = `<div class="container-fluid" style="border:solid 5px; padding: 20px; margin-bottom: 10px">
    <div class="row">
        <div class="col-xs-8 col-sm-8 col-md-5 col-lg-4 year-make-model">
            <b>${vehicle.Year}
            ${vehicle.Make.MakeName}
            ${vehicle.Model.ModelName}</b>
        </div>
        
    </div>
    <div class="row container4rowsNimage">
        <div class=" col-2 image" style="display:inline">
            <h5>
                <img class="carPic" style="width:100px; height:100px" src=${url} alt="Vehicle Picture Not Available"/>
            </h5>
        </div>
        <div class="col-10 container4rows" style="padding-top: 16px">
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7>
                        <b>Body Style: </b>
                        ${bodyStyles[vehicle.BodyStyle - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" ">
                    <h7 style="margin-left: 6%">
                        <b>Interior: </b>
                        ${interior[vehicle.Interior - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 44%">
                        <b>Sales Price: </b>
                        $${vehicle.SalesPrice}
                    </h7>
                </div>
            </div>
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7 style="margin-left: 20%">
                        <b>Trans: </b>
                        ${transmission[vehicle.Transmission - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 5%">
                        <b>Mileage: </b>
                        ${vehicle.Mileage}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                    <h7 style="margin-left: 57%">
                        <b>MSRP: </b>
                        $${vehicle.MSRP}
                    </h7>
                </div>
            </div>
            <div class="row" style="justify-content:center">
                <div class="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <h7 style="margin-left: 29%">
                        <b>Color: </b>
                        ${color[vehicle.Color - 1]}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4" style="margin-left: 37px">
                    <h7 style="margin-left: 5%">
                        <b>VIN #: </b>
                        ${vehicle.VIN}
                    </h7>
                </div>
                <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                             <h7 style="margin-left: 69%">
                                <a class="btn btn-primary btn-md" href="EditVehicle/${vehicle.VehicleId}" role="button">Edit</a>
                            </h7>
                        </div>
                    </div>
                    
                </div>`
                vehicleDiv.append(v);
            });

        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });
}