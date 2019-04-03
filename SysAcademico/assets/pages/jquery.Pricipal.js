/*___________________________________

    CERRAR SESION
  _____________________________________*/

function CerrarSesion() {
    sessionStorage.removeItem('USUARIO');
    $(location).attr("href", "Ingreso.aspx");
    Session.Contents.RemoveAll();
    response.clear();
    Session.abondon();
    response.write("Success");
    response.End();
}




var selector = "#menu li";

$(selector).click(function () {
    $(selector).removeClass('active');
    $(this).addClass('active');
});