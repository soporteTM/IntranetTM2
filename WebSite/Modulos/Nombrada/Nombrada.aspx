<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Nombrada.aspx.cs" Inherits="Modulos_Nombrada_Nombrada" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Programacion de unidades </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Zircos</a>
                    </li>
                    <li>
                        <a href="#">Charts </a>
                    </li>
                    <li class="active">Google Charts
                                        </li>
                </ol>
                <div class="clearfix"></div>
                
            </div>
        </div>
    </div>
    <!-- end row -->


    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="clearfix"></div>
                            <asp:Label  ID="lblMensaje" runat="server" CssClass="text1" Font-Bold="True" ForeColor="#CC3300" Visible="false"></asp:Label>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <asp:Label  ID="lblfecha" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha:</asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <span class="fa fa-calendar-check-o"></span>
                                                </span>
                                                <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtFecha" runat="server"></asp:TextBox>
                                            </div>
                                    </div>
                                    <div class="panelOptions col-sm-10 m-t-15" style="text-align: right;">
                                        <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-warning" runat="server" OnClick="btnFiltrar_Click" ><i class="fa fa-search m-r-5"></i> <span>  Buscar</span>  </asp:LinkButton>
                                        <asp:LinkButton ID="btnAgregar" CssClass="btn btn-info" runat="server" OnClick="btnAgregar_Click"><i class="fa fa-plus m-r-5"></i> <span>  Agregar</span>  </asp:LinkButton>                         
                                        <asp:LinkButton ID="btnExportar" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="btnExportar_Click" ><i class="glyphicon glyphicon-save-file m-r-5"></i> <span> Exportar </span> </asp:LinkButton>
                                    <%--<asp:LinkButton ID="btnEnviar" CssClass="btn btn-instagram" runat="server"  Visible="true" OnClick="btnEnviar_Click" ><i class="fa fa-envelope m-r-5"></i> <span>  Enviar</span>  </asp:LinkButton>--%>
                                    </div>
                                </div>
                       </div>
                        <%-- Grid View Nombrada --%>
                       <asp:GridView ID="grvNombrada" runat="server" AutoGenerateColumns="False"
                       CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="grvNombrada_RowCommand" OnPreRender="grvNombrada_PreRender" >

                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" Visible="false"  />
                                    <asp:BoundField DataField="id_unidad" HeaderText="Codigo Unidad" Visible="false"  />
                                    <asp:BoundField DataField="cod_interno" HeaderText="Codigo Interno" />
                                    <asp:BoundField DataField="nro_placa" HeaderText="Numero de Placa" />
                                    <asp:BoundField DataField="id_conductor"  HeaderText="Codigo Conductor" Visible="false" />
                                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" Visible="true"  />
                                    <asp:BoundField DataField="nro_licencia" HeaderText="Brevete" Visible="true"  />
                                    <asp:BoundField DataField="tipo" HeaderText="Operacion" />
                                    <asp:BoundField DataField="observacion" HeaderText="Observaciones" />
                                    <asp:BoundField DataField="status_unidad" HeaderText="Estado" Visible="false" />
                                    <asp:TemplateField ItemStyle-Width="20px" >
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td style="padding: 0 2px;">
                                                        <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id")+";"+Eval("cod_interno")+";"+Eval("nro_placa")+";"+Eval("NombreCompleto")+";"+Eval("tipo")+";"+Eval("id_unidad")+";"+Eval("observacion")+";"+Eval("id_conductor")%>' CssClass="btn btn-info waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Modificar"><span class="fa fa-pencil-square-o" /></asp:LinkButton>
                                                    </td>
                                                    <td style="padding: 0 2px;">
                                                        <asp:LinkButton ToolTip="Eliminar Conductor" OnClientClick="JConfirm('Debe estar seguro antes de eliminar información del sistema','¿Desea eliminar este Conductor?',this); return false;" CommandArgument='<%# Eval("id") %>' CommandName="eliminar" CssClass="btn btn-danger waves-effect waves-light btn-primary m-b-5"    ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        <%-- Fin Grid View Nombrada --%>
                    </div>
            </div>

            <%-- ACTUALIZAR CONDUCTOR --%>
            <div id="infoModalAlert2" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Datos del Conductor</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <asp:TextBox  spellcheck="false" CssClass="form-control col-" ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                                <%-- AUTO COMPLETADO CONDUCTOR --%>
                                <div class="form-group col-lg-12">
                                    <label for="userName">Conductor </label>
                                    <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarConductor.ashx" ID="txtUnidad" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtUnidad_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                </div>
                                <%-- FIN AUTOCOMPLETADO CONDUCTOR --%>

                                <div class="form-group col-lg-12">
                                    <%-- AUTO COMPLETADO UNIDAD --%>
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Codigo de la unidad </label>
                                        <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarUnidad.ashx" ID="txtCodUnidad" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtCodUnidad_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 2;display: none;"></asp:TextBox>
                                    </div>
                                    <%-- FIN DE AUTOCOMPLETADO UNIDAD --%>
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Operacion </label>
                                        <asp:DropDownList  CssClass="form-control" ID="ddlOperacion" runat="server">
                                        </asp:DropDownList>                                
                                    </div>
                                </div>
                                <div class="form-group col-lg-12">
                                    <label for="userName">Observaciones </label>
                                    <asp:DropDownList  CssClass="form-control" ID="ddlObservaciones" runat="server">
                                    </asp:DropDownList>                                
                                </div>

                                <div class="col-sm-3">
                                    <asp:LinkButton ID="btnActualizar" CssClass="btn btn-instagram m-t-5" runat="server" OnClick="btnActualizar_Click" ><i class="glyphicon glyphicon-floppy-saved m-r-5"></i> <span>   Guardar</span>  </asp:LinkButton>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN ACTUALIZAR CONDUCTOR --%>


        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>
</asp:Content>

