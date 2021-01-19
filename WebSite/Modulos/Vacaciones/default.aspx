<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="Modulos_Vacaciones_Vacaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <div class="row">
    <div class="col-xs-12">
        <div class="page-title-box">
            <h4 class="page-title">Módulo Vacaciones </h4>                
            <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Inicio</a>
                    </li>
                    <li>
                        <a href="#">Vacaciones</a>
                    </li>
                    <li class="active">Consulta Vacaciones
                    </li>
                </ol>
            <div class="clearfix"></div>
        </div>
    </div>
 </div>

    <div class="row">
        <div class="col-sm-12">
            <div class="card-box table-responsive">
                <div class="col-sm-12">
                    <div class="form-group col-lg-12">
                        <h3 class="header-title">Informe de solicitud de Vacaciones </h3>
                        </div>
                    <div class="col-sm-6">
                        <div class="form-group col-lg-6">
                            <label for="userName">Estado </label>
                            <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                      </div>
                      <div class="panelOptions col-sm-6 pull-right" style="text-align: right;">
                            <asp:LinkButton ID="btnResumen" CssClass="btn btn-instagram m-b-5" runat="server" OnClick="btnResumen_Click" >
                                <i class="glyphicon glyphicon-list"></i> <span> Resumen</span>  </asp:LinkButton>
                            <asp:LinkButton ID="btnNuevo" CssClass="btn btn-instagram m-b-5" runat="server" OnClick="btnNuevo_Click" >
                                <i class="fa fa-plus m-r-5"></i> <span> Nuevo</span>  </asp:LinkButton>
                      </div>
                      
                      <div class="clearfix"></div>
                      <asp:HiddenField ID="hfSolicitante" runat="server" />
                      <asp:HiddenField ID="hfidSolicitud" runat="server" />
                        <asp:gridview id="grvSolicitud" runat="server" autogeneratecolumns="False"  OnRowCommand="grVacaciones_RowCommand" OnRowDataBound="grvSolicitud_RowDataBound" OnPreRender="grvSolicitud_PreRender"
                            cssclass="table table-striped table-bordered dataTable" gridlines="None">
                            <Columns>
                                <asp:BoundField DataField="id_solicitud" HeaderText="Codigo de solicitud" visible="false"/>
                                <asp:BoundField DataField="id_solicitante" HeaderText="id_solicitante" visible="false"/>
                                <asp:BoundField DataField="nom_solicitante" HeaderText="Nombre Solicitante" visible="false"/>
                                <asp:BoundField DataField="id_empleado" HeaderText="id_emp" visible="false"/>
                                <asp:BoundField DataField="nom_empleado" HeaderText="Nombre Empleado" visible="true"/>
                                <asp:BoundField DataField="fch_inicio" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="fch_fin" HeaderText="Fecha Termino" />
                                <asp:BoundField DataField="total_dias" HeaderText="#Días" />
                                <asp:BoundField DataField="observaciones" HeaderText="observaciones" visible="false" />
                                <asp:BoundField DataField="fch_registro" HeaderText="Fecha Registro" />
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnDetalle" CommandArgument='<%#Eval("id_solicitud")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                               <%-- <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnModificar" CommandArgument='<%#Eval("id_solicitud")+";"+Eval("fch_inicio")+";"+Eval("fch_fin")+";"+Eval("total_dias")+";"+Eval("observaciones")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5"   runat="server" CommandName="Modificar"><i class="fa fa-pencil-square-o" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>--%>
                                                <td style="padding: 0 2px;">
                                                    <asp:LinkButton ID="btnEliminar" CommandArgument='<%#Eval("id_solicitud")+";"+Eval("estado")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="eliminar"><i class="fa fa-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                       </asp:gridview>
                    <asp:Panel runat="server" ID="pnlObs">
                    <div class="col-lg-12">
                            <div class="alert alert-icon alert-info alert-dismissible fade in" role="alert">
                                                <i class="mdi mdi-information"></i>
                                                <strong>No cuenta con solicitudes registradas</strong>
                                            </div>
                        </div>
                        </asp:Panel>
                </div>
                </div>
                <asp:Panel runat="server" ID="pnl1" Visible="false">
                <%--<div class="card-box table-responsive">
                    <div class="col-sm-12 m-b-20">
                        <h3 class="header-title">Informe de aprobacion de Vacaciones </h3>
                    </div>
                    <asp:gridview id="grvPendientes" runat="server" autogeneratecolumns="False"  OnRowCommand="grvPendientes_RowCommand" OnRowDataBound="grvPendientes_RowDataBound" OnPreRender="grvPendientes_PreRender"
                        cssclass="table table-striped table-bordered dataTable" gridlines="None">
                            <Columns>
                                <asp:BoundField DataField="id_aprobacion" HeaderText="idAprobacion" Visible="false" />
                                <asp:BoundField DataField="id_solicitud" HeaderText="Codigo de solicitud" Visible="false"  />
                                <asp:BoundField DataField="id_evaluador" HeaderText="idEvaluador" Visible="false" />
                                <asp:BoundField DataField="id_solicitante" HeaderText="id_solicitante" visible="false"/>
                                <asp:BoundField DataField="nom_solicitante" HeaderText="Nombre Solicitante" visible="true"/>
                                <asp:BoundField DataField="id_empleado" HeaderText="id_emp" visible="false"/>
                                <asp:BoundField DataField="nom_empleado" HeaderText="Nombre Empleado" visible="true"/>
                                <asp:BoundField DataField="fch_inicio" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="fch_fin" HeaderText="Fecha Termino" />
                                <asp:BoundField DataField="total_dias" HeaderText="#Días" />
                                <asp:BoundField DataField="fch_ingreso" HeaderText="Fecha Ingreso" />
                                <asp:BoundField DataField="dpto_laboral" HeaderText="Dpto Laboral" />
                                <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="30px">
                                            <itemtemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 0 2px;">
                                                            <asp:linkbutton id="btnaprobar" commandargument='<%#Eval("id_aprobacion")%>' cssclass="btn btn-primary waves-effect waves-light btn-success m-b-5"   Visible="false" runat="server" commandname="Aprobar"><i class="glyphicon glyphicon-ok" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:linkbutton>
                                                        </td>
                                                        <td style="padding: 0 2px;">
                                                            <asp:linkbutton id="btnrechazar" commandargument='<%#Eval("id_aprobacion")%>' cssclass="btn btn-primary waves-effect waves-light btn-danger m-b-5" Visible="false" runat="server" commandname="Rechazar"><i class="glyphicon glyphicon-remove" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:linkbutton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </itemtemplate>
                                        </asp:TemplateField>
                            </Columns>
                        </asp:gridview>
            </div>--%>
          </asp:Panel>
        </div>
    </div>
    <div id="modalResumen" tabindex="-1" role="dialog" class="modal fade">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>

                    <h3 class="header-title">Informe de Vacaciones </h3>
                    
                </div>
                <div class="modal-body">
                            <div class="form-group col-lg-6">
                                <label for="userName">Dias Tomados:</label>
                            </div>
                            <div class="form-group col-lg-6">
                                <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtTomados" enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6">
                                <label for="userName">Dias Pendientes:</label>
                            </div>
                            <div class="form-group col-lg-6">
                                <asp:TextBox  spellcheck="false"  CssClass="form-control col-6" ID="txtPendientes" enabled="false" runat="server"></asp:TextBox>    
                            </div>
                            <div class="form-group col-lg-6">
                                <label for="userName">Dias Truncos:</label>
                            </div>
                            <div class="form-group col-lg-6">
                                <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtTruncos" enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6">
                                <label for="userName">Dias Vencidos: </label>
                            </div>
                            <div class="form-group col-lg-6">
                                <asp:TextBox  spellcheck="false"  CssClass="form-control col-6" ID="txtVencidos" enabled="false" runat="server"></asp:TextBox>
                             </div>
                            <div class="form-group col-lg-6">
                                <label for="userName">Dias Disponibles:</label>
                            </div>
                            <div class="form-group col-lg-6">
                                <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtDisponibles" enabled="false" runat="server"></asp:TextBox>    
                            </div>
                </div>
                <div class="modal-header"></div>
            </div>
        </div>
    </div>

    <div id="modalSeguimiento" tabindex="-1" role="dialog" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>

                    <h3 class="header-title">Informe de aprobacion de Vacaciones </h3>
                    
                </div>
                <div class="modal-body">
                    <asp:gridview id="grvAprobacion" runat="server" autogeneratecolumns="False"  OnRowCommand="grVacaciones_RowCommand" OnRowDataBound="grvAprobacion_RowDataBound"
                    cssclass="table table-striped table-bordered dataTable" gridlines="None">

                            <Columns>
                                <asp:BoundField DataField="id_aprobacion" HeaderText="idAprobacion" Visible="false" />
                                <asp:BoundField DataField="id_solicitud" HeaderText="Codigo de solicitud" Visible="false" />
                                <asp:BoundField DataField="id_evaluador" HeaderText="idEvaluador" Visible="false" />
                                <asp:BoundField DataField="nombre" HeaderText="nombre"/>
                                <asp:BoundField DataField="fch_respuesta" HeaderText="Fecha Respuesta" />
                                <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("estado") %>' Font-Size="10"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                            </Columns>

                        </asp:gridview>
                </div>
                <div class="modal-footer"></div>
            </div>
        </div>
    </div>
    <%-- CONDUCTOR --%>
    <div id="modalConductor" tabindex="-1" role="dialog" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title">Vacaciones</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group col-lg-12">
                            <asp:label runat="server" id="lblNombreEmpleado"  for="userName"> Nombre del Empleado </asp:label>
                        <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarConductor.ashx" ID="txtEmpleado" runat="server" Enabled="false"></asp:TextBox>
                        <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarEmpleados.ashx" ID="txtemp_adm" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtEmpleado_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 2;display: none;"></asp:TextBox>
                        <asp:TextBox ID="txtemp_adm_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 2;display: none;"></asp:TextBox>
                        <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtIdSolicitud" visible="false" runat="server"></asp:TextBox>
                     </div>

    
                    <div class="row">
                        <span class="text-primary icon icon-info-circle icon-5x"></span>

                        <div class="form-group col-lg-12">

                            <div class="form-group col-lg-4">
                                <label for="userName">Fecha Inicio </label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                    <asp:textbox required spellcheck="false" placeholder="Ingresa fecha inicio" data-provide="datepicker" cssclass="form-control datepickers" id="fch_inicio" runat="server"></asp:textbox>
                                </div>
                            </div>

                            <div class="form-group col-lg-4">
                                <label for="userName">Fecha Termino </label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                    <asp:textbox required spellcheck="false" placeholder="Ingresa fecha termino" data-provide="datepicker" cssclass="form-control datepickers" id="fch_fin" runat="server"></asp:textbox>
                                </div>
                            </div>
                            <div class="form-group col-lg-4">
                            <label for="userName">Dias </label>
                            <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtDias" enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-12">
                            <label for="userName">Observaciones </label>
                            <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtObservaciones" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                            </div>

                            <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="btnAsignar" CssClass="btn btn-instagram m-t-5 " OnClick="btnAsignar_Click" runat="server" Text="Guardar" ></asp:LinkButton>
                                </div>

                        </div>

                    </div>
                </div>
                <div class="modal-footer"></div>
            </div>
        </div>
    </div>
    <%-- CONDUCTOR --%>

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
            <%-- FIN DE ELIMINADO DE FILA --%>



    <%-- ADMINISTRATIVO --%>
    <div id="modalAdministrativo" tabindex="-1" role="dialog" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>

                    <h4 class="modal-title">Vacaciones</h4>

                </div>
                <div class="modal-body">
                    <div class="row">
                        <span class="text-primary icon icon-info-circle icon-5x"></span>



                        <asp:textbox spellcheck="false" cssclass="form-control col-" id="Textbox1" runat="server" visible="false"></asp:textbox>
                        <%-- AUTO COMPLETADO CONDUCTOR --%>
                        <div class="form-group col-lg-12">
                            <label for="userName">Empleado </label>
                            <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarConductor.ashx" ID="TextBox2" runat="server"></asp:TextBox>
                        </div>
                        </div>
                        <%-- FIN AUTOCOMPLETADO CONDUCTOR --%>





                        <div class="form-group col-lg-12">

                            <div class="form-group col-lg-6">
                                <label for="userName">Fecha Inicio </label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                    <asp:textbox required spellcheck="false" placeholder="Ingresa fecha inicio" data-provide="datepicker" cssclass="form-control datepickers" id="Textbox4" runat="server"></asp:textbox>
                                </div>
                            </div>

                            <div class="form-group col-lg-6">
                                <label for="userName">Fecha Termino </label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                    <asp:textbox required spellcheck="false" placeholder="Ingresa fecha termino" data-provide="datepicker" cssclass="form-control datepickers" id="Textbox5" runat="server"></asp:textbox>
                                </div>
                            </div>

                        </div>

                       <%-- <div class="form-group col-lg-12">
                            <div class="col-lg-12 text-right">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-instagram m-t-5" Text="Guardar" OnClick="btnGuardarDM_Click"></asp:Button>
                            </div>
                        </div>--%>

                    </div>
                </div>
                <div class="modal-footer"></div>
            </div>
        </div>
    
    <%-- ADMINISTRATIVO --%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
     <script type="text/javascript">
         

                                                    $(document).ready(function () {

                                                        $("input[id*='fch_fin']").change(function () {
                                                            $("input[id*='txtDias']").val();
                                                            var valor1 = $("input[id*='fch_inicio']").val();
                                                            var valor2 = $("input[id*='fch_fin']").val();

                                                            var parts = valor1.split('/');
                                                            var parts2 = valor2.split('/');

                                                            var valor3 = new Date(parts[2], parts[1] - 1, parts[0]);
                                                            var valor4 = new Date(parts2[2], parts2[1] - 1, parts2[0]);
                                                            var newdate = new Date(valor3);
                                                            var newdate2 = new Date(valor4);

                                                            var diasdif= newdate2.getTime()-newdate.getTime();
	                                                        var contdias = Math.round(diasdif/(1000*60*60*24));

                                                            $("input[id*='txtDias']").val(contdias+1);
                                                        });

                                                        $(".tooltip_html").each(function (index) {
                                                            var html = $(this).parent().find(".infoHTML").html();
                                                            $(this).tooltipster({
                                                                content: $(html),
                                                                minWidth: 200,
                                                                maxWidth: 300,
                                                                position: 'top',
                                                                contentAsHTML: true,
                                                                interactive: true
                                                            });
                                                        });
                                                    });


    </script>
</asp:Content>
