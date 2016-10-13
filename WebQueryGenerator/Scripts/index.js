$(document).ready(function () {
    //  $(".datepicker").datepicker();
    $('#btnGenerate').click(function () {


        $.ajax({
            url: "api/Data",
            type: "Post",
            data: {
                DateFrom: $('#dateFrom').val(),
                DateTo: $('#dateTo').val(),
                ValueFrom: $('#txtValueFrom').val(),
                ValueTo: $('#txtValueTo').val(),
                Table: $('#txtTable').val(),
            },
            success: function (data) {
                var textField = $('#scrollableTextField');
                console.log('success', data);
                data.forEach(function (elem) {
                    if (textField.text() == '') {
                        textField.text(elem);
                    }
                    else {
                        textField.text(textField.text() + '\n' + elem);
                    }
                })
            },
            error: function (e) {
                console.log('error', e);
            }


        });
    });
})

