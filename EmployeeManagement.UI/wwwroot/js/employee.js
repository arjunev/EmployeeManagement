﻿$(document).ready(function () {
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
                    /*                var newEmployeeCard = `<div class="card">
                                                              <h1>${result.Name}</h1>
                                                             <b>Id :</b> <p>${result.Id}</p>
                                                             <b>Department:</b><p>${result.Department}</p>
                                                             <b>Age:</b><p>${result.Age}</p>
                                                             <b>Address:</b><p>${result.Address}</p>
                                                            </div>`*/

                    location.reload();
                    /*                alert("haii please delete me");*/

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