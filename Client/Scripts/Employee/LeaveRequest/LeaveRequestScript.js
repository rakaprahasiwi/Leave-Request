$(document).ready(function () {
    LoadIndexLeaveRequest();
    $('#tableLeaveRequestEmployee').DataTable({
        "ajax": LoadIndexLeaveRequest()
    })
})

function Save() {
    var leaveRequest = new Object();
    leaveRequest.Request_Date = $('#Request_Date').val();
    leaveRequest.from_Date = $('#From_Datee').val();
    leaveRequest.end_Date = $('#End_Datee').val();
    leaveRequest.Employee_Id = $('#Employee').val();
    leaveRequest.Manager_Id = $('#Manager').val();
    leaveRequest.LeaveType_Id = $('#LeaveType_Id').val();
    leaveRequest.Attachment = $('#Attachment').val();
    leaveRequest.Reason = $('#Reason').val();
    leaveRequest.Status = $('#Status').val();
    $.ajax({
        url: '/LeaveRequests/InsertOrUpdate/',
        data: leaveRequest,
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

function Validate() {
    if ($('#From_Date').val() == "" || $('#From_Date').val() == " ") {
        swal("Oops", "Please Insert Start Date", "error")
    }
    else if ($('#End_Date').val() == "" || $('#End_Date').val() == " ") {
        swal("Oops", "Please Insert End Date", "error")
    }
    else if ($('#LeaveType_Id').val() == 0 || $('#LeaveType_Id').val() == "Select Leave Type") {
        swal("Oops", "Expected Leave Type", "error")
    }
    else if ($('#Attachment').val() == "" || $('#Attachment').val() == " ") {
        swal("Oops", "Please Insert File", "error")
    }
    else if ($('#Reason').val() == "" || $('#Reason').val() == " ") {
        swal("Oops", "Please Insert Reason", "error")
    }
    else if ($('#Id').val() == "" || $('#Id').val() == " ") {
        Save();
    }
    else {
        Edit();
    }
}

function ClearScreen() {
    $('#From_Date').val('');
    $('#End_Date').val('');
    $('#Id').val('');
    $('#LeaveType_Id').val(0);
    $('#Attachment').val('effwe');
    $('#Reason').val('');
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
                renderLeaveType(element);
            }
        })
    }
    else {
        renderLeaveType(element);
    }
}

function renderLeaveType(element) {
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