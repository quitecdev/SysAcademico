<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotaDocente.aspx.cs" Inherits="SysAcademico.NotaDocente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">

    <link rel="shortcut icon" href="assets/images/favicon.ico">

    <title>CAS - Sistema Acádemico</title>


    <!-- Editatable  Css-->
    <link rel="stylesheet" href="assets/plugins/magnific-popup/dist/magnific-popup.css" />
    <link rel="stylesheet" href="assets/plugins/jquery-datatables-editable/datatables.css" />

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
<body onload="pageLoad();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
            function endReq(sender, args) {

                //$('#table_nota').editableTableWidget().numericInputExample().find('td:first').focus();
                
                $(document).ready(function () {
                    $("#<%=GridView1.ClientID%>  input").change(function () {
                        var ID_ESTUDIANTE = $(this).closest("tr").find('td:eq(0)').text();
                        var DESCRIPCION_PONDERACION = $(this).data('nota');
                        var VALOR_NOTA = $(this).val();
                        $.ajax({
                            type: "POST",
                            cache: false,
                            async: false,
                            contentType: "application/json; charset=utf-8",
                            url: "NotaDocente.aspx/ActualizarNota",
                            data: '{ID_ESTUDIANTE:"' + ID_ESTUDIANTE + '",DESCRIPCION_PONDERACION:"' + DESCRIPCION_PONDERACION +'",VALOR_NOTA:"' + VALOR_NOTA + '"}',
                            success: function (data) {
          
                            },
                            error: function (data) {
                                alert('ERROR');
                            }
                        });


                    });
                });


                $(function () {
                    $(".numeric").numeric();
                    $(".numeric").focus(function () { $(this).css("background-color", "#E0ECF8"); });
                    $(".numeric").blur(function () { $(this).css("background-color", "#eee"); });
                    $('.decimal').numeric(".");
                });
               
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">INGRESO DE CALIFICACIONES</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box table-responsive">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="m-t-25"></div>
                            <div class="row">
                                <div class="col-md-6">

                                    
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Docente:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_docente" AutoPostBack="True" OnSelectedIndexChanged="cmb_docente_SelectedIndexChanged"></asp:DropDownList>
                                    </div>


                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Sede:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_sede" AutoPostBack="True" OnSelectedIndexChanged="cmb_sede_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Carrera:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_carrera" AutoPostBack="True" OnSelectedIndexChanged="cmb_carrera_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Nota:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_nota" AutoPostBack="True" OnSelectedIndexChanged="cmb_nota_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Horario:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_horario" AutoPostBack="True" OnSelectedIndexChanged="cmb_horario_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="m-t-25"></div>
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" CssClass="table table-striped" GridLines="None" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div class="alert alert-danger alert-dismissible fade in" role="alert">
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                            <strong>¡Vaya!</strong> Parece que no existen notas para ingresar.
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
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

    <!-- Numeric  -->
    <script src="assets/js/jquery.numeric.js"></script>

    <!-- Editable js -->
    <script src="assets/plugins/magnific-popup/dist/jquery.magnific-popup.min.js"></script>
    <script src="assets/plugins/jquery-datatables-editable/jquery.dataTables.js"></script>
    <script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="assets/plugins/tiny-editable/mindmup-editabletable.js"></script>
    <script src="assets/plugins/tiny-editable/numeric-input-example.js"></script>
    <!-- init -->
    <script src="assets/pages/jquery.datatables.editable.init.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>
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


            $(document).ready(function () {
                $("#<%=GridView1.ClientID%>  input").change(function () {
                    var ID_ESTUDIANTE = $(this).closest("tr").find('td:eq(0)').text();
                    var DESCRIPCION_PONDERACION = $(this).data('nota');
                    var VALOR_NOTA = $(this).val();
                    $.ajax({
                        type: "POST",
                        cache: false,
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: "NotaDocente.aspx/ActualizarNota",
                        data: '{ID_ESTUDIANTE:"' + ID_ESTUDIANTE + '",DESCRIPCION_PONDERACION:"' + DESCRIPCION_PONDERACION +'",VALOR_NOTA:"' + VALOR_NOTA + '"}',
                        success: function (data) {
          
                        },
                        error: function (data) {
                            alert('ERROR');
                        }
                    });


                });
            });

            $(function () {
                $(".numeric").numeric();
                $(".numeric").focus(function () { $(this).css("background-color", "#E0ECF8"); });
                $(".numeric").blur(function () { $(this).css("background-color", "#eee"); });
                $('.decimal').numeric(".");
            });

        }
    </script>
</body>
</html>

