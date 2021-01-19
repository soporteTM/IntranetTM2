<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Otros_Default" EnableEventValidation="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .card-actions {
            margin-top: -15px;
        }

        .md-form-group {
            margin-bottom: 0px !important;
        }

        .parsley-errors-list {
            display: none !important;
        }

        .wizard.vertical > .steps {
            width: 100%;
        }

        .wizard > .steps .current a {
            background: #2184be;
        }

        .wizard > .steps a {
            text-align: left;
            padding-left: 60px;
        }

            .wizard > .steps a:hover {
                text-align: left;
                padding-left: 60px;
            }

        .wizard > .steps .number {
            left: 3px;
        }

        .form-control {
            border: 1px solid #e3e3e3;
            border-radius: 4px;
            padding: 6px 6px;
            height: auto !important;
            max-width: 100%;
            font-size: 12px;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: all 300ms linear;
            -moz-transition: all 300ms linear;
            -o-transition: all 300ms linear;
            -ms-transition: all 300ms linear;
            transition: all 300ms linear;
            background-color: #fbfbfb;
        }

        select.form-control {
            padding: 6px 1px;
        }

        #mapa {
            max-width: 1200px;
            height: 350px;
        }

        tr.selected {
            background-color: #337ab7 !important;
            color: white;
        }

            tr.selected a {
                color: white;
            }

        .modalArchivo .modal-dialog {
            max-width: 420px !important;
        }

        textarea.form-control {
            min-height: 40px;
            resize: none;
        }

        .tooltipster-content {
            color: #797979 !important;
        }

        .tooltipster-sidetip .tooltipster-box {
            border: 1px solid #ccc !important;
            background-color: #f3f3f3 !important;
        }

        .tooltipster-sidetip.tooltipster-top .tooltipster-arrow-border, .tooltipster-sidetip.tooltipster-top .tooltipster-arrow-background {
            border-top-color: #ccc !important;
        }

        .infoHTML table td {
            padding: 3px !important;
        }

        .noBorder {
            padding: 0px !important;
            border: none !important;
        }

            .noBorder table {
                margin: 0px !important;
                border: none;
            }

        .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
            background-color: #2184be !important;
            border: 1px solid #188ae2 !important;
        }

            .nav-tabs > li.active > a, .nav-tabs > li.active > a:focus, .nav-tabs > li.active > a:hover {
                color: #ffffff !important;
            }

        .nav-tabs {
            border-bottom: 2px solid #2184be;
        }

        .tab-content > .tab-pane {
            display: block;
        }

        .nav > li > a {
            padding: 10px 13px;
        }
        /* .nav-tabs>li{
            margin-bottom:-2px;
        }*/
    </style>
    <!--Form Wizard-->
    <script src="https://maps.google.com/maps/api/js?key=AIzaSyACUIWfOegSNoAekhfohSapVb4zVvqcWaA&libraries=places&region=pe&language=es"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Reposición de Telefonos </h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Otros</a>
                    </li>
                    <li class="active">Busqueda
                    </li>
                </ol>
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
                            <h4 class="header-title"><b>Registro</b></h4>
                        </div>

                        <div class="panelOptions col-sm-6" style="text-align: right;">
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default waves-effect waves-light m-b-5" runat="server" OnClick="LinkButton1_Click">
                                <i class="fa fa-plus m-r-5"></i> <span>Nuevo</span> </asp:LinkButton>
                            <asp:LinkButton ID="LinkEnviar"  CssClass="btn btn-primary waves-effect waves-light m-b-5" runat="server" OnClick="LinkEnviar_Click">
                                <i class="fa fa-plus m-r-5"></i> <span>Enviar</span> </asp:LinkButton>
                        </div>

                        <div class="clearfix"></div>
                        <asp:HiddenField runat="server" ID="hfusuario"/>
                        <asp:HiddenField runat="server" ID="Hfnomusuario"/>
                        <asp:HiddenField runat="server" ID="hfcod_reposicion" />

                        <asp:GridView ID="gvOtros" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None"
                            OnRowCommand="gvOtros_RowCommand" OnPreRender="gvOtros_PreRender" OnRowDataBound="gvOtros_RowDataBound" Visible="false">

                            <Columns>
                                <asp:BoundField  DataField="cod_reposicion" HeaderText="Codigo" Visible="false" />
                                <asp:BoundField DataField="n_celular" HeaderText="Numero Celular" />
                                <asp:BoundField DataField="empleado" HeaderText="Empleado" />
                                <%--<asp:BoundField DataField="conductor" HeaderText="Conductor" />--%>
                                <asp:BoundField DataField="tipo_emp" HeaderText="Tipo Empleado" />
                                <asp:BoundField Visible="false" DataField="motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="opcional_motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                                <asp:BoundField DataField="placa" HeaderText="Placa"/>
                                <asp:BoundField Visible="false" DataField="area" HeaderText="Area"/>
                                <asp:BoundField  DataField="opcional_area" HeaderText="Area" />
                                <asp:BoundField Visible="false" DataField="fch_entrega" HeaderText="Fecha Entrega" />
                                <asp:BoundField DataField="plan_equipo" HeaderText="Plan Equipo" Visible="false" />
                                <asp:BoundField DataField="nom_equipo" HeaderText="Modelo Equipo" Visible="false" />
                                <asp:BoundField Visible="false" DataField="usuario_registro" HeaderText="Usuario Registro" />
                                <asp:BoundField Visible="false" DataField="usuario_modificacion" HeaderText="Usuario Modificacion" />
                                <asp:BoundField Visible="false" DataField="fch_modificacion" HeaderText="Fecha Modificacion" />
                                <asp:BoundField Visible="false" DataField="estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%#Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                </asp:TemplateField>

                            <asp:TemplateField>
       
                           <ItemTemplate>
                             <table>
                                  <tr>

                                   <td>
                                       <asp:LinkButton  ToolTip="Eliminar Reposicion" CommandArgument='<%# Eval("cod_reposicion") %>' CommandName="Eliminar1" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                   </td>
                                    </tr>
                                  </table>
                            </ItemTemplate>
                         </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>

                        <!---- VISTA ADMINISTRADOR -->

                         <asp:GridView ID="GvOtros1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered dataTable" GridLines="None"
                           OnPreRender="GvOtros1_PreRender" OnRowDataBound="GvOtros1_RowDataBound" OnRowCommand="GvOtros1_RowCommand" Visible="false">
                            <Columns>
                                <asp:TemplateField>
                            <ItemTemplate>
                                    <table>
                                        <tr>
                                                <td style="padding: 0 2px;">
                                                     <asp:CheckBox  ID="chkReposicion" runat="server"  EnableViewState="true"/>   
                                                </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:BoundField  DataField="cod_reposicion" HeaderText="Codigo" />
                                <asp:BoundField DataField="n_celular" HeaderText="Numero Celular" />
                                <asp:BoundField DataField="empleado" HeaderText="Empleado" />
                                <asp:BoundField DataField="tipo_emp" HeaderText="Tipo Empleado" />
                                <asp:BoundField Visible="false" DataField="motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="opcional_motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="placa" HeaderText="Placa"/>
                                <asp:BoundField DataField="unidad" HeaderText="Unidad" />
                                <asp:BoundField  DataField="area" HeaderText="Area" Visible="false" />
                                <asp:BoundField  DataField="opcional_area" HeaderText="Area" />
                                <asp:BoundField DataField="fch_solicitud" HeaderText="Fecha Solicitud" Visible="false" />
                                <asp:BoundField DataField="fch_entrega" HeaderText="Fecha Entrega" Visible="false" />
                                <asp:BoundField DataField="plan_equipo" HeaderText="Plan Equipo" Visible="true" />
                                <asp:BoundField DataField="nom_equipo" HeaderText="Modelo Equipo" Visible="true" />
                                <asp:BoundField  DataField="usuario_registro" HeaderText="Usuario Registro" Visible="false" />
                                <asp:BoundField  DataField="usuario_modificacion" HeaderText="Usuario Modificacion" Visible="false" />
                                <asp:BoundField  DataField="fch_modificacion" HeaderText="Fecha Modificacion" Visible="false" />
                                <asp:BoundField  DataField="estado" HeaderText="Estado"  Visible="false" />
                                <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado1" runat="server" Text='<%#Eval("estado") %>' Font-Size="10" Height="30px" ></asp:Label>
                                            </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                <ItemTemplate>
                                <table>
                                  <tr>
                                       <td>
                                          <asp:LinkButton ToolTip="Asignar reposicion" CommandArgument='<%# Eval("cod_reposicion")%>' CommandName="Editar" CssClass="icon-list-demo" ID="Edit" runat="server"><i class="ti-pencil-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                       </td>
                                   <td>
                                       <asp:LinkButton  ToolTip="Eliminar Reposicion" CommandArgument='<%# Eval("cod_reposicion") %>' CommandName="Eliminar" CssClass="icon-list-demo" ID="LinkButton3" runat="server"><i class="ti-trash" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
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

            <div id="infoModalAlert15" tabindex="-1" role="dialog" class="modal fade">
               <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Mensaje de Correo</h4>
                        </div>
                        <div class="modal-body">
                            <label for="userName">Mensaje</label>
                            <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtObservaciones" TextMode="MultiLine"  Rows="4" runat="server"></asp:TextBox>
                            <br />
                           
                            <asp:LinkButton ID="btnAsignar" CssClass="btn btn-instagram m-t-5 " OnClick="btnAsignar_Click" runat="server" Text="Enviar Correo" ></asp:LinkButton>
                                
                        
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
                            <h4 class="modal-title">Registro de Reposición</h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox  spellcheck="false" placeholder="Razon Social" CssClass="form-control col-12" ID="txtId" runat="server" Visible="false"></asp:TextBox>
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                    <div class="form-group col-lg-6">
                                         <asp:RadioButton ID="RBadministrativo" runat="server" required CssClass="form-control col-lg-6" GroupName="Tipo" Text="Administrativo" OnCheckedChanged="RBadministrativo_CheckedChanged" AutoPostBack="True" Visible="false" />
                                     </div>
                                     <div class="form-group col-lg-6">
                                         
                                         <asp:RadioButton ID="RBConductor" runat="server" required CssClass="form-control col-lg-6" GroupName="Tipo" Text="Conductor" OnCheckedChanged="RadioButton2_CheckedChanged"   AutoPostBack="True" Visible="false" />
                                     </div>
                                        
                                    <div class="form-group col-lg-12">
                                         <div class="form-group col-lg-6">
                                            <asp:CheckBox  ID="chkConductor" runat="server" Text="Conductor?"  EnableViewState="true" OnCheckedChanged="chkConductor_CheckedChanged" AutoPostBack="True"/>  
                                        </div>
                                        <div class="form-group col-lg-6">
                                            <asp:TextBox  required spellcheck="false" placeholder="Ingresar Información" CssClass="form-control col-lg-12 autocomplete"  data-url="BuscarConductor.ashx" ID="txtEmpleado" runat="server" ></asp:TextBox>
                                        </div>
                                        
                                    </div>  

                                <div class="form-group col-lg-12">
                                     <div class="form-group col-lg-4">
                                         <label for="userName">Área</label>
                                        <asp:DropDownList ToolTip="Seleccionar Área" required CssClass="form-control" ID="ddlArea" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-lg-4">
                                          <label for="userName">Unidad</label>
                                          <asp:TextBox spellcheck="false" placeholder="Unidad" CssClass="form-control col-12 autocomplete" data-url="BuscarUnidad.ashx"  ID="txtUnidad" runat="server"></asp:TextBox>
                                         
                                     </div>
                                     <div class="form-group col-lg-4">
                                           <label for="userName">Placa</label>
                                        <asp:TextBox   spellcheck="false" placeholder="Placa" CssClass="form-control col-12" ID="txtUnidad_id" runat="server"></asp:TextBox>
                                      </div>

                                </div>

                               <div class="form-group col-lg-12">
                                   <div class="form-group col-lg-6">
                                    <label for="userName">Motivo</label>
                                     <asp:DropDownList ToolTip="Seleccionar Motivo" required CssClass="form-control" ID="ddlMotivo" runat="server">
                                     </asp:DropDownList>
                                 </div>
                                 <div class="form-group col-lg-6">
                                    <label for="userName">Teléfono</label>
                                     <asp:TextBox  required spellcheck="false" placeholder="Teléfono" CssClass="form-control col-12" ID="txtTelefono" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ControlToValidate="txtTelefono" ErrorMessage="*Ingrese Valores Numericos"
                                    ForeColor="Red"
                                    ValidationExpression="^[0-9]*">
                                </asp:RegularExpressionValidator>
                                </div>

                                   <div class="col-lg-12">
                                        <label for="userName">Observaciones </label>
                                        <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtobs" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                    </div> 
                               </div>
                                 
                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="btnGuardar1" CssClass="btn btn-instagram m-t-5" runat="server" Text="Guardar" OnClick="btnGuardar1_Click"/>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>


               <div id="infoModalAlert5" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Solicitud Correo</h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox  spellcheck="false" placeholder="Razon Social" CssClass="form-control col-12" ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="form-group col-lg-12">
                                    
                                    <div class="form-group col-lg-6">
                                        <label for="userName">Plan Equipo</label>
                                         <asp:DropDownList ToolTip="Plan Equipo" required CssClass="form-control" ID="ddlPlanEquipo" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                     <div class="form-group col-lg-6">
                                         <label for="userName">Modelo Equipo</label>
                                        <asp:TextBox  required  spellcheck="false" placeholder="Informacion Equipo"   CssClass="form-control col-12" ID="txtNombreEquipo" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                 <div class="form-group col-lg-12 text-right">
                                     <asp:LinkButton ID="lnkAsignar" CssClass="btn btn-instagram m-t-5" runat="server" Text="Asignar" OnClick="lnkAsignar_Click"></asp:LinkButton>
                                     
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
                                    <h3 class="text-danger">¿Desea eliminar esta Solicitud?</h3>
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


        </asp:View>
    </asp:MultiView>
</asp:Content>








