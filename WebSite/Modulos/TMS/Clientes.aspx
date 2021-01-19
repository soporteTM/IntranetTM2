<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Modulos_TMS_Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript">
     
    </script>
    <style type="text/css"> 
    .dropdown-menu>li>a{
        padding-left:10px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Clientes</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">

            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="lblMensaje" runat="server"/>
                                <div class="col-lg-2">
                                    <h4 class="header-title">Busqueda de Clentes</h4>
                                </div>

                                <div class="col-lg-10 text-right">
                                    <asp:LinkButton ID="btnBuscarCliente" runat="server" CssClass="btn btn-primary btn-sm" OnClientClick="$('.loading').fadeIn('fast');" OnClick="btnBuscarCliente_Click">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton> 

                                    
                                     <asp:LinkButton ID="btnFacturacion" runat="server" CssClass="btn btn-default btn-sm" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-download"></i> Exportar
                                    </asp:LinkButton> 
                                    
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                             <div class="row form-group">
                                <div class="col-md-1">
                                    Cliente
                                </div>
                                <div class="col-md-4">
                                     <asp:TextBox CssClass="form-control" ID="txtFiltroCliente" runat="server"  ></asp:TextBox>
                                </div>
                                
                                <div class="col-md-2">
                                    Estado (TMS):</div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlFiltroEstadoCliente" runat="server" CssClass="form-control" >
                                        <asp:ListItem Value="-1">TODOS</asp:ListItem>
                                        <asp:ListItem Value="1" Selected="True">HABILITADO</asp:ListItem>
                                        <asp:ListItem Value="0">NO HABILITADO</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                         
                        </div>
                    </div>
                </div>
            </div>

            <div id="panelCliente" runat="server" class="row" visible="false">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-lg-8">
                                    <h4 class="header-title">Registrar Sub-Cliente</h4>
                                </div>

                                <div class="col-lg-4" style="text-align: right;">

                                    <%--<asp:LinkButton ID="btnFiltrar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrar_Click">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnActualizar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnActualizar_Click" Visible="false">
                                        <i class="glyphicon glyphicon-plus"></i> Actualizar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnCancelar_Click" Visible="false">
                                        <i class="glyphicon glyphicon-plus"></i> Cancelar
                                    </asp:LinkButton>

                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-1">
                                    <label for="name-1" class="control-label">Codigo:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox required CssClass="form-control" ID="txtEmpresa_id" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-1">
                                    <label for="name-1" class="control-label">Razón Social:</label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox placeholder="Ingresar nombre de cliente" CssClass="form-control" ID="txtCliente" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox placeholder="Ingresar nombre de cliente" CssClass="form-control autocomplete" data-url="BuscarEmpresa.ashx" ID="txtEmpresa" runat="server"></asp:TextBox>
                                    <%--<asp:TextBox ID="txtEmpresa_id" runat="server" class="form-control" Style="color: #CCC; position: absolute; background: transparent; z-index: 1; display: none;"></asp:TextBox>--%>
                                </div>

                                <br /><br />

                                <div class="col-md-1">
                                    <label for="name-1" class="control-label">RUC:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox CssClass="form-control" ID="txtRUC" runat="server"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive1">
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClientes_RowCommand" OnPreRender="gvClientes_PreRender"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" EmptyDataText="No se encontraron resultados.">

                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <div class="btn-group dropdown">
                                            <button style="padding: 2px 5px;" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown" type="button">
                                                <span class="icon icon-gear icon-sx icon-fw">Opciones</span>
                                                <!--Opciones-->
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li>
                                                    <%--<asp:LinkButton ToolTip="Editar" Visible='<%# (Convert.ToInt32(Eval("EstadoTMS")) == 1 ? false : true )%>' CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Editar" CssClass="icon-list-primary" runat="server"><i class="fa fa-edit"></i> Editar </asp:LinkButton>--%>
                                                   <asp:LinkButton ToolTip="Agregar" Visible='<%# (Convert.ToInt32(Eval("EstadoTMS")) == 1 ? false : true )%>' CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Agregar" CssClass="icon-list-primary" runat="server"><i class="fa fa-plus"></i> Agregar </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <%--<asp:LinkButton ToolTip="Eliminar" CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Eliminar" CssClass="icon-list-primary" runat="server"><i class="fa fa-remove"></i> Eliminar </asp:LinkButton>--%>
                                                    <asp:LinkButton ToolTip="Retirar" Visible='<%# (Convert.ToInt32(Eval("EstadoTMS")) == 1 ? true : false )%>' CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Retirar" CssClass="icon-list-primary" runat="server"><i class="fa fa-remove"></i> Retirar </asp:LinkButton>

                                                </li>
                                                <li>
                                                    <asp:LinkButton ToolTip="SubClientes" Visible='<%# (Convert.ToInt32(Eval("EstadoTMS")) == 1 && Eval("Cod_Empresa").ToString() != "" ? true : false )%>' CommandArgument='<%# Eval("Cod_Empresa").ToString() + ";" + Eval("Raz_Soc").ToString() %>' CommandName="Detalles" CssClass="icon-list-primary" runat="server"><i class="fa fa-list"></i> Sub-Clientes </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ToolTip="Horas a Notificar" Visible='<%# (Convert.ToInt32(Eval("EstadoTMS")) == 1 && Eval("Cod_Empresa").ToString() != "" ? true : false )%>' CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Asignacion_Horas" CssClass="icon-list-primary" runat="server"><i class="fa fa-gear"></i> Configurar notificación </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ToolTip="Correos a Notificar" Visible='<%# (Convert.ToInt32(Eval("EstadoTMS")) == 1 && Eval("Cod_Empresa").ToString() != "" ? true : false )%>' CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Asignacion_Correos" CssClass="icon-list-primary" runat="server"><i class="fa fa-gear"></i> Configurar correos </asp:LinkButton>
                                                </li>

                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cod_Empresa" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpresa" runat="server" Text='<%# Eval("Cod_Empresa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Raz_Soc" HeaderText="Razon Social"/>
                                <asp:BoundField DataField="Ruc" HeaderText="RUC" />
                                <asp:BoundField DataField="DescEstadoTMS" HeaderText="Estado (TMS)" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="false" />
                                
                            </Columns>

                        </asp:GridView>

              
                    </div>
                </div>
            </div>
        </asp:View>

        <asp:View ID="View2" runat="server">
            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-lg-8">
                                    <h4 class="header-title">
                                        <asp:Label ID="lblTituloCliente" runat="server" Text="Label"></asp:Label> / Sub-Clientes</h4>
                                </div>

                                <div class="col-lg-4" style="text-align: right;">

                                    <%--<asp:LinkButton ID="btnFiltrar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrar_Click">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnAgregar_SubCliente" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_SubCliente_Click">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnActualizar_SubCliente" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnActualizar_SubCliente_Click" Visible="false">
                                        <i class="glyphicon glyphicon-plus"></i> Actualizar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnCancelar_SubCliente" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnCancelar_SubCliente_Click" Visible="false">
                                        <i class="glyphicon glyphicon-plus"></i> Cancelar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnRegresar" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnRegresar_Click">
                                        Regresar
                                    </asp:LinkButton>
                                    <asp:HiddenField ID="HFIDCliente" runat="server" />
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-1">
                                    <label for="name-1" class="control-label">Codigo:</label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox required CssClass="form-control" ID="txtSubEmpresa_id" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-2">
                                    <label for="name-1" class="control-label">Razón Social:</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox required CssClass="form-control" ID="txtSubCliente" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox placeholder="Ingresar nombre de cliente" CssClass="form-control autocomplete2" data-url="BuscarEmpresa2.ashx" ID="txtSubEmpresa" runat="server"></asp:TextBox>
                                    
                                </div> 
                            </div>
                             <div class="row form-group">
                                <div class="col-md-1">
                                    <label for="name-1" class="control-label">RUC:</label>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox CssClass="form-control" ID="txtRUC_SubCliente" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label for="name-1" class="control-label">Dirección Fiscal:</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control" ID="txtDireccion_SubCliente" runat="server"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <div class="table-responsive1">
                        <asp:GridView ID="gvSubClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvSubClientes_RowCommand" OnPreRender="gvSubClientes_PreRender"
                            CssClass="table table-striped table-bordered dataTable" GridLines="None" EmptyDataText="No se encontraron resultados.">

                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <div class="btn-group dropdown">
                                            <button style="padding: 2px 5px;" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown" type="button">
                                                <span class="icon icon-gear icon-sx icon-fw">Opciones</span>
                                                <!--Opciones-->
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <%--<li>
                                                    <asp:LinkButton ToolTip="Editar" CommandArgument='<%# Eval("Cod_Empresa_Padre")+";"+Eval("Cod_Empresa")%>' CommandName="Editar" CssClass="icon-list-primary" runat="server"><i class="fa fa-edit"></i> Editar </asp:LinkButton>
                                                </li>--%>
                                                <li>
                                                    <asp:LinkButton ToolTip="Eliminar" CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Eliminar" CssClass="icon-list-primary" runat="server"><i class="fa fa-remove"></i> Eliminar </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ToolTip="Configurar notificación" CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Asignacion_Horas" CssClass="icon-list-primary" runat="server"><i class="fa fa-gear"></i> Configurar notificación </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ToolTip="Correos a Notificar" Visible='<%# Eval("Cod_Empresa").ToString() != "" %>' CommandArgument='<%# Eval("Cod_Empresa")%>' CommandName="Asignacion_Correos" CssClass="icon-list-primary" runat="server"><i class="fa fa-gear"></i> Configurar correos </asp:LinkButton>
                                                </li>

                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cod_Empresa_Padre" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpresa" runat="server" Text='<%# Eval("Cod_Empresa_Padre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cod_Empresa" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubEmpresa" runat="server" Text='<%# Eval("Cod_Empresa") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Raz_Soc" HeaderText="Razon Social"/>
                                <asp:BoundField DataField="RUC" HeaderText="RUC" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="false"/>
                                
                            </Columns>

                        </asp:GridView>
                         <%--Modal para aprobar eliminación--%>
                        <div id="infoModaEliminar_SubCliente" tabindex="-1" role="dialog" class="modal fade">
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
                                            <span class="text-success icon icon-check-circle icon-5x"></span>
                                            <h3 class="text-success">¿Está SEGURO de ELIMINAR este SubCliente?</h3>
                                            <div class="m-t-lg">
                                                <asp:LinkButton ID="btnEliminar_SubCliente" CssClass="btn btn-success" runat="server" OnClick="btnEliminar_SubCliente_Click"><i class="fa m-r-5"></i> <span>   Confirmar</span>  </asp:LinkButton>
                                                <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="modal-footer"></div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </asp:View>



    </asp:MultiView>

    <%--Modal para Asignar Horas para notificación de correo y administración de destinatarios--%>
    <div id="infoModalAsignarHoras" class="modal fade" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-lg-3">
                            Cliente:
                            <asp:Label ID="lblTittle" runat="server"></asp:Label>
                            
                        </div>
                        
                        <div class="col-lg-4">
                            <asp:DropDownList CssClass="form-control" ID="ddlMovimientoAsignacion" runat="server" 
                                OnSelectedIndexChanged="ddlMovimientoAsignacion_SelectedIndexChanged" AutoPostBack="true">
                                <asp:listitem text="Importación" value="I"></asp:listitem>
                                <asp:listitem text="Exportación" value="E"></asp:listitem>    
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-5 text-right">
                            <asp:LinkButton class="btn btn-primary btn-sm" ID="btnGuardarAsignacion" OnClick="btnGuardarAsignacion_Click" runat="server"><i class="glyphicon glyphicon-check"></i> Actualizar información</asp:LinkButton>
                            <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-close"></i>Cerrar</button>
                        </div>
                    </div>

                    <%-- <button type="button" class="close" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                                <span class="sr-only">Cerrar</span>
                                            </button>--%>
                </div>
                <div class="modal-body" style="padding-bottom: 0px;">
                    <div class="row">

                        <asp:HiddenField ID="hfAction" runat="server" />
                        <div class="col-md-4" style="padding-right: 20px;">
                            <div class="card-box" style="padding: 0px; border: none;">
                                <div class="card-header bg-light">
                                    <h4 class="card-title panel-title">Terminal de Retiro</h4>
                                </div>
                                <div class="card-body" style="padding-top: 15px;">

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:CheckBox runat="server" ID="chkRetiroLlegada" />
                                                <asp:Label runat="server">Llegada</asp:Label>
                                                <asp:Label ID="lblIDRetiroLlegada" Text="270100" Visible="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:CheckBox runat="server" ID="chkRetiroIngreso" />
                                                Ingreso 
                                                                    <asp:Label ID="lblIDRetiroIngreso" Text="270200" Visible="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:CheckBox runat="server" ID="chkRetiroSalida" />
                                                Salida 
                                                                    <asp:Label ID="lblIDRetiroSalida" Text="270300" Visible="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-12" style="display:none">
                                                <asp:CheckBox runat="server" ID="chkRetiroObservacion" />
                                                Observacion 
                                                                    <asp:Label ID="lblIdRetiroObservacion" Text="270400" Visible="false" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding: 0px;">
                            <div class="card-box" style="padding: 0px 20px; border-top: none; border-bottom: none; border-radius: 0px; margin-bottom: 0px; padding-bottom: 10px;">
                                <div class="card-header bg-light">
                                    <h4 class="card-title panel-title">Cliente</h4>
                                </div>
                                <div class="card-body" style="padding-top: 15px;">
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkLocalLlegada" />
                                            Llegada 
                                            <asp:Label ID="lblIDLocalLlegada" Text="270500" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkLocalIngreso" />
                                            Ingreso 
                                            <asp:Label ID="lblIDLocalIngreso" Text="270600" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkLocalInicio" />
                                            Inicio 
                                            <asp:Label ID="lblIDLocalInicio" Text="270700" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkLocalTermino" />
                                            Termino 
                                            <asp:Label ID="lblIDLocalTermino" Text="270800" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkLocalSalida" />
                                            Salida 
                                            <asp:Label ID="lblIDLocalSalida" Text="270900" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkLocalObservacion" />
                                            Observacion 
                                            <asp:Label ID="lblIDLocalObservacion" Text="271000" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4" style="padding-left: 20px;">
                            <div class="card-box" style="padding: 0px; border: none;">
                                <div class="card-header bg-light">
                                    <h4 class="card-title panel-title">Terminal de Devolución</h4>
                                </div>
                                <div class="card-body" style="padding-top: 15px;">
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkDevolucionLlegada" />
                                            Llegada 
                                                                <asp:Label ID="lblIDDevolucionLlegada" Text="271100" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkDevolucionIngreso" />
                                            Ingreso 
                                                                <asp:Label ID="lblIDDevolucionIngreso" Text="271200" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkDevolucionSalida" />
                                            Salida 
                                                                <asp:Label ID="lblIDDevolucionSalida" Text="271300" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group" style="display:none">
                                        <div class="row">
                                            <asp:CheckBox runat="server" ID="chkDevolucionObservacion" />
                                            Observacion 
                                                                <asp:Label ID="lblIDDevolucionObservacion" Text="271400" Visible="false" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row" title="Contactos a Notificar" style="padding-top: 20px; border-top: 2px solid #f3f3f3; display:none;">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalEmpresa" Checked="false" /><asp:Label runat="server">Empresa</asp:Label>
                                <asp:Label ID="lblIDAdicionalEmpresa" Text="271500" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalPctLinea" Checked="false" /><asp:Label runat="server">Precinto Linea</asp:Label>
                                <asp:Label ID="lblIDPctLinea" Text="271900" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalPctTransito" Checked="false" /><asp:Label runat="server">Precinto Tránsito</asp:Label>
                                <asp:Label ID="lblIDAdicionalPctTransito" Text="271800" Visible="false" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalUnidad" Checked="false" /><asp:Label runat="server">Unidad</asp:Label>
                                <asp:Label ID="lblIDAdicionalUnidad" Text="271600" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalPctAduana" Checked="false" /><asp:Label runat="server">Precinto Aduana</asp:Label>
                                <asp:Label ID="lblIDAdicionalPctAduana" Text="272000" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalPernocte" Checked="false" /><asp:Label runat="server">Pernocte</asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalChofer" Checked="false" /><asp:Label runat="server">Chofer</asp:Label>
                                <asp:Label ID="lblIDAdicionalChofer" Text="271700" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkAdicionalPctVacio" Checked="false" /><asp:Label runat="server">Precinto CTN Vacío</asp:Label>
                                <asp:Label ID="lblIDAdicionalPctVacio" Text="271800" Visible="false" runat="server"></asp:Label>
                            </div>
                        </div>

                    </div>
                    
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:CheckBox runat="server" ID="chkHeredarAsignacion" OnCheckedChanged="chkHeredarAsignacion_CheckedChanged" Checked="false"
                                Text="Heredar Asignaciones." AutoPostBack="true" />
                        </div>
                        <div class="col-sm-4">
                            <asp:CheckBox runat="server" ID="chkConsolidarAsignacion" Checked="false" Text="Consolidar Asignaciones." />
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>

    </div>
    <%--Modal para Asignar Horas para notificación de correo y administración de destinatarios--%>
    <div id="infoModalAsignarCorreos" class="modal fade" tabindex="-1" role="dialog" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="row">
                        <div class="col-lg-8">
                            Cliente:
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            
                        </div>
                        <div class="col-lg-4 text-right">
                            <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-close"></i>Cerrar</button>
                        </div>
                    </div>
 
                </div>
                <div class="modal-body" style="padding-bottom: 0px;">
                    <div class="row">
                        <div class="col-sm-12" style="padding: 0px 20px; border-top: none; border-bottom: none; border-radius: 0px; margin-bottom: 0px; padding-bottom: 10px;">
                            <div class="col-sm-6">
                                <asp:Label runat="server">Correo: </asp:Label>
                                <asp:TextBox CssClass="form-control" ID="txtMailCliente" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label runat="server">Movimiento: </asp:Label>
                                <asp:dropdownlist cssclass="form-control" id="ddlMovimientoCorreo" runat="server">
                                    <asp:listitem text="importación" value="I"></asp:listitem>
                                    <asp:listitem text="exportación" value="E"></asp:listitem>
                                    <asp:listitem text="ambos" value="A"></asp:listitem>
                                </asp:dropdownlist>
                            </div>
                            <div class="col-sm-2">
                                <asp:LinkButton CssClass="btn btn-primary btn-sm" ID="btnAgregarCorreo" OnClick="btnAgregarCorreo_Click" runat="server">
                                                        <i class="glyphicon glyphicon-plus"></i> Agregar
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="card-box" style="padding: 0px 20px; border-top: none; border-bottom: none; border-radius: 0px; margin-bottom: 0px; padding-bottom: 10px;">
                            <asp:GridView ID="gvDestinatarios" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDestinatarios_RowCommand"
                                OnPreRender="gvDestinatarios_PreRender" CssClass="table table-striped table-bordered dataTable" GridLines="None"
                                EmptyDataText="No se encontraron resultados." OnRowDataBound="gvDestinatarios_RowDataBound">

                                <Columns>
                                    <asp:TemplateField HeaderText="Opción" Visible="true" HeaderStyle-Width="20px">
                                        <ItemTemplate>
                                            <asp:LinkButton CssClass="btn btn-default btn-sm" ID="btnEliminarCorreo" CommandName="Eliminar" CommandArgument='<%#Eval("Empr_MC")+";"+Eval("Mail_MC")+";"+Eval("Movi_MC") %>' runat="server">
                                                <div class="media">
                                                    <div class="media-left">
                                                        <i class="fa fa-trash"></i>
                                                    </div>
                                                                        
                                                    <div class="media-body">
                                                        <span class="d-b">Eliminar</span> 
                                                    </div>
                                                </div>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Empr_MC" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpresa_MC" runat="server" Text='<%# Eval("Empr_MC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Movimiento" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMovimiento_MC" runat="server" Text='<%# Eval("Movi_MC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Mail_MC" HeaderText="Correo Destino" />
                                    <asp:BoundField DataField="Esta_MC" HeaderText="Estado" Visible="false" />

                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <%--Modal para aprobar eliminación--%>
    <div id="infoModaAprobar" tabindex="-1" role="dialog" class="modal fade">
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
                        <span class="text-success icon icon-check-circle icon-5x"></span>
                        <h3 class="text-success">¿Está SEGURO de ELIMINAR este cliente?</h3>
                        <p>Al eliminar el cliente, se eliminarán también los subclientes.</p>
                        <div class="m-t-lg">
                            <asp:HiddenField ID="HFIDEliminar" runat="server" />
                            <asp:LinkButton ID="btnConfirmación" CssClass="btn btn-success" runat="server" OnClick="btnEliminar_Click"><i class="fa m-r-5"></i> <span>   Confirmar</span>  </asp:LinkButton>
                            <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                        </div>
                    </div>

                </div>
                <div class="modal-footer"></div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(document).ready(function () {
            // Initialize ajax autocomplete:
            if ($('input.autocomplete2').length > 0) {
                $("input.autocomplete2").each(function (key, input) {
                    var url = $(this).data("url");

                    $(input).autocomplete({
                        serviceUrl: url,
                        paramName: 'term',
                        dataType: 'json',
                        //type: 'POST',
                        minChars: 2,
                        lookupLimit: 20,
                        transformResult: function (response) {
                            return {
                                suggestions: $.map(response, function (dataItem) {
                                    return { value: dataItem.descripcion, data: dataItem.id, ruc: dataItem.ruc };
                                })
                            };
                        },
                        lookupFilter: function (suggestion, originalQuery, queryLowerCase) {
                            var re = new RegExp('\\b' + $.Autocomplete.utils.escapeRegExChars(queryLowerCase), 'gi');
                            return re.test(suggestion.value);
                        },
                        onSelect: function (suggestion) {
                            console.log(suggestion);
                            $("input[id*='" + $(input).attr("id") + "_id']").val(suggestion.data);
                            $("input[id*='txtRUC_SubCliente']").val(suggestion.ruc);
                        }
                    });

                });
            }
        });
    </script>
</asp:Content >
