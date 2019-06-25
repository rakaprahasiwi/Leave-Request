$(document).ready(function () {
    LoadIndexLeaveRemain();
    $('#tableLeaveRemain').DataTable({
        "ajax": LoadIndexLeaveRemain()
    })
})

function Save() {
    var remain = new Object();
    remain.duration = $('#Duration').val();
    remain.employee_id = $('#Employee_Id').val();
    $.ajax({
        url: "/LeaveRemains/InsertOrUpdate/",
        data: remain,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveRemains/Index/';
            });
            LoadIndexLeaveRemain();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

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
                html += '<td>' + val.Duration + '</td>';
                html += '<td>' + val.Employee_Id + '</td>';
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
    var remain = new Object();
    remain.id = $('#Id').val();
    remain.duration = $('#Duration').val();
    remain.employee_id = $('#Employee_Id').val();
    $.ajax({
        url: "/LeaveRemains/InsertOrUpdate/",
        data: remain,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/LeaveRemains/Index/';
            });
            LoadIndexLeaveRemain();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/LeaveRemains/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Duration').val(result.Duration);
            $('#Employee_Id').val(result.Employee_Id);

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
            url: "/LeaveRemains/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/LeaveRemains/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Duration').val('');
    $('#Employee_Id').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Duration').val() == "" || $('#Duration').val() == " ") {
        swal("Oops", "Please Insert Balance Leave", "error")
    } else if ($('#Duration').val() < 0 || $('#Duration').val() > 12) {
        swal("Oops", "Please Insert Balance Leave between 0-12", "error")
    }else if ($('#Employee_Id').val() == "" || $('#Employee_Id').val() == " ") {
        swal("Oops", "Expected Employee", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}