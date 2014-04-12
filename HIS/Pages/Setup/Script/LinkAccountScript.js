$(document).ready(function () {
    $("#MainDiv").hide();
    $("input[id*=rdbLnkAccts_]").each(function () {
        if ($(this).attr("checked")) {
            $("#MainDiv").show();
            ShowRespectiveDiv(this);
        }
    });
    $("input[id*=rdbLnkAccts_]").click(function () {
        $("#MainDiv").show();
        ShowRespectiveDiv(this);
    });
});

function ShowRespectiveDiv(element) {
    hideAllDivs();
    clearCtrls();

    var selectedVal = $(element).val();
    if (selectedVal == "1") {
        $("#legend").text("Payables Linked Accounts");
        BindForVendorsPurchases();
        $("#div1").show();
    }
    else if (selectedVal == "2") {
        $("#legend").text("Receivables Linked Accounts");
        BindForCustomerSales();
        $("#div2").show();
    }
    else if (selectedVal == "3") {
        $("#legend").text("Payables Linked Accounts");
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "FinanceSettingSetup.aspx/GetBankAccCodes",
            data: {},
            dataType: "json",
            success: function (data) {
                $("#ddlExchangeGainLoss").append('<option value=""></option>');
                $.each(data.d, function (i, code) {
                    $("#ddlExchangeGainLoss").append('<option value=' + i + '>' + code + '</option>');
                });
                var str = '{ "value": "currency_loss"  }';
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                    data: str,
                    dataType: "json",
                    success: function (data) {
                          $("select#ddlExchangeGainLoss").val(data.d.toString());
                    },
                    error: function (result) {
                        alert("error");
                    }
                });
            },
            error: function (result) {
                alert("error");
            }
        });
        $("#div3").show();
    }
    else if (selectedVal == "4") {
        $("#legend").text("Closing/Opening Stock Linked Accounts");
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "FinanceSettingSetup.aspx/GetBankAccCodes",
            data: {},
            dataType: "json",
            success: function (data) {
                $("#ddlClosingStock").append('<option value=""></option>');
                $("#ddlOpeningStock").append('<option value=""></option>');
                $("#ddlInventoryStock").append('<option value=""></option>');

                $.each(data.d, function (i, code) {
                    $("#ddlClosingStock").append('<option value=' + i + '>' + code + '</option>');
                    $("#ddlOpeningStock").append('<option value=' + i + '>' + code + '</option>');
                    $("#ddlInventoryStock").append('<option value=' + i + '>' + code + '</option>');
                });
                var str = '{ "value": "closing_stock"  }';
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                    data: str,
                    dataType: "json",
                    success: function (data) {
                        $("select#ddlClosingStock").val(data.d.toString());
                        str = '{ "value": "opening_stock"  }';
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                            data: str,
                            dataType: "json",
                            success: function (data) {
                                $("select#ddlOpeningStock").val(data.d.toString());
                                str = '{ "value": "inventory_acc"  }';
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json;",
                                    url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                                    data: str,
                                    dataType: "json",
                                    success: function (data) {
                                        $("select#ddlInventoryStock").val(data.d.toString());
                                    },
                                    error: function (result) {
                                        alert("error");
                                    }
                                });
                            },
                            error: function (result) {
                                alert("error");
                            }
                        });
                    },
                    error: function (result) {
                        alert("error");
                    }
                });               
            },
            error: function (result) {
                alert("error");
            }
        });
        $("#div4").show();
    }
}

function hideAllDivs() {
    try {
        $("#div1").hide();
        $("#div2").hide();
        $("#div3").hide();
        $("#div4").hide();
    }
    catch (ex) {
    }
}

function saveExchangeGainOrLoss() {
    if ($("#ddlExchangeGainLoss").val() == "") {
        alert("Invalid Selection!");
    }
    else {
        var str = '{"type": "currency_loss", "value": ' + JSON.stringify($("#ddlExchangeGainLoss").val()) + ' }';
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: "FinanceSettingSetup.aspx/SetAccGLSetup",
            data: str,
            dataType: "json",
            success: function (data) {
                alert("Exchange Gain/Loss Saved Successfully!");
            },
            error: function (result) {
                alert("error");
            }
        });
    }
    return false;
}

function saveOpenClosingStock() {
    var isSaveSuccessful = true;
    var str = '{"type": "closing_stock", "value": ' + JSON.stringify($("#ddlClosingStock").val()) + ' }';
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/SetAccGLSetup",
        data: str,
        dataType: "json",
        success: function (data) {
            str = '{"type": "opening_stock", "value": ' + JSON.stringify($("#ddlOpeningStock").val()) + ' }';
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "FinanceSettingSetup.aspx/SetAccGLSetup",
                data: str,
                dataType: "json",
                success: function (data) {
                    str = '{"type": "inventory_acc", "value": ' + JSON.stringify($("#ddlInventoryStock").val()) + ' }';
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "FinanceSettingSetup.aspx/SetAccGLSetup",
                        data: str,
                        dataType: "json",
                        success: function (data) {
                            //alert("Save Successful!");
                        },
                        error: function (result) {
                            isSaveSuccessful = false;
                            alert("Error  in saving Inventory Stock");
                        }
                    });
                },
                error: function (result) {
                    isSaveSuccessful = false;
                    alert("Error in saving Closing Stock");
                }
            });
        },
        error: function (result) {
            isSaveSuccessful = false;
            alert("Error in saving Opening Stock");
        }
    });
       
    if (isSaveSuccessful)
        alert("Save Successful!");
    return false;
}

function BindForVendorsPurchases() {
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/GetBankAccCodesForVendorsPurchasesCUstomers",
        data: {},
        dataType: "json",
        success: function (data) {
            $("#ddlBankAccount").append('<option value=""></option>');
            $.each(data.d, function (i, code) {
                $("#ddlBankAccount").append('<option value=' + i + '>' + code + '</option>');
            });
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "FinanceSettingSetup.aspx/GetPayablesAccCodeList",
                data: {},
                dataType: "json",
                success: function (data) {
                    $("#ddlPayable").append('<option value=""></option>');
                    $("#ddlPayableOTH").append('<option value=""></option>');
                    $.each(data.d, function (i, code) {
                        $("#ddlPayable").append('<option value=' + i + '>' + code + '</option>');
                        $("#ddlPayableOTH").append('<option value=' + i + '>' + code + '</option>');
                    });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "FinanceSettingSetup.aspx/GetAllAccCodeList",
                        data: {},
                        dataType: "json",
                        success: function (data) {
                            $("#ddlFrieght").append('<option value=""></option>');
                            $.each(data.d, function (i, code) {
                                $("#ddlFrieght").append('<option value=' + i + '>' + code + '</option>');
                            });
                            var str = '{ "value": "payable"  }';
                            $.ajax({
                                type: "POST",
                                contentType: "application/json;",
                                url: "FinanceSettingSetup.aspx/GetAccGLSetupValuesByGLType",
                                data: str,
                                dataType: "json",
                                success: function (data) {
                                    $.each(data.d, function (i, code) {
                                        if (i == "gl_principal_bank") {
                                            $("select#ddlBankAccount").val(code);
                                        }
                                        else if (i == "gl_acc_code") {
                                            $("select#ddlPayable").val(code);
                                        }
                                        else if (i == "gl_freight") {
                                            $("select#ddlFrieght").val(code);
                                        }
                                        else if (i == "gl_discount") {
                                            $("#txtDiscount").val(code);
                                        }
                                    });
                                    str = '{ "value": "payable_oth"  }';
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json;",
                                        url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                                        data: str,
                                        dataType: "json",
                                        success: function (data) {
                                            $.each(data.d, function (i, code) {
                                                $("select#ddlPayableOTH").val(data.d.toString());
                                            });

                                        },
                                        error: function (result) {
                                            alert("error");
                                        }
                                    });
                                },
                                error: function (result) {
                                    alert("error");
                                }
                            });
                        },
                        error: function (result) {
                            alert("Error in getting Frieght Expenses Listing");
                        }
                    });
                },
                error: function (result) {
                    alert("Error in getting Payables Listing");
                }
            });
        },
        error: function (result) {
            alert("Error in getting Principal Bank Acc Listing");
        }
    });
}

function BindForCustomerSales() {
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/GetBankAccCodesForVendorsPurchasesCUstomers",
        data: {},
        dataType: "json",
        success: function (data) {
            $("#ddlBankAccForCus").append('<option value=""></option>');
            $.each(data.d, function (i, code) {
                $("#ddlBankAccForCus").append('<option value=' + i + '>' + code + '</option>');
            });
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "FinanceSettingSetup.aspx/GetReceivablesAccCodeList",
                data: {},
                dataType: "json",
                success: function (data) {
                    $("#ddlReceivable").append('<option value=""></option>');
                    $("#ddlReceivableOTH").append('<option value=""></option>');

                    $.each(data.d, function (i, code) {
                        $("#ddlReceivable").append('<option value=' + i + '>' + code + '</option>');
                        $("#ddlReceivableOTH").append('<option value=' + i + '>' + code + '</option>');
                    });
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "FinanceSettingSetup.aspx/GetAllAccCodeList",
                        data: {},
                        dataType: "json",
                        success: function (data) {
                            $("#ddlFreightRevenue").append('<option value=""></option>');
                            $("#ddlSalesDiscount").append('<option value=""></option>');
                            $("#ddlBankCharges").append('<option value=""></option>');
                            
                            $.each(data.d, function (i, code) {
                                $("#ddlFreightRevenue").append('<option value=' + i + '>' + code + '</option>');
                                $("#ddlSalesDiscount").append('<option value=' + i + '>' + code + '</option>');
                                $("#ddlBankCharges").append('<option value=' + i + '>' + code + '</option>');
                            });

                            var str = '{ "value": "receivable"  }';
                            $.ajax({
                                type: "POST",
                                contentType: "application/json;",
                                url: "FinanceSettingSetup.aspx/GetAccGLSetupValuesByGLType",
                                data: str,
                                dataType: "json",
                                success: function (data) {
                                    $.each(data.d, function (i, code) {
                                        if (i == "gl_principal_bank") {
                                            $("select#ddlBankAccForCus").val(code);
                                        }
                                        else if (i == "gl_acc_code") {
                                            $("select#ddlReceivable").val(code);
                                        }
                                        else if (i == "gl_freight") {
                                            $("select#ddlFreightRevenue").val(code);
                                        }
                                        else if (i == "gl_discount") {
                                            $("select#ddlSalesDiscount").val(code);
                                        }
                                    });
                                    str = '{ "value": "receivable_oth"  }';
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json;",
                                        url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                                        data: str,
                                        dataType: "json",
                                        success: function (data) {
                                            $.each(data.d, function (i, code) {
                                                $("select#ddlReceivableOTH").val(data.d.toString());
                                            });
                                            str = '{ "value": "bank_charges"  }';
                                            $.ajax({
                                                type: "POST",
                                                contentType: "application/json;",
                                                url: "FinanceSettingSetup.aspx/GetAccGLSetupByGLType",
                                                data: str,
                                                dataType: "json",
                                                success: function (data) {
                                                    $.each(data.d, function (i, code) {
                                                        $("select#ddlBankCharges").val(data.d.toString());
                                                    });

                                                },
                                                error: function (result) {
                                                    alert("error");
                                                }
                                            });
                                        },
                                        error: function (result) {
                                            alert("error");
                                        }
                                    });
                                },
                                error: function (result) {
                                    alert("error");
                                }
                            });
                        },
                        error: function (result) {
                            alert("Error in getting Frieght Expenses/Sales Discount Listing");
                        }
                    });
                },
                error: function (result) {
                    alert("Error in getting Receivables Listing");
                }
            });
        },
        error: function (result) {
            alert("Error in getting Principal Bank Acc Listing");
        }
    });

}

function saveVendorsPurchases() {
    var uiMapperDetails = [];

    var detail = new GLUIMapper();
    detail.gl_setup_type = "payable";
    detail.gl_principal_bank = $("#ddlBankAccount").val();
    detail.gl_acc_code = $("#ddlPayable").val();
    detail.gl_freight = $("#ddlFrieght").val();
    detail.gl_discount = $("#txtDiscount").val();
    uiMapperDetails.push(detail);

    detail = new GLUIMapper();
    detail.gl_setup_type = "payable_oth";
    detail.gl_principal_bank = $("#ddlBankAccount").val();
    detail.gl_acc_code = $("#ddlPayableOTH").val();
    detail.gl_freight = $("#ddlFrieght").val();
    detail.gl_discount = $("#txtDiscount").val();
    uiMapperDetails.push(detail);

    var str = '{ "uiMapper": ' + JSON.stringify(uiMapperDetails) + '  }';
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/SaveDetails",
        data: str,
        dataType: "json",
        success: function (data) {
            alert("Save Success");
        },
        error: function (result) {
            alert("error");
        }
    });
    return false;
}

function saveCustomerSales() {
    var uiMapperDetails = [];

    var detail = new GLUIMapper();
    detail.gl_setup_type = "receivable";
    detail.gl_principal_bank = $("#ddlBankAccForCus").val();
    detail.gl_acc_code = $("#ddlReceivable").val();
    detail.gl_freight = $("#ddlFreightRevenue").val();
    detail.gl_discount = $("#ddlSalesDiscount").val();
    uiMapperDetails.push(detail);

    detail = new GLUIMapper();
    detail.gl_setup_type = "receivable_oth";
    detail.gl_principal_bank = $("#ddlBankAccForCus").val();
    detail.gl_acc_code = $("#ddlReceivableOTH").val();
    detail.gl_freight = $("#ddlFreightRevenue").val();
    detail.gl_discount = $("#ddlSalesDiscount").val();
    uiMapperDetails.push(detail); 

    var str = '{ "uiMapper": ' + JSON.stringify(uiMapperDetails) + '  }';
    $.ajax({
        type: "POST",
        contentType: "application/json;",
        url: "FinanceSettingSetup.aspx/SaveDetails",
        data: str,
        dataType: "json",
        success: function (data) {
            if ($("#ddlBankCharges").val() == "") {
                alert("Save Success");
            }
            else {
                var str = '{"type": "bank_charges", "value": ' + JSON.stringify($("#ddlBankCharges").val()) + ' }';
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "FinanceSettingSetup.aspx/SetAccGLSetup",
                    data: str,
                    dataType: "json",
                    success: function (data) {
                        alert("Save Success");
                    },
                    error: function (result) {
                        alert("error");
                    }
                });
            }
           
        },
        error: function (result) {
            alert("error");
        }
    });
    return false;
}

function clearCtrls() {
    $("#ddlBankAccount").html('');
    $("#ddlPayable").html('');
    $("#ddlPayableOTH").html('');
    $("#ddlFrieght").html('');
    $("#ddlBankAccForCus").html('');
    $("#ddlReceivable").html('');
    $("#ddlReceivableOTH").html('');
    $("#ddlFreightRevenue").html('');
    $("#ddlSalesDiscount").html('');
    $("#ddlExchangeGainLoss").html('');
    $("#ddlBankCharges").html('');
    $("#ddlClosingStock").html('');
    $("#ddlOpeningStock").html('');
    $("#ddlInventoryStock").html('');
}

GLUIMapper = function () {
    this.gl_setup_type = null;
    this.gl_principal_bank = null;
    this.gl_acc_code = null;
    this.gl_freight = null;
    this.gl_discount = null;
}