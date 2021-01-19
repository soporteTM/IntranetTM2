<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Templete.master" CodeFile="documentacion.aspx.cs" Inherits="Modulos_Empleados_documentacion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/fancybox/lib/jquery.mousewheel.pack.js")%>'></script>
    <script type="text/javascript" src = '<%=ResolveClientUrl("~/App_Themes/fancybox/source/jquery.fancybox.pack.js?v=2.1.7")%>'></script>
    <script type = "text/javascript" src ='<%=ResolveClientUrl("~/App_Themes/fancybox/source/helpers/jquery.fancybox-buttons.js?v=1.0.5")%>'></script> 
    <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/fancybox/source/helpers/jquery.fancybox-media.js?v=1.0.6")%>'></script>
    <script type="text/javascript" src='<%=ResolveClientUrl("~/App_Themes/fancybox/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7")%>'> </script>     --%>



    <script src="https://cdn.jsdelivr.net/npm/jquery@3.4.1/dist/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/gh/fancyapps/fancybox@3.5.7/dist/jquery.fancybox.min.css" />
    <script src="https://cdn.jsdelivr.net/gh/fancyapps/fancybox@3.5.7/dist/jquery.fancybox.min.js"></script>


    -   
    <style type="text/css">
        .fancybox-slide--iframe .fancybox-content, .fancybox-slide--map .fancybox-content, .fancybox-slide--pdf .fancybox-content, .fancybox-slide--video .fancybox-content {
            width: 850px;
        }

        .fancybox-is-open .fancybox-bg {
            opacity: .6;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Empleados </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Empleados</a>
                    </li>
                    <li class="active">Documentacion
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>



    <div class="row">
        <div class="col-xs-12">

            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="header-title">

                                <table width="100%" border="0">
                                    <tr>
                                        <td style="width: 100px;">Documentación</td>
                                        <td style="width: 15px; text-align: center;">/</td>
                                        <td style="width: 80px;">Empleado</td>
                                        <td>
                                            <asp:TextBox placeholder="Ingresar nombre del personal" CssClass="form-control autocomplete" data-url="BuscarEmpleados.ashx" ID="txtEmpleado" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtEmpleado_id" runat="server" class="form-control" Style="color: #CCC; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>


                            </div>
                        </div>

                        <div class="col-lg-4" style="text-align: right;">

                            <asp:Button ID="btnBuscarEmpleadoDocumento" CssClass="btn btn-primary " runat="server" Text="Buscar" UseSubmitBehavior="False" OnClick="btnBuscarEmpleadoDocumento_Click" />
                            <asp:Button ID="btnExportarDocumentacion" CssClass="btn btn-primary " runat="server" Text="Exportar" UseSubmitBehavior="False" OnClick="btnExportarDocumentacion_Click" />

                            <asp:HiddenField ID="HFEmpleadoDocumento" runat="server" Value="0" />
                        </div>
                        <div class="clearfix"></div>
                    </div>

                </div>
                <asp:Panel runat="server" ID="PanelDocumento" Visible="false">

                    <asp:HiddenField runat="server" ID="hfCodigoDoc" />
                    <asp:HiddenField runat="server" ID="hfCodigoDoctxt" />
                    <asp:HiddenField runat="server" ID="hfCodId" />
                    <div class="panel-body">
                        <div class="col-md-12">
                            <ul class="nav nav-tabs">
                                <li id="li1" runat="server" class="">
                                    <asp:LinkButton ID="lnkPersonal" runat="server" OnClick="lnkPersonal_Click"><span class="visible-xs"><i class="fa fa-user"></i></span><span class="hidden-xs">1. Personal</span></asp:LinkButton></li>
                                <li id="li2" runat="server" class="">
                                    <asp:LinkButton ID="lnkRegistro" runat="server" OnClick="lnkRegistro_Click"><span class="visible-xs"><i class="fa fa-users"></i></span><span class="hidden-xs">2. Registro</span></asp:LinkButton></li>
                                <li id="li3" runat="server" class="">
                                    <asp:LinkButton ID="lnkCapacitacion" runat="server" OnClick="lnkCapacitacion_Click"><span class="visible-xs"><i class="fa fa-graduation-cap"></i></span><span class="hidden-xs">3. Capacitacion</span></asp:LinkButton></li>
                            </ul>

                            <div class="tab-content">
                                <div class="tab-pane">
                                </div>
                            </div>

                        </div>
                        <!-- end col -->

                        <div class="col-lg-3" style="padding: 0px;">
                            <div class="wizard clearfix vertical">
                                <div class="steps clearfix">
                                    <ul role="tablist">
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-9">
                        </div>

                        <asp:HiddenField runat="server" ID="hfOperacion" />
                        <asp:HiddenField runat="server" ID="hfIDocuento" />
                        <asp:GridView ID="gvDocumento" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvDocumento_PreRender" OnRowCommand="gvDocumento_RowCommand" OnRowDataBound="gvDocumento_RowDataBound">

                            <Columns>
                                <asp:BoundField DataField="IDDocumento" HeaderText="IDDocumento" Visible="false" />
                                <asp:BoundField DataField="IDPersonal" HeaderText="IDPersonal" Visible="false" />
                                <asp:BoundField DataField="codTipo" HeaderText="codTipo" Visible="false" />
                                <asp:BoundField DataField="tipodocumento" HeaderText="Tipo de Documeno" Visible="true" />
                                <asp:BoundField DataField="documentacion" HeaderText="documentacion" Visible="false" />
                                <asp:TemplateField HeaderText="¿Tiene Vigencia?">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVigencia" runat="server" Text='<%# Eval("TieneVigencia") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inicio de Vigencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFchIni" runat="server" Text='<%# Eval("FchInicioVigencia") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fin de Vigencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFchFin" runat="server" Text='<%# Eval("FchFinVigencia") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ToolTip="Registrar Documento" CommandArgument='<%#Eval("IDDocumento")+";"+Eval("codTipo")+";"+Eval("tipodocumento")%>' CommandName="registrar" CssClass="icon-list-primary m-r-5" ID="LinkButton2" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <%--                                                <td>
                                                    <asp:LinkButton ToolTip="Editar Documento" CommandArgument='<%#Eval("IDDocumento")+";"+Eval("FchInicioVigencia")+";"+Eval("FchFinVigencia")+";"+Eval("TieneVigencia")+";"+Eval("Observacion")%>' CommandName="editar" CssClass="icon-list-primary m-r-5" ID="LinkButton3" runat="server"><i class="glyphicon glyphicon-pencil" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>

                                                <td>
                                                    <asp:LinkButton ToolTip="Descargar" CommandArgument='<%# Eval("tipodocumento")+";"+Eval("documentacion")+";"+Eval("FchInicioVigencia")+";"+Eval("FchFinVigencia") %>' CommandName="Descargar" CssClass="icon-list-primary m-l-5" ID="LinkButton9" runat="server"><i class="fa fa-file-pdf-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Ver historico" CommandArgument='<%# Eval("codTipo")%>' CommandName="Visualizar" CssClass="icon-list-primary m-l-5" ID="LinkButton1" runat="server"><i class="glyphicon glyphicon-list-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <%--<td>
                                                    <asp:LinkButton ToolTip="Ver historico" CommandArgument='<%# Eval("codTipo")%>' CommandName="Visualizar" CssClass="icon-list-primary m-l-5" ID="LinkButton3" runat="server"><i class="glyphicon glyphicon-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="lnkVisualizar" href='<%# Page.ResolveUrl(Eval("documentacion").ToString())%>' data-fancybox="images" data-caption='<%# Eval("tipodocumento")%>'><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px; margin-left:5px;"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>



                    </div>
                </asp:Panel>

                <div id="DocumentoReporte" tabindex="-1" role="dialog" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                    <span class="sr-only">Close</span>
                                </button>

                                <h4 class="modal-title">Filtrar Fechas</h4>

                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <span class="text-primary icon icon-info-circle icon-5x"></span>


                                    <div class="col-lg-12">
                                        <asp:DropDownList ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlFitro" runat="server" OnSelectedIndexChanged="ddlFitro_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>


                                    <asp:Panel runat="server" ID="pnlFiltroFechas" Visible="false">
                                        <div class="form-group col-lg-12">

                                            <div class="form-group col-lg-6">
                                                <label for="userName">Fecha Inicio </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <span class="fa fa-calendar"></span></span>
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingresa fecha inicio" data-provide="datepicker" CssClass="form-control datepickers" ID="fchInicioFiltro" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group col-lg-6">
                                                <label for="userName">Fecha Fin </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <span class="fa fa-calendar"></span></span>
                                                    <asp:TextBox required spellcheck="false" placeholder="Ingresa fecha fin" data-provide="datepicker" CssClass="form-control datepickers" ID="fchFinFiltro" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>


                                    <div class="form-group col-lg-12">
                                        <div class="col-lg-12 text-center">
                                            <asp:LinkButton ID="btnExportar" runat="server" CssClass="btn btn-instagram m-t-5" Text="Exportar" OnClick="btnExportar_Click"></asp:LinkButton>

                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="modal-footer"></div>
                        </div>
                    </div>
                </div>

                <div id="modalArchivo" runat="server" tabindex="-1" role="dialog" class="modal fade modalArchivo">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                    <span class="sr-only">Close</span>
                                </button>

                                <h4 class="modal-title">Información de Documento</h4>

                            </div>
                            <div class="modal-body">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label for="userName">Nombre:</label>
                                            <asp:TextBox required CssClass="form-control" ID="txtNombreDocumento" runat="server" Enabled="false"></asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hfCodTipoDocumento" />
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label>Archivo:</label>
                                            <asp:FileUpload required CssClass="form-control" ID="FUArchivoDocumento" runat="server" accept=".pdf, .doc, .docx" />
                                            <asp:HiddenField ID="HFArchivoDocumento" runat="server" />
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">

                                        <div class="col-lg-2">
                                            <label>¿Vigencia?:</label>
                                            <asp:DropDownList required ToolTip="Seleccionar tipo" CssClass="form-control" ID="ddlVigencia" runat="server" OnSelectedIndexChanged="ddlVigencia_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-5">
                                            <label for="userName">Desde:</label>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <span class="fa fa-calendar-check-o"></span>
                                                </span>
                                                <asp:TextBox data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaDesdeDocumento" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-lg-5">
                                            <label>Hasta:</label>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <span class="fa fa-calendar-check-o"></span>
                                                </span>
                                                <asp:TextBox data-provide="datepicker" CssClass="form-control datepickers" ID="txtFechaHastaDocumento" runat="server"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="clearfix"></div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <label>Comentario/Observación</label>
                                            <asp:TextBox CssClass="form-control" ID="txtObservacionDocumento" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>


                            </div>
                            <div class="modal-footer">

                                <div class="m-t-lg">
                                    <asp:HiddenField ID="HFIDArchivo" Value="0" runat="server" />
                                    <asp:LinkButton ID="btnGuardarArchivo" runat="server" Text="Continuar" CssClass="btn btn-primary" OnClick="btnGuardarArchivo_Click" />
                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cerrar</button>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div id="infoModalConfirmacionActualizacion" tabindex="-1" role="dialog" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                    <span class="sr-only">Cerrar</span>
                                </button>
                            </div>
                            <asp:TextBox runat="server" ID="txtEliTipo" Visible="false"></asp:TextBox>
                            <div class="modal-body">
                                <div class="text-center">
                                    <span class="text-danger icon icon-times-circle icon-5x"></span>
                                    <h3 class="text-info">¿Desea Actualizar el documento seleccionado?</h3>
                                    <p>El registro anterior se ocultara y se mostrara el ultimo ingreso</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnActualizar" CssClass="btn btn-info" runat="server" OnClick="btnActualizar_Click"><i class="fa m-r-5"></i> <span>   Actualizar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer"></div>
                        </div>
                    </div>
                </div>


                <div id="modalSeguimiento" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content p-0 b-0">
                            <div class="panel panel-color panel-primary">
                                <div class="panel-heading">
                                    <button type="button" class="close" data-dismiss="modal">
                                        <span aria-hidden="true">×</span>
                                        <span class="sr-only">Close</span>
                                    </button>

                                    <h3 class="panel-title">Historico de documentos</h3>

                                </div>
                                <div class="panel-body">
                                    <asp:GridView ID="gvDocumentoHistorico" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvDocumento_PreRender" OnRowCommand="gvDocumento_RowCommand" OnRowDataBound="gvDocumento_RowDataBound">

                                        <Columns>
                                            <asp:BoundField DataField="IDDocumento" HeaderText="IDDocumento" Visible="false" />
                                            <asp:BoundField DataField="IDPersonal" HeaderText="IDPersonal" Visible="false" />
                                            <asp:BoundField DataField="codTipo" HeaderText="codTipo" Visible="false" />
                                            <asp:BoundField DataField="tipodocumento" HeaderText="Tipo de Documento" Visible="true" />
                                            <asp:BoundField DataField="documentacion" HeaderText="Documentacion" Visible="false" />
                                            <asp:TemplateField HeaderText="¿Tiene Vigencia?">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVigencia" runat="server" Text='<%# Eval("TieneVigencia") %>' Font-Size="10"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inicio Vigencia">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFchIni" runat="server" Text='<%# Eval("FchInicioVigencia") %>' Font-Size="10"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fin Vigencia">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFchFin" runat="server" Text='<%# Eval("FchFinVigencia") %>' Font-Size="10"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                            <asp:TemplateField HeaderText="Estado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>' Font-Size="10"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="20px">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <a class="fancybox" href='<%# Page.ResolveUrl(Eval("documentacion").ToString())%>' title='<%# Eval("tipodocumento")%>'><i class="fa fa-search" style="width: 18px; height: 18px; line-height: 18px; font-size: 18px;"></i></a>
                                                                <script type="text/javascript">
                                                                    $(document).ready(function () {
                                                                        $(".fancybox").fancybox({
                                                                            width: 800,
                                                                            height: 800,
                                                                            type: 'iframe'
                                                                        });
                                                                    });
                                                                </script>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ToolTip="Descargar" CommandArgument='<%# Eval("tipodocumento")+";"+Eval("documentacion")+";"+Eval("FchInicioVigencia")+";"+Eval("FchFinVigencia") %>' CommandName="Descargar" CssClass="icon-list-primary m-l-5" ID="LinkButton9" runat="server"><i class="fa fa-file-pdf-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ToolTip="Eliminar" CommandArgument='<%# Eval("IDDocumento")%>' CommandName="Eliminar" CssClass="icon-list-primary m-l-5" ID="LinkButton3" runat="server"><i class="fa fa-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <HeaderStyle Width="20px" />
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>

                                <div class="modal-footer"></div>




                            </div>
                        </div>
                    </div>
                </div>


                <%-- CONFIRMAR ELIMINADO DE FILA --%>
                <div id="infoModalAlert3" tabindex="-1" role="dialog" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                    <span class="sr-only">Cerrar</span>
                                </button>
                            </div>

                            <div class="modal-body">
                                <div class="text-center">
                                    <span class="text-danger icon icon-times-circle icon-5x"></span>
                                    <h3 class="text-danger">¿Desea eliminar este Documento?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click"><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer"></div>
                        </div>
                    </div>
                </div>
                <%-- FIN DE ELIMINADO DE FILA --%>
            </div>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>
