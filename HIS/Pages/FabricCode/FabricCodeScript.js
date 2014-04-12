var $selectedRow = null;
$(document).ready(function () {
    $(".initalHide").hide();
    $("input[id*='rdbPriceOption']").click(function () {
        if ($(this).attr("checked") == "checked") {
            rdbPriceOptionChange(this);
        }
    });
    $("input[id*='rdbPriceOption']").each(function () {
        if ($(this).attr("checked") == "checked") {
            rdbPriceOptionChange($(this));
        }
    });
    $(".InsertUpdateDeleteGrid tbody tr").click(function () {
        if ($(this).index() != 0) {
            rowHighlight($(this));
        }
    });
    $(".InsertUpdateDeleteGrid").find("tr:last").attr("addNew", "true");
    $(".InsertUpdateDeleteGrid").find("tr:last td:first > input:first").blur(function () {
        if ($.trim($(this).val()) != '') {
            cloneNewRow(true);
            $(this).unbind("blur");
        }
    });
    highlightRowOnMouseOver();
    if ($(".InsertUpdateDeleteGrid").find("tr").length > 1) {
        $selectedRow = $(".InsertUpdateDeleteGrid").find("tr:nth-child(2)");
    }
    else {
        $selectedRow = null;
    }
});
function cloneNewRow(isOnAdd) {
    var newRow = null;
    if (isOnAdd == true) {
        newRow = $(".InsertUpdateDeleteGrid").find("tr:last").clone();
    }
    else {
        newRow = $selectedRow.clone();
    }
    $('td', $(newRow)).removeClass('active');
    $('td', $(newRow)).removeClass('highlight');
    $(newRow).removeClass('InsertUpdateDeleteGridrow');
    $(newRow).removeClass('InsertUpdateDeleteGridrowAlt');
    $(newRow).find("tr:last").attr("addNew", "true");


    if (isOnAdd == true) {
        $(".InsertUpdateDeleteGrid").append(newRow);
        $(newRow).find("td > input").val('');
        $(".numerictd").each(function (tdIndex, element) {
            $(this).val("0.00");
        });
    }
    else {
        newRow.insertBefore($(".InsertUpdateDeleteGrid tbody tr:last"));
        var rollerblindId = $(newRow).find("td:first > input:first").val().split('-');
        if (!isNaN(parseInt(rollerblindId[1]))) {
            $(newRow).find("td:first > input:first").val("RB-" + (parseInt(rollerblindId[1]) + 1));
        }
        else {
            $(newRow).find("td:first > input:first").val('');
        }
        $(newRow).find("input[id*=txtColor_]").val('');
        $(newRow).attr("addNew", "true");
    }

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

    $(".InsertUpdateDeleteGrid").find("tr:last td:first > input:first").blur(function () {
        if ($.trim($(this).val()) != '') {
            cloneNewRow(true);
            $(this).unbind("blur");
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

function delFabricCode(element) {
    var $thisRow = $(element).parents("tr").eq(0);
    if ($thisRow.attr("addNew")) {
        console.log($thisRow.index());
        console.log($(".InsertUpdateDeleteGrid tbody tr").length);
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

FabricCodeUIMapper = function () {
    this.fc_code = null;
    this.fc_type = null;
    this.fc_desc = null;
    this.fc_colour = null;
    this.fc_unitcost = null;
    this.fc_unitprice = null;
    this.fc_unitprice2 = null;
    this.fc_unitprice3 = null;
    this.fc_unitprice4 = null;
    this.fc_instprice = null;
    this.fc_instprice2 = null;
    this.fc_instprice3 = null;
    this.fc_instprice4 = null;
    this.fc_width = null;
    this.fc_min_width = null;
    this.fc_rmk = null;
    this.fc_size = null;
    this.primaryKey = null;
}

function rdbPriceOptionChange(rdbOption) {
    var rdbVal = $(rdbOption).val();
    if (rdbVal == 1) {//PriceOption - Supply
        if ($("#MainContent_ddlmaterial").val() == 1) {//MaterialType - Roller
            $("#MainContent_gvFabricCodeRollerList").find("tr").each(function (index, ele) {
                $(this).find("td,th").each(function (tdIndex, element) {
                    if (tdIndex == 15) {
                        $(this).hide();
                    }
                    else if (tdIndex == 8 || tdIndex == 9 || tdIndex == 10 || tdIndex == 11) {
                        $(this).hide();
                    }
                    else if (tdIndex == 4 || tdIndex == 5 || tdIndex == 6 || tdIndex == 7) {
                        $(this).show();
                    }
                    else {
                        $(this).show();
                    }
                });
            });
        }
        else {//MaterialType - Timber Or FernWood
            $("#MainContent_gvFabricCodeList").find("tr").each(function (index, ele) {
                $(this).find("td,th").each(function (tdIndex, element) {
                    if (tdIndex == 12) {
                        $(this).hide();
                    }
                    else if (tdIndex == 8 || tdIndex == 9) {
                        $(this).hide();
                    }
                    else if (tdIndex == 6 || tdIndex == 7) {
                        $(this).show();
                    }
                    else {
                        $(this).show();
                    }
                });
            });
        }
    }
    else {//PriceOption - Supply & Installation
        if ($("#MainContent_ddlmaterial").val() == 1) {//MaterialType - Roller
            $("#MainContent_gvFabricCodeRollerList").find("tr").each(function (index, ele) {
                $(this).find("td,th").each(function (tdIndex, element) {
                    if (tdIndex == 15) {
                        $(this).hide();
                    }
                    else if (tdIndex == 8 || tdIndex == 9 || tdIndex == 10 || tdIndex == 11) {
                        $(this).show();
                    }
                    else if (tdIndex == 4 || tdIndex == 5 || tdIndex == 6 || tdIndex == 7) {
                        $(this).hide();
                    }
                    else {
                        $(this).show();
                    }
                });
            });
        }
        else {//MaterialType - Timber Or FernWood
            $("#MainContent_gvFabricCodeList").find("tr").each(function (index, ele) {
                $(this).find("td,th").each(function (tdIndex, element) {
                    if (tdIndex == 12) {
                        $(this).hide();
                    }
                    else if (tdIndex == 8 || tdIndex == 9) {
                        $(this).show();
                    }
                    else if (tdIndex == 6 || tdIndex == 7) {
                        $(this).hide();
                    }
                    else {
                        $(this).show();
                    }
                });
            });
        }
    }
}

$(window).resize(function () {
    onWindowLoadOrResize(true);
});

$(window).load(function () {
    onWindowLoadOrResize(false);
});

function onWindowLoadOrResize(isReSize) {
    if ($("#MainContent_ddlmaterial").val() == 1) {
        CloneAndShowFooter("#MainContent_gvFabricCodeRollerList", 4, isReSize)
    }
    else {
        CloneAndShowFooter("#MainContent_gvFabricCodeList", 6, isReSize)
    }
}

function CloneAndShowFooter(elementId, colspan, isReSize) {
    if ($(elementId + " tr td").length == 0) return;
    $("#tblfooter").width($(elementId).width());
    var footerTableRow = $(elementId + " tr:nth-child(2)").clone();
    $(footerTableRow).find("td").each(function (tdIndex, element) {
        var mainTblWidth = $(elementId + " tr:nth-child(2) td")[tdIndex].clientWidth - 10;
        $(this).width(mainTblWidth);
        if (isReSize) {
            return;
        }
        $(this).css("border", "0");
        $(this).html('');
        if (tdIndex == 0) {
            $(this).attr("colspan", colspan);
            $(this).css("text-align", "right");
            $(this).html('Supply and Installation Price:')
        }
        if (colspan == 4) {
            if (tdIndex > 0 && tdIndex <= 3) {
                $(this).remove();
            }
            if (tdIndex > 3 && tdIndex < 12) {
                $(this).css("text-align", "right");
                var txtHtml = "<input id='txtFooter_" + tdIndex + "' type='text' value = '0.00' style='width: 70px;text-align:right;' onblur='convertThisElementValueToDecimal(this);setValuesSupplyAndInstallationToGrid(this);' onkeypress='return check_digit(event,this,8,3);'/>";
                $(this).html(txtHtml);
            }
        }
        else if (colspan == 6) {
            if (tdIndex > 0 && tdIndex <= 5) {
                $(this).remove();
            }
            if (tdIndex > 5 && tdIndex < 10) {
                $(this).css("text-align", "right");
                var txtHtml = "<input id='txtFooter_" + tdIndex + "' type='text' value = '0.00' style='width: 70px;text-align:right;' onblur='convertThisElementValueToDecimal(this);setValuesSupplyAndInstallationToGrid(this);' onkeypress='return check_digit(event,this,8,3);'/>";
                $(this).html(txtHtml);
            }
        }
    });
    if (!isReSize) {
        $("#tblfooter").append(footerTableRow);
    }
}

//highlight the selected row
function rowHighlight($row) {
    var $table = (".InsertUpdateDeleteGrid");
    $('tbody tr:odd td', $table).removeClass('active');
    $('tbody tr:even td', $table).removeClass('active');
    $('td', $row).addClass('active');
    $selectedRow = $row;
    setSupplyAndInstallationPrice($row);
}

function setSupplyAndInstallationPrice($row) {
    if ($("#MainContent_ddlmaterial").val() == 1) {//MaterialType - Roller
        $('td > input', $row).each(function (index, element) {
            if (index == 8 || index == 9 || index == 10 || index == 11) {
                $("#txtFooter_" + index).val($(this).val());
                var invisibletxtBoxIndex = index - 4;
                $("#txtFooter_" + invisibletxtBoxIndex).val($(this).val());
            }
        });
    }
    else {//MaterialType - Timber Or FernWood
        $('td > input', $row).each(function (index, element) {
            if (index == 8 || index == 9) {
                $("#txtFooter_" + index).val($(this).val());
                var invisibletxtBoxIndex = index - 2;
                $("#txtFooter_" + invisibletxtBoxIndex).val($(this).val());
            }
        });
    }
}

function setValuesSupplyAndInstallationToGrid(txtBox) {
    if ($selectedRow == null) return;
    var index = $(txtBox).attr("id").split("_")[1];
    var tdIndex = parseInt(index) + 1;
    if ($("#MainContent_ddlmaterial").val() == 1) {//MaterialType - Roller       
        if (index == 8 || index == 9 || index == 10 || index == 11) {
            $selectedRow.find("td:nth-child(" + tdIndex + ") > input").val($(txtBox).val());
        }
        else if (index == 4 || index == 5 || index == 6 || index == 7) {
            var invisibletxtBoxIndex = parseInt(tdIndex) + 4;
            $selectedRow.find("td:nth-child(" + invisibletxtBoxIndex + ") > input").val($(txtBox).val());
        }
    }
    else {//MaterialType - Timber Or FernWood
        if (index == 8 || index == 9) {
            $selectedRow.find("td:nth-child(" + tdIndex + ") > input").val($(txtBox).val());
        }
        else if (index == 6 || index == 7) {
            var invisibletxtBoxIndex = parseInt(tdIndex) + 2;
            $selectedRow.find("td:nth-child(" + invisibletxtBoxIndex + ") > input").val($(txtBox).val());
        }
    }
}


function save() {
    if (isValid()) {
        var fabricCodeDetails = [];

        $(".InsertUpdateDeleteGrid tbody tr").each(function (trindex, element) {
            if (trindex > 0) {
                var fcDetail = new FabricCodeUIMapper();
                var index = trindex - 1;
                fcDetail.fc_code = $(this).find("input[id*=txtCode_]").val();
                fcDetail.fc_type = $("#MainContent_ddlmaterial").val();
                fcDetail.fc_desc = $(this).find("input[id*=txtDescription_]").val();
                fcDetail.fc_colour = $(this).find("input[id*=txtColor_]").val();
                fcDetail.fc_unitcost = $(this).find("input[id*=txtUnitCost_]").val();
                fcDetail.fc_unitprice = $(this).find("input[id*=txtunitprice_]").val();
                fcDetail.fc_unitprice2 = $(this).find("input[id*=txtunitprice2_]").val();

                fcDetail.fc_instprice = $(this).find("input[id*=txtinstprice_]").val();
                fcDetail.fc_instprice2 = $(this).find("input[id*=txtinstprice2_]").val();

                fcDetail.fc_width = $(this).find("input[id*=txtwidth_]").val();
                fcDetail.fc_rmk = $(this).find("input[id*=txtrmk_]").val();
                fcDetail.fc_min_width = null;

                if ($("#MainContent_ddlmaterial").val() == 1) {
                    fcDetail.fc_unitprice3 = $(this).find("input[id*=txtunitprice3_]").val();
                    fcDetail.fc_unitprice4 = $(this).find("input[id*=txtunitprice4_]").val();
                    fcDetail.fc_instprice3 = $(this).find("input[id*=txtinstprice3_]").val();
                    fcDetail.fc_instprice4 = $(this).find("input[id*=txtinstprice4_]").val();
                    fcDetail.fc_size = null;
                    fcDetail.primaryKey = $($(this)[0].cells[15]).html();
                }
                else {
                    fcDetail.fc_size = $(this).find("input[id*=txtSize_]").val();
                    fcDetail.fc_unitprice3 = "0.00";
                    fcDetail.fc_unitprice4 = "0.00";
                    fcDetail.fc_instprice3 = "0.00";
                    fcDetail.fc_instprice4 = "0.00";
                    fcDetail.primaryKey = $($(this)[0].cells[12]).html();
                }

                fabricCodeDetails.push(fcDetail);
            }
        });
        var str = '{ "fabricCodeDetails": ' + JSON.stringify(fabricCodeDetails) + '  }';

        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "FabricCodeAddEdit.aspx/SaveFabricCode",
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

function isValid() {
    var uniqueValues = {};
    var listOfValues = [];
    var isNotValid = false;
    $(".InsertUpdateDeleteGrid tbody tr").each(function (index, element) {
        if (index != 0 && !isNotValid && index != $(".InsertUpdateDeleteGrid tbody tr").length - 1) {
            var itemval = $(this).find("td:first > input:first").val();
            if ($("#MainContent_ddlmaterial").val() == 1) {//MaterialType - Roller 
                if (!itemval.match("^RB-")) {
                    alert("Please Enter 'RB-' as the starting charactors in the FC Code for Roller blind!");
                    isNotValid = true;
                }
            }
            if ($.trim(itemval) == "") {
                alert("You tried to assign the Null value to a variable that is not a Variant data type.");
                isNotValid = true;
            }

            if (!uniqueValues[itemval]) {
                uniqueValues[itemval] = true;
                listOfValues.push(itemval);
            }
            else {
                alert("Duplicates Fabric Code Found! Remove the Duplicates");
                isNotValid = true;
            }
        }
    });
    return !isNotValid;
}

function previewPriceList() {
    var id = new Date().getTime();
    var screenH = window.screen.height - 110;
    var screenW = 998;
    var leftPos = window.screen.width - 10;
    leftPos = (leftPos - 998) / 2;
    var rdbPriceOpt;
    $("input[id*='rdbPriceOption']").each(function () {
        if ($(this).attr("checked") == "checked") {
            rdbPriceOpt = $(this).val();
        }
    });
    var feature = "toolbar=0,scrollbars=0,location=0,status=1,menubar=0,resizable=no,width=" + screenW + ",left = " + leftPos + ",height=" + screenH + ",top = 5";
    if (rdbPriceOpt == 1) {
        window.open("Preview.aspx?fctype=" + $("#MainContent_ddlmaterial").val() + "&priceOpt=" + rdbPriceOpt);
    }
    else {
        window.open("PreviewOthers.aspx?fctype=" + $("#MainContent_ddlmaterial").val() + "&priceOpt=" + rdbPriceOpt);
    }
    return false;
}