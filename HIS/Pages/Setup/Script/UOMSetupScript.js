function save() {
    if (isValid()) {
        var uiMapperDetails = [];

        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                var detail = new UIMapper();
                detail.unit_id = isNaN(parseInt($(this).find("input[id*=txtId_]").val())) ? 0 : parseInt($(this).find("input[id*=txtId_]").val());
                detail.unit_rmk = $(this).find("input[id*=txtDescription_]").val();
                detail.unit_type = $(this).find("input[id*=txtType_]").val();
                detail.primaryKey = $($(this)[0].cells[3]).html();
                uiMapperDetails.push(detail);
            }
        });
        var str = '{ "uiMapperDetails": ' + JSON.stringify(uiMapperDetails) + '  }';

        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "UOMSetup.aspx/SaveDetails",
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
    this.unit_id = null;
    this.unit_rmk = null;
    this.unit_type = null;
    this.primaryKey = null;
}