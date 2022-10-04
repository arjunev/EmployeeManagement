$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
});

function bindEvents()
{
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h1>${result.name}</h1>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard);
                showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $("#createform").submit(function (event) {
        var employee = {};
        employee.Name = $("#name").val();
        employee.Department = $("#dept").val();
        employee.Age = Number($("#age").val());
        employee.Address = $("#address").val();
        var data = JSON.stringify(employee);
        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/insert',
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload(true);
            },
            error: function (error) {
                console.log(error);
            },
        });
    });

    $("#updateform").submit(function (event) {
        console.log("clicked");
        var employee = {};
        employee.Id = Number($("#empId").val());
        employee.Name = $("#empName").val();
        employee.Department = $("#empDept").val();
        employee.Age = Number($("#empAge").val());
        employee.Address = $("#empAddress").val();
        var data = JSON.stringify(employee);
        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/update',
            type: 'PUT',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: data,
            success: function (result) {
                location.reload(true);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });



    $(".employeeDelete").on("click", function (event)

    {
        var employeeId = event.currentTarget.getAttribute("data-id");

        var result = confirm("OK or cancel?");
        if (result)
        {
            alert("Successfully deleted the data");
            $.ajax({
                url: 'https://localhost:44383/api/internal/employee/' + employeeId,
                type: 'DELETE',
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                     location.reload();
                    $("#EmployeeCard").html(newEmployeeCard);
                    showEmployeeDeleteCard();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
        else
        {
           alert("Deletion Canceled");
        }


    });
}
 
function hideEmployeeDetailCard() {
    $("#EmployeeCard").hide();
}

function showEmployeeDetailCard() {
    $("#EmployeeCard").show();
}
function showEmployeeDeleteCard() {
    $("#EmployeeCard").show();
}