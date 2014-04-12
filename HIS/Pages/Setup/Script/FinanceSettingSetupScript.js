$(document).ready(function () {
    $("input[id*=rdbAcctNum_]").each(function () {
        if ($(this).attr("checked")) {
            BindAccountNumber(this);
        }
    });

    $("input[id*=rdbAcctNum_]").click(function () {
        BindAccountNumber(this);
    });
});

function BindAccountNumber(element) {
    if ($(element).val() == 10) {
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "FinanceSettingSetup.aspx/GetSGDAccountNumber",
            data: {},
            dataType: "json",
            success: function (data) {
                $("#sgdDiv").show();
                $("#usdDiv").hide();
                $("#txtSGDNum").val(data.d.toString());
            },
            error: function (result) {
                alert("error");
            }
        });
    }
    else if ($(element).val() == 20) {
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "FinanceSettingSetup.aspx/GetUSDAccountNumber",
            data: {},
            dataType: "json",
            success: function (data) {
                $("#sgdDiv").hide();
                $("#usdDiv").show();
                $("#txtUSDNum").val(data.d.toString());
            },
            error: function (result) {
                alert("error");
            }
        });
    }
}


function UpdateSGDAcct() {
    var str = '{ "value": ' + JSON.stringify($("#txtSGDNum").val()) + '  }';
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/UpdateSGDAccountNumber",
        data: str,
        dataType: "json",
        success: function (data) {
            $("#sgdDiv").show();
            $("#usdDiv").hide();
            alert("SGD Bank Acc No. Updated!");
        },
        error: function (result) {
            alert("error");
        }
    });
}

function UpdateUSDAcct() {
    var str = '{ "value": ' + JSON.stringify($("#txtUSDNum").val()) + '  }';
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/UpdateUSDAccountNumber",
        data: str,
        dataType: "json",
        success: function (data) {
            $("#sgdDiv").hide();
            $("#usdDiv").show();
            alert("USD Bank Acc No. Updated!");
        },
        error: function (result) {
            alert("error");
        }
    });
}