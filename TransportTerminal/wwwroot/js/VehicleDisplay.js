

function displayBigVehicles() {
    var sendData = { type: "Bus" };
    $("#btnBigVehicle").click(function () {

        $.ajax({
            type: "GET",
            url: "/TransportTerminal/BigVehiclesPartial",
            data: sendData,

            success: function (data) {
                $("#bigVehicles").html(data);
            },
            error: function (data) {
                console.error("Ajax GET error", data);
            }
        });
    });
}
function displaySmallVehicles() {
    var sendData = { type: "Car" };
    $("#btnSmallVehicle").click(function () {

        $.ajax({
            type: "GET",
            url: "/TransportTerminal/SmallVehiclesPartial",
            data: sendData,

            success: function (data) {
                $("#smallVehicles").html(data);
            },
            error: function (data) {
                console.error("Ajax GET error", data);
            }
        });
    });
}