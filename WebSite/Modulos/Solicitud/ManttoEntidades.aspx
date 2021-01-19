<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="ManttoEntidades.aspx.cs" Inherits="Modulos_MantenimientoEntidades_Default" EnableEventValidation="False" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--Morris Chart CSS -->
    <%--<link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title"> Mantenimiento Entidades </h4>
                <div class="clearfix"></div>
                
            </div>
        </div>
    </div>
    <!-- end row -->
    <asp:HiddenField runat="server" ID="hfUsuario" />
    <asp:HiddenField runat="server" ID="hfClienteID" />
    <asp:HiddenField runat="server" ID="hfLocalID" />
    <asp:HiddenField runat="server" ID="hfContactoID" />
    <asp:HiddenField runat="server" ID="hfAccion" />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <%--Inicio Vista Registro--%>
        <asp:View ID="View1" runat="server">

            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="col-sm-6">
                           <h4 class="m-t-0 header-title"><b>Cliente</b></h4>
                            <p class="text-muted font-13 m-b-30">
                                Consulta el detalle de clientes. 
                            </p>
                        </div>
                        
                        <div class="panelOptions col-sm-6" style="text-align: right;">               
                            <asp:LinkButton ID="lnkAgregar" CssClass="btn btn-info waves-effect waves-light m-b-5" runat="server" OnClick="lnkAgregar_Click">
                                <i class="fa fa-plus m-r-5"></i> <span> Agregar Cliente</span>  </asp:LinkButton>
                        </div>
                        <div class="clearfix"></div>
                        
                        <%--<div class="col-md-4">                
                            <label for="userName">Buscar por Cliente </label>
                            <asp:DropDownList required CssClass="form-control" ID="ddlCliente" runat="server"> </asp:DropDownList>
                        </div>
                        
                        <div class="clearfix"></div>--%>

                    <%-- Grid View Cliente --%>
                    <asp:GridView ID="grvClientes" runat="server" AutoGenerateColumns="False" OnRowCommand="grvClientes_RowCommand"
                        CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvClientes_PreRender">

                        <Columns>
                            <asp:BoundField DataField="codigo_cliente" HeaderText="ID" Visible="false" />
                            <asp:BoundField DataField="cod_documento" HeaderText="Codigo Documento" Visible="false" />
                            <asp:BoundField DataField="tipo_documento" HeaderText="Tipo Documento" />
                            <asp:BoundField DataField="nro_documento" HeaderText="Nro Documento" />
                            <asp:BoundField DataField="razon_social" HeaderText="Razon Social" />
                            <asp:BoundField DataField="nombre_comercial" HeaderText="Nombre Comercial" />
                            <asp:BoundField DataField="direccion" HeaderText="Direccion"/>
                        
                            <asp:TemplateField HeaderStyle-Width="20px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                 <td>
                                                    <asp:LinkButton ToolTip="Visualizar Cliente" CommandName="visualizar"   CommandArgument='<%#Eval("codigo_cliente")+";"+Eval("tipo_documento")+";"+Eval("nro_documento")+";"+Eval("razon_social")+";"+Eval("nombre_comercial")+";"+Eval("direccion")%>'   CssClass="icon-list-primary" ID="lnkVisualizar" runat="server"><i class="fa fa-search m-l-5" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Editar Cliente" CommandName="editar" CommandArgument='<%#Eval("codigo_cliente")+";"+Eval("cod_documento")+";"+Eval("nro_documento")+";"+Eval("razon_social")+";"+Eval("nombre_comercial")+";"+Eval("direccion") %>' CssClass="icon-list-primary" ID="lnkEditar" runat="server"><i class="ti-pencil-alt m-l-5" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ToolTip="Eliminar Cliente" CommandName="eliminar" CommandArgument='<%# Eval("codigo_cliente") %>' CssClass="icon-list-primary" ID="lnkEliminar" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                        <asp:HiddenField runat="server" ID="cod_cliente"/>
            <div id="infoModalAlertCliente" tabindex="-1" role="dialog" class="modal fade">
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
                                    <h3 class="text-danger">¿Desea eliminar este Cliente?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="lnkEliminarCliente" CssClass="btn btn-danger" runat="server" OnClick="lnkEliminarCliente_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
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
                    <%-- Fin Grid View Cliente --%>
            <%--Inicio de Registro de Cliente--%>
            <div id="modalCliente" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro de Cliente</h4>

                        </div>
                        <div class="modal-body">
                            <div class="text">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">
                                    <label for="userName">Tipo de Documento :</label>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlDocumento" runat="server"> </asp:DropDownList>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Nro. Documento :</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese nro. documento" CssClass="form-control" ID="txtNroDocumento" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Razón Social :</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese razón social" CssClass="form-control" ID="txtRazon" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-12">
                                    <label for="userName">Nombre Comercial :</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese nombre comercial" CssClass="form-control" ID="txtNomComercial" runat="server"></asp:TextBox>
                                </div>

                                 <div class="form-group col-lg-12">
                                     <label for="userName">Dirección :</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese dirección" CssClass="form-control" ID="txtDireccion" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group  m-t-lg text-right">
                                    <asp:Button ID="lnkRegistrar" CssClass="btn btn-info m-t-5" runat="server" OnClick="lnkRegistrar_Click" Text="Guardar"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%--Fin de Registro de Cliente--%>
            <div class="clearfix"></div>    
        </asp:View>
        
        <%--Fin Vista Registro--%>
        
        <%--Inicio de Segunda Vista Listado de Cliente--%>

        <asp:View ID="View2" runat="server">
            <div class="row">
            <div class="col-md-12">
                <div class="card-box">

                    <div class="row">

                        <div class="col-md-12">
                            <div class="col-lg-12">

                                <div class="row">
                                    <div class="col-lg-8">
                                        <h4 class="header-title m-t-0">Información del Cliente</h4>
                                        <p class="text-muted font-13 m-b-10">
                                            Visualiza la información ingresada del cliente.
                                        </p>
                                    </div>

                                    <div class="panelOptions col-sm-12" style="text-align: right;">               
                            <asp:LinkButton ID="lnkRegresar" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="lnkRegresar_Click">
                               <span> Regresar</span>  </asp:LinkButton>
                        </div>

                                    <div class="clearfix"></div>
                                </div>
                                
                                <div class="form-group col-lg-2">
                                    <label> Tipo Documento :</label>
                                    <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label> Nro. Documento :</label>
                                    <asp:Label ID="lblNroDocumento" runat="server"></asp:Label>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label> Razón Social :</label>
                                    <asp:Label ID="lblRazonSoc" runat="server"></asp:Label>
                                </div>

                                <div class="form-group col-lg-10">
                                    <label> Nombre Comercial :</label>
                                    <asp:Label ID="lblNombreCom" runat="server"></asp:Label>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label> Dirección :</label>
                                    <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
                
                        <div class="panel-body">
                            <div class="col-md-12">
                                <ul class="nav nav-tabs">
                                    <li id="li1" runat="server" class="">
                                        <asp:LinkButton ID="lnkLocal" runat="server" OnClick="lnkLocal_Click"><span class="visible-xs"><i class="fa fa-user"></i></span><span class="hidden-xs">1. Local</span></asp:LinkButton></li>
                                    <li id="li2" runat="server" class="">
                                        <asp:LinkButton ID="lnkContacto" runat="server" OnClick="lnkContacto_Click"><span class="visible-xs"><i class="fa fa-users"></i></span><span class="hidden-xs">2. Contacto</span></asp:LinkButton></li>
                                </ul>
                                <asp:Panel runat="server" ID="PanelLocal">
                                <div class="col-sm-8 m-t-20 m-b-20">
                                        <h4 class="header-title"><b>Información de Locales</b></h4>
                                </div>

                                <div class="panelOptions col-sm-4 m-t-20 m-b-20" style="text-align: right;">
                                <asp:LinkButton ID="btnAgregarLocal" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="btnAgregarLocal_Click">
                                    <i class="fa fa-plus m-r-5"></i> <span> Agregar Local</span>  </asp:LinkButton>
                                </div>

                                <asp:GridView ID="grvLocal" runat="server" AutoGenerateColumns="False" OnPreRender="grvLocal_PreRender" OnRowCommand="grvLocal_RowCommand"
                                                CssClass="table table-striped table-bordered dataTable" GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="cod_cliente" HeaderText="ID" Visible="false" />
                                                    <asp:BoundField DataField="codigo_local" HeaderText="id_local" Visible="false" />
                                                    <asp:BoundField DataField="direccion" HeaderText="DIRECCION" />
                                                    <asp:BoundField DataField="codigo_ubigeo" HeaderText="ID_ubigeo" Visible="false" />
                                                    <asp:BoundField DataField="nombre_departamento" HeaderText="DEPARTAMENTO"/>
                                                    <asp:BoundField DataField="nombre_provincia" HeaderText="PROVINCIA"/>
                                                    <asp:BoundField DataField="ubigeo" HeaderText="DISTRITO" />
                        
                                                    <asp:TemplateField HeaderStyle-Width="20px">
                                                            <ItemTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:LinkButton ToolTip="Editar Local"  CommandName="editar" CommandArgument='<%# Eval("codigo_local") + ";" + Eval("direccion")+";"+Eval("codigo_ubigeo") %>' CssClass="icon-list-primary" ID="lnkEditaLocal" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                        </td>
                                                                        <td>
                                                                            <asp:LinkButton ToolTip="Eliminar Local"  CommandName="eliminar" CommandArgument='<%# Eval("codigo_local") %>' CssClass="icon-list-primary" ID="lnkEliminarLocal" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="20px" />
                                                        </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                    <asp:HiddenField runat="server" ID="cod_local"/>
            <div id="infoModalAlertLocal" tabindex="-1" role="dialog" class="modal fade">
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
                                    <h3 class="text-danger">¿Desea eliminar este Local?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminarLocal" CssClass="btn btn-danger" runat="server" OnClick="lnkEliminarLocal_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>


                                      <%--Inicio de Registro de Local--%>
            <div id="modalLocal" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro de Local</h4>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-12">
                                    <label for="userName">Dirección</label>
                                        <asp:TextBox required spellcheck="false" placeholder="Ingrese dirección" CssClass="form-control" ID="txtDireccionLocal" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-4">
                                        <label for="userName">Departamento</label>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Provincia</label>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlProvincia" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Distrito</label>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlDistrito" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="m-t-lg text-right">
                                        <asp:LinkButton ID="lnkRegistrarLocal" runat="server" CssClass="btn btn-info m-t-5" Text="Procesar" OnClick="lnkRegistrarLocal_Click"> </asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%--Fin de Registro de Local--%>


                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="PanelContacto" Visible="false">

                                         <div class="col-sm-8 m-t-20 m-b-20">
                                             <h4 class="header-title"><b>Información de Contacto</b></h4>
                                        </div>

                                        <div class="panelOptions col-sm-4 m-t-20 m-b-20" style="text-align: right;">
                                            <asp:LinkButton ID="btnAgregarContacto" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="btnAgregarContacto_Click">
                                                <i class="fa fa-plus m-r-5"></i> <span> Agregar Contacto</span>  </asp:LinkButton>
                                        </div>

                                        <asp:GridView ID="grvContacto" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="grvContacto_RowCommand" OnPreRender="grvContacto_PreRender">

                                            <Columns>
                                                <asp:BoundField DataField="contacto_id" HeaderText="ID" Visible="false"/>
                                                <asp:BoundField DataField="codigo_cliente" HeaderText="codigo_cliente" Visible="false" />
                                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="apellido_pat" HeaderText="Apellido Paterno" />
                                                <asp:BoundField DataField="apellido_mat" HeaderText="Apellido Materno" />
                                                <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                                                <asp:BoundField DataField="correo" HeaderText="Correo" />
                                                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                                                <asp:BoundField DataField="anexo" HeaderText="Anexo" />
                                                <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" />
                                                <asp:BoundField DataField="observacion" HeaderText="Observación" />
                                                <asp:BoundField DataField="estado" HeaderText="Estado" Visible="false"/>
                                                <asp:BoundField DataField="uCreacion" HeaderText="U-Creación" Visible="false"/>
                                                <asp:BoundField DataField="uModificacion" HeaderText="U-Modificación" Visible="false"/>
                                                <asp:BoundField DataField="fecha_creacion" HeaderText="F-Creación" Visible="false"/>
                                                <asp:BoundField DataField="fecha_modificacion" HeaderText="F-Modificación" Visible="false"/>    
                                                <asp:TemplateField HeaderStyle-Width="20px">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ToolTip="Editar Contacto" CommandName="editar" CommandArgument='<%#Eval("contacto_id")+";"+Eval("codigo_cliente")+";"+Eval("nombre")+";"+Eval("apellido_pat")+";"+Eval("apellido_mat")+";"+Eval("cargo")+";"+Eval("correo")+";"+Eval("telefono")+";"+Eval("anexo")+";"+Eval("fecha_nacimiento")+";"+Eval("observacion") %>' CssClass="icon-list-primary" ID="lnkEditarContacto" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                </td>
                                                                <td>
                                                                    <asp:LinkButton ToolTip="Eliminar Contacto" CommandName="eliminar" CommandArgument='<%#Eval("contacto_id") %>' CssClass="icon-list-primary" ID="lnkEliminarContacto" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                <HeaderStyle Width="20px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:HiddenField runat="server" ID="cod_id" />
            <div id="infoModalAlert5" tabindex="-1" role="dialog" class="modal fade">
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
                                    <h3 class="text-danger">¿Desea eliminar este Contacto?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>



                                    </asp:Panel>
                         <div class="tab-content">
                              <div class="tab-pane">

                                  
                                   
                                    </div>
                                </div>

                            </div>
                            <!-- end col -->

                        </div>
            
            
          
            
            <%--Inicio de Registro de Contacto--%>
            <div id="modalContacto" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>

                            <h4 class="modal-title">Registro de Contacto</h4>

                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>

                                <div class="form-group col-lg-12">

                                    <div class="form-group col-lg-12">
                                        <label for="userName">Nombre :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese nombre" CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                                        </div>
                                </div>
                                
                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Apellido Paterno :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese apellido paterno" CssClass="form-control" ID="txtApePaterno" runat="server"></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Apellido Materno :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese apellido materno" CssClass="form-control" ID="txtApeMaterno" runat="server"></asp:TextBox>
                                        </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Fecha Nacimiento :</label>
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <span class="fa fa-calendar"></span></span>
                                            <asp:TextBox required data-provide="datepicker" CssClass="form-control datepickers" ID="txtFchNacimiento" runat="server" ValidateRequestMode="Inherit"></asp:TextBox>
                                        </div>
                                    </div>
                                   

                                    <div class="form-group col-lg-6">
                                        <label for="userName">Cargo :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese cargo" CssClass="form-control" ID="txtCargo" runat="server"></asp:TextBox>
                                        </div>                                  
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-12">
                                        <label for="userName">Correo :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese correo" CssClass="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator 
                                            id="txtCorreo_validation" runat="SERVER" 
                                            ControlToValidate="txtCorreo" 
                                            ErrorMessage="El formato para ingresar correo es:  abcd@xyz.com "
                                            ValidationExpression="^[a-zA-Z0-9_\-\.~]{2,}@[a-zA-Z0-9_\-\.~]{2,}\.[a-zA-Z]{2,4}$">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-6">
                                        <label for="userName" class="control-label">Teléfono :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese teléfono" CssClass="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                                        </div>

                                    <div class="form-group col-lg-6">
                                        <label for="userName" class="control-label">Anexo :</label>
                                            <asp:TextBox required spellcheck="false" placeholder="Ingrese anexo" CssClass="form-control" ID="txtAnexo" runat="server"></asp:TextBox>
                                        </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-12">
                                        <label for="userName" class="control-label">Observación :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtObservacion" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                        </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="m-t-lg text-right">
                                        <asp:Button ID="lnkRegistrarContacto" runat="server" CssClass="btn btn-info m-t-5" Text="Procesar" OnClick="lnkRegistrarContacto_Click"> </asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%--Fin de Registro de Contacto--%>
        </asp:View>

        <%--Fin de Segunda Vista Listado de Cliente--%>
    </asp:MultiView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
  <%--  <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>--%>
</asp:Content>
