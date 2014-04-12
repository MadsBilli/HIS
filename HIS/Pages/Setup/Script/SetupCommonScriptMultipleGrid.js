var $selectedRow1 = null;
$(document).ready(function () {
    $(".InsertUpdateDeleteGrid1 tbody tr").click(function () {
        if ($(this).index() != 0) {
            rowHighlight1($(this));
        }
    });
    $(".InsertUpdateDeleteGrid1").find("tr:last").attr("addNew", "true");
    $(".InsertUpdateDeleteGrid1").find("tr:last td > input").keyup(function () {
        if ($(this).parent().parent()[0].className.match(/nonInsertable/g) == null) {
            if ($.trim($(this).val()) != '' && $(this).parent().parent().index() == $(".InsertUpdateDeleteGrid1 tbody tr").length - 1) {
                var Id = $(".InsertUpdateDeleteGrid1").find("tr:nth-last-child(2)").find("td:first > input:first").val();
                if ($(this).parent().index() != 0) {
                    if (!isNaN(parseInt(Id))) {
                        $(this).parent().parent().find("input[id*=txtId_]").val((parseInt(Id) + 1));
                    }
                    else {
                        $(this).parent().parent().find("input[id*=txtId_]").val('');
                    }
                }
                cloneNewRow1();
                $(this).unbind("keyup");
            }
        }
    });
    highlightRowOnMouseOver1();
});
function cloneNewRow1() {
    var newRow = $(".InsertUpdateDeleteGrid1").find("tr:last").clone();
    $('td', $(newRow)).removeClass('active');
    $('td', $(newRow)).removeClass('highlight');
    $(newRow).removeClass('InsertUpdateDeleteGrid1row');
    $(newRow).removeClass('InsertUpdateDeleteGrid1rowAlt');
    $(newRow).find("tr:last").attr("addNew", "true");
    $(".InsertUpdateDeleteGrid1").append(newRow);
    $(newRow).find("td > input").val('');

    $('td > input', $(newRow)).each(function (index, element) {
        var existingID = $(this).attr("id");
        var tdIndex = existingID.lastIndexOf('_');
        var newId = existingID.substr(0, tdIndex + 1) + $(newRow).index();
        $(this).attr("id", newId);

        var existingname = $(this).attr("name").split('$');
        var ctvalue = existingname[3].substr(3);
        var newname = parseInt(ctvalue, 10) + 1;
        $(this).attr("name", existingname[0] + "$" + existingname[1] + "$" + existingname[2] + "$ctl" + newname + "$" + existingname[4]);
    });

    $(".InsertUpdateDeleteGrid1").find("tr:last td > input").keyup(function () {
        if ($.trim($(this).val()) != '' && $(this).parent().parent().index() == $(".InsertUpdateDeleteGrid1 tbody tr").length - 1) {
            var Id = $(".InsertUpdateDeleteGrid1").find("tr:nth-last-child(2)").find("td:first > input:first").val();
            if ($(this).parent().index() != 0) {
                if (!isNaN(parseInt(Id))) {
                    $(this).parent().parent().find("input[id*=txtId_]").val((parseInt(Id) + 1));
                }
                else {
                    $(this).parent().parent().find("input[id*=txtId_]").val('');
                }
            }
            cloneNewRow1();
            $(this).unbind("keyup");
        }
    });

    if ($(newRow).index() % 2 == 0) {
        $(newRow).addClass("InsertUpdateDeleteGrid1rowAlt");
    }
    else {
        $(newRow).addClass("InsertUpdateDeleteGrid1row");
    }

    $(newRow).click(function () {
        if ($(this).index() != 0) {
            rowHighlight1($(this));
        }
    });
    highlightRowOnMouseOver1();
}
function isValid1() {
    var uniqueValues = {};
    var listOfValues = [];
    var isNotValid = false;
    $(".InsertUpdateDeleteGrid1 tbody tr").each(function (index, element) {
        if (index != 0 && !isNotValid && index != $(".InsertUpdateDeleteGrid1 tbody tr").length - 1) {
            var itemval = $(this).find("td:first > input:first").val();
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

//highlight the selected row
function rowHighlight1($row) {
    var $table = (".InsertUpdateDeleteGrid1");
    $('tbody tr:odd td', $table).removeClass('active');
    $('tbody tr:even td', $table).removeClass('active');
    $('td', $row).addClass('active');
    $selectedRow1 = $row;
}

function delItem1(element) {
    var $thisRow = $(element).parents("tr").eq(0);
    if ($thisRow.attr("addNew")) {
        if ($thisRow.index() != $(".InsertUpdateDeleteGrid1 tbody tr").length - 1) {
            if (confirm("Are you sure want to delete this record? This action can't be undo.")) {
                $thisRow.remove();
                formatTable1();
                return false;
            }
            else {
                return false;
            }
        }
        else if ($thisRow.index() == $(".InsertUpdateDeleteGrid1 tbody tr").length - 1) {
            return false;
        }
    }
    return confirm("Are you sure want to delete this record? This action can't be undo.");
}



function highlightRowOnMouseOver1() {
    $(".InsertUpdateDeleteGrid1 tbody tr:odd").hover(
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).addClass('highlight');
     },
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).removeClass('highlight');
     });
    $(".InsertUpdateDeleteGrid1 tbody tr:even").hover(
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).addClass('highlight');
     },
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).removeClass('highlight');
     });
}

function formatTable1() {
    $(".InsertUpdateDeleteGrid1 tbody tr").each(function (index, element) {
        if (index > 0) {
            if (index % 2 == 0) {
                $(this).removeClass("InsertUpdateDeleteGrid1row");
                $(this).addClass("InsertUpdateDeleteGrid1rowAlt");
            }
            else {
                $(this).removeClass("InsertUpdateDeleteGrid1rowAlt");
                $(this).addClass("InsertUpdateDeleteGrid1row");
            }
        }
    });
}