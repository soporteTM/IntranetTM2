<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_SIG_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo SIG</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="col-sm-6">                             
       <p  id="alerta" class="text-muted font-13 m-b-30">
          <asp:Label  ID="lblMensaje" runat="server" CssClass="text1" Font-Bold="True" ForeColor="#CC3300" Visible="false"></asp:Label>
       </p>
    </div>
    <div class="col-sm-8 m-t-15">
        <asp:label id="lblTitulo" class="page-title" runat="server"></asp:label>
    </div>
    <!-- end row -->
    
    
    <div class="row">
        
        <div class="col-md-12">
          
            
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="col-lg-8">
                    <h1>Empresas</h1>
                    </div>
                    <div class="panelOptions col-sm-4 m-t-15" style="text-align: right;">
        
                     
                     <asp:LinkButton ID="btnAgregar" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="btnAgregar_Click">
                        <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  
                     </asp:LinkButton>
                    </div>


                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">
                                <div class="panelOptions col-sm-6" style="text-align: right;"></div>
                                <div class="clearfix"></div>

                                
                                <asp:GridView ID="grvEmpresa" runat="server" AutoGenerateColumns="False" OnRowCommand="grvEmpresa_RowCommand"
                                CssClass="table table-striped table-bordered dataTable" GridLines="None" OnPreRender="grvEmpresa_PreRender">
                                   
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="Emp_Rsoc" HeaderText="Razon Social"/>
                                        <asp:BoundField DataField="RUC" HeaderText="RUC"/>
                                        <asp:BoundField DataField="Contacto" HeaderText="Contacto"/>
                                        <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnDetalle" CommandArgument='<%#Eval("id")+";"+Eval("Emp_Rsoc")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id")+";"+Eval("Emp_Rsoc")+";"+Eval("RUC")+";"+Eval("Contacto")+";"+Eval("telefono")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Actualizar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

            <%-- INICIO DE REGISTRO EMPRESA --%>
           <div id="infoModalAlert2" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Empresa</h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox  spellcheck="false" placeholder="Razon Social" CssClass="form-control col-12" ID="txtId" runat="server" Visible="false"></asp:TextBox>
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                 <div class="form-group col-lg-12">
                                    <label for="userName">Empresa </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Razon Social" CssClass="form-control col-12" ID="txtRsoc" runat="server"></asp:TextBox>
                                 </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName">RUC </label>
                                    <asp:TextBox  required  spellcheck="false" MaxLength="11" placeholder="RUC" CssClass="form-control col-12" ID="txtRuc" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    ControlToValidate="txtRuc" ErrorMessage="*Ingrese Valores Numericos"
                                    ForeColor="Red"
                                    ValidationExpression="^[0-9]*">
                                </asp:RegularExpressionValidator>
                                 </div>
                                
                                <div class="form-group col-lg-6">
                                    <label for="userName">Telefono </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Telefono" CssClass="form-control col-12" ID="txtTelefono" runat="server"></asp:TextBox>
                                 </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ControlToValidate="txtTelefono" ErrorMessage="*Ingrese Valores Numericos"
                                    ForeColor="Red"
                                    ValidationExpression="^[0-9]*">
                                </asp:RegularExpressionValidator>
                                <div class="form-group col-lg-12">
                                    <label for="userName">Contacto </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Contacto" CssClass="form-control col-12" ID="txtContacto" runat="server"></asp:TextBox>
                                 </div>
                                
                                <div class="form-group col-lg-12 text-right">
                                    <asp:Button ID="btnGuardar" CssClass="btn btn-instagram m-t-5 " runat="server" Text="Guardar" OnClick="btnAgregarEmpresa_Click" ></asp:Button>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE REGISTRO EMPRESA --%>
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
                                    <h3 class="text-danger">¿Desea eliminar esta Nave?</h3>
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
            <%-- FIN DE ELIMINADO DE FILA --%>

            </asp:View>
            <asp:View ID="View2" runat="server">
                
                    <div class="form-group col-lg-2">
                        <asp:label runat="server" ID="idemp" Visible="false"></asp:label>
                        <asp:DropDownList  CssClass="form-control" ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                    <div class="col-lg-6">
                        <asp:label runat="server" CssClass="page-title" id="lblEmpresa" ></asp:label>
                    </div>
                
                    <div class="panelOptions col-sm-4 m-t-15" style="text-align: right;">
        
                     <asp:LinkButton ID="btnRegresar" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="btnRegresar_Click" >
                        <span>Regresar</span>
                     </asp:LinkButton>
                     <asp:LinkButton ID="btnRegistrar" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="btnRegistrar_Click">
                        <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  
                     </asp:LinkButton>
                    </div>
                

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">
                                <div class="panelOptions col-sm-6" style="text-align: right;"></div>
                                <div class="clearfix"></div>

                                
                                <asp:GridView ID="grvConductor" runat="server" AutoGenerateColumns="False" OnRowCommand="grvConductor_RowCommand" OnPreRender="grvConductor_PreRender"
                                CssClass="table table-striped table-bordered dataTable" GridLines="None" >
                                   
                                    <Columns>
                                        <asp:BoundField DataField="id_conductor" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="nombre" HeaderText="Nombre Completo"/>
                                        <asp:BoundField DataField="dni" HeaderText="DNI"/>
                                        <asp:BoundField DataField="licencia" HeaderText="Brevete"/>
                                        <asp:BoundField DataField="cat_licencia" HeaderText="Categoria de Brevete"/>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="LinkButton4" CommandArgument='<%#Eval("id_conductor")+";"+Eval("nombre")+";"+Eval("dni")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id_conductor")+";"+Eval("nombre")+";"+Eval("dni")+";"+Eval("licencia")+";"+Eval("cat_licencia")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Actualizar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_conductor")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <asp:GridView ID="grvUnidad" runat="server" AutoGenerateColumns="False" OnRowCommand="grvUnidad_RowCommand" OnPreRender="grvUnidad_PreRender"
                                CssClass="table table-striped table-bordered dataTable" GridLines="None" >
                                   
                                    <Columns>
                                        <asp:BoundField DataField="id_unidad" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="placa" HeaderText="Placa"/>
                                        <asp:BoundField DataField="clasificacion" HeaderText="Clasificacion"/>
                                        <asp:BoundField DataField="configuracion" HeaderText="Configuracion"/>
                                        <asp:BoundField DataField="año_fabricacion" HeaderText="Año de Fabricacion"/>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr >   
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnDetalle" CommandArgument='<%#Eval("id_unidad")+";"+Eval("placa")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id_unidad")+";"+Eval("placa")+";"+Eval("clasificacion")+";"+Eval("configuracion")+";"+Eval("año_fabricacion")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Actualizar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_unidad")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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
                <%------------------------------------------------------ INICIO REGISTRO/ACTUALIZAR CONDUCTOR -------------------------------------------------------------%>
                <div id="infoModalAlert4" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Conductor</h4>
                        </div>
                        <div class="modal-body">
                            
                            <div class="row">
                                <asp:textbox runat="server" ID="txtAccionConductor" Visible="false"></asp:textbox>
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                 <div class="form-group col-lg-12">
                                    <label for="userName">Nombre </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Nombre Completo" CssClass="form-control col-12" ID="txtNombre" runat="server"></asp:TextBox>
                                 </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName">DNI </label>
                                    <asp:TextBox  required  spellcheck="false" MaxLength="11" placeholder="DNI" CssClass="form-control col-12" ID="txtDni" runat="server"></asp:TextBox>
                                 </div>
                                
                                <div class="form-group col-lg-6">
                                    <label for="userName">Licencia </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Licencia" CssClass="form-control col-12" ID="txtLicencia" runat="server"></asp:TextBox>
                                 </div>
                                <div class="form-group col-lg-12">
                                    <label for="userName">Categoria de Licencia </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Categoria de Licencia" CssClass="form-control col-12" ID="txtCatLic" runat="server"></asp:TextBox>
                                 </div>
                                
                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="btnGrabarConductor" CssClass="btn btn-instagram m-t-5 " runat="server" Text="Guardar" OnClick="btnGrabarConductor_Click" ></asp:LinkButton>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
               </div>
                <%------------------------------------------------------ FIN REGISTRO CONDUCTOR -------------------------------------------------------------%>
                <%------------------------------------------------------ INICIO REGISTRO UNIDAD -------------------------------------------------------------%>
                <div id="infoModalAlert5" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Unidad</h4>
                        </div>
                        <div class="modal-body">
                            
                            <div class="row">
                                <asp:textbox runat="server" ID="txtAccionUnidad" Visible="false"></asp:textbox>
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                 <div class="form-group col-lg-6">
                                    <label for="userName">Placa </label>
                                    <asp:TextBox required spellcheck="false" placeholder="Placa" CssClass="form-control col-12" ID="txtPlaca" runat="server"></asp:TextBox>
                                 </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Clasificacion </label>
                                    <asp:TextBox  spellcheck="false" placeholder="Clasificacion" CssClass="form-control col-12" ID="txtClasificacion" runat="server"></asp:TextBox>
                                 </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Configuracion </label>
                                    <asp:TextBox  spellcheck="false" placeholder="Configuracion" CssClass="form-control col-12" ID="txtConfiguracion" runat="server"></asp:TextBox>
                                 </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Año de Fabricacion </label>
                                    <asp:TextBox  spellcheck="false" placeholder="Año de Fabricacion" CssClass="form-control col-12" ID="txtAñoFab" runat="server"></asp:TextBox>
                                 </div>
                                    <%--<div class="form-group col-lg-12">  
                                    <label for="userName">Archivo:</label>
                                    <asp:FileUpload required CssClass="form-control" ID="fuArchivo" runat="server" accept=".pdf"  />
                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                    </div>--%>
                                
                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="Button1" CssClass="btn btn-instagram m-t-5 " runat="server" Text="Guardar" OnClick="btnGrabarUnidad_Click" ></asp:LinkButton>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
               </div>
                <%------------------------------------------------------ FIN REGISTRO UNIDAD -------------------------------------------------------------%>
                <%-- CONFIRMAR ELIMINADO DE FILA --%>
            <div id="infoModalAlert6" tabindex="-1" role="dialog" class="modal fade">
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
                                    <h3 class="text-danger">¿Desea eliminar lo seleccionado?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminarTipo" CssClass="btn btn-danger" runat="server" OnClick="btnEliminarTipo_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE ELIMINADO DE FILA --%>

                </asp:View>

                <asp:View ID="View3" runat="server">
                    <asp:Panel runat="server" ID="doc1">
                    <div class="col-lg-6">
                        <asp:label runat="server" CssClass="page-title" id="lblDocumentacion" ></asp:label>
                    </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="doc2">
                    <div class="col-lg-6">
                    <asp:Label runat="server" CssClass="page-title" ID="lblDocumentacion2" ></asp:Label>
                    </div>
                    </asp:Panel>
                    <div class="panelOptions col-sm-6 m-t-15" style="text-align: right;">
        
                     <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="btnRegresar_Click" >
                        <span>Regresar</span>
                     </asp:LinkButton>
                     <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="LinkButton2_Click">
                        <i class="fa fa-plus m-r-5"></i> <span> Agregar </span>  
                     </asp:LinkButton>
                    </div>
                

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">
                                <div class="panelOptions col-sm-6" style="text-align: right;"></div>
                                <div class="clearfix"></div>
                                <asp:GridView ID="grvDocumentacion" runat="server" AutoGenerateColumns="False" OnRowCommand="grvDocumentacion_RowCommand"
                                CssClass="table table-striped table-bordered dataTable" GridLines="None" >
                                    <Columns>
                                        <asp:BoundField DataField="id_doc" HeaderText="ID Documento" Visible="false" />
                                        <asp:BoundField DataField="tipo_doc" HeaderText="Tipo Documento"/>
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo" Visible="false" />
                                        <asp:BoundField DataField="id" HeaderText="ID" Visible="false"/>
                                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Inicio"/>
                                        <asp:BoundField DataField="fecha_fin" HeaderText="Fecha de Termino"/>
                                        <asp:BoundField DataField="documentacion" HeaderText="Documentacion" visible="false"/>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr >
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnDetalle" CommandArgument='<%#Eval("documentacion")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ToolTip="Descargar" CommandArgument='<%# Eval("documentacion") %>' CommandName="Descargar" CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" ID="LinkButton9" runat="server"><i class="fa fa-file-pdf-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminarDoc" CommandArgument='<%#Eval("id_doc")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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
                
                <%-- CONFIRMAR ELIMINADO DE FILA --%>
            <div id="infoModalAlert7" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span>
                            <span class="sr-only">Cerrar</span>
                            </button>
                        </div>
                        <asp:TextBox runat="server" ID="TextBox11" Visible="false"></asp:TextBox>
                        <div class="modal-body">
                            <div class="text-center">
                                <span class="text-danger icon icon-times-circle icon-5x"></span>
                                    <h3 class="text-danger">¿Desea eliminar este documento?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-danger" runat="server" OnClick="btnEliminarTipo_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>

                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE ELIMINADO DE FILA --%>
               <div id="infoModalAlert8" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Documentacion</h4>
                        </div>
                        <div class="modal-body">
                            
                            <div class="row">
                                <asp:textbox runat="server" ID="txtTipo" Visible="false"></asp:textbox>
                                <asp:textbox runat="server" ID="txtIdtipo" Visible="false"></asp:textbox>
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                
                                <div class="form-group col-lg-12">
                                    <asp:DropDownList  CssClass="form-control" ID="ddlTipoDocu" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-sm-6">
                                     <asp:Label  ID="lblfecha" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha Registro:</asp:Label>
                                     <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtFechaRegistro" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-6">
                                     <asp:Label  ID="Label1" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha Fin:</asp:Label>
                                     <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtFechaFin" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                    <div class="form-group col-lg-12">  
                                    <label for="userName">Archivo:</label>
                                    <asp:FileUpload required CssClass="form-control" ID="fuArchivo" runat="server" accept=".pdf"  />
                                    <asp:HiddenField ID="HiddenField3" runat="server" />
                                    </div>
                                
                                <div class="form-group col-lg-12 text-right">
                                    <asp:Button ID="Button2" CssClass="btn btn-instagram m-t-5 " runat="server" Text="Guardar" OnClick="Button2_Click" ></asp:Button>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
               </div>

                </asp:View>
           
           
          </asp:MultiView>
        </div>
    </div>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>

    
</asp:Content>

