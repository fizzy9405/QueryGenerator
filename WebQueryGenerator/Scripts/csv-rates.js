$(document).ready(function () {
    $('#btnGenerateCSV').on('click', function () {
        that.GenerateCSV();
    });
    $('#btn-add-row').on('click', function () {
        that.AddRow();
    });
});

let that = this;
function GenerateCSV() {
    var coll = that.CollectData();
    debugger;
    $.ajax({
        url: "/api/CSVRates",
        type: "Post",
        data: {
            Values: coll,

            UseComma: $('#myonoffswitch')[0].checked
        },
        success: function () {
            alert("File was saved at 'C:\\CSVFolder'");
            console.log('success');
        },
        error: function (e) {
            console.log('error', e);
        }
    });
};

function AddRow() {
   
    var $div = $('li[class^="rates-list-item"]:last');

    var num = parseInt($div.prop("id").match(/\d+/g), 10) + 1;

    var $row = $div.clone().prop('id', num);
    ClearInputs($row);
    $div.after($row);

}

function IncreaseIds() {
    var firstInput = $('input[id^="txtCodeOrISIN"]:last');
    var num = parseInt(firstInput.prop("id").match(/\d+/g), 10) + 1;
    firstInput.prop("id").val() = num;
}

function ClearInputs($row){
    var rowsInputs = $row.find('input');
    rowsInputs.each(function (el) {
        rowsInputs[el].value='';
    })
}

function CollectData() {
    var allListItems = $('.rates-list-item');
    var lastItemLoc = allListItems.length - 1;

    var testBigColl = [];
    for (var i = 0; i <= lastItemLoc; i++) {

        var parentSelector = '#' + i + '.rates-list-item ';
        arr = {
            CodeOrIsin: $(parentSelector + '[id="txtCodeOrISIN"]').val(),
            DateFrom: $(parentSelector + '[id="dateFrom"]').val(),
            DateTo: $(parentSelector + '[id="dateTo"]').val(),
            ValueFrom: $(parentSelector + '[id="numValueFrom"]').val(),
            ValueTo: $(parentSelector + '[id="numValueTo"]').val(),

        };
        testBigColl.push(arr);
    }
    return testBigColl;
}