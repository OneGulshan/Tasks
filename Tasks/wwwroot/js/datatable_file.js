$(document).ready(function () {
    GetQuestion();
});
function GetQuestion() {
    $.ajax({
        url: '/Question/GetQuestionList',
        type: 'Get',
        datatype: 'json',
        success: OnSuccess
    })
}

function OnSuccess(response) {
    $('#dataTable').DataTable({
        bProcessing: true,
        bLengthChange: true,
        lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
        bfilter: true,
        bSort: true,
        bPaginate: true,
        data: response,
        columns: [
            {
                data: 'Question1',
                render: function (data, type, row, meta) {
                    return row.question1
                }
            },
            {
                data: 'Questio2',
                render: function (data, type, row, meta) {
                    return row.question2
                }
            },
            {
                data: 'Question3',
                render: function (data, type, row, meta) {
                    return row.question3
                }
            },
            {
                data: 'Car1Q',
                render: function (data, type, row, meta) {
                    return row.car1Q
                }
            },
            {
                data: 'Car2Q',
                render: function (data, type, row, meta) {
                    return row.car2Q
                }
            },
            {
                data: 'Bike1Q',
                render: function (data, type, row, meta) {
                    return row.bike1Q
                }
            },
            {
                data: 'Bike2Q',
                render: function (data, type, row, meta) {
                    return row.bike2Q
                }
            },
        ]
    });
}