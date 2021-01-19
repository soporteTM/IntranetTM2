<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Finanzas_Default" %>

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

    <asp:HiddenField runat="server" ID="hfID" />
    <asp:HiddenField runat="server" ID="hfIDEmpleado" />
    <asp:HiddenField runat="server" ID="hfAction" />
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box table-responsive">
                        <div class="clearfix"></div>
                            <asp:Label  ID="lblMensaje" runat="server" CssClass="text1" Font-Bold="True" ForeColor="#CC3300" Visible="false"></asp:Label>
                                <div class="row">
                                    
                                    <div class="panelOptions col-sm-12 m-t-15" style="text-align: right;">                                        
                                        <asp:LinkButton ID="btnAgregar" CssClass="btn btn-info" runat="server" OnClick="btnAgregar_Click" ><i class="fa fa-plus m-r-5"></i> <span>  Agregar</span>  </asp:LinkButton>                         
                                    </div>
                                </div>
                       </div>
                        <%-- Grid View Nombrada --%>
                       <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False"
                       CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="gvUsuario_RowCommand" OnPreRender="gvUsuario_PreRender" >
                                <Columns>
                                    <asp:BoundField DataField="id_usuario" HeaderText="ID" Visible="false"  />
                                    <asp:BoundField DataField="FE_emisor" HeaderText="Emisor"/>
                                    <asp:BoundField DataField="FE_receptor" HeaderText="Receptor" />
                                    <%--<asp:BoundField DataField="pass_user" HeaderText="Contraseña" />--%>
                                    <asp:BoundField DataField="FE_tipoFacturación"  HeaderText="Tipo de Facturación" Visible="true" />
                                    <asp:BoundField DataField="FE_tipo" HeaderText="Tipo" Visible="true"  />
                                    <asp:BoundField DataField="FE_serie" HeaderText="Serie" Visible="true"  />
                                    <asp:BoundField DataField="FE_correlativo" HeaderText="Correlativo" />
                                    <asp:BoundField DataField="FE_valor" HeaderText="Valor" />
                                    <asp:BoundField DataField="FE_fechaEmision" HeaderText="Fecha Emisión" />
                                    <asp:BoundField DataField="FE_estadoProcesamiento" HeaderText="Estado Procesamiento" />
                                    <asp:BoundField DataField="FE_estadoOSE" HeaderText="Estado OSE-SUNAT" />
                                    <asp:TemplateField ItemStyle-Width="20px" >
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td style="padding: 0 2px;">
                                                        <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id_usuario")+";"+Eval("id_empleado")%>' CssClass="btn btn-info waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Modificar"><span class="fa fa-pencil-square-o" /></asp:LinkButton>
                                                    </td>
                                                    <td style="padding: 0 2px;">
                                                        <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_usuario")%>' CssClass="btn btn-danger waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="eliminar"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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
                                

                                <div class="form-group col-lg-12">
                                    <label for="userName">Nombre de Usuario </label>
                                    <asp:TextBox runat="server" ID="txtNomUsuario" CssClass="form-control"></asp:TextBox>                             
                                </div>

                                <div class="form-group col-lg-12">
                                    <label for="userName">Nombre de Inicio</label>
                                    <asp:TextBox runat="server" ID="txtNomUser" CssClass="form-control"></asp:TextBox>                             
                                </div>

                                <div class="form-group col-lg-12">
                                    <label for="userName">Perfil </label>
                                    <asp:DropDownList  CssClass="form-control" ID="ddlPerfil" runat="server">
                                    </asp:DropDownList>                                
                                </div>

                                <%-- Auto Completado administrativo --%>
                                <div class="form-group col-lg-12">
                                    <label for="userName">Empleado </label>
                                    <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarAdministrativo.ashx" ID="txtEmpleado" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtEmpleado_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                </div>

                                <div class="col-sm-3">
                                    <asp:LinkButton ID="btnGuardar" CssClass="btn btn-instagram m-t-5" runat="server" OnClick="btnGuardar_Click"><i class="glyphicon glyphicon-floppy-saved m-r-5"></i> <span>   Guardar</span>  </asp:LinkButton>
                                    
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
                                    <h3 class="text-danger">¿Desea eliminar este Usuario?</h3>
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

            <div id="infoModalAlert4" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Modificacion de Usuario</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row m-b-20">
                                <div class="col-lg-8">
                                    <label for="userName">Jefatura </label>
                                    <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarAdministrativo.ashx" ID="txtJefe" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtJefe_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                </div>
                                <div class="col-lg-1"></div>
                                <div class="col-lg-2 m-t-15">
                                    <asp:LinkButton ID="lnkModificar" CssClass="btn btn-instagram m-t-5" runat="server" OnClick="lnkModificar_Click"><i class="fa fa-redo-alt m-r-5"></i> <span>Modificar</span>  </asp:LinkButton> 
                                </div>
                                <div class="col-lg-1"></div>
                            </div>
                            <div class="row m-t-20 modal-footer">

                                <div class="col-lg-4"></div>
                                <div class="col-lg-4">
                                    <asp:LinkButton ID="btnReestablecer" CssClass="btn btn-instagram m-t-5" runat="server" OnClick="btnReestablecer_Click"><i class="fa fa-redo-alt m-r-5"></i> <span>Reestablecer Contraseña</span>  </asp:LinkButton> 
                                </div>
                                <div class="col-lg-4"></div>
                                    
                                
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>
</asp:Content>

