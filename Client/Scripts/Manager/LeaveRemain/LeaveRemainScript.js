$(document).ready(function () {
    LoadIndexLeaveRemain();
    $('#table').DataTable({
        "ajax": LoadIndexLeaveRemain()
    })
})

function LoadIndexLeaveRemain() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/LeaveRemains/LoadLeaveRemain/", //shoot to controller client LeaveTypessController
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Employee_Id + '</td>';
                html += '<td>' + val.LeaveRequest_Id + '</td>';
                html += '<td>' + val.Duration + '</td>';
                html += '<td>' + '<a href = "#" class="fa da-pencil" onclick= return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}