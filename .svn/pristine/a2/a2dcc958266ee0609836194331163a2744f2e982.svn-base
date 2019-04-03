<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframeBuscarInscripciones.aspx.cs" Inherits="SysAcademico.iframeBuscarInscripciones" %>

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
                    $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
                        "aaSorting": [[2, "desc"]], // Sort by first column descending
                        destroy: true,
                        stateSave: true
                    });
                });

            }
        </script>
        <div class="row card-box" style="height: 100vh;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridInscripcion" GridLines="None" CssClass="table gvv m-0" AutoGenerateColumns="false" runat="server" ShowHeaderWhenEmpty="True" DataKeyNames="ID_INSCRIP,NOMBRE,APELLIDO_PATERNO_INSCRIP,APELLIDO_MATERNO_INSCRIP,PRIMER_NOMBRE_INSCRIP,SEGUNDO_NOMBRE_INSCRIP,FECHA_NACIMIENTO_INSCRIP,DESCRIPCION_NACIONALIDAD,ID_ESTADO_CIVIL,ID_CIUDAD,ID_PROVINCIA,DIRECCION,TELEF_INSCRIP,CEL_INSCRIP,TELEF_EMER_INSCRIP,IMG_INSCRIP,DOC_IDENTIDAD,PAPELETA_VOT,FOTOGRAFIA,CERT_MEDICO,ID_INSCRIPCION_ESTADO,DESCRIPCION_ESTADO,URL,NUMERO_FACTURA" OnSelectedIndexChanged="GridInscripcion_SelectedIndexChanged" OnRowDataBound="GridInscripcion_RowDataBound" OnRowCommand="GridInscripcion_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton class="btn btn-icon waves-effect waves-light btn-inverse btn-xs m-b-5" CommandName="Select" ID="Seleccionar" runat="server">
                                               <i class="fa fa-magic"></i> </button>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="# IDENTIDAD" DataField="ID_INSCRIP" />
                            <asp:BoundField HeaderText="NOMBRE" DataField="NOMBRE" />
                            <asp:BoundField HeaderText="Nº FACTURA" DataField="NUMERO_FACTURA" Visible="false" />
                            <asp:TemplateField HeaderText="ESTADO">
                                <ItemTemplate>
                                    <asp:Label ID="lb_estado" runat="server" Text='<%# Eval("DESCRIPCION_ESTADO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="URL" DataField="URL" Visible="false" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ToolTip="Ver Archivo" runat="server" ID="lnk_documento">
                                         <i class="text-primary fa fa-file-pdf-o"></i> </button>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_eliminar" ToolTip="Editar" CommandName="Editar" CommandArgument='<%# Bind("ID_INSCRIP") %>' runat="server">
                                                <span class="zmdi zmdi-edit text-custom"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ControlStyle Width="50px" />
                                <FooterStyle Width="50px" />
                                <HeaderStyle Width="50px" />
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div id="modalEstado" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalBuscarLabel" aria-hidden="true">
            <div class="modal-dialog" style="width: 65%;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="modalBuscarLabel">REQUISITOS</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <h3 runat="server" id="nombre"></h3>
                                <div class="row">
                                    <div class="col-md-offset-1 col-md-5">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="checkbox checkbox-custom">
                                                    <asp:CheckBox runat="server" ID="ckb_docIdent" />
                                                    <label for="ckb_docIdent" class="lead">
                                                        Documento de Identidad                                  
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="checkbox checkbox-custom">
                                                    <asp:CheckBox runat="server" ID="ckb_foto" />
                                                    <label for="ckb_foto" class="lead">
                                                        Fotografías                                  
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="checkbox checkbox-custom">
                                                    <asp:CheckBox runat="server" ID="ckb_papeleta" />
                                                    <label for="ckb_papeleta" class="lead">
                                                        Papeleta de Votación                                  
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="checkbox checkbox-custom">
                                                    <asp:CheckBox runat="server" ID="ckb_certf" />
                                                    <label for="ckb_certf" class="lead">
                                                        Certificado Médico                                  
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="checkbox checkbox-custom">
                                                    <asp:CheckBox runat="server" ID="ckb_pago" AutoPostBack="true" OnCheckedChanged="ckb_pago_CheckedChanged" />
                                                    <label for="ckb_pago" class="lead text-custom">
                                                        Pago Realizado                                 
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class=" col-md-12">
                                                <label class="control-label" for="Celular_field">Número Factura</label>
                                                <div class="row">
                                                    <div class=" col-md-6">
                                                        <asp:TextBox runat="server" ID="txt_factura" class="form-control" TabIndex="10" Enabled="false" data-mask="999-999-9999999" required></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class=" col-md-12">
                                                <asp:Button runat="server" ID="btn_guardar" CssClass="btn btn-custom" Text="Finalizar" OnClick="btn_guardar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>

        <!-- Modal -->
        <div id="modalEditar" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="VisorPdfLabel">
            <div class="modal-dialog" style="width: 95%;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="H1">EDITAR DATOS PERSONALES</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ID="panel1">
                            <ContentTemplate>
                                <div class="form-horizontal">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="DIfield">Nº Documento de Identidad</label>
                                                <div class="col-sm-4">
                                                    <asp:TextBox runat="server" ID="txt_DI" TabIndex="2" class="number ci form-control" AutoPostBack="True" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Apellido_Paterno_field">Apellido Paterno</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_apellido_paterno" class="required form-control" TabIndex="3" required></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Primer_Nombre_field">Primer Nombre</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_primer_nombre" class="form-control" TabIndex="5" required></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Fecha_Nacmiento_field">Fecha de Nacimiento</label>
                                                <div class="col-sm-9">
                                                    <div class="input-group">
                                                        <asp:TextBox runat="server" ID="txt_fecha_nacimiento" class="date2 form-control" placeholder="dd/mm/yyyy" TabIndex="7" required></asp:TextBox>
                                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="ti-calendar"></i></span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Telf_field">Teléfono</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_telf" class="number form-control" TabIndex="9"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Telf_Emer_field">Teléfono Emergencia</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_emergencia" class="number form-control" TabIndex="11"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Provincia_field">Provincia</label>
                                                <div class="col-sm-9">
                                                    <asp:DropDownList runat="server" ID="cmb_provincia" class="form-control" TabIndex="13" OnSelectedIndexChanged="cmb_provincia_SelectedIndexChanged" AutoPostBack="True" required></asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Direccion_field">Dirección</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_direccion" class="form-control" TabIndex="15"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Apellido_Materno_field">Apellido Materno</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_apellido_materno" class="form-control" TabIndex="4"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Segundo_Nombre_field">Segundo Nombre</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_segundo_nombre" class="form-control" TabIndex="6"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Estado_Civil_field">Estado Civil</label>
                                                <div class="col-sm-9">
                                                    <asp:DropDownList runat="server" ID="cmb_estado_civil" class="form-control" TabIndex="8" required>
                                                        <asp:ListItem Value=""></asp:ListItem>
                                                        <asp:ListItem Value="1">Unión Libre</asp:ListItem>
                                                        <asp:ListItem Value="2">Divorciado(a)</asp:ListItem>
                                                        <asp:ListItem Value="3">Viudo(a)</asp:ListItem>
                                                        <asp:ListItem Value="4">Casado(a)</asp:ListItem>
                                                        <asp:ListItem Value="5">Soltero(a)</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Celular_field">Celular</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_celular" class="number form-control" TabIndex="10" required></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Correo_field">Correo Electrónico</label>
                                                <div class="col-sm-9">
                                                    <asp:TextBox runat="server" ID="txt_correo" TextMode="Email" class="email form-control" TabIndex="12" required></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-sm-3 control-label" for="Ciudad_field">Ciudad</label>
                                                <div class="col-sm-9">
                                                    <asp:DropDownList runat="server" ID="cmb_ciudad" class="form-control" TabIndex="14" required></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-offset-1 col-md-5">
                                            <asp:Button runat="server" ID="btn_actualizar" CssClass="btn btn-custom" Text="Guardar" OnClick="btn_actualizar_Click" />                           
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>


        <!-- Modal -->
        <div id="VisorPdf" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="VisorPdfLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <iframe id="ProformaPdf" src="about:black" width="100%" height="450" onscroll="yes" frameborder="0"></iframe>
                    </div>
                </div>
            </div>
        </div>

    </form>

    <script>
        var resizefunc = [];
        </script>

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

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>


    <!-- Plugins -->
    <script src="assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.js"></script>
    <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>

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
    <script src="assets/plugins/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>

    <script src="assets/js/General.js"></script>
    <script src="assets/pages/jquery.Inscripcion.js"></script>

    <script>
        $(document).ready(function () {
            $(".gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
                "aaSorting": [[2, "desc"]], // Sort by first column descending
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
