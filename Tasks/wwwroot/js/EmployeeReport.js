$(document).ready(function () {
    $("#btnGenerate").click(function () {
        ReportManager.GenerateReport();
    });
});

var ReportManager = {
    GenerateReport(): function() {
        var jsonParse = "";
        var serviceUrl = "../Home/GetEmployeeReport";
        ReportManager.GetReport(serviceUrl, jsonParse, onFailed);

        function onFailed(error) {
            alert(error);
        }
    },

    GetReport: function (serviceUrl, jsonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.open('..Reports/ReportViewer.aspx', '_newtab');
            },
            error: errorCallback
        });
    }
};

var ReportHelper = {

};