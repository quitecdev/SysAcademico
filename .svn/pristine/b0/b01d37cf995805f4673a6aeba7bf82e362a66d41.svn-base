<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AUX_CORREGIR_INSCRIPCION.aspx.cs" Inherits="SysAcademico.AUX_CORREGIR_INSCRIPCION" %>

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
                <h4 class="page-title">EDITAR</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box table-responsive">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="m-t-25"></div>
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

                            <asp:GridView ID="GridCarrera" GridLines="None" CssClass="gvv m-0 table table-striped dt-responsive nowrap dataTable no-footer dtr-inline" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True" DataKeyNames="ID_INSCRIP_DETALLE_CARRERA,APELLIDO,NOMBRE,DESCRIPCION_UNIVERSIDAD,HORARIO,COD_CARRERA" OnRowCommand="GridCarrera_RowCommand">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="cbk_ok" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="APELLIDO" DataField="APELLIDO" />
                                    <asp:BoundField HeaderText="NOMBRE" DataField="NOMBRE" />
                                    <asp:BoundField HeaderText="DESCRIPCION_UNIVERSIDAD" DataField="DESCRIPCION_UNIVERSIDAD" />
                                    <asp:BoundField HeaderText="HORARIO" DataField="HORARIO" />
                                    <asp:BoundField HeaderText="CARRERA" DataField="COD_CARRERA" />
                                    <asp:TemplateField HeaderText="EDITAR">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_editar" CommandName="Editar" CommandArgument='<%# Bind("ID_INSCRIP_DETALLE_CARRERA") %>' runat="server"><i class="fa fa-pencil"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OCULTAR">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_ocultar" CommandName="Ocultar" CommandArgument='<%# Bind("ID_INSCRIP_DETALLE_CARRERA") %>' runat="server"><i class="fa fa-times-circle-o"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ID_INSCRIP_DETALLE_CARRERA" DataField="ID_INSCRIP_DETALLE_CARRERA" />
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField Value="" ID="id_inscripcion_detalle" runat="server" />

                            <br />
                            <asp:Button ID="btnGetSelected" runat="server" Text="Guardar" OnClick="GetSelectedRecords" />


                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                            <asp:DropDownList runat="server" ID="cmb_carrearEditar" class="form-control" AutoPostBack="True"  OnSelectedIndexChanged="cmb_carrearEditar_SelectedIndexChanged"></asp:DropDownList>
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
                                <asp:Button runat="server" ID="bnt_actualizarCarrera" CssClass="btn btn-custom ValidarControl" TabIndex="20" Text="Agregar" OnClick="bnt_actualizarCarrera_Click" />
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
    <link href="assets/plugins/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <script src="assets/plugins/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>

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

    </script>
</body>
</html>




