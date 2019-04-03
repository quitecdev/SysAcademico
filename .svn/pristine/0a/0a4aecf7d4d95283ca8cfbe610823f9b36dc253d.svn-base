<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HorarioDocente.aspx.cs" Inherits="SysAcademico.HorarioDocente" %>

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
    <link href="assets/plugins/timepicker/bootstrap-timepicker.min.css" rel="stylesheet">

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/menu.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />

        <style>
        th {
            background: #8b1716;
            color: #fff;
            padding: 20px !important;
        }

        td {
            padding: 20px !important;
        }
    </style>

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

                //$(document).ready(function () {
                //    $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                //        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]] //value:item pair
                //    });
                //});
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">DOCENTE-MATERIA</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box table-responsive">
                    <div class="dropdown pull-right">
                        <a href="#" class="dropdown-toggle card-drop" data-toggle="dropdown" aria-expanded="false">
                            <i class="zmdi zmdi-more-vert"></i>
                        </a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="#" data-toggle="modal" data-target="#con-close-modal2">Editar</a></li>
                        </ul>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="m-t-25"></div>
                            <div class="m-t-25"></div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:GridView ID="GridCodigos" GridLines="None" CssClass="table table-hover m-0 table-responsive" AutoGenerateColumns="false" runat="server" DataKeyNames="DESCRIPCION_MATERIA,COD_MATERIA">
                                        <Columns>
                                            <asp:BoundField DataField="DESCRIPCION_MATERIA" HeaderText="DESCRIPCION" />
                                            <asp:BoundField DataField="COD_MATERIA" HeaderText="CODIGO" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="m-t-25"></div>
                            <asp:GridView ID="GridHorario" GridLines="None" CssClass="table table-bordered table-hover m-0 table-responsive" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" DataKeyNames="HORIA/DIA,LUNES,MARTES,MIERCOLES,JUEVES,VIERNES,SABADO">
                                <Columns>
                                    <asp:BoundField DataField="HORIA/DIA" HeaderText="HORIA/DIA" />
                                    <asp:BoundField DataField="LUNES" HeaderText="LUNES" />
                                    <asp:BoundField DataField="MARTES" HeaderText="MARTES" />
                                    <asp:BoundField DataField="MIERCOLES" HeaderText="MIERCOLES" />
                                    <asp:BoundField DataField="JUEVES" HeaderText="JUEVES" />
                                    <asp:BoundField DataField="VIERNES" HeaderText="VIERNES" />
                                    <asp:BoundField DataField="SABADO" HeaderText="SABADO" />
                                </Columns>
                            </asp:GridView>
                            <div class="m-t-25"></div>
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
    <script src="assets/plugins/timepicker/bootstrap-timepicker.min.js"></script>

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

    </script>
</body>
</html>
