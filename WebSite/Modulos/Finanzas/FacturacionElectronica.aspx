<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="FacturacionElectronica.aspx.cs" Inherits="Modulos_Finanzas_FE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Facturación Electronica </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li><a href="#">Finanzas </a></li>
                    <li class="active">Facturación Electronica</li>
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
                    <div class="card-box table-responsive" >
                        <div class="clearfix"></div>
                                <asp:Label  ID="lblMensaje" runat="server" CssClass="text1" Font-Bold="True" ForeColor="#CC3300" Visible="false"></asp:Label>
                                <div class="row">
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="userName">Tipo Documento </label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlTipoDocumento" runat="server">
                                                <asp:ListItem Value="00" Text="MOSTRAR TODOS"></asp:ListItem>
                                                <asp:ListItem Value="01" Text="FACTURA"></asp:ListItem>
                                                <asp:ListItem Value="03" Text="BOLETA"></asp:ListItem>
                                                <asp:ListItem Value="07" Text="NOTA DE CRÉDITO"></asp:ListItem>
                                                <asp:ListItem Value="08" Text="NOTA DE DÉBITO"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                      </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="userName">Fch. Emsión (desde) </label>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <span class="fa fa-calendar"></span></span>
                                                <asp:textbox required spellcheck="false" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="fchEmision_Desde" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                      </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="userName">Fch. Emsión (hasta)</label>
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <span class="fa fa-calendar"></span></span>
                                                <asp:textbox required spellcheck="false" placeholder="dd/mm/yyyy" data-provide="datepicker" cssclass="form-control datepickers" id="fchEmision_Hasta" runat="server"></asp:textbox>
                                            </div>
                                        </div>
                                      </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="userName">Estado </label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server">
                                                <asp:ListItem Value="00" Text="MOSTRAR TODOS"></asp:ListItem>
                                                <asp:ListItem Value="PENDIENTE" Text="PENDIENTE"></asp:ListItem>
                                                <asp:ListItem Value="ENVIADO" Text="ENVIADO"></asp:ListItem>
                                                <asp:ListItem Value="ACEPTADO" Text="ACEPTADO"></asp:ListItem>
                                                <asp:ListItem Value="ERROR" Text="ERROR"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                      </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label for="userName">Estado SUNAT </label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlEstadoSUNAT" runat="server">
                                                <asp:ListItem Value="00" Text="MOSTRAR TODOS"></asp:ListItem>
                                                <asp:ListItem Value="01" Text="ACEPTADO"></asp:ListItem>
                                                <asp:ListItem Value="03" Text="ACEPTADO CON OBSERVACIONES"></asp:ListItem>
                                                <asp:ListItem Value="05" Text="EXECPCIÓN"></asp:ListItem>
                                                <asp:ListItem Value="04" Text="RECHAZADO"></asp:ListItem>
                                                <asp:ListItem Value="07" Text="INCIDENCIA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                      </div>
                                    <div class="cols-sm-2">
                                        <label for="userName" style="display:block;">&nbsp; </label>
                                         <asp:LinkButton ID="btnBuscar" CssClass="btn btn-instagram btn-sm"  runat="server" OnClick="btnBuscar_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                <i class="fa fa-search m-r-5"></i> <span> Buscar</span>  </asp:LinkButton>
                                    </div>
                                     

                                    </div>
                                 <div class="row">
                                     <div class="col-sm-6 text-right" >
                                            <div class="form-group">
                                                <asp:HiddenField ID="HFMarcarFilas" Value="1" runat="server" />
                                                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-instagram btn-sm" runat="server" OnClick="LinkButton2_Click">
                                <i class="fa fa-check m-r-5"></i> <span> Marcar Todos</span>  </asp:LinkButton>
                                            </div>
                                        </div>
                                     <div class="col-sm-6 text-left"> 
                                          <div class="form-group">
                                         <asp:LinkButton ID="LinkButton1" CssClass="btn btn-instagram btn-sm"  runat="server" OnClick="LinkButton1_Click">
                                <i class="fa fa-download m-r-5"></i> <span> Descargar PDF</span>  </asp:LinkButton>
                                    </div>
                                         </div>
                                    <div class="panelOptions col-sm-12 m-t-15" style="text-align: right; display:none;">                                        
                                        <asp:LinkButton ID="btnAgregar" CssClass="btn btn-info" runat="server" OnClick="btnAgregar_Click" ><i class="fa fa-plus m-r-5"></i> <span>  Agregar</span>  </asp:LinkButton>                         
                                    </div>
                                </div>

                        <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False"
                       CssClass="table table-striped table-bordered grillascrollYa" GridLines="None" OnRowCommand="gvUsuario_RowCommand" OnPreRender="gvUsuario_PreRender" >
                                <Columns>
                                     <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <div class="checkbox checkbox-default">
                                                <asp:CheckBox ID="chkSeleccionar" runat="server" Text=" " Visible='<%# (Eval("Download_Status").ToString() == "DESCARGADO" && Eval("Estado").ToString() == "ACEPTADO" ? true : false) %>' />
                                                  <asp:Label Visible="false" ID="lblIDProceso" runat="server" Text='<%# Eval("IDProceso") %>'></asp:Label>
                                                <asp:Label Visible="false" ID="lblDirectory" runat="server" Text='<%# Eval("Download_Archivo") %>'></asp:Label>
                                            </div>                                    
                                        </ItemTemplate>
                                        <HeaderStyle Width="1px" CssClass="text-center" />
                                        <ItemStyle CssClass="text-center" />
                                    </asp:TemplateField>  
                                    <asp:BoundField DataField="IDProceso" HeaderText="ID" HeaderStyle-Width="30px" Visible="false" />
                                    <asp:BoundField DataField="Directory" HeaderText="Carpeta" Visible="false" />
                                    <asp:BoundField DataField="DocumentType" HeaderText="Tipo Documento" />                                    
                                    <asp:BoundField DataField="NumPref"  HeaderText="Nro. Documento" Visible="true" />
                                    <asp:BoundField DataField="DocDate" HeaderText="Fch. Emisión" HeaderStyle-Width="70px" DataFormatString="{0:d}" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="NumFolio" HeaderText="Doc. Correlativo" Visible="false" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true"  />
                                    <asp:BoundField DataField="Proceso_StatusLegal" HeaderText="Estado SUNAT" />
                                    <asp:BoundField DataField="FchRegistro" HeaderText="Fch. Proceso" HeaderStyle-Width="70px" DataFormatString="{0:d}" ItemStyle-CssClass="text-center"/>
                               
                                    <asp:TemplateField HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <div class="btn-group dropdown">
                                            <button style="padding: 2px 5px;" class="btn btn-instagram btn-sm dropdown-toggle" data-toggle="dropdown" type="button">
                                                <span class="icon icon-gear icon-sx icon-fw"></span>
                                                Opciones
                                                <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu dropdown-menu-right">
                                                <li>
                                                    <asp:LinkButton ID="btnDetalle" CommandName="ReProcesar" CommandArgument='<%#Eval("IDProceso")+";"+Eval("DocEntry")+";"+Eval("Download_Archivo")%>' runat="server" Visible='<%# (Eval("Estado").ToString() != "ACEPTADO" ? true : false) %>'>
                                                        <div class="media">
                                                            <div class="media-left">
                                                                <span class="fa fa-download"></span>
                                                            </div>
                                                            <div class="media-body">
                                                                <span class="d-b">Re-Procesar</span> 
                                                            </div>
                                                        </div>
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="btnDocumentos" CommandName="PDF" CommandArgument='<%#Eval("IDProceso")+";"+Eval("DocEntry")+";"+Eval("Download_Archivo")%>' runat="server" Visible='<%# (Eval("Download_Status").ToString() == "DESCARGADO" && Eval("Estado").ToString() == "ACEPTADO" ? true : false) %>'>
                                                        <div class="media">
                                                            <div class="media-left">
                                                                <span class="fa fa-file"></span>
                                                            </div>
                                                            <div class="media-body">
                                                                <span class="d-b">Descargar PDF</span> 
                                                            </div>
                                                        </div>
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="LinkButton4" CommandName="CDP" CommandArgument='<%#Eval("IDProceso")+";"+Eval("DocEntry")%>' runat="server" Visible='<%# (Eval("Download_Status").ToString() == "DESCARGADO" && Eval("Estado").ToString() == "ACEPTADO" ? true : false) %>'>
                                                        <div class="media">
                                                            <div class="media-left">
                                                                <span class="fa fa-download"></span>
                                                            </div>
                                                            <div class="media-body">
                                                                <span class="d-b">Descargar CDP</span> 
                                                            </div>
                                                        </div>
                                                    </asp:LinkButton>
                                                </li>
                                                <li style="display:none;">
                                                    <asp:LinkButton ID="LinkButton5" CommandName="Unidad" CommandArgument='<%#Eval("IDProceso")+";"+Eval("DocEntry")%>' runat="server" Visible='<%# (Eval("Download_Status").ToString() == "DESCARGADO" ? true : false) %>'>
                                                        <div class="media">
                                                            <div class="media-left">
                                                                <span class="fa fa-download"></span>
                                                            </div>
                                                            <div class="media-body">
                                                                <span class="d-b">Descargar RAR</span> 
                                                            </div>
                                                        </div>
                                                    </asp:LinkButton>
                                                </li>
                                                
 
                                            </ul>
                                        </div>
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

