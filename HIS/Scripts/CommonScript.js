function HideAndShowUsingJQuery(element, Opt) {
    var ele = $(element);
    var midelementToHideOrShow = $(ele.parents("table").eq(1)).find("tr:nth-child(2):first");
    var btmelementToHideOrShow = $(ele.parents("table").eq(1)).find("tr:nth-child(3):last");

    if (Opt == 'O') {
        midelementToHideOrShow.show();
        btmelementToHideOrShow.show();
        ele.prev().show();
    }
    else if (Opt == 'C') {
        midelementToHideOrShow.hide();
        btmelementToHideOrShow.hide();
        ele.next().show();
    }
    ele.hide();
}

function convertThisElementValueToDecimal(element) {
    var value = $(element).val();

    if (value == "" || value.toString() == NaN.toString()) { $(element).val("0"); }
    var num = parseFloat($(element).val());
    var cleanNum = num.toFixed(2);
    $(element).val(cleanNum);
}

function NumberOnly() {
    var AsciiValue = event.keyCode
    if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
        event.returnValue = true;
    else
        event.returnValue = false;
}

function check_digit(e, obj, intsize, deczize) {

    var keycode;

    if (window.event) keycode = window.event.keyCode;
    else if (e) keycode = e.which;
    else return true;
    var fieldval = (obj.value);
    var dots = fieldval.split(".").length;
    if (keycode == 46) {
        if (dots > 1) {

            return false;
        } else {

            return true;
        }
    }
    if (keycode == 8 || keycode == 9 || keycode == 46 || keycode == 13) // back space, tab, delete, enter 
    {
        return true;
    }
    if ((keycode >= 32 && keycode <= 45) || keycode == 47 || (keycode >= 58 && keycode <= 127)) {
        return false;
    }

    if (fieldval == "0" && keycode == 48) {
        return false;
    }
    if (fieldval.indexOf(".") != -1) {
        if (keycode == 46)
            return false;

        var splitfield = fieldval.split(".");

        if (splitfield[1].length >= deczize && keycode != 8 && keycode != 0) {
            alert("Number Of Deciaml Digits Exceeded!");
            return false;
        }
    }
    else if (fieldval.length >= intsize && keycode != 46) {
        alert("Number Of Digits Exceeded!");
        return false;
    }
    else return true;
}

function highlightRowOnMouseOver() {
    $(".InsertUpdateDeleteGrid tbody tr:odd").hover(
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).addClass('highlight');
     },
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).removeClass('highlight');
     });
    $(".InsertUpdateDeleteGrid tbody tr:even").hover(
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).addClass('highlight');
     },
     function () {
         if ($(this).index == 1) return;
         $('td', $(this)).removeClass('highlight');
     });
}

function formatTable() {
    $(".InsertUpdateDeleteGrid tbody tr").each(function (index, element) {
        if (index > 0) {
            if (index % 2 == 0) {
                $(this).removeClass("InsertUpdateDeleteGridrow");
                $(this).addClass("InsertUpdateDeleteGridrowAlt");
            }
            else {
                $(this).removeClass("InsertUpdateDeleteGridrowAlt");
                $(this).addClass("InsertUpdateDeleteGridrow");
            }
        }
    });
}