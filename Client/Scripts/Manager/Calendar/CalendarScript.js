$(document).ready(function () {
    LoadIndexCalendar();
    $('#tableCalendar').DataTable({
        "ajax": LoadIndexCalendar()
    });
})

function Save() {
    var calendar = new Object();
    calendar.name = $('#Name').val();

    calendar.national_date = $('#National_Date').val();
    $.ajax({
        url: "/Calendars/InsertOrUpdate/",
        data: calendar,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Calendars/Index/';
            });
            LoadIndexCalendar();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexCalendar() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Calendars/LoadCalendar/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + moment(val.National_Date).format("MM/DD/YYYY") + '</td>';
                html += '<td> <Button href = "#" class="btn btn-info" onclick="return GetById(' + val.Id + ')"><i class="fa fa-pencil"></i></Button>';
                html += ' <Button href = "#" class="btn btn-danger" onclick="return Delete(' + val.Id + ')"><i class="fa fa-trash"></i></Button></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var calendar = new Object();
    calendar.id = $('#Id').val();
    calendar.name = $('#Name').val();
    debugger;
    calendar.national_date = $('#National_Date').val();
    debugger;
    $.ajax({
        url: "/Calendars/InsertOrUpdate/",
        data: calendar,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Calendars/Index/';
            });
            LoadIndexCalendar();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Calendars/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            debugger;
            $('#National_Date').val(moment(result.National_Date).format("MM/DD/YYYY"));
            debugger;
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
            url: "/Calendars/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Calendars/Index/';
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
    $('#National_Date').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#National_Date').val() == "") {
        swal("Oops", "Please Choose Date", "error")
    }
    else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}