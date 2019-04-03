<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframePerfilUsuario.aspx.cs" Inherits="SysAcademico.iframePerfilUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">

    <link rel="shortcut icon" href="assets/images/favicon.ico">

    <title>CAS - Sistema Acádemico</title>

    <!-- DataTables -->
    <link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/datatables/buttons.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/datatables/fixedHeader.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/datatables/responsive.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/datatables/scroller.bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap-fileinput-master/css/fileinput.css" rel="stylesheet" />

    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
    <script src="assets/js/modernizr.min.js"></script>

    <style>
        /*.kv-avatar .file-preview-frame, .kv-avatar .file-preview-frame:hover {
            margin: 0;
            padding: 0;
            border: none;
            box-shadow: none;
            text-align: center;
        }

        .kv-avatar .file-input {
            display: table-cell;
            max-width: 100%;
        }*/
    </style>
</head>
<body onload="pageLoad();">
    <form method='post' runat="server" id='form'>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
            function endReq(sender, args) {
                $("#bnt_guardar").on('click', function () {  
                    $('#form').parsley().validate("first");
                    $('.second .req').removeAttr('required');
                    $('.first .req').attr('required','required');
                    if ($('#form').parsley().isValid()) { 
                        $('#form').parsley().destroy();
                        console.log("valid");
                    } else {
                        console.log('not valid');
                    }
                });

                $("#bt_actualizarClave").on('click', function () {
                    $('#form').parsley().validate("second");
                    $('.first .req').removeAttr('required');
                    $('.second .req').attr('required','required');
                    if ($('#form').parsley().isValid("second")) {
                        $('#form').parsley().destroy();
                        console.log('valid');
                    } else {
                        console.log('not valid');
                    }
                });

            }
        </script>
        <div class="row card-box">
            <div class="media">
                <div class="media-left">
                    <div class="kv-avatar center-block">
                        <%--<input id="avatar-2" name="avatar-2" type="file" class="file-loading">--%>
                        <asp:FileUpload runat="server" ID="fil_Imagen" class="file-loading" />
                    </div>
                </div>
                <div class="media-body">
                    <h4 class="media-heading" runat="server" id="nombre"></h4>
                    <div class="row">
                        <div class="col-sm-12">
                            <ul class="nav nav-tabs nav-justified">
                                <li role="presentation" class="active">
                                    <a href="#home" id="home-tab" role="tab" data-toggle="tab" aria-controls="home" aria-expanded="true">Datos Personales</a>
                                </li>
                                <li role="presentation" class="">
                                    <a href="#profile" role="tab" id="profile-tab" data-toggle="tab" aria-controls="profile" aria-expanded="false">Cuenta</a>
                                </li>
                            </ul>
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane fade active in first" id="home" aria-labelledby="home-tab">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Apellido Paterno</label>
                                                    <asp:TextBox runat="server" ID="txt_apellido_paterno" class="req form-control" TabIndex="1" data-parsley-group="first" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Apellido Materno</label>
                                                    <asp:TextBox runat="server" ID="txt_apellido_materno" class="req form-control" TabIndex="2" data-parsley-group="first" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Primer Nombre</label>
                                                    <asp:TextBox runat="server" ID="txt_primer_nombre" class="req form-control" TabIndex="3" data-parsley-group="first" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Segundo Nombre</label>
                                                    <asp:TextBox runat="server" ID="txt_segundo_nombre" class="req form-control" TabIndex="4" data-parsley-group="first" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Celular</label>
                                                    <asp:TextBox runat="server" ID="txt_celular" class="req number form-control" TabIndex="5" data-parsley-group="first" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Correo Electrónico</label>
                                                    <asp:TextBox runat="server" ID="txt_correo" class="req email form-control" TabIndex="6" data-parsley-group="first" data-parsley-type="email" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label>Dirección</label>
                                                    <asp:TextBox runat="server" ID="txt_direccion" class="req form-control" TabIndex="7" data-parsley-group="first" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <asp:Button runat="server" OnClick="bnt_guardar_Click" ID="bnt_guardar" Text="Actualizar" class="btn btn-custom btn-block" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div role="tabpanel" class="tab-pane fade second" id="profile" aria-labelledby="profile-tab">

                                    <div class="col-md-4">
                                        <section role="form" id="form_clave">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="zmdi zmdi-key"></i></span>
                                                    <asp:TextBox runat="server" ID="txt_claveActual" class="req form-control"  placeholder="Ingrese su contraseña actual" data-parsley-group="second" required  TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="zmdi zmdi-key"></i></span>
                                                    <asp:TextBox runat="server" ID="txt_claveNueva" class="req form-control" placeholder="Ingrese su contraseña actual" data-parsley-group="second" required TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon"><i class="zmdi zmdi-key"></i></span>
                                                    <asp:TextBox runat="server" data-parsley-equalto="#txt_claveNueva" ID="TextBox2" class="req form-control" placeholder="Ingrese su contraseña actual" data-parsley-group="second" required  TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button runat="server" ID="bt_actualizarClave" OnClick="bt_actualizarClave_Click" Text="Actualizar" class="btn btn-custom btn-block" />
                                            </div>
                                        </section>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField runat="server" ID="HiddenImagen" Value="./assets/images/usuario.png" />
        <asp:HiddenField runat="server" ID="ID_USUARIO" />
    </form>

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


    <!-- Validation js (Parsleyjs) -->
    <script type="text/javascript" src="assets/plugins/parsleyjs/dist/parsley.min.js"></script>

    <!-- FileInput js -->
    <!-- purify.min.js is only needed if you wish to purify HTML content in your preview for HTML files.
     This must be loaded before fileinput.min.js -->
    <script src="assets/plugins/bootstrap-fileinput-master/js/plugins/purify.min.js"></script>
    <!-- the main fileinput plugin file -->
    <script src="assets/plugins/bootstrap-fileinput-master/js/fileinput.min.js"></script>
    <!-- App js -->
    <!-- Validation js (Parsleyjs) -->
    <script type="text/javascript" src="assets/plugins/parsleyjs/dist/parsley.min.js"></script>

    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>
    <script>

        $("#fil_Imagen").fileinput({
            overwriteInitial: true,
            maxFileSize: 1500,
            showClose: false,
            showCaption: false,
            showBrowse: false,
            browseOnZoneClick: true,
            removeLabel: '',
            removeIcon: '<i class="glyphicon glyphicon-remove"></i>',
            removeTitle: 'Cancel or reset changes',
            elErrorContainer: '#kv-avatar-errors-2',
            msgErrorClass: 'alert alert-block alert-danger',
            defaultPreviewContent: '<img src="' + $('#HiddenImagen').val() + '" class="media-object img-circle"  style="width: 150px; height: 150x;" ><h6 class="text-muted">Cambiar de imagen</h6>',
            //layoutTemplates: { main2: '{preview} ' + btnCust + ' {remove} {browse}' },
            allowedFileExtensions: ["jpg", "png", "gif"]
        });

        //localizar timers
        var iddleTimeoutWarning = null;
        var iddleTimeout = null;
 
        //esta funcion automaticamente sera llamada por ASP.NET AJAX cuando la pagina cargue y un postback parcial complete
        function pageLoad() { 
 
            //borrar antiguos timers de postbacks anteriores
            if (iddleTimeoutWarning != null)
            {                
                clearTimeout(iddleTimeoutWarning);
            }

            if (iddleTimeout != null)
            {
                clearTimeout(iddleTimeout);
            }
            //leer tiempos desde web.config
            var millisecTimeOutWarning = <%= int.Parse(System.Configuration.ConfigurationManager.AppSettings["SessionTimeoutWarning"]) * 60 * 1000 %>;
            var millisecTimeOut = <%= int.Parse(System.Configuration.ConfigurationManager.AppSettings["SessionTimeout"]) * 60 * 1000 %>; 
 
            //establece tiempo para mostrar advertencia si el usuario ha estado inactivo
            iddleTimeoutWarning = setTimeout("DisplayIddleWarning()", millisecTimeOutWarning);
            iddleTimeout = setTimeout("TimeoutPage()", millisecTimeOut);
        } 
 
        function DisplayIddleWarning() {
            console.log("Tu sesion esta a punto de expirar debido a inactividad.");
        } 
 
        function TimeoutPage() {
            //actualizar pagina para este ejemplo, podriamos redirigir a otra pagina con codigo para eliminar variables de sesion
            Salir();
        } 

        $("form").click(function(){
            pageLoad();
        });
		
		
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
                    window.top.location.href = 'Login.aspx';
                }
            });
        }

        $("#bnt_guardar").on('click', function () {  
            $('#form').parsley().validate("first");
            $('.second .req').removeAttr('required');
            $('.first .req').attr('required','required');
            if ($('#form').parsley().isValid()) { 
                $('#form').parsley().destroy();
                console.log("valid");
            } else {
                console.log('not valid');
            }
        });

        $("#bt_actualizarClave").on('click', function () {
            $('#form').parsley().validate("second");
            $('.first .req').removeAttr('required');
            $('.second .req').attr('required','required');
            if ($('#form').parsley().isValid("second")) {
                $('#form').parsley().destroy();
                console.log('valid');
            } else {
                console.log('not valid');
            }
        });

    </script>

</body>
</html>


