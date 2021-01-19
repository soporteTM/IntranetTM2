<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Operativo_Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Embarque/Descarga</h4>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <div class="col-sm-7 m-t-15">
        <asp:label id="lblTitulo" class="page-title" runat="server"></asp:label>
    </div>
    <div class="col-sm-6">                             
          <asp:Label  ID="lblMensaje" runat="server" CssClass="text1" Font-Bold="True" ForeColor="#CC3300" Visible="false"></asp:Label>
        <div class="form-group col-lg-6">
            <label for="userName">Estado </label>
            <asp:DropDownList CssClass="form-control" ID="ddlEstadoNave" runat="server" OnSelectedIndexChanged="ddlEstadoNave_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
        </div>
    </div>
    
    <!-- end row -->
    <d
    <div class="panelOptions col-sm-5 m-t-20" style="text-align: right;">
        
                     <asp:LinkButton ID="btnRegresar" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="btnRegresar_Click" >
                        <span>Regresar</span>
                     </asp:LinkButton>
                     <asp:LinkButton ID="btnAgregar" CssClass="btn btn-primary waves-effect waves-light m-b-5 m-r-5" runat="server" OnClick="btnAgregar_Click" >
                        <i class="fa fa-plus m-r-5" ></i> <span> Agregar </span>  
                     </asp:LinkButton>
                     <asp:LinkButton ID="btnExportar" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="btnExportar_Click" >
                        <i class="glyphicon glyphicon-save-file m-r-5"></i> <span> Exportar </span>  
                     </asp:LinkButton>
                     <asp:LinkButton ID="btnRefrescar" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="btnRefrescar_Click" Visible="false" >
                        <i class="glyphicon glyphicon-refresh m-r-5"></i> <span> Actualizar</span>  
                     </asp:LinkButton>
                     <asp:LinkButton ID="btnEliminarAll" CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="btnEliminarAll_Click" Visible="false">
                        <i class="glyphicon glyphicon-refresh m-r-5"></i> <span> Eliminar Seleccion</span>  
                     </asp:LinkButton>

                     
     </div>

    <div class="row">
        
        <div class="col-md-12">
          
            <%-- INICIO VISTA LISTADO NAVES --%>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="card-box table-responsive">
                                <div class="panelOptions col-sm-6" style="text-align: right;"></div>
                                <div class="clearfix"></div>
                                                            <asp:HiddenField runat="server" ID="hfNomUser"/>
                                                         <asp:HiddenField runat="server" ID="hfidSeg" />

                                <asp:GridView ID="grvNave" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered dataTable" GridLines="None" OnRowCommand="grvNave_RowCommand"  OnPreRender="grvNave_PreRender" OnRowDataBound="grvNave_RowDataBound">
                                   
                                    <Columns>
                                        <asp:BoundField DataField="fila" HeaderText="N°" Visible="true" />
                                        <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                        <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                        <asp:BoundField DataField="nro_manifiesto" HeaderText="Manifiesto" />
                                        <asp:BoundField DataField="Puerto" HeaderText="Puerto"  />
                                        <asp:BoundField DataField="fecha_registro" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="fecha_termino" HeaderText="Fecha Termino"  />
                                        <asp:TemplateField HeaderText="Operacion">
                                            <ItemTemplate>
                                                <asp:Label ID="lbloperacion" runat="server" Text='<%# Eval("operacion") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFinalizado" runat="server" Text='<%# Eval("finalizado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnDetalle" CommandArgument='<%#Eval("id")+";"+Eval("Nave")+";"+Eval("operacion")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id")+";"+Eval("Nave")+";"+Eval("Puerto")+";"+Eval("fecha_termino")+";"+Eval("fecha_registro")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Modificar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

            <%-- INICIO DE REGISTRAR NAVE CONTENEDOR --%>
            <div id="infoModalAlert2" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Nave</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="form-group col-lg-6">
                                    <label for="userName">Puerto </label>
                                    <asp:DropDownList  CssClass="form-control" ID="ddlPuerto" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label for="userName">Operacion </label>
                                    <asp:DropDownList  CssClass="form-control" ID="ddlOperacion" runat="server" OnSelectedIndexChanged="ddlOperacion_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                 <div class="form-group col-lg-12">
                                    <label for="userName">Nave </label>
                                    <asp:TextBox  required spellcheck="false" placeholder="Nave" CssClass="form-control col-12" ID="txtNave" runat="server"></asp:TextBox>
                                </div>
                                    <div class="col-sm-6">
                                     <asp:Label  ID="lblfecha" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha:</asp:Label>
                                     <div class="input-group">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtFecha" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                    <div class="col-sm-6">
                                     <asp:Label  ID="lblHora" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Hora:</asp:Label>
                                       <asp:TextBox required spellcheck="false" placeholder="HH:MM" CssClass="form-control col-12" ID="txtHora" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator 
                                        id="txtHora_validation" runat="SERVER" 
                                        ControlToValidate="txtHora" 
                                        ErrorMessage="El formato para ingresar hora es:  HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$">
                                        </asp:RegularExpressionValidator>
                                </div>
                                
                                <asp:Panel ID="PanelEmbarque" runat="server" Visible="true">
                                   
                                <div class="form-group col-lg-12">
                                    <label for="userName">Archivo </label>
                                    <asp:FileUpload CssClass="form-control" ID="fuImportar" runat="server" />
                                </div>

                                </asp:Panel>

                                <asp:Panel ID="PanelDescarga" runat="server" Visible="false">
                                    <div class="col-sm-6 m-t-15">
                                     <asp:Label  ID="lblAmanifiesto" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Año Manifiesto</asp:Label>
                                       <asp:TextBox  spellcheck="false" placeholder="Año manifiesto" CssClass="form-control col-12" ID="txtAmanifiesto" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator 
                                        id="txtAmanifiesto_validation" runat="SERVER" 
                                        ControlToValidate="txtAmanifiesto" 
                                        ErrorMessage="Debe ingresar un año valido "
                                        ValidationExpression="^\d{4}$">
                                        </asp:RegularExpressionValidator>
                                </div>
                                    <div class="col-sm-6 m-t-15">
                                     <asp:Label  ID="lblNmanifiesto" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Nro Manifiesto</asp:Label>
                                       <asp:TextBox  spellcheck="false" placeholder="Numero manifiesto" CssClass="form-control col-12" ID="txtNmanifiesto" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator 
                                        id="txtNmanifiesto_validation" runat="SERVER" 
                                        ControlToValidate="txtNmanifiesto" 
                                        ErrorMessage="Este campo solo puede contener digitos"
                                        ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$">
                                        </asp:RegularExpressionValidator>
                                </div>
                                </asp:Panel>
                                

                                

                                <div class="form-group col-lg-12 text-right">
                                    <asp:Button ID="btnImportar" CssClass="btn btn-instagram m-t-5 " runat="server" OnClick="btnImportar_Click"  Text="Guardar"></asp:Button>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE REGISTRAR NAVE CONTENEDOR --%>
                     <%-- INICIO ACTUALIZAR NAVE --%>
                    <div id="infoModalAlert4" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Actualizacion de Nave</h4>
                            <asp:label ID="lblANave" runat="server" class="modal-title"></asp:label>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <asp:TextBox  spellcheck="false" placeholder="Contenedor" CssClass="form-control col-12" ID="txtID" runat="server" Visible="false"></asp:TextBox>
                                
                                <div class="form-group col-lg-12">
                                    <label for="userName">Nave </label>
                                    <asp:TextBox  spellcheck="false" placeholder="Nave" CssClass="form-control col-12" ID="txtANave" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Fecha Inicio </label>
                                    <asp:TextBox  spellcheck="false" placeholder="DD/MM/AAAA HH:MM" CssClass="form-control col-12" ID="txtAFechaInicio" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-6">
                                    <label for="userName">Fecha termino </label>
                                    <asp:TextBox  spellcheck="false" placeholder="DD/MM/AAAA HH:MM" CssClass="form-control col-12" ID="txtAFecha" runat="server"></asp:TextBox>
                                </div>
                                
                                

                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="btnActualizarNave" CssClass="btn btn-instagram m-t-5 " runat="server" OnClick="btnActualizarNave_Click" ><i class="fa fa-save"></i> <span>  Guardar</span>  </asp:LinkButton>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
                    <%-- FIN ACTUALIZAR NAVE --%>

                    <%-- CONFIRMAR ELIMINADO DE FILA --%>
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
            <%-- Seleccion de exportacion--%>
            <div id="infoModalAlertexpo" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span>
                            <span class="sr-only">Cerrar</span>
                            </button>
                            <h3 class="text">Exportar Reporte</h3>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="form-group col-lg-12">
                                    <div class="form-group col-lg-3 m-t-10">    
                                        <asp:Label  ID="Label3" runat="server" CssClass="m-t-10" ForeColor="#000000" Visible="true">Tipo de Reporte:</asp:Label>
                                    </div>
                                    <div class="form-group col-lg-9">
                                        <asp:DropDownList  CssClass="form-control" ID="ddlExportar" runat="server" OnSelectedIndexChanged="ddlExportar_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                </div>
                            <div class="row">
                                <asp:panel runat="server" ID="pnl1" Visible="false">
                                
                                <div class="col-sm-6">
                                     <asp:Label  ID="Label2" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha inicio:</asp:Label>
                                    <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtfchBegin" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                     <asp:Label  ID="Label1" runat="server" CssClass="m-t-5" ForeColor="#000000" Visible="true">Fecha fin:</asp:Label>
                                    <asp:TextBox required data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtfchEnd" runat="server"></asp:TextBox>
                                
                                    </div>
                                </asp:panel>
                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="Button1" CssClass="btn btn-instagram m-t-5 " runat="server" OnClick="Button1_Click"  Text="Generar"></asp:LinkButton>
                                </div>
                            </div>
                                
                        </div>
                        
                        
                        <div class="modal-footer"></div>
                    </div>
                </div>
                    </div>
            </div>
            <%-- FIN seleccionar de exportar --%>

            </asp:View>
            <%-- FIN DE VISTA LISTADO NAVES --%>

            <%-- INICIO DE VISTA DETALLE --%>
            <asp:View ID="View2" runat="server">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box table-responsive">
                            <div class="clearfix"></div>
                                <asp:GridView ID="grvContenedor" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-striped table-bordered dataTable" OnPreRender="grvContenedor_PreRender" OnRowCommand="grvContenedor_RowCommand" OnRowDataBound="grvContenedor_RowDataBound" >
                                    <Columns>
                                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkContenedorALL" runat="server" EnableViewState="true" OnCheckedChanged="chkContenedorALL_CheckedChanged" AutoPostBack="true" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="padding: 0 2px;">
                                            <asp:CheckBox ID="chkContenedor" runat="server" EnableViewState="true"/>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                                        <asp:BoundField DataField="id_seg" HeaderText="id segumiento"  Visible="false"/>
                                        <asp:BoundField DataField="id_cnt" HeaderText="id contenedor"  Visible="false"/>
                                        <asp:BoundField DataField="contenedor" HeaderText="Contenedor"  />
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo"  />
                                        <asp:TemplateField HeaderText="Vacio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVacio" runat="server" Text='<%# Eval("vacio") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chofer">
                                            <ItemTemplate>
                                                <div class="input-group">
                                                    <span class="input-group m-r-10">
                                                        <span class="mdi mdi-worker"></span>
                                                    </span>
                                                <asp:Label ID="lblConductor" runat="server" Text='<%# Eval("nom_conductor") %>' Font-Size="10"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="cod_interno" HeaderText="Codigo interno"  />
                                        <asp:TemplateField HeaderText="Placa">
                                            <ItemTemplate>
                                                <div class="input-group">
                                                    <span class="input-group m-r-10">
                                                        <span class="mdi mdi-truck"></span>
                                                    </span>
                                                    <asp:Label ID="lblPlaca" runat="server" Text='<%# Eval("nro_placa") %>' Font-Size="10"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnAsignar" CommandArgument='<%#Eval("id_cnt")+";"+Eval("contenedor")+";"+Eval("Vacio")+";"+Eval("nom_conductor")+";"+Eval("nro_placa")+";"+Eval("id_seg")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="asignar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_cnt")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

                  <%-- INICIO REGISTRAR CONTENEDOR --%>
                    <div id="infoModalAlert3" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Contenedor</h4>
                            <asp:label ID="lblNave" runat="server" class="modal-title"></asp:label>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <asp:TextBox  spellcheck="false" placeholder="Contenedor" CssClass="form-control col-12" ID="txtCodNave" runat="server" Visible="false"></asp:TextBox>
                                <div class="form-group col-lg-12">
                                    <label for="userName">Contenedor </label>
                                    <asp:TextBox  spellcheck="false" placeholder="Contenedor" CssClass="form-control col-12" ID="txtContenedor" runat="server"></asp:TextBox>
                                    <%--<asp:RegularExpressionValidator 
                                        id="txtContenedor_validacion" runat="SERVER" 
                                        ControlToValidate="txtContenedor" 
                                        ErrorMessage="El contenedor debe contener 4 letras y 7 numeros "
                                        ValidationExpression="^\[A-Z]\d{7}$">
                                        </asp:RegularExpressionValidator>--%>
                                </div>
                                <div class="form-group col-lg-10">
                                    <label for="userName">Tipo </label>
                                    <asp:TextBox  spellcheck="false" placeholder="Tipo" CssClass="form-control col-12" ID="txtTipo" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-lg-2">
                                    <label for="userName" class="m-t-20">  </label>
                               <div class="checkbox checkbox-primary" style="width: 20px;height: 20px;padding: 0px;margin: auto;float: none;display: block;">
                                   
                                    <asp:CheckBox ID="chk" runat="server" />
                                    <label for="chkActivo">Vacio</label>
                                </div>
                                </div>
                                <div class="form-group col-lg-10">
                                    
                               <div class="checkbox checkbox-primary m-l-15" style="width: 20px;height: 20px;padding: 0px;float: none;display: block;">
                                   
                                    <asp:CheckBox ID="ckhexcel" runat="server" OnCheckedChanged="ckhexcel_CheckedChanged" AutoPostBack="true" />
                                    <label for="chkActivo">Excel</label>
                                </div>
                                </div>
                                <div class="form-group col-lg-10" >
                                    <asp:FileUpload CssClass="form-control" ID="fuImportar2" runat="server" visible="false" />

                                </div>
                                
                                

                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="btnAgregarContenedor" CssClass="btn btn-instagram m-t-5 " runat="server" OnClick="btnAgregarContenedor_Click" ><i class="fa fa-save"></i> <span>  Guardar</span>  </asp:LinkButton>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
                    <%-- FIN REGISTRO CONTENEDOR --%>


                <%-- INICIO REGISTRAR SEGUIMIENTO --%>
                <div id="infoModalAlertAdd" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <asp:Label ID="NombreContenedor" runat="server" class="modal-title"></asp:Label>
                            <asp:label ID="lblContenedor" runat="server" class="modal-title" Text="0" Visible="false"></asp:label>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <asp:TextBox ID="txtContenedor_id" runat="server" Visible="false"></asp:TextBox>
                                
                                <div class="form-group col-lg-10">
                                    <label for="userName">Unidad </label>
                                    <asp:TextBox CssClass="form-control autocomplete" placeholder="Numero de Unidad"  data-url="BuscarUnidad.ashx" ID="txtUnidad" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtUnidad_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                </div>
                                <%-- <div class="form-group col-lg-4">
                                    <label for="userName">Placa </label>
                                    <asp:TextBox  spellcheck="false" CssClass="form-control col-12" ID="txtPlaca" runat="server" Enabled="false" ></asp:TextBox>
                                </div>--%>

                                <div class="form-group col-lg-2">
                                    <label for="chkActivo"></label>
                                    <div class="checkbox checkbox-primary m-l-15 m-t-15" style="width: 20px;height: 20px;padding: 0px;float: none;display: block;">
                                    <asp:CheckBox ID="chkVacio" runat="server" />
                                    <label for="chkActivo">Vacio</label>
                                </div>
                                </div>
                                

                                <div class="form-group col-lg-12">
                                    <label for="userName">Conductor </label>
                                    <asp:TextBox CssClass="form-control autocomplete" data-url="BuscarConductor.ashx" ID="txtConductor" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtConductor_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                </div>
                               
                                <label for="userName">Ingreso al Deposito </label>
                                <div class="row">
                                <div class="form-group col-lg-4">
                                    <div class="input-group"  style="width:100%">
                                        <span class="input-group-addon">
                                        <span class="fa fa-calendar-check-o"></span>    
                                        </span>
                                         <span class="input-group-btn" style="width:100px">
                                         
                                        <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control col-8" ID="txtDia01" runat="server"></asp:TextBox>
                                       </span>
                                        
                                      
                                        <asp:TextBox  spellcheck="false" placeholder="Hora Llegada:" CssClass="form-control col-4" ID="txtFch1" runat="server" style="text-align: right;width:40px;" ></asp:TextBox>
                                    </div>
                                     <asp:RegularExpressionValidator 
                                        id="RegularExpressionValidator1" runat="SERVER" 
                                        ControlToValidate="txtFch1" 
                                        ErrorMessage="El formato es :HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$" >
                                        </asp:RegularExpressionValidator>
                                        
                                </div>

                               




                                <div class="form-group col-lg-4">
                                    <div class="input-group" style="width:100%">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <span class="input-group-btn" style="width:100px">
                                             <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control col-8" ID="txtDia02" runat="server"></asp:TextBox>
                                            
                                        </span>
                                        <asp:TextBox  spellcheck="false" placeholder="Hora Ingreso:" CssClass="form-control col-12" ID="txtFch2" runat="server" style="text-align: right;width:40px;" ></asp:TextBox>
                                    </div>
                                     <asp:RegularExpressionValidator 
                                        id="RegularExpressionValidator2" runat="SERVER" 
                                        ControlToValidate="txtFch2" 
                                        ErrorMessage="El formato es :HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$">
                                        </asp:RegularExpressionValidator>
                                </div>


                                <div class="form-group col-lg-4">

                                    <div class="input-group" style="width:100%">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <span class="input-group-btn" style="width:100px">

                                         <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control col-8" ID="txtDia03" runat="server"></asp:TextBox>
                                            
                                        </span>
                                        <asp:TextBox  spellcheck="false" placeholder="Hora Salida:" CssClass="form-control col-12" ID="txtFch3" runat="server" style="text-align: right;width:40px;" ></asp:TextBox>
                                    </div>



                                    <asp:RegularExpressionValidator 
                                        id="RegularExpressionValidator3" runat="SERVER" 
                                        ControlToValidate="txtFch3" 
                                        ErrorMessage="El formato es :HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$">
                                        </asp:RegularExpressionValidator>

                                </div>
                                </div>
                                <label for="userName">Ingreso al Terminal </label>
                                <div class="row">
                                <div class="form-group col-lg-4">

                                    <div class="input-group" style="width:100%">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <span class="input-group-btn" style="width:100px">
                                              <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control col-8" ID="txtDia04" runat="server"></asp:TextBox>
                                        </span>

                                        <asp:TextBox  spellcheck="false" placeholder="Hora Llegada:" CssClass="form-control col-12" ID="txtFch4" runat="server" style="text-align: right;width:40px;" ></asp:TextBox>
                                    </div>
                                    <asp:RegularExpressionValidator 
                                        id="RegularExpressionValidator4" runat="SERVER" 
                                        ControlToValidate="txtFch4" 
                                        ErrorMessage="El formato es :HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$">
                                        </asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-lg-4">
                                    <div class="input-group" style="width:100%">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <span class="input-group-btn" style="width:100px">
                                          <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control col-8" ID="txtDia05" runat="server"></asp:TextBox>
                                        </span>  
                                        <asp:TextBox  spellcheck="false" placeholder="Hora Ingreso:" CssClass="form-control col-12" ID="txtFch5" runat="server" style="text-align: right;width:40px;" ></asp:TextBox>
                                    </div>
                                    <asp:RegularExpressionValidator 
                                        id="RegularExpressionValidator5" runat="SERVER" 
                                        ControlToValidate="txtFch5" 
                                        ErrorMessage="El formato es :HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$">
                                        </asp:RegularExpressionValidator>
                                </div>


                                <div class="form-group col-lg-4">
                                    <div class="input-group" style="width:100%">
                                        <span class="input-group-addon">
                                            <span class="fa fa-calendar-check-o"></span>
                                        </span>
                                        <span class="input-group-btn" style="width:100px">
                                            <asp:TextBox data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control col-8" ID="txtDia06" runat="server"></asp:TextBox>
                                        </span>
                                        <asp:TextBox  spellcheck="false" placeholder="Hora Salida:" CssClass="form-control col-12" ID="txtFch6" runat="server" style="text-align: right;width:40px;"></asp:TextBox>
                                    </div>
                                    <asp:RegularExpressionValidator 
                                        id="RegularExpressionValidator6" runat="SERVER" 
                                        ControlToValidate="txtFch6" 
                                        ErrorMessage="El formato es :HH:MM "
                                        ValidationExpression="^(?:0?[0-9]|1[0-9]|2[0-4]):[0-5][0-9]?$">
                                        </asp:RegularExpressionValidator>
                                </div>
                                </div>


                                <div class="form-group col-lg-12 text-right">
                                    

                                   
                                        
                                    <asp:Button ID="btnLiberar" CssClass="btn btn-danger m-t-5 " runat="server" OnClick="btnLiberar_Click" Text="Liberar" Visible="true" ></asp:Button>
                                   
                                    <asp:Button ID="btnAsignar" CssClass="btn btn-instagram m-t-5 " runat="server" OnClick="btnAsignar_Click" Text="Asignar"></asp:Button>
                                    
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
                    <%-- FIN REGISTRO Seguimiento --%>

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

                        <div class="modal-body">
                            <asp:TextBox  spellcheck="false" CssClass="form-control col-" ID="txtid_cnt" runat="server" Visible="false"></asp:TextBox>
                            <div class="text-center">
                                <span class="text-danger icon icon-times-circle icon-5x"></span>
                                    <h3 class="text-danger">¿Desea eliminar este Contenedor?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="btnEliminarCNT" CssClass="btn btn-danger" runat="server" OnClick="btnEliminarCNT_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>
                                
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>

                            <div id="EliminarSeguimiento" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span>
                            <span class="sr-only">Cerrar</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox  spellcheck="false" CssClass="form-control col-" ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                            <div class="text-center">
                                <span class="text-danger icon icon-times-circle icon-5x"></span>
                                    <h3 class="text-danger">¿Desea eliminar este Seguimiento?</h3>
                                    <p>Debe estar seguro antes de eliminar información del sistema</p>
                                    <div class="m-t-lg">
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" OnClick="LinkButton1_Click" ><i class="fa m-r-5"></i> <span>   Eliminar</span>  </asp:LinkButton>
                                        <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                    </div>
                             </div>
                                
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
            <%-- FIN DE ELIMINADO DE FILA --%>



            </asp:View>
           <%-- FIN DE VISTA DETALLE --%>
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

