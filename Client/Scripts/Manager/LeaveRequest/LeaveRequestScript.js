$(document).ready(function () {
    LoadIndexLeaveRequest();
    $('#tableLeaveRequest').DataTable({
        "ajax": LoadIndexLeaveRequest()
    })
})

function Save() {
    var leave_request = new Object();
    leave_request.employee_Id = $('1').val();
    leave_request.manager_Id = $('2').val();
    leave_request.LeaveTypes_Id = $('#Leave_Type').val();
    leave_request.reason = $('#Reason').val();
    leave_request.requestDate = $('#Request_Date').val();
    leave_request.fromDate = $('#From_Date').val();
    leave_request.endDate = $('#End_Date').val();
    leave_request.attachment = $('file').val();
    leave_request.status = $('Submitted').val();
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
            LoadIndexLeaveRequest();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexLeaveRequest() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/LeaveRequests/LoadLeaveRequest/", //shoot to controller client LeaveTypessController
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Employee_Id + '</td>';
                html += '<td>' + val.Manager_Id + '</td>';
                html += '<td>' + val.LeaveType.Name + '</td>';
                html += '<td>' + val.Reason + '</td>';
                html += '<td>' + moment(val.Request_Date).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + moment(val.From_Date).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + moment(val.End_Date).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + val.Attachment + '</td>';
                html += '<td>' + val.Status + '</td>';
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
    var leave_request = new Object();
    leave_request.id = $('#Id').val();
    leave_request.employee_Id = $('#Employee_Id').val();
    leave_request.manager_Id = $('#Manager_Id').val();
    leave_request.LeaveTypes_Id = $('#LeaveTypes').val();
    leave_request.reason = $('#Reason').val();
    leave_request.requestDate = $('#Request_Date').val();
    leave_request.fromDate = $('#From_Date').val();
    leave_request.endDate = $('#End_Date').val();
    leave_request.attachment = $('#Attachment').val();
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
            LoadIndexLeaveRequest();
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
            $('#LeaveTypes').val(result.LeaveTypes.Name);
            $('#Reason').val(result.Reason);
            $('#Request_Date').val(moment(val.Request_Date).format("MM/DD/YYYY"));
            $('#From_Date').val(moment(val.From_Date).format("MM/DD/YYYY"));
            $('#End_Date').val(moment(val.End_Date).format("MM/DD/YYYY"));
            $('#Attachment').val(result.Attachment);
            $('#Status').val(result.Status);

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
    $('#Id').val('');
    $('#Leave_Type').val('');
    $('#Reason').val('');
    $('#From_Date').val('');
    $('#End_Date').val('');
    $('#Update').hide();
    $('#Save').show();
}

var LeaveTypes = []
function LoadLeaveTypes(element) {
    if (LeaveTypes.length == 0) {
        $.ajax({
            type: "GET",
            url: "/LeaveTypes/LoadLeaveTypes/",
            success: function (data) {
                LeaveTypes = data;
                renderType(element);
            }
        })
    }
    else {
        renderType(element);
    }
}

function renderType(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Type'));
    $.each(LeaveTypes, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadLeaveTypes($('#Leave_Type'));
$('#Update').hide();
$('#Save').show();
ClearScreen();


function Validate() {
    if ($('#Id').val() == " ")
    {
        Save();
    }
    else
    {
        Edit();
    }
}