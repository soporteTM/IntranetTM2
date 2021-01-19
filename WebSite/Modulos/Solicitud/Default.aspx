<%@ Page Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modulos_Solicitud_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!--Morris Chart CSS -->
    <link rel="stylesheet" href="App_Themes/zircos/default/assets/plugins/morris/morris.css">
    <style>
        .widget-box-two .widget-two-icon {
            position: absolute;
            right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Modulo de Solicitud</h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="#">Solicitud</a>
                    </li>
                    <li class="active">Solicitud
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hfUsuario"/>
    <asp:HiddenField runat="server" ID="hfIdSolicitud" />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                 <div class="row">
                    <div class="col-sm-12">
                        <div class="card-box table-responsive">
                                        <div class="panelOptions col-sm-12 m-b-10" style="text-align: right;">

                                           <%-- <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-primary waves-effect waves-light btn-primary" runat="server" >
                                                <i class="fa fa-search"></i>
                                            </asp:LinkButton>--%>
                                            <%--<asp:LinkButton ID="btnAgregarSolicitud" CssClass="btn btn-primary waves-effect waves-light btn-primary" runat="server" OnClick="btnAgregarSolicitud_Click" >
                                                <span>Nuevo</span>
                                            </asp:LinkButton>--%>
                                            <button class="btn btn-primary waves-effect waves-light btn-primary" data-toggle="modal" data-target="#infoModalAlert6" type="button" data-animation="door">Nuevo</button>
                                            
                                        </div>
                                        
                            <div class="clearfix"></div>
                                           <asp:GridView ID="gvSolicitud" runat="server" AutoGenerateColumns="False" OnPreRender="gvSolicitud_PreRender" OnRowCommand="gvSolicitud_RowCommand" OnRowDataBound="gvSolicitud_RowDataBound"
                                                CssClass="table table-striped table-bordered dataTable" GridLines="None">
                                       
                                                <Columns>
                                                    <asp:BoundField DataField="cd_sol_id" HeaderText="cd_sol_id" Visible="false" />
                                                    <asp:BoundField DataField="cd_sol" HeaderText="# Sol" Visible="true" />
                                                    <asp:TemplateField HeaderText="Servicio">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblServicio" runat="server" Text='<%# Eval("cd_tipo_solicitud") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="cd_emp_creacion" HeaderText="Empresa Creacion" Visible="true" ItemStyle-Width="500px"/>
                                                    <asp:BoundField DataField="cd_tipo_mov" HeaderText="Movimiento" Visible="true" />
                                                    <asp:BoundField DataField="cd_cliente" HeaderText="Cliente" Visible="true" ItemStyle-Width="500px" />
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cant. Cont." Visible="true" />
                                                    <asp:BoundField DataField="cd_tipo_aduana" HeaderText="cd_tipo_aduana" Visible="false" />
                                                    <asp:BoundField DataField="cd_tipo_via" HeaderText="cd_tipo_via" Visible="false" />
                                                    <asp:BoundField DataField="cd_tipo_incoterm" HeaderText="cd_tipo_incoterm" Visible="false" />
                                                    <asp:BoundField DataField="cd_tipo_servicio" HeaderText="cd_tipo_servicio" Visible="false" />
                                                    <asp:BoundField DataField="cd_tipo_cond_emb" HeaderText="cd_tipo_cond_emb" Visible="false" />
                                                    <asp:BoundField DataField="cd_alm_entrada" HeaderText="cd_alm_entrada" Visible="false" />
                                                    <asp:BoundField DataField="cd_alm_devolucion" HeaderText="cd_alm_devolucion" Visible="false" />
                                                    <asp:BoundField DataField="cd_proveedor" HeaderText="cd_proveedor" Visible="false" />
                                                    <asp:BoundField DataField="observaciones" HeaderText="observaciones" Visible="true" />
                                                    <asp:BoundField DataField="aud_usuario_creacion" HeaderText="Usuario" Visible="true" />
                                                    <asp:BoundField DataField="fch_emision2" HeaderText="Fecha" Visible="true" />
                                                    <asp:TemplateField ItemStyle-Width="30px">
                                                    <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <%--<td style="padding: 0 2px;">
                                                                <asp:LinkButton ID="btnDetalle" CommandArgument='<%#Eval("cd_sol")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="Observar"><i class="fa fa-search" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                            </td> --%>
                                                            <td style="padding: 0 2px;">
                                                                <asp:LinkButton ID="btnDetalleContenedor" CommandArgument='<%#Eval("cd_sol")+";"+Eval("cd_cliente")%>' CssClass="btn btn-primary waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="DetalleContenedor"><i class="glyphicon glyphicon-list-alt" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                            </td> 
                                                            <td style="padding: 0 2px;">
                                                                <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("cd_sol")+";"+Eval("cd_cliente")%>' CssClass="btn btn-success waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="DetalleContenedor"><i class="fa fa-truck" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                            </td> 
                                                            <td style="padding: 0 2px;">
                                                                <asp:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("cd_sol")+";"+Eval("cd_cliente")%>' CssClass="btn btn-warning waves-effect waves-light btn-primary m-b-5" runat="server" CommandName="DetalleContenedor"><i class="ion ion-clipboard" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i></asp:LinkButton>
                                                            </td> 
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                        </asp:TemplateField>
                                             </Columns>
                                </asp:GridView>



              <div id="infoModalAlert1" tabindex="-1" role="dialog" class="modal fade">
               <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                           <button type="button" class="close" data-dismiss="modal">
                              <span aria-hidden="true">×</span>
                              <span class="sr-only">Close</span>
                           </button>
                             <h4 class="modal-title m-t-0">Solicitud de Transporte</h4>
                        </div>
                        <div class="modal-body">

                        </div>
                        <div class="modal-footer">

                        </div>
                    </div>
                </div>
            </div>

               <div id="infoModalAlert6" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Registro de Solicitud
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-6" data-toggle="modal" data-target="#infoModalAlert2">
                                    <div class="col-xl-3 col-md-12">
                                <div class="card-box widget-box-two widget-two-primary" >
                                    <i class="mdi mdi-cube widget-two-icon"></i>
                                    <div class="wigdet-two-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">Registro Solicitud</p>
                                        <h5><span data-plugin="counterup">Integral / Operativo</span></h5>
                                        <br />
                                    </div>
                                </div>
                            </div>    
                                </div>
                                <div class="col-lg-6 " data-toggle="modal" data-target="#infoModalAlert5">
                                    <div class="col-xl-3 col-md-12">
                                <div class="card-box widget-box-two widget-two-warning">
                                    <i class="mdi mdi-truck widget-two-icon"></i>
                                    <div class="wigdet-two-content">
                                        <p class="m-0 text-uppercase font-600 font-secondary text-overflow" title="Statistics">Registro Solicitud</p>
                                        <h5><span data-plugin="counterup">Distribucion</span></h5>
                                        <br />

                                    </div>
                                </div>
                            </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer"></div>
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
                            <h4 class="modal-title">Registro de Solicitud (Operativo/Integral)
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="row">
                                    <div class="card-box">
                                                     <div class="col-lg-12">
                                                             <div class="row">
                                                        <div class="form-group col-lg-4">
                                                            <label for="userName">Tipo Via</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlVia" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                         <div class="form-group col-lg-4">
                                                            <label for="userName">Movimiento </label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlMovimiento" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                          <div class="form-group col-lg-4">
                                                            <label for="userName">Servicio </label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlServicio" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                         </div>
                                                             <div class="row">
                                                         <div class="form-group col-lg-4">
                                                            <label for="userName">Aduanas</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlAduanas" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                         <div class="form-group col-lg-2">
                                                            <label for="userName">Incoterm</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlIncoterm" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group col-lg-2">
                                                            <label for="userName">C Emb.</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlCEmb" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group col-lg-4">
                                                            <label for="userName">Tipo Solicitud </label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlOperacion" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                                 </div>
                                                            <div class="row">
                                                                <div class="form-group col-lg-12">
                                                            <label for="userName">Cliente</label>
                                                             <div class="col-lg-11">
                                                                 <asp:TextBox required CssClass="form-control autocomplete" data-url="BuscarCliente.ashx" ID="txtCliente" runat="server"></asp:TextBox>
                                                                 <asp:TextBox ID="txtCliente_id" runat="server" class="form-control" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>
                                                             </div>
                                                             <div class="col-lg-1">
                                                                 <asp:LinkButton runat="server" ID="btnRefrescar" OnClick="btnRefrescar_Click" CssClass="btn btn-instagram"/>
                                                             </div>
                                                         </div>
                                                            </div>
                                                             <div class="row">
                                                                <div class="form-group col-lg-12">
                                                                    <label for="userName">Recojo</label>
                                                                    <asp:DropDownList  CssClass="form-control select2-dropdown" ID="ddlRecojo" runat="server" >
                                                                    </asp:DropDownList>
                                                                </div>
                                                             </div>
                                                         <div class="row">
                                                        <div class="form-group col-lg-12">
                                                            <label for="userName">Devolucion(Vacio)</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlDevolucion" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                             <div class="row">
                                                             <div class="form-group col-lg-12">
                                                            <label for="userName">Observacion </label>
                                                            <asp:TextBox CssClass="form-control" ID="txtObservacion" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                                        </div>
                                                </div>
                                                                </div>
                                                             </div>
                                                     </div>
                                                     </div>
                                <div class="form-group col-lg-12 text-right">
                                    <asp:Button ID="btnGuardarSolicitud" CssClass="btn btn-instagram m-t-5 " runat="server" Text="Guardar" OnClick="btnGuardarSolicitud_Click"></asp:Button>
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
                             <h4 class="modal-title m-t-0">Registro de Solicitud</h4>
                        </div>
                        <div class="modal-body">
                                                      <span class="text-primary icon icon-info-circle icon-5x"></span>
                            <div class="form-group">
                                <div class="row">
                                        <div class="col-lg-6">
                                            <label for="userName">Orden Viaje:</label>
                                            <asp:TextBox ID="txtorden" runat="server" placeholder="Ingresar Orden viaje" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-6">
                                        <label for="userName">Fecha Programada:</label>
                                        <div class="input-group">
                                        <span class="input-group-addon">
                                        <span class="fa fa-calendar"></span></span>
                                        <asp:textbox spellcheck="false" placeholder="Fecha Programada" data-provide="datepicker" cssclass="form-control datepickers" id="txtfch_programada" runat="server"></asp:textbox>
                                        </div>
                                        </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <label for="userName">Cliente:</label>
                                            <asp:TextBox CssClass="form-control autocomplete" data-url="BuscarCliente.ashx" ID="txtCliente2" runat="server" placeholder="Ingresar Cliente"></asp:TextBox>
                                            <asp:TextBox ID="txtCliente2_id" runat="server" class="btn btn-icon waves-effect mdi mdi-refresh m-b-5" style="color: #CCC; position: absolute; background: transparent; z-index: 1;display: none;"></asp:TextBox>

                                        </div>
                                        <div class="col-lg-6">
                                            <br />
                                             <asp:LinkButton runat="server" ID="btnrefresh" OnClick="btnrefresh_Click" CssClass="btn btn-instagram" Height="25px" style="margin:7px"/>
                                        </div>
                                    </div>
                                </div>

                                </div>
                                <div class="form-group">
                                     <div class="row">
                                        <div class="col-lg-12">
                                            <label for="userName">Origen:</label>
                                              <asp:DropDownList ToolTip="Seleccionar Origen"  CssClass="form-control" ID="ddlOrigen" runat="server">
                                             </asp:DropDownList>
                                        </div>
                                         <div class="col-lg-12">
                                            <label for="userName">Destino:</label>
                                              <asp:DropDownList ToolTip="Seleccionar Destino" CssClass="form-control" ID="ddlDestino" runat="server">
                                             </asp:DropDownList>
                                        </div>
                                    
                                </div>
                           </div>
                            <div class="form-group">
                                <div class="row">
                                     <div class="col-lg-6">
                                        <label for="userName">GR Transporte:</label>
                                            <asp:TextBox ID="txtgrtransporte" runat="server" placeholder="Ingresar Gr Transporte" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">
                                        <label for="userName">GR Cliente:</label>
                                            <asp:TextBox ID="txtgrsodimac" runat="server" placeholder="Ingresar Gr Cliente" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="col-lg-6">
                                           <label for="userName">Tipo Unidad:</label>
                                           <asp:DropDownList ToolTip="Seleccionar Unidad" CssClass="form-control" ID="ddlUnidad" runat="server">
                                            
                                               </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <label for="userName">Pick Ticket:</label>
                                            <asp:TextBox ID="txtticket" runat="server" placeholder="Ingresar Pick Ticket" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    <div class="col-lg-12">
                                            <label for="userName">Contenedor:</label>
                                              <asp:TextBox ID="txtcontenedor" runat="server" placeholder="Ingresar contenedor o referencia" CssClass="form-control"></asp:TextBox>
                                        </div>  
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <label for="userName">Observaciones </label>
                                        <asp:TextBox  spellcheck="false"  CssClass="form-control col-12" ID="txtObservaciones" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="col-lg-12 text-right">
                                        <asp:LinkButton ID="btnAsignar" CssClass="btn btn-instagram m-t-5 "  runat="server" Text="Solicitar" OnClick="btnAsignar_Click" ></asp:LinkButton>
                                    </div>
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
                            <h4 class="modal-title">Solicitud Transporte</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                
                                <div class="row">
                                                     <div class="col-lg-12">
                                                        <span class="text-primary icon icon-info-circle icon-5x"></span>
                                                        <asp:TextBox  spellcheck="false" placeholder="Contenedor" CssClass="form-control col-12" ID="txtCodNave" runat="server" Visible="false"></asp:TextBox>
                                                        <div class="form-group col-lg-12">
                                                            <%--<label for="userName">Tipo Solicitud </label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlOperacion" runat="server" >
                                                            </asp:DropDownList>--%>
                                                        </div>
                                                        <div class="form-group col-lg-10">
                                                            <label for="userName"> Proveedor </label>
                                                            <div class="checkbox checkbox-primary" >
                                                                <asp:CheckBox ID="chkProveedor" runat="server" />
                                                                <label for="chkActivo">Transportes Meridian</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group col-lg-10">
                                                            <label for="userName">Observacion </label>
                                                            <%--<asp:TextBox CssClass="form-control" ID="txtObservacion" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>--%>
                                                        </div>
                                                     </div>
                                                     <%--<div class="col-lg-6">
                                                         <h3>Detalle de Contenedores</h3>
                                                            <asp:GridView ID="gvContenedor" runat="server" AutoGenerateColumns="False"
                                                                CssClass="table table-striped table-bordered dataTable">
                                                                <Columns>
                                                                    <asp:BoundField DataField="cod_det_cont_id" HeaderText="cod_det"  Visible="false"/>
                                                                    <asp:BoundField DataField="cd_sol" HeaderText="cod_sol"  Visible="false"/>
                                                                    <asp:BoundField DataField="cd_item" HeaderText="Item"  Visible="false"/>
                                                                    <asp:BoundField DataField="tipoContenedor" HeaderText="Tipo Contenedor"  Visible="true"/>
                                                                    <asp:BoundField DataField="contenedor" HeaderText="Contenedor"  Visible="true"/>
                                                                    <asp:BoundField DataField="st1_descarga" HeaderText="1° Lugar de descarga"  Visible="true"/>
                                                                    <asp:BoundField DataField="st2_descarga" HeaderText="2° Lugar de descarga"  Visible="true"/>
                                                                    <asp:BoundField DataField="carga_suelta" HeaderText="Carga suelta"  Visible="true"/>
                                                                    <asp:BoundField DataField="sol_det_fecha" HeaderText="Fecha cita"  Visible="true"/>
                                                                </Columns>
                                                            </asp:GridView>
                                                     </div>--%>
                                                     </div>
                                <div class="form-group col-lg-12 text-right">
                                    <asp:LinkButton ID="btnSolicitudTransporte" CssClass="btn btn-instagram m-t-5 " runat="server" Text="Guardar" OnClick="btnSolicitudTransporte_Click"></asp:LinkButton>
                                </div>
                                </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
                                        <!-- end col -->

                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <div class="row">
                        <div class="col-md-12" >
                            <div class="panelOptions col-sm-12 m-b-10" style="text-align:right;">
                                        <asp:LinkButton ID="btnAtras" CssClass="btn btn-default waves-effect waves-light btn-default" runat="server" OnClick="btnAtras_Click">Regresar</asp:LinkButton>                   
                                        <asp:LinkButton ID="btnNuevo" CssClass="btn btn-primary waves-effect waves-light btn-primary" runat="server" OnClick="btnNuevo_Click">Nuevo <i class="fa fa-plus"></i></asp:LinkButton>                   
                                        <asp:LinkButton ID="btnImpo" CssClass="btn btn-primary waves-effect waves-light btn-success" runat="server" OnClick="btnImpo_Click">Importar <i class="fa fa-upload"></i></asp:LinkButton>                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        <div class="card-box">
                        <div class="row">
                            <div class="col-lg-12"></div>
                        <div class="col-lg-8">
                            <div class="col-lg-6 m-t-30">
                                <asp:Label runat="server" CssClass="h3">Cliente: </asp:Label>
                                <asp:Label runat="server" CssClass="h3" ID="lblCliente">AUSA</asp:Label>
                            </div>
                            <div class="col-lg-6 m-t-30">
                                <asp:Label runat="server" CssClass="h3">Solicitud: </asp:Label>
                            <asp:Label runat="server" CssClass="h3" ID="lblSolicitud">123456</asp:Label>
                            </div>
                            </div>
                        <div class="col-lg-4">
                            <h3>Resumen de Contenedores</h3>
                        <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable">
                                            <Columns>
                                                <asp:BoundField DataField="cd_sol_det_id" HeaderText="id Solicitud Detalla" visible="false"/>
                                                <asp:BoundField DataField="cd_sol" HeaderText="codigo Solicitud" visible="false"/>
                                                <asp:BoundField DataField="cd_item" HeaderText="Item"/>
                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad"/>
                                                <asp:BoundField DataField="cd_tipo_contenedor" HeaderText="Tipo Contenedor"/>
                                            </Columns>
                                        </asp:GridView>

                        </div>
                            </div>
                            </div>
                           
                            </div>
                        <div class="panel-body">
                            <div class="col-md-12">
                               <%-- <ul class="nav nav-tabs">
                                    <li id="li1" runat="server" class="">
                                        <asp:LinkButton ID="lnkLocal" runat="server" OnClick="lnkLocal_Click"><span class="visible-xs"><i class="fa fa-user"></i></span><span class="hidden-xs">1. Resumen</span></asp:LinkButton></li>
                                    <li id="li2" runat="server" class="">
                                        <asp:LinkButton ID="lnkContacto" runat="server" OnClick="lnkContacto_Click"><span class="visible-xs"><i class="fa fa-users"></i></span><span class="hidden-xs">2. Detalle</span></asp:LinkButton></li>
                                </ul>--%>
                                    <%--<asp:Panel runat="server" ID="PanelLocal">
                                    <div class="row m-t-30">
                                <h3>Resumen de Contenedores</h3>
                                                           
                                                         <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable">
                                            <Columns>
                                                <asp:BoundField DataField="cd_sol_det_id" HeaderText="id Solicitud Detalla" visible="false"/>
                                                <asp:BoundField DataField="cd_sol" HeaderText="codigo Solicitud" visible="false"/>
                                                <asp:BoundField DataField="cd_item" HeaderText="Item"/>
                                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad"/>
                                                <asp:BoundField DataField="cd_tipo_contenedor" HeaderText="Tipo Contenedor"/>
                                            </Columns>
                                        </asp:GridView>
                                                         
                                                     
                                        </div>
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
                                        <asp:DropDownList required CssClass="form-control" ID="ddlDepartamento" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Provincia</label>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlProvincia" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                    <div class="form-group col-lg-4">
                                        <label for="userName">Distrito</label>
                                        <asp:DropDownList required CssClass="form-control" ID="ddlDistrito" runat="server"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="m-t-lg text-right">
                                        <asp:LinkButton ID="lnkRegistrarLocal" runat="server" CssClass="btn btn-info m-t-5" Text="Procesar" > </asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>



                                    </asp:Panel>--%>
                                    <asp:Panel runat="server" ID="PanelContacto" Visible="true">

                                        <div class="row m-t-30">
                                    <div class="col-lg-12">
                                        <h3>Detalle de Contenedores</h3>
                                         <asp:GridView ID="gvContenedorDetalle" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered dataTable">
                                                <Columns>
                                                    <asp:BoundField DataField="cod_det_cont_id" HeaderText="cod_det"  Visible="false"/>
                                                    <asp:BoundField DataField="cd_sol" HeaderText="cod_sol"  Visible="false"/>
                                                    <asp:BoundField DataField="cd_item" HeaderText="Item"  Visible="false"/>
                                                    <asp:BoundField DataField="tipoContenedor" HeaderText="Tipo Contenedor"  Visible="true"/>
                                                    <asp:BoundField DataField="contenedor" HeaderText="Contenedor"  Visible="true"/>
                                                    <asp:BoundField DataField="st1_descarga" HeaderText="1° Lugar de descarga"  Visible="true"/>
                                                    <asp:BoundField DataField="st2_descarga" HeaderText="2° Lugar de descarga"  Visible="true"/>
                                                    <asp:BoundField DataField="carga_suelta" HeaderText="Carga suelta"  Visible="true"/>
                                                    <asp:BoundField DataField="fecha_cita" HeaderText="Fecha cita"  Visible="true"/>
                                                    <asp:BoundField DataField="hora_cita" HeaderText="Hora cita"  Visible="true"/>
                                                </Columns>
                                         </asp:GridView>
                                    </div>
                                </div>



                                    </asp:Panel>

                                            <div id="infoModalAlert3" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">×</span>
                                <span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Detalle de contenedor</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="row">
                                                     <div class="col-lg-12">
                                                         <div class="card-box">
                                                             <div class="row">
                                                        <div class="form-group col-lg-3">
                                                            <label for="userName">Tipo</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlTipoCont" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                         <div class="form-group col-lg-3">
                                                            <label for="userName">Pies </label>
                                                            <asp:TextBox  spellcheck="false" CssClass="form-control col-12" ID="txtPies" runat="server"></asp:TextBox>
                                                        </div>
                                                          <div class="form-group col-lg-3">
                                                            <label for="userName">Prefijo </label>
                                                            <asp:TextBox  spellcheck="false" CssClass="form-control col-12" ID="txtPrefijo" runat="server"></asp:TextBox>
                                                        </div>
                                                          <div class="form-group col-lg-3">
                                                            <label for="userName">Numero</label>
                                                            <asp:TextBox  spellcheck="false" CssClass="form-control col-12" ID="txtNumeroCont" runat="server"></asp:TextBox>
                                                        </div>
                                                         </div>
                                                             <div class="row">
                                                         <div class="form-group col-lg-6">
                                                            <label for="userName">1° Lugar de Descarga</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlDescarga1" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                         <div class="form-group col-lg-6">
                                                            <label for="userName">2° Lugar de Descarga</label>
                                                            <asp:DropDownList  CssClass="form-control" ID="ddlDescarga2" runat="server" >
                                                            </asp:DropDownList>
                                                        </div>
                                                                 </div>
                                                             <div class="row">
                                                        
                                                         <div class="form-group col-lg-4">
                                                            <label for="userName">Fecha Cita </label>
                                                             <asp:TextBox  data-provide="datepicker" data-date-format="dd/mm/yyyy"  parsley-trigger="change" CssClass="form-control" ID="txtFechaCita" runat="server"></asp:TextBox>
                                                        </div>
                                                         
                                                        <div class="form-group clockpicker col-lg-2" data-placement="top" data-align="top" data-autoclose="true">
                                                             <label for="userName">Hora</label>
                                                            <asp:TextBox  spellcheck="false" CssClass="form-control col-12 " ID="txtHoraCita" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-lg-6" style="text-align:center">
                                                            <div class="checkbox checkbox-primary m-t-20" >
                                                                <asp:CheckBox ID="chkCargaSuelta" runat="server" />
                                                                <label for="chkActivo">Carga Suelta</label>
                                                            </div>
                                                        </div>
                                                                </div>

                                                             <div style="text-align:right">
                                                             <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary waves-effect waves-light btn-success" runat="server" OnClick="btnAgregarContenedor_Click">Agregar <i class="fa fa-plus"></i></asp:LinkButton>                   
                                                             </div>
                                                             </div>
                                                     </div>
                                    </div>
                                                
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>
                                <div id="infoModalAlert7" tabindex="-1" role="dialog" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        
                        <div class="modal-body">
                            <div class="row">
                                <span class="text-primary icon icon-info-circle icon-5x"></span>
                                <div class="row" style="text-align:center">
                                              <span class="text-success fa fa-file-excel-o  widget-one-icon" style="font-size:75px;"></span>
                                               <h3 class="text-success"> Archivo Excel</h3>
                                    <p>Seleccionar el arhivo excel que registrara la informacion en el sitema.</p>
                                    <div class="form-group col-lg-12" >
                                        <div class="col-lg-6">
                                            <asp:FileUpload CssClass="form-control" ID="fuImportar" runat="server" />
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:LinkButton ID="lnkImportar" CssClass="btn btn-primary waves-effect waves-light btn-success col-lg-12" runat="server" OnClick="lnkImportar_Click">Procesar<i class="fa fa-upload m-l-5"></i></asp:LinkButton>
                                        </div>
                                                         
                                                             </div>
                                    </div>
                                                
                            </div>
                        </div>
                        <div class="modal-footer"></div>
                    </div>
                </div>
            </div>

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
                                            <asp:TextBox required data-provide="datepicker" CssClass="form-control datepickers" ID="txtFchNacimiento" runat="server"></asp:TextBox>
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
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                        </div>
                                </div>

                                <div class="form-group col-lg-12">
                                    <div class="m-t-lg text-right">
                                        <asp:Button ID="lnkRegistrarContacto" runat="server" CssClass="btn btn-info m-t-5" Text="Procesar"> </asp:Button>
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
    </asp:MultiView>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="Server">
    <!-- Google Charts js -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <!-- Init -->
    <script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/initReportes.js")%>'></script>

    
</asp:Content>

