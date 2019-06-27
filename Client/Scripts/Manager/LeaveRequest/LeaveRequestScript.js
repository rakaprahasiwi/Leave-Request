$(document).ready(function () {
    LoadIndexLeaveRequest();
    $('#tableLeaveRequest').DataTable({
        "ajax": LoadIndexLeaveRequest()
    })
})

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
                html += '<td>' + moment(val.Request_Date).format("YYYY-MM-DD") + '</td>';
                html += '<td>' + moment(val.From_Date).format("YYYY-MM-DD") + '</td>';
                html += '<td>' + moment(val.End_Date).format("YYYY-MM-DD") + '</td>';
                html += '<td>' + val.Employee_Id + '</td>';
                html += '<td>' + val.Manager_Id + '</td>';
                html += '<td>' + val.LeaveType.Name + '</td>';
                html += '<td>' + val.Attachment + '</td>';
                html += '<td>' + val.Reason + '</td>';
                html += '<td>' + val.Status + '</td>';
                html += '<td>' + '<Button href = "#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i></button>';
                html += ' <Button href="#" class="btn btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i></Button></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

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

function Edit() {
    var leaveRequest = new Object();
    leaveRequest.id = $('#Id').val();
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
        url: "/LeaveRequests/InsertOrUpdate/",
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

function GetById(Id) {
    $.ajax({
        url: "/LeaveRequests/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Request_Date').val(moment(result.Request_Date).format("YYYY-MM-DD"));
            $('#From_Datee').val(moment(result.From_Date).format("YYYY-MM-DD"));
            $('#End_Datee').val(moment(result.End_Date).format("YYYY-MM-DD"));
            $('#Employee').val(result.Employee_Id);
            $('#Manager').val(result.Manager_Id);
            $('#LeaveType_Id').val(result.LeaveType_Id);
            $('#Attachment').val(result.Attachment);
            $('#Reason').val(result.Reason);
            $('#Status').val(result.Status);
            
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

//function LoadIndexLeaveRequest() {
//    $.ajax({
//        type: "GET",
//        async: false,
//        url: "/LeaveRequests/LoadLeaveRequest/",
//        dateType: "json",
//        success: function (data) {
//            var html = '';
//            var i = 1;
//            $.each(data, function (index, val) {
//                $.ajax({
//                    url: "/LeaveRequests/GetById/",
//                    data: { id: val.LeaveType_Id },
//                    success: function (result) {
//                        html += '<tr>';
//                        html += '<td>' + i + '</td>';
//                        html += '<td>' + val.Request_Date + '</td>';
//                        html += '<td>' + val.From_Date + '</td>';
//                        html += '<td>' + val.End_Date + '</td>';
//                        html += '<td>' + val.Employee_Id + '</td>';
//                        html += '<td>' + val.Manager_Id + '</td>';
//                        html += '<td>' + result.Name + '</td>';
//                        html += '<td>' + val.Attachment + '</td>';
//                        html += '<td>' + val.Reason + '</td>';
//                        html += '<td>' + val.Status + '</td>';
//                        html += '<td> <Button href="#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i></Button>';
//                        html += ' <Button href="#" class="btn btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i></Button> </td>';
//                        html += '</tr>';
//                        i++;
//                        $('.tbody').html(html);
//                    }
//                });
//            });
//        }
//    });
//}

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

function Validate() {
    if ($('#From_Date').val() == "" || $('#From_Date').val() == " ")
    {
        swal("Oops", "Please Insert Start Date", "error")
    } 
    else if ($('#End_Date').val() == "" || $('#End_Date').val() == " ")
    {
        swal("Oops", "Please Insert End Date", "error")
    } 
    else if ($('#LeaveType_Id').val() == 0 || $('#LeaveType_Id').val() == "Select Leave Type")
    {
        swal("Oops", "Expected Leave Type", "error")
    } 
    else if ($('#Attachment').val() == "" || $('#Attachment').val() == " ")
    {
        swal("Oops", "Expected Note", "error")
    }
    else if ($('#Reason').val() == "" || $('#Reason').val() == " ")
    {
        swal("Oops", "Expected Reaspn", "error")
    }
    else if ($('#Id').val() == "" || $('#Id').val() == " ")
    {
        Save();
    }
    else
    {
        Edit();
    }
}