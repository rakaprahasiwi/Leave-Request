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
        url: "/LeaveRequestsEmployees/LoadLeaveRequestEmployee/", //shoot to controller client LeaveTypessController
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
                html += '<td>' + '<Button href = "#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-eye"></i></button>';
                html += '<Button href = "#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i></button>';
                html += ' <Button href="#" class="btn btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i></Button></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}