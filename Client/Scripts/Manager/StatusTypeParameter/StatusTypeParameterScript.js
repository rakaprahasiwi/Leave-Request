$(document).ready(function () {
    LoadIndexStatusTypeParameter();
    $('#tableStatusTypeParameter').DataTable({
        "ajax": LoadIndexStatusTypeParameter()
    })
})

function Save() {
    var status = new Object();
    status.name = $('#Name').val();
    $.ajax({
        url: "/StatusTypeParameters/InsertOrUpdate/",
        data: status,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/StatusTypeParameters/Index/';
            });
            LoadIndexStatusTypeParameter();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexStatusTypeParameter() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/StatusTypeParameters/LoadStatusTypeParameter/", //shoot to controller client LeaveTypessController
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + '<Button href = "#" class="btn hidden-sm-down btn-success" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i>Edit</button>';
                html += ' | <Button href="#" class="btn hidden-sm-down btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i>Delete</Button></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}

function Edit() {
    var status = new Object();
    status.id = $('#Id').val();
    status.name = $('#Name').val();
    $.ajax({
        url: "/StatusTypeParameters/InsertOrUpdate/",
        data: status,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/StatusTypeParameters/Index/';
            });
            LoadIndexStatusTypeParameter();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/StatusTypeParameters/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);

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
            url: "/StatusTypeParameters/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/StatusTypeParameters/Index/';
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
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}