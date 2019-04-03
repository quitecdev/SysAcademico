<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMaterias.aspx.cs" Inherits="SysAcademico.AdminMaterias" %>

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
                        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]] //value:item pair
                    });
                });
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">MATERIAS</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box table-responsive">
                    <div class="m-t-25"></div>
                    <button class="btn btn-custom waves-effect waves-light m-b-5" data-toggle="modal" data-target="#con-close-modal"><i class="zmdi zmdi-plus-circle m-r-5"></i><span>Añadir</span> </button>
                    <div class="m-t-25"></div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="m-t-25"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Selecciones Una Carrea:</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList runat="server" class="form-control" ID="cmb_carrera" AutoPostBack="True" OnSelectedIndexChanged="cmb_carrera_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <asp:GridView ID="GridMateria" GridLines="None" CssClass="gvv m-0 table table-striped dt-responsive nowrap dataTable no-footer dtr-inline" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" DataSourceID="ObjectDataSource1" OnRowDeleting="GridMateria_RowDeleting" OnRowEditing="GridMateria_RowEditing" OnRowUpdating="GridMateria_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label ID="ID_MATERIA" runat="server" Text='<%# Bind("ID_MATERIA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CARRERA">
                                        <ItemTemplate>
                                            <asp:Label ID="DESCRIPCION_CARRERA" runat="server" Text='<%# Bind("DESCRIPCION_CARRERA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MATERIA">
                                        <ItemTemplate>
                                            <asp:Label ID="DESCRIPCION_MATERIA" runat="server" Text='<%# Bind("DESCRIPCION_MATERIA") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_nombre" Text='<%# Bind("DESCRIPCION_MATERIA") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CODIGO">
                                        <ItemTemplate>
                                            <asp:Label ID="COD_MATERIA" runat="server" Text='<%# Bind("COD_MATERIA") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_codigoAñadir" Text='<%# Bind("COD_MATERIA") %>' runat="server" CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="&lt;span class=&quot;fa fa-pencil text-custom&quot;&gt;&lt;/span&gt;" CancelText="&lt;span class=&quot;fa fa-times text-custom&quot;&gt;&lt;/span&gt;" DeleteText="" UpdateText="&lt;span class=&quot;fa fa-save text-custom&quot;&gt;&lt;/span&gt;">
                                        <ControlStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>

                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="EliminarMateria" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerMateria" TypeName="SysAcademico.App_Code.AdminMaterias" UpdateMethod="ActualizarMateria" OnDeleting="ObjectDataSource1_Deleting" OnUpdating="ObjectDataSource1_Updating">
                                <DeleteParameters>
                                    <asp:Parameter Name="ID_CARRERA" Type="String" />
                                </DeleteParameters>
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="0" Name="ID_CARRERA" SessionField="ID_CARRERA" Type="String" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ID_MATERIA" Type="String" />
                                    <asp:Parameter Name="DESCRIPCION_MATERIA" Type="String" />
                                    <asp:Parameter Name="COD_MATERIA" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField Value="" ID="hd_index" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                    <h4 class="modal-title">Datos Materia</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:UpdatePanel runat="server" ID="up2">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">Carrera</label>
                                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_CarrearAñadir" required></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-2" class="control-label">Materia</label>
                                                        <asp:TextBox runat="server" ID="txt_materia" CssClass="form-control" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">Código</label>
                                                        <asp:TextBox runat="server" ID="txt_codigo" CssClass="form-control"></asp:TextBox>
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
                "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]] //value:item pair
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




