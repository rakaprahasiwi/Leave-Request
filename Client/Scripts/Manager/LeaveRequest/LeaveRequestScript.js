$(document).ready(function () {
    LoadIndexLeaveRequest();
    $('#tableLeaveRequest').DataTable({
        "ajax": LoadIndexLeaveRequest()
    })
})

function Save() {
    var leave_request = new Object();
    leave_request.employee_Id = $('#Employee_Id').val();
    leave_request.manager_Id = $('#Manager_Id').val();
    leave_request.LeaveTypes_Id = $('#LeaveTypes_Id').val();
    leave_request.reason = $('#Reason').val();
    leave_request.requestDate = $('#Request_Date').val();
    leave_request.fromDate = $('#From_Date').val();
    leave_request.endDate = $('#End_Date').val();
    leave_request.attachment = $('#Attachment').val();
    leave_request.StatusTypeParameter_Id = $('#StatusTypeParameter_Id').val();
    $.ajax({
        url: "/LeaveRequests/InsertOrUpdate/",
        data: leave_request,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveRequests/Index/';
            });
            LoadIndexLeaveTypes();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexLeaveRequest() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/LeaveRequests/LeaveRequest/", //shoot to controller client LeaveTypessController
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Employee_Id + '</td>';
                html += '<td>' + val.Manager_Id + '</td>';
                html += '<td>' + val.LeaveTypes.Name + '</td>';
                html += '<td>' + val.Reason + '</td>';
                html += '<td>' + moment(val.Request_Date).format("MMM Do YY") + '</td>';
                html += '<td>' + moment(val.From_Date).format("MMM Do YY") + '</td>';
                html += '<td>' + moment(val.End_Date).format("MMM Do YY") + '</td>';
                html += '<td>' + val.Attachment + '</td>';
                html += '<td>' + val.StatusTypeParameter.Name + '</td>';
                html += '<td>' + '<a href = "#" class="fa da-pencil" onclick= return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}

function Edit() {
    var leave_request = new Object();
    leave_request.id = $('#Id').val();
    leave_request.employee_Id = $('#Employee_Id').val();
    leave_request.manager_Id = $('#Manager_Id').val();
    leave_request.LeaveTypes_Id = $('#LeaveTypes_Id').val();
    leave_request.reason = $('#Reason').val();
    leave_request.requestDate = $('#Request_Date').val();
    leave_request.fromDate = $('#From_Date').val();
    leave_request.endDate = $('#End_Date').val();
    leave_request.attachment = $('#Attachment').val();
    leave_request.StatusTypeParameter_Id = $('#StatusTypeParameter_Id').val();
    $.ajax({
        url: "/LeaveRequests/InsertOrUpdate/",
        data: leave_request,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveRequests/Index/';
            });
            LoadIndexLeaveTypes();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/LeaveRequests/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Employee_Id').val(result.Employee_Id);
            $('#Manager_Id').val(result.Manager_Id);
            $('#LeaveTypes_Id').val(result.LeaveTypes.Name);
            $('#Reason').val(result.Reason);
            $('#Request_Date').val(moment(result.Request_Date).format("MMM Do YY"));
            $('#From_Date').val(moment(result.From_Date).format("MMM Do YY"));
            $('#End_Date').val(moment(result.End_Date).format("MMM Do YY"));
            $('#Attachment').val(result.Attachment);
            $('#StatusTypeParameter_Id').val(result.StatusTypeParameter.Name);

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
            url: "/LeaveRequests/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/LeaveRequests/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Employee_Id').val('');
    $('#Manager_Id').val('');
    $('#Id').val('');
    $('#LeaveTypes_Id').val('');
    $('#Reason').val('');
    $('#Request_Date').val('');
    $('#From_Date').val('');
    $('#End_Date').val('');
    $('#Attachment').val('');
    $('#StatusTypeParameter_Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Employee_Id').val() == 0 || $('#Employee_Id').val() == "" || $('#Employee_Id').val() == " ") {
        swal("Oops", "Please Insert ID Employee", "error")
    } else if ($('#Manager_Id').val() == 0 || $('#Manager_Id').val() == " " || $('#Manager_Id').val() == " ") {
        swal("Oops", "Expected Manager ID", "error")
    } else if ($('#LeaveTypes_Id').val() == "" || $('#LeaveTypes_Id').val() == " ") {
        swal("Oops", "Expected Leave Type ID", "error")
    }
    else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}