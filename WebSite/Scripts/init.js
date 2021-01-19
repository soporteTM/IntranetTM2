/**
 * HOMER - Responsive Admin Theme
 * version 1.7
 *
 */

 Number.prototype.formatMoney = function (c, d, t) {
    var n = this,
    c = isNaN(c = Math.abs(c)) ? 2 : c,
    d = d == undefined ? "." : d,
    t = t == undefined ? "," : t,
    s = n < 0 ? "-" : "",
    i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "",
    j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
};


$(document).ready(function () {
 
    //// Handle minimalize sidebar menu
    //$('.hide-menu').click(function(event){
    //    event.preventDefault();
    //    if ($(window).width() < 769) {
    //        $("body").toggleClass("show-sidebar");
            
    //    } else {
    //        $("body").toggleClass("hide-sidebar");
    //        if ( $("body").hasClass("hide-sidebar"))
    //            $.cookie('menu', '1');
    //        else
    //            $.cookie('menu', '0');
    //    }
    //});

    // var MenuActivo = $.cookie('menu');
    //if (MenuActivo == "1") {
    // $("body").toggleClass("hide-sidebar");
    //} 

    $('form').parsley();

    if ($("table.dataTable thead tr").length > 0) {
        $('table.dataTable').dataTable();
    }

    if ($("table.dataTableBasic thead tr").length > 0) {
        $('table.dataTableBasic').dataTable({
            "bFilter": false,
            "bPaginate": false,
            "bSort": false,
            "bInfo": false,
            "bLengthChange": false
        });
    }

    if ($('.grillascrollY').find("thead tr").length > 0 && $('.grillascrollY').find("tbody tr").length > 0) {
        oPoppupGrillaSY = $('.grillascrollY').dataTable({
            "bJQueryUI": true,
            "bPaginate": false,
            "bFilter": false,
            "sPaginationType": "full_numbers",
            //"sDom": '<""f>t<"F"lp>',
            "scrollY": 228,// 285,
            "aaSorting": [[0, "asc"]],
            //"scrollCollapse": true,
            "bLengthChange": false
            //"sScrollXInner": "160%"    

        });
    }

    if ($('.grillascrollYa').find("thead tr").length > 0 && $('.grillascrollYa').find("tbody tr").length > 0) {
        oPoppupGrillaSY = $('.grillascrollYa').dataTable({
            "bJQueryUI": true,
            "bPaginate": false,
            "bFilter": false,
            "sPaginationType": "full_numbers",
            //"sDom": '<""f>t<"F"lp>',
            "scrollY": 285,// 285,
            "aaSorting": [[0, "asc"]],
            //"scrollCollapse": true,
            "bLengthChange": false
            //"sScrollXInner": "160%"    

        });
    }

    $(".number").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
        // Allow: Ctrl+C
            (e.keyCode == 67 && e.ctrlKey === true) ||
        // Allow: Ctrl+X
            (e.keyCode == 88 && e.ctrlKey === true) ||
        // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });


    $(".money").change(function (e) {

        var valor = parseFloat($(this).val());
        if (valor != null && valor != NaN) {
            

            if ($(this).attr("data-total") !== null) {
                var total = parseFloat($(this).data("total"));
            
                if ( valor <= 0 )
                    $(this).val(total.formatMoney(2, '.', ','));
                else if ( valor > total )
                    $(this).val(total.formatMoney(2, '.', ','));
                else
                     $(this).val(valor.formatMoney(2, '.', ','));
            
            }
            else{
                
                $(this).val(valor.formatMoney(2, '.', ','));
            }
        
        
        }
        else {
            $(this).val("");
        }

       


    });


    $(".money3").change(function (e) {

        var valor = parseFloat($(this).val());
        if (valor != null && valor != NaN) {
            $(this).val(valor.formatMoney(3, '.', ','));            
        }
        else {
            $(this).val("");
        }

       


    });

     

    // Set minimal height of #wrapper to fit the window
    setTimeout(function () {
        fixWrapperHeight();
    });

    
    // Move modal to body
    // Fix Bootstrap backdrop issu with animation.css
    $('.modal').appendTo("form");

    $("#btnContinuarConfirmModal").click(function () {

        var name = $(this).attr("name");
        name = name.replace("javascript:__doPostBack('", "");
        name = name.replace("','')", "");

        __doPostBack(name, '');
    });

});

 
$(window).bind("resize click", function () {

   
    // Waint until metsiMenu, collapse and other effect finish and set wrapper height
    setTimeout(function () {
        fixWrapperHeight();
    }, 300);
})

function fixWrapperHeight() {

    //// Get and set current height
    //var headerH = 62;
    //var navigationH = $("#navigation").height();
    //var contentH = $(".content").height();

    //// Set new height when contnet height is less then navigation
    //if (contentH < navigationH) {
    //    $("#wrapper").css("min-height", navigationH + 'px');
    //}

    //// Set new height when contnet height is less then navigation and navigation is less then window
    //if (contentH < navigationH && navigationH < $(window).height()) {
    //    $("#wrapper").css("min-height", $(window).height() - headerH  + 'px');
    //}

    //// Set new height when contnet is higher then navigation but less then window
    //if (contentH > navigationH && contentH < $(window).height()) {
    //    $("#wrapper").css("min-height", $(window).height() - headerH + 'px');
    //}
}


 

function JAlert(mtext,mtitle,mtype){   
    //alert(mtype); 
    $("#ModalAlert .modal-body span").hide();
    $("#ModalAlert .modal-body span.text-" + mtype).show();
    $("#ModalAlert .modal-body h3").attr("class", "text-" + mtype)
    $("#ModalAlert .modal-body h3").html(mtitle);
    $("#ModalAlert .modal-body p").html(mtext);
    $("#ModalAlert").modal("show");
}

function JConfirm(mtext, mtitle, btn) {

    var nameControl = $(btn).attr("name");

    if (nameControl == null || nameControl == "")
        nameControl = $(btn).attr("href");

    $("#btnContinuarConfirmModal").attr("name", nameControl);
    $("#ModalConfirm .modal-body h3").html(mtitle);
    $("#ModalConfirm .modal-body p").html(mtext);
    $("#ModalConfirm").modal("show");
}

 

function JToastr(mtext, mtitle, mtype) {

    var shortCutFunction = mtype;
    var msg = mtext;
    var title = mtitle;
  

    toastr.options = {
        closeButton: true,
        debug: false,
        newestOnTop: false,
        progressBar: false,
        positionClass: 'toast-top-right',
        preventDuplicates: false,
        onclick: null
    };

   

    var $toast = toastr[shortCutFunction](msg, title); // Wire up an event handler to a button in the toast, if it exists
    $toastlast = $toast;

    if (typeof $toast === 'undefined') {
        return;
    }

    if ($toast.find('#okBtn').length) {
        $toast.delegate('#okBtn', 'click', function () {
            alert('you clicked me. i was toast #' + toastIndex + '. goodbye!');
            $toast.remove();
        });
    }
    if ($toast.find('#surpriseBtn').length) {
        $toast.delegate('#surpriseBtn', 'click', function () {
            alert('Surprise! you clicked me. i was toast #' + toastIndex + '. You could perform an action here.');
        });
    }
    if ($toast.find('.clear').length) {
        $toast.delegate('.clear', 'click', function () {
            toastr.clear($toast, { force: true });
        });
    }

}