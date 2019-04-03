<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCronogramaDetalle.aspx.cs" Inherits="SysAcademico.AdminCronogramaDetalle" %>

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

    <style>
        .file {
            visibility: hidden;
            position: absolute;
        }
    </style>

    <form id="form1" runat="server" novalidate>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
            function endReq(sender, args) {

                $(document).ready(function () {
                    $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
                        "order": [[0, 'asc']],
                        searching: false,
                        destroy: true,
                        stateSave: true
                    });
                });
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <h4 class="page-title">CRONOGRAMA DETALLE</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="card-box table-responsive">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">Cronograma:</label>
                                        <asp:DropDownList runat="server" class="form-control" ID="cmb_cronograma" AutoPostBack="true" OnSelectedIndexChanged="cmb_cronograma_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="m-t-25"></div>
                            <asp:GridView ID="GridCarrera" GridLines="None" CssClass="gvv m-0 table table-striped dt-responsive nowrap dataTable no-footer dtr-inline" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" DataSourceID="ObjectDataSource1" OnRowUpdating="GridCarrera_RowUpdating" OnRowCommand="GridCarrera_RowCommand" OnRowDataBound="GridCarrera_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label ID="ID_CRONOGRAMA_DETALLE" runat="server" Text='<%# Bind("ID_CRONOGRAMA_DETALLE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SEMANA">
                                        <ItemTemplate>
                                            <asp:Label ID="SEMANA_CRONOGRAMA" runat="server" Text='<%# Bind("SEMANA_CRONOGRAMA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FECHA">
                                        <ItemTemplate>
                                            <asp:Label ID="FECHA_CRONOGRAMA" runat="server" Text='<%# Bind("FECHA_CRONOGRAMA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DIA">
                                        <ItemTemplate>
                                            <asp:Label ID="DIA" runat="server" Text='<%# Bind("DIA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TEMA">
                                        <ItemTemplate>
                                            <asp:Label ID="TEMA" runat="server" Text='<%# Bind("TEMA") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_tema" Text='<%# Bind("TEMA") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TEMATICA">
                                        <ItemTemplate>
                                            <asp:Label ID="TEMATICA" runat="server" Text='<%# Bind("TEMATICA") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txt_tematica" TextMode="MultiLine" CssClass="form-control" Text='<%# Bind("TEMATICA") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REQUERIMIENTO">
                                        <ItemTemplate>
                                            <asp:Label ID="REQUERIMIENTO" runat="server" Text='<%# Bind("REQUERIMIENTO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txt_requerimiento" TextMode="MultiLine" CssClass="form-control" Text='<%# Bind("REQUERIMIENTO") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FERIADO">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="FERIADO" runat="server" Checked='<%#Convert.ToBoolean(Eval("FERIADO")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="ckb_feriado" runat="server" Checked='<%#Convert.ToBoolean(Eval("FERIADO")) %>' Enabled="true" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="&lt;span class=&quot;fa fa-pencil text-custom&quot;&gt;&lt;/span&gt;" CancelText="&lt;span class=&quot;fa fa-times text-custom&quot;&gt;&lt;/span&gt;" DeleteText="" UpdateText="&lt;span class=&quot;fa fa-save text-custom&quot;&gt;&lt;/span&gt;">
                                        <ControlStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Contenido">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_eliminar" CommandName="Adjunto" CommandArgument='<%# Bind("ID_CRONOGRAMA_DETALLE") %>' runat="server"><i class="zmdi zmdi-attachment-alt"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--                                    <asp:CommandField HeaderText="Editar" ShowEditButton="True" EditText="&lt;span class=&quot;fa fa-pencil text-custom&quot;&gt;&lt;/span&gt;" CancelText="&lt;span class=&quot;fa fa-times text-custom&quot;&gt;&lt;/span&gt;" DeleteText="" UpdateText="&lt;span class=&quot;fa fa-save text-custom&quot;&gt;&lt;/span&gt;">
                                        <ControlStyle Width="50px" />
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>--%>
                                    <%--<asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" DeleteText="&lt;span class=&quot;fa fa-times&quot;&gt;&lt;/span&gt;"></asp:CommandField>--%>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerDetalle" TypeName="SysAcademico.App_Code.AdminCronogramaDetalle" OnUpdating="ObjectDataSource1_Updating" UpdateMethod="ActualizarCronogramaDetalle">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="cmb_cronograma" DefaultValue="0" Name="ID_CRONOGRAMA" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ID_CRONOGRAMA_DETALLE" Type="String" />
                                    <asp:Parameter Name="TEMA" Type="String" />
                                    <asp:Parameter Name="TEMATICA" Type="String" />
                                    <asp:Parameter Name="REQUERIMIENTO" Type="String" />
                                    <asp:Parameter Name="FERIADO" Type="String" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>

                            <asp:HiddenField Value="" ID="hd_index" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <!-- Modal -->
                    <div id="myModal" class="modal fade" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">CONTENIDO</h4>
                                </div>
                                <div class="modal-body">
                                    <iframe id="iframe_BuscarInscripciones" height="560" width="100%" src="about:blank" scrolling="no" frameborder="0"></iframe>
<%--                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <asp:FileUpload runat="server" ID="file_adjunto" CssClass="file" />
                                                <div class="input-group col-xs-12">
                                                    <span class="input-group-addon"><i class="zmdi zmdi-attachment-alt"></i></span>
                                                    <input type="text" class="form-control" disabled placeholder="Subir Contenido">
                                                    <span class="input-group-btn">
                                                        <button class="browse btn btn-custom" type="button"><i class="glyphicon glyphicon-search"></i>Buscar</button>
                                                    </span>
                                                </div>
                                            </div>
                                            <asp:Button runat="server" ID="btn_subir" Text="Subir" CssClass="btn btn-block btn-custom" OnClick="btn_subir_Click" />
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridInscripcion" GridLines="None" CssClass="table m-0" AutoGenerateColumns="false" runat="server" ShowHeaderWhenEmpty="True" DataKeyNames="ID_CRONOGRAMA_ADJUNTO,ID_CRONOGRAMA_DETALLE,RUTA_ADJUNTO,ICONO_ADJUNTO,PESO_ADJUNTO,NOMBRE_ADJUNTO" OnPreRender="GridInscripcion_PreRender">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="icono" CssClass="lead m-t-0  text-custom"><i class='<%#  Eval("ICONO_ADJUNTO") %>'></i></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="NOMBRE">
                                                        <ItemTemplate>
                                                            <a href='<%#  Eval("RUTA_ADJUNTO") %>' target="_blank"><%#  Eval("NOMBRE_ADJUNTO") %></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="TAMAÑO" DataField="PESO_ADJUNTO" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="con-close-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                    <h4 class="modal-title">Datos Carrera</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:UpdatePanel runat="server" ID="up2">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">Nombre Técnico</label>
                                                        <asp:TextBox runat="server" ID="txt_nombre" CssClass="form-control" required></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="field-2" class="control-label">Taller</label>
                                                        <asp:TextBox runat="server" ID="txt_taller" CssClass="form-control" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="field-1" class="control-label">Código</label>
                                                        <asp:TextBox runat="server" ID="txt_codigo" CssClass="form-control" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                "order": [[0, 'asc']],
                searching: false,
                destroy: true,
                stateSave: true
            });
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

    </script>
</body>
</html>





