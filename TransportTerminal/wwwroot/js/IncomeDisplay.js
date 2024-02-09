function displayEmployeeIncome() {
    $("#btnFinish").click(function () {

        $.ajax({
            type: "GET",
            url: "/TransportTerminal/EmployeeIncomePartial",
            success: function (data) {
                $("#employeeIncome").html(data);
                console.log(data);

            },
            error: function (data) {
                console.error("Ajax GET error", data);
            }
        });
    });
}
function displayTotalIncome() {
    $("#btnFinish").click(function () {

        $.ajax({
            type: "GET",
            url: "/TransportTerminal/TotalIncomePartial",
            success: function (data) {
                $("#totalIncome").html(data);
            },
            error: function (data) {
                console.error("Ajax GET error", data);
            }
        });
    });
}
function deleteAll() {
    $("#btnDeleteAll").click(function () {

        $.ajax({
            type: "GET",
            url: "/TransportTerminal/DeleteVehicles",
            success: function (data) {
                $("#totalIncome").empty();
                $("#employeeIncome").empty();
                $("#smallVehicles").empty();
                $("#bigVehicles").empty();
            },
            error: function (data) {
                console.error("Ajax GET error", data);
            }
        });
    });
}