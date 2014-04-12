$(document).ready(function () {
            $(".initalHide").hide();
            if ($("#MainContent_ddlSalesmanCode").val() != 0) {
                $("#MainContent_txtSalesman").val($("#MainContent_ddlSalesmanCode").val());
            }

            chkShowHideGridColumn($("#MainContent_chkShowHideGridColumn")[0], 4);
            chkShowHideGridColumn($("#MainContent_chkShowInactiveColumn")[0], 3);
    });


function fillSalesManValue(element) {
    if ($(element).val() != 0) {
    var str = '{ "emp_id": ' + JSON.stringify($(element).val()) + '  }';
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "CustomerAddEdit.aspx/GetSalesManCode",
        data: str,
        dataType: "json",
        success: function (data) {
            $("#MainContent_txtSalesman").val(data.d);
        },
        error: function (result) {
            alert("error");
        }
    });
    }
    else {
        $("#MainContent_txtSalesman").val('');
    }
}

function chkShowHideGridColumn(chkbox, indextoHide) {
    if ($(chkbox).attr("checked") == "checked") {
        $("#MainContent_gvCustomerList").find("tr").each(function (index, ele) {
            $(this).find("td,th").each(function (tdIndex, element) {
                if (tdIndex == indextoHide || (indextoHide == 4 && tdIndex == 5))
                    $(this).show();
            });
        });
    }
    else {
        $("#MainContent_gvCustomerList").find("tr").each(function (index, ele) {
            $(this).find("td,th").each(function (tdIndex, element) {
                if (tdIndex == indextoHide || (indextoHide == 4 && tdIndex == 5))
                    $(this).hide();
            });
        });
    }
}

function Confirm() {
    if (confirm("Are you sure want to delete this record? This action can't be undo.")) {
        return true;
    }
    else {
        return false;
    }
}