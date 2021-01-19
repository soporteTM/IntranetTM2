<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Combustible_Default" %>

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
    <asp:HiddenField ID="hfUsuario" runat="server" />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">

                        <div class="row">
                            <div class="col-md-6">
                                <h4 class="m-t-0 header-title"><b>Abastecimiento</b></h4>
                                <p class="text-muted font-13">
                                    Consulta el detalle de carga de cisterna. 
                                </p>
                            </div>

                            <div class="col-md-6" style="text-align: right;">
                                <asp:LinkButton ID="lnkCisterna" CssClass="btn btn-info waves-effect waves-light m-b-5"
                                    runat="server" OnClick="lnkCisterna_Click">
                                <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  
                                </asp:LinkButton>
                            </div>
                        </div>

                        <div class="row m-b-5">
                            <div class="col-md-4">
                                <h5>Cisterna</h5>
                                <asp:DropDownList ID="ddlCisternasFiltro" CssClass="select2-container" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <h5>Rango de fechas</h5>
                                <div class="input-group input-daterange" data-provide="datepicker" data-date-autoclose="true" data-date-format="dd-M-yyyy">
                                    <asp:TextBox placeholder="dd/MM/yyyy" data-provide="datepicker" CssClass="form-control datepicker" ID="dtpFechaInicioFiltro" runat="server"></asp:TextBox>
                                    <span class="input-group-addon">to</span>
                                    <asp:TextBox placeholder="dd/MM/yyyy" data-provide="datepicker" CssClass="form-control datepicker" ID="dtpFechaFinFilro" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <h5>Estado</h5>
                                <asp:DropDownList ID="ddlEstadoFiltro" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="panelOptions col-md-1" style="text-align: right;">
                                <asp:LinkButton ID="lnkFiltrar" CssClass="btn btn-info waves-effect waves-light m-t-30"
                                    runat="server" OnClick="lnkFiltrar_Click" >
                                <i class="fa fa-list m-r-5"></i> <span class="m-r-5"> Filtrar </span>  
                                </asp:LinkButton>
                            </div>
                        </div>
                        
                        <div class="clearfix"></div>
                        <asp:HiddenField ID="hdCisterna" runat="server" />
                        <asp:HiddenField ID="hdTipoCisterna" runat="server" />
                        <asp:GridView ID="gvConsumo" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="gvConsumo_PreRender" OnRowDataBound="gvConsumo_RowDataBound" OnRowCommand="gvConsumo_RowCommand">

                            <Columns>
                                <asp:BoundField DataField="fila" HeaderText="Nro." />
                                <asp:BoundField Visible="false" DataField="id_cisterna" HeaderText="Codigo" />

                                <asp:TemplateField HeaderText="Cisterna">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcisterna" runat="server" Text='<%# Eval("cod_cisterna") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- <asp:BoundField DataField="cod_cisterna" HeaderText="Cisterna" />--%>
                                <asp:BoundField DataField="cantidad_gl" HeaderText="Galones(Gl.)" DataFormatString="{0:n}" />
                                <asp:BoundField Visible="false" DataField="cantidad_rm_gl" HeaderText="Rem(Gl.)" DataFormatString="{0:n}" />
                                <asp:BoundField DataField="consumo_gl" HeaderText="Consumo(Gl.)" DataFormatString="{0:n}" />
                                <asp:BoundField DataField="saldo_gl" HeaderText="Saldo(Gl.)" DataFormatString="{0:n}" />
                                <asp:BoundField DataField="precio_compra" HeaderText="P.Compra" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="subtotal" HeaderText="Total" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="total" HeaderText="Total(IGV.)" DataFormatString="{0:c}" />
                                <asp:BoundField DataField="nro_factura" HeaderText="Nro Factura" />
                                <asp:BoundField DataField="fecha_registro" HeaderText="Registro" />
                                <asp:BoundField DataField="numero_scop" HeaderText="Numero de scop" />


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
                                                    <asp:LinkButton ToolTip="Detalle Consumo" ID="LinkButton3" CommandArgument='<%# Eval("id_cisterna")+";"+Eval("numero_scop")%>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="detalle"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                </td>

                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ToolTip="Seleccionar" ID="lnkRemanente" CommandArgument='<%# Eval("id_cisterna") %>' CssClass="btn btn-icon waves-effect waves-light btn-danger m-b-5" runat="server" CommandName="remanente"><span class="fa fa-check-square-o"/></asp:LinkButton>
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

                            <h4 class="modal-title">Registro de Cisterna</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">

                                    <label for="name-1" class="control-label">Cisterna </label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlCisterna" runat="server" OnSelectedIndexChanged="ddlCisterna_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>

                                </div>


                                <div class="form-group col-lg-6">

                                    <label for="name-1" class="control-label">Capacidad(Gl.)</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-battery"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Total Gl." CssClass="form-control" ID="txtCapacidad" runat="server"></asp:TextBox>

                                    </div>

                                </div>

                                <div class="form-group col-lg-6">

                                    <label for="name-1" class="control-label">Remanente(Gl.)</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-battery-20"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Total Gl." CssClass="form-control" ID="txtRem" runat="server"></asp:TextBox>

                                    </div>

                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Precio Compra :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-currency-usd"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese precio de compra" CssClass="form-control" ID="txtPrecioCompra" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Total:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-currency-usd"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Total" CssClass="form-control" ID="txtTotalCarga" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Total(IGV.):</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="mdi mdi-currency-usd"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Total + IGV" CssClass="form-control" ID="txtTotalCargaIGV" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Nro. Factura</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-text"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="Nro. Factura" CssClass="form-control" ID="txtFactura" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Nro. Scop</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-text"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtScop" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Fecha Registro</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="dd/MM/yyyy" data-provide="datepicker" CssClass="form-control datepicker" ID="txtFchRegistro" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Fecha Vencimiento</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" placeholder="dd/MM/yyyy" data-provide="datepicker" CssClass="form-control datepicker" ID="txtFchVencimiento" runat="server"></asp:TextBox>

                                    </div>
                                </div>



                                <div class="col-lg-6 m-t-lg text-right">
                                    <asp:LinkButton ID="lnkRegistrar" CssClass="btn btn-info waves-effect waves-light m-b-5 m-t-15"
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

        </asp:View>

        <asp:View ID="View2" runat="server">

            <asp:HiddenField runat="server" ID="hfSaldo" />
            <div class="col-sm-6">
                <h4 class="m-t-0 header-title"><b>Detalle de Consumo</b></h4>
            </div>

            <div class="col-md-12">
                <div class="form-group col-lg-4">
                    <label for="userName">Cliente </label>
                    <asp:DropDownList required CssClass="form-control" ID="ddlCliente" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-lg-8">
                    <div class="col-lg-8">
                    </div>
                    <div class="col-lg-4">
                        <label for="userName">
                            Numero de Scop:
                        </label>
                        <asp:TextBox CssClass="form-control" ID="txtNroScop" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-lg-2" style="text-align: right;">
                    <%--<label for="userName">Galones(Gl.) </label>--%>
                    <asp:TextBox spellcheck="false" CssClass="form-control" ID="txtGalones" runat="server" BorderColor="Black" ForeColor="Blue" Visible="false"></asp:TextBox>
                </div>

                <div class="form-group col-lg-2" style="text-align: right;">
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

                <asp:LinkButton ID="lnkExportar" CssClass="btn btn-info waves-effect waves-light m-b-5"
                    runat="server" OnClick="lnkExportar_Click">
                   <i class="fa fa-download m-r-5"></i> <span> Exportar </span>  </asp:LinkButton>
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
                                        <td style="padding: 0 2px;">
                                            <asp:LinkButton ID="lnkPrint" CommandArgument='<%# Eval("id_abastecimiento") %>' CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="print"><span class="fa fa-print"/></asp:LinkButton>
                                        </td>
                                        <td style="padding: 0 2px;">
                                            <asp:LinkButton OnClientClick="JConfirm('¿Está seguro de que desea eliminar este registro?','Alerta!!',this); return false;" ID="btnDelete" CommandArgument='<%# Eval("id_abastecimiento") %>' CssClass="btn btn-icon waves-effect btn-danger m-b-5" runat="server" CommandName="eliminar"><span class="fa fa-times"/></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField Visible="false" DataField="id_abastecimiento" HeaderText="Codigo" />
                        <asp:BoundField DataField="nro_despacho" HeaderText="Nro.Despacho" />
                        <asp:BoundField DataField="nom_empresa" HeaderText="Cliente" />
                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha" />
                        <asp:BoundField DataField="cod_unidad" HeaderText="Tipo Vehículo" />
                        <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                        <asp:BoundField DataField="nro_placa" HeaderText="Placa" />
                        <asp:BoundField DataField="cnt_inicial" HeaderText="Cnt. Inicial" />
                        <asp:BoundField DataField="cnt_final" HeaderText="Cnt. Final" />
                        <asp:BoundField DataField="km_unidad" HeaderText="KM." />
                        <asp:BoundField DataField="horometro" HeaderText="Horometro" />
                        <asp:BoundField DataField="cantidad_gl" HeaderText="Cantidad(Gl.)" />
                        <asp:BoundField DataField="nom_conductor" HeaderText="Conductor" />
                        <asp:BoundField DataField="precio_galon_igv" HeaderText="Precio" DataFormatString="{0:c}" />
                        <asp:BoundField DataField="total_venta" HeaderText="Total(S/.)" DataFormatString="{0:c}" />
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

                                <div class="form-group col-lg-12">
                                    <label for="name-1" class="control-label">Cliente:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlClienteAdd" runat="server" OnSelectedIndexChanged="ddlClienteAdd_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Ticket:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-ticket"></span>
                                        </span>
                                        <asp:TextBox ID="txtTicket" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Abastecedor:</label>
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
                                        <asp:TextBox ID="txtConductor_id" runat="server" class="form-control" Style="color: #CCC; position: absolute; background: transparent; z-index: 1; display: none;"></asp:TextBox>

                                    </div>
                                </div>


                                <%----------------------------------------------------------------%>
                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Unidad Vehiculo:</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-file-excel-o"></span>
                                        </span>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlTipoVehiculoAdd" runat="server"></asp:DropDownList>
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
                                    <label for="name-1" class="control-label">Contómetro Inicial :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-sort-numeric-asc"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtcntInicial" runat="server"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="name-1" class="control-label">Contómetro Final :</label>
                                    <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-sort-numeric-desc"></span>
                                        </span>
                                        <asp:TextBox required spellcheck="false" CssClass="form-control" ID="txtcntFinal" runat="server"></asp:TextBox>

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
    <script>
        $(document).ready(function () {
            //$('.example').DataTable({
            //    "order": [[1, "asc"]]
            //});
            $('.select2-container').select2({
                box-sizing: "border-box"
                margin: "0"
                position: "relative"
                vertical-align: "middle"
            });
            $('.select2').select2({
                dir: "ltr"
            });
            //$('.select2').on('select2:select', function (e) {

            //    $("input[id*='hfTipo_Empresa_Valores']").val($(this).val());
                
            //});

        });
        </script>

    <script type="text/javascript">


        function round(value, exp) {
            if (typeof exp === 'undefined' || +exp === 0)
                return Math.round(value);

            value = +value;
            exp = +exp;

            if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0))
                return NaN;

            // Shift
            value = value.toString().split('e');
            value = Math.round(+(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp)));

            // Shift back
            value = value.toString().split('e');
            return +(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp));
        }
        
        $(document).ready(function () {

            $("input[id*='txtCapacidad'], input[id*='txtPrecioCompra']").change(function () {
                $("input[id*='txtTotalCarga']").val();
                $("input[id*='txtTotalCargaIGV']").val();
                var valor1 = $("input[id*='txtCapacidad']").val();
                var valor2 = $("input[id*='txtPrecioCompra']").val();
                var valor3 = parseFloat(valor1) * parseFloat(valor2);
                var valor4 = parseFloat(valor3) * 1.18;
                if (valor3 != null && !isNaN(valor3))
                    $("input[id*='txtTotalCarga']").val(round(valor3, 2));
                if (valor4 != null && !isNaN(valor4))
                    $("input[id*='txtTotalCargaIGV']").val(round(valor4, 2));
            });


            $("input[id*='txtcntInicial'], input[id*='txtcntFinal']").change(function () {
                $("input[id*='txtcntInicial']").val();
                $("input[id*='txtcntFinal']").val();
                var valor1 = $("input[id*='txtcntInicial']").val();
                var valor2 = $("input[id*='txtcntFinal']").val();
                var valor3 = parseFloat(valor2) - parseFloat(valor1);
                if (valor3 != null && !isNaN(valor3))
                    $("input[id*='txtGl']").val(round(valor3, 2));

            });


        });

    </script>

</asp:Content>

