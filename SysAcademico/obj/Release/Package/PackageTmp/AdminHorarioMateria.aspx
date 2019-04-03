<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHorarioMateria.aspx.cs" Inherits="SysAcademico.AdminHorarioMateria" %>

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
                <h4 class="page-title">HORARIO-MATERIA</h4>
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
                            <button class="btn btn-custom waves-effect waves-light m-b-5" data-toggle="modal" data-target="#con-close-modal"><i class="zmdi zmdi-plus-circle m-r-5"></i><span>Añadir</span> </button>
                            <div class="m-t-25"></div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Sede:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_sede" AutoPostBack="True" OnSelectedIndexChanged="cmb_sede_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Carrera:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_carrera" AutoPostBack="true" OnSelectedIndexChanged="cmb_carrera_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Horario:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_horario" AutoPostBack="true" OnSelectedIndexChanged="cmb_horario_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Materia:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_materia" AutoPostBack="true" OnSelectedIndexChanged="cmb_materia_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Paralelo:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_paralelo" AutoPostBack="true" OnSelectedIndexChanged="cmb_paralelo_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
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

        <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width: 85%">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Datos Intervalo</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ID="up2">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Sede:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_sedeAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_sedeAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Carrera:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_carreraAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_carreraAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Materia:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_materiaAñadir" AutoPostBack="true" OnSelectedIndexChanged="cmb_materiaAñadir_SelectedIndexChanged" required></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Paralelo:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_paraleloAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_paraleloAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Intervalo:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_intervaloAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_intervaloAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Hora:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_intervaloDetalleAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_intervaloDetalleAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Día:</label>
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="cmb_horarioAñadir" required></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="bnt_guardar" OnClick="btn_guardar_Click" CssClass="btn btn-block btn-custom" Text="Guardar" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <div id="con-close-modal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width: 50%">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Editar</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Sede:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_sedeEditar" AutoPostBack="True" OnSelectedIndexChanged="cmb_sedeEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Carrera:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_carreraEditar" AutoPostBack="true" OnSelectedIndexChanged="cmb_carreraEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Materia:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_materiaEditar" AutoPostBack="true" OnSelectedIndexChanged="cmb_materiaEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Paralelo:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_paraleloEditar" AutoPostBack="true" OnSelectedIndexChanged="cmb_paraleloEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="m-t-25"></div>
                                <asp:GridView ID="GridParalelo" GridLines="None" CssClass="gvv m-0 table table-striped dt-responsive nowrap dataTable no-footer dtr-inline" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" DataSourceID="ObjectDataSource1" OnRowDeleting="GridParalelo_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <asp:Label ID="ID_HORARIO_DETALLE" runat="server" Text='<%# Bind("ID_HORARIO_DETALLE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HORA">
                                            <ItemTemplate>
                                                <asp:Label ID="HORA" runat="server" Text='<%# Bind("HORA") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MATERIA">
                                            <ItemTemplate>
                                                <asp:Label ID="MATERIA" runat="server" Text='<%# Bind("MATERIA") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DIA">
                                            <ItemTemplate>
                                                <asp:Label ID="DESCRIPCION_DIAS" runat="server" Text='<%# Bind("DESCRIPCION_DIAS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField DeleteText="&lt;span class=&quot;fa fa-trash text-custom&quot;&gt;&lt;/span&gt;" EditText="" ShowDeleteButton="True">
                                            <ControlStyle Width="50px" />
                                            <FooterStyle Width="50px" />
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle Width="50px" />
                                        </asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerMateriaHorario" TypeName="SysAcademico.App_Code.AdminHorarioMateria" DeleteMethod="EliminarHorario" OnDeleting="ObjectDataSource1_Deleting">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ID_HORARIO_DETALLE" Type="String" />
                                    </DeleteParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmb_paraleloEditar" DefaultValue="0" Name="ID_PARALELO_MATERIA" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:HiddenField Value="" ID="hd_index" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
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

