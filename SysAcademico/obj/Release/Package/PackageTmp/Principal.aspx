<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="SysAcademico.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">

    <link rel="shortcut icon" href="assets/images/favicon.ico">

    <title>CAS - Sistema Acádemico</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />



    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
    <script src="assets/js/modernizr.min.js"></script>

</head>
<body onload="pageLoad();CallMe();">

    <div id="wrapper">
        <div class="topbar">

            <!-- LOGO -->
            <div class="topbar-left">
                <div class="text-center">
                    <a href="#" class="logo">
                        <span>
                            <img src="assets/images/CAS-logo.png" alt="logo" style="height: 46px;"></span>
                    </a>
                </div>
            </div>
            <!-- Button mobile view to collapse sidebar menu -->
            <div class="navbar navbar-default" role="navigation">
                <div class="container">
                    <div class="">
                        <div class="pull-left">
                            <button class="button-menu-mobile open-left waves-effect waves-light">
                                <i class="zmdi zmdi-menu"></i>
                            </button>
                            <span class="clearfix"></span>
                        </div>

                        <ul class="nav navbar-nav navbar-right pull-right">
                            <li>
                                <!-- Notification -->
                                <div class="notification-box">
                                    <ul class="list-inline m-b-0">
                                        <li>
                                            <a href="javascript:void(0);" class="right-bar-toggle">
                                                <i class="zmdi zmdi-notifications-none"></i>
                                            </a>
                                            <div class="noti-dot">
                                                <span class="dot"></span>
                                                <span class="pulse"></span>
                                                <%--<span class="badge badge-danger" id="badge_notificaciones"></span>--%>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <!-- End Notification bar -->
                            </li>

                            <li class="dropdown user-box">
                                <a href="" class="dropdown-toggle waves-effect waves-light profile " data-toggle="dropdown" aria-expanded="true">
                                    <asp:Image runat="server" ID="imgPerfil" ImageUrl="./assets/images/usuario.png" alt="user-img" class="img-circle user-img" />
                                    <div class="user-status away"><i class="zmdi zmdi-dot-circle"></i></div>
                                </a>

                                <ul class="dropdown-menu">
                                    <li><a href="#" onclick="javascript:ModalPerfilUsuario();"><i class="ti-user m-r-5"></i>Perfil</a></li>
                                    <li><a onclick="Salir();"><i class="ti-power-off m-r-5"></i>Cerrar sesión</a></li>
                                </ul>
                            </li>
                        </ul>

                    </div>
                </div>
            </div>
        </div>
        <!-- ============================================================== -->
        <!-- MENUS -->
        <!-- ============================================================== -->

        <div class="left side-menu">
            <div class="sidebar-inner slimscrollleft">

                <div id="sidebar-menu">
                    <ul runat="server" id="menu">
                        <%-- GENERACION DINAMICA --%>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
        <!-- ============================================================== -->
        <!-- CONTENIDO PAGINA -->
        <!-- ============================================================== -->
        <div class="content-page">
            <!-- Start content -->
            <div class="content">
                <div class="container">
                    <iframe id="iframe_Contenido" style="width: 100%; height: 100vh; position: relative;" src="about:blank" frameborder="0" allowfullscreen></iframe>
                </div>
            </div>
            <footer class="footer">
                2017 © CAS. Design by <a href="http://www.quitec.com.ec/" target="_blank" class="text-muted">QUITEC</a>
            </footer>

        </div>
        <!-- ============================================================== -->
        <!-- NOTIFICACION -->
        <!-- ============================================================== -->
        <div class="side-bar right-bar">
            <a href="javascript:void(0);" class="right-bar-toggle">
                <i class="zmdi zmdi-close-circle-o"></i>
            </a>
            <h4 class="">NOTIFICACIONES</h4>
            <div class="notification-list nicescroll">
                <ul id="ul_noti" class="list-group list-no-border user-list">
                    <%--                    <li class="list-group-item">
                        <a href="#" class="user-list-item">
                            <div class="icon">
                                <i class="zmdi zmdi-account"></i>
                            </div>
                            <div class="user-desc">
                                <span class="name">Nueva Inscripción</span>
                                <span class="desc">Hay nuevos ajustes disponibles</span>
                                <span class="time">5 hours ago</span>
                            </div>
                        </a>
                    </li>--%>
                </ul>
            </div>
        </div>
    </div>

    <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="location.reload(true);" aria-hidden="true">×</button>
                    <h4 class="modal-title">Perfil Usuario</h4>
                </div>
                <div class="modal-body">
                    <%--<iframe id="iframe_Perfil" src="about:blank" scrolling="no" frameborder="0"></iframe>--%>
                    <div class="embed-responsive embed-responsive-16by9">
                        <iframe id="iframe_Perfil" class="embed-responsive-item" src="about:blank" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.modal -->


    <div id="modalBuscar" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalBuscarLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 65%;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="modalBuscarLabel">Buscar Inscripciones</h4>
                </div>
                <div class="modal-body">
                    <iframe id="iframe_BuscarInscripciones" height="560" width="100%" src="about:blank" scrolling="no" frameborder="0"></iframe>
                </div>
            </div>
        </div>
    </div>


    <div id="panel-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content p-0 b-0">
                <div class="panel panel-color panel-primary">
                    <div class="panel-heading">
                        <button type="button" class="close m-t-5" data-dismiss="modal" aria-hidden="true">×</button>
                        <h3 class="panel-title">NOTIFICACIÓN</h3>
                    </div>
                    <div class="panel-body">
                        <iframe id="iframe_Notificacion" height="560" width="100%" src="about:blank" frameborder="0"></iframe>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>



    <!-- END wrapper -->
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

    <script src="assets/plugins/OwlCarousel2-2.2.1/src/js/owl.carousel.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script src="assets/js/General.js"></script>
    <script src="assets/pages/jquery.Pricipal.js"></script>

    <%--    <script>
        $(function () {
            $('.content').slimScroll({
                height: '250px'
            });
        });
    </script>--%>




    <script>
        function ModalEjemplo(ID_NOTIFICACION) {
            $('#panel-modal').modal('show');
            ConfigurarFrame('iframe_Notificacion', './iframe_Notificacion.aspx?not_id=' + ID_NOTIFICACION + '');
        }

        function Salir() {

            $.ajax({
                type: "POST",
                cache: false,
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "Principal.aspx/metodoLimpiarDatos",
                dataType: "json",
                data: {},
                success: function () {
                    //$(location).attr('href', 'Ingreso.aspx');
                    //window.opener.top.location.href="Ingreso.aspx";
                    window.top.location.href = 'Login.aspx';
                }
            });
        }

        function pageLoad() {
            ConfigurarFrame('iframe_Contenido', 'Inicio.aspx');
        }


        //var fnInt = setInterval(CallMe, 3000);
        function CallMe() {
            $.ajax({
                type: "POST",
                cache: false,
                async: false,
                contentType: "application/json; charset=utf-8",
                url: "Principal.aspx/ContNotificaciones",
                dataType: "json",
                data: {},
                success: function (returnedData) {
                    var objdata = $.parseJSON(returnedData.d);
                    if (objdata != null) {
                        var htmlNoti = "";
                        var id
                        $("#ul_noti").empty("");
                        $(objdata).each(function () {
                            id = this.ID_NOTIFICACION
                            if (this.TOTAL == "0") {
                                $("#badge_notificaciones").text("");
                            }
                            else {
                                $("#badge_notificaciones").text(this.TOTAL);
                            }

                            if (this.ESTADO_NOTIFICACION == "1") {
                                htmlNoti = htmlNoti + "<li class='list-group-item active'> <a href='javascript:ModalEjemplo(" + this.ID_NOTIFICACION + ");' class='user-list-item'> <div class='icon'> <i class='zmdi zmdi-comment'></i> </div> <div class='user-desc'> <span class='name'>Administrador</span> <span class='desc'>" + this.ASUNTO_NOTIFICACION + "</span> <span class='time'>" + this.FECHA_NOTIFICACION + "</span> </div> </a> </li>"
                            }
                            else {
                                htmlNoti = htmlNoti + "<li class='list-group-item'> <a href='javascript:ModalEjemplo(" + this.ID_NOTIFICACION + ");' class='user-list-item'> <div class='icon'> <i class='zmdi zmdi-comment'></i> </div> <div class='user-desc'> <span class='name'>Administrador</span> <span class='desc'>" + this.ASUNTO_NOTIFICACION + "</span> <span class='time'>" + this.FECHA_NOTIFICACION + "</span> </div> </a> </li>"
                            }


                        });
                        ModalEjemplo(id);
                        $("#ul_noti").append(htmlNoti);
                    }

                }
            });
        }





    </script>
</body>
</html>
