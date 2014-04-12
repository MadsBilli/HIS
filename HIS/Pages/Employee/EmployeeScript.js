$(document).ready(function () {
    $(".initalHide").hide();
});

function fillEmpID(element) {
    if ($(element).val() != 0) {
        var str = '{ "statusID": ' + JSON.stringify($(element).val()) + '  }';
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "EmployeeAdminAddEdit.aspx/GetEmpID",
            data: str,
            dataType: "json",
            success: function (data) {
                $("#MainContent_txtE_emp_id").val(data.d);
            },
            error: function (result) {
                alert("error");
            }
        });
    }
    else {
        $("#MainContent_txtE_emp_id").val('');
    }
};


function chkShowHideLeftEmp() {
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "EmployeeAdminAddEdit.aspx/GetEmpID",
            data: str,
            dataType: "json",
            success: function (data) {
            },
            error: function (result) {
                alert("error");
            }
        }); 
};


