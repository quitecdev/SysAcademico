<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SysAcademico.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">

    <!-- App Favicon -->
    <link rel="shortcut icon" href="assets/images/favicon.ico">

    <!-- App title -->
    <title>CAS - Ingreso</title>

    <!-- Sweet Alert css -->
    <link href="assets/plugins/bootstrap-sweetalert/sweet-alert.css" rel="stylesheet" type="text/css" />

    <!-- App CSS -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/login.css" rel="stylesheet" />
    <script src="assets/js/modernizr.min.js"></script>

    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
</head>
<body>
    <div class="container-fluid contenedor">
        <form id="Form1" runat="server" method="post" action="" role="login">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
                function endReq(sender, args) {
                    //$(document).ready(function () {
                    //    $('.ValidarClave').parsley();
                    //});
                }
            </script>


            <div class="row">
                <div class="col-xs-12 col-sm-6 col-md-8 img-fondo-contenido">
                    <img src="assets/images/IMG_0042.jpg" style="width: 100%; height: 100vh;" />
                </div>
                <div class="col-xs-12 col-sm-6 col-md-4 login-contenido">
                    <section id="logo">
                        <a href="#">
                            <img src="assets/images/CAS-logo.png" alt="" />
                        </a>
                    </section>
                    <section class="login">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:TextBox runat="server" ID="txt_usuario" placeholder="Ingrese su nombre de usuario" required class="form-control-login form-control"></asp:TextBox>
                                    <span class="glyphicon glyphicon-user"></span>
                                </div>

                                <div>
                                    <asp:TextBox runat="server" ID="txt_clave" placeholder="Introducir su contraseña" TextMode="Password" required class="form-control-login form-control"></asp:TextBox>
                                    <span class="glyphicon glyphicon-lock"></span>
                                </div>
                                <asp:Button runat="server" ID="bnt_ingresar" class="btn btn-block btn-custom" Text="Inicia sesión ahora" OnClick="bnt_ingresar_Click" />

                                <div class="form-group less-space">
                                    <asp:CheckBox ID="chkRememberMe" Checked="true" runat="server" />
                                    Recordarme en este dispositivo
                                </div>
                                <section>
                                    <a onclick="ConfigurarFrame('iframe_EnviarClave', 'iframeEnviarClave.aspx')" href="#" data-toggle="modal" data-target="#modalEnviarClave">¿ Olvidaste tu contraseña ?</a>
                                </section>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </section>
                    <div class="mypanel"></div>
                    <div id="modalCambiarClave" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                    <h4 class="modal-title">Cambiar Contraseña</h4>
                                </div>
                                <div class="modal-body">
                                    <iframe id="iframe_CambiarClave" height="178" width="100%" src="about:blank" scrolling="no" frameborder="0"></iframe>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="modalEnviarClave" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog" style="width: 30%;">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                    <h4 class="modal-title">Enviar Contraseña</h4>
                                </div>
                                <div class="modal-body">
                                    <iframe id="iframe_EnviarClave" height="120" width="100%" src="about:blank" scrolling="no" frameborder="0"></iframe>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </form>
    </div>
    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/detect.js"></script>
    <script src="assets/js/fastclick.js"></script>
    <script src="assets/js/jquery.slimscroll.js"></script>
    <script src="assets/js/jquery.blockUI.js"></script>
    <script src="assets/js/waves.js"></script>
    <script src="assets/js/wow.min.js"></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script src="assets/js/General.js"></script>


    <script>


        $(function () {
            $("#get_btn").click(function () {
                $.ajax({
                    url: 'https://api.myjson.com/bins/14uydt',
                    type: 'POST',
                    dataType: 'JSON',
                    success: function (data) {
                        var canciones = "<ul>";
                        for (var c = 0; c < data.length; c++) {
                            var infocancion = "<li>" + data[c].label;
                            infocancion += " - " + data[c].value;
                            canciones += infocancion;
                        }
                        canciones += "</ul>";
                        $("#salida").html(canciones);
                    }
                })
            });
        });
    </script>

</body>
</html>
