<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteInscripciones.aspx.cs" Inherits="SysAcademico.ReporteInscripciones" %>

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

                $(document).ready(function () {
                    $('.gvv').DataTable( {
                        dom: "Bfrtip",
                        buttons: [{ extend: "excel", className: "btn btn-default waves-effect" },
                                  { extend: "pdf", className: "btn btn-default waves-effect" },
                                  { extend: "print", className: "btn btn-default waves-effect" }],
                        responsive: !0
                    } );
                });
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">REPORTE INSCRIPCIONES</h4>
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
                                        <label for="exampleInputEmail1">Sede:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_sede" AutoPostBack="True" OnSelectedIndexChanged="cmb_sede_SelectedIndexChanged" required></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Carrera:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_carrera" AutoPostBack="True" OnSelectedIndexChanged="cmb_carrera_SelectedIndexChanged" required></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Horario:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_horario" AutoPostBack="True" OnSelectedIndexChanged="cmb_horario_SelectedIndexChanged" required></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Hora:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_hora" required></asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <asp:Button ID="btn_buscar" Text="Buscar" CssClass="btn btn-custom  w-md m-b-5" runat="server" OnClick="btn_buscar_Click" />
                            <div class="m-t-25"></div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridInscripciones" GridLines="None" CssClass="gvv datatable-buttons m-0 table table-striped table-responsive" AutoGenerateColumns="false" runat="server" ShowHeaderWhenEmpty="True" PageSize="5" OnPreRender="GridInscripciones_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SEDE">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="DESCRIPCION_UNIVERSIDAD" Text='<%# Bind("DESCRIPCION_UNIVERSIDAD") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CARRERA">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="COD_CARRERA" Text='<%# Bind("COD_CARRERA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HORA">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="HORA" Text='<%# Bind("HORA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PARALELO">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="DESCRIPCION_PARALELO" Text='<%# Bind("DESCRIPCION_PARALELO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="ID_INSCRIP" Text='<%# Bind("ID_INSCRIP") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NOMBRE">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="NOMBRE" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nº FAC.">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="NUMERO_FACTURA" Text='<%# Bind("NUMERO_FACTURA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TIP. PAGO">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="DESCRIPCION_TIPO_PAGO" Text='<%# Bind("DESCRIPCION_TIPO_PAGO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                    </asp:GridView>
                                </div>
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

    <!-- Datatable init js -->
    <script src="assets/pages/jquery.datatables.init.js"></script>
    <script src="assets/pages/jquery.datatables.editable.init.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script>

        $(document).ready(function () {
            $('.gvv').DataTable( {
                dom: "Bfrtip",
                buttons: [{ extend: "excel", className: "btn btn-default waves-effect" },
                          { extend: "pdf", className: "btn btn-default waves-effect" },
                          { extend: "print", className: "btn btn-default waves-effect" }],
                responsive: !0
            } );
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

    </script>
</body>
</html>
