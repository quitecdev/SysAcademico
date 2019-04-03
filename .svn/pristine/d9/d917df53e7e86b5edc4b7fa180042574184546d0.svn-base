<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminNotificacion.aspx.cs" Inherits="SysAcademico.AdminNotificacion" ValidateRequest="false" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">

    <link rel="shortcut icon" href="assets/images/favicon.ico">

    <title>CAS - Sistema Acádemico</title>

    <link href="assets/plugins/summernote/summernote.css" rel="stylesheet" />
    <link href="assets/plugins/jquery-ui-bootstrap-masterbs3/css/custom-theme/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="assets/plugins/jquery-ui/css/jquery-ui.css" rel="stylesheet" />
    <link href="assets/plugins/jquery.tagsinput/src/jquery.tagsinput.css" rel="stylesheet" />
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



    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
</head>

<body onload="pageLoad();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
            function endReq(sender, args) {


            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">Notificación</h4>
            </div>
        </div>


        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <h4 class="header-title m-t-0 m-b-30">Mensaje</h4>

                    <div class="row">
                        <div class="col-sm-12">
                            <section class="form-horizontal" role="form">
                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-8">
                                        <button type="button" class="btn btn-icon waves-effect waves-light btn-danger m-b-5" data-toggle="modal" data-target="#myModal"><i class="zmdi zmdi-account-box-mail m-r-5"></i><span>Grupos</span> </button>
                                        <%--                                        <asp:LinkButton runat="server" ID="bnt_enviar" OnClientClick="Validar()" CssClass="btn btn-inverse waves-effect waves-light m-b-5">
                                            <i class="fa fa-envelope-o m-r-5"></i> <span>Enviar</span> 
                                        </asp:LinkButton>--%>
                                        <%-- <button class="btn btn-inverse waves-effect waves-light m-b-5"> <i class="fa fa-envelope-o m-r-5"></i> <span>Enviar</span> </button>--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Buscar</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txt_buscar" CssClass="form-control autocomplete ui-autocomplete-input"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Contacto</label>
                                    <div class="col-md-8">
                                        <%--<input id="contantos" type="text" data-role="tagsinput" placeholder="Agregar Contacto"/>--%>
                                        <asp:TextBox runat="server" parsley-trigger="change" required CssClass="form-control" ID="txt_destinatario" placeholder="Agregar Contacto"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Asunto</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txt_asunto" required CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label"></label>
                                    <div class="col-md-8">
                                        <asp:Button runat="server" ID="btn_enviar" OnClick="btn_enviar_Click" CssClass="btn btn-custom" Text="Enviar" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtSummernote" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    <asp:Label ID="lblSum" runat="server" Text="Summernote"></asp:Label>
                                </div>
                            </section>
                        </div>
                        <!-- end col -->
                    </div>
                    <!-- end row -->
                </div>
            </div>
            <!-- end col -->
        </div>



        <!-- sample modal content -->
        <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="myModalLabel">GRUPOS</h4>
                    </div>
                    <div class="modal-body">
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="Docente" value="Docente" type="checkbox">
                            <label for="Docente">
                                Docente                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="Estudiante" value="Estudiante" type="checkbox">
                            <label for="Estudiante">
                                Estudiante                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="Personal Admin." value="Personal Admin." type="checkbox">
                            <label for="Personal Admin.">
                                Personal Admin.                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="C1" value="C1" type="checkbox">
                            <label for="C1">
                                C1                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="C2" value="C2" type="checkbox">
                            <label for="C2">
                                C2                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="C3" value="C3" type="checkbox">
                            <label for="checkbox1">
                                C3                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="P1" value="P1" type="checkbox">
                            <label for="checkbox1">
                                P1                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="P2" value="P2" type="checkbox">
                            <label for="checkbox1">
                                P2                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="PD1" value="PD1" type="checkbox">
                            <label for="checkbox1">
                                PD1                       
                            </label>
                        </div>
                        <div class="checkbox checkbox-custom m-b-15">
                            <input id="BAM1" value="BAM1" type="checkbox">
                            <label for="checkbox1">
                                BAM1                       
                            </label>
                        </div>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

    </form>
    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/plugins/jquery-ui/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/detect.js"></script>
    <script src="assets/js/fastclick.js"></script>
    <script src="assets/js/jquery.slimscroll.js"></script>
    <script src="assets/js/jquery.blockUI.js"></script>
    <script src="assets/js/waves.js"></script>
    <script src="assets/js/wow.min.js"></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>

    <!-- Datatables-->
    <script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="assets/plugins/datatables/dataTables.buttons.min.js"></script>
    <script src="assets/plugins/datatables/buttons.bootstrap.min.js"></script>
    <script src="assets/plugins/datatables/jszip.min.js"></script>
    <script src="assets/plugins/datatables/pdfmake.min.js"></script>
    <script src="assets/plugins/datatables/vfs_fonts.js"></script>
    <script src="assets/plugins/datatables/buttons.html5.min.js"></script>
    <script src="assets/plugins/datatables/buttons.print.min.js"></script>
    <script src="assets/plugins/datatables/dataTables.fixedHeader.min.js"></script>
    <script src="assets/plugins/datatables/dataTables.keyTable.min.js"></script>
    <script src="assets/plugins/datatables/dataTables.responsive.min.js"></script>
    <script src="assets/plugins/datatables/responsive.bootstrap.min.js"></script>
    <script src="assets/plugins/datatables/dataTables.scroller.min.js"></script>

    <!-- Summernote js-->
    <script src="assets/plugins/summernote/summernote.min.js"></script>
    <script src="assets/plugins/jquery.tagsinput/src/jquery.tagsinput.js"></script>

    <!-- Validation js (Parsleyjs) -->
    <script type="text/javascript" src="assets/plugins/parsleyjs/dist/parsley.min.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script src="assets/js/General.js"></script>

    <script>

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


        $(document).ready(function () {
            $('#txt_destinatario').tagsInput({
                width: 'auto',
                defaultText: ''
            });
        });

        $('input[type="checkbox"]').click(function() {
            if( $(this).is(':checked') ) {
                $('#txt_destinatario').addTag(this.value);
            }
            else
            {
                $('#txt_destinatario').removeTag(this.value);
            }
           
        });


        $(document).ready(function () {

            SearchText();

            function SearchText() {
                $("#<%=txt_buscar.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            cache: false,
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "AdminNotificacion.aspx/GetAutoCompleteData",
                            dataType: "json",
                            data: "{ 'txt' : '" + $("#<%=txt_buscar.ClientID %>").val() + "'}",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item,
                                        value: item
                                    }
                                }))
                                //debugger;
                            },
                            error: function (result) {
                                alert("Error");
                            }
                        });
                    },
                    select: function(event, ui) {
                        //$('#txt_buscar').val('');
                        $('#txt_destinatario').addTag(ui.item.value);  
                        $("#<%=txt_buscar.ClientID %>").val('')
                    },
                    minLength: 3,
                    delay: 1000
                });
            }
        });

        $(function () {
            // Set up your summernote instance
            $("#<%= txtSummernote.ClientID %>").summernote({
                height: 350,                 // set editor height
                minHeight: null,             // set minimum height of editor
                maxHeight: null,             // set maximum height of editor
                focus: false
            });
            focus: true,
            // When the summernote instance loses focus, update the content of your <textarea>
            $("#<%= txtSummernote.ClientID %>").on('summernote.blur', function () {
                $('#<%= txtSummernote.ClientID %>').html($('#<%= txtSummernote.ClientID %>').summernote('code'));
            });
        });


        $(document).ready(function() {
            $('form').parsley();
        });


        $("#bnt_enviar").on('click', function () {  

            if ($('#form').parsley().isValid()) { 
                alert('No');
            }
        });

       

    </script>
</body>
</html>




