

var dataTable;

$(document).ready(function () {

});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/Product/GetAll"
        },
        "columns": [
            { "data": "productName", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "category.categoryName", "width": "15%" },
            { "data": "productDecription", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="/admin/Product/Upsert?id=${data}">
                         <i class="bi bi-pencil-square"></i> edit</a>
                        <a class="btn btn-danger" onClick=Delete('/admin/Product/Delete/${data}')> <i class=" bi bi-x-circle"></i> Delete</a>
                </div>
                    `
                },
                "width": "15%"
            },


        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }

                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}