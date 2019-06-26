$(document).ready(function () {
    LoadIndexLeaveType();
    $('#tableLeaveType').DataTable({
        "ajax": LoadIndexLeaveType()
    })
})

function Save() {
    var leave_type = new Object();
    leave_type.name = $('#Name').val();
    leave_type.duration = $('#Duration').val();
    leave_type.note = $('#Note').val();
    $.ajax({
        url: "/LeaveTypes/InsertOrUpdate/",
        data: leave_type,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveTypes/Index/';
            });
            LoadIndexLeaveType();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexLeaveType() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/LeaveTypes/LoadLeaveType/", //shoot to controller client LeaveTypessController
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Duration + '</td>';
                html += '<td>' + val.Note + '</td>';
                html += '<td>' + '<Button href = "#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i></button>';
                html += ' <Button href="#" class="btn btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i></Button></td>';
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
    leave_type.duration = $('#Duration').val();
    leave_type.note = $('#Note').val();
    $.ajax({
        url: "/LeaveTypes/InsertOrUpdate/",
        data: leave_type,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveTypes/Index/';
            });
            LoadIndexLeaveTypes();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/LeaveTypes/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Duration').val(result.Duration);
            $('#Note').val(result.Note);

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
            url: "/LeaveTypes/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/LeaveTypes/Index/';
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
    $('#Duration').val('');
    $('#Note').val('Choose');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Duration').val() < 1 || $('#Duration').val() >100) {
        swal("Oops", "Expected Value", "error")
    }else if ($('#Duration').val() == "" || $('#Duration').val() == " ") {
        swal("Oops", "Expected Value", "error")
    } else if ($('#Note').val() == "Choose") {
        swal("Oops", "Expected Note", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}

