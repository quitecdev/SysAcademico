
/*=====================================
    QUERY'S INSCRIPCION
  =====================================*/

$(document).ready(function () {
    $('#rootwizard').bootstrapWizard({
        'tabClass': 'nav nav-tabs navtab-wizard nav-justified bg-muted',
        'onNext': function (tab, navigation, index) {
            var $valid = $("#commentForm").valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            }
        }

    });


    jQuery('.date2').datepicker({
        format: "dd/mm/yyyy",
        language: "es"
    });

});


$(function () {
    var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
    $('#rootwizard a[href="#' + tabName + '"]').tab('show');
    $("#rootwizard a").click(function () {
        $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
    });
});



function ValidarCedula() {
    alert("El Documento de Identidad ingresado no es correcto.");
}



function PdfInscripcion(ruta) {
    $('#VisorPdf').modal('show');
    ConfigurarFrame('ProformaPdf', ruta)
}