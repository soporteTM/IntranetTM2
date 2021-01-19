<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="PreFacturacion.aspx.cs" Inherits="Modulos_TMS_PreFacturacion" %>

<script runat="server">

    protected void hdtCabecera_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void chkDetalleCargaPeligro_CheckedChanged(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Monitoreo de Servicios
                </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Monitoreo</a>
                    </li>
                    <li class="active">Seguimiento
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <div id="panelBotonera" class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="lblMensaje" runat="server"/>
                                
                                <div class="col-lg-10 text-left">
                                    <asp:LinkButton ID="btnModificarCliente" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnModificarCliente_Click" >
                                        <i class="glyphicon glyphicon-plus"></i> Modificar Cliente
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnAnularDocumento" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAnularDocumento_Click">
                                        <i class="glyphicon glyphicon-trash"></i> Anular Documento
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnConsultarTarifa" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnConsultarTarifa_Click">
                                        <i class="glyphicon glyphicon-search"></i> Consultar Tarifa
                                    </asp:LinkButton> 

                                    <asp:LinkButton ID="btnExportarDetalle" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnExportarDetalle_Click" >
                                        <i class="glyphicon glyphicon-save-file m-r-5"></i> Exportar
                                    </asp:LinkButton> 

                                    <%--<asp:LinkButton ID="btnAgregarSeguimiento" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-time"></i> Seguimiento
                                    </asp:LinkButton> --%>

                                    <%-- <asp:LinkButton ID="btnFacturacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-check"></i> Facturación
                                    </asp:LinkButton> --%>
                                    
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div id="panelFacturacion" class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="HiddenField1" runat="server"/>
                                <div class="col-lg-2">
                                    <h4 class="header-title">PANEL DE FACTURACION</h4>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                            <div class="row form-group">
                                <div class="col-md-2">
                                    Documento:
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox CssClass="form-control" ID="txtDocumento" runat="server" Enabled="false" ></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                   <%-- Estado--%>
                                    AL:
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtAL" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    Fecha de Creación:
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtFechaCreacion" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2">
                                    Centro de Costos:
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox CssClass="form-control" ID="txtCentroCostos" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                   <%-- Estado--%>
                                    Cliente:
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" Enabled="false">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    Código Cliente:
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtCodigoCliente" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>

            <div id="modalDetalleTarifaSAP" tabindex="-1" role="dialog" class="modal fade" >
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title mt-0">Tarifario SAP</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body" style="padding-bottom:10px;">
                            <div class="table-responsive" style="margin-top: 10px;">
                                <asp:GridView ID="grvDetalleTarifaSAP" runat="server" CssClass="table table-striped table-bordered dataTable" GridLines="None" AutoGenerateColumns="False"
                                    EmptyDataText="No se encontraron resultados" OnPreRender="grvDetalleTarifaSAP_PreRender">

                                    <Columns>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="hdtCabecera"
                                                    OnCheckedChanged="hdtCabecera_CheckedChanged" AutoPostBack="True" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDetalleFac" runat="server" /></ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="DetFac_Id" HeaderText="ID" />--%>

                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="DetFac_Id" runat="server" Text='<%# Eval("DetFac_Id") %>'></asp:Label>
                                            </ItemTemplate>

                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="DetFac_RO" HeaderText="AL" />
                                        <asp:BoundField DataField="DetFac_Solicitud" HeaderText="Solicitud" />
                                        <asp:TemplateField HeaderText="Servicio Venta" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblServicioVenta" runat="server" Width="150px" Text='<%# Eval("DetFac_Servicio") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle Width="250px" />
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="DetFac_Servicio" HeaderText="Servicio Venta" />--%>
                                        <%--<asp:BoundField DataField="DetFac_ServicioCompras" HeaderText="Servicio Compras" />--%>
                                        <asp:TemplateField HeaderText="Servicio Compras" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblServicioCompra" runat="server" Width="150px" Text='<%# Eval("DetFac_ServicioCompras") %>'
                                                    Font-Underline="False"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="250px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Bic_Peso" HeaderText="Peso" Visible="False" />
                                        <asp:BoundField DataField="Bic_Vol" HeaderText="Volumen" Visible="False" />
                                        <asp:BoundField DataField="DESC_ZONA" HeaderText="Zona" />
                                        <asp:BoundField DataField="DISTRITO_DESCRIP" HeaderText="Distrito" />
                                        <asp:BoundField DataField="DISTRITO_CODIGO" HeaderText="Distrito"
                                            Visible="False" />

                                        <asp:BoundField DataField="DetFac_CargaPeligrosa" HeaderText="CargaPeligrosa."
                                            Visible="False" />
                                        <asp:BoundField DataField="ROT_ContenedorCodigo" HeaderText="Conte." />
                                        <asp:BoundField DataField="DetFac_EstadoFactu" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="DetFac_CodUnidadNegocio" HeaderText="COD. UNI NEG" />

                                        <asp:TemplateField HeaderText="Proveedor">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlTransporte" runat="server" DataTextField="EMPRETRANS_RAZONSOCIAL"
                                                    DataValueField="EMPRETRANS_CODIGO" Height="16px" Width="250px"
                                                    AutoPostBack="True">
                                                </asp:DropDownList><br />
                                                <asp:Label ID="lblTransporte" runat="server" Text='<%# Eval("Transporte") %>'
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlTransporte" runat="server" CssClass="textobox" DataTextField="EMPRETRANS_RAZONSOCIAL"
                                                    DataValueField="EMPRETRANS_CODIGO" Height="16px" Width="118px">
                                                </asp:DropDownList><asp:Label ID="lblTransporte" runat="server" Text='<%# Eval("Transporte") %>'
                                                    Visible="False"></asp:Label>
                                            </EditItemTemplate>
                                            <ItemStyle Wrap="False" />
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="chkCabeceraCargaPeligrosa" Visible="false" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDetalleCargaPeligro" runat="server"
                                                    Width="120" AutoPostBack="True" Visible="false"
                                                    OnCheckedChanged="chkDetalleCargaPeligro_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Cod. Cont." Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLote" runat="server" Text='<%# Eval("Lote") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="OV" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOV" runat="server" Text='<%# Eval("DetFac_OV_DocNum") %>'
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="EM" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEM" runat="server" Text='<%# Eval("DetFac_EM_DocNum") %>'
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="HE" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOE" runat="server" Text='<%# Eval("DetFac_OE_DocNum") %>'
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="ZON_TAR" HeaderText="Cod Zona" />

                                        <%--<asp:CommandField ButtonType="Image" Visible="false" CancelImageUrl="~/Images/canceled.png" EditImageUrl="~/Images/icono_editar.gif"
                                            ShowEditButton="True" UpdateImageUrl="~/Images/ico_actualizar.gif">
                                            <ItemStyle Wrap="False" />
                                        </asp:CommandField>--%>

<%--                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Select" CausesValidation="False" ID="ImageButton1eeea"
                                                    runat="server" CssClass="bt1n14 " ImageUrl="~/App_Themes/Templete/images/icons/dark/close.png"
                                                    ToolTip="Quitar servicio" OnClientClick="return confirm('¿Desea quitar este contenedor?');" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>
                                        <%--<asp:BoundField DataField="Contenedor" HeaderText="Contenedor" />--%>
                                        
                                        <%--<asp:TemplateField HeaderText="SOLICITUD" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="hplSolicitud" CommandName="Editar" CommandArgument='<%# Convert.ToString(Eval("ROS_Kitem")) + "|" + Convert.ToString(Eval("ROS_KRO")) + "|" + Convert.ToString(Eval("TS_DES")) %>' Text='<%# Eval("ROS_Kitem") %>' runat="server"></asp:LinkButton>
                                                <asp:LinkButton ID="lkSolDistrib" CommandName="select" Text='<%# Eval("ROS_Kitem") %>' Visible="false" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                            <asp:LinkButton ID="btnCerrarDetalleTarifa" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="dispose();" Visible="false" >
                                <i class="glyphicon glyphicon-plus"></i> Cerrar
                            </asp:LinkButton>

                        </div>
                    </div>
                </div>
            </div>

            <div id="panelDetalleContenedores" class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="HiddenField3" runat="server"/>
                                <div class="col-lg-2">
                                    <h4 class="header-title">DETALLE DE CONTENEDORES</h4>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;">
                            <div class="table-responsive" style="margin-top: 10px;">
                                <asp:GridView ID="grvDetalleContenedores" runat="server" CssClass="table table-striped table-bordered dataTable" GridLines="None" AutoGenerateColumns="False"
                                    EmptyDataText="No se encontraron resultados" OnPreRender="grvDetalleContenedores_PreRender">

                                    <Columns>

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="checkbox checkbox-primary">
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="." />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="" HeaderText="ID" />
                                        <asp:BoundField DataField="" HeaderText="AL" />
                                        <asp:BoundField DataField="" HeaderText="Solicitud" />
                                        <asp:BoundField DataField="Zona" HeaderText="Servicio Venta" />
                                        <asp:BoundField DataField="Zona" HeaderText="Servicio Compras" />
                                        <asp:BoundField DataField="Zona" HeaderText="Zona" />
                                        <asp:BoundField DataField="Zona" HeaderText="Distrito" />
                                        <asp:BoundField DataField="Zona" HeaderText="Contenedor" />
                                        <asp:TemplateField HeaderText="Evento">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlEvento" runat="server" CssClass="form-control" DataTextField="EVENTO_DESCRIPCION"
                                                    DataValueField="EVENTO_CODIGO">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblNum" runat="server" Text='<%# Eval("Evento") %>'
                                                    Visible="False"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Zona" HeaderText="Cod. Zona" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <i class="glyphicon glyphicon-plus"></i><asp:Button runat="server" ID="btnEliminarContenedor" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="Contenedor" HeaderText="Contenedor" />--%>
                                        
                                        <%--<asp:TemplateField HeaderText="SOLICITUD" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="hplSolicitud" CommandName="Editar" CommandArgument='<%# Convert.ToString(Eval("ROS_Kitem")) + "|" + Convert.ToString(Eval("ROS_KRO")) + "|" + Convert.ToString(Eval("TS_DES")) %>' Text='<%# Eval("ROS_Kitem") %>' runat="server"></asp:LinkButton>
                                                <asp:LinkButton ID="lkSolDistrib" CommandName="select" Text='<%# Eval("ROS_Kitem") %>' Visible="false" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>

            <div id="panelDetalleServicios" class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="HiddenField4" runat="server"/>
                                <div class="col-lg-2">
                                    <h4 class="header-title">DETALLE DE SERVICIOS</h4>
                                </div>
                                <div class="col-lg-10 text-right">
                                    <asp:LinkButton ID="btnAgregarServicio" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarServicio_Click" >
                                        <i class="glyphicon glyphicon-plus"></i> Agregar Servicio
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="btnEliminarServicio" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnEliminarServicio_Click">
                                        <i class="glyphicon glyphicon-trash"></i> Eliminar Servicio
                                    </asp:LinkButton>

                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>


                        <div class="panel-body" style="padding-bottom:10px;">
                            <div class="table-responsive" style="margin-top: 10px;">
                                <asp:GridView ID="grvServicios" runat="server" CssClass="table table-striped table-bordered dataTable" GridLines="None" 
                                    AutoGenerateColumns="False" EmptyDataText="No se encontraron resultados" OnPreRender="grvServicios_PreRender">

                                    <Columns>

                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkServicios" runat="server"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="U_CTS_CSER" HeaderText="Id" />
                                    <asp:BoundField DataField="U_CTS_NSER" HeaderText="Nombre" />
                                        <%--<asp:BoundField DataField="Contenedor" HeaderText="Contenedor" />--%>
                                        
                                        <%--<asp:TemplateField HeaderText="SOLICITUD" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="hplSolicitud" CommandName="Editar" CommandArgument='<%# Convert.ToString(Eval("ROS_Kitem")) + "|" + Convert.ToString(Eval("ROS_KRO")) + "|" + Convert.ToString(Eval("TS_DES")) %>' Text='<%# Eval("ROS_Kitem") %>' runat="server"></asp:LinkButton>
                                                <asp:LinkButton ID="lkSolDistrib" CommandName="select" Text='<%# Eval("ROS_Kitem") %>' Visible="false" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="center" />
                                        </asp:TemplateField>--%>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>

            <asp:HiddenField ID="lblentidad0" runat="server"/>

        </asp:View>
    </asp:MultiView>
</asp:Content>