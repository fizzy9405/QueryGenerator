$(document).ready(function () {
    $('#btnGenerateCSV').on('click', function () {
        $.ajax({
            url: "/api/CSVRates",
            type: "Post",
            data: {
                CodeOrISIN: $('#txtCodeOrISIN').val(),
                DateFrom: $('#dateFrom').val(),
                DateTo: $('#dateTo').val(),
                ValueFrom: $('#numValueFrom').val(),
                ValueTo: $('#numValueTo').val()
               
                
            },
            success: function() {
                alert("File was saved at 'C:\\CSVFolder'");
                console.log('success');

            },
            error: function (e) {
                console.log('error', e);
            }
        });
    });
});