var $selectedRow = null;
$(document).ready(function () {
    $(".InsertUpdateDeleteGrid tbody tr").click(function () {
        if ($(this).index() != 0) {
            rowHighlight($(this));
        }
    });
    $(".InsertUpdateDeleteGrid").find("tr:last").attr("addNew", "true");
    $(".InsertUpdateDeleteGrid").find("tr:last td > input").keyup(function () {
        if ($(this).parent().parent()[0].className.match(/nonInsertable/g) == null) {
            if ($.trim($(this).val()) != '' && $(this).parent().parent().index() == $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
                var Id = $(".InsertUpdateDeleteGrid").find("tr:nth-last-child(2)").find("td:first > input:first").val();
                if ($(this).parent().index() != 0) {
                    if (!isNaN(parseInt(Id))) {
                        $(this).parent().parent().find("input[id*=txtId_]").val((parseInt(Id) + 1));
                    }
                    else {
                        $(this).parent().parent().find("input[id*=txtId_]").val('');
                    }
                }
                cloneNewRow();
                $(this).unbind("keyup");
            }
        }
    });
    highlightRowOnMouseOver();
});
function cloneNewRow() {
    var newRow = $(".InsertUpdateDeleteGrid").find("tr:last").clone();
    $('td', $(newRow)).removeClass('active');
    $('td', $(newRow)).removeClass('highlight');
    $(newRow).removeClass('InsertUpdateDeleteGridrow');
    $(newRow).removeClass('InsertUpdateDeleteGridrowAlt');
    $(newRow).find("tr:last").attr("addNew", "true");
    $(".InsertUpdateDeleteGrid").append(newRow);
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

    $(".InsertUpdateDeleteGrid").find("tr:last td > input").keyup(function () {
        if ($.trim($(this).val()) != '' && $(this).parent().parent().index() == $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
            var Id = $(".InsertUpdateDeleteGrid").find("tr:nth-last-child(2)").find("td:first > input:first").val();
            if ($(this).parent().index() != 0) {
                if (!isNaN(parseInt(Id))) {
                    $(this).parent().parent().find("input[id*=txtId_]").val((parseInt(Id) + 1));
                }
                else {
                    $(this).parent().parent().find("input[id*=txtId_]").val('');
                }
            }
            cloneNewRow();
            $(this).unbind("keyup");
        }
    });

    if ($(newRow).index() % 2 == 0) {
        $(newRow).addClass("InsertUpdateDeleteGridrowAlt");
    }
    else {
        $(newRow).addClass("InsertUpdateDeleteGridrow");
    }

    $(newRow).click(function () {
        if ($(this).index() != 0) {
            rowHighlight($(this));
        }
    });
    highlightRowOnMouseOver();
}
function isValid() {
    var uniqueValues = {};
    var listOfValues = [];
    var isNotValid = false;
    $(".InsertUpdateDeleteGrid tbody tr").each(function (index, element) {
        if (index != 0 && !isNotValid && index != $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
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
function rowHighlight($row) {
    var $table = (".InsertUpdateDeleteGrid");
    $('tbody tr:odd td', $table).removeClass('active');
    $('tbody tr:even td', $table).removeClass('active');
    $('td', $row).addClass('active');
    $selectedRow = $row;
}

function delItem(element) {
    var $thisRow = $(element).parents("tr").eq(0);
    if ($thisRow.attr("addNew")) {
        if ($thisRow.index() != $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
            if (confirm("Are you sure want to delete this record? This action can't be undo.")) {
                $thisRow.remove();
                formatTable();
                return false;
            }
            else {
                return false;
            }
        }
        else if ($thisRow.index() == $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
            return false;
        }
    }
    return confirm("Are you sure want to delete this record? This action can't be undo.");
}