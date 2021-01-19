<%@ Page Title="" Language="C#" MasterPageFile="~/Templete.master" AutoEventWireup="true" CodeFile="SeguimientoTransportes.aspx.cs" Inherits="Modulos_TMS_SeguimientoTransportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <div class="page-title-box">
                <h4 class="page-title">Módulo de Seguimiento</h4>
                <ol class="breadcrumb p-0 m-0">
                    <li>
                        <a href="default.aspx">Solicitud de Transporte</a>
                    </li>
                    <li class="active">Seguimento
                    </li>
                </ol>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="Viwe1" runat="server">

            <div class="row">
                <div class="col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <asp:HiddenField ID="lblMensaje" runat="server"/>
                                <div class="col-lg-4">
                                    <h4 class="header-title">Detalle de Contenedores</h4>
                                </div>

                                <div class="col-lg-8 text-right">
                                   <%-- <asp:LinkButton ID="btnFiltrarSolicitudes" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnFiltrarSolicitudes_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-search"></i> Buscar
                                    </asp:LinkButton> 
                                    
                                      <asp:LinkButton ID="btnAnularSolicitud" runat="server" CssClass="btn btn-danger btn-sm" OnClientClick="JConfirm('¿Esta seguro de anular las solicitudes?','Confirmar Acción', this); return false;" OnClick="btnAnularSolicitud_Click">
                                        <i class="glyphicon glyphicon-trash"></i> Anular Solicitud
                                    </asp:LinkButton> 

                                     <asp:LinkButton ID="btnProgramacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnProgramacion_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-road"></i> Programación
                                    </asp:LinkButton> 
                                    <asp:LinkButton ID="btnAgregarSeguimiento" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-time"></i> Seguimiento
                                    </asp:LinkButton> 
                                     <asp:LinkButton ID="btnFacturacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnAgregarSeguimiento_Click" OnClientClick="$('.loading').fadeIn('fast');">
                                        <i class="glyphicon glyphicon-check"></i> Facturación
                                    </asp:LinkButton> --%>

                                    <asp:LinkButton ID="btnGrabar" CssClass="btn btn-info waves-effect waves-light" runat="server" OnClick="btnGrabar_Click">
                                        <span class="m-r-5"> Grabar </span>
                                    </asp:LinkButton> 

                                    <asp:LinkButton ID="btnEnviarCorreo" CssClass="btn btn-info waves-effect waves-light" runat="server" OnClick="btnEnviarCorreo_Click" Visible="false">
                                        <span class="m-r-5"> Enviar Correo </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnMonitoreo" CssClass="btn btn-info waves-effect waves-light" runat="server" OnClick="btnMonitoreo_Click" Visible="false">
                                        <span class="m-r-5"> Monitoreo </span>
                                    </asp:LinkButton>

                                     <asp:LinkButton ID="btnAgregarContenedor" runat="server" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarContenedor_Click">
                                        <i class="glyphicon glyphicon-plus"></i> Agregar Contenedor
                                    </asp:LinkButton> 

                                     <asp:LinkButton ID="btnRegresar" runat="server" CssClass="btn btn-default btn-sm" OnClick="btnRegresar_Click" >
                                        <i class="glyphicon  glyphicon-repeat"></i> Regresar
                                    </asp:LinkButton> 
                                      
                                </div>

                                <div class="clearfix"></div>
                            </div>
                        </div>

                        <div class="panel-body" style="padding-bottom:10px;"> 
           

                            <%--inicio del segundo card--%>
                            <div class="card-box table-responsive"  > 
                               <asp:GridView ID="grvSolicitudes" runat="server" CssClass="table table-striped table-bordered dataTable" Style="display: none;" >
                                   <Columns>
                                       <asp:TemplateField>
                                           <ItemTemplate>
                                               <asp:CheckBox ID="chkVer" runat="server"/>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>

                            </div>

                            <%--inicio del tercer card--%>
                            
                            <asp:GridView ID="grvContenedores" runat="server" CssClass="table table-striped table-bordered dataTable" AutoGenerateColumns="False"
                                EmptyDataText="No se encontraron contenedores" OnRowDataBound="grvContenedores_RowDataBound" OnRowEditing="grvContenedores_RowEditing"
                                OnRowCancelingEdit="grvContenedores_RowCancelingEdit" OnRowCommand="grvContenedores_RowCommand" OnRowUpdating="grvContenedores_RowUpdating" >
                                <Columns>
                                    <asp:TemplateField>
                                        <%--<HeaderTemplate>
                                                <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" AutoPostBack="True" 
                                                OnCheckedChanged="HeaderLevelCheckBox_CheckedChanged" />
                                        </HeaderTemplate>--%>
                                        <ItemTemplate>
                                            <div class="btn-group dropdown">
                                                <button style="" class="btn btn-default btn-sm dropdown-toggle"
                                                    data-toggle="dropdown" type="button"><%-- style="padding: 2px 5px;"--%>
                                                    <span class="icon icon-gear icon-sx icon-fw">Opciones</span>
                                                    <!--Opciones-->
                                                    <span class="caret"></span>
                                                </button>
                                                <ul class="dropdown-menu">
                                                    <li>
                                                        <asp:LinkButton ToolTip="Asignar" CommandName="Asignar" CommandArgument='<%# Eval("Contenedor") + ";" + Eval("[Fecha Cita]") + ";" + Eval("Evento") + ";" + Eval("[RO/AL]") + ";" + Eval("Item") %>' CssClass="icon-list-primary" runat="server"><i class="icon icon-download" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i> Asignar Horas </asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ToolTip="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("[RO/AL]") + ";" + Eval("Contenedor") %>' CssClass="icon-list-primary" runat="server"><i class="icon icon-download" style="width:18px; height:18px; line-height:18px; font-size:18px;"></i> Eliminar </asp:LinkButton>
                                                    </li>
                                                    
                                                </ul>
                                            </div>
                                            <%--<asp:Label ID="lblCarga" runat="server" Text='<%# Eval("dbCarga") %>'
                                                Visible="False"></asp:Label>--%>
                                        </ItemTemplate>
                                        <EditItemTemplate></EditItemTemplate>
                                        <%--<ItemStyle CssClass="details-control" Wrap="False" />--%>
                                    </asp:TemplateField>

                                    <asp:CommandField ShowEditButton="True" UpdateText="Actualizar" CancelText="Cancelar"
                                        EditText="Editar" > 
                                
                                        <ItemStyle Wrap="False" />
                                    </asp:CommandField>

                                    <asp:TemplateField HeaderText="RO/AL">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemROAL" runat="server" Text='<%# Eval("[RO/AL]") %>'></asp:Label>
                                            <asp:Label ID="lblSolicitud" runat="server" Text='<%# Eval("Solicitud") %>' Style="display: none;"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditROAL" runat="server" Text='<%# Eval("[RO/AL]") %>'></asp:Label>
                                            <asp:Label ID="lblSolicitud" runat="server" Text='<%# Eval("Solicitud") %>'
                                                Visible="False"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contenedor">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContenedor" runat="server" Text='<%# Eval("Contenedor") %>'></asp:Label><asp:Label ID="lblItem" Style="display: none;" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditContenedor" runat="server" CssClass="form-control"
                                                Text='<%# Eval("Contenedor") %>'></asp:TextBox>
                                            <asp:Label ID="lblItem" runat="server" Text='<%# Eval("Item") %>'
                                                Visible="False"></asp:Label>
                                            <asp:Label ID="lblAntCont" runat="server" Text='<%# Eval("Contenedor") %>'
                                                Visible="False"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pies">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemPies" runat="server" Text='<%# Eval("Pies") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPies" runat="server" CssClass="form-control" Text='<%# Eval("Pies") %>'
                                                Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemTipo" runat="server" Text='<%# Eval("Tipo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="select60">
                                                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="select">
                                                </asp:DropDownList>
                                            </div>
                                            <asp:Label ID="lblTipoCon" runat="server" Text='<%# Eval("Tipo") %>'
                                                Visible="False"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tara">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTara" runat="server" Text='<%# Eval("Tara") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTara" runat="server" CssClass="form-control" Text='<%# Eval("Tara") %>'
                                                Width="54px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Peso">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPeso" runat="server" Text='<%# Eval("Peso") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" Text='<%# Eval("Peso") %>'
                                                Width="50px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Payload">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPyld" runat="server" BorderStyle="None"
                                                Text='<%# Eval("Pyload") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPyload" runat="server" CssClass="form-control" Text='<%# Eval("Pyload") %>'
                                                Width="61px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Fecha Cita">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemFecCita" runat="server"
                                                Text='<%# Eval("[Fecha Cita]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFecCita" runat="server" CssClass="form-control datepicker" MaxLength="10"
                                                Text='<%# Eval("[Fecha Cita]") %>' Width="74px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Hora Cita">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemHoraCita" runat="server" MaxLength="5" onkeyup="formataHora(this, event);"
                                                Text='<%# Eval("[Hora Cita]") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtHoraCita" runat="server" CssClass="form-control" Text='<%# Eval("[Hora Cita]") %>'
                                                Width="53px" onkeyup="formataHora(this, event);" MaxLength="5"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Placa">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPlaca" runat="server" Text='<%# Eval("Placa") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="txtPlaca" runat="server" Text='<%# Eval("Placa") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Evento">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlEvento" runat="server" CssClass="form-control" DataTextField="EVENTO_DESCRIPCION"
                                                DataValueField="EVENTO_CODIGO">
                                            </asp:DropDownList> 
                                            <asp:Label ID="lblNum" runat="server" Text='<%# Eval("Evento") %>'
                                                Visible="False"></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlEvento" runat="server" CssClass="text1"
                                                Visible="False">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblNum" runat="server" Text='<%# Eval("Evento") %>'
                                                Visible="False"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Servicio">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnkbtn_Click"
                                                Text='<%# Eval("SERVICIO") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                
                            <div id="modalConfirmarEliminarContenedor" tabindex="-1" role="dialog" class="modal fade">
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
                                                <h3 class="text-success">¿Está SEGURO de ELIMINAR este local?</h3>
                                                <p>Debe estar seguro antes de ejecutar la siguiente accion, ya que no se podrá revertir.</p>
                                                <div class="m-t-lg">
                                                    <asp:LinkButton ID="btnConfirmarEliminarContenedor" CssClass="btn btn-success" runat="server" OnClick="btnConfirmarEliminarContenedor_Click"><i class="fa m-r-5"></i> <span>   Confirmar</span>  </asp:LinkButton>
                                                    <button class="btn btn-default" data-dismiss="modal" type="button">Cancelar</button>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="modal-footer"></div>
                                    </div>
                                </div>
                            </div>

                            <div id="modalAsignacion" class="modal fade" tabindex="-1" role="dialog" style="display: none;">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                     Contenedor:
                                            <asp:Label ID="lblTittle" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-lg-6 text-right">
                                                       <asp:LinkButton class="btn btn-primary btn-sm" ID="btnGuardarAsignacion" OnClick="btnGuardarAsignacion_Click" runat="server"><i class="glyphicon glyphicon-check"></i> Actualizar información</asp:LinkButton>
                                                  <button type="button" class="btn btn-default btn-sm" data-dismiss="modal"><i class="fa fa-close"></i> Cerrar</button>
                                                   </div>
                                            </div>
                                           
                                           <%-- <button type="button" class="close" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                                <span class="sr-only">Cerrar</span>
                                            </button>--%>
                                        </div>
                                        <div class="modal-body" style="padding-bottom:0px;">
                                            <div class="row">
                                                <asp:HiddenField ID="hfTSol" runat="server" />
                                                <asp:HiddenField ID="hfTipSol" runat="server" />
                                                <asp:HiddenField ID="hfEnt1" runat="server" />
                                                <asp:HiddenField ID="hfEnt2" runat="server" />
                                                <asp:HiddenField ID="hfsol" runat="server" />
                                                <asp:HiddenField ID="hfSoli" runat="server" />
                                                <asp:HiddenField ID="hfFechaSoli" runat="server" />
                                                <asp:HiddenField ID="hfHoraSoli" runat="server" />
                                                <asp:HiddenField ID="hfEvento" runat="server" />
                                                <asp:HiddenField ID="hfAL" runat="server" />
                                                <asp:HiddenField ID="hfContenedor" runat="server" />
                                                <asp:HiddenField ID="hfMovimiento" runat="server" />
                                                <asp:HiddenField ID="hfAction" runat="server" />
                                                <div class="col-md-4" style="padding-right:20px;">
                                                    <div class="card-box" style="padding:0px;border:none;">
                                                        <div class="card-header bg-light">
                                                            <h4 class="card-title panel-title">Terminal de Retiro</h4>
                                                        </div>
                                                        <div class="card-body" style="padding-top:15px;">
                                                    
                                                            <div class="form-group">
                                                                <asp:Label runat="server" >Terminal</asp:Label>
                                                                <asp:DropDownList runat="server" ID="ddlTerminalRetiro" CssClass="form-control" ></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">
                                                                
                                                                <div class="row panelHora p1">
                                                                    <div class="col-md-3">
                                                                        <asp:Label runat="server" >Llegada</asp:Label>
                                                                        </div>
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpRetiroLlegadaFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox  AutoCompleteType="Disabled" placeholder="Hora" cssclass="form-control" id="txtRetiroLlegadaHora" 
                                                                            runat="server" data-toggle="input-mask" data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="row panelHora p2">
                                                                    <div class="col-md-3">
                                                                        Ingreso
                                                                    </div>
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpRetiroIngresoFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtRetiroIngresoHora" placeholder="Hora" cssclass="form-control" data-toggle="input-mask" 
                                                                            data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="row panelHora p3">
                                                                    <div class="col-md-3">
                                                                        Salida
                                                                    </div>
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpRetiroSalidaFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtRetiroSalidaHora" placeholder="Hora" cssclass="form-control" data-toggle="input-mask" 
                                                                            data-mask-format="00:00:00" maxlength="8" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:Label runat="server" >Observación</asp:Label>
                                                                <asp:TextBox runat="server" ID="txtRetiroObservacion" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                        </div>
                                                    </div>


                                                </div>
                                    
                                                <div class="col-md-4" style="padding:0px;">
                                                    <div class="card-box" style="padding:0px 20px;border-top:none;border-bottom:none;border-radius: 0px;margin-bottom: 0px;padding-bottom: 10px;">
                                                        <div class="card-header bg-light">
                                                            <h4 class="card-title panel-title">Cliente</h4>
                                                        </div>
                                                        <div class="card-body" style="padding-top:15px;">

                                                            <div class="form-group">
                                                                <asp:Label runat="server" >Local</asp:Label>
                                                                <asp:DropDownList runat="server" ID="ddlClienteLocal" CssClass="form-control" ></asp:DropDownList>
                                                            </div>
                                                            <div class="form-group">                                                        
                                                                <div class="row panelHora p4">
                                                                    <div class="col-md-3">
                                                                        Llegada
                                                                    </div> 
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpClienteLlegadaFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtClienteLlegadaHora" CssClass="form-control" placeholder="Hora" data-toggle="input-mask" 
                                                                            data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">                                                       
                                                                <div class="row panelHora p5">
                                                                     <div class="col-md-3">
                                                                        Ingreso
                                                                        </div> 
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpClienteIngresoFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtClienteIngresoHora" CssClass="form-control" placeholder="Hora" data-toggle="input-mask" 
                                                                            data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group"> 
                                                                <div class="row panelHora p6">
                                                                     <div class="col-md-3">
                                                                        Inicio
                                                                        </div> 
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpClienteInicioFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtClienteInicioHora" placeholder="Hora" cssclass="form-control " data-toggle="input-mask" 
                                                                            data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group"> 
                                                                <div class="row panelHora p7">
                                                                    <div class="col-md-3">
                                                                        Termino
                                                                        </div>
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpClienteTerminoFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtClienteTerminoHora" placeholder="Hora" cssclass="form-control " data-toggle="input-mask" 
                                                                            data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group"> 
                                                                <div class="row panelHora p8">
                                                                    <div class="col-md-3">
                                                                        Salida
                                                                        </div>
                                                                    <div class="col-md-5">
                                                                        <asp:TextBox runat="server" ID="dtpClienteSalidaFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtClienteSalidaHora" placeholder="Hora" cssclass="form-control " data-toggle="input-mask" 
                                                                            data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <asp:Label runat="server" >Observación</asp:Label>
                                                                <asp:TextBox runat="server" ID="txtClienteObservacion" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                                                            </div>

                                                         </div>
                                                    </div>
                                                </div>
                                    
                                                <div class="col-md-4" style="padding-left:20px;">
                                                    <div class="card-box" style="padding:0px;border:none;">
                                                        <div class="card-header bg-light">
                                                            <h4 class="card-title panel-title">Terminal de Devolución</h4>
                                                        </div>
                                                        <div class="card-body" style="padding-top:15px;">

                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Terminal</asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlTerminalDevolucion" CssClass="form-control" ></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group"> 
                                                        <div class="row panelHora p9">
                                                            <div class="col-md-3">
                                                                Llegada
                                                                </div>
                                                            <div class="col-md-5">
                                                                <asp:TextBox runat="server" ID="dtpDevolucionLlegadaFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:TextBox runat="server" ID="txtDevolucionLlegadaHora" placeholder="Hora" cssclass="form-control " data-toggle="input-mask"
                                                                    data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group"> 
                                                        <div class="row panelHora p10">
                                                            <div class="col-md-3">
                                                                Ingreso
                                                                </div>
                                                            <div class="col-md-5">
                                                                <asp:TextBox runat="server" ID="dtpDevolucionIngresoFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:TextBox runat="server" ID="txtDevolucionIngresoHora" placeholder="Hora" cssclass="form-control " data-toggle="input-mask" 
                                                                    data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group"> 
                                                        <div class="row panelHora p11">
                                                            <div class="col-md-3">
                                                                Salida
                                                                </div>
                                                            <div class="col-md-5">
                                                                <asp:TextBox runat="server" ID="dtpDevolucionSalidaFecha" CssClass="datepicker form-control" AutoComplete="Off"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:TextBox runat="server" ID="txtDevolucionSalidaHora" placeholder="Hora" cssclass="form-control " data-toggle="input-mask" 
                                                                    data-mask-format="00:00" maxlength="5" AutoComplete="Off"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="checkbox checkbox-primary">
                                                        <asp:CheckBox runat="server" ID="chkNoDevolucion" Text="No hay devolución"/>
                                                            </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Observación</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtObservacionDevolucion" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                                                    </div>

                                                         </div>
                                                    </div> 
                                                </div>
                                    
                                            </div>
                                            <div class="row" title="Más Información" style="padding-top: 20px;border-top: 2px solid #f3f3f3;">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Empresa</asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlEmpresaInfo" CssClass="form-control" OnSelectedIndexChanged="ddlEmpresaInfo_SelectedIndexChanged" 
                                                            AutoPostBack="true" AutoComplete="Off"></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Kilometraje</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtKmInicialInfo" CssClass="form-control" AutoComplete="Off">Inicial</asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Precinto Linea</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtPrecintoLineaInfo" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group"> 
                                                        <div class="checkbox checkbox-primary">
                                                        <asp:CheckBox runat="server" Checked="true" ID="chkEnviarCorreoInfo" Text="Enviar Correo" />
                                                            </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Unidad</asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlUnidadInfo" CssClass="form-control" ></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Kilometraje</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtKmFinalInfo" CssClass="form-control" AutoComplete="Off">Final</asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Precinto Aduana</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtPrecintoAduanaInfo" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                                                    </div>
                                                    <%--<div class="form-group">
                                                        <asp:Label runat="server" >Doble Carga</asp:Label>
                                                        <asp:CheckBox runat="server" Checked="false" ID="chkDobleCargaInfo"/>
                                                    </div>--%>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Chofer</asp:Label>
                                                        <asp:DropDownList runat="server" ID="ddlChoferInfo" CssClass="form-control" ></asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Precinto CTN Vacío</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtPrecintoVacioInfo" CssClass="form-control" AutoComplete="Off">Inicial</asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Label runat="server" >Precinto Tránsito</asp:Label>
                                                        <asp:TextBox runat="server" ID="txtPrecintoTransitoInfo" CssClass="form-control" AutoComplete="Off"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                       
                                                        <div class="checkbox checkbox-primary">
                                                        <asp:CheckBox runat="server" ID="chkPernocteInfo" Checked="false" Text="Pernocte" />
                                                            </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div> 
                                    </div>
                                </div>

                            </div>

                            <div id="modalAgregarContenedor" tabindex="-1" role="dialog" class="modal fade">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                                <span class="sr-only">Close</span>
                                            </button>

                                            <h4 class="modal-title">Registro de Contenedor</h4>

                                        </div>
                                        <div class="modal-body">
                                
                                                <div class="form-group col-lg-6">

                                                    <label for="name-1" class="control-label">RO/AL </label>
                                                        <asp:DropDownList CssClass="form-control" ID="ddlMantROAL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMantROAL_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                        
                                                </div>


                                                <div class="form-group col-lg-6">

                                                    <label for="name-1" class="control-label">Solicitud</label>
                                            
                                                        <asp:DropDownList CssClass="form-control" ID="ddlMantTipo" runat="server" >
                                                        </asp:DropDownList>
                                        
                                                </div>

                                                <div class="form-group col-lg-6">

                                                    <label for="name-1" class="control-label">Contenedor </label>
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <asp:TextBox required CssClass="form-control" ID="txtMantPrefijoCont" runat="server"/>
                                                            </div>
                                                            <div class="col-md-8">
                                                                <asp:TextBox cssclass="form-control" id="txtMantSufijoCont" runat="server"/>
                                                                <%--<asp:TextBox runat="server" ID="txtRetiroLlegadaHora" CssClass="form-control" placeholder="Hora"></asp:TextBox>--%>
                                                            </div>
                                                        </div>
                                        
                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Tipo </label>
                                                        <asp:DropDownList CssClass="form-control" ID="ddlMantSolicitud" runat="server" >
                                                        </asp:DropDownList>

                                        
                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Pies </label>
                                            
                                                        <asp:TextBox required CssClass="form-control" ID="txtMantPies" runat="server"></asp:TextBox>

                                       
                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Tara </label>
                                            
                                                        <asp:TextBox required CssClass="form-control" ID="txtMantTara" runat="server"></asp:TextBox>

                                        
                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Fecha Cita</label>
                                            
                                                        <asp:TextBox required placeholder="dd/MM/yyyy" data-provide="datepicker" CssClass="form-control datepicker" ID="txtMantFchCita" runat="server"></asp:TextBox>

                                        
                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Hora Cita </label>
                                                    <asp:TextBox required CssClass="form-control" ID="txtMantHoraCita" runat="server"></asp:TextBox>

                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Peso </label>
                                            
                                                        <asp:TextBox required CssClass="form-control" ID="txtMantPeso" runat="server"></asp:TextBox>

                                        
                                                </div>

                                                <div class="form-group col-lg-6">
                                                    <label for="name-1" class="control-label">Payload </label>
                                                        <asp:TextBox required CssClass="form-control" ID="txtMantPayload" runat="server"></asp:TextBox>

                                        
                                                </div>



                                                <div class="col-lg-12 m-t-lg text-right">
                                                    <asp:LinkButton ID="btnRegistrarContenedor" CssClass="btn btn-info waves-effect waves-light m-b-5 m-t-15" runat="server" OnClick="btnRegistrarContenedor_Click">
                                                        <i class="fa fa-save m-r-5"></i> <span>Procesar</span>
                                                    </asp:LinkButton>
                                                </div>
                                
                                        </div>
                                        <div class="modal-footer"></div>
                                    </div>
                                </div>
                            </div>                            

                        </div>
                    </div>
                </div>
            </div>  

        </asp:View>


    </asp:MultiView>

    <style>

        .modal-lg{
            max-width:900px !important;
        }

    </style>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="input-mask"]').each(function (a, e) { var t = $(e).data("maskFormat"), n = $(e).data("reverse"); null != n ? $(e).mask(t, { reverse: n }) : $(e).mask(t) });          
            validarInputHoras();
            $('.panelHora input[type=text]').each(function (a, e) {
                $(this).change(function () {
                    //alert($(this).attr("id"));
                    validarInputHoras();
                });
            });
        });
        function validarInputHoras() {
            $(".panelHora input[type=text]").attr("disabled", "disabled");
            var tope = 0;
            $('.panelHora').each(function (a, e) {
                if ($('.panelHora').eq(a).find("input[type=text]").eq(0).val() != "" && $('.panelHora').eq(a).find("input[type=text]").eq(1).val() != "") {
                    $('.panelHora').eq(a).find("input[type=text]").removeAttr("disabled");
                    tope = a + 1;
                }
                else {
                    if (tope == a)
                        $('.panelHora').eq(a).find("input[type=text]").removeAttr("disabled");
                    else {

                    }
                }
                //alert($('.panelHora').eq(a).find("input[type=text]").eq(0).val());
                //alert($('.panelHora').eq(a).find("input[type=text]").eq(1).val());
               // ($('.panelHora').eq(a).find("input[type=text]").val() == "")
            });

            if (tope == 0)
                $('.panelHora').eq(0).find("input[type=text]").removeAttr("disabled");
        }
    </script>
</asp:Content>