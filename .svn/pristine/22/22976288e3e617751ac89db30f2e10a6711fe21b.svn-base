
/************************************************
    CONFIGURACION DINAMICA DEL IFRAME
************************************************/
function ConfigurarFrame(idFrame, url) {

    if (document.getElementById(idFrame) != null) {
        //if (document.getElementById(idFrame).getAttribute("src").toString() == "about:blank") {
        document.getElementById(idFrame).setAttribute("src", url);
        //}
    }
}



var content_height = document.body.scrollHeight - 100;
//alert(content_height);
content_height = $(window).height() - 120;
document.getElementById('iframe_Contenido').style.height = content_height + "px";
// Reset iframe height after window resize
$(function () {
    $(window).resize(function () {
        content_height = $(window).height() - 120;
        //var content_height=document.body.scrollHeight-100;

        document.getElementById('iframe_Contenido').style.height = content_height + "px";
    });
});





/*=====================================
    QUERY'S INGRESO
  =====================================*/

function ModalCambiarClave(cod) {
    $('#modalCambiarClave').modal('show');
    ConfigurarFrame('iframe_CambiarClave', 'iframeCambiarClave.aspx?cod=' + cod)
}


/*=====================================
    QUERY'S MASTER PAGE
  =====================================*/

function ModalPerfilUsuario() {
    $('#con-close-modal').modal('show');
    ConfigurarFrame('iframe_Perfil', 'iframePerfilUsuario.aspx');
}

