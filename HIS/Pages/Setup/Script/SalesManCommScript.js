$(document).ready(function () {
    $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
        $(this).find("input[id*=txtRate_]").change(function () {
            if ($(this).val().match(/%/g) == null) {
                $(this).val($(this).val() + "%")
            }
        });
    });
});
function save() {
    if (isValid()) {
        var uiMapperDetails = [];

        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                var detail = new UIMapper();
                detail.emp_salesman_id = $($(this)[0].cells[0]).html();
                detail.emp_name = $($(this)[0].cells[1]).html();
                detail.emp_salesman_com = $(this).find("input[id*=txtRate_]").val();
                detail.emp_id = $($(this)[0].cells[3]).html();
                uiMapperDetails.push(detail);
            }
        });
        var str = '{ "uiMapperDetails": ' + JSON.stringify(uiMapperDetails) + '  }';

        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "SalesManCommSetup.aspx/SaveDetails",
            data: str,
            dataType: "json",
            success: function (data) {
                $("#MainContent_btnSave").click();
            },
            error: function (result) {
                alert("error");
            }
        });
    }
    return false;
}

UIMapper = function () {
    this.emp_id = null;
    this.emp_salesman_id = null;
    this.emp_name = null;
    this.emp_salesman_com = null;
}
