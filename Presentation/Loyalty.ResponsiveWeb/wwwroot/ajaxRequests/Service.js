
function getCustomers() {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:53055/api/Customer/GetCustomers',
        contentType: "application/json; char=utf-8",
        dataType: "json",
        success: function (result) {
            result.data.forEach(function (key, value) {
                $("#customerTable").append(`
                    <tr>
                        <td>1.</td>
                        <td>`+ key.firstname + `</td>
                        <td>
                            <div class="progress progress-xs">
                                <div class="progress-bar progress-bar-danger" style="width: `+ key.point + `%"></div>
                            </div>
                        </td>
                        <td><span class="badge bg-danger">`+ key.point + `%</span ></td>
                        <td><span class="btn btn-success" data-toggle="modal" data-target="#EditModal" onclick="getEditCustomer('`+ key.id + `')">Edit</span></td>
                    </tr>
                `);
            })
        }
    })
}

function getEditCustomer(customerId) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:53055/api/Customer/GetCustomerById/' + customerId,
        contentType: "application/json; char=utf-8",
        dataType: "json",
        success: function (result) {
            document.getElementById("CustomerId").value = result.data.id;
            document.getElementById("CustomerFirstName").value = result.data.firstname;
            document.getElementById("CustomerSurName").value = result.data.surname;
            document.getElementById("Threshold").value = result.data.point;
            document.getElementById("Email").value = result.data.email;
        }
    })
}

function saveCustomer() {
    var list = {};
    list.Id = document.getElementById("CustomerId").value;
    list.Firstname = document.getElementById("CustomerFirstName").value;
    list.Surname = document.getElementById("CustomerSurName").value;
    list.Point = parseInt(document.getElementById("Threshold").value);
    list.Email = document.getElementById("Email").value;

    $.ajax({
        type: 'POST',
        url: 'http://localhost:53055/api/Customer/UpdateCustomer',
        data: JSON.stringify(list),
        contentType: "application/json; char=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
        }
    })

}