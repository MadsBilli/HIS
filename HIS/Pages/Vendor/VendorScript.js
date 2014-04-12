$(document).ready(function () {
    $(".initalHide").hide();
    chkShowHideGridColumn($("#MainContent_chkShowHideGridColumn")[0], 4);
    chkShowHideGridColumn($("#MainContent_chkShowInactiveColumn")[0], 3);
});


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