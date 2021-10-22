$(document).ready(function () {

    $("#deleteVehicle").click(function () {
        DeleteVehicle("#thisVehicle");
    });
    $("#deleteSpecial").click(function () {
        DeleteSpecial("#thisSpecial");
    });
});

function DeleteVehicle(vehicleId) {
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44380/AdminController/vehicle/" + vehicleId,
        success: function (data, status, xhr) {
            document.location = './home.html';
        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });

}
function DeleteSpecial(specialId) {
    $.ajax({
        type: "DELETE",
        url: "https://localhost:44380/AdminController/special/" + specialId,
        success: function (data, status, xhr) {
            document.location = './home.html';
        },
        error: function (jqXHR, ajaxOptions, thrownError) {
            alert("Status: " + ajaxOptions); alert("Error: " + thrownError);
        }
    });
}
