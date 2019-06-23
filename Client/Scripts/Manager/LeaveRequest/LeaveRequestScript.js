$(document).ready(function () {
    LoadIndexLeaveRequest();
    $('#table').DataTable({
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
                html += '<td>' + val.Employee_Id + '</td>';
                html += '<td>' + val.Manager_Id + '</td>';
                html += '<td>' + val.LeaveTypes_Id + '</td>';
                html += '<td>' + val.Reason + '</td>';
                html += '<td>' + val.Request_Date + '</td>';
                html += '<td>' + val.From_Date + '</td>';
                html += '<td>' + val.End_Date + '</td>';
                html += '<td>' + val.StatusTypeParameter_Id + '</td>';
                html += '<td>' + '<a href = "#" class="fa da-pencil" onclick= return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}