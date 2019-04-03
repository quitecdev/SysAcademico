<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDocentes.aspx.cs" Inherits="SysAcademico.AdminDocentes" %>

<!DOCTYPE html>
<html>
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
                        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
                        "aaSorting": [[1, "desc"]], // Sort by first column descending
                        destroy: true,
                        stateSave: true
                    });
                });
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">DOCENTES</h4>
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
                            <asp:GridView ID="GridDocentes" GridLines="None" CssClass="gvv m-0 table table-striped table-responsive" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridInscripcion_SelectedIndexChanged" OnRowDataBound="GridInscripcion_RowDataBound" DataSourceID="ObjectDataSource1" OnRowUpdating="GridDocentes_RowUpdating" OnRowCommand="GridDocentes_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="# IDENTIDAD">
                                        <ItemTemplate>
                                            <asp:Label ID="ID_DOCENTE" runat="server" Text='<%# Bind("ID_DOCENTE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="APELLIDO PATERNO">
                                        <ItemTemplate>
                                            <asp:Label ID="APELLIDO_PATERNO_DOCENTE" runat="server" Text='<%# Bind("APELLIDO_PATERNO_DOCENTE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_apellidoPaterno" Text='<%# Bind("APELLIDO_PATERNO_DOCENTE") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="APELLIDO MATERNO">
                                        <ItemTemplate>
                                            <asp:Label ID="APELLIDO_MATERNO_DOCENTE" runat="server" Text='<%# Bind("APELLIDO_MATERNO_DOCENTE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_apellidoMaterno" Text='<%# Bind("APELLIDO_MATERNO_DOCENTE") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PRIMER NOMBRE">
                                        <ItemTemplate>
                                            <asp:Label ID="PRIMER_NOMBRE_DOCENTE" runat="server" Text='<%# Bind("PRIMER_NOMBRE_DOCENTE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_primerNombre" Text='<%# Bind("PRIMER_NOMBRE_DOCENTE") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SEGUNDO NOMBRE">
                                        <ItemTemplate>
                                            <asp:Label ID="SEGUNDO_NOMBRE_DOCENTE" runat="server" Text='<%# Bind("SEGUNDO_NOMBRE_DOCENTE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_segundoNombre" Text='<%# Bind("SEGUNDO_NOMBRE_DOCENTE") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CORREO">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="CORREO_DOCENTE" NavigateUrl='<%# Bind("CORREO_DOCENTE", "mailto:{0}") %>' Text='<%# Bind("CORREO_DOCENTE") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_correo" Text='<%# Bind("CORREO_DOCENTE") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NO_MODIFICAR" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="NO_MODIFICAR" runat="server" Text='<%# Bind("NO_MODIFICAR") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="&lt;span class=&quot;fa fa-pencil text-custom&quot;&gt;&lt;/span&gt;" CancelText="&lt;span class=&quot;fa fa-times text-custom&quot;&gt;&lt;/span&gt;" UpdateText="&lt;span class=&quot;fa fa-save text-custom&quot;&gt;&lt;/span&gt;">
                                        <ControlStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_eliminar" CommandName="ObtenerDocente" CommandArgument='<%# Bind("ID_DOCENTE") %>' runat="server">
                                                <span class="fa fa-trash text-custom"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerDocentes" TypeName="SysAcademico.App_Code.AdminDocentes" OnUpdating="ObjectDataSource1_Updating" UpdateMethod="ActualizarDocente">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="ID_DOCENTE" Type="String" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ID_DOCENTE" Type="String" />
                                    <asp:Parameter Name="APELLIDO_PATERNO_DOCENTE" Type="String" />
                                    <asp:Parameter Name="APELLIDO_MATERNO_DOCENTE" Type="String" />
                                    <asp:Parameter Name="PRIMER_NOMBRE_DOCENTE" Type="String" />
                                    <asp:Parameter Name="SEGUNDO_NOMBRE_DOCENTE" Type="String" />
                                    <asp:Parameter Name="CORREO_DOCENTE" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField Value="" ID="hd_index" runat="server" />
                            <asp:HiddenField Value="" ID="id_docente" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog modal-sm">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                </div>
                                <div class="modal-body">
                                    <h4>¿Está seguro que desea eliminar este registro ?</h4>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <asp:Button runat="server" ID="btn_eliminar" OnClick="btn_eliminar_Click" UseSubmitBehavior="false" CssClass="btn btn-block btn-custom" Text="Aceptar" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!-- /.modal -->
                    <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                    <h4 class="modal-title">Datos Docente</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:UpdatePanel runat="server" ID="up2">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label"># Identidad</label>
                                                        <asp:TextBox runat="server" ID="txt_ci" CssClass="form-control" OnTextChanged="txt_ci_TextChanged" AutoPostBack="true" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">Apellido Paterno</label>
                                                        <asp:TextBox runat="server" ID="txt_apellidoPaterno" CssClass="form-control" required></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-2" class="control-label">Apellido Materno</label>
                                                        <asp:TextBox runat="server" ID="txt_apellidoMaterno" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">Primer Nombre</label>
                                                        <asp:TextBox runat="server" ID="txt_primerNombre" CssClass="form-control" required></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-2" class="control-label">Segundo Nombre</label>
                                                        <asp:TextBox runat="server" ID="txt_segundoNombre" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-3" class="control-label">E-mail</label>
                                                        <asp:TextBox runat="server" ID="txt_email" CssClass="form-control" TextMode="Email" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <asp:Button runat="server" ID="bnt_guardar" OnClick="btn_guardar_Click" CssClass="btn btn-block btn-custom" Text="Guardar" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
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

    <!-- Validation js (Parsleyjs) -->
    <script type="text/javascript" src="assets/plugins/parsleyjs/dist/parsley.min.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script src="assets/js/General.js"></script>

    <script>
        $(document).ready(function () {
            $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
                "aaSorting": [[1, "desc"]], // Sort by first column descending
                destroy: true,
                stateSave: true
            });
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


