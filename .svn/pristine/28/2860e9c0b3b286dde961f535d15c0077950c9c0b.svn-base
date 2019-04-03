<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_SubirContenido.aspx.cs" Inherits="SysAcademico.iframe_SubirContenido" %>

<!DOCTYPE html>

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

    <style>
        .file {
            visibility: hidden;
            position: absolute;
        }


        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>
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
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb" role="navigation">
                        <ol class="breadcrumb" runat="server" id="directorio_link">
                        </ol>
                    </nav>
                    <div id="exTab2" class="container">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a href="#1" data-toggle="tab">Archivos</a>
                            </li>
                            <li><a href="#2" data-toggle="tab">Links</a>
                            </li>
                        </ul>

                        <div class="tab-content ">
                            <div class="tab-pane active" id="1">
                                <div class="form-group">
                                    <asp:FileUpload runat="server" Multiple="Multiple" ID="file_adjunto" CssClass="file" />
                                    <div class="input-group col-xs-12">
                                        <span class="input-group-addon"><i class="zmdi zmdi-attachment-alt"></i></span>
                                        <input type="text" class="form-control" disabled placeholder="Subir Contenido">
                                        <span class="input-group-btn">
                                            <button class="browse btn btn-custom" type="button"><i class="zmdi zmdi-folder"></i>...Examinar</button>
                                        </span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:RadioButton runat="server" CssClass="radio-inline" Checked="true" ID="rd_recurso1" Text="Recursos" GroupName="Carpeta" />
                                    <asp:RadioButton runat="server" CssClass="radio-inline" ID="rd_recetas1" Text="Recetas" GroupName="Carpeta" />
                                </div>
                                <asp:Button runat="server" ID="btn_subir" Text="Subir" CssClass="btn btn-block btn-custom" OnClick="btn_subir_Click" />
                            </div>
                            <div class="tab-pane" id="2">
                                <section class="form-inline" role="form">
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txt_nombre" CssClass="form-control" placeholder="Ingrese nombre"></asp:TextBox>
                                        <%--<input type="email" class="form-control" id="exampleInputEmail21" placeholder="Enter email">--%>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox runat="server" ID="txt_link" CssClass="form-control" placeholder="Ingrese el link"></asp:TextBox>
                                        <%--<input type="email" class="form-control" id="exampleInputEmail21" placeholder="Enter email">--%>
                                    </div>
                                    <div class="form-group">
                                        <asp:RadioButton runat="server" CssClass="radio-inline" Checked="true" ID="rd_recurso2" Text="Recursos" GroupName="Carpeta" />
                                        <asp:RadioButton runat="server" CssClass="radio-inline" ID="rd_recetas2" Text="Recetas" GroupName="Carpeta" />
                                    </div>

                                    <asp:Button runat="server" ID="btn_guardar" Text="Guardar" CssClass="btn btn-block btn-custom" OnClick="btn_guardar_Click" />
                                    <%-- <button type="submit" class="btn btn-block btn-custom">Guardar</button>--%>
                                </section>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridInscripcion" GridLines="None" CssClass="table m-0" AutoGenerateColumns="false" runat="server" ShowHeaderWhenEmpty="True" DataKeyNames="ID_CRONOGRAMA_ADJUNTO,ID_CRONOGRAMA_DETALLE,RUTA_ADJUNTO,ICONO_ADJUNTO,PESO_ADJUNTO,NOMBRE_ADJUNTO" OnRowCommand="GridInscripcion_RowCommand" AllowPaging="True" OnPageIndexChanging="GridInscripcion_PageIndexChanging" PageSize="5">
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
                                            <asp:TemplateField HeaderText="Contenido">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_eliminar" CommandName="Eliminar" CommandArgument='<%# Bind("ID_CRONOGRAMA_ADJUNTO") %>' runat="server"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
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

        $(document).on('click', '.browse', function(){
            var file = $(this).parent().parent().parent().find('.file');
            file.trigger('click');
        });
        $(document).on('change', '.file', function(){
            $(this).parent().find('.form-control').val($(this).val().replace(/C:\\fakepath\\/i, ''));
        });

    </script>
</body>
</html>
