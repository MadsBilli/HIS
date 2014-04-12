$(document).ready(function () {
    fillDdlGrp();
    $("#divSysSetup").find("textarea[id*=txtDesc_]").keyup(function () {
        var id = $(this).attr("id").split('_');
        var divElement = $("#divDesc_" + id[1]);
        myFunc($(this), $(divElement));
    });

    //and this for good measure
    $("#divSysSetup").find("textarea[id*=txtDesc_]").change(function () {
        var id = $(this).attr("id").split('_');
        var divElement = $("#divDesc_" + id[1]);
        myFunc($(this), $(divElement));
    });
    $("#divSysSetup").find("input[id*=txtGrp_]").change(function () {
        fillDdlGrp();
    });
    $("#divSysSetup").find("textarea[id*=txtVal_]").keyup(function () {
        var id = $(this).attr("id").split('_');
        var divElement = $("#divVal_" + id[1]);
        myFunc($(this), $(divElement));
    });

    //and this for good measure
    $("#divSysSetup").find("textarea[id*=txtVal_]").change(function () {
        var id = $(this).attr("id").split('_');
        var divElement = $("#divVal_" + id[1]);
        myFunc($(this), $(divElement));
    });
});

function fillDdlGrp() {
    var uniqueValues = {};
    var listOfValues = [];
    $("#ddlGrp").html('');
    $("#ddlGrp").html("<option value='All'></option>");
    $("#divSysSetup").find("input[id*=txtGrp_]").each(function (tdindex, element) {
        var itemval = $(this).val();
        if (!uniqueValues[itemval]) {
            uniqueValues[itemval] = true;
            listOfValues.push(itemval);
            $("#ddlGrp").append("<option value='" + itemval + "'>" + itemval + "</option>");
        }
    });
}

function myFunc(element, divElement) {
    var input = $(element).val();
    $(divElement).text(input);
}

function changeFilter() {
    var selectedVal = $("#ddlGrp").val();
    $("#divSysSetup").find("input[id*=txtGrp_]").each(function (index, element) {
        var itemval = $(this).val();
        var tdindex = index + 1;
        if (selectedVal == "All") {
            $("#divSysSetup").find("fieldset[id=fld_" + tdindex + "]").show();
        }
        else {
            if (selectedVal == itemval) {
                $("#divSysSetup").find("fieldset[id=fld_" + tdindex + "]").show();
            }
            else {
                $("#divSysSetup").find("fieldset[id=fld_" + tdindex + "]").hide();
            }
        }
    });
}

function save() {
    var uiMapperDetails = [];

    $("#divSysSetup").find("input[id*=txtGrp_]").each(function (index, element) {
        var tdindex = index + 1;
        var detail = new UIMapper();
        detail.setup_txt = $("#divSysSetup").find("td[id=txtPrimaryKey_" + tdindex + "]").html();
        detail.setup_value = $("#divSysSetup").find("div[id=divVal_" + tdindex + "]").html();
        detail.setup_description = $("#divSysSetup").find("div[id=divDesc_" + tdindex + "]").html();
        detail.setup_grp = $("#divSysSetup").find("input[id=txtGrp_" + tdindex + "]").val();
        detail.setup_id = 0;
        detail.setup_LN = parseInt($("#divSysSetup").find("label[id=lblLN_" + tdindex + "]").html());
        detail.primaryKey = $("#divSysSetup").find("td[id=txtPrimaryKey_" + tdindex + "]").html();
        uiMapperDetails.push(detail);
    });
    var str = '{ "uiMapperDetails": ' + JSON.stringify(uiMapperDetails) + '  }';

    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "SystemSettingSetup.aspx/SaveDetails",
        data: str,
        dataType: "json",
        success: function (data) {
            $("#MainContent_btnSave").click();
        },
        error: function (result) {
            alert("error");
        }
    });
    return false;
}

UIMapper = function () {
    this.setup_txt = null;
    this.setup_value = null;
    this.setup_description = null;
    this.setup_id = null;
    this.setup_grp = null;
    this.setup_LN = null;
    this.primaryKey = null;
}