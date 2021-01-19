<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="ConsumoGrifo.aspx.cs" Inherits="Modulos_Combustible_ConsumoGrifo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <style type="text/css">
        .card-actions {
            margin-top: -15px;
        }

        .md-form-group {
            margin-bottom: 0px !important;
        }

        .btn {
            border-radius: 2px;
            padding: 4px 8px;
            font-size: 12px;
        }

        .table.table-bordered tbody th, table.table-bordered tbody td {
            border-left-width: 0;
            border-bottom-width: 0;
            font-size: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Módulo de Gestión de Unidades </h4>               
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                            <h4 class="m-t-0 header-title"><b>Consumo de Estacion</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Consulta de consumo en Estaciones. 
                            </p>
                        </div>
                        <asp:HiddenField ID="hfUsuario" runat="server" />
                        <asp:HiddenField ID="hfCodCisterna" runat="server" />
                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="lnkCisterna" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                runat="server" OnClick="lnkCisterna_Click">
                   <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  </asp:LinkButton>
                        </div>
                        <div class="clearfix"></div>
                        <asp:HiddenField ID="hdCisterna" runat="server" />
                        <asp:HiddenField ID="hdTipoCisterna" runat="server" />
                        <asp:GridView ID="gvConsumo" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvConsumo_PreRender" OnRowDataBound="gvConsumo_RowDataBound" OnRowCommand="gvConsumo_RowCommand">

                            <Columns>
                                <asp:BoundField DataField="id_Estacion" HeaderText="Codigo Estacion" visible="false" />
                                <asp:BoundField DataField="Estacion_nom" HeaderText="Nombre de Estacion" />
                                <asp:BoundField DataField="Fecha_Inicio2" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="Fecha_Fin2" HeaderText="Fecha Fin" />
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Detalle Consumo" ID="LinkButton3" CommandArgument='<%# Eval("id_Estacion")+";"+Eval("estado") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Cerrar Consumo" ID="LinkButton1" CommandArgument='<%# Eval("id_Estacion") %>' CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server" CommandName="cerrar"><span class="fa fa-check-circle"/></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>


                    </div>
                </div>
            </div>

            
            

           <div id="infoModalAlert2" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro de Grifo</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                 <div class="form-group col-lg-12">
                                    <label for="name-1" class="control-label"> Nombre de Estacion </label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:TextBox CssClass="form-control" ID="txtNomEstacion" runat="server" BorderColor="Black" ForeColor="Blue" ></asp:TextBox>
                                    </div>
                                </div>
                                

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Fecha Inicio</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" required parsley-trigger="change" CssClass="form-control" ID="txtFechaInicio" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Fecha Fin</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" required parsley-trigger="change" CssClass="form-control" ID="txtFechaFin" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="m-t-lg text-right">
                                    <asp:LinkButton ID="lnkRegistrar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                        runat="server" OnClick="lnkRegistrar_Click">
                   <i class="fa fa-save m-r-5"></i> <span>Procesar</span>  </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

             <div id="infoModalRemanente" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Seleccionar Cisterna</h4>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">
                                    <label for="userName">Cisterna: </label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlCisternaR" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="col-lg-12 text-center">
                                        <asp:LinkButton ID="lnkRegistroRemanente" runat="server" CssClass="btn btn-instagram m-t-5" Text="Aceptar" OnClick="btnInsertarR_Click"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                       <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

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
                                    <h3 class="text-primary">¿Desea cerrar la estacion seleccionada?</h3>
                                    <p>Debe estar seguro antes de cerrar una estacion del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnCerrar" CssClass="btn btn-primary" runat="server" OnClick="btnCerrar_Click" ><i class="fa m-r-5"></i> <span>   Cerrar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

        </asp:View>

        <asp:View ID="View2" runat="server">

            <asp:HiddenField  runat="server" ID="hfSaldo"/>
            <div class="col-sm-6">
                <h4 class="m-t-0 header-title"><b>Detalle de Consumo</b></h4>
            </div>

            <div class="col-md-12">
                <div class="form-group col-lg-4">
                    <label for="userName">Cliente </label>
                    <asp:DropDownList required CssClass="form-control" ID="ddlCliente" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="form-group col-lg-2" style="text-align:right;">
                    <%--<label for="userName">Galones(Gl.) </label>--%>
                    <asp:TextBox spellcheck="false" CssClass="form-control" ID="txtGalones" runat="server" BorderColor="Black" ForeColor="Blue" Visible="false"></asp:TextBox>
                </div>

                <div class="form-group col-lg-2" style="text-align:right;">
                    <%--<label for="userName">Consumo(Gl.)</label>--%>
                    <asp:TextBox spellcheck="false" CssClass="form-control" ID="txtConsumo" runat="server" BorderColor="Black" ForeColor="Blue" Visible="false"></asp:TextBox>
                </div>

            
            </div>

            <div class="panelOptions col-sm-12" style="text-align: right;">

                <asp:LinkButton ID="lnkRegresar" CssClass="btn btn-default waves-effect waves-light m-b-5"
                    runat="server" OnClick="lnkRegresar_Click">
                    <span> Regresar </span>  </asp:LinkButton>

                <asp:LinkButton ID="lnkAgregar" CssClass="btn btn-warning waves-effect waves-light m-b-5"
                    runat="server" OnClick="lnkAgregar_Click">
                   <i class="fa fa-plus m-r-5fa fa-search m-r-5"></i> <span> Agregar </span>  </asp:LinkButton>

                <asp:LinkButton ID="lnkBuscar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                    runat="server" OnClick="lnkBuscar_Click">
                   <i class="fa fa-search m-r-5"></i> <span> Buscar </span>  </asp:LinkButton>

                <asp:linkbutton id="lnkexportar" cssclass="btn btn-info waves-effect waves-light m-b-5"
                    runat="server" onclick="lnkexportar_Click">
                   <i class="fa fa-download m-r-5"></i> <span> exportar </span>  </asp:linkbutton>
            </div>
            <div class="clearfix"></div>

            <div class="card-box table-responsive">
                <asp:HiddenField ID="hdfCisterna" runat="server" />
                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowDataBound="gvDetalle_RowDataBound" OnRowCommand="gvDetalle_RowCommand" OnPreRender="gvDetalle_PreRender">

                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <%--<td style="padding: 0 2px;">
                                            <asp:LinkButton ID="lnkPrint" CommandArgument='<%# Eval("id_consumo_estacion") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="print"><span class="fa fa-print"/></asp:LinkButton>
                                        </td>--%>
                                        <td style="padding: 0 2px;">
                                            <asp:LinkButton OnClientClick="JConfirm('¿Está seguro de que desea eliminar este registro?','Alerta!!',this); return false;" ID="btnDelete" CommandArgument='<%# Eval("id_consumo_estacion") %>' CssClass="btn btn-icon waves-effect btn-danger m-b-5" runat="server" CommandName="eliminar"><span class="fa fa-times"/></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField Visible="false" DataField="id_consumo_estacion" HeaderText="Codigo" />
                        <asp:BoundField DataField="nro_despacho" HeaderText="Nro.Despacho" />
                        <asp:BoundField DataField="nom_empresa" HeaderText="Cliente" />
                        <asp:BoundField DataField="fecha_registro2" HeaderText="Fecha" />
                        <asp:BoundField DataField="cod_unidad" HeaderText="Tipo Vehículo" />
                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                        <asp:BoundField DataField="nro_placa" HeaderText="Placa" />
                        <asp:BoundField DataField="km_unidad" HeaderText="KM." />
                        <asp:BoundField DataField="horometro" HeaderText="Horometro" />
                        <asp:BoundField DataField="cantidad_gl" HeaderText="Cantidad(Gl.)" />
                        <asp:BoundField DataField="nom_conductor" HeaderText="Conductor" />
                        <asp:BoundField DataField="precio_galon_igv" HeaderText="Precio"  DataFormatString="{0:c}" />
                        <asp:BoundField DataField="total_venta" HeaderText="Total(S/.)"  DataFormatString="{0:c}" />
                        <asp:BoundField DataField="NDS" HeaderText="NDS"  />
                        <asp:BoundField DataField="nom_estacion" HeaderText="Nombre Estacion"  />
                        <asp:BoundField DataField="nom_abastecedor" HeaderText="Abastecedor" />
                    </Columns>
                </asp:GridView>
            </div>

            <div id="infoModalAlertAdd" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Consumo de Cisterna</h4>

                        </div>

                         <div class="col-lg-12 m-t-10">                            

                              <asp:Literal runat="server" ID="ltCisterna">
                                    
                            </asp:Literal>
                        </div>

                       

                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label"> Cliente:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlClienteAdd" runat="server" OnSelectedIndexChanged="ddlClienteAdd_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label"> Nombre de Estacion:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:TextBox ID="txtNomEstacion2" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label"> Ticket:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-ticket"></span>
                                        </span>
                                        <asp:TextBox ID="txtTicket" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label"> Numero de NDS:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-ticket"></span>
                                        </span>
                                        <asp:TextBox ID="txtNDS" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label"> Abastecedor:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-street-view"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlAbastecedor" runat="server"></asp:DropDownList>
                                    </div>
                                </div>


                                  <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Conductor:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-street-view"></span>
                                        </span>
                                        <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarConductor.ashx" ID="txtConductor" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtConductor_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>

                                    </div>
                                </div>


                                <%----------------------------------------------------------------%>
                                  <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Unidad Vehiculo:</label>
                                     <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlTipoVehiculoAdd" runat="server"> </asp:DropDownList>
                                    </div>
                                </div>
                                <%----------------------------------------------------------------%>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Unidad :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-bars"></span>
                                        </span>

                                        <%--<asp:Literal runat="server" ID="lstUnidad"> </asp:Literal>--%>

                                        <asp:TextBox required CssClass="form-control" data-url="BuscarUnidad.ashx" ID="txtVehiculo" runat="server"></asp:TextBox>

                                        <%-- <asp:textbox required Cssclass="form-control" ID="txtVehiculo" runat="server" Visible="false"></asp:textbox>--%>                                        
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Placa :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-truck"></span>
                                        </span>
                                        <%--<asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtPlaca" runat="server"></asp:TextBox>--%>
                                       <asp:TextBox ID="txtVehiculo_id" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">KM :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-indent"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtkm" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Horómetro :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-indent"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtHorometro" runat="server"></asp:TextBox>

                                    </div>
                                </div>                               

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Galones(gl.) :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-battery-3"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtGl" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Precio(gl.) :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-battery-3"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtPrecioGl" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <%--<div class="form-group col-lg-6">--%>
                                   <%-- <label for="name-1" class="control-label">N° Despacho :</label>--%>
                                    <div class="input-group">
                                        <%--<span class="input-group-addon">
                                            <span class="fa fa-reorder"></span>
                                        </span>--%>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtNroDespacho" runat="server" Visible="false"></asp:TextBox>

                                    </div>
                               <%-- </div>--%>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Fecha :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy" required parsley-trigger="change" CssClass="form-control" ID="txtFecha" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="m-t-lg text-right">
                                    <asp:LinkButton ID="lnkAddConsumo" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                        runat="server" OnClick="lnkAddConsumo_Click">
                   <i class="fa fa-save m-r-5"></i> <span>Registrar</span>  </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>         
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

