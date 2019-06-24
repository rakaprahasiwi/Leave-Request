$(document).ready(function () {
    LoadIndexLeaveTypes ();
    $('#table').DataTable({
        "ajax": LoadIndexLeaveTypes()
    })
})

function Save() {
    var leave_type = new Object();
    leave_type.name = $('#Name').val();
    leave_type.value = $('#Value').val();
    $.ajax({
        url: "/LeaveTypess/InsertOrUpdate/",
        data: leave_type,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveTypess/Index/';
            });
            LoadIndexLeaveTypes();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexLeaveTypes() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/LeaveTypess/LoadLeaveTypes/", //shoot to controller client LeaveTypessController
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Value + '</td>';
                html += '<td>' + '<Button href = "#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')">Edit</button>';
                html += ' | <Button href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')">Button</Button></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}

function Edit() {
    var leave_type = new Object();
    leave_type.id = $('#Id').val();
    leave_type.name = $('#Name').val();
    leave_type.value = $('#Value').val();
    $.ajax({
        url: "/LeaveTypess/InsertOrUpdate/",
        data: leave_type,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveTypess/Index/';
            });
            LoadIndexLeaveTypes();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/LeaveTypess/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Value').val(result.Value);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "/LeaveTypess/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/LeaveTypess/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Name').val('');
    $('#Value').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Value').val() == 0 || $('#Value').val() == " " || $('#Value').val() == " ") {
        swal("Oops", "Expected Value", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}

