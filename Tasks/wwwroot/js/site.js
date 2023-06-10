$('#PlaceHolderHere').on('hidden.bs.modal', function () {
    location.reload();
})

$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderElement.html(data);
            //    var menuId = PlaceHolderElement.find('.MenuId').val();
            //    var cat_id = PlaceHolderElement.find('.CategoryId').val();
            //    GetMenu(menuId);
            //    GetCategory(menuId, cat_id);

            PlaceHolderElement.find('.modal').modal('show');
        })
    })
})