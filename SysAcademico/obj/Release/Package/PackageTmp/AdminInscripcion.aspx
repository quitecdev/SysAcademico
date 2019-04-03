<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminInscripcion.aspx.cs" Inherits="SysAcademico.AdminInscripcion" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">

    <link rel="shortcut icon" href="assets/images/favicon.ico">

    <title>CAS - Sistema Acádemico</title>

    <link href="assets/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet">
    <link href="assets/plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">

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
    <form id="commentForm" runat="server" method="get" action="" class="form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
            function endReq(sender, args) {

                jQuery('.datepicker-autoclose').datepicker({
                    autoclose: true,
                    todayHighlight: true,
                    format: "dd/mm/yyyy",
                    language: "es"
                });


                function PdfInscripcion(ruta) {
                    $('#VisorPdf').modal('show');
                    alert(ruta);
                }

                $(function () {
                    $(".numeric").numeric();
                    $(".numeric").focus(function () { $(this).css("background-color", "#E0ECF8"); });
                    $(".numeric").blur(function () { $(this).css("background-color", "#eee"); });
                    $('.guion').numeric("-");
                });

                //$(document).ready(function () {
                //    $("#GridInscripcion.gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                //        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
                //        "aaSorting": [[2, "desc"]], // Sort by first column descending
                //        destroy: true,
                //        stateSave: true
                //    });
                //});

                $(document).ready(function () {
                    $(".gvv").dataTable();
                });
            }
        </script>
        <!-- Page-Title -->
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box p-b-0">
                    <div class="dropdown pull-right">
                        <a href="#" class="dropdown-toggle card-drop" data-toggle="dropdown" aria-expanded="false">
                            <i class="zmdi zmdi-more-vert"></i>
                        </a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a data-toggle="modal" data-target="#modalBuscar">Buscar</a></li>
                        </ul>
                    </div>

                    <h4 class="header-title m-t-0 m-b-30">INSCRIPCIÓN CARRERAS</h4>

                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <h3>DATOS PERSONALES</h3>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="DIfield">Tipo Documento</label>
                                        <div class="col-sm-9">
                                            <asp:DropDownList runat="server" ID="cmb_nacionalidad" TabIndex="1" class="form-control" required>
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem Value="CEDULA">CEDULA</asp:ListItem>
                                                <asp:ListItem Value="PASAPORT">PASAPORTE</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="DIfield">Nº Documento de Identidad</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox runat="server" ID="txt_DI" TabIndex="2" class="number ci form-control" AutoPostBack="True" OnTextChanged="txt_DI_TextChanged" required></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Apellido_Paterno_field">Apellido Paterno</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txt_apellido_paterno" class="required form-control" TabIndex="3" style="text-transform: uppercase;" required></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Primer_Nombre_field">Primer Nombre</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txt_primer_nombre" class="form-control" TabIndex="5" style="text-transform: uppercase;" required></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Fecha_Nacmiento_field">Fecha de Nacimiento</label>
                                        <div class="col-sm-9">
                                            <div class="input-group">
                                                <asp:TextBox runat="server" ID="txt_fecha_nacimiento" class="datepicker-autoclose form-control" placeholder="dd/mm/yyyy" TabIndex="7" required></asp:TextBox>
                                                <span class="input-group-addon bg-custom b-0 text-white"><i class="ti-calendar"></i></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Telf_field">Teléfono</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txt_telf" style="text-transform: uppercase;" class="number form-control" TabIndex="9"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Telf_Emer_field">Teléfono Emergencia</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txt_emergencia" style="text-transform: uppercase;" class="number form-control" TabIndex="11"></asp:TextBox>
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
                                            <asp:TextBox runat="server" ID="txt_direccion" style="text-transform: uppercase;" class="form-control" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Apellido_Materno_field">Apellido Materno</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txt_apellido_materno" style="text-transform: uppercase;" class="form-control" TabIndex="4"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-3 control-label" for="Segundo_Nombre_field">Segundo Nombre</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox runat="server" ID="txt_segundo_nombre" style="text-transform: uppercase;" class="form-control" TabIndex="6"></asp:TextBox>
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
                                            <asp:TextBox runat="server" ID="txt_celular" style="text-transform: uppercase;" class="number form-control" TabIndex="10" required></asp:TextBox>
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
                            <div class="clearfix"></div>
                            <div class="m-t-25"></div>
                            <h3>DATOS CARRERA</h3>
                            <div class="clearfix"></div>
                            <div class="m-t-25"></div>
                            <button class="btn btn-custom waves-effect waves-light m-b-5" data-toggle="modal" data-target="#con-close-modal"><i class="zmdi zmdi-plus-circle m-r-5"></i><span>Añadir</span> </button>
                            <div class="m-t-25"></div>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="GridMateriasAsiganadas" GridLines="None" CssClass="table" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" OnRowDeleting="GridMateriasAsiganadas_RowDeleting" DataSourceID="ObjectDataSource1" OnRowCommand="GridMateriasAsiganadas_RowCommand" OnRowDataBound="GridMateriasAsiganadas_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_INSCRIP_DETALLE_CARRERA" runat="server" Text='<%# Bind("ID_INSCRIP_DETALLE_CARRERA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SEDE">
                                                <ItemTemplate>
                                                    <asp:Label ID="DESCRIPCION_UNIVERSIDAD" runat="server" Text='<%# Bind("DESCRIPCION_UNIVERSIDAD") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CARRERA">
                                                <ItemTemplate>
                                                    <asp:Label ID="DESCRIPCION_CARRERA" runat="server" Text='<%# Bind("DESCRIPCION_CARRERA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HORARIO">
                                                <ItemTemplate>
                                                    <asp:Label ID="DESCRIPCION_INTERVALO" runat="server" Text='<%# Bind("DESCRIPCION_INTERVALO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HORA">
                                                <ItemTemplate>
                                                    <asp:Label ID="HORA" runat="server" Text='<%# Bind("HORA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PARALELO">
                                                <ItemTemplate>
                                                    <asp:Label ID="DESCRIPCION_PARALELO" runat="server" Text='<%# Bind("DESCRIPCION_PARALELO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID_INSCRIPCION_ESTADO" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="ID_INSCRIPCION_ESTADO" runat="server" Text='<%# Bind("ID_INSCRIPCION_ESTADO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ESTADO">
                                                <ItemTemplate>
                                                    <asp:Label ID="DESCRIPCION_ESTADO" runat="server" Text='<%# Bind("DESCRIPCION_ESTADO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FORMA DE PAGO">
                                                <ItemTemplate>
                                                    <asp:Label ID="DESCRIPCION_TIPO_PAGO" runat="server" Text='<%# Bind("DESCRIPCION_TIPO_PAGO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="# FACTURA">
                                                <ItemTemplate>
                                                    <asp:Label ID="NUMERO_FACTURA" runat="server" Text='<%# Bind("NUMERO_FACTURA") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="ESTADO" runat="server" Value='<%# Bind("ESTADO") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_eliminar" ToolTip="Editar" CommandName="Editar" CommandArgument='<%# Bind("ID_INSCRIP_DETALLE_CARRERA") %>' runat="server">
                                                <span class="zmdi zmdi-edit text-custom"></span>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                                <ControlStyle Width="50px" />
                                                <FooterStyle Width="50px" />
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div class="alert alert-danger alert-dismissible fade in" role="alert">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                    <span aria-hidden="true">×</span>
                                                </button>
                                                <strong>¡Vaya!</strong> Parece que no existen carreras asignadas.
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ObtenerDetalle" TypeName="SysAcademico.App_Code.AdminInscripcionDetalleCarrera">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="txt_DI" DefaultValue="0" Name="ID_INSCRIP" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    <asp:HiddenField Value="" ID="hd_index" runat="server" />
                                    <asp:HiddenField Value="" ID="id_inscripcion_detalle" runat="server" />
                                </div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="m-t-25"></div>
                            <h3>DATOS ADICIONALES</h3>
                            <div class="m-t-25"></div>
                            <div class="form-group clearfix">
                                <div class="row">
                                    <div class="col-md-offset-1 col-md-5">
                                        <h4>Requisitos</h4>
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
                                    </div>
                                    <div class="col-md-5">
                                        <h4>Como nos encontró</h4>
                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="radio radio-custom m-b-15">
                                                    <input type="radio" runat="server" checked name="radio" id="rd_web" value="web">
                                                    <label for="rd_web" class="lead">
                                                        Pagina Web
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="radio radio-custom m-b-15">
                                                    <input type="radio" runat="server" name="radio" id="rd_amigo" value="amigo">
                                                    <label for="rd_amigo" class="lead">
                                                        Amigos
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="radio radio-custom m-b-15">
                                                    <input type="radio" runat="server" name="radio" id="rd_facebook" value="facebook">
                                                    <label for="rd_facebook" class="lead">
                                                        Facebook
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="radio radio-custom m-b-15">
                                                    <input type="radio" runat="server" name="radio" id="rd_twitter" value="twitter">
                                                    <label for="cb_twitter" class="lead">
                                                        Twitter
                                                    </label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class=" col-md-12">
                                                <div class="radio radio-custom m-b-15">
                                                    <input type="radio" runat="server" name="radio" id="rd_otro" value="otro">
                                                    <label for="rd_otro" class="lead">
                                                        Otros
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="m-t-25"></div>
                                <div class="row">
                                    <div class="col-md-offset-1 col-md-5">
                                        <asp:Button runat="server" ID="btn_guardar" CssClass="btn btn-custom" Text="Guardar" OnClick="btn_guardar_Click" />
                                        <asp:Button runat="server" ID="btn_nuevo" CssClass="btn btn-custom" Text="Nuevo" OnClick="btn_nuevo_Click" UseSubmitBehavior="False" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                            <div class="clearfix"></div>
                            <div class="m-t-25"></div>
                            <div class="m-t-25"></div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                            <label for="field-1" class="control-label">Sede</label>
                                            <asp:DropDownList runat="server" ID="cmb_sede" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_sede_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-2" class="control-label">Carrera</label>
                                            <asp:DropDownList runat="server" ID="cmb_materia" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_materia_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Horario</label>
                                            <asp:DropDownList runat="server" ID="cmb_horario" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_horario_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Hora</label>
                                            <asp:DropDownList runat="server" ID="cmb_hora" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_hora_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Paralelo</label>
                                            <asp:DropDownList runat="server" ID="cmb_paralelo" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Forma de Pago</label>
                                            <asp:DropDownList runat="server" ID="cmb_forma_pago" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_forma_pago_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="div_factura">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Factura</label>
                                            <asp:TextBox runat="server" ID="txt_factura" class="form-control" data-mask="999-999-9999999"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btn_agregar" CssClass="btn btn-custom ValidarControl" TabIndex="20" Text="Agregar" OnClick="btn_agregar2_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <div id="modalEditar" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title">Datos Carrera</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Sede</label>
                                            <asp:DropDownList runat="server" ID="cmb_sedeEditar" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_sedeEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-2" class="control-label">Carrera</label>
                                            <asp:DropDownList runat="server" ID="cmb_carrearEditar" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_carrearEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Horario</label>
                                            <asp:DropDownList runat="server" ID="cmb_horarioEditar" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_horarioEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Hora</label>
                                            <asp:DropDownList runat="server" ID="cmb_horaEditar" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_horaEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Paralelo</label>
                                            <asp:DropDownList runat="server" ID="cmb_ParaleloEditar" class="form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Forma de Pago</label>
                                            <asp:DropDownList runat="server" ID="cmb_formaPagoEditar" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cmb_formaPagoEditar_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="div2">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="field-1" class="control-label">Factura</label>
                                            <asp:TextBox runat="server" ID="txt_facturaEditar" class="form-control" Enabled="false" data-mask="999-999-9999999"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="bnt_actualizarCarrera" CssClass="btn btn-custom ValidarControl" TabIndex="20" Text="Agregar" OnClick="bnt_actualizarCarrera_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>



        <div id="modalBuscar" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalBuscarLabel" aria-hidden="true">
            <div class="modal-dialog" style="width: 90%;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="modalBuscarLabel">Buscar Inscripciones</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <%-- <iframe id="iframe_BuscarInscripciones" height="615" width="100%" src="about:blank" scrolling="no" frameborder="0"></iframe>--%>
                                <asp:GridView ID="GridInscripcion" GridLines="None" CssClass="table gvv m-0" AutoGenerateColumns="false" runat="server" ShowHeaderWhenEmpty="True" DataKeyNames="ID_INSCRIP,APELLIDOS,NOMBRES,URL" OnSelectedIndexChanged="GridInscripcion_SelectedIndexChanged" OnRowDataBound="GridInscripcion_RowDataBound" OnRowCommand="GridInscripcion_RowCommand" OnPreRender="GridInscripcion_PreRender">
                                    <Columns>
                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton class="btn btn-icon waves-effect waves-light btn-inverse btn-xs m-b-5" CommandName="Select" ID="Seleccionar" runat="server">
                                               <i class="fa fa-magic"></i> </button>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="# IDENTIDAD" DataField="ID_INSCRIP" />
                                        <asp:BoundField HeaderText="APELLIDOS" DataField="APELLIDOS" />
                                        <asp:BoundField HeaderText="NOMBRES" DataField="NOMBRES" />
                                        <asp:BoundField HeaderText="Nº FACTURA" DataField="NUMERO_FACTURA" Visible="false" />
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
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div id="VisorPdf" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="VisorPdfLabel">
            <div class="modal-dialog" role="document" style="width: 90%;">
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

    <!-- Form wizard -->
    <script src="assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.js"></script>
    <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <!-- Calendar -->
    <script src="assets/plugins/moment/moment.js"></script>
    <script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
    <script src="assets/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>

    <!-- App js -->
    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>

    <script src="assets/js/General.js"></script>
    <script src="assets/pages/jquery.Inscripcion.js"></script>
    <!-- Numeric  -->
    <script src="assets/js/jquery.numeric.js"></script>

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

    <script src="assets/plugins/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>
    <script>


        //$(document).ready(function () {
        //    $("#GridInscripcion.gvv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
        //        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100, "Todo"]], //value:item pair
        //        "aaSorting": [[2, "desc"]], // Sort by first column descending
        //        destroy: true,
        //        stateSave: true
        //    });
        //});

        $(document).ready(function () {
            $(".gvv").dataTable();
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

        jQuery('.datepicker-autoclose').datepicker({
            autoclose: true,
            todayHighlight: true,
            format: "dd/mm/yyyy",
            language: "es"
        });

    </script>

</body>
</html>
