<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Locales.aspx.cs" Inherits="Modulos_TMS_Mantenimiento_Locales" %>

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
                <h4 class="page-title">Locales de Clientes</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <asp:HiddenField ID="hfAction" runat="server" />
            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="lblMensaje" runat="server"/>
                                <div class="col-lg-8">
                                    <h4 class="header-title">Busqueda de Local</h4>
                                </div>

                                <div class="col-lg-4" style="text-align: right;"> 

                                    <asp:LinkButton ID="btnFiltrar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrar_Click">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton>  
                                     <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" Visible="false">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar
                                    </asp:LinkButton>  
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
                             <div class="row form-group">
                                <div class="col-md-1 text-right">
                                    Cliente: 
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox placeholder="Ingresar nombre de cliente" CssClass="form-control autocomplete" data-url="BuscarEmpresa.ashx" ID="txtEmpresa" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtEmpresa_id" runat="server" class="form-control" Style="color: #CCC; position: absolute; background: transparent; z-index: 1; display: none;"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">                
                <div class="col-sm-12">
                    <div class="table-responsive">
                        <asp:GridView ID="gvLocales" runat="server" AutoGenerateColumns="False" OnRowCommand="gvLocales_RowCommand" OnPreRender="gvLocales_PreRender"
                            CssClass="table table-striped table-bordered example" GridLines="None" EmptyDataText="No se encontraron resultados" >

                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <div class="btn-group dropdown">
                                            <button style="padding: 2px 5px;" class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown" type="button">
                                                <span class="icon icon-gear icon-sx icon-fw">Opciones</span>
                                                <!--Opciones-->
                                                <span class="caret"> </span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li>
                                                    <asp:LinkButton ToolTip="Editar" CommandArgument='<%# Eval("ENT_CODI")+";"+Eval("LOCAL")%>' CommandName="Editar" CssClass="icon-list-primary" runat="server"><i class="fa fa-edit"></i> Editar </asp:LinkButton>
                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CLIENTE" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpresa" runat="server" Text='<%# Eval("CLIENTE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CLIENTE" HeaderText="CLIENTE" Visible="false" />
                                <asp:BoundField DataField="LOCAL" HeaderText="Local" Visible="true" />
                                <asp:BoundField DataField="PROVINCIA" HeaderText="Provincia" />
                                <asp:BoundField DataField="DISTRITO" HeaderText="Distrito" />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Direccion" />
                                <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                                <%--<asp:BoundField DataField="LOCAL_USUARIO_CREACION" HeaderText="Usuario Creacion" />--%>
                                <%--<asp:TemplateField HeaderText="Actions" Visible="true">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnEditar" CssClass="btn btn-icon waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Editar"><span class="fa fa-pencil-square-o"/></asp:LinkButton>
                                                    CommandArgument='<%# Eval("cod_flota") %>'
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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

                                <div class="col-lg-7">
                                    <h4 class="header-title">Registrar/Editar Local</h4>
                                </div>

                                <div class="col-lg-5" style="text-align: right;">

                                   <asp:HiddenField ID="HFCodigo" runat="server" Value="0" />
                                    
                                    <asp:LinkButton ID="btnActualizarLocal" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnConfirmarActualizar_Click">
                                        <i class="glyphicon glyphicon-floppy-saved"></i> Guardar
                                    </asp:LinkButton> 
                                    <asp:LinkButton ID="btnAgregarLocal" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnConfirmación_Click">
                                        <i class="glyphicon glyphicon-floppy-saved"></i> Guardar
                                    </asp:LinkButton> 
                                     <asp:LinkButton ID="btnRegresar" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnRegresar_Click" >
                                        <i class="glyphicon  glyphicon-repeat"></i> Cancelar
                                    </asp:LinkButton> 
                                       
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 

                <div class="row form-group">   
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Codigo:</label>
                        <asp:TextBox required CssClass="form-control" ID="txtCodigoCliente" runat="server"></asp:TextBox>
                    </div> 
                    <div class="col-md-8">
                        <label for="name-1" class="control-label">Cliente:</label>
                        <asp:TextBox CssClass="form-control" ID="txtCliente" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="row form-group">   
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Provincia</label>
                        <asp:DropDownList required ID="ddlProvincia" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Distrito</label>
                        <asp:DropDownList required ID="ddlDistrito" CssClass="form-control" style="text-transform:uppercase" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Dirección:</label>
                        <asp:TextBox required CssClass="form-control" ID="txtDireccion" style="text-transform:uppercase" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">   
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Geocerca:</label>
                        <asp:TextBox CssClass="form-control" ID="txtGeocerca" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Descripción Local:</label>
                        <asp:TextBox CssClass="form-control" ID="txtDescripcionLocal" runat="server"></asp:TextBox>
                    </div>
                    <%--<div id="div_CodClie" class="col-md-4">
                        <label for="name-1" class="control-label">Codigo Cliente:</label>
                        <asp:TextBox Enabled="false" CssClass="form-control" ID="txtCodigoClienteMant" runat="server"></asp:TextBox>
                    </div>--%>
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Atención:</label>
                        <asp:DropDownList ID="ddlAtencion" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row form-group">   
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Horario de Atención L/V:</label>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtHoraAtenciónInicio" runat="server" />
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" ID="txtHoraAtenciónFin" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Mail 1:</label>
                        <asp:TextBox CssClass="form-control" ID="txtMail1" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="name-1" class="control-label">Mail 2:</label>
                        <asp:TextBox CssClass="form-control" ID="txtMail2" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">   
                    <div class="col-md-12">
                        <label for="name-1" class="control-label">Observaciones:</label>
                        <asp:TextBox CssClass="form-control" ID="txtObservaciones" Rows="2" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">   
                    <div class="col-md-3    ">
                        <label for="name-1" class="control-label">Usuario Creación:</label>
                        <asp:TextBox CssClass="form-control" ID="txtUsuarioCreacion" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="name-1" class="control-label">Usuario Modificación:</label>
                        <asp:TextBox CssClass="form-control" ID="txtUsuarioModificacion" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="name-1" class="control-label">Fecha Creación:</label>
                        <asp:TextBox CssClass="form-control" ID="txtFechaCreacion" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label for="name-1" class="control-label">Fecha Modificación:</label>
                        <asp:TextBox CssClass="form-control" ID="txtFechaModificacion" runat="server"></asp:TextBox>
                    </div>
                </div>                
                <div class="row form-group">   
                    <div class="col-md-3">
                         <div class="checkbox checkbox-primary">
                        <asp:CheckBox ID="chkDeshabilitar" CssClass="col-md-6" text="Deshabilitar" runat="server" />
                     </div>
                     </div>
                    
                </div>

                         </div>
                    </div>
                </div>
            </div>

 
            <%-- MODAL CONFIRMAR AGREGAR --%>
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
                                <h3 class="text-success">¿Está SEGURO de AGREGAR este local?</h3>
                                <p>Debe estar seguro antes de ejecutar la siguiente accion</p>
                                <div class="m-t-lg">
                                    <asp:LinkButton ID="btnConfirmación" CssClass="btn btn-success" runat="server" OnClick="btnAgregarLocal_Click"><i class="fa m-r-5"></i> <span>   Confirmar</span>  </asp:LinkButton>
                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            
            <%-- MODAL CONFIRMAR ACTUALIZAR --%>
            <div id="infoModaActualizar" tabindex="-1" role="dialog" class="modal fade">
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
                                <h3 class="text-success">¿Está SEGURO de ACTUALIZAR este local?</h3>
                                <p>Debe estar seguro antes de ejecutar la siguiente accion</p>
                                <div class="m-t-lg">
                                    <asp:LinkButton ID="btnConfirmarActualizar" CssClass="btn btn-success" runat="server" OnClick="btnAgregarLocal_Click"><i class="fa m-r-5"></i> <span>   Confirmar</span>  </asp:LinkButton>
                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
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
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            /*$(".fancybox").fancybox({
                width: 800,
                height: 800,
                type: 'iframe'
            });*/
            $('.example').DataTable({
                "order": [[2, "asc"]]
            });
        });
        
    </script>
</asp:Content>