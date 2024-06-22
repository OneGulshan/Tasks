$('#PlaceHolderHere').on('hidden.bs.modal', function () {
    location.reload();
})

$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            var menuId = PlaceHolderElement.find('.hdnMenuId').val();
            var cat_id = PlaceHolderElement.find('.hdnCatId').val();
            GetMenu(menuId);
            GetCategory(menuId, cat_id);

            $('#con').empty();
            $('#sta').empty();
            $('#city').empty();
            var C_Id = PlaceHolderElement.find('.hdncId').val();
            var S_Id = PlaceHolderElement.find('.hdnsId').val();
            var City_Id = PlaceHolderElement.find('.hdncityId').val();
            GetCountry(C_Id);
            Getstate(C_Id, S_Id);
            Getcity(S_Id, City_Id);
            PlaceHolderElement.find('.modal').modal('show');
        });
    });
});

$(document).ready(function () {
    $('#menu').change(function () {
        $('#category').attr('disabled', false);
        var id = $(this).val();
        GetCategory(id);
    });
    $('#con').change(function () {
        $('#sta').attr('disabled', false);
        var id = $(this).val();
        Getstate(id);
    });
    $('#sta').change(function () {
        $('#city').attr('disabled', false);
        var id = $(this).val();
        Getcity(id);
    });
});

function GetMenu(menu_id) {
    $.ajax({
        url: "/Admin/GetMenu",
        success: function (result) {
            $('#menu').empty();
            $('#menu').append('<option value=' + 0 + ' >' + '--------Select Menu-------' + '</option >');
            $.each(result, function (i, data) {
                if (menu_id == data.menu_Id) {
                    $('#menu').append('<option value=' + data.menuId + ' selected >' + data.menuName + '</option >');
                }
                else {
                    $('#menu').append('<option value=' + data.menuId + '>' + data.menuName + '</option >');
                }

            });
        }
    });
}

function GetCategory(menuId, categoryid) {
    $.ajax({
        url: '/Admin/GetCategory?id=' + menuId,
        success: function (result) {
            $('#category').empty();
            $('#category').append('<option value=' + 0 + ' >' + '--------Select Category-------' + '</option >');
            $.each(result, function (i, data) {
                if (categoryid == data.categoryId) {
                    $('#category').append('<option value=' + data.categoryId + ' selected >' + data.categoryName + '</option >');
                }
                else {
                    $('#category').append('<option value=' + data.categoryId + ' >' + data.categoryName + '</option >');
                }
            });
        }
    });
}

function GetCountry(cid) {
    $.ajax({
        url: "/AutoMapperDashboard/Country",
        success: function (result) {
            $('#con').empty();
            $('#con').append('<option value=' + 0 + ' >' + '--------Select country-------' + '</option >');
            $.each(result, function (i, data) {
                if (cid == data.cid) {
                    $('#con').append('<option value=' + data.cid + ' selected >' + data.cName + '</option >');
                }
                else {
                    $('#con').append('<option value=' + data.cid + '>' + data.cName + '</option >');
                }
            });
        }
    });
}

function Getstate(cid, sid) {
    $.ajax({
        url: '/AutoMapperDashboard/State?id=' + cid,
        success: function (result) {
            $('#sta').empty();
            $('#sta').append('<option value=' + 0 + ' >' + '--------Select State-------' + '</option >');
            $.each(result, function (i, data) {
                if (sid == data.sid) {
                    $('#sta').append('<option value=' + data.sid + ' selected >' + data.sName + '</option >');
                }
                else {
                    $('#sta').append('<option value=' + data.sid + ' >' + data.sName + '</option >');
                }
            });
        }
    });
}

function Getcity(sid, cid) {
    $.ajax({
        url: '/AutoMapperDashboard/City?id=' + sid,
        success: function (result) {
            $('#city').empty();
            $('#city').append('<option value=' + 0 + ' >' + '--------Select city-------' + '</option >');
            $.each(result, function (i, data) {
                if (cid == data.city_Id) {
                    $('#city').append('<option value=' + data.city_Id + ' selected >' + data.city_Name + '</option >');
                }
                else {
                    $('#city').append('<option value=' + data.city_Id + ' >' + data.city_Name + '</option >');
                }
            });
        }
    });
}

/*------------------Refreshpage--------------------------------------------*/
//function refreshPage() {
//    window.location.reload();
//}

