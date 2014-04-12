function save() {
    if (isSaveValid()) {
        var uiMapperDetails = [];

        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                var detail = new UIMapper();
                detail.rt_display_name = $(this).find("input[id*=txtDisplayName_]").val();
                detail.rt_name = $(this).find("input[id*=txtName_]").val();
                detail.rt_allow_edit = false;
                detail.rt_form = null;
                detail.rt_id = $(this).find("input[id*=txtId_]").val();
                detail.rt_criteria = $(this).find("input[id*=txtCriteria_]").val();
                detail.rt_table = $(this).find("input[id*=txtTable_]").val();
                detail.primaryKey = $($(this)[0].cells[5]).html();
                uiMapperDetails.push(detail);
            }
        });
        var str = '{ "uiMapperDetails": ' + JSON.stringify(uiMapperDetails) + '  }';

        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "RptPrintingSetup.aspx/SaveDetails",
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
    this.rt_name = null;
    this.rt_display_name = null;
    this.rt_allow_edit = null;
    this.rt_form = null;
    this.rt_table = null;
    this.rt_id = null;
    this.rt_criteria = null;
    this.primaryKey = null;
}

function isSaveValid() {
    var uniqueValues = {};
    var listOfValues = [];
    var isNotValid = false;
    $(".InsertUpdateDeleteGrid tbody tr").each(function (index, element) {
        if (index != 0 && !isNotValid && index != $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
            var itemval = $(this).find("input[id*=txtName_]").val();
            if ($.trim(itemval) == "") {
                alert("You tried to assign the Null value to Rpt Name. This column doesn't allow null values");
                isNotValid = true;
            }
            if (!uniqueValues[itemval]) {
                uniqueValues[itemval] = true;
                listOfValues.push(itemval);
            }
            else {
                alert("Duplicates Ids Found! Remove the Duplicates");
                isNotValid = true;
            }
        }
    });
    return !isNotValid;
}