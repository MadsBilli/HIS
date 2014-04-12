function save() {
    if (isValid()) {
        var uiMapperDetails = [];

        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                var detail = new UIMapper();
                detail.city_code = $(this).find("input[id*=txtId_]").val();
                detail.city_desc = $(this).find("input[id*=txtName_]").val();
                if ($(this).find("input[id*=chkActive_]").attr("checked")) {
                    detail.city_active = true;
                }
                else {
                    detail.city_active = false;
                }
                detail.primaryKey = $($(this)[0].cells[3]).html();
                uiMapperDetails.push(detail);
            }
        });
        var str = '{ "uiMapperDetails": ' + JSON.stringify(uiMapperDetails) + '  }';

        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "CountrySetup.aspx/SaveDetails",
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
    this.city_code = null;
    this.city_desc = null;
    this.city_active = null;
    this.primaryKey = null;
}

function showActive(element) {
    if ($(element).attr("checked")) {
        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                if ($(this).find("input[id*=chkActive_]").attr("checked")) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            }
        });
    }
    else {       
        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                $(this).show();
            }
        });
    }
}

function fillddlCountry() {
    var uniqueValues = {};
    var listOfValues = [];
    $("#ddlCountry").html('');
    $("#ddlCountry").html("<option value='All'></option>");
    $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
        if (trindex > 0) {
            $(this).find("input[id*=txtName_]").each(function (tdindex, element) {
                var itemval = $(this).val();
                if (!uniqueValues[itemval]) {
                    uniqueValues[itemval] = true;
                    listOfValues.push(itemval);
                    $("#ddlCountry").append("<option value='" + itemval + "'>" + itemval + "</option>");
                }
            });
        }
    });
}
function setFocus() {
    var selectedvalue = $("#ddlCountry").val();
    var setfocus = false;
    $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, trelement) {
        if (trindex > 0) {
            $(this).find("input[id*=txtName_]").each(function (tdindex, tdelement) {
                var itemval = $(this).val();
                if (itemval == selectedvalue) {
                    if (!setfocus) {
                        $(trelement).find("input[id*=txtId_]").focus();
                        setfocus = true;
                    }
                }
            });
        }
    });
}
$(document).ready(function () {
    if ($("#chkActive").attr("checked")) {
        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                if ($(this).find("input[id*=chkActive_]").attr("checked")) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            }
        });
    }
    fillddlCountry();
    $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
        if (trindex > 0) {
            $(this).find("input[id*=txtName_]").change(function() {
                fillddlCountry();
            });
        }
    });
});