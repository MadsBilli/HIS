function save() {
    if (isValid()) {
        var uiMapperDetails = [];

        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                var detail = new UIMapper();
                detail.inv_sel_ln = isNaN(parseInt($(this).find("input[id*=txtId_]").val())) ? 0 : parseInt($(this).find("input[id*=txtId_]").val());
                detail.inv_sel_desc = $(this).find("input[id*=txtDescription_]").val();
                detail.primaryKey = $($(this)[0].cells[2]).html();
                uiMapperDetails.push(detail);
            }
        });
        var str = '{ "uiMapperDetails": ' + JSON.stringify(uiMapperDetails) + '  }';

        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "InvoiceItemsSelectionSetup.aspx/SaveDetails",
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
    this.inv_sel_ln = null;
    this.inv_sel_desc = null;
    this.primaryKey = null;
}