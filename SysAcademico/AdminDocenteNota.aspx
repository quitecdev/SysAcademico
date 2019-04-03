<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDocenteNota.aspx.cs" Inherits="SysAcademico.AdminDocenteNota" %>

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
    <link href="assets/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet">
    <link href="assets/plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">

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

                $(document).ready(function () {
                    $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]] //value:item pair
                    });
                });

                jQuery('.datepicker-autoclose').datepicker({
                    autoclose: true,
                    todayHighlight: true,
                    format: "dd/mm/yyyy",
                    language: "es"
                });
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">DOCENTE-NOTA</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box table-responsive">
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
                                        <label for="exampleInputEmail1">Nota:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_nota" AutoPostBack="true" OnSelectedIndexChanged="cmb_nota_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Nota Detalle:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_notaDetalle" AutoPostBack="true" OnSelectedIndexChanged="cmb_notaDetalle_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="m-t-25"></div>
                            <asp:GridView ID="GridNotasDetalle" GridLines="None" CssClass="gvv m-0 table table-striped dt-responsive nowrap dataTable no-footer dtr-inline" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" DataSourceID="ObjectDataSource1" OnRowUpdating="GridNotasDetalle_RowUpdating" OnRowCommand="GridNotasDetalle_RowCommand" OnRowDataBound="GridNotasDetalle_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label ID="ID_DOCENTE_NOTA" runat="server" Text='<%# Bind("ID_DOCENTE_NOTA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DESCRIPCION">
                                        <ItemTemplate>
                                            <asp:Label ID="DESCRIPCION_PONDERACION" runat="server" Text='<%# Bind("DESCRIPCION_PONDERACION") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nº IDENTIDAD">
                                        <ItemTemplate>
                                            <asp:Label ID="ID_DOCENTE" runat="server" Text='<%# Bind("ID_DOCENTE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NOMBRE">
                                        <ItemTemplate>
                                            <asp:Label ID="NOMBRE" runat="server" Text='<%# Bind("NOMBRE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FECHA INICIO">
                                        <ItemTemplate>
                                            <asp:Label ID="FECHA_INICIO" runat="server" Text='<%# Bind("FECHA_INICIO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txt_fechaInicio" Text='<%# Bind("FECHA_INICIO") %>' class="form-control datepicker-autoclose" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FECHA FIN">
                                        <ItemTemplate>
                                            <asp:Label ID="FECHA_FIN" runat="server" Text='<%# Bind("FECHA_FIN") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txt_fechaFin" Text='<%# Bind("FECHA_FIN") %>' class="form-control datepicker-autoclose" placeholder="dd/mm/yyyy"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--                                    <asp:TemplateField HeaderText="NO_MODIFICAR" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="NO_MODIFICAR" runat="server" Text='<%# Bind("NO_MODIFICAR") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="&lt;span class=&quot;fa fa-pencil text-custom&quot;&gt;&lt;/span&gt;" CancelText="&lt;span class=&quot;fa fa-times text-custom&quot;&gt;&lt;/span&gt;" DeleteText="" UpdateText="&lt;span class=&quot;fa fa-save text-custom&quot;&gt;&lt;/span&gt;">
                                        <ControlStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Eliminar" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_eliminar" CommandName="Obtener" CommandArgument='<%# Bind("ID_DOCENTE_NOTA") %>' runat="server">
                                                <span class="fa fa-trash text-custom"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ControlStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerPonderacion" TypeName="SysAcademico.App_Code.AdminDocenteNota" OnUpdating="ObjectDataSource1_Updating" UpdateMethod="ActualizarPonderacion">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmb_nota" DefaultValue="0" Name="ID_NOTA" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="cmb_notaDetalle" DefaultValue="0" Name="ID_NOTA_DETALLE" PropertyName="SelectedValue" Type="String" />
                                    <asp:ControlParameter ControlID="cmb_sede" DefaultValue="0" Name="ID_SEDE" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ID_DOCENTE_NOTA" Type="String" />
                                    <asp:Parameter Name="DESCRIPCION_PONDERACION" Type="String" />
                                    <asp:Parameter Name="ID_DOCENTE" Type="String" />
                                    <asp:Parameter Name="NOMBRE" Type="String" />
                                    <asp:Parameter Name="FECHA_INICIO" Type="String" />
                                    <asp:Parameter Name="FECHA_FIN" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField Value="" ID="hd_index" runat="server" />
                            <asp:HiddenField Value="" ID="id_ponderacion" runat="server" />
                            <div class="m-t-25"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog" style="width: 65%">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Datos Nota</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ID="up2">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Sede:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_sedeAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_sedeAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Carrera:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_carreraAñadir" required AutoPostBack="True" OnSelectedIndexChanged="cmb_carreraAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Nota:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_notaAñadir" required AutoPostBack="true" OnSelectedIndexChanged="cmb_notaAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Nota Detalle:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_notaDetalleAñadir" required AutoPostBack="true" OnSelectedIndexChanged="cmb_notaDetalleAñadir_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Nota Ponderacion:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_notaPonderacion" required AutoPostBack="true" OnSelectedIndexChanged="cmb_notaPonderacion_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">

                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Docente:</label>
                                            <asp:DropDownList runat="server" class="form-control" ID="cmb_docente" required></asp:DropDownList>
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
    <script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>

    <!-- Validation js (Parsleyjs) -->
    <script type="text/javascript" src="assets/plugins/parsleyjs/dist/parsley.min.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script src="assets/js/General.js"></script>
    <script>

        $(document).ready(function () {
            $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]] //value:item pair
            });
        });

        jQuery('.datepicker-autoclose').datepicker({
            autoclose: true,
            todayHighlight: true,
            format: "dd/mm/yyyy",
            language: "es"
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

