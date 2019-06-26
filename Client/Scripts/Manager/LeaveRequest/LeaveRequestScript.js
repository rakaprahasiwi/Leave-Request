$(document).ready(function () {
    LoadIndexLeaveRequest();
    $('#tableLeaveRequest').DataTable({
        "ajax": LoadIndexLeaveRequest()
    })
    ClearScreen();
})

function Save() {
    var leave_request = new Object();
    leave_request.employee_id = $('#Employee_Id').val();
    leave_request.manager_id = $('#Manager_Id').val();
    leave_request.LeaveType_Id = $('#LeaveType_Id').val();
    leave_request.reason = $('#Reason').val();
    leave_request.request_date = $('#Request_Date').val();
    leave_request.from_date = $('#From_Date').val();
    leave_request.end_date = $('#End_Date').val();
    leave_request.attachment = $('#Attachment').val();
    leave_request.status = $('#Status').val('Submited');
    console.log(leave_request);
    $.ajax({
        url: "/LeaveRequests/InsertOrUpdate/",
        type: 'POST',
        dataType: 'json',
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
        },
        error: function () {
            $('#Update').hide();
            $('#Save').show();
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
                $.ajax({
                    url: "/leaveTypes/GetById/",
                    data: { id: val.LeaveType_Id },
                    success: function (result) {
                        html += '<tr>';
                        html += '<td>' + i + '</td>';
                        html += '<td>' + val.Employee_Id + '</td>';
                        html += '<td>' + val.Manager_Id + '</td>';
                        html += '<td>' + result.Name + '</td>';
                        html += '<td>' + val.Reason + '</td>';
                        html += '<td>' + moment(val.Request_Date).format("MM/DD/YYYY") + '</td>';
                        html += '<td>' + moment(val.From_Date).format("MM/DD/YYYY") + '</td>';
                        html += '<td>' + moment(val.End_Date).format("MM/DD/YYYY") + '</td>';
                        html += '<td>' + val.Attachment + '</td>';
                        html += '<td>' + val.Status + '</td>';
                        html += '<td>' + '<Button href = "#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i></Button>';
                        html += ' <Button href="#" class="btn btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i></Button></td>';
                        html += '</tr>';
                        i++;
                        $('.tbody').html(html);
                    }
                });;
            });
        }
    });
}

function Edit() {
    var leave_request = new Object();
    leave_request.id = $('#Id').val();
    leave_request.employee_id = $('#Employee_Id').val();
    leave_request.manager_id = $('#Manager_Id').val();
    leave_request.LeaveType_Id = $('#LeaveType_Id').val();
    leave_request.reason = $('#Reason').val();
    leave_request.request_date = $('#Request_Date').val();
    leave_request.from_date = $('#From_Date').val();
    leave_request.end_date = $('#End_Date').val();
    leave_request.attachment = $('#Attachment').val();
    leave_request.status = $('#Status').val();
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
            $('#LeaveType_Id').val(result.LeaveType_Id);
            $('#Reason').val(result.Reason);
            $('#Request_Date').val(moment(result.Request_Date).format("MM/DD/YYYY"));
            $('#From_Date').val(moment(result.From_Date).format("MM/DD/YYYY"));
            $('#End_Date').val(moment(result.End_Date).format("MM/DD/YYYY"));
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
    $('#LeaveType_Id').val('Select Leave Type');
    $('#Reason').val('');
    $('#Attachment').val('');
    $('#From_Date').val('');
    $('#End_Date').val('');
    $('#Update').hide();
    $('#Save').show();
}

var LeaveTypes = []
function LoadLeaveType(element) {
    if (LeaveTypes.length == 0) {
        $.ajax({
            type: "GET",
            url: "/LeaveTypes/LoadLeaveType/",
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
    $ele.append($('<option/>').val('0').text('Select Leave Type'));
    $.each(LeaveTypes, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadLeaveType($('#LeaveType_Id'));
$('#Update').hide();
$('#Save').show();
ClearScreen();

function today() {
    var Request_Date = document.querySelector(Request_Date);
    var today = new Date();
    Request_Date.value = today.toISOString().substr(0, 10);
}


function Validate() {
    if ($('#From_Date').val() == "" || $('#From_Date').val() == " ")
    {
        swal("Oops", "Please Choose From Date", "error")
    }
    else if ($('#End_Date').val() == "" || $('#End_Date').val() == " ")
    {
        swal("Oops", "Please Choose End Date", "error")
    }
    else if ($('#Leave_Type').val() == "" || $('#Leave_Type').val() == " ")
    {
        swal("Oops", "Please Choose Leave Type", "error")
    }
    else if ($('#Reason').val() == "" || $('#Reason').val() == " ")
    {
        swal("Oops", "Please Insert Reason", "error")
    }
    else if ($('#Attachment').val() == "" || $('#Attachment').val() == " ")
    {
        swal("Oops", "Please Insert Attachment", "error")
    }
    else if ($('#Id').val() == "")
    {
        Save();
    }
    else
    {
        Edit();
    }
}